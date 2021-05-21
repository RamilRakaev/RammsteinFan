var commentBtn = document.getElementsByClassName('comment-collapse-btn')[0]
var commentIcon = document.getElementsByClassName('comment-white-triangle')[0]
commentBtn.onclick = function () {
	if (commentIcon.style.transform != 'rotate(180deg)') {
		commentIcon.style.transform = 'rotate(180deg)'
	}
	else {
		commentIcon.style.transform = 'rotate(0deg)'
	}
}

function showHideFormComment() {
	let form = document.getElementById(event.target.getAttribute("child-id"))
	
	if (form.classList.contains('show')) {
		form.classList.toggle('show')
		let cancel = document.getElementsByClassName('dedicated')[0]
		cancel.style.color = 'white'
		cancel.classList.toggle('dedicated')
	}
	else {
		form.classList.toggle('show');
		event.target.classList.toggle('dedicated')
		event.target.style.color = '#B79B74';
	}
	
}
for (let elem of document.getElementsByClassName('show-close-comment')) {
    elem.onclick = function () { showHideFormComment(event) };
}