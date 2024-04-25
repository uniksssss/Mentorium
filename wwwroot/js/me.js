
const ME_INFO_URL = 'http://localhost:5129/api/users/me';
const ABOUT_ME = document.getElementById('about_me');

function aboutMe() {
    fetch(ME_INFO_URL, {
        method: 'GET',
        redirect: 'manual'
    })
        .then(
            response => {
                console.log(response.status);
                if (response.ok) {
                    response.json()
                        .then(json => {
                            if (!json) {
                                ABOUT_ME.innerText = "Not Found";
                            } else {
                                ABOUT_ME.innerText = `
                                Имя: ${json['firstName']}
                                Фамилия: ${json['lastName']}
                                Описание: ${json['description']}
                                Телега: ${json['telegramId']}
                                `;
                                console.log(json);
                            }
                        });
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

aboutMe();
