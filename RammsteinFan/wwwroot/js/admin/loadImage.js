let radioButons = document.getElementsByName("locationRelativeImg")
for (let radio of radioButons) {
    radio.addEventListener('change', (event) => {
        let selects = document.getElementsByName("location")
        for (let select of selects) {
            select.toggleAttribute("disabled")
        }
        let labels = document.querySelectorAll('label[for="location"]')
        for (let label of labels) {
            label.classList.toggle("d-none")
        }
    });
}