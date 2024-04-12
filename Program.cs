using System.Security.Claims;
using AspNet.Security.OAuth.GitHub;
using Mentorium;
using Mentorium.Models;
using Mentorium.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

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
                )
            .WithExposedHeaders("Location");
    })  
);  

builder.Services.AddAuthentication(o =>
    {
        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(o =>
    {
        o.LoginPath = "/signin";
        o.LogoutPath = "/signout";
        o.Events.OnRedirectToLogin = context =>
        {
            var uri = new Uri(context.RedirectUri);
            context.Response.StatusCode = 401;
            context.Response.Headers.Location = uri.AbsolutePath;
            return Task.CompletedTask;
        };
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

builder.Services.AddDbContext<MentoriumDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});
builder.Services.AddScoped<Repo, Repo>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<MentoriumDbContext>();
    db!.Database.Migrate();   
}

app.UseCors("Development");

app.UseAuthentication();
app.UseAuthorization();

app.UseFileServer();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();