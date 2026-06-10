var lstopciones = [];

$(document).ready(function () {
   
    EditarRolUsuarioAccesosForm();
  
});

function EditarRolUsuarioAccesosForm() {
    $('#txtRolUsuarioNombre').val($("#spanNombreRolUsuario")[0].innerText);
    let idrol = $("#spanIdRolUsuario")[0].innerText;
    lstopciones = [];

    let urlValidar = urlController + "Menu/GetMenuAcceso?idrol=" + idrol;
    StartLoader();
    
    fetch(urlValidar, {
        method: 'GET',        
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        //console.log("datos" + JSON.stringify(data));
        if (data.Ok) {
            BuildItemsAcceso(data.Data)
                .then(creado => {
                    if (creado){
                        FinalizeLoader();   
                        $("#dvRolesUsuarioTable").addClass("ocultar");    
                        $("#dvRolUsuarioAccesos").removeClass("ocultar");                    
                    }

                })
                .catch (err => {
                    FinalizeLoader();
                    ShowModalDialog(err, false, 'error', '', 0);
                    reject(err);
                } );    
            
                        

            return true;
        }
        else {
            let message = data.Message;
            ShowModalDialog(message, false, 'warning', '', 0);

            return false;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );    

}
  
function ValidatePostUpdateRolUsuarioAccesosForm() {
    return new Promise( (resolve, reject) => {
        console.log(lstopciones);
        let urlUpdate = urlController + 'RolMenu/UpdateAccesoRol';
        StartLoader();   

        fetch(urlUpdate, {
            method: 'POST',
            body: JSON.stringify(lstopciones),
            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {           
                FinalizeLoader();
                ShowModalDialog('Datos definición acceso guardados', false, 'success', '', 0);                    

                resolve (true);                
            }
            else {
                FinalizeLoader();
                ShowModalDialog(data.Message, false, 'error', '', 0);                    
                reject (data.Message);
            }            
          })
          .catch (err => {
            FinalizeLoader();            
            ShowModalDialog(err, false, 'error', '', 0);
            reject (err);
          } );       
  
    });    

}

function VolverTablaRolesDesdeAccesos() {
    $("#dvRolUsuarioAccesos").addClass("ocultar");    
    $("#dvRolesUsuarioTable").removeClass("ocultar");

}


function asignaracceso(element) {
    let idcontrol = element.id;    
    let chkopcion = document.getElementById(idcontrol);
    let idopcion = chkopcion.dataset.id;

    //*** ASIGNO LOS PERMISOS DEL ARBOL DE HERENCIA */
    let indice = lstopciones.findIndex((elem) => elem.idmenu == idopcion);

    if (indice > -1) {
        lstopciones[indice].acceso = document.getElementById(idcontrol).checked;;
    }
   
}
  
function BuildItemsAcceso(menu_usuario) {       
    var opcionesmenu = '';

    return new Promise( (resolve, reject) => {
        for (var i = 0; i < menu_usuario.length; i++) {            
            var datosopcion = menu_usuario[i].opcion;                  
    
            if (datosopcion.idmenupadre == 0) {
                opcionesmenu += '<li class="nav-item">';
                opcionesmenu += '<label class="nav-acceso btnbar" data-id="' + datosopcion.idmenu + '" data-idpadre="' + datosopcion.idmenupadre + '" >' + datosopcion.nombreitem + '</label>';
    
                if (datosopcion.opciones){
                    opcionesmenu += '<ul>';
                    opcionesmenu += BuildItemsSubMenuAcceso(menu_usuario[i].submenu);
                    opcionesmenu += '</ul>';
                }
        
                opcionesmenu += '</li>';
            }        
        }
    
        $("#lista_accesos").empty();
    
        $("#lista_accesos").append(opcionesmenu);

        resolve(true);
      });    

    
}

function BuildItemsSubMenuAcceso(submenu) {        
    var opcionessubmenu = '';

    for (var j = 0; j < submenu.length; j++) {
        var submenuopcion = submenu[j];
        var datossubmenu = submenu[j].opcion;        
        let idopcion = '';

        if (!datossubmenu.opciones) {                  
            idopcion = 'opcion_acceso' + datossubmenu.idmenu;
            let objopcion = new Object();
            objopcion.idrol = $("#spanIdRolUsuario")[0].innerText;
            objopcion.idmenu = datossubmenu.idmenu;
            objopcion.idmenupadre = datossubmenu.idmenupadre;

            opcionessubmenu += '<li>';
            if (datossubmenu.idrolmenu != null) {
                opcionessubmenu += '<label for="' + idopcion + '" class="acceso-item opcionbar" > <input type="checkbox" id="' + idopcion + '" data-id="' + datossubmenu.idmenu + '" data-idpadre="' + datossubmenu.idmenupadre + '" onchange="asignaracceso(this)" checked/>     ' + datossubmenu.nombreitem + '</label>';
                debugger;
                objopcion.acceso = true;
            }
            else {
                opcionessubmenu += '<label for="' + idopcion + '" class="acceso-item opcionbar" > <input type="checkbox" id="' + idopcion + '" data-id="' + datossubmenu.idmenu + '" data-idpadre="' + datossubmenu.idmenupadre + '" onchange="asignaracceso(this)"/>     ' + datossubmenu.nombreitem + '</label>';
                objopcion.acceso = false;
            }
            
            lstopciones.push(objopcion);
            
            opcionessubmenu += '</li>';
        }

        //LA OPCIÓN TIENE UN SUBMENU DESCENDIENTE
        if (datossubmenu.opciones) {            
            opcionessubmenu += '<li class="dropdown-submenu navbar-collapse">';
            opcionessubmenu += '<label class="acceso-item  submenu opcionbar dropdown-toggle" data-id="' + datossubmenu.idmenu + '" data-idpadre="' + datossubmenu.idmenupadre + '" >     ' + datossubmenu.nombreitem + '</label>';
            opcionessubmenu += '<ul class="dropdown-menu">';

            opcionessubmenu += BuildItemsSubMenuAcceso(submenuopcion.submenu);

            opcionessubmenu += '</ul>';
            opcionessubmenu += '</li>';
        }
    }

    return opcionessubmenu;

}