var isUpdateDecVie_PlanAccionObjetivosPgdVriSede = false;
var DataTableDecVie_PlanAccionObjetivosPgdVriSede = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionObjetivosPgdVriSede();
});

function LoadDataTableDecVie_PlanAccionObjetivosPgdVriSede() {
    DataTableDecVie_PlanAccionObjetivosPgdVriSede = $('#tblDecVie_PlanAccionObjetivosPgdVriSede').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionObjetivosPgdVriSede/GetDataTableDecVie_PlanAccionObjetivosPgdVriSede"
        },      
        "columns": [
            { "data": "nmobjetivopgdvrisede", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionObjetivosPgdVriSede(' + row.id_objetivopgdvrisede + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionObjetivosPgdVriSede" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionObjetivosPgdVriSede(' + row.id_objetivopgdvrisede + ',`' + row.nmobjetivopgdvrisede + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionObjetivosPgdVriSede() {
    DataTableDecVie_PlanAccionObjetivosPgdVriSede.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionObjetivosPgdVriSede(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionObjetivosPgdVriSede) {                                          
                    ExisteDecVie_PlanAccionObjetivosPgdVriSede()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionObjetivosPgdVriSede(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionObjetivosPgdVriSede(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_PlanAccionObjetivosPgdVriSede() {    
    let nmobjetivopgdvrisede = $("#txtCdDecViePlanAccionObjetivosPgdVriSede").val();   
    let urlValidar = urlController + "DecVie_PlanAccionObjetivosPgdVriSede/GetDecVie_PlanAccionObjetivosPgdVriSedeNombre?cd_nmobjetivopgdvrisede=" + nmobjetivopgdvrisede;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmobjetivopgdvrisede + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionObjetivosPgdVriSede(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionObjetivosPgdVriSede/UpdateDecVie_PlanAccionObjetivosPgdVriSede";

    objData.id_depend = $("#spanIdDependenciaPlanAccionObjetivosPgdVriSede")[0].innerText;
    objData.id_objetivopgdvrisede = ($("#spanIdDecVie_PlanAccionObjetivosPgdVriSede")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionObjetivosPgdVriSede")[0].innerText;
    objData.nmobjetivopgdvrisede = $("#txtCdDecViePlanAccionObjetivosPgdVriSede").val();
    objData.observaciones = $("#txtDecVie_PlanAccionObjetivosPgdVriSede").val();

    if (objData.id_objetivopgdvrisede == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionObjetivosPgdVriSede/InsertDecVie_PlanAccionObjetivosPgdVriSede";        
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

            RefreshDataTableDecVie_PlanAccionObjetivosPgdVriSede();
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

function CrearDecVie_PlanAccionObjetivosPgdVriSede() {
    $( "#txtCdDecViePlanAccionObjetivosPgdVriSede" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionObjetivosPgdVriSede")[0].innerText = '';
    $("#txtCdDecViePlanAccionObjetivosPgdVriSede").val('');
    $("#txtDecVie_PlanAccionObjetivosPgdVriSede").val('');
    isUpdateDecVie_PlanAccionObjetivosPgdVriSede = false;
    $("#spanIdDependenciaPlanAccionObjetivosPgdVriSede")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionObjetivosPgdVriSede');
}

function EditarDecVie_PlanAccionObjetivosPgdVriSede(idobjetivopgdvrisede) {   
    removeValidationFormByForm('formDecVie_PlanAccionObjetivosPgdVriSede'); 
    let urlEditar = urlController + "DecVie_PlanAccionObjetivosPgdVriSede/GetDecVie_PlanAccionObjetivosPgdVriSedeDetails?id_objetivopgdvrisede=" + idobjetivopgdvrisede;
    isUpdateDecVie_PlanAccionObjetivosPgdVriSede = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionObjetivosPgdVriSede")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionObjetivosPgdVriSede")[0].innerText = datos.id_objetivopgdvrisede;
            $("#txtCdDecViePlanAccionObjetivosPgdVriSede").val(datos.nmobjetivopgdvrisede);
            $("#txtDecVie_PlanAccionObjetivosPgdVriSede").val(datos.observaciones);
            $( "#txtCdDecViePlanAccionObjetivosPgdVriSede" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionObjetivosPgdVriSede = true;            
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

function ValidarEliminarDecVie_PlanAccionObjetivosPgdVriSede(idobjetivopgdvrisede, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionObjetivosPgdVriSede(idobjetivopgdvrisede);
            }
        });

}

function EliminarDecVie_PlanAccionObjetivosPgdVriSede(idobjetivopgdvrisede) {
    let urlEliminar = urlController + "DecVie_PlanAccionObjetivosPgdVriSede/DeleteDecVie_PlanAccionObjetivosPgdVriSede?id_objetivopgdvrisede=" + idobjetivopgdvrisede;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionObjetivosPgdVriSede();
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
