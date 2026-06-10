var isUpdateDecVie_InventarioConocimientoImpacto = false;
var DataTableDecVie_InventarioConocimientoImpacto = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioConocimientoImpacto();
});

function LoadDataTableDecVie_InventarioConocimientoImpacto() {
    DataTableDecVie_InventarioConocimientoImpacto = $('#tblDecVie_InventarioConocimientoImpacto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioConocimientoImpacto/GetDataTableDecVie_InventarioConocimientoImpacto"
        },      
        "columns": [
            { "data": "nmimpacto", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioConocimientoImpacto(' + row.id_conocimientoimpacto + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioConocimientoImpacto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioConocimientoImpacto(' + row.id_conocimientoimpacto + ',`' + row.nmimpacto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioConocimientoImpacto() {
    DataTableDecVie_InventarioConocimientoImpacto.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioConocimientoImpacto(formF, botonClose) {
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
                if (!isUpdateDecVie_InventarioConocimientoImpacto) {                                          
                    ExisteDecVie_InventarioConocimientoImpacto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioConocimientoImpacto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioConocimientoImpacto(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_InventarioConocimientoImpacto() {    
    let nmimpacto = $("#txtCdDecVieInventarioConocimientoImpacto").val();   
    let urlValidar = urlController + "DecVie_InventarioConocimientoImpacto/GetDecVie_InventarioConocimientoImpactoNombre?cd_nmimpacto=" + nmimpacto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmimpacto + " ya está registrado.";
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

function AddUpdateDecVie_InventarioConocimientoImpacto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioConocimientoImpacto/UpdateDecVie_InventarioConocimientoImpacto";

    objData.id_conocimientoimpacto = ($("#spanIdDecVie_InventarioConocimientoImpacto")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioConocimientoImpacto")[0].innerText;
    objData.nmimpacto = $("#txtCdDecVieInventarioConocimientoImpacto").val();
    objData.observaciones = $("#txtDecVie_InventarioConocimientoImpacto").val();

    if (objData.id_conocimientoimpacto == undefined) {
        urlUpdate = urlController + "DecVie_InventarioConocimientoImpacto/InsertDecVie_InventarioConocimientoImpacto";        
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

            RefreshDataTableDecVie_InventarioConocimientoImpacto();
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

function CrearDecVie_InventarioConocimientoImpacto() {
    $( "#txtCdDecVieInventarioConocimientoImpacto" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioConocimientoImpacto")[0].innerText = '';
    $("#txtCdDecVieInventarioConocimientoImpacto").val('');
    $("#txtDecVie_InventarioConocimientoImpacto").val('');
    isUpdateDecVie_InventarioConocimientoImpacto = false;

    removeValidationFormByForm('formDecVie_InventarioConocimientoImpacto');
}

function EditarDecVie_InventarioConocimientoImpacto(idconocimientoimpacto) {   
    removeValidationFormByForm('formDecVie_InventarioConocimientoImpacto'); 
    let urlEditar = urlController + "DecVie_InventarioConocimientoImpacto/GetDecVie_InventarioConocimientoImpactoDetails?id_conocimientoimpacto=" + idconocimientoimpacto;
    isUpdateDecVie_InventarioConocimientoImpacto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioConocimientoImpacto")[0].innerText = datos.id_conocimientoimpacto;
            $("#txtCdDecVieInventarioConocimientoImpacto").val(datos.nmimpacto);
            $("#txtDecVie_InventarioConocimientoImpacto").val(datos.observaciones);
            $( "#txtCdDecVieInventarioConocimientoImpacto" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioConocimientoImpacto = true;
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

function ValidarEliminarDecVie_InventarioConocimientoImpacto(idconocimientoimpacto, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioConocimientoImpacto(idconocimientoimpacto);
            }
        });

}

function EliminarDecVie_InventarioConocimientoImpacto(idconocimientoimpacto) {
    let urlEliminar = urlController + "DecVie_InventarioConocimientoImpacto/DeleteDecVie_InventarioConocimientoImpacto?id_conocimientoimpacto=" + idconocimientoimpacto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioConocimientoImpacto();
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
