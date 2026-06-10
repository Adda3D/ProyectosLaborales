var isUpdateDecVie_Macroproceso = false;
var DataTableDecVie_Macroproceso = null;

$(document).ready(function () {
    LoadDataTableDecVie_Macroproceso();
});

function LoadDataTableDecVie_Macroproceso() {
    DataTableDecVie_Macroproceso = $('#tblDecVie_Macroproceso').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_Macroproceso/GetDataTableDecVie_Macroproceso"
        },      
        "columns": [
            { "data": "nmdecviemacroproceso", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_Macroproceso(' + row.id_decviemacroproceso + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_Macroproceso" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_Macroproceso(' + row.id_decviemacroproceso + ',`' + row.nmdecviemacroproceso + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_Macroproceso() {
    DataTableDecVie_Macroproceso.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_Macroproceso(formF, botonClose) {
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
                if (!isUpdateDecVie_Macroproceso) {                                          
                    ExisteDecVie_Macroproceso()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_Macroproceso(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_Macroproceso(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_Macroproceso() {    
    let nmdecviemacroproceso = $("#txtCdDecVieMacroproceso").val();   
    let urlValidar = urlController + "DecVie_Macroproceso/GetDecVie_MacroprocesoNombre?cd_nmdecviemacroproceso=" + nmdecviemacroproceso;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmdecviemacroproceso + " ya está registrado.";
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

function AddUpdateDecVie_Macroproceso(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_Macroproceso/UpdateDecVie_Macroproceso";

    objData.id_decviemacroproceso = ($("#spanIdDecVie_Macroproceso")[0].innerText == '') ? undefined : $("#spanIdDecVie_Macroproceso")[0].innerText;
    objData.nmdecviemacroproceso = $("#txtCdDecVieMacroproceso").val();
    objData.observaciones = $("#txtDecVie_Macroproceso").val();

    if (objData.id_decviemacroproceso == undefined) {
        urlUpdate = urlController + "DecVie_Macroproceso/InsertDecVie_Macroproceso";        
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

            RefreshDataTableDecVie_Macroproceso();
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

function CrearDecVie_Macroproceso() {
    $( "#txtCdDecVieMacroproceso" ).prop( "disabled", false );
    $("#spanIdDecVie_Macroproceso")[0].innerText = '';
    $("#txtCdDecVieMacroproceso").val('');
    $("#txtDecVie_Macroproceso").val('');
    isUpdateDecVie_Macroproceso = false;

    removeValidationFormByForm('formDecVie_Macroproceso');
}

function EditarDecVie_Macroproceso(iddecviemacroproceso) {   
    removeValidationFormByForm('formDecVie_Macroproceso'); 
    let urlEditar = urlController + "DecVie_Macroproceso/GetDecVie_MacroprocesoDetails?id_decviemacroproceso=" + iddecviemacroproceso;
    isUpdateDecVie_Macroproceso = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_Macroproceso")[0].innerText = datos.id_decviemacroproceso;
            $("#txtCdDecVieMacroproceso").val(datos.nmdecviemacroproceso);
            $("#txtDecVie_Macroproceso").val(datos.observaciones);
            $( "#txtCdDecVieMacroproceso" ).prop( "disabled", false );            
            isUpdateDecVie_Macroproceso = true;
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

function ValidarEliminarDecVie_Macroproceso(iddecviemacroproceso, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_Macroproceso(iddecviemacroproceso);
            }
        });

}

function EliminarDecVie_Macroproceso(iddecviemacroproceso) {
    let urlEliminar = urlController + "DecVie_Macroproceso/DeleteDecVie_Macroproceso?id_decviemacroproceso=" + iddecviemacroproceso;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_Macroproceso();
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
