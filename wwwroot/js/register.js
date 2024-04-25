import { signIn } from "./signIn.js";

const CHECK_URL = 'http://localhost:5129/api/check';
const ME_URL = 'http://localhost:5129/me';

const URL_PARAMS = new URLSearchParams(window.location.search);
const IS_MENTOR = URL_PARAMS.get('is_mentor') === "true";

fetch(CHECK_URL)
    .then(response => {
        if (response.status === 401) {
            signIn(response.headers.get('location'), window.location);
        } else if (!response.ok) {
            throw new Error('Ошибка...');
        }
    })
    .catch(error => {
        console.log(error);
    });

console.log(IS_MENTOR);

document
    .querySelector('button')
    .addEventListener('click', (e) => {
        e.preventDefault();
        console.log('!');

        const formData = {
            firstName: document.querySelector("#first_name").value,
            lastName: document.querySelector("#last_name").value,
            description: document.querySelector("#description").value,
            telegramId: document.querySelector("#telegram").value,
            isMentor: IS_MENTOR,
        };
        
        const json = JSON.stringify(formData);
        console.log(JSON.stringify(formData));

        fetch('http://localhost:5129/api/users/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: json
        })
            .then(response => {
                if (response.ok) {
                    window.location = ME_URL;
                } else if (response.status === 401) {
                    signIn(response.headers.get('location'), window.location.toString());
                }
            });
    });