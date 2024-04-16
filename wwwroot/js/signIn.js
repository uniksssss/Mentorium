
export function signIn(signInLocation, currentLocation) {
    console.log(signInLocation);
    console.log(currentLocation);
    window.location = encodeURI(`${signInLocation}?ReturnUrl=${currentLocation}`);
}
