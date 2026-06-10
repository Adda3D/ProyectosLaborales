$(document).ready(function () {        
    debugger;
    let usuariosession = sessionStorage.getItem('usersession');
    if (usuariosession == "") {
        location.href = "/Pages/Login.html";
    } else {
        //StartLoader();

        //var idEncode = getParameterUrlByName('id');
        //idUsuario = parseInt(atob(idEncode));        

        //GetInput();
    }
});

// Funcionalidad del boton
document.addEventListener('DOMContentLoaded', function() {
    // Muestra el pop-up apenas se carga la página
    document.getElementById('alertPopup').style.display = 'flex';
  });


document.getElementById('alertButton').onclick = function() {
    document.getElementById('alertPopup').style.display = 'flex';
 };
 
 document.getElementById('acceptButton').onclick = function() {
    document.getElementById('alertPopup').style.display = 'none';
 };
 
 document.getElementById('rejectButton').onclick = function(e) {
    e.preventDefault(); // Esto previene que el pop-up se cierre.
 };

 document.getElementById('reloadButton').addEventListener('click', function() {
    // Forzando recarga desde el servidor
    window.location.reload(true);
});



 document.getElementById('infoButton').addEventListener('click', function() {
    window.open('https://sites.google.com/unal.edu.co/iris/inicio', '_blank');
});

document.getElementById('emailButton').addEventListener('click', function() {
    window.open('https://forms.gle/mbx9wLz7zVypHdkX8', '_blank');
});


 // Funcionalidad del boton


// Valida los campos del formulario
function ValidateLogin() {

    if (document.getElementById("username").checkValidity() == false) {
        $(form).addClass('was-validated');
    } else 
    {
        if (document.getElementById("password").checkValidity() == false) {
            $(form).addClass('was-validated');
        }
        else
        {
            GetLogin();    
        }
    }
}

// Obtiene los datos para iniciar sesión
function GetLogin() {
    StartLoader();

    ValidarUsuario()
        .then(validado => {
            FinalizeLoader();
            if (validado) {
                $("#loginiris").addClass("ocultar");
                $("#dvmainiris").removeClass("imagenlogin");
                $("#menuiris").removeClass("ocultar");
                $("#mainiris").removeClass("ocultar");

                let usuario = $("#username").val();

                // Guarda el usuario para el resto del sistema (¡CORRECTO!)
                sessionStorage.setItem("usuario", usuario);

                // Puedes obtener el idfuncionario y guardarlo en una variable global si quieres
                $.get(urlController + "Funcionario/GetIdFuncionarioByUsuario?usuario=" + usuario, function (response) {
                    if (response.Ok) {
                        // Si quieres guardar el id en global para otras funciones, puedes hacerlo aquí:
                        window.FuncionarioActualID = response.Data.idfuncionario;
                        // Aquí ya NO vuelves a guardar el usuario (ya lo guardaste arriba)
                    } else {
                        console.warn("No se pudo obtener ID del funcionario:", response.Message);
                    }
                });
            }
        });
}


function ValidarUsuario() {
    let usuariologin = $("#username").val(); // + "@unal.edu.co";    
    let contrasena = $("#password").val();
    let urlValidar = urlController + "Usuario/UsuarioLogin";
    let usuariodata = $("#username").val();
    var data = {
        "Usuario": usuariologin,
        "Clave": contrasena
    };

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: { 'Authorization': 'Bearer ' + TokenIRIS, 'Content-Type': 'application/json' }
        })
        .then(response => response.json())
          .then(data => {
            //console.log("datos" + JSON.stringify(data));
            if (data.Ok) {
                BuildItemsMenu(data.Data.menuusuario);      
                TabInicio();
                TabAlertasSeguimiento();
                onclickTab("0");
                
                sessionStorage.setItem("usersession", usuariodata);
                // DEBUG login: ver qué devuelve el backend
                console.log("🔑 LOGIN - data.Data completo:", JSON.stringify(data.Data));
                console.log("🔑 idrol recibido:", data.Data.idrol, "| id_depend:", data.Data.id_depend);
                sessionStorage.setItem("idrol", data.Data.idrol);
                console.log("✅ idrol guardado en sessionStorage:", sessionStorage.getItem("idrol"));
                IdDependenciaUsuarioLogueado = data.Data.id_depend;

                return true;
            }
            else {
                let message = data.Message;
                ShowModalDialog(message, false, 'warning', '', 0);

                return false;
            }            
          })
          .then( resultado => {
            return resolve(resultado);
          }) 
          .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      });

}

function BuildItemsMenu(menu_usuario) {       
    var opcionesmenu = '';

    for (var i = 0; i < menu_usuario.length; i++) {
        var opcion = menu_usuario[i];
        var datosopcion = menu_usuario[i].opcion;
        let nombreopcion = datosopcion.nombreitem.toLowerCase();
        let migapan = nombreopcion.charAt(0).toUpperCase() + nombreopcion.slice(1);

        if (datosopcion.idmenupadre == 0) {
            opcionesmenu += '<li class="nav-item dropdown">';
            opcionesmenu += '<a class="nav-link dropdown-toggle btnbar menumoduloiris" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">' + datosopcion.nombreitem + '</a>';

            if (datosopcion.opciones){
                opcionesmenu += BuildItemsSubMenu(migapan, menu_usuario[i].submenu);
            }
    
            opcionesmenu += '</li>';
        }        
    }

    opcionesmenu += '<li class="nav-item">';
    opcionesmenu += '<a class="nav-link btnbar menumoduloiris" onclick="CerrarTabs();" href="#">CERRAR SESIÓN</a>';
    opcionesmenu += '</li>';

    $("#menu_usuario").empty();

    $("#menu_usuario").append(opcionesmenu);
    
}

function BuildItemsSubMenu(nombrepadre, submenu) {
    let rutapadre = nombrepadre + ' / ';
    var opcionessubmenu = '<ul class="dropdown-menu submenuiris">';

    for (var j = 0; j < submenu.length; j++) {
        var submenuopcion = submenu[j];
        var datossubmenu = submenu[j].opcion;
        let nombreopcion = datossubmenu.nombreitem.toLowerCase();
        let rutamigapan = '';
        let idopcion = '';

        if (!datossubmenu.opciones) {
            rutamigapan = rutapadre + nombreopcion.charAt(0).toUpperCase() + nombreopcion.slice(1);
            idopcion = 'opcmenu' + datossubmenu.idmenu;

            opcionessubmenu += '<li>';
            opcionessubmenu += '<a class="dropdown-item opcionbar" url="' + datossubmenu.url + 
                               '" id="' + idopcion + 
                               '" onclick="' + datossubmenu.onclick + '" data-jerarquia="2" data-breadcrumb="' + rutamigapan + '" ' +
                               'data-id="' + datossubmenu.idmenu + '" href="#">' + datossubmenu.nombreitem + '</a>';
            opcionessubmenu += '</li>';
        }

        //LA OPCIÓN TIENE UN SUBMENU DESCENDIENTE
        if (datossubmenu.opciones) {
            rutamigapan = rutapadre + datossubmenu.nombreitem;
            opcionessubmenu += '<li class="dropdown-submenu">';
            opcionessubmenu += '<a class="dropdown-item dropdown-toggle" href="#">' + datossubmenu.nombreitem + '</a>';

            opcionessubmenu += BuildItemsSubMenu(rutamigapan, submenuopcion.submenu);

            opcionessubmenu += '</li>';
        }
    }

    opcionessubmenu += '</ul>';

    return opcionessubmenu;

}


