import {signIn} from "./signIn.js";

const USER_INFO_URL = 'http://localhost:5129/hello';
const ABOUT_ME = document.getElementsByClassName('about_me')[0];
const SIGN_IN_BUTTON = document.getElementById("sign_in_button");

function aboutMe() {
    fetch(USER_INFO_URL, {
        method: 'GET'
    })
        .then(
            response => {
                console.log(response.status);
                console.log(response.headers);
                console.log(window.location);
                if (response.status === 401) {
                    signIn(response.headers.get('location'), window.location.toString());
                }
            } 
        )
        .catch(
            error => {
                ABOUT_ME.innerText = error.innerText;
            }
        )
}

SIGN_IN_BUTTON.addEventListener('click', () => signIn(window.location));
aboutMe();
