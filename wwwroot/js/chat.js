let sendMessage = document.querySelector('#chat_input');
let sendButton = document.querySelector('#send');
let chat = document.querySelector(".chat");

const URL_PARAMS = new URLSearchParams(window.location.search);
const CHAT_ID = URL_PARAMS.get('chat_id');

const SCHEME = document.location.protocol === "https:" ? "wss" : "ws";
const PORT = document.location.port ? (":" + document.location.port) : "";
const CONNECTION_URL = `${SCHEME}://${document.location.hostname}${PORT}/ws?chatId=${CHAT_ID}`;

let socket = new WebSocket(CONNECTION_URL);

sendButton.addEventListener('click', function () {
    if (!socket || socket.readyState !== WebSocket.OPEN) {
        alert("socket not connected");
    }
    
    let data = {
        "ChatId": CHAT_ID,
        "MessageText": sendMessage.value
    };
    console.log(data);
    socket.send(JSON.stringify(data));
});

socket.onmessage = function (event) {
    console.log(event.data);
    let message = JSON.parse(event.data);
    console.log(message);

    let containers = document.querySelectorAll('.container');    
    let chatBox = containers[containers.length - 1].querySelector('.chat-box-footer');

    let newMessage = document.createElement('div');
    newMessage.className = "bubbleWrapper";
    
    if (message.IsOwn) {
        newMessage.innerHTML = `<div class="inlineContainer own">
                        <img class="inlineIcon" src="/img/ava.png">
                        <div class="ownBubble own">
                            ${message.MessageText}
                        </div>
                    </div><span class="own">${message.DateTime}</span>`;
    } else {
        newMessage.innerHTML = `<div class="inlineContainer">
                        <img class="inlineIcon" src="/img/ava.png">
                        <div class="otherBubble other">
                            ${message.MessageText}
                        </div>
                    </div><span class="other">${message.DateTime}</span>`;
    }
    
    chatBox.before(newMessage);
};

function htmlEscape(str) {
    return str.toString()
        .replace(/&/g, '&amp;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;');
}