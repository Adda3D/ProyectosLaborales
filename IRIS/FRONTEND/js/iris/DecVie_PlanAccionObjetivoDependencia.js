var isUpdateDecVie_PlanAccionObjetivoDependencia = false;
var DataTableDecVie_PlanAccionObjetivoDependencia = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionObjetivoDependencia();
});

function LoadDataTableDecVie_PlanAccionObjetivoDependencia() {
    DataTableDecVie_PlanAccionObjetivoDependencia = $('#tblDecVie_PlanAccionObjetivoDependencia').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionObjetivoDependencia/GetDataTableDecVie_PlanAccionObjetivoDependencia"
        },      
        "columns": [
            { "data": "nmobjetivodependencia", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionObjetivoDependencia(' + row.id_objetivodependencia + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionObjetivoDependencia" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionObjetivoDependencia(' + row.id_objetivodependencia + ',`' + row.nmobjetivodependencia + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionObjetivoDependencia() {
    DataTableDecVie_PlanAccionObjetivoDependencia.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionObjetivoDependencia(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionObjetivoDependencia) {                                          
                    ExisteDecVie_PlanAccionObjetivoDependencia()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionObjetivoDependencia(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionObjetivoDependencia(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_PlanAccionObjetivoDependencia() {    
    let nmobjetivodependencia = $("#txtCdDecViePlanAccionObjetivoDependencia").val();   
    let urlValidar = urlController + "DecVie_PlanAccionObjetivoDependencia/GetDecVie_PlanAccionObjetivoDependenciaNombre?cd_nmobjetivodependencia=" + nmobjetivodependencia;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmobjetivodependencia + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionObjetivoDependencia(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionObjetivoDependencia/UpdateDecVie_PlanAccionObjetivoDependencia";
    objData.id_depend = $("#spanIdDependenciaPlanAccionObjetivoDependencia")[0].innerText;
    objData.id_objetivodependencia = ($("#spanIdDecVie_PlanAccionObjetivoDependencia")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionObjetivoDependencia")[0].innerText;
    objData.nmobjetivodependencia = $("#txtCdDecViePlanAccionObjetivoDependencia").val();
    objData.observaciones = $("#txtDecVie_PlanAccionObjetivoDependencia").val();

    if (objData.id_objetivodependencia == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionObjetivoDependencia/InsertDecVie_PlanAccionObjetivoDependencia";        
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

            RefreshDataTableDecVie_PlanAccionObjetivoDependencia();
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

function CrearDecVie_PlanAccionObjetivoDependencia() {
    $( "#txtCdDecViePlanAccionObjetivoDependencia" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionObjetivoDependencia")[0].innerText = '';
    $("#txtCdDecViePlanAccionObjetivoDependencia").val('');
    $("#txtDecVie_PlanAccionObjetivoDependencia").val('');
    isUpdateDecVie_PlanAccionObjetivoDependencia = false;
    $("#spanIdDependenciaPlanAccionObjetivoDependencia")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionObjetivoDependencia');
}

function EditarDecVie_PlanAccionObjetivoDependencia(idobjetivodependencia) {   
    removeValidationFormByForm('formDecVie_PlanAccionObjetivoDependencia'); 
    let urlEditar = urlController + "DecVie_PlanAccionObjetivoDependencia/GetDecVie_PlanAccionObjetivoDependenciaDetails?id_objetivodependencia=" + idobjetivodependencia;
    isUpdateDecVie_PlanAccionObjetivoDependencia = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionObjetivoDependencia")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionObjetivoDependencia")[0].innerText = datos.id_objetivodependencia;
            $("#txtCdDecViePlanAccionObjetivoDependencia").val(datos.nmobjetivodependencia);
            $("#txtDecVie_PlanAccionObjetivoDependencia").val(datos.observaciones);
            $( "#txtCdDecViePlanAccionObjetivoDependencia" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionObjetivoDependencia = true;
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

function ValidarEliminarDecVie_PlanAccionObjetivoDependencia(idobjetivodependencia, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionObjetivoDependencia(idobjetivodependencia);
            }
        });

}

function EliminarDecVie_PlanAccionObjetivoDependencia(idobjetivodependencia) {
    let urlEliminar = urlController + "DecVie_PlanAccionObjetivoDependencia/DeleteDecVie_PlanAccionObjetivoDependencia?id_objetivodependencia=" + idobjetivodependencia;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionObjetivoDependencia();
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
