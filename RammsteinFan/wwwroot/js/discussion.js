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
	//alert(event.target.getAttribute("child-id"))
	//alert(document.getElementById(event.target.getAttribute("child-id")).style)
	let form = document.getElementById(event.target.getAttribute("child-id"))
	
	if (form.style.display == 'none') {
		form.style.display = 'block'
	}
	else {
		form.style.display = 'none'
		event.bl()
	}
}
for (let elem of document.getElementsByClassName('show-form-comment')) {
    elem.onclick = function () { showHideFormComment(event) };
}