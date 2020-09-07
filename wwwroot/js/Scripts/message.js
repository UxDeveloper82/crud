let submitForm = document.querySelector("#signupform");
submitForm.addEventListener("submit", submitData);

function submitData(e) {
    e.preventDefault();
    let name = document.getElementById('MyMessage_Name').value;
    let email = document.getElementById('MyMessage_Email').value;
    let message = document.getElementById('MyMessage_Message').value;

    fetch('https://localhost:44381/api/mymessages', {
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-type': 'application/json'
        },
        body: JSON.stringify({ name: name, email: email, message: message })
    })
        .then((res) => res.json())
        .then((data) => {
            submitForm.reset();
            alert("Message Send");
        })
        .catch((error) => {
            console.error('Error', error);
        })

}
