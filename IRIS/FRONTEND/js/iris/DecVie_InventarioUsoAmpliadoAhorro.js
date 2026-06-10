var isUpdateDecVie_InventarioUsoAmpliadoAhorro = false;
var DataTableDecVie_InventarioUsoAmpliadoAhorro = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioUsoAmpliadoAhorro();
});

function LoadDataTableDecVie_InventarioUsoAmpliadoAhorro() {
    DataTableDecVie_InventarioUsoAmpliadoAhorro = $('#tblDecVie_InventarioUsoAmpliadoAhorro').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioUsoAmpliadoAhorro/GetDataTableDecVie_InventarioUsoAmpliadoAhorro"
        },      
        "columns": [
            { "data": "nmahorro", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioUsoAmpliadoAhorro(' + row.id_ahorro + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioUsoAmpliadoAhorro" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioUsoAmpliadoAhorro(' + row.id_ahorro + ',`' + row.nmahorro + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioUsoAmpliadoAhorro() {
    DataTableDecVie_InventarioUsoAmpliadoAhorro.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioUsoAmpliadoAhorro(formF, botonClose) {
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
                if (!isUpdateDecVie_InventarioUsoAmpliadoAhorro) {                                          
                    ExisteDecVie_InventarioUsoAmpliadoAhorro()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioUsoAmpliadoAhorro(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioUsoAmpliadoAhorro(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_InventarioUsoAmpliadoAhorro() {    
    let nmahorro = $("#txtCdDecVieInventarioUsoAmpliadoAhorro").val();   
    let urlValidar = urlController + "DecVie_InventarioUsoAmpliadoAhorro/GetDecVie_InventarioUsoAmpliadoAhorroNombre?cd_nmahorro=" + nmahorro;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmahorro + " ya está registrado.";
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

function AddUpdateDecVie_InventarioUsoAmpliadoAhorro(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioUsoAmpliadoAhorro/UpdateDecVie_InventarioUsoAmpliadoAhorro";

    objData.id_ahorro = ($("#spanIdDecVie_InventarioUsoAmpliadoAhorro")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioUsoAmpliadoAhorro")[0].innerText;
    objData.nmahorro = $("#txtCdDecVieInventarioUsoAmpliadoAhorro").val();
    objData.observaciones = $("#txtDecVie_InventarioUsoAmpliadoAhorro").val();

    if (objData.id_ahorro == undefined) {
        urlUpdate = urlController + "DecVie_InventarioUsoAmpliadoAhorro/InsertDecVie_InventarioUsoAmpliadoAhorro";        
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

            RefreshDataTableDecVie_InventarioUsoAmpliadoAhorro();
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

function CrearDecVie_InventarioUsoAmpliadoAhorro() {
    $( "#txtCdDecVieInventarioUsoAmpliadoAhorro" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioUsoAmpliadoAhorro")[0].innerText = '';
    $("#txtCdDecVieInventarioUsoAmpliadoAhorro").val('');
    $("#txtDecVie_InventarioUsoAmpliadoAhorro").val('');
    isUpdateDecVie_InventarioUsoAmpliadoAhorro = false;

    removeValidationFormByForm('formDecVie_InventarioUsoAmpliadoAhorro');
}

function EditarDecVie_InventarioUsoAmpliadoAhorro(idahorro) {   
    removeValidationFormByForm('formDecVie_InventarioUsoAmpliadoAhorro'); 
    let urlEditar = urlController + "DecVie_InventarioUsoAmpliadoAhorro/GetDecVie_InventarioUsoAmpliadoAhorroDetails?id_ahorro=" + idahorro;
    isUpdateDecVie_InventarioUsoAmpliadoAhorro = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioUsoAmpliadoAhorro")[0].innerText = datos.id_ahorro;
            $("#txtCdDecVieInventarioUsoAmpliadoAhorro").val(datos.nmahorro);
            $("#txtDecVie_InventarioUsoAmpliadoAhorro").val(datos.observaciones);
            $( "#txtCdDecVieInventarioUsoAmpliadoAhorro" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioUsoAmpliadoAhorro = true;
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

function ValidarEliminarDecVie_InventarioUsoAmpliadoAhorro(idahorro, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioUsoAmpliadoAhorro(idahorro);
            }
        });

}

function EliminarDecVie_InventarioUsoAmpliadoAhorro(idahorro) {
    let urlEliminar = urlController + "DecVie_InventarioUsoAmpliadoAhorro/DeleteDecVie_InventarioUsoAmpliadoAhorro?id_ahorro=" + idahorro;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioUsoAmpliadoAhorro();
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
