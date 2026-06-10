var isUpdateSemestre = false;
var DataTableSemestre = null;

$(document).ready(function () {
    LoadDataTableSemestre();
});

function LoadDataTableSemestre() {
    DataTableSemestre = $('#tblSemestre').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Semestre/GetDataTableSemestre"
        },      
        "columns": [
            { "data": "nmsemestre", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarSemestre(' + row.id_semestre + ')" data-bs-toggle="modal" data-bs-target="#ModalSemestre" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarSemestre(' + row.id_semestre + ',`' + row.nmsemestre + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableSemestre() {
    DataTableSemestre.ajax.reload(null, false);    
}

function ValidatePostUpdateSemestre(formF, botonClose) {
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
                if ($("#spanIdSemestre")[0].innerText == '') {
                    ExisteSemestre()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateSemestre(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateSemestre(botonClose);
                }
            }
        }
    }
}

function ExisteSemestre() {    
    let nmsemestre = $("#txtCdSemestre").val();   
    let urlValidar = urlController + "Semestre/GetSemestreNombre?cd_nmsemestre=" + nmsemestre;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmsemestre + " ya está registrado.";
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

function AddUpdateSemestre(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Semestre/UpdateSemestre";

    objData.id_semestre = ($("#spanIdSemestre")[0].innerText == '') ? undefined : $("#spanIdSemestre")[0].innerText;
    objData.nmsemestre = $("#txtCdSemestre").val();    

    if (objData.id_semestre == undefined) {
        urlUpdate = urlController + "Semestre/InsertSemestre";        
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

            RefreshDataTableSemestre();
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

function CrearSemestre() {
    $( "#txtCdSemestre" ).prop( "disabled", false );
    $("#spanIdSemestre")[0].innerText = '';   
    $("#txtCdSemestre").val('');
    isUpdateSemestre = false;

    removeValidationFormByForm('formSemestre');
}

function EditarSemestre(idsemestre) {   
    removeValidationFormByForm('formSemestre'); 
    let urlEditar = urlController + "Semestre/GetSemestreDetails?id_semestre=" + idsemestre;
    isUpdateSemestre = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdSemestre")[0].innerText = datos.id_semestre;
            $("#txtCdSemestre").val(datos.nmsemestre);         
            isUpdateSemestre = true;
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

function ValidarEliminarSemestre(idsemestre, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarSemestre(idsemestre);
            }
        });

}

function EliminarSemestre(idsemestre) {
    let urlEliminar = urlController + "Semestre/DeleteSemestre?id_semestre=" + idsemestre;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableSemestre();
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
