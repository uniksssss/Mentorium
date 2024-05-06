let sendMessage = document.querySelector('#chat_input');
let sendButton = document.querySelector('#send');
let chat = document.querySelector(".chat");
let chatContainer = chat.querySelector('.container');

const URL_PARAMS = new URLSearchParams(window.location.search);
const CHAT_ID = URL_PARAMS.get('chat_id');

const SCHEME = document.location.protocol === "https:" ? "wss" : "ws";
const PORT = document.location.port ? (":" + document.location.port) : "";
const CONNECTION_URL = `${SCHEME}://${document.location.hostname}${PORT}/ws?chatId=${CHAT_ID}`;

function updateState() {
    function disable() {
        sendMessage.disabled = true;
        sendButton.disabled = true;
    }
    function enable() {
        sendMessage.disabled = false;
        sendButton.disabled = false;
    }

    if (!socket) {
        disable();
    } else {
        switch (socket.readyState) {
            case WebSocket.CLOSED:
                disable();
                break;
            case WebSocket.CLOSING:
                disable();
                break;
            case WebSocket.CONNECTING:
                disable();
                break;
            case WebSocket.OPEN:
                enable();
                break;
            default:
                disable();
                break;
        }
    }
}

let socket = new WebSocket(CONNECTION_URL);
socket.onopen = function (event) {
    updateState();
    chat.innerHTML += '<tr>' +
        '<td colspan="3" class="commslog-data">Connection opened</td>' +
        '</tr>';
};
socket.onclose = function (event) {
    updateState();
    chat.innerHTML += '<tr>' +
        '<td colspan="3" class="commslog-data">Connection closed. Code: ' + htmlEscape(event.code) + '. Reason: ' + htmlEscape(event.reason) + '</td>' +
        '</tr>';
};
socket.onerror = updateState;
socket.onmessage = function (event) {
    let message = JSON.parse(event.data);
    console.log(message);
    
    let messages = chatContainer.querySelectorAll('.bubbleWrapper');
    let lastMessage = messages[messages.length - 1];

    let newMessage = document.createElement('div');
    newMessage.classList.add('bubbleWrapper');
    newMessage.innerHTML = `<div class="inlineContainer">
                        <img class="inlineIcon" src="./img/ava.png">
                        <div class="otherBubble other">
                            ${message.MessageText}
                        </div>
                    </div><span class="other">${message.DateTime}</span>`;
    
    lastMessage.insertAdjacentElement('afterend', newMessage);
};

sendButton.addEventListener('onclick', function () {
    if (!socket || socket.readyState !== WebSocket.OPEN) {
        alert("socket not connected");
    }
    let data = {
        "ChatId": CHAT_ID,
        "MessageId": sendMessage.value
    };
    socket.send(data);
    chat.innerHTML += '<tr>' +
        '<td class="commslog-client">Client</td>' +
        '<td class="commslog-server">Server</td>' +
        '<td class="commslog-data">' + htmlEscape(data) + '</td></tr>';
});

function htmlEscape(str) {
    return str.toString()
        .replace(/&/g, '&amp;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;');
}