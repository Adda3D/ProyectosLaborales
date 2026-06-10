var isUpdateDecVie_PlanAccionIndicadoresEstrategicos = false;
var DataTableDecVie_PlanAccionIndicadoresEstrategicos = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionIndicadoresEstrategicos();
});

function LoadDataTableDecVie_PlanAccionIndicadoresEstrategicos() {
    DataTableDecVie_PlanAccionIndicadoresEstrategicos = $('#tblDecVie_PlanAccionIndicadoresEstrategicos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionIndicadoresEstrategicos/GetDataTableDecVie_PlanAccionIndicadoresEstrategicos"
        },      
        "columns": [
            { "data": "nmindicadoresestrategicos", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_PlanAccionIndicadoresEstrategicos(' + row.id_indicadoresestrategicos + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PlanAccionIndicadoresEstrategicos" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_PlanAccionIndicadoresEstrategicos(' + row.id_indicadoresestrategicos + ',`' + row.nmindicadoresestrategicos + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionIndicadoresEstrategicos() {
    DataTableDecVie_PlanAccionIndicadoresEstrategicos.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_PlanAccionIndicadoresEstrategicos(formF, botonClose) {
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
                if (!isUpdateDecVie_PlanAccionIndicadoresEstrategicos) {                                          
                    ExisteDecVie_PlanAccionIndicadoresEstrategicos()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_PlanAccionIndicadoresEstrategicos(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_PlanAccionIndicadoresEstrategicos(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_PlanAccionIndicadoresEstrategicos() {    
    let nmindicadoresestrategicos = $("#txtCdDecViePlanAccionIndicadoresEstrategicos").val();   
    let urlValidar = urlController + "DecVie_PlanAccionIndicadoresEstrategicos/GetDecVie_PlanAccionIndicadoresEstrategicosNombre?cd_nmindicadoresestrategicos=" + nmindicadoresestrategicos;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmindicadoresestrategicos + " ya está registrado.";
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

function AddUpdateDecVie_PlanAccionIndicadoresEstrategicos(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_PlanAccionIndicadoresEstrategicos/UpdateDecVie_PlanAccionIndicadoresEstrategicos";
    objData.id_depend = $("#spanIdDependenciaPlanAccionIndicadoresEstrategicos")[0].innerText;
    objData.id_indicadoresestrategicos = ($("#spanIdDecVie_PlanAccionIndicadoresEstrategicos")[0].innerText == '') ? undefined : $("#spanIdDecVie_PlanAccionIndicadoresEstrategicos")[0].innerText;
    objData.nmindicadoresestrategicos = $("#txtCdDecViePlanAccionIndicadoresEstrategicos").val();
    objData.observaciones = $("#txtDecVie_PlanAccionIndicadoresEstrategicos").val();

    if (objData.id_indicadoresestrategicos == undefined) {
        urlUpdate = urlController + "DecVie_PlanAccionIndicadoresEstrategicos/InsertDecVie_PlanAccionIndicadoresEstrategicos";        
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

            RefreshDataTableDecVie_PlanAccionIndicadoresEstrategicos();
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

function CrearDecVie_PlanAccionIndicadoresEstrategicos() {
    $( "#txtCdDecViePlanAccionIndicadoresEstrategicos" ).prop( "disabled", false );
    $("#spanIdDecVie_PlanAccionIndicadoresEstrategicos")[0].innerText = '';
    $("#txtCdDecViePlanAccionIndicadoresEstrategicos").val('');
    $("#txtDecVie_PlanAccionIndicadoresEstrategicos").val('');
    isUpdateDecVie_PlanAccionIndicadoresEstrategicos = false;
    $("#spanIdDependenciaPlanAccionIndicadoresEstrategicos")[0].innerText = '2';

    removeValidationFormByForm('formDecVie_PlanAccionIndicadoresEstrategicos');
}

function EditarDecVie_PlanAccionIndicadoresEstrategicos(idindicadoresestrategicos) {   
    removeValidationFormByForm('formDecVie_PlanAccionIndicadoresEstrategicos'); 
    let urlEditar = urlController + "DecVie_PlanAccionIndicadoresEstrategicos/GetDecVie_PlanAccionIndicadoresEstrategicosDetails?id_indicadoresestrategicos=" + idindicadoresestrategicos;
    isUpdateDecVie_PlanAccionIndicadoresEstrategicos = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDependenciaPlanAccionIndicadoresEstrategicos")[0].innerText = '2';
            $("#spanIdDecVie_PlanAccionIndicadoresEstrategicos")[0].innerText = datos.id_indicadoresestrategicos;
            $("#txtCdDecViePlanAccionIndicadoresEstrategicos").val(datos.nmindicadoresestrategicos);
            $("#txtDecVie_PlanAccionIndicadoresEstrategicos").val(datos.observaciones);
            $( "#txtCdDecViePlanAccionIndicadoresEstrategicos" ).prop( "disabled", false );            
            isUpdateDecVie_PlanAccionIndicadoresEstrategicos = true;
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

function ValidarEliminarDecVie_PlanAccionIndicadoresEstrategicos(idindicadoresestrategicos, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionIndicadoresEstrategicos(idindicadoresestrategicos);
            }
        });

}

function EliminarDecVie_PlanAccionIndicadoresEstrategicos(idindicadoresestrategicos) {
    let urlEliminar = urlController + "DecVie_PlanAccionIndicadoresEstrategicos/DeleteDecVie_PlanAccionIndicadoresEstrategicos?id_indicadoresestrategicos=" + idindicadoresestrategicos;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionIndicadoresEstrategicos();
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
