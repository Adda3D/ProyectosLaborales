var isUpdateDecVie_PlanAccionLineaPolitica = false;
var DataTableDecVie_PlanAccionLineaPolitica = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionLineaPolitica();
});

function LoadDataTableDecVie_PlanAccionLineaPolitica() {
    DataTableDecVie_PlanAccionLineaPolitica = $('#tblDecVie_PlanAccionLineaPolitica').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionLineaPolitica/GetDataTableDecVie_PlanAccionLineaPolitica"
        },      
        "columns": [
            { "data": "lineapolitica", "orderable": true },
            { "data": "descripcionlineapolitica", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionLineaPolitica(' + row.id_lineapolitica + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionLineaPolitica" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionLineaPolitica(' + row.id_lineapolitica + ',`' + row.lineapolitica + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionLineaPolitica() {
    DataTableDecVie_PlanAccionLineaPolitica.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionLineaPolitica(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionLineaPolitica) {                                          
                    ExisteDecVie_PlanAccionLineaPolitica()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionLineaPolitica(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionLineaPolitica(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_PlanAccionLineaPolitica() {    
    let lineapolitica = $("#txtCdDecViePlanAccionLineaPolitica").val();   
    let urlValidar = urlController + "DecVie_PlanAccionLineaPolitica/GetDecVie_PlanAccionLineaPoliticaNombre?cd_lineapolitica=" + lineapolitica;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + lineapolitica + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionLineaPolitica(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionLineaPolitica/UpdateDecVie_PlanAccionLineaPolitica";
    objData.id_depend = $("#spanIdDependenciaPlanAccionLineaPolitica")[0].innerText;
    objData.id_lineapolitica = ($("#spanIdDecVie_PlanAccionLineaPolitica")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionLineaPolitica")[0].innerText;
    objData.lineapolitica = $("#txtCdDecViePlanAccionLineaPolitica").val();
    objData.descripcionlineapolitica = $("#txtDecVie_PlanAccionLineaPolitica").val();

    if (objData.id_lineapolitica == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionLineaPolitica/InsertDecVie_PlanAccionLineaPolitica";        
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

            RefreshDataTableDecVie_PlanAccionLineaPolitica();
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

function CrearDecVie_PlanAccionLineaPolitica() {
    $( "#txtCdDecViePlanAccionLineaPolitica" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionLineaPolitica")[0].innerText = '';
    $("#txtCdDecViePlanAccionLineaPolitica").val('');
    $("#txtDecVie_PlanAccionLineaPolitica").val('');
    isUpdateDecVie_PlanAccionLineaPolitica = false;
    $("#spanIdDependenciaPlanAccionLineaPolitica")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionLineaPolitica');
}

function EditarDecVie_PlanAccionLineaPolitica(idlineapolitica) {   
    removeValidationFormByForm('formDecVie_PlanAccionLineaPolitica'); 
    let urlEditar = urlController + "DecVie_PlanAccionLineaPolitica/GetDecVie_PlanAccionLineaPoliticaDetails?id_lineapolitica=" + idlineapolitica;
    isUpdateDecVie_PlanAccionLineaPolitica = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionLineaPolitica")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionLineaPolitica")[0].innerText = datos.id_lineapolitica;
            $("#txtCdDecViePlanAccionLineaPolitica").val(datos.lineapolitica);
            $("#txtDecVie_PlanAccionLineaPolitica").val(datos.descripcionlineapolitica);
            $( "#txtCdDecViePlanAccionLineaPolitica" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionLineaPolitica = true;
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

function ValidarEliminarDecVie_PlanAccionLineaPolitica(idlineapolitica, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionLineaPolitica(idlineapolitica);
            }
        });

}

function EliminarDecVie_PlanAccionLineaPolitica(idlineapolitica) {
    let urlEliminar = urlController + "DecVie_PlanAccionLineaPolitica/DeleteDecVie_PlanAccionLineaPolitica?id_lineapolitica=" + idlineapolitica;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionLineaPolitica();
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
