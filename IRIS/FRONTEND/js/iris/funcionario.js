var isUpdateFuncionario = false;
var DataTableFuncionario = null;

$(document).ready(function () {
    LoadDataTableFuncionario();
     
});


function LoadDataTableFuncionario() {
    DataTableFuncionario = $('#tblFuncionario').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Funcionario/GetDataTableFuncionario"
        },      
        "columns": [            
            { "data": "numidentificacion", "orderable": true },
            { "data": "nombres", "orderable": true },
            { "data": "apellidos", "orderable": true },
            { "data": "correo", "orderable": false },
            { "data": "dependencia", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarFuncionario(' + row.idfuncionario + ')" data-bs-toggle="modal" data-bs-target="#ModalFuncionario" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarFuncionario(' + row.idfuncionario + ',`' + row.nombrecompleto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTableFuncionario() {
    DataTableFuncionario.ajax.reload(null, false);
}

function CrearFuncionario() {
    $("#txtNroIdFuncionario" ).prop( "disabled", false );
    $("#spanIdFuncionario")[0].innerText = '';
    $("#txtNroIdFuncionario").val('');
    $("#txtNombreFuncionario").val('');
    $("#txtApellidoFuncionario").val('');
    $("#txtEmailFuncionario").val('');

    LoadDependenciaSelectNulo('cboDependenciaFuncionario', true);    

    $('#cboDependenciaFuncionario').select2({
        dropdownParent: $('#ModalFuncionario'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    isUpdateFuncionario = false;

    removeValidationFormByForm('formFuncionario');
}

function EditarFuncionario(idFuncionario) {   
    removeValidationFormByForm('formFuncionario'); 
    let urlEditar = urlController + "Funcionario/GetFuncionarioDetails?idfuncionario=" + idFuncionario;
    isUpdateFuncionario = false;
    StartLoader();

    LoadDependenciaSelect('cboDependenciaFuncionario');    

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            let correofuncionario = datos.correo;
            let posarroba = correofuncionario.indexOf("@");
            correofuncionario = correofuncionario.substring(0,posarroba);            

            $("#txtNroIdFuncionario" ).prop( "disabled", true );
            $("#spanIdFuncionario")[0].innerText = datos.idfuncionario;
            $("#txtNroIdFuncionario").val(datos.numidentificacion);
            $("#txtNombreFuncionario").val(datos.nombres);
            $("#txtApellidoFuncionario").val(datos.apellidos);
            $("#txtEmailFuncionario").val(correofuncionario);
            $('#cboDependenciaFuncionario').select2().val(datos.id_depend).trigger("change");

            $('#cboDependenciaFuncionario').select2({
                dropdownParent: $('#ModalFuncionario'),
                placeholder: "Seleccione",        
                width: 'resolve'
            });
        
            isUpdateFuncionario = true;
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

function ValidarEliminarFuncionario(idFuncionario, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarFuncionario(idFuncionario);
            }
        });

}

function EliminarFuncionario(idFuncionario) {
    let urlEliminar = urlController + "Funcionario/DeleteFuncionario?idfuncionario=" + idFuncionario;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableFuncionario();
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

function ValidatePostUpdateFuncionario(formF, botonClose) {
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
                if (!isUpdateFuncionario) {                                          
                    ExisteIdentificacionFuncionario()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateFuncionario(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateFuncionario(botonClose);
                }            
            }
        }
    }
}

function ExisteIdentificacionFuncionario() {    
    let nroidentificacionFuncionario = $("#txtNroIdFuncionario").val();   
    let urlValidar = urlController + "Funcionario/GetFuncionarioIdentificacion?numidentificacion=" + nroidentificacionFuncionario;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "No. identificación " + nroidentificacionFuncionario + " ya está registrado.";
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

function AddUpdateFuncionario(botonCerrar) {
    debugger;
    var objData = new Object();
    let correofuncionario = $("#txtEmailFuncionario").val() + '@unal.edu.co';
    let urlUpdate = urlController + "Funcionario/UpdateFuncionario";

	objData.idfuncionario = ($("#spanIdFuncionario")[0].innerText == '') ? undefined : $("#spanIdFuncionario")[0].innerText;
	objData.id_depend = $("#cboDependenciaFuncionario").val();
	objData.numidentificacion = $("#txtNroIdFuncionario").val();
	objData.nombres = $("#txtNombreFuncionario").val();
	objData.apellidos = $("#txtApellidoFuncionario").val();
	objData.correo = correofuncionario; //$("#txtEmailFuncionario").val();

    if (objData.idfuncionario == undefined) {
        urlUpdate = urlController + "Funcionario/InsertFuncionario";        
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

            $('#cboDependenciaFuncionario').select2('destroy');
            
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTableDataTableFuncionario();
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

function CerrarModalUpdateFuncionario() {
    if ($('#cboDependenciaFuncionario').data('select2')) {
        $('#cboDependenciaFuncionario').select2('destroy');        
      }    
    
}


