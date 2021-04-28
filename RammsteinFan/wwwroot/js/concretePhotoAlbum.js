// Get the modal
var modal = document.getElementById('myModal');

let captionText = document.getElementById("caption")
for (let img of document.getElementsByClassName('myImg')) {

    img.onclick = function () {
        modal.style.display = "block"
        document.getElementById("img01").src = img.src
        captionText.innerHTML = img.alt
    }
}
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}