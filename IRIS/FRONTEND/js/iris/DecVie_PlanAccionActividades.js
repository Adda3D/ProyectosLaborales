var isUpdateDecVie_PlanAccionActividades = false;
var DataTableDecVie_PlanAccionActividades = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionActividades();
});

function LoadDataTableDecVie_PlanAccionActividades() {
    DataTableDecVie_PlanAccionActividades = $('#tblDecVie_PlanAccionActividades').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionActividades/GetDataTableDecVie_PlanAccionActividades"
        },      
        "columns": [
            { "data": "nmactividad", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionActividades(' + row.id_actividades + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionActividades" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionActividades(' + row.id_actividades + ',`' + row.nmactividad + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionActividades() {
    DataTableDecVie_PlanAccionActividades.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionActividades(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionActividades) {                                          
                    ExisteDecVie_PlanAccionActividades()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionActividades(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionActividades(botonClose);
                }                
            }
        }
    }
}

function ExisteDecVie_PlanAccionActividades() {    
    let nmactividad = $("#txtCdDecViePlanAccionActividades").val();   
    let urlValidar = urlController + "DecVie_PlanAccionActividades/GetDecVie_PlanAccionActividadesNombre?cd_nmactividad=" + nmactividad;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmactividad + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionActividades(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionActividades/UpdateDecVie_PlanAccionActividades";
    objData.id_depend = $("#spanIdDependenciaPlanAccionActividades")[0].innerText;
    objData.id_actividades = ($("#spanIdDecVie_PlanAccionActividades")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionActividades")[0].innerText;
    objData.nmactividad = $("#txtCdDecViePlanAccionActividades").val();
    objData.observaciones = $("#txtDecVie_PlanAccionActividades").val();

    if (objData.id_actividades == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionActividades/InsertDecVie_PlanAccionActividades";        
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

            RefreshDataTableDecVie_PlanAccionActividades();
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

function CrearDecVie_PlanAccionActividades() {
    $( "#txtCdDecViePlanAccionActividades" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionActividades")[0].innerText = '';
    $("#txtCdDecViePlanAccionActividades").val('');
    $("#txtDecVie_PlanAccionActividades").val('');
    isUpdateDecVie_PlanAccionActividades = false;
    $("#spanIdDependenciaPlanAccionActividades")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionActividades');
}

function EditarDecVie_PlanAccionActividades(idactividades) {   
    removeValidationFormByForm('formDecVie_PlanAccionActividades'); 
    let urlEditar = urlController + "DecVie_PlanAccionActividades/GetDecVie_PlanAccionActividadesDetails?id_actividades=" + idactividades;
    isUpdateDecVie_PlanAccionActividades = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionActividades")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionActividades")[0].innerText = datos.id_actividades;
            $("#txtCdDecViePlanAccionActividades").val(datos.nmactividad);
            $("#txtDecVie_PlanAccionActividades").val(datos.observaciones);
            $( "#txtCdDecViePlanAccionActividades" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionActividades = true;
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

function ValidarEliminarDecVie_PlanAccionActividades(idactividades, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionActividades(idactividades);
            }
        });

}

function EliminarDecVie_PlanAccionActividades(idactividades) {
    let urlEliminar = urlController + "DecVie_PlanAccionActividades/DeleteDecVie_PlanAccionActividades?id_actividades=" + idactividades;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionActividades();
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
