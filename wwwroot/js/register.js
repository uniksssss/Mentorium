import {signIn} from "./signIn.js";

const form = document.createElement('form');
const REGISTER_URL = 'http://localhost:5129/api/users/register'

async function onSubmit() {
    const user = new FormData(document.getElementById("myForm"));
    
    fetch(REGISTER_URL, {
        method: 'POST',
        body: user,
        redirect: 'manual'
    })
        .then(response => {
            console.log(response.status);
            if (response.redirected) {
                signIn(window.location);
            }
        })
        .catch(error => {
            console.log(error);
        });
}

form.addEventListener('submit', () => onSubmit());
