import {signIn} from "./signIn.js";

const form = document.createElement('form');
form.id = 'register_form';
form.onsubmit = function() {
    const formData = new FormData(form);    

    const object = {};
    formData.forEach(function(value, key){
        object[key] = value;
    });
    const json = JSON.stringify(object);
    console.log(json);

    fetch('http://localhost:5129/api/users/register', {
        method: 'POST',
        body: json,
    })
        .then(response => {
            console.log(response.status);
            console.log(response.headers);
            if (response.status === 401) {
                signIn(response.headers.get('location'), window.location.toString());
            }
        })
        .catch(error => {
            console.log(error);
        })
}

form.appendChild();

const body = document.getElementsByTagName('body')[0];
body.appendChild(form);
