
const SIGN_IN_URL = 'http://localhost:5129/signin';
const USER_INFO_URL = 'http://localhost:5129/hello';
const ABOUT_ME = document.getElementsByClassName('about_me')[0];
const SIGN_IN_BUTTON = document.getElementById("sign_in_button");

function signIn() {
    const currentUrl = window.location;
    window.location = encodeURI(`${SIGN_IN_URL}?ReturnUrl=${currentUrl}`);
}

function aboutMe() {
    fetch(USER_INFO_URL, {
        method: 'GET',
        redirect: 'manual'
    })
        .then(
            response => {
                if (response.status === 200) {
                       response.text()
                           .then(text => ABOUT_ME.innerText = text);
                } else {
                    throw new Error('The user is not authenticated');
                }
            } 
        )
        .catch(
            error => {
                ABOUT_ME.innerText = error.innerText;
            }
        )
}

SIGN_IN_BUTTON.addEventListener('click', () => signIn());
aboutMe();
