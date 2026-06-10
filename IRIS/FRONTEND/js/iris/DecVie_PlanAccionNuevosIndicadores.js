var isUpdateDecVie_PlanAccionNuevosIndicadores = false;
var DataTableDecVie_PlanAccionNuevosIndicadores = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionNuevosIndicadores();
});

function LoadDataTableDecVie_PlanAccionNuevosIndicadores() {
    DataTableDecVie_PlanAccionNuevosIndicadores = $('#tblDecVie_PlanAccionNuevosIndicadores').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionNuevosIndicadores/GetDataTableDecVie_PlanAccionNuevosIndicadores"
        },      
        "columns": [
            { "data": "nmnuevosindicadores", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionNuevosIndicadores(' + row.id_nuevosindicadores + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionNuevosIndicadores" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionNuevosIndicadores(' + row.id_nuevosindicadores + ',`' + row.nmnuevosindicadores + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionNuevosIndicadores() {
    DataTableDecVie_PlanAccionNuevosIndicadores.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionNuevosIndicadores(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionNuevosIndicadores) {                                          
                    ExisteDecVie_PlanAccionNuevosIndicadores()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionNuevosIndicadores(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionNuevosIndicadores(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_PlanAccionNuevosIndicadores() {    
    let nmnuevosindicadores = $("#txtCdDecViePlanAccionNuevosIndicadores").val();   
    let urlValidar = urlController + "DecVie_PlanAccionNuevosIndicadores/GetDecVie_PlanAccionNuevosIndicadoresNombre?cd_nmnuevosindicadores=" + nmnuevosindicadores;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmnuevosindicadores + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionNuevosIndicadores(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionNuevosIndicadores/UpdateDecVie_PlanAccionNuevosIndicadores";
    objData.id_depend = $("#spanIdDependenciaPlanAccionNuevosIndicadores")[0].innerText;
    objData.id_nuevosindicadores = ($("#spanIdDecVie_PlanAccionNuevosIndicadores")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionNuevosIndicadores")[0].innerText;
    objData.nmnuevosindicadores = $("#txtCdDecViePlanAccionNuevosIndicadores").val();
    objData.observaciones = $("#txtDecVie_PlanAccionNuevosIndicadores").val();

    if (objData.id_nuevosindicadores == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionNuevosIndicadores/InsertDecVie_PlanAccionNuevosIndicadores";        
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

            RefreshDataTableDecVie_PlanAccionNuevosIndicadores();
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

function CrearDecVie_PlanAccionNuevosIndicadores() {
    $( "#txtCdDecViePlanAccionNuevosIndicadores" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionNuevosIndicadores")[0].innerText = '';
    $("#txtCdDecViePlanAccionNuevosIndicadores").val('');
    $("#txtDecVie_PlanAccionNuevosIndicadores").val('');
    isUpdateDecVie_PlanAccionNuevosIndicadores = false;
    $("#spanIdDependenciaPlanAccionNuevosIndicadores")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionNuevosIndicadores');
}

function EditarDecVie_PlanAccionNuevosIndicadores(idnuevosindicadores) {   
    removeValidationFormByForm('formDecVie_PlanAccionNuevosIndicadores'); 
    let urlEditar = urlController + "DecVie_PlanAccionNuevosIndicadores/GetDecVie_PlanAccionNuevosIndicadoresDetails?id_nuevosindicadores=" + idnuevosindicadores;
    isUpdateDecVie_PlanAccionNuevosIndicadores = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionNuevosIndicadores")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionNuevosIndicadores")[0].innerText = datos.id_nuevosindicadores;
            $("#txtCdDecViePlanAccionNuevosIndicadores").val(datos.nmnuevosindicadores);
            $("#txtDecVie_PlanAccionNuevosIndicadores").val(datos.observaciones);
            $( "#txtCdDecViePlanAccionNuevosIndicadores" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionNuevosIndicadores = true;
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

function ValidarEliminarDecVie_PlanAccionNuevosIndicadores(idnuevosindicadores, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionNuevosIndicadores(idnuevosindicadores);
            }
        });

}

function EliminarDecVie_PlanAccionNuevosIndicadores(idnuevosindicadores) {
    let urlEliminar = urlController + "DecVie_PlanAccionNuevosIndicadores/DeleteDecVie_PlanAccionNuevosIndicadores?id_nuevosindicadores=" + idnuevosindicadores;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionNuevosIndicadores();
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
