const URL = 'http://localhost:5129/hello';
// const paragraph = document.getElementById('kek');

fetch(URL, {
    method: 'GET'
})
    .then(response => {
        console.log(response.status);
        response.text()
            .then(content => console.log(content))
    })
    .catch(error => {
        console.error('Произошла ошибка', error);
    });
