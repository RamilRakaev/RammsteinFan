let collapse = document.getElementsByClassName('collapsible');
console.log(collapse);
for (let i = 0; i < collapse.length; i++) {
    collapse[i].addEventListener('click', function () {
        this.classList.toggle('active');
        let content = document.getElementsByClassName('content')[i];
        if (content.style.maxHeight) {
            content.style.maxHeight = null;
            this.textContent = "Развернуть";
        }
        else {
            content.style.maxHeight = content.scrollHeight + "px";
            this.textContent = "Свернуть";
        }
    })
}