
// Get the modal
window.addEventListener('DOMContentLoaded', (event) => {
    console.log('DOM fully loaded and parsed');
var modal = document.getElementById("alertback");

let alert = document.getElementsByClassName("alert")[0];

// Get the button that opens the modal
var btn1 = document.getElementsByClassName("onlineBtn")[0];
var btn2 = document.getElementsByClassName("onlineBtn")[1];
var btn3 = document.getElementsByClassName("onlineBtn")[2];


// When the user clicks the button, open the modal 

btn1.onclick = function () {
    alert.style.display = "block";
    modal.style.display = "block";
}
btn2.onclick = function () {
    alert.style.display = "block";
    modal.style.display = "block";
}
btn3.onclick = function () {
    alert.style.display = "block";
    modal.style.display = "block";
}


// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];



// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    alert.style.display = "none";
    modal.style.display = "none";
}


// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        alert.style.display = "none";
        modal.style.display = "none";
    }
}
});
