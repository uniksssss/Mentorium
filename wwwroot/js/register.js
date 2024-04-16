import { signIn } from "./signIn.js";

function submitForm() {
    event.preventDefault();

    const formData = {
        first_name: document.getElementById("first_name").value,
        last_name: document.getElementById("last_name").value
    };

    const jsonData = JSON.stringify(formData);

    fetch('http://localhost:5129/api/users/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonData
    })
        .then(response => {
            console.log(response);
            if (response.status === 401) {
                signIn(response.headers.get('location'), window.location.toString());
            }
        });
}