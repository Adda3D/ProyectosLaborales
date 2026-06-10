var isUpdatePublicaciones_ImpresionPapel = false;
var DataTablePublicaciones_ImpresionPapel = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_ImpresionPapel();
});

function LoadDataTablePublicaciones_ImpresionPapel() {
    DataTablePublicaciones_ImpresionPapel = $('#tblPublicaciones_ImpresionPapel').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_ImpresionPapel/GetDataTablePublicaciones_ImpresionPapel"
        },      
        "columns": [
            { "data": "nmpapel", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_ImpresionPapel(' + row.id_papel + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_ImpresionPapel" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_ImpresionPapel(' + row.id_papel + ',`' + row.nmpapel + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_ImpresionPapel() {
    DataTablePublicaciones_ImpresionPapel.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_ImpresionPapel(formF, botonClose) {
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
                if (!isUpdatePublicaciones_ImpresionPapel) {                                          
                    ExistePublicaciones_ImpresionPapel()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_ImpresionPapel(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_ImpresionPapel(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_ImpresionPapel() {    
    let nmpapel = $("#txtCdPublicacionesImpresionPapel").val();   
    let urlValidar = urlController + "Publicaciones_ImpresionPapel/GetPublicaciones_ImpresionPapelNombre?cd_nmpapel=" + nmpapel;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmpapel + " ya está registrado.";
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

function AddUpdatePublicaciones_ImpresionPapel(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_ImpresionPapel/UpdatePublicaciones_ImpresionPapel";

    objData.id_papel = ($("#spanIdPublicaciones_ImpresionPapel")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_ImpresionPapel")[0].innerText;
    objData.nmpapel = $("#txtCdPublicacionesImpresionPapel").val();
    objData.observaciones = $("#txtPublicaciones_ImpresionPapel").val();

    if (objData.id_papel == undefined) {
        urlUpdate = urlController + "Publicaciones_ImpresionPapel/InsertPublicaciones_ImpresionPapel";        
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

            RefreshDataTablePublicaciones_ImpresionPapel();
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

function CrearPublicaciones_ImpresionPapel() {
    $( "#txtCdPublicacionesImpresionPapel" ).prop( "disabled", false );
    $("#spanIdPublicaciones_ImpresionPapel")[0].innerText = '';
    $("#txtCdPublicacionesImpresionPapel").val('');
    $("#txtPublicaciones_ImpresionPapel").val('');
    isUpdatePublicaciones_ImpresionPapel = false;

    removeValidationFormByForm('formPublicaciones_ImpresionPapel');
}

function EditarPublicaciones_ImpresionPapel(idpapel) {   
    removeValidationFormByForm('formPublicaciones_ImpresionPapel'); 
    let urlEditar = urlController + "Publicaciones_ImpresionPapel/GetPublicaciones_ImpresionPapelDetails?id_papel=" + idpapel;
    isUpdatePublicaciones_ImpresionPapel = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_ImpresionPapel")[0].innerText = datos.id_papel;
            $("#txtCdPublicacionesImpresionPapel").val(datos.nmpapel);
            $("#txtPublicaciones_ImpresionPapel").val(datos.observaciones);
            $( "#txtCdPublicacionesImpresionPapel" ).prop( "disabled", false );            
            isUpdatePublicaciones_ImpresionPapel = true;
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

function ValidarEliminarPublicaciones_ImpresionPapel(idpapel, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_ImpresionPapel(idpapel);
            }
        });

}

function EliminarPublicaciones_ImpresionPapel(idpapel) {
    let urlEliminar = urlController + "Publicaciones_ImpresionPapel/DeletePublicaciones_ImpresionPapel?id_papel=" + idpapel;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_ImpresionPapel();
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
