var isUpdateDecVie_PlanAccionMeta = false;
var DataTableDecVie_PlanAccionMeta = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionMeta();
});

function LoadDataTableDecVie_PlanAccionMeta() {
    DataTableDecVie_PlanAccionMeta = $('#tblDecVie_PlanAccionMeta').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionMeta/GetDataTableDecVie_PlanAccionMeta"
        },      
        "columns": [
            { "data": "nmmeta", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionMeta(' + row.id_meta + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionMeta" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionMeta(' + row.id_meta + ',`' + row.nmmeta + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionMeta() {
    DataTableDecVie_PlanAccionMeta.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionMeta(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionMeta) {                                          
                    ExisteDecVie_PlanAccionMeta()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionMeta(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionMeta(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_PlanAccionMeta() {    
    let nmmeta = $("#txtCdDecViePlanAccionMeta").val();   
    let urlValidar = urlController + "DecVie_PlanAccionMeta/GetDecVie_PlanAccionMetaNombre?cd_nmmeta=" + nmmeta;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmmeta + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionMeta(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionMeta/UpdateDecVie_PlanAccionMeta";
    
    objData.id_depend = $("#spanIdDependenciaPlanAccionMeta")[0].innerText;
    objData.id_meta = ($("#spanIdDecVie_PlanAccionMeta")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionMeta")[0].innerText;
    objData.nmmeta = $("#txtCdDecViePlanAccionMeta").val();
    objData.observaciones = $("#txtDecVie_PlanAccionMeta").val();

    if (objData.id_meta == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionMeta/InsertDecVie_PlanAccionMeta";        
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

            RefreshDataTableDecVie_PlanAccionMeta();
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

function CrearDecVie_PlanAccionMeta() {
    $( "#txtCdDecViePlanAccionMeta" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionMeta")[0].innerText = '';
    $("#txtCdDecViePlanAccionMeta").val('');
    $("#txtDecVie_PlanAccionMeta").val('');
    isUpdateDecVie_PlanAccionMeta = false;
    $("#spanIdDependenciaPlanAccionMeta")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionMeta');
}

function EditarDecVie_PlanAccionMeta(idmeta) {   
    removeValidationFormByForm('formDecVie_PlanAccionMeta'); 
    let urlEditar = urlController + "DecVie_PlanAccionMeta/GetDecVie_PlanAccionMetaDetails?id_meta=" + idmeta;
    isUpdateDecVie_PlanAccionMeta = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionMeta")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionMeta")[0].innerText = datos.id_meta;
            $("#txtCdDecViePlanAccionMeta").val(datos.nmmeta);
            $("#txtDecVie_PlanAccionMeta").val(datos.observaciones);
            $( "#txtCdDecViePlanAccionMeta" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionMeta = true;
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

function ValidarEliminarDecVie_PlanAccionMeta(idmeta, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionMeta(idmeta);
            }
        });

}

function EliminarDecVie_PlanAccionMeta(idmeta) {
    let urlEliminar = urlController + "DecVie_PlanAccionMeta/DeleteDecVie_PlanAccionMeta?id_meta=" + idmeta;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionMeta();
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
