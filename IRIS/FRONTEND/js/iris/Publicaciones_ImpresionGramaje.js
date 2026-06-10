var isUpdatePublicaciones_ImpresionGramaje = false;
var DataTablePublicaciones_ImpresionGramaje = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_ImpresionGramaje();
});

function LoadDataTablePublicaciones_ImpresionGramaje() {
    DataTablePublicaciones_ImpresionGramaje = $('#tblPublicaciones_ImpresionGramaje').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_ImpresionGramaje/GetDataTablePublicaciones_ImpresionGramaje"
        },      
        "columns": [
            { "data": "nmgramaje", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_ImpresionGramaje(' + row.id_gramaje + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_ImpresionGramaje" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_ImpresionGramaje(' + row.id_gramaje + ',`' + row.nmgramaje + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_ImpresionGramaje() {
    DataTablePublicaciones_ImpresionGramaje.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_ImpresionGramaje(formF, botonClose) {
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
                if (!isUpdatePublicaciones_ImpresionGramaje) {                                          
                    ExistePublicaciones_ImpresionGramaje()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_ImpresionGramaje(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_ImpresionGramaje(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_ImpresionGramaje() {    
    let nmgramaje = $("#txtCdPublicacionesImpresionGramaje").val();   
    let urlValidar = urlController + "Publicaciones_ImpresionGramaje/GetPublicaciones_ImpresionGramajeNombre?cd_nmgramaje=" + nmgramaje;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmgramaje + " ya está registrado.";
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

function AddUpdatePublicaciones_ImpresionGramaje(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_ImpresionGramaje/UpdatePublicaciones_ImpresionGramaje";

    objData.id_gramaje = ($("#spanIdPublicaciones_ImpresionGramaje")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_ImpresionGramaje")[0].innerText;
    objData.nmgramaje = $("#txtCdPublicacionesImpresionGramaje").val();
    objData.observaciones = $("#txtPublicaciones_ImpresionGramaje").val();

    if (objData.id_gramaje == undefined) {
        urlUpdate = urlController + "Publicaciones_ImpresionGramaje/InsertPublicaciones_ImpresionGramaje";        
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

            RefreshDataTablePublicaciones_ImpresionGramaje();
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

function CrearPublicaciones_ImpresionGramaje() {
    $( "#txtCdPublicacionesImpresionGramaje" ).prop( "disabled", false );
    $("#spanIdPublicaciones_ImpresionGramaje")[0].innerText = '';
    $("#txtCdPublicacionesImpresionGramaje").val('');
    $("#txtPublicaciones_ImpresionGramaje").val('');
    isUpdatePublicaciones_ImpresionGramaje = false;

    removeValidationFormByForm('formPublicaciones_ImpresionGramaje');
}

function EditarPublicaciones_ImpresionGramaje(idgramaje) {   
    removeValidationFormByForm('formPublicaciones_ImpresionGramaje'); 
    let urlEditar = urlController + "Publicaciones_ImpresionGramaje/GetPublicaciones_ImpresionGramajeDetails?id_gramaje=" + idgramaje;
    isUpdatePublicaciones_ImpresionGramaje = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_ImpresionGramaje")[0].innerText = datos.id_gramaje;
            $("#txtCdPublicacionesImpresionGramaje").val(datos.nmgramaje);
            $("#txtPublicaciones_ImpresionGramaje").val(datos.observaciones);
            $( "#txtCdPublicacionesImpresionGramaje" ).prop( "disabled", false );            
            isUpdatePublicaciones_ImpresionGramaje = true;
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

function ValidarEliminarPublicaciones_ImpresionGramaje(idgramaje, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_ImpresionGramaje(idgramaje);
            }
        });

}

function EliminarPublicaciones_ImpresionGramaje(idgramaje) {
    let urlEliminar = urlController + "Publicaciones_ImpresionGramaje/DeletePublicaciones_ImpresionGramaje?id_gramaje=" + idgramaje;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_ImpresionGramaje();
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
