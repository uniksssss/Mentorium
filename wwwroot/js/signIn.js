
export function signIn(signInLocation, currentLocation) {
    window.location = encodeURI(`${signInLocation}?ReturnUrl=${currentLocation}`);
}
