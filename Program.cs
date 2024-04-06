using System.Security.Claims;
using AspNet.Security.OAuth.GitHub;
using Mentorium;
using Microsoft.AspNetCore.Authentication.Cookies;

var configuration = new Configuration();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>  
    options.AddPolicy("Development", policyBuilder =>
    {
        policyBuilder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(
                origin => !string.IsNullOrWhiteSpace(origin) &&
                          origin.StartsWith("http://localhost", StringComparison.CurrentCultureIgnoreCase)
                );
    })  
);  

builder.Services.AddAuthentication(o =>
    {
        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = GitHubAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(o =>
    {
        o.LoginPath = "/signin";
        o.LogoutPath = "/signout";
    })
    .AddGitHub(o =>
    {
        o.ClientId = configuration.ClientId!;
        o.ClientSecret = configuration.ClientSecret!;
        o.CallbackPath = "/signin-github";
        
        o.Scope.Add("read:user");
        
        o.Events.OnCreatingTicket += context =>
        {
            if (context.AccessToken is { })
            {
                context.Identity?.AddClaim(new Claim("access_token", context.AccessToken));
            }
            
            return Task.CompletedTask;
        };

        o.SaveTokens = true;
    });

builder.Logging.ClearProviders().AddConsole();

var app = builder.Build();

app.UseCors("Development");

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapGet("/", () => "Hello, World!");

app.Run();