$(document).ready(function(){
    $('#mainAudio').MediaElementPlayer({
        alwaysShowControls:true,
        features:['playpause','volume','progress'],
        audioVolume:'horizontal',
        audioWidth:400,
        audioHeight:120
    });
});
var audio =document.getElementById("mainAudio");
    function playClick(){
        borderBlock(event)

        //найти элемент audio и изменить путь к треку
        
        audio.src="/../audio/"+event.target.getAttribute("path"); 
        document.getElementById("preview").textContent=
        event.target.parentElement.getElementsByClassName("title")[0].innerHTML
        //включить или выключить проигрывание аудио
        audio.play()

        //скрыть кнопку play и показать кнопку pause
        event.target.style.display="none";
        document.getElementsByClassName("selected")[0].getElementsByClassName("pauseBtn")[0].style.display="inline"
    
    };

    function pauseClick(){
        borderBlock(event)
        audio.pause()
        event.target.style.display="none";
        document.getElementsByClassName("selected")[0].getElementsByClassName("playBtn")[0].style.display="inline"
    }

    function borderBlock(){
        //найти и убрать обводку у элемента с классом selected, после удалить класс
        var previous=document.getElementsByClassName("selected")[0]
        var previousStyle=previous.style;
        previousStyle.border="0";
        previousStyle.padding="9px 12px 3px 18px";
        previous.getElementsByClassName("pauseBtn")[0].style.display="none"
        previous.getElementsByClassName("playBtn")[0].style.display="inline"
        var previousList=previous.classList
        previousList.add("audioBlock:hover");
        previousList.remove("selected");

        //добавить выделенному блоку класс selected
         event.target.parentElement.classList.add("selected");
                                        
        //добавить обводку блока
        var parent =event.target.parentElement.style; 
        parent.border="3px solid #B79B74";
        parent.padding="6px 9px 0 15px";
        // event.target.getElementsByClassName("pauseBtn")[0].style.display ="none"
        // alert()
    }

function enterAudio(){
    var stl =event.target.style;
    stl.border="3px solid #B79B74";
    stl.padding="6px 9px 0 15px";
}
                                   
function leaveAudio(){
    if(!event.target.classList.contains("selected")){
        var stl =event.target.style;
        stl.border="0";  
        stl.padding="9px 12px 3px 18px";
    }
}

