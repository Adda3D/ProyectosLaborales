var isUpdateDecVie_PlanAccionObjetivoEstrategico = false;
var DataTableDecVie_PlanAccionObjetivoEstrategico = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionObjetivoEstrategico();
});

function LoadDataTableDecVie_PlanAccionObjetivoEstrategico() {
    DataTableDecVie_PlanAccionObjetivoEstrategico = $('#tblDecVie_PlanAccionObjetivoEstrategico').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionObjetivoEstrategico/GetDataTableDecVie_PlanAccionObjetivoEstrategico"
        },      
        "columns": [
            { "data": "objetivoestrategico", "orderable": true },
            { "data": "descripcionobjetivoestrategico", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionObjetivoEstrategico(' + row.id_objetivoestrategico + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionObjetivoEstrategico" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionObjetivoEstrategico(' + row.id_objetivoestrategico + ',`' + row.objetivoestrategico + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionObjetivoEstrategico() {
    DataTableDecVie_PlanAccionObjetivoEstrategico.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionObjetivoEstrategico(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionObjetivoEstrategico) {                                          
                    ExisteDecVie_PlanAccionObjetivoEstrategico()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionObjetivoEstrategico(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionObjetivoEstrategico(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_PlanAccionObjetivoEstrategico() {    
    let objetivoestrategico = $("#txtCdDecViePlanAccionObjetivoEstrategico").val();   
    let urlValidar = urlController + "DecVie_PlanAccionObjetivoEstrategico/GetDecVie_PlanAccionObjetivoEstrategicoNombre?cd_objetivoestrategico=" + objetivoestrategico;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + objetivoestrategico + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionObjetivoEstrategico(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionObjetivoEstrategico/UpdateDecVie_PlanAccionObjetivoEstrategico";
    objData.id_depend = $("#spanIdDependenciaPlanAccionObjetivoEstrategico")[0].innerText;
    objData.id_objetivoestrategico = ($("#spanIdDecVie_PlanAccionObjetivoEstrategico")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionObjetivoEstrategico")[0].innerText;
    objData.objetivoestrategico = $("#txtCdDecViePlanAccionObjetivoEstrategico").val();
    objData.descripcionobjetivoestrategico = $("#txtDecVie_PlanAccionObjetivoEstrategico").val();

    if (objData.id_objetivoestrategico == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionObjetivoEstrategico/InsertDecVie_PlanAccionObjetivoEstrategico";        
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

            RefreshDataTableDecVie_PlanAccionObjetivoEstrategico();
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

function CrearDecVie_PlanAccionObjetivoEstrategico() {
    $( "#txtCdDecViePlanAccionObjetivoEstrategico" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionObjetivoEstrategico")[0].innerText = '';
    $("#txtCdDecViePlanAccionObjetivoEstrategico").val('');
    $("#txtDecVie_PlanAccionObjetivoEstrategico").val('');
    isUpdateDecVie_PlanAccionObjetivoEstrategico = false;
    $("#spanIdDependenciaPlanAccionObjetivoEstrategico")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionObjetivoEstrategico');
}

function EditarDecVie_PlanAccionObjetivoEstrategico(idobjetivoestrategico) {   
    removeValidationFormByForm('formDecVie_PlanAccionObjetivoEstrategico'); 
    let urlEditar = urlController + "DecVie_PlanAccionObjetivoEstrategico/GetDecVie_PlanAccionObjetivoEstrategicoDetails?id_objetivoestrategico=" + idobjetivoestrategico;
    isUpdateDecVie_PlanAccionObjetivoEstrategico = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionObjetivoEstrategico")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionObjetivoEstrategico")[0].innerText = datos.id_objetivoestrategico;
            $("#txtCdDecViePlanAccionObjetivoEstrategico").val(datos.objetivoestrategico);
            $("#txtDecVie_PlanAccionObjetivoEstrategico").val(datos.descripcionobjetivoestrategico);
            $( "#txtCdDecViePlanAccionObjetivoEstrategico" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionObjetivoEstrategico = true;
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

function ValidarEliminarDecVie_PlanAccionObjetivoEstrategico(idobjetivoestrategico, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionObjetivoEstrategico(idobjetivoestrategico);
            }
        });

}

function EliminarDecVie_PlanAccionObjetivoEstrategico(idobjetivoestrategico) {
    let urlEliminar = urlController + "DecVie_PlanAccionObjetivoEstrategico/DeleteDecVie_PlanAccionObjetivoEstrategico?id_objetivoestrategico=" + idobjetivoestrategico;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionObjetivoEstrategico();
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
