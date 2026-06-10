var isUpdateDependencia = false;
var DataTableDependencia = null;

$(document).ready(function () {
    LoadDataTableDependencia();
     
});


function LoadDataTableDependencia() {
    DataTableDependencia = $('#tblDependencia').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Dependencia/GetDataTableDependencia"
        },      
        "columns": [            
            { "data": "coddepend", "orderable": true },
            { "data": "nmdepend", "orderable": true },
            { "data": "nombrearea", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDependencia(' + row.id_depend + ')" data-bs-toggle="modal" data-bs-target="#ModalDependencia" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDependencia(' + row.id_depend + ',`' + row.nmdepend + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDataTableDependencia() {
    DataTableDependencia.ajax.reload(null, false);
}

function CrearDependencia() {
    $("#txtCodigoDependencia" ).prop( "disabled", false );
    $("#spanIdDependencia")[0].innerText = '';
    $("#txtCodigoDependencia").val('');
    $("#txtNombreDependencia").val('');

    LoadAreaAcademicaSelect('cboAreaDependencia', true);

    $('#cboAreaDependencia').select2({        
        dropdownParent: $('#ModalDependencia'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    isUpdateDependencia = false;

    removeValidationFormByForm('formDependencia');
}

function EditarDependencia(idDependencia) {       
    removeValidationFormByForm('formDependencia'); 
    let urlEditar = urlController + "Dependencia/GetDependenciaDetails?id_depend=" + idDependencia;
    isUpdateDependencia = false;
    StartLoader();

    LoadAreaAcademicaSelect('cboAreaDependencia');

    $('#cboAreaDependencia').select2({        
        dropdownParent: $('#ModalDependencia'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtCodigoDependencia" ).prop( "disabled", true );
            $("#spanIdDependencia")[0].innerText = datos.id_depend;
            $("#txtCodigoDependencia").val(datos.coddepend);
            $("#txtNombreDependencia").val(datos.nmdepend);
            $("#cboAreaDependencia").select2().val(datos.id_areaacad).trigger("change");

            $('#cboAreaDependencia').select2({dropdownParent: $('#ModalDependencia')});
        
            isUpdateDependencia = true;
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

function ValidarEliminarDependencia(idDependencia, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDependencia(idDependencia);
            }
        });

}

function EliminarDependencia(idDependencia) {
    let urlEliminar = urlController + "Dependencia/DeleteDependencia?id_depend=" + idDependencia;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableDependencia();
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

function ValidatePostUpdateDependencia(formF, botonClose) {
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
                if (!isUpdateDependencia) {                                          
                    ExisteCodigoDependencia()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDependencia(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDependencia(botonClose);
                }            
            }
        }
    }
}

function ExisteCodigoDependencia() {    
    let nroCodigoDependencia = $("#txtCodigoDependencia").val();   
    let urlValidar = urlController + "Dependencia/GetDependenciaCodigo?coddepend=" + nroCodigoDependencia;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "Código " + nroCodigoDependencia + " ya está registrado.";
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

function AddUpdateDependencia(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Dependencia/UpdateDependencia";

	objData.id_depend = ($("#spanIdDependencia")[0].innerText == '') ? undefined : $("#spanIdDependencia")[0].innerText;
	objData.id_areaacad = $("#cboAreaDependencia").val();
	objData.coddepend = $("#txtCodigoDependencia").val();
	objData.nmdepend = $("#txtNombreDependencia").val();

    if (objData.id_depend == undefined) {
        urlUpdate = urlController + "Dependencia/InsertDependencia";        
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
            debugger;
           // $('#cboAreaDependencia').select2('destroy');

            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTableDataTableDependencia();

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

function CerrarModalUpdateDependencia() {
    if ($('#cboAreaDependencia').data('select2')) {
        $('#cboAreaDependencia').select2('destroy');        
      }    
    
}


