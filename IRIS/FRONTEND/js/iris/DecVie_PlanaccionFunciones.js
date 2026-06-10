var isUpdateDecVie_PlanaccionFunciones = false;
var DataTableDecVie_PlanaccionFunciones = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanaccionFunciones();
});

function LoadDataTableDecVie_PlanaccionFunciones() {
    DataTableDecVie_PlanaccionFunciones = $('#tblDecVie_PlanaccionFunciones').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanaccionFunciones/GetDataTableDecVie_PlanaccionFunciones"
        },      
        "columns": [
            { "data": "nmfuncion", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanaccionFunciones(' + row.id_funciones + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanaccionFunciones" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanaccionFunciones(' + row.id_funciones + ',`' + row.nmfuncion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanaccionFunciones() {
    DataTableDecVie_PlanaccionFunciones.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanaccionFunciones(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanaccionFunciones) {                                          
                    ExisteDecVie_PlanaccionFunciones()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanaccionFunciones(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanaccionFunciones(botonClose);
                }              
            }
        }
    }
}

function ExisteDecVie_PlanaccionFunciones() {    
    let nmfuncion = $("#txtCdDecViePlanaccionFunciones").val();   
    let urlValidar = urlController + "DecVie_PlanaccionFunciones/GetDecVie_PlanaccionFuncionesNombre?cd_nmfuncion=" + nmfuncion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmfuncion + " ya está registrado.";
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

function AddUpdateDecVie_PlanaccionFunciones(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanaccionFunciones/UpdateDecVie_PlanaccionFunciones";
    objData.id_depend = $("#spanIdDependenciaPlanaccionFunciones")[0].innerText;
    objData.id_funciones = ($("#spanIdDecVie_PlanaccionFunciones")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanaccionFunciones")[0].innerText;
    objData.nmfuncion = $("#txtCdDecViePlanaccionFunciones").val();
    objData.observaciones = $("#txtDecVie_PlanaccionFunciones").val();

    if (objData.id_funciones == undefined) {
        urlUpdate = urlController + "DecVie_PlanaccionFunciones/InsertDecVie_PlanaccionFunciones";        
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

            RefreshDataTableDecVie_PlanaccionFunciones();
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

function CrearDecVie_PlanaccionFunciones() {
    $( "#txtCdDecViePlanaccionFunciones" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanaccionFunciones")[0].innerText = '';
    $("#txtCdDecViePlanaccionFunciones").val('');
    $("#txtDecVie_PlanaccionFunciones").val('');
    isUpdateDecVie_PlanaccionFunciones = false;
    $("#spanIdDependenciaPlanaccionFunciones")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanaccionFunciones');
}

function EditarDecVie_PlanaccionFunciones(idfunciones) {   
    removeValidationFormByForm('formDecVie_PlanaccionFunciones'); 
    let urlEditar = urlController + "DecVie_PlanaccionFunciones/GetDecVie_PlanaccionFuncionesDetails?id_funciones=" + idfunciones;
    isUpdateDecVie_PlanaccionFunciones = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanaccionFunciones")[0].innerText = '2';
            $("#spanIdDecVie_PlanaccionFunciones")[0].innerText = datos.id_funciones;
            $("#txtCdDecViePlanaccionFunciones").val(datos.nmfuncion);
            $("#txtDecVie_PlanaccionFunciones").val(datos.observaciones);
            $( "#txtCdDecViePlanaccionFunciones" ).prop( "disabled", false );            
            isUpdateDecVie_PlanaccionFunciones = true;
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

function ValidarEliminarDecVie_PlanaccionFunciones(idfunciones, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanaccionFunciones(idfunciones);
            }
        });

}

function EliminarDecVie_PlanaccionFunciones(idfunciones) {
    let urlEliminar = urlController + "DecVie_PlanaccionFunciones/DeleteDecVie_PlanaccionFunciones?id_funciones=" + idfunciones;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanaccionFunciones();
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
