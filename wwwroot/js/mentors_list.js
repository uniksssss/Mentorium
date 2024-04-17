import {signIn} from './signIn.js'

const MENTORS_URL = 'http://localhost:5129/api/users/all_mentors';
const TABLE = document.querySelector('table');

function loadMentorsInfo() {
    fetch(MENTORS_URL, {
        method: 'GET'
    })
        .then(
            response => {
                if (response.ok) {
                    response.json()
                        .then(json => {
                            if (!json) {
                                throw new Error('Ошибка...');
                            }
                            
                            for (const user of json) {
                                const row = document.createElement('tr');
                                
                                const firstNameColumn = document.createElement('td');
                                firstNameColumn.textContent = user['firstName'];
                                row.appendChild(firstNameColumn);

                                const lastNameColumn = document.createElement('td');
                                lastNameColumn.textContent = user['lastName'];
                                row.appendChild(lastNameColumn);

                                const descriptionColumn = document.createElement('td');
                                descriptionColumn.textContent = user['description'];
                                row.appendChild(descriptionColumn);

                                const telegramColumn = document.createElement('td');
                                telegramColumn.textContent = user['telegramId'];
                                row.appendChild(telegramColumn);
                                
                                TABLE.querySelector('tbody').appendChild(row);
                            }
                        });
                } else if (response.status === 401) {
                    signIn(response.headers.get('location'), window.location);
                } else {
                    throw new Error('Ошибка...');
                }
            }
        )
        .catch(
            error => {
                TABLE.querySelector('tbody').textContent = error.innerText;
            }
        )
}

loadMentorsInfo();
