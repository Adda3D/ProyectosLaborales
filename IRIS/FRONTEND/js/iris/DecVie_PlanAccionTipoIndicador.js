var isUpdateDecVie_PlanAccionTipoIndicador = false;
var DataTableDecVie_PlanAccionTipoIndicador = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionTipoIndicador();
});

function LoadDataTableDecVie_PlanAccionTipoIndicador() {
    DataTableDecVie_PlanAccionTipoIndicador = $('#tblDecVie_PlanAccionTipoIndicador').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionTipoIndicador/GetDataTableDecVie_PlanAccionTipoIndicador"
        },      
        "columns": [
            { "data": "nmtipoindicador", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionTipoIndicador(' + row.id_tipoindicador + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionTipoIndicador" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionTipoIndicador(' + row.id_tipoindicador + ',`' + row.nmtipoindicador + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionTipoIndicador() {
    DataTableDecVie_PlanAccionTipoIndicador.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionTipoIndicador(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionTipoIndicador) {                                          
                    ExisteDecVie_PlanAccionTipoIndicador()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionTipoIndicador(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionTipoIndicador(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_PlanAccionTipoIndicador() {    
    let nmtipoindicador = $("#txtCdDecViePlanAccionTipoIndicador").val();   
    let urlValidar = urlController + "DecVie_PlanAccionTipoIndicador/GetDecVie_PlanAccionTipoIndicadorNombre?cd_nmtipoindicador=" + nmtipoindicador;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipoindicador + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionTipoIndicador(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionTipoIndicador/UpdateDecVie_PlanAccionTipoIndicador";

    objData.id_depend = $("#spanIdDependenciaPlanAccionTipoIndicador")[0].innerText;
    objData.id_tipoindicador = ($("#spanIdDecVie_PlanAccionTipoIndicador")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionTipoIndicador")[0].innerText;
    objData.nmtipoindicador = $("#txtCdDecViePlanAccionTipoIndicador").val();
    objData.observaciones = $("#txtDecVie_PlanAccionTipoIndicador").val();

    if (objData.id_tipoindicador == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionTipoIndicador/InsertDecVie_PlanAccionTipoIndicador";        
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

            RefreshDataTableDecVie_PlanAccionTipoIndicador();
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

function CrearDecVie_PlanAccionTipoIndicador() {
    $( "#txtCdDecViePlanAccionTipoIndicador" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionTipoIndicador")[0].innerText = '';
    $("#txtCdDecViePlanAccionTipoIndicador").val('');
    $("#txtDecVie_PlanAccionTipoIndicador").val('');
    isUpdateDecVie_PlanAccionTipoIndicador = false;
    $("#spanIdDependenciaPlanAccionTipoIndicador")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionTipoIndicador');
}

function EditarDecVie_PlanAccionTipoIndicador(idtipoindicador) {   
    removeValidationFormByForm('formDecVie_PlanAccionTipoIndicador'); 
    let urlEditar = urlController + "DecVie_PlanAccionTipoIndicador/GetDecVie_PlanAccionTipoIndicadorDetails?id_tipoindicador=" + idtipoindicador;
    isUpdateDecVie_PlanAccionTipoIndicador = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionTipoIndicador")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionTipoIndicador")[0].innerText = datos.id_tipoindicador;
            $("#txtCdDecViePlanAccionTipoIndicador").val(datos.nmtipoindicador);
            $("#txtDecVie_PlanAccionTipoIndicador").val(datos.observaciones);
            $( "#txtCdDecViePlanAccionTipoIndicador" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionTipoIndicador = true;
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

function ValidarEliminarDecVie_PlanAccionTipoIndicador(idtipoindicador, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionTipoIndicador(idtipoindicador);
            }
        });

}

function EliminarDecVie_PlanAccionTipoIndicador(idtipoindicador) {
    let urlEliminar = urlController + "DecVie_PlanAccionTipoIndicador/DeleteDecVie_PlanAccionTipoIndicador?id_tipoindicador=" + idtipoindicador;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionTipoIndicador();
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
