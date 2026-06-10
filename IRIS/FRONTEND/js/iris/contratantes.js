var isUpdateContratante = false;
var DataTableContratante = null;

$(document).ready(function () {
    LoadDataTableContratante(); 
     
});


function LoadDataTableContratante() {
    DataTableContratante = $('#tblContratante').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "propuesta_entidad/GetDatataTablePropuestaEntidad"
        },      
        "columns": [            
            { "data": "razonsocial", "orderable": true },
            { "data": "numidentificacion", "orderable": true },
            { "data": "direccion", "orderable": false },
            { "data": "telefono", "orderable": false },
            { "data": "correo", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaContratante(' + row.idpropuesta_entidad + ')" data-bs-toggle="modal" data-bs-target="#ModalContratante" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarContratante(' + row.idpropuesta_entidad + ',`' + row.razonsocial + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTableContratante() {
    DataTableContratante.ajax.reload(null, false);
}

function CargarCombosContratantes() {
    LoadTipoDocumentoSelect('cboTipoDocContratante');
    LoadTipoEntidadSelect('cbotipoContratanteContratante');

}

function AddSelect2ModalContratante() {
    $('#cboTipoDocContratante').select2({        
        dropdownParent: $('#ModalContratante'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });

    $('#cbotipoContratanteContratante').select2({        
         dropdownParent: $('#ModalContratante'),
         placeholder: "Seleccione",        
         width: 'resolve'
     });

}

function DestruyeSelectContratante() {
    if ($('#cboTipoDocContratante').data('select2')) {
        $('#cboTipoDocContratante').select2('destroy');        
      }    

      if ($('#cbotipoContratanteContratante').data('select2')) {
        $('#cbotipoContratanteContratante').select2('destroy');        
      }    
}

function CrearContratante() {
    $("#txtNroIdContratante" ).prop( "disabled", false );
    $("#spanIdContratante")[0].innerText = '';
    $("#txtNroIdContratante").val('');
    $("#txtRSocialContratante").val('');
    $("#txtDireccionContratante").val('');
    $("#txtTelefonoContratante").val('');
    $("#txtEmailContratante").val('');
    
    CargarCombosContratantes();
    $('#cboTipoDocContratante').select2().val('').trigger("change");
    $('#cbotipoContratanteContratante').select2().val('').trigger("change");

    AddSelect2ModalContratante();    

    isUpdateContratante = false;

    removeValidationFormByForm('formContratante');

}

function EditarPropuestaContratante(idContratante) {   
    removeValidationFormByForm('formContratante'); 
    let urlEditar = urlController + "propuesta_entidad/GetPropuestaEntidadDetails?idpropuesta_entidad=" + idContratante;
    isUpdateContratante = false;
    StartLoader();

    CargarCombosContratantes();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtNroIdContratante" ).prop( "disabled", true );
            $("#spanIdContratante")[0].innerText = datos.idpropuesta_entidad;
            $("#txtNroIdContratante").val(datos.numidentificacion);
            $("#txtRSocialContratante").val(datos.razonsocial);
            $("#txtDireccionContratante").val(datos.direccion);
            $("#txtTelefonoContratante").val(datos.telefono);
            $("#txtEmailContratante").val(datos.correo);
            $('#cboTipoDocContratante').select2().val(datos.id_tipodocumento).trigger("change");
            $('#cbotipoContratanteContratante').select2().val(datos.id_tipoentidad).trigger("change");

            AddSelect2ModalContratante();
        
            isUpdateContratante = true;
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

function ValidarEliminarContratante(idContratante, razonsocial) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + razonsocial + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaContratante(idContratante);
            }
        });

}

function EliminarPropuestaContratante(idContratante) {
    let urlEliminar = urlController + "propuesta_entidad/DeletePropuestaEntidad?idpropuesta_entidad=" + idContratante;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableContratante();
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

function ValidatePostUpdateContratante(formF, botonClose) {
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
                if (!isUpdateContratante) {                                          
                    ExisteIdentificacionContratante()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateContratante(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateContratante(botonClose);
                }            
            }
        }
    }
}

function ExisteIdentificacionContratante() {    
    let nroidentificacionContratante = $("#txtNroIdContratante").val();   
    let urlValidar = urlController + "propuesta_entidad/GetPropuestaEntidadIdentificacion?nroidentificacion=" + nroidentificacionContratante;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "No. identificación " + nroidentificacionContratante + " ya está registrado.";
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

function AddUpdateContratante(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "propuesta_entidad/UpdatePropuestaEntidad";

	objData.idpropuesta_entidad = ($("#spanIdContratante")[0].innerText == '') ? undefined : $("#spanIdContratante")[0].innerText;
	objData.id_tipodocumento = $("#cboTipoDocContratante").val();
	objData.id_tipoentidad = $("#cbotipoContratanteContratante").val();
	objData.numidentificacion = $("#txtNroIdContratante").val();
	objData.razonsocial = $("#txtRSocialContratante").val();
	objData.direccion = $("#txtDireccionContratante").val();
	objData.telefono = $("#txtTelefonoContratante").val();
	objData.correo = $("#txtEmailContratante").val();

    if (objData.idpropuesta_entidad == undefined) {
        urlUpdate = urlController + "propuesta_entidad/InsertPropuestaEntidad";        
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
            DestruyeSelectContratante();
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTableDataTableContratante();
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

function CerrarModalUpdateContratante() {
    DestruyeSelectContratante();
}

