var isUpdateDecVie_InventarioConocimientoSoporte = false;
var DataTableDecVie_InventarioConocimientoSoporte = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioConocimientoSoporte();
});

function LoadDataTableDecVie_InventarioConocimientoSoporte() {
    DataTableDecVie_InventarioConocimientoSoporte = $('#tblDecVie_InventarioConocimientoSoporte').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioConocimientoSoporte/GetDataTableDecVie_InventarioConocimientoSoporte"
        },      
        "columns": [
            { "data": "nmsoporte", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioConocimientoSoporte(' + row.id_conocimientosoporte + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioConocimientoSoporte" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioConocimientoSoporte(' + row.id_conocimientosoporte + ',`' + row.nmsoporte + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioConocimientoSoporte() {
    DataTableDecVie_InventarioConocimientoSoporte.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioConocimientoSoporte(formF, botonClose) {
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
                if (!isUpdateDecVie_InventarioConocimientoSoporte) {                                          
                    ExisteDecVie_InventarioConocimientoSoporte()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioConocimientoSoporte(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioConocimientoSoporte(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_InventarioConocimientoSoporte() {    
    let nmsoporte = $("#txtCdDecVieInventarioConocimientoSoporte").val();   
    let urlValidar = urlController + "DecVie_InventarioConocimientoSoporte/GetDecVie_InventarioConocimientoSoporteNombre?cd_nmsoporte=" + nmsoporte;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmsoporte + " ya está registrado.";
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

function AddUpdateDecVie_InventarioConocimientoSoporte(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioConocimientoSoporte/UpdateDecVie_InventarioConocimientoSoporte";

    objData.id_conocimientosoporte = ($("#spanIdDecVie_InventarioConocimientoSoporte")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioConocimientoSoporte")[0].innerText;
    objData.nmsoporte = $("#txtCdDecVieInventarioConocimientoSoporte").val();
    objData.observaciones = $("#txtDecVie_InventarioConocimientoSoporte").val();

    if (objData.id_conocimientosoporte == undefined) {
        urlUpdate = urlController + "DecVie_InventarioConocimientoSoporte/InsertDecVie_InventarioConocimientoSoporte";        
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

            RefreshDataTableDecVie_InventarioConocimientoSoporte();
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

function CrearDecVie_InventarioConocimientoSoporte() {
    $( "#txtCdDecVieInventarioConocimientoSoporte" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioConocimientoSoporte")[0].innerText = '';
    $("#txtCdDecVieInventarioConocimientoSoporte").val('');
    $("#txtDecVie_InventarioConocimientoSoporte").val('');
    isUpdateDecVie_InventarioConocimientoSoporte = false;

    removeValidationFormByForm('formDecVie_InventarioConocimientoSoporte');
}

function EditarDecVie_InventarioConocimientoSoporte(idconocimientosoporte) {   
    removeValidationFormByForm('formDecVie_InventarioConocimientoSoporte'); 
    let urlEditar = urlController + "DecVie_InventarioConocimientoSoporte/GetDecVie_InventarioConocimientoSoporteDetails?id_conocimientosoporte=" + idconocimientosoporte;
    isUpdateDecVie_InventarioConocimientoSoporte = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioConocimientoSoporte")[0].innerText = datos.id_conocimientosoporte;
            $("#txtCdDecVieInventarioConocimientoSoporte").val(datos.nmsoporte);
            $("#txtDecVie_InventarioConocimientoSoporte").val(datos.observaciones);
            $( "#txtCdDecVieInventarioConocimientoSoporte" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioConocimientoSoporte = true;
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

function ValidarEliminarDecVie_InventarioConocimientoSoporte(idconocimientosoporte, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioConocimientoSoporte(idconocimientosoporte);
            }
        });

}

function EliminarDecVie_InventarioConocimientoSoporte(idconocimientosoporte) {
    let urlEliminar = urlController + "DecVie_InventarioConocimientoSoporte/DeleteDecVie_InventarioConocimientoSoporte?id_conocimientosoporte=" + idconocimientosoporte;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioConocimientoSoporte();
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
