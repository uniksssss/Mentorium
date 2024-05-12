import {signIn} from './signIn.js'

const MENTORS_URL = 'http://localhost:5129/api/users/all_mentors';
const CREATE_CHAT_URL = 'http://localhost:5129/api/chats/new/';
const grid = document.querySelector('.mentor-grid');
const prototypeCard = document.querySelector('.mentor-card');
grid.removeChild(prototypeCard);

function createChat(userId) {
    fetch(`${CREATE_CHAT_URL}${userId}`, {
        method: 'POST'
    })
        .then(
            response => {
                if (response.ok) {
                    response.json()
                        .then(json => {
                            if (!json) {
                                throw new Error('Ошибка');
                            }
                            window.location.href = `/chat?chat_id=${json['chatId']}`;
                        });
                } else {
                    throw new Error('Ошибка');
                }
            }
        )
}

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
                                const card = prototypeCard.cloneNode(true);
                                card.addEventListener('click', function (event) {
                                    createChat(user['userId']);
                                });
                                card.querySelector('.mentor-content-name').innerText = `${user['firstName']} ${user['lastName']}`;
                                card.querySelector('.mentor-content-description').innerText = `${user['description']}`;
                                grid.appendChild(card);
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
            }
        )
}

loadMentorsInfo();
