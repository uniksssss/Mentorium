
const SIGN_IN_URL = 'http://localhost:5129/signin';

export function signIn(returnLocation) {
    window.location = encodeURI(`${SIGN_IN_URL}?ReturnUrl=${returnLocation}`);
}
