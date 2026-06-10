function ocultar_boton_funcionarios() {
    var x = document.getElementById("slide-out-right");
    var y = document.getElementById("messages");
    
    if (x.style.display == "none") {
        x.style.display = "block";
        y.style.display = "block";
    } else {
        x.style.display = "none";
        y.style.display = "none";
    }
}

function ocultar_ultimos_informes() {
  var x = document.getElementById("messages");
  var y = document.getElementById("activity");
  x.style.display = "none";
  y.style.display = "block";
}

function mostrar_boton_funcionarios() {
  var x = document.getElementById("messages");
  var y = document.getElementById("activity");
  x.style.display = "block";
  y.style.display = "none";
}

function mostrar_informacion_funcionario() {
  var x = document.getElementsByClassName("card-reveal")[0];
  var y = document.getElementsByClassName("card-content")[0];
  var z = document.getElementsByClassName("card-image waves-effect waves-block waves-light")[0];
  x.style.display = "block";
  y.style.display = "none";
  z.style.display = "none";
}

function ocultar_informacion_funcionario() {
  var x = document.getElementsByClassName("card-reveal")[0];
  var y = document.getElementsByClassName("card-content")[0];
  var z = document.getElementsByClassName("card-image waves-effect waves-block waves-light")[0];
  x.style.display = "none";
  y.style.display = "block";
  z.style.display = "block";
}

function toggleFullscreen(elem) {
    elem = elem || document.documentElement;
    if (!document.fullscreenElement && !document.mozFullScreenElement &&
      !document.webkitFullscreenElement && !document.msFullscreenElement) {
      if (elem.requestFullscreen) {
        elem.requestFullscreen();
      } else if (elem.msRequestFullscreen) {
        elem.msRequestFullscreen();
      } else if (elem.mozRequestFullScreen) {
        elem.mozRequestFullScreen();
      } else if (elem.webkitRequestFullscreen) {
        elem.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
      }
    } else {
      if (document.exitFullscreen) {
        document.exitFullscreen();
      } else if (document.msExitFullscreen) {
        document.msExitFullscreen();
      } else if (document.mozCancelFullScreen) {
        document.mozCancelFullScreen();
      } else if (document.webkitExitFullscreen) {
        document.webkitExitFullscreen();
      }
    }
  }
  
  document.getElementById('btnFullscreen').addEventListener('click', function() {
    toggleFullscreen();
  });