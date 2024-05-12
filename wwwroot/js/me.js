
const ME_INFO_URL = 'http://localhost:5129/api/users/me';
const CHATS_URL = 'http://localhost:5129/api/chats/user/'
const ABOUT_ME = document.getElementById('about_me');

const grid = document.querySelector('.mentor-grid');
const prototypeCard = document.querySelector('.mentor-card');
grid.removeChild(prototypeCard);

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
                                ABOUT_ME.innerText = `${json['firstName']} ${json['lastName']}`;
                                getFavouriteMentors(json['userId']);
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

function getFavouriteMentors(meId) {
    fetch(`${CHATS_URL}${meId}`, {
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
                                throw new Error('Îøèáêà...');
                            }

                            for (const chat of json) {
                                for (const user of chat['users']) {
                                    if (user['userId'] != meId) {
                                        const card = prototypeCard.cloneNode(true);
                                        card.setAttribute('href', `chat?chat_id=${chat['chatId']}`);
                                        card.querySelector('.mentor-content-name').innerText = `${user['firstName']} ${user['lastName']}`;
                                        card.querySelector('.mentor-content-description').innerText = `${user['description']}`;
                                        const skillsBlock = card.querySelector('.skillsM');
                                        skillsBlock.innerText = "";
                                        for (const skill of user['skills']) {
                                            const newSkill = document.createElement("p");
                                            newSkill.className = "MentorsSkills";
                                            newSkill.textContent = skill['skillName'];
                                            skillsBlock.appendChild(newSkill);
                                        }
                                        grid.appendChild(card);
                                    }
                                }
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
