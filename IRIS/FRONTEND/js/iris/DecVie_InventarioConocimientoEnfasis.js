var isUpdateDecVie_InventarioConocimientoEnfasis = false;
var DataTableDecVie_InventarioConocimientoEnfasis = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioConocimientoEnfasis();
});

function LoadDataTableDecVie_InventarioConocimientoEnfasis() {
    DataTableDecVie_InventarioConocimientoEnfasis = $('#tblDecVie_InventarioConocimientoEnfasis').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioConocimientoEnfasis/GetDataTableDecVie_InventarioConocimientoEnfasis"
        },      
        "columns": [
            { "data": "nmenfasis", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioConocimientoEnfasis(' + row.id_conocimientoenfasis + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioConocimientoEnfasis" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioConocimientoEnfasis(' + row.id_conocimientoenfasis + ',`' + row.nmenfasis + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioConocimientoEnfasis() {
    DataTableDecVie_InventarioConocimientoEnfasis.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioConocimientoEnfasis(formF, botonClose) {
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
                if (!isUpdateDecVie_InventarioConocimientoEnfasis) {                                          
                    ExisteDecVie_InventarioConocimientoEnfasis()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioConocimientoEnfasis(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioConocimientoEnfasis(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_InventarioConocimientoEnfasis() {    
    let nmenfasis = $("#txtCdDecVieInventarioConocimientoEnfasis").val();   
    let urlValidar = urlController + "DecVie_InventarioConocimientoEnfasis/GetDecVie_InventarioConocimientoEnfasisNombre?cd_nmenfasis=" + nmenfasis;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmenfasis + " ya está registrado.";
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

function AddUpdateDecVie_InventarioConocimientoEnfasis(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioConocimientoEnfasis/UpdateDecVie_InventarioConocimientoEnfasis";

    objData.id_conocimientoenfasis = ($("#spanIdDecVie_InventarioConocimientoEnfasis")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioConocimientoEnfasis")[0].innerText;
    objData.nmenfasis = $("#txtCdDecVieInventarioConocimientoEnfasis").val();
    objData.observaciones = $("#txtDecVie_InventarioConocimientoEnfasis").val();

    if (objData.id_conocimientoenfasis == undefined) {
        urlUpdate = urlController + "DecVie_InventarioConocimientoEnfasis/InsertDecVie_InventarioConocimientoEnfasis";        
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

            RefreshDataTableDecVie_InventarioConocimientoEnfasis();
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

function CrearDecVie_InventarioConocimientoEnfasis() {
    $( "#txtCdDecVieInventarioConocimientoEnfasis" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioConocimientoEnfasis")[0].innerText = '';
    $("#txtCdDecVieInventarioConocimientoEnfasis").val('');
    $("#txtDecVie_InventarioConocimientoEnfasis").val('');
    isUpdateDecVie_InventarioConocimientoEnfasis = false;

    removeValidationFormByForm('formDecVie_InventarioConocimientoEnfasis');
}

function EditarDecVie_InventarioConocimientoEnfasis(idconocimientoenfasis) {   
    removeValidationFormByForm('formDecVie_InventarioConocimientoEnfasis'); 
    let urlEditar = urlController + "DecVie_InventarioConocimientoEnfasis/GetDecVie_InventarioConocimientoEnfasisDetails?id_conocimientoenfasis=" + idconocimientoenfasis;
    isUpdateDecVie_InventarioConocimientoEnfasis = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioConocimientoEnfasis")[0].innerText = datos.id_conocimientoenfasis;
            $("#txtCdDecVieInventarioConocimientoEnfasis").val(datos.nmenfasis);
            $("#txtDecVie_InventarioConocimientoEnfasis").val(datos.observaciones);
            $( "#txtCdDecVieInventarioConocimientoEnfasis" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioConocimientoEnfasis = true;
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

function ValidarEliminarDecVie_InventarioConocimientoEnfasis(idconocimientoenfasis, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioConocimientoEnfasis(idconocimientoenfasis);
            }
        });

}

function EliminarDecVie_InventarioConocimientoEnfasis(idconocimientoenfasis) {
    let urlEliminar = urlController + "DecVie_InventarioConocimientoEnfasis/DeleteDecVie_InventarioConocimientoEnfasis?id_conocimientoenfasis=" + idconocimientoenfasis;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioConocimientoEnfasis();
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
