import {signIn} from "./signIn.js";

const MENTORS_LIKE_BUTTON = document.querySelector('#mentors_like');
const STUDENT_LIKE_BUTTON = document.querySelector('#student_like');
const SIGN_IN_BUTTON = document.querySelector('#sign_in');

const CHECK_URL = 'http://localhost:5129/api/check';
const ME_URL = 'http://localhost:5129/me';
const REGISTER_URL = 'http://localhost:5129/register';

SIGN_IN_BUTTON.addEventListener('click', () => {
   fetch(CHECK_URL)
       .then(response => {
          if (response.ok) {
             window.location = ME_URL;
          } else if (response.status === 401) {
             signIn(response.headers.get('location'), ME_URL);
          } else {
             throw new Error('Ошибка...');
          }
       })
       .catch(error => {
          console.log(error);
       });
});

MENTORS_LIKE_BUTTON.addEventListener('click', () => {
   window.location = `${REGISTER_URL}?${encodeURI(`is_mentor=true`)}`;
});

STUDENT_LIKE_BUTTON.addEventListener('click', () => {
   window.location = `${REGISTER_URL}?${encodeURI(`is_mentor=false`)}`;
});
