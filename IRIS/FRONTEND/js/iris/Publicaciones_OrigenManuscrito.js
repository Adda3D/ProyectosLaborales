var isUpdatePublicaciones_OrigenManuscrito = false;
var DataTablePublicaciones_OrigenManuscrito = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_OrigenManuscrito();
});

function LoadDataTablePublicaciones_OrigenManuscrito() {
    DataTablePublicaciones_OrigenManuscrito = $('#tblPublicaciones_OrigenManuscrito').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_OrigenManuscrito/GetDataTablePublicaciones_OrigenManuscrito"
        },      
        "columns": [
            { "data": "nmorigenmanuscrito", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_OrigenManuscrito(' + row.id_origenmanuscrito + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_OrigenManuscrito" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_OrigenManuscrito(' + row.id_origenmanuscrito + ',`' + row.nmorigenmanuscrito + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_OrigenManuscrito() {
    DataTablePublicaciones_OrigenManuscrito.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_OrigenManuscrito(formF, botonClose) {
    debugger;
    validateTextXSSLastButtonByForm(formF);

    var formV = $("#" + formF);
    if (formV[0].checkValidity() == false) {
        $(formV).addClass('was-validated');
    } else {
        if (checkValidityXSS == false) {
            $(formV).addClass('was-validated');
        } else {
            if (checkValiditySelect == false) {
                $(formV).addClass('was-validated');
            } else {
                if (!isUpdatePublicaciones_OrigenManuscrito) {                                          
                    ExistePublicaciones_OrigenManuscrito()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_OrigenManuscrito(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_OrigenManuscrito(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_OrigenManuscrito() {    
    let nmorigenmanuscrito = $("#txtCdPublicacionesOrigenManuscrito").val();   
    let urlValidar = urlController + "Publicaciones_OrigenManuscrito/GetPublicaciones_OrigenManuscritoNombre?cd_nmorigenmanuscrito=" + nmorigenmanuscrito;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmorigenmanuscrito + " ya está registrado.";
                ShowModalDialog(message, false, 'warning', '', 0);
                return true;
            }
            else {
                return false;
            }            
          })
          .then( resultado => {
            return resolve(resultado);
          }) 
          .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      });
}

function AddUpdatePublicaciones_OrigenManuscrito(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_OrigenManuscrito/UpdatePublicaciones_OrigenManuscrito";

    objData.id_origenmanuscrito = ($("#spanIdPublicaciones_OrigenManuscrito")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_OrigenManuscrito")[0].innerText;
    objData.nmorigenmanuscrito = $("#txtCdPublicacionesOrigenManuscrito").val();
    objData.observaciones = $("#txtPublicaciones_OrigenManuscrito").val();

    if (objData.id_origenmanuscrito == undefined) {
        urlUpdate = urlController + "Publicaciones_OrigenManuscrito/InsertPublicaciones_OrigenManuscrito";        
    }

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTablePublicaciones_OrigenManuscrito();
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );          
}

function CrearPublicaciones_OrigenManuscrito() {
    $( "#txtCdPublicacionesOrigenManuscrito" ).prop( "disabled", false );
    $("#spanIdPublicaciones_OrigenManuscrito")[0].innerText = '';
    $("#txtCdPublicacionesOrigenManuscrito").val('');
    $("#txtPublicaciones_OrigenManuscrito").val('');
    isUpdatePublicaciones_OrigenManuscrito = false;

    removeValidationFormByForm('formPublicaciones_OrigenManuscrito');
}

function EditarPublicaciones_OrigenManuscrito(idorigenmanuscrito) {   
    removeValidationFormByForm('formPublicaciones_OrigenManuscrito'); 
    let urlEditar = urlController + "Publicaciones_OrigenManuscrito/GetPublicaciones_OrigenManuscritoDetails?id_origenmanuscrito=" + idorigenmanuscrito;
    isUpdatePublicaciones_OrigenManuscrito = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_OrigenManuscrito")[0].innerText = datos.id_origenmanuscrito;
            $("#txtCdPublicacionesOrigenManuscrito").val(datos.nmorigenmanuscrito);
            $("#txtPublicaciones_OrigenManuscrito").val(datos.observaciones);
            $( "#txtCdPublicacionesOrigenManuscrito" ).prop( "disabled", false );            
            isUpdatePublicaciones_OrigenManuscrito = true;
            FinalizeLoader();
            return;
        }
        else {
            ShowModalDialog(data.Message, false, 'warning', '', 0);
            FinalizeLoader();
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      

}

function ValidarEliminarPublicaciones_OrigenManuscrito(idorigenmanuscrito, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_OrigenManuscrito(idorigenmanuscrito);
            }
        });

}

function EliminarPublicaciones_OrigenManuscrito(idorigenmanuscrito) {
    let urlEliminar = urlController + "Publicaciones_OrigenManuscrito/DeletePublicaciones_OrigenManuscrito?id_origenmanuscrito=" + idorigenmanuscrito;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_OrigenManuscrito();
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      
    
}
