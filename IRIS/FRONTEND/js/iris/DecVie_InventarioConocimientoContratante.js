var isUpdateDecVie_InventarioConocimientoContratante = false;
var DataTableDecVie_InventarioConocimientoContratante = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioConocimientoContratante();
});

function LoadDataTableDecVie_InventarioConocimientoContratante() {
    DataTableDecVie_InventarioConocimientoContratante = $('#tblDecVie_InventarioConocimientoContratante').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioConocimientoContratante/GetDataTableDecVie_InventarioConocimientoContratante"
        },      
        "columns": [
            { "data": "nmcontratante", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioConocimientoContratante(' + row.id_conocimientocontratante + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioConocimientoContratante" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioConocimientoContratante(' + row.id_conocimientocontratante + ',`' + row.nmcontratante + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioConocimientoContratante() {
    DataTableDecVie_InventarioConocimientoContratante.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioConocimientoContratante(formF, botonClose) {
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
                if (!isUpdateDecVie_InventarioConocimientoContratante) {                                          
                    ExisteDecVie_InventarioConocimientoContratante()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioConocimientoContratante(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioConocimientoContratante(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_InventarioConocimientoContratante() {    
    let nmcontratante = $("#txtCdDecVieInventarioConocimientoContratante").val();   
    let urlValidar = urlController + "DecVie_InventarioConocimientoContratante/GetDecVie_InventarioConocimientoContratanteNombre?cd_nmcontratante=" + nmcontratante;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmcontratante + " ya está registrado.";
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

function AddUpdateDecVie_InventarioConocimientoContratante(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioConocimientoContratante/UpdateDecVie_InventarioConocimientoContratante";

    objData.id_conocimientocontratante = ($("#spanIdDecVie_InventarioConocimientoContratante")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioConocimientoContratante")[0].innerText;
    objData.nmcontratante = $("#txtCdDecVieInventarioConocimientoContratante").val();
    objData.observaciones = $("#txtDecVie_InventarioConocimientoContratante").val();

    if (objData.id_conocimientocontratante == undefined) {
        urlUpdate = urlController + "DecVie_InventarioConocimientoContratante/InsertDecVie_InventarioConocimientoContratante";        
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

            RefreshDataTableDecVie_InventarioConocimientoContratante();
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

function CrearDecVie_InventarioConocimientoContratante() {
    $( "#txtCdDecVieInventarioConocimientoContratante" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioConocimientoContratante")[0].innerText = '';
    $("#txtCdDecVieInventarioConocimientoContratante").val('');
    $("#txtDecVie_InventarioConocimientoContratante").val('');
    isUpdateDecVie_InventarioConocimientoContratante = false;

    removeValidationFormByForm('formDecVie_InventarioConocimientoContratante');
}

function EditarDecVie_InventarioConocimientoContratante(idconocimientocontratante) {   
    removeValidationFormByForm('formDecVie_InventarioConocimientoContratante'); 
    let urlEditar = urlController + "DecVie_InventarioConocimientoContratante/GetDecVie_InventarioConocimientoContratanteDetails?id_conocimientocontratante=" + idconocimientocontratante;
    isUpdateDecVie_InventarioConocimientoContratante = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioConocimientoContratante")[0].innerText = datos.id_conocimientocontratante;
            $("#txtCdDecVieInventarioConocimientoContratante").val(datos.nmcontratante);
            $("#txtDecVie_InventarioConocimientoContratante").val(datos.observaciones);
            $( "#txtCdDecVieInventarioConocimientoContratante" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioConocimientoContratante = true;
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

function ValidarEliminarDecVie_InventarioConocimientoContratante(idconocimientocontratante, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioConocimientoContratante(idconocimientocontratante);
            }
        });

}

function EliminarDecVie_InventarioConocimientoContratante(idconocimientocontratante) {
    let urlEliminar = urlController + "DecVie_InventarioConocimientoContratante/DeleteDecVie_InventarioConocimientoContratante?id_conocimientocontratante=" + idconocimientocontratante;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioConocimientoContratante();
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
