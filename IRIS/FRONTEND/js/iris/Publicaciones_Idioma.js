var isUpdatePublicaciones_Idioma = false;
var DataTablePublicaciones_Idioma = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_Idioma();
});

function LoadDataTablePublicaciones_Idioma() {
    DataTablePublicaciones_Idioma = $('#tblPublicaciones_Idioma').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_Idioma/GetDataTablePublicaciones_Idioma"
        },      
        "columns": [
            { "data": "nmidioma", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_Idioma(' + row.id_idioma + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_Idioma" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_Idioma(' + row.id_idioma + ',`' + row.nmidioma + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_Idioma() {
    DataTablePublicaciones_Idioma.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_Idioma(formF, botonClose) {
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
                if (!isUpdatePublicaciones_Idioma) {                                          
                    ExistePublicaciones_Idioma()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_Idioma(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_Idioma(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_Idioma() {    
    let nmidioma = $("#txtCdPublicacionesIdioma").val();   
    let urlValidar = urlController + "Publicaciones_Idioma/GetPublicaciones_IdiomaNombre?cd_nmidioma=" + nmidioma;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmidioma + " ya está registrado.";
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

function AddUpdatePublicaciones_Idioma(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_Idioma/UpdatePublicaciones_Idioma";

    objData.id_idioma = ($("#spanIdPublicaciones_Idioma")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_Idioma")[0].innerText;
    objData.nmidioma = $("#txtCdPublicacionesIdioma").val();
    objData.observaciones = $("#txtPublicaciones_Idioma").val();

    if (objData.id_idioma == undefined) {
        urlUpdate = urlController + "Publicaciones_Idioma/InsertPublicaciones_Idioma";        
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

            RefreshDataTablePublicaciones_Idioma();
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

function CrearPublicaciones_Idioma() {
    $( "#txtCdPublicacionesIdioma" ).prop( "disabled", false );
    $("#spanIdPublicaciones_Idioma")[0].innerText = '';
    $("#txtCdPublicacionesIdioma").val('');
    $("#txtPublicaciones_Idioma").val('');
    isUpdatePublicaciones_Idioma = false;

    removeValidationFormByForm('formPublicaciones_Idioma');
}

function EditarPublicaciones_Idioma(ididioma) {   
    removeValidationFormByForm('formPublicaciones_Idioma'); 
    let urlEditar = urlController + "Publicaciones_Idioma/GetPublicaciones_IdiomaDetails?id_idioma=" + ididioma;
    isUpdatePublicaciones_Idioma = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_Idioma")[0].innerText = datos.id_idioma;
            $("#txtCdPublicacionesIdioma").val(datos.nmidioma);
            $("#txtPublicaciones_Idioma").val(datos.observaciones);
            $( "#txtCdPublicacionesIdioma" ).prop( "disabled", false );            
            isUpdatePublicaciones_Idioma = true;
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

function ValidarEliminarPublicaciones_Idioma(ididioma, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_Idioma(ididioma);
            }
        });

}

function EliminarPublicaciones_Idioma(ididioma) {
    let urlEliminar = urlController + "Publicaciones_Idioma/DeletePublicaciones_Idioma?id_idioma=" + ididioma;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_Idioma();
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
