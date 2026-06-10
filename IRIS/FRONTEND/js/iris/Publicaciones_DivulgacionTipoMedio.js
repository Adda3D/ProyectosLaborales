var isUpdatePublicaciones_DivulgacionTipoMedio = false;
var DataTablePublicaciones_DivulgacionTipoMedio = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_DivulgacionTipoMedio();
});

function LoadDataTablePublicaciones_DivulgacionTipoMedio() {
    DataTablePublicaciones_DivulgacionTipoMedio = $('#tblPublicaciones_DivulgacionTipoMedio').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DivulgacionTipoMedio/GetDataTablePublicaciones_DivulgacionTipoMedio"
        },      
        "columns": [
            { "data": "nmtipomedio", "orderable": true },
          //{ "data": "descripcion", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_DivulgacionTipoMedio(' + row.id_tipomedio + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionTipoMedio" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_DivulgacionTipoMedio(' + row.id_tipomedio + ',`' + row.nmtipomedio + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_DivulgacionTipoMedio() {
    DataTablePublicaciones_DivulgacionTipoMedio.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_DivulgacionTipoMedio(formF, botonClose) {
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
                if (!isUpdatePublicaciones_DivulgacionTipoMedio) {                                          
                    ExistePublicaciones_DivulgacionTipoMedio()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_DivulgacionTipoMedio(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_DivulgacionTipoMedio(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_DivulgacionTipoMedio() {    
    let nmtipomedio = $("#txtTipoPublicaciones_DivulgacionTipoMedio").val();   
    let urlValidar = urlController + "Publicaciones_DivulgacionTipoMedio/GetPublicaciones_DivulgacionTipoMedioNombre?cd_nmtipomedio=" + nmtipomedio;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipomedio + " ya está registrado.";
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

function AddUpdatePublicaciones_DivulgacionTipoMedio(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_DivulgacionTipoMedio/UpdatePublicaciones_DivulgacionTipoMedio";

    objData.id_tipomedio = ($("#spanIdPublicaciones_DivulgacionTipoMedio")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_DivulgacionTipoMedio")[0].innerText;
    objData.nmtipomedio = $("#txtTipoPublicaciones_DivulgacionTipoMedio").val();
//  objData.descripcion = $("#txtDescripcionPublicaciones_DivulgacionTipoMedio").val();

    if (objData.id_tipomedio == undefined) {
        urlUpdate = urlController + "Publicaciones_DivulgacionTipoMedio/InsertPublicaciones_DivulgacionTipoMedio";        
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

            RefreshDataTablePublicaciones_DivulgacionTipoMedio();
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

function CrearPublicaciones_DivulgacionTipoMedio() {
 //   $( "#txtTipoPublicaciones_DivulgacionTipoMedio" ).prop( "disabled", false );
    $("#spanIdPublicaciones_DivulgacionTipoMedio")[0].innerText = '';
    $("#txtTipoPublicaciones_DivulgacionTipoMedio").val('');
//  $("#txtDescripcionPublicaciones_DivulgacionTipoMedio").val('');
    isUpdatePublicaciones_DivulgacionTipoMedio = false;

    removeValidationFormByForm('formPublicaciones_DivulgacionTipoMedio');
}

function EditarPublicaciones_DivulgacionTipoMedio(idtipomedio) {   
    removeValidationFormByForm('formPublicaciones_DivulgacionTipoMedio'); 
    let urlEditar = urlController + "Publicaciones_DivulgacionTipoMedio/GetPublicaciones_DivulgacionTipoMedioDetails?id_tipomedio=" + idtipomedio;
    isUpdatePublicaciones_DivulgacionTipoMedio = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_DivulgacionTipoMedio")[0].innerText = datos.id_tipomedio;
            $("#txtTipoPublicaciones_DivulgacionTipoMedio").val(datos.nmtipomedio);
    //      $("#txtDescripcionPublicaciones_DivulgacionTipoMedio").val(datos.descripcion);
  //        $( "#txtTipoPublicaciones_DivulgacionTipoMedio" ).prop( "disabled", false );            
            isUpdatePublicaciones_DivulgacionTipoMedio = true;
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

function ValidarEliminarPublicaciones_DivulgacionTipoMedio(idtipomedio, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionTipoMedio(idtipomedio);
            }
        });

}

function EliminarPublicaciones_DivulgacionTipoMedio(idtipomedio) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionTipoMedio/DeletePublicaciones_DivulgacionTipoMedio?id_tipomedio=" + idtipomedio;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_DivulgacionTipoMedio();
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
