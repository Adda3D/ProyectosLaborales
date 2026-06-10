var isUpdatePropuestaExtension = false;
var DataTablePropuestaExtension = null;
var DataTablePropuestaSeguimiento = null;
var DataTablePropuestaModificaMinuta = null;
var DataTablePropuestaModificaGarantia = null;

$(document).ready(function () {
    $("#datepicker").datepicker({
        format: "yyyy-mm-dd",
      });

    LoadDataTablePropuestaExtension(); 
        
});

function LoadDataTablePropuestaExtension() {
    DataTablePropuestaExtension = $('#tblPropuestaExtension').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,        
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta/GetDataTablePropuesta"
        },      
        "columns": [            
            { "data": "id_propuesta", "orderable": true },
            { "data": "consecutivooferta", "orderable": true },            
            { "data": "nmpropuestadt", "orderable": false },
            { "data": "strfecrad", "orderable": true },
            { "data": "entidadcontrata", "orderable": false },
            { "data": "nombreestado", "orderable": true },
            { "data": "strvalor", "className": "dt-body-right", "orderable": false },
            { "data": "responsable", "orderable": false },
            { "data": "nmpropuesta", "visible": false },
            /*
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaExtension(' + row.id_propuesta + ')" /> ' +                           
                           '<img src="../images/iris/seguimiento.png" class="cambiarMouse" title="Seguimiento Propuesta" onclick="SeguimientoPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`);" /> ' +
                           '<img src="../images/iris/minuta.png" class="cambiarMouse" title="Suscripción Minuta" onclick="MinutaPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);" /> ' +
                           '<img src="../images/iris/modificar.png" class="cambiarMouse" title="Modificaciones Minuta" onclick="ModificacionMinutaPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);" /> ' +
                           '<img src="../images/iris/seguro.png" class="cambiarMouse" title="Suscripción Garantía" onclick="SuscribirGarantiaPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);" /> ' +
                           '<img src="../images/iris/modi-seguro.png" class="cambiarMouse" title="Modificaciones Garantía" onclick="ModificacionGarantiaPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`);" /> ';
                },
                "className": "text-center", "orderable": false
            }
            */
            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/bell.png" class="cambiarMouse opciondatatable" title="Notificación Seguimiento" onclick="CrearNotificacionSeguimientoUsuario(`PROPUESTA`,`' + row.consecutivooferta + '`);" data-bs-toggle="modal" data-bs-target="#ModalGenerarAlertaUsuario" /> ' +
                           '<img src="../images/iris/task.png" class="cambiarMouse opciondatatable" title="Tareas" onclick="TareasPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);" /> ' +
                        '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="EditarPropuestaExtension(' + row.id_propuesta + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +                            
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="SeguimientoPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);"><img src="../images/iris/seguimiento.png">   Seguimiento Propuesta</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="MinutaPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);"><img src="../images/iris/minuta.png">   Suscripción Minuta</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="SuscribirGarantiaPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`,`' + row.entidadcontrata + '`);"><img src="../images/iris/seguro.png">   Suscripción Garantía</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="CrearProyectoDesdePropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.entidadcontrata + '`,`' + row.TipoPropuesta + '`,' + row.idpropuesta_entidad + ',' + row.id_tipopropuesta + ');"><img src="../images/iris/project.png">   Crear Proyecto</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarPropuesta(' + row.id_propuesta + ',`' + row.consecutivooferta + '`,`' + row.nmpropuesta + '`);"><img src="../images/iris/Eliminar.png">   Eliminar Propuesta</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
               
        ],         
        "columnDefs": [
            { "targets": 1,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nmpropuesta + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function OpcionesPropuestaExtension() {
    document.getElementById("myDropdown").classList.toggle("show");
  }

function RefreshDataTablePropuestaExtension() {
    DataTablePropuestaExtension.ajax.reload(null, false);
}

function CargarCombosPropuesta() {
    let promises_arrPropuesta = [];
    return new Promise((resolve, reject)=>{

        $('#cboPropuestaContratante').select2();
        $('#cboPropuestaModalidad').select2();
        $('#cboPropuestaOrigen').select2();
        $('#cboPropuestaTipoPropuesta').select2();
        $('#cboPropuestaTipoUsuario').select2();
        $('#cboPropuestaEstado').select2();
        $('#cboPropuestaResponsable').select2();
    //    $('#cboPropuestaOficioAprob').select2();
    //    $('#cboPropuestaActaAprob').select2();    
    
        promises_arrPropuesta.push(LoadPropuestaContratante('cboPropuestaContratante', true));
        promises_arrPropuesta.push(LoadPropuestaModalidad('cboPropuestaModalidad', true));
        promises_arrPropuesta.push(LoadPropuestaOrigen('cboPropuestaOrigen', true));
        promises_arrPropuesta.push(LoadPropuestaTipoPropuesta('cboPropuestaTipoPropuesta', true));
        promises_arrPropuesta.push(LoadPropuestaTipoUsuario('cboPropuestaTipoUsuario', true));
        promises_arrPropuesta.push(LoadPropuestaEstado('cboPropuestaEstado', true));
        promises_arrPropuesta.push(LoadFuncionarioSelect('cboPropuestaResponsable', true));
    //    LoadPropuestaTipoAprobacionSelect('cboPropuestaOficioAprob');    
    //    LoadPropuestaTipoAprobacionSelect('cboPropuestaActaAprob');

    Promise.all(promises_arrPropuesta)
    .then(selectcargado=>{
        if (selectcargado) {
            resolve (true);
        }
        else {
            resolve(false);
        }
    })
    .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0); 
        reject(err); 
    })
    })
}

function AddSelect2ModalPropuesta() {
    $('#cboPropuestaContratante').select2().val('').trigger("change");
    $('#cboPropuestaModalidad').select2().val('').trigger("change");
    $('#cboPropuestaOrigen').select2().val('').trigger("change");
    $('#cboPropuestaTipoPropuesta').select2().val('').trigger("change");
    $('#cboPropuestaTipoUsuario').select2().val('').trigger("change");
    $('#cboPropuestaEstado').select2().val('').trigger("change");
    $('#cboPropuestaResponsable').select2().val('').trigger("change");
//    $('#cboPropuestaOficioAprob').select2().val('').trigger("change");
//    $('#cboPropuestaActaAprob').select2().val('').trigger("change");

}

//#region CRUD Propuesta
function CrearPropuestaExtension() {
    CargarCombosPropuesta();
    
    $( "#txtConsPropuesta" ).prop( "disabled", false );
    $("#spanIdPropuestaExtension")[0].innerText = '';
    $("#txtConsPropuesta").val('');
    $("#txtNombrePropuesta").val('');
    $("#dtFechaRadicaPropuesta").val('');
    $("#nmValorPropuesta").val('0');
    $("#txtPropuestaContrato").val('');
//    $("#cboPropuestaOficioAprob").val('');
//    $("#cboPropuestaActaAprob").val('');
    $("#txtPropuestaOficioAprob").val('');
    $("#txtPropuestaActaAprob").val('');
    $("#dtFechaRadicaPropuesta").val(getFechaActual());
    $("#txtPropuestaoficioaprobenlace").val('');
    $("#txtPropuestaactaaprobenlace").val('');

    isUpdatePropuestaExtension = false;
    AddSelect2ModalPropuesta();    

    removeValidationFormByForm('formPropuestaExtension');

    $("#dvPropuestaExtensionTable").addClass("ocultar");    
    $("#ModalPropuestaExtension").removeClass("ocultar");
    
}

function ValidatePostUpdatePropuestaExtension(formF, botonClose) {    
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
                if (!isUpdatePropuestaExtension) {                                          
                    ExisteConsecutivoPropuesta()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePropuestaExtension(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePropuestaExtension(botonClose);
                }            
            }
        }
    }
}

function ExisteConsecutivoPropuesta() {    
    let codigoPropuestaExtension = $("#txtConsPropuesta").val();   
    let urlValidar = urlController + "Propuesta/GetPropuestaConsecutivo?consecutivo=" + codigoPropuestaExtension;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El consecutivo " + codigoPropuestaExtension + " ya está registrado.";
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

function AddUpdatePropuestaExtension(botonCerrar) {    
    var objpropuesta = new Object();
    let urlUpdate = urlController + "Propuesta/UpdatePropuesta";

    objpropuesta.id_propuesta = ($("#spanIdPropuestaExtension")[0].innerText == '') ? undefined : $("#spanIdPropuestaExtension")[0].innerText;
    objpropuesta.consecutivooferta = $("#txtConsPropuesta").val();
    objpropuesta.nmpropuesta = $("#txtNombrePropuesta").val();
    objpropuesta.fecrad = $("#dtFechaRadicaPropuesta").val();
    objpropuesta.valorinicialpropuesta = $("#nmValorPropuesta").val();
    objpropuesta.idfuncionario = $("#cboPropuestaResponsable").val();
    objpropuesta.idpropuesta_entidad = $("#cboPropuestaContratante").val();    
    objpropuesta.id_propuestatipousuario = $("#cboPropuestaTipoUsuario").val();
    objpropuesta.id_modalidad = $("#cboPropuestaModalidad").val();
    objpropuesta.id_origenpropuesta = $("#cboPropuestaOrigen").val();
    objpropuesta.id_tipopropuesta = $("#cboPropuestaTipoPropuesta").val();
//    objpropuesta.id_aprobacionconsejofacultad = $("#cboPropuestaOficioAprob").val();
//    objpropuesta.id_actaconsejofacultad = $("#cboPropuestaActaAprob").val();
    objpropuesta.oficioaprobacion = $("#txtPropuestaOficioAprob").val();
    objpropuesta.actaaprobacion = $("#txtPropuestaActaAprob").val();
    objpropuesta.id_estadopropuesta = $("#cboPropuestaEstado").val();
    objpropuesta.contratoconvenio = $("#txtPropuestaContrato").val();
    objpropuesta.oficioaprobenlace = $("#txtPropuestaoficioaprobenlace").val();
    objpropuesta.actaaprobenlace = $("#txtPropuestaactaaprobenlace").val();

    if (objpropuesta.id_propuesta == undefined) {
        urlUpdate = urlController + "Propuesta/InsertPropuesta";        
    }

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objpropuesta),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession')  }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();

            DestruyeSelectEdicionPropuesta();

            $("#ModalPropuestaExtension").addClass("ocultar");    
            $("#dvPropuestaExtensionTable").removeClass("ocultar");
        
            RefreshDataTablePropuestaExtension();
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

function DestruyeSelectEdicionPropuesta() {
    if ($('#cboPropuestaContratante').data('select2')) {
        $('#cboPropuestaContratante').select2('destroy');        
      }    

    if ($('#cboPropuestaModalidad').data('select2')) {
        $('#cboPropuestaModalidad').select2('destroy');        
      }    

    if ($('#cboPropuestaOrigen').data('select2')) {
        $('#cboPropuestaOrigen').select2('destroy');        
      }    

    if ($('#cboPropuestaTipoPropuesta').data('select2')) {
        $('#cboPropuestaTipoPropuesta').select2('destroy');        
      }    

    if ($('#cboPropuestaTipoUsuario').data('select2')) {
        $('#cboPropuestaTipoUsuario').select2('destroy');        
      }    

    if ($('#cboPropuestaEstado').data('select2')) {
        $('#cboPropuestaEstado').select2('destroy');        
      }    

    if ($('#cboPropuestaResponsable').data('select2')) {
        $('#cboPropuestaResponsable').select2('destroy');        
      }    
/*
    if ($('#cboPropuestaOficioAprob').data('select2')) {
        $('#cboPropuestaOficioAprob').select2('destroy');        
      }    

    if ($('#cboPropuestaActaAprob').data('select2')) {
        $('#cboPropuestaActaAprob').select2('destroy');        
      }    
*/
}

function VolverTablaPropuestasDesdeEdicion() {
    DestruyeSelectEdicionPropuesta();

    $("#ModalPropuestaExtension").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");
}

function EditarPropuestaExtension(idpropuesta) {   
    CargarCombosPropuesta()
    .then(()=>{

        removeValidationFormByForm('formPropuestaExtension'); 
        let urlEditar = urlController + "Propuesta/GetPropuestaDetails?id_propuesta=" + idpropuesta;
        isUpdatePropuestaExtension = false;
        StartLoader();
        
        fetch(urlEditar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {                      
                let datos = data.Data;
                
                    
                    $("#spanIdPropuestaExtension")[0].innerText = datos.id_propuesta;
                    $("#txtConsPropuesta").val(datos.consecutivooferta);
                    $("#txtConsPropuesta" ).prop( "disabled", true );
                    $("#txtNombrePropuesta").val(datos.nmpropuesta);
                    $("#dtFechaRadicaPropuesta").val(datos.fecrad.slice(0, 10));
                    $("#nmValorPropuesta").val(datos.valorinicialpropuesta);
                    $('.cboPropuestaResponsable-select2').select2().val(datos.idfuncionario).trigger("change");
                    $('#cboPropuestaContratante').select2().val(datos.idpropuesta_entidad).trigger("change");            
                    $('.cboPropuestaTipoUsuario-select2').select2().val(datos.id_propuestatipousuario).trigger("change");
                    $('.cboPropuestaModalidad-select2').select2().val(datos.id_modalidad).trigger("change");
                    $('.cboPropuestaOrigen-select2').select2().val(datos.id_origenpropuesta).trigger("change");
                    $('.cboPropuestaTipoPropuesta-select2').select2().val(datos.id_tipopropuesta).trigger("change");
        //            $('#cboPropuestaOficioAprob').select2().val(datos.id_aprobacionconsejofacultad).trigger("change");
        //            $('#cboPropuestaActaAprob').select2().val(datos.id_actaconsejofacultad).trigger("change");
        
                    $("#txtPropuestaOficioAprob").val(datos.oficioaprobacion);
                    $("#txtPropuestaActaAprob").val(datos.actaaprobacion);
                    $('.cboPropuestaEstado-select2').select2().val(datos.id_estadopropuesta).trigger("change");
                    $('.cboPropuestaEstado-select2').select2().val(datos.id_estadopropuesta).trigger("change");
                    $("#txtPropuestaContrato").val(datos.contratoconvenio);
                    $("#txtPropuestaoficioaprobenlace").val(datos.oficioaprobenlace);
                    $("#txtPropuestaactaaprobenlace").val(datos.actaaprobenlace);
                
                    //AddSelect2ModalPropuesta();
                
                    isUpdatePropuestaExtension = true;
                    FinalizeLoader();
        
                $("#dvPropuestaExtensionTable").addClass("ocultar");    
                $("#ModalPropuestaExtension").removeClass("ocultar");
            
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
    })  

//    $('#cboPropuestaOficioAprob').select2().val('').trigger("change");
//    $('#cboPropuestaActaAprob').select2().val('').trigger("change");

}

function ValidarEliminarPropuesta(idpropuesta, consecutivo) {
    ShowDialogConfirmacion('','Seguro de eliminar propuesta' + consecutivo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaExtension(idpropuesta);
            }
        });
}

function EliminarPropuestaExtension(idpropuesta) {
    let urlEliminar = urlController + "Propuesta/DeletePropuesta?id_propuesta=" + idpropuesta;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePropuestaExtension();
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

//#endregion


//#region Seguimiento Propuesta
function SeguimientoPropuesta(idpropuesta, consecutivo, nombre) {    
    $("#spanIdPropuestaSeguimiento")[0].innerText = idpropuesta;
    $("#txtConsPropuestaSeguimiento").val(consecutivo);
    $("#txtNombrePropuestaSeguimiento").val(nombre);
        
    LoadDataTablePropuestaSeguimiento();

    $("#dvPropuestaExtensionTable").addClass("ocultar");
    $("#dvPropuestaSegumiento").removeClass("ocultar");    
}

function LoadDataTablePropuestaSeguimiento() {
    DataTablePropuestaSeguimiento = $('#tblSeguimientoPropuestaExtension').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "PropuestaSeguimiento/GetDataTablePropuestaSeguimientoByPropuesta", //?id_propuesta=" + $("#spanIdPropuestaSeguimiento")[0].innerText
            "data": {
                "id_propuesta": function() { return $("#spanIdPropuestaSeguimiento")[0].innerText }                 
            }
        },      
        "columns": [            
            { "data": "strfechaseguimiento", "orderable": true },
            { "data": "seguimientodetalle", "orderable": true },
            { "data": "responsable", "orderable": false }
            /*
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaExtension(' + row.idseguimiento + ')" data-bs-toggle="modal" data-bs-target="#ModalPropuestaExtension" /> ';
                },
                "className": "text-center", "orderable": false
            }
            */
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePropuestaSeguimiento() {
    DataTablePropuestaSeguimiento.ajax.reload(null, false);
}

function CargarCombosSeguimientoPropuesta() {
    $('#cboSeguimientoFuncionario').select2();

    LoadFuncionarioSelect('cboSeguimientoFuncionario', true);
}

function AddSelect2ModalSeguimientoPropuesta() {
    $('#cboSeguimientoFuncionario').select2().val('').trigger("change");

    /*
    $('#cboSeguimientoFuncionario').select2({        
        dropdownParent: $('#ModalSeguimientoPropuestaExtension'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    */
}

function VolverTablaPropuestasDesdeSeguimiento() {
    DataTablePropuestaSeguimiento.destroy();

    $("#spanIdPropuestaSeguimiento")[0].innerText = '';
    $("#txtConsPropuestaSeguimiento").val('');
    $("#txtNombrePropuestaSeguimiento").val('');          

    $("#dvPropuestaSegumiento").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");
}

function VolverATablaSeguimientoPropuesta() {
    $('#cboSeguimientoFuncionario').select2('destroy');

    $("#ModalSeguimientoPropuestaExtension").addClass("ocultar");    
    $("#dvPropuestaSegumiento").removeClass("ocultar");        
}

function CrearSeguimientoPropuestaExtension() {
    CargarCombosSeguimientoPropuesta();
    $('#cboSeguimientoFuncionario').select2().val('').trigger("change");

    $("#dtfechaseguimientoPropuesta").val(getFechaActual());
    $("#txtseguimientodetallePropuesta").val('');

    $("#dvPropuestaSegumiento").addClass("ocultar");    
    $("#ModalSeguimientoPropuestaExtension").removeClass("ocultar");        

}

function ValidatePostUpdateSeguimientoPropuestaExtension(formF, botonClose) {
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
                AddUpdateSeguimientoPropuestaExtension(botonClose);
            }
        }
    }    
}

function AddUpdateSeguimientoPropuestaExtension(botonCerrar) {    
    let objseguimiento = new Object();
    let urlUpdate = urlController + "PropuestaSeguimiento/InsertPropuestaSeguimiento";

    objseguimiento.id_propuesta = ($("#spanIdPropuestaSeguimiento")[0].innerText == '') ? undefined : $("#spanIdPropuestaSeguimiento")[0].innerText;
    objseguimiento.seguimientodetalle = $("#txtseguimientodetallePropuesta").val();
    objseguimiento.fechaseguimiento = $("#dtfechaseguimientoPropuesta").val();
    objseguimiento.idfuncionario = $("#cboSeguimientoFuncionario").val();

    if (objseguimiento.id_propuesta == undefined) {
        return;
//        urlUpdate = urlController + "Propuesta/InsertPropuesta";        
    }

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objseguimiento),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            VolverATablaSeguimientoPropuesta()

            RefreshDataTablePropuestaSeguimiento();
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
//#endregion

//#region Minuta Propuesta
function MinutaPropuesta(idpropuesta, consecutivo, nombre, entidadcontrata) {
    $("#spanidpropuestaminuta")[0].innerText = idpropuesta;
    $("#spanidsuscripcionminuta")[0].innerText = '';
    
    $("#txtConsPropuestaMinuta").val(consecutivo);
    $("#txtNombrePropuestaMinuta").val(nombre);
    
    //CARRGA DATOS EN LOS CAMPOS SELECT DE LA MINUTA
    CargarCombosMinutaPropuesta()
    .then(()=>{

    
    InicializaCamposMinutaPropuesta();
    $("#txtMinutaEntidadResponsable").val(entidadcontrata);
    
    let urlMinutaPropuesta = urlController + "Propuesta_SuscripcionMinuta/GetPropuesta_SuscripcionMinutaByPropuesta?idpropuesta=" + idpropuesta;    
    
    fetch(urlMinutaPropuesta, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
    .then(data => {
        if (data.Ok) {
            AddSelect2ModalMinutaPropuesta();        
            StartLoader();
                    
                    CargarCamposMinutaPropuesta(data.Data);
                    FinalizeLoader();

    
                $("#dvPropuestaExtensionTable").addClass("ocultar");
                $("#dvPropuestaMinuta").removeClass("ocultar");    
            
                return;
            }
            else {
                AddSelect2ModalMinutaPropuesta();        
    
                $("#dvPropuestaExtensionTable").addClass("ocultar");
                $("#dvPropuestaMinuta").removeClass("ocultar");    

                return;
            }
        })
        .catch(err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
        });
    })
}

function CargarCombosMinutaPropuesta() {
    let promises_arrMinutaPropuesta = [];
    return new Promise((resolve, reject)=>{

        promises_arrMinutaPropuesta.push(LoadAvalConsejoSelect('cboidavalconfac'));
        promises_arrMinutaPropuesta.push(LoadFuncionarioSelect('cboidresponsablece', true));
        promises_arrMinutaPropuesta.push(LoadFuncionarioSelect('cboidresponsabledecanatura', true));    
        promises_arrMinutaPropuesta.push(LoadFuncionarioSelect('cboidresponsableobsdec', true));
        promises_arrMinutaPropuesta.push(LoadFuncionarioSelect('cboidresponsableintegraobs', true));
        promises_arrMinutaPropuesta.push(LoadFuncionarioSelect('cboidresponsableavales', true));
        promises_arrMinutaPropuesta.push(LoadFuncionarioSelect('cboidresponsablefirma', true));           
        
        Promise.all(promises_arrMinutaPropuesta)
        .then(selectcargado=>{
            if (selectcargado) {
                resolve (true);
            }
            else {
                resolve(false);
            }
        })
        .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0); 
            reject(err); 
        })
    })
}

function InicializaCamposMinutaPropuesta() {
    $('#cboidavalconfac').select2().val('').trigger("change");
    $("#dtfecrecepcion").val(getFechaActual());    
    $("#dtfecrevce").val('');
    $('#cboidresponsablece').select2().val('').trigger("change");
    $("#dtfecremisiondecanatura").val('');
    $('#cboidresponsabledecanatura').select2().val('').trigger("change");
    $("#dtfecrespuestaobsdecanatura").val('');
    $("#txtobservacionesdecanatura").val('');
    $('#cboidresponsableobsdec').select2().val('').trigger("change");
    $("#fecintegracionaobsminuta").val('');
    $('#cboidresponsableintegraobs').select2().val('').trigger("change");
    $("#txtconsecutivoremisionminutaent").val('');
    $("#nmtiemporevminuta").val('');
    $("#dtfecrespobsminuta").val('');
    $("#nmtiemporemminutaobs").val('');    
    $("#dtfecaprintminuta").val('');
    $('#cboavalesinternos').select2().val('0').trigger("change");
    $('#cboidresponsableavales').select2().val('').trigger("change");
    $("#dtfirmaunal").val('');
    $("#dtfirmaminutasecop").val('');
    $('#cboidresponsablefirma').select2().val('').trigger("change");    
    $("#dtfirmaentidad").val('');
    $("#txtnumminuta").val('');
    $("#txtnombreminutaproyecto").val('');
    $("#txtenlacesoportes").val('');    
    $('#cbominutacargadasecop').select2().val('0').trigger("change");    
}

function CargarCamposMinutaPropuesta(objdatos) {     
    $("#spanidsuscripcionminuta")[0].innerText = objdatos.id_suscripcionminuta;
    $('#cboidavalconfac').select2().val(objdatos.id_avalconfac).trigger("change");
    $("#dtfecrecepcion").val(objdatos.fecrecepcion.slice(0,10));
    if (objdatos.fecrevce != null) {
        $("#dtfecrevce").val(objdatos.fecrevce.slice(0,10));
    }
    
    if (objdatos.idresponsablece != null) {
        $('#cboidresponsablece').select2().val(objdatos.idresponsablece).trigger("change");
    }
    
    if (objdatos.fecremisiondecanatura != null) {
        $("#dtfecremisiondecanatura").val(objdatos.fecremisiondecanatura.slice(0,10));
    }    
    
    if (objdatos.idresponsabledecanatura != null) {
        $('#cboidresponsabledecanatura').select2().val(objdatos.idresponsabledecanatura).trigger("change");
    }
    
    if (objdatos.fecrespuestaobsdecanatura != null) {
        $("#dtfecrespuestaobsdecanatura").val(objdatos.fecrespuestaobsdecanatura.slice(0,10));
    }
        
    $("#txtobservacionesdecanatura").val(objdatos.observacionesdecanatura);

    if (objdatos.idresponsableobsdec != null) {
        $('#cboidresponsableobsdec').select2().val(objdatos.idresponsableobsdec).trigger("change");
    }
    
    if (objdatos.fecintegracionaobsminuta != null) {
        $("#fecintegracionaobsminuta").val(objdatos.fecintegracionaobsminuta.slice(0,10));
    }
    
    if (objdatos.idresponsableintegraobs != null) {
        $('#cboidresponsableintegraobs').select2().val(objdatos.idresponsableintegraobs).trigger("change");
    }
    
    $("#txtconsecutivoremisionminutaent").val(objdatos.consecutivoremisionminutaent);
    $("#nmtiemporevminuta").val(objdatos.tiemporevminuta);

    if (objdatos.fecintegracionaobsminuta != null) {
        $("#dtfecrespobsminuta").val(objdatos.fecrespobsminuta.slice(0,10));
    }
    
    $("#nmtiemporemminutaobs").val(objdatos.tiemporemminutaobs);

    if (objdatos.fecaprintminuta != null) {
        $("#dtfecaprintminuta").val(objdatos.fecaprintminuta.slice(0,10));
    }
    
    if (objdatos.avalesinternos != null) {
        $('#cboavalesinternos').select2().val(objdatos.avalesinternos).trigger("change");
    }
    
    if (objdatos.idresponsableavales != null) {
        $('#cboidresponsableavales').select2().val(objdatos.idresponsableavales).trigger("change");
    }
    
    if (objdatos.firmaunal != null) {
        $("#dtfirmaunal").val(objdatos.firmaunal.slice(0,10));
    }
    
    if (objdatos.firmaminutasecop != null) {
        $("#dtfirmaminutasecop").val(objdatos.firmaminutasecop.slice(0,10));
    }
    
    if (objdatos.idresponsablefirma != null) {
        $('#cboidresponsablefirma').select2().val(objdatos.idresponsablefirma).trigger("change");    
    }
    
    if (objdatos.firmaentidad != null) {
        $("#dtfirmaentidad").val(objdatos.firmaentidad.slice(0,10));
    }
    
    $("#txtnumminuta").val(objdatos.numminuta);
    $("#txtnombreminutaproyecto").val(objdatos.nombreminutaproyecto);
    $("#txtenlacesoportes").val(objdatos.enlacesoportes);

    if (objdatos.minutacargadasecop != null) {
        $('#cbominutacargadasecop').select2().val(objdatos.minutacargadasecop).trigger("change");
    }
        
}

function AddSelect2ModalMinutaPropuesta() {
    $('#cboidavalconfac').select2();
    $('#cboidresponsablece').select2();
    $('#cboidresponsabledecanatura').select2();
    $('#cboidresponsableobsdec').select2();
    $('#cboidresponsableintegraobs').select2();
    $('#cboidresponsableavales').select2();
    $('#cboidresponsablefirma').select2();    
    $('#cbominutacargadasecop').select2();
    $('#cboavalesinternos').select2();

}

function DestruyeSelectMinutaPropuesta() {
    $('#cboidavalconfac').select2('destroy');
    $('#cboidresponsablece').select2('destroy');
    $('#cboidresponsabledecanatura').select2('destroy');
    $('#cboidresponsableobsdec').select2('destroy');
    $('#cboidresponsableintegraobs').select2('destroy');
    $('#cboidresponsableavales').select2('destroy');
    $('#cboidresponsablefirma').select2('destroy');
    $('#cbominutacargadasecop').select2('destroy');
    $('#cboavalesinternos').select2('destroy');
}

function VolverTablaPropuestasdesdeMinuta() {
    $("#spanidpropuestaminuta")[0].innerText = '';
    $("#spanidsuscripcionminuta")[0].innerText = '';

    $("#txtConsPropuestaMinuta").val('');
    $("#txtNombrePropuestaMinuta").val('');    

    DestruyeSelectMinutaPropuesta();

    $("#dvPropuestaMinuta").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");

}

function ValidatePostUpdateMinutaPropuestaExtension(formF) {    
    validateTextXSSLastButtonByForm(formF);
    debugger;

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
                AddUpdateMinutaPropuestaExtension();
            }
        }
    }    
}

function AddUpdateMinutaPropuestaExtension() {  
    debugger;  
    let objminuta = new Object();
    let urlUpdate = urlController + "Propuesta_SuscripcionMinuta/UpdatePropuesta_SuscripcionMinuta";
    StartLoader();
    
    objminuta.id_suscripcionminuta = ($("#spanidsuscripcionminuta")[0].innerText == '') ? undefined : $("#spanidsuscripcionminuta")[0].innerText;
    
    objminuta.id_avalconfac =$('#cboidavalconfac').val();
    objminuta.id_propuesta = $("#spanidpropuestaminuta")[0].innerText;
    objminuta.fecrecepcion = $("#dtfecrecepcion").val();
    objminuta.minutacargadasecop = $("#cbominutacargadasecop").val();
    objminuta.fecrevce = ($("#dtfecrevce").val() == '') ? undefined : $("#dtfecrevce").val();     
    objminuta.fecremisiondecanatura = ($("#dtfecremisiondecanatura").val() == '') ? undefined : $("#dtfecremisiondecanatura").val(); 
    objminuta.consecutivoremisiondecanatura = $("#txtconsecutivoremisionminutaent").val();
    objminuta.fecrespuestaobsdecanatura = ($("#dtfecrespuestaobsdecanatura").val() == '') ? undefined : $("#dtfecrespuestaobsdecanatura").val(); 
    objminuta.observacionesdecanatura = $("#txtobservacionesdecanatura").val();
    objminuta.fecintegracionaobsminuta = ($("#dtfecintegracionaobsminuta").val() == '') ? undefined : $("#dtfecintegracionaobsminuta").val(); 
    objminuta.consecutivoremisionminutaent = $("#txtconsecutivoremisionminutaent").val();
    objminuta.tiemporevminuta = ($("#nmtiemporemminutaobs").val() == '') ? undefined : $("#nmtiemporemminutaobs").val(); 
    objminuta.fecrespobsminuta = ($("#dtfecrespobsminuta").val() == '') ? undefined : $("#dtfecrespobsminuta").val(); 
    objminuta.tiemporemminutaobs = ($("#nmtiemporevminuta").val() == '') ? undefined : $("#nmtiemporevminuta").val(); 
    objminuta.fecaprintminuta = ($("#dtfecaprintminuta").val() == '') ? undefined : $("#dtfecaprintminuta").val(); 
    objminuta.avalesinternos = $("#cboavalesinternos").val();
    objminuta.firmaunal = ($("#dtfirmaunal").val() == '') ? undefined : $("#dtfirmaunal").val(); 
    objminuta.firmaminutasecop = ($("#dtfirmaminutasecop").val() == '') ? undefined : $("#dtfirmaminutasecop").val(); 
    objminuta.firmaentidad = ($("#dtfirmaentidad").val() == '') ? undefined : $("#dtfirmaentidad").val(); 
    objminuta.numminuta =  $("#txtnumminuta").val();
    objminuta.nombreminutaproyecto = $("#txtnombreminutaproyecto").val();
    objminuta.enlacesoportes = $("#txtenlacesoportes").val();
    objminuta.idresponsablece = ($("#cboidresponsablece").val() == '') ? undefined : $("#cboidresponsablece").val(); 
    objminuta.idresponsabledecanatura = ($("#cboidresponsabledecanatura").val() == '') ? undefined : $("#cboidresponsabledecanatura").val(); 
    objminuta.idresponsableobsdec = ($("#cboidresponsableobsdec").val() == '') ? undefined : $("#cboidresponsableobsdec").val(); 
    objminuta.idresponsableintegraobs = ($("#cboidresponsableintegraobs").val() == '') ? undefined : $("#cboidresponsableintegraobs").val(); 
    objminuta.idresponsableavales = ($("#cboidresponsableavales").val() == '') ? undefined : $("#cboidresponsableavales").val(); 
    objminuta.idresponsablefirma = ($("#cboidresponsablefirma").val() == '') ? undefined : $("#cboidresponsablefirma").val(); 

    if (objminuta.id_suscripcionminuta == undefined) {
        urlUpdate = urlController + "Propuesta_SuscripcionMinuta/InsertPropuesta_SuscripcionMinuta";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objminuta),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            VolverTablaPropuestasdesdeMinuta();            
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
//#endregion

//#region ModificacionMinutaPropuesta
function ModificacionMinutaPropuesta(idpropuesta, consecutivo, nombre, entidadcontrata) {  
    let urlModiMinuta = urlController + "Propuesta_SuscripcionMinuta/GetPropuesta_SuscripcionMinutaByPropuesta?idpropuesta=" + idpropuesta;

    fetch(urlModiMinuta, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            $("#spanIdPropuestaModificaMinuta")[0].innerText = idpropuesta;
            $("#spanIdSucripcionMinutaModificaMinuta")[0].innerText = datos.id_suscripcionminuta;
            $("#txtConsPropuestaModificaMinuta").val(consecutivo);
            $("#txtNombrePropuestaModificaMinuta").val(nombre);
                
            LoadDataTablePropuestaModificaMinuta();
        
            FinalizeLoader();

            $("#dvPropuestaExtensionTable").addClass("ocultar");
            $("#dvPropuestaModificacionMinuta").removeClass("ocultar");    
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

function LoadDataTablePropuestaModificaMinuta() {
    DataTablePropuestaModificaMinuta = $('#tblPropuestaModificacionMinuta').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_ModificacionMinuta/GetDataTablePropuestaModificacionMinutaByPropuesta", //?id_propuesta=" + $("#spanIdPropuestaModificaMinuta")[0].innerText
            "data": {
                "id_propuesta": function() { return $("#spanIdPropuestaModificaMinuta")[0].innerText }                
            }
        },      
        "columns": [                        
            { "data": "fecsolmodvol", "orderable": true, render: function (data, type, row, meta) {return row.fecsolmodvol.slice(0,10)} },
            { "data": "descripcionmodificacion", "orderable": true },
            { "data": "tipomodificaciondetalle", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarModificacionMinutaPropuesta(' + row.id_modificacionminuta + ',' + row.id_suscripcionminuta + ',' + row.id_propuesta + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePropuestaModificaMinuta() {
    DataTablePropuestaModificaMinuta.ajax.reload(null, false);
}

function VolverTablaPropuestasDesdeModificaMinuta() {
    DataTablePropuestaModificaMinuta.destroy();

    $("#spanIdPropuestaModificaMinuta")[0].innerText = '';
    $("#spanIdSucripcionMinutaModificaMinuta")[0].innerText = '';    
    $("#txtConsPropuestaModificaMinuta").val('');
    $("#txtNombrePropuestaModificaMinuta").val('');          

    $("#dvPropuestaModificacionMinuta").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");
}

function CargarCombosModificacionMinutaPropuesta() {
    LoadFuncionarioSelect('cboRespSolicitudModificacion', true);
    LoadFuncionarioSelect('cboidresponsableremitedecanatura', true);    
    LoadFuncionarioSelect('cboidresponsableaprobmodificacionminuta', true);
    LoadTipoModificacionMinutaSelect('cboTipoModificacionMinuta', true);
    
/*
    $('#cboidresponsableremitedecanatura').empty();
    $('#cboidresponsableaprobmodificacionminuta').empty();
*/
}

function InicializaCamposModificacionMinutaPropuesta() {
    $("#dtFechaSolicitaModificacion").val(getFechaActual());    
    $('#cboTipoModificacionMinuta').select2().val('').trigger("change");
    $("#txtDescrModificacionMinuta").val('');
    $('#cboRespSolicitudModificacion').select2().val('').trigger("change");
    $("#dtfecrevisionsolicitud").val('');
    $('#cboidresponsableremitedecanatura').select2().val('').trigger("change");
    $("#txtconsecutivodecremisionmodificacionminuta").val('');
    $("#nmtiemporevmodificacionminuta").val('');
    $('#cboidresponsableaprobmodificacionminuta').select2().val('').trigger("change");
    $("#dtfecrecepcionobsdecmodiminuta").val('');    
    $("#dtfecremisionobsmodiminutaentidad").val('');
    $("#dtfecaprobacionobsmodiminutaentidad").val('');
    $('#cboavalesinternosmodiminuta').select2().val('0').trigger("change");
    $("#dtfechasuscripcionmodiminuta").val('');
    $("#nmvalorajustadomodificacionminuta").val('');
    $("#txtplazoajustadomodificacionminuta").val('');
    $("#txtobligacionajustadamodiminuta").val('');
    $("#txtproductoajustadamodiminuta").val('');    
    $("#txtenlacesoportemodiminuta").val('');
}

function AddSelect2DivModificaMinutaPropuesta() {
    $('#cboTipoModificacionMinuta').select2();
    $('#cboRespSolicitudModificacion').select2();
    $('#cboidresponsableremitedecanatura').select2();
    $('#cboidresponsableaprobmodificacionminuta').select2();
    $('#cboavalesinternosmodiminuta').select2();
}

function DestruyeSelectModificacionMinuta() {
    $('#cboTipoModificacionMinuta').select2('destroy');
    $('#cboRespSolicitudModificacion').select2('destroy');
    $('#cboidresponsableremitedecanatura').select2('destroy');
    $('#cboidresponsableaprobmodificacionminuta').select2('destroy');
    $('#cboavalesinternosmodiminuta').select2('destroy');
}

function CrearModificacionMinutaPropuesta() {
    $("#spanidmodificacionminuta")[0].innerText = '';
    $("#spanidsuscripcionaadmodificacionminuta")[0].innerText = $("#spanIdSucripcionMinutaModificaMinuta")[0].innerText;
    $("#spanidpropuestaaddmodificacionminuta")[0].innerText = $("#spanIdPropuestaModificaMinuta")[0].innerText;

//    $("#txtConsPropuestaMinuta").val(consecutivo);
//    $("#txtNombrePropuestaMinuta").val(nombre);

    //CARRGA DATOS EN LOS CAMPOS SELECT DE LA MODIFICACION MINUTA
    CargarCombosModificacionMinutaPropuesta();

    InicializaCamposModificacionMinutaPropuesta();

    AddSelect2DivModificaMinutaPropuesta()

    removeValidationFormByForm('formAddModificacionMinutaPropuesta');

    $("#dvPropuestaModificacionMinuta").addClass("ocultar");    
    $("#dvAddModificacionMinutaPropuesta").removeClass("ocultar");

}

function  CargarCamposModificacionMinutaPropuesta(objdatos) {
    $("#dtFechaSolicitaModificacion").val(objdatos.fecsolmodvol.slice(0,10));    
    $('#cboTipoModificacionMinuta').select2().val(objdatos.id_tipomodificacion).trigger("change");
    $("#txtDescrModificacionMinuta").val(objdatos.descripcionmodificacion);

    if (objdatos.idresponsablerevsolicitud != null){
        $('#cboRespSolicitudModificacion').select2().val(objdatos.idresponsablerevsolicitud).trigger("change");
    }
    
    if (objdatos.fecrevisionsolicitud != null) {
        $("#dtfecrevisionsolicitud").val(objdatos.fecrevisionsolicitud.slice(0,10));
    }
    
    if (objdatos.idresponsableremitedecanatura != null) {
        $('#cboidresponsableremitedecanatura').select2().val(objdatos.idresponsableremitedecanatura).trigger("change");
    }
    
    $("#txtconsecutivodecremisionmodificacionminuta").val(objdatos.consecutivoremisiondecanatura);

    if (objdatos.tiemporevisiondec !=null) {
        $("#nmtiemporevmodificacionminuta").val(objdatos.tiemporevisiondec);
    }
    
    if (objdatos.idresponsableaprobmodificacion != null) {
        $('#cboidresponsableaprobmodificacionminuta').select2().val(objdatos.idresponsableaprobmodificacion).trigger("change");
    }
    
    if (objdatos.fecrecepcionobsdec != null) {
        $("#dtfecrecepcionobsdecmodiminuta").val(objdatos.fecrecepcionobsdec.slice(0,10)); 
    }
       
    if (objdatos.fecremisionobsentidad != null) {
        $("#dtfecremisionobsmodiminutaentidad").val(objdatos.fecremisionobsentidad.slice(0,10));
    }
    
    if (objdatos.fecapromodificaciones != null) {
        $("#dtfecaprobacionobsmodiminutaentidad").val(objdatos.fecapromodificaciones.slice(0,10));    
    }

    $('#cboavalesinternosmodiminuta').select2().val(objdatos.avalinterno).trigger("change");

    if (objdatos.fecsusmodacuvol != null) {
        $("#dtfechasuscripcionmodiminuta").val(objdatos.fecsusmodacuvol.slice(0,10));
    }

    $("#nmvalorajustadomodificacionminuta").val(objdatos.valorajustado);
    $("#txtplazoajustadomodificacionminuta").val(objdatos.plazoejecajustado);
    $("#txtobligacionajustadamodiminuta").val(objdatos.obligacionesmodificadas);
    $("#txtproductoajustadamodiminuta").val(objdatos.productosmodificados);    
    $("#txtenlacesoportemodiminuta").val(objdatos.enlacesoportes);
}

function EditarModificacionMinutaPropuesta(idmodificacionminuta, idsuscripcionminuta, idpropuesta) {
    $("#spanidmodificacionminuta")[0].innerText = idmodificacionminuta;
    $("#spanidsuscripcionaadmodificacionminuta")[0].innerText = idsuscripcionminuta;
    $("#spanidpropuestaaddmodificacionminuta")[0].innerText = idpropuesta;

    CargarCombosModificacionMinutaPropuesta();    

    removeValidationFormByForm('formAddModificacionMinutaPropuesta'); 
    let urlEditarModificacionMinuta = urlController + "Propuesta_ModificacionMinuta/GetPropuesta_ModificacionMinutaDetails?id_modificacionminuta=" + idmodificacionminuta;
    //isUpdatePropuestaExtension = false;
    StartLoader();

    fetch(urlEditarModificacionMinuta, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            CargarCamposModificacionMinutaPropuesta(datos);

            AddSelect2DivModificaMinutaPropuesta();
        
            FinalizeLoader();

            $("#dvPropuestaModificacionMinuta").addClass("ocultar");    
            $("#dvAddModificacionMinutaPropuesta").removeClass("ocultar");
        
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

function VolverTablaModificacionesMinuta() {
    $("#dvAddModificacionMinutaPropuesta").addClass("ocultar");    
    $("#dvPropuestaModificacionMinuta").removeClass("ocultar");

}

function ValidatePostUpdateModificacionMinutaPropuesta(formF) {    
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
                AddUpdateModificacionMinutaPropuesta();
            }
        }
    }    

}

function AddUpdateModificacionMinutaPropuesta() {
    let objmodificaminuta = new Object();
    let urlUpdate = urlController + "Propuesta_ModificacionMinuta/UpdatePropuesta_ModificacionMinuta";
    StartLoader();
    
    objmodificaminuta.id_modificacionminuta = ($("#spanidmodificacionminuta")[0].innerText == '') ? undefined : $("#spanidmodificacionminuta")[0].innerText;
    
    objmodificaminuta.id_suscripcionminuta = $("#spanidsuscripcionaadmodificacionminuta")[0].innerText;
    objmodificaminuta.id_propuesta = $("#spanidpropuestaaddmodificacionminuta")[0].innerText;
    objmodificaminuta.fecsolmodvol = $("#dtFechaSolicitaModificacion").val();
    objmodificaminuta.id_tipomodificacion = $("#cboTipoModificacionMinuta").val();
    objmodificaminuta.descripcionmodificacion = $("#txtDescrModificacionMinuta").val();
    objmodificaminuta.idresponsablerevsolicitud = ($("#cboRespSolicitudModificacion").val() == '') ? undefined : $("#cboRespSolicitudModificacion").val();
    objmodificaminuta.fecrevisionsolicitud = ($("#dtfecrevisionsolicitud").val() == '') ? undefined : $("#dtfecrevisionsolicitud").val();    
    objmodificaminuta.idresponsableremitedecanatura = ($("#cboidresponsableremitedecanatura").val() == '') ? undefined : $("#cboidresponsableremitedecanatura").val();
    objmodificaminuta.fecremsolmoddecanatura = ($("#dtfecremsolmoddecanatura").val() == '') ? undefined : $("#dtfecremsolmoddecanatura").val();
    objmodificaminuta.consecutivoremisiondecanatura = $("#txtconsecutivodecremisionmodificacionminuta").val();
    objmodificaminuta.tiemporevisiondec = ($("#nmtiemporevmodificacionminuta").val() == '') ? undefined : $("#nmtiemporevmodificacionminuta").val(); 
    objmodificaminuta.idresponsableaprobmodificacion = ($("#cboidresponsableaprobmodificacionminuta").val() == '') ? undefined : $("#cboidresponsableaprobmodificacionminuta").val();
    objmodificaminuta.fecrecepcionobsdec = ($("#dtfecrecepcionobsdecmodiminuta").val() == '') ? undefined : $("#dtfecrecepcionobsdecmodiminuta").val(); 
    objmodificaminuta.fecremisionobsentidad = ($("#dtfecremisionobsmodiminutaentidad").val() == '') ? undefined : $("#dtfecremisionobsmodiminutaentidad").val(); 
    objmodificaminuta.fecapromodificaciones = ($("#dtfecaprobacionobsmodiminutaentidad").val() == '') ? undefined : $("#dtfecaprobacionobsmodiminutaentidad").val();
    objmodificaminuta.avalinterno = $("#cboavalesinternosmodiminuta").val();
    objmodificaminuta.fecsusmodacuvol = ($("#dtfechasuscripcionmodiminuta").val() == '') ? undefined : $("#dtfechasuscripcionmodiminuta").val();
    objmodificaminuta.valorajustado = ($("#nmvalorajustadomodificacionminuta").val() == '') ? 0 : $("#nmvalorajustadomodificacionminuta").val(); 
    objmodificaminuta.plazoejecajustado = $("#txtplazoajustadomodificacionminuta").val();
    objmodificaminuta.obligacionesmodificadas = $("#txtobligacionajustadamodiminuta").val();
    objmodificaminuta.productosmodificados =  $("#txtproductoajustadamodiminuta").val();
    objmodificaminuta.enlacesoportes = $("#txtenlacesoportemodiminuta").val();
    
    if (objmodificaminuta.id_modificacionminuta == undefined) {
        urlUpdate = urlController + "Propuesta_ModificacionMinuta/InsertPropuesta_ModificacionMinuta";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objmodificaminuta),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {     
            FinalizeLoader();

            DestruyeSelectModificacionMinuta();

            $("#dvAddModificacionMinutaPropuesta").addClass("ocultar");    
            $("#dvPropuestaModificacionMinuta").removeClass("ocultar");
        
            RefreshDataTablePropuestaModificaMinuta();
            return;                  
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);      
            DestruyeSelectModificacionMinuta();      

            $("#dvAddModificacionMinutaPropuesta").addClass("ocultar");    
            $("#dvPropuestaModificacionMinuta").removeClass("ocultar");

            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        DestruyeSelectModificacionMinuta();      

        $("#dvAddModificacionMinutaPropuesta").addClass("ocultar");    
        $("#dvPropuestaModificacionMinuta").removeClass("ocultar");

      } );      

}

//#endregion

//#region Garantia Propuesta
function SuscribirGarantiaPropuesta (idpropuesta, consecutivo, nombre, entidadcontrata) {
    $("#spanidpropuestagarantia")[0].innerText = idpropuesta;
    $("#spanidsuscripciongarantia")[0].innerText = '';
    removeValidationFormByForm('formGarantiaPropuestaExtension');

    $("#txtConsPropuestaGarantia").val(consecutivo);
    $("#txtNombrePropuestaGarantia").val(nombre);

    //CARRGA DATOS EN LOS CAMPOS SELECT DE LA POLIZA
    CargarCombosGarantiaPropuesta()
    .then(()=>{

        InicializaCamposGarantiaPropuesta();
        //$("#txtMinutaEntidadResponsable").val(entidadcontrata);
            
        let urlGarantiaPropuesta = urlController + "Propuesta_SuscripcionGarantia/GetPropuesta_SuscripcionGarantiaByPropuesta?idpropuesta=" + idpropuesta;    
    
        fetch(urlGarantiaPropuesta, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
            .then(response => response.json())
            .then(data => {
                if (data.Ok) {
                    StartLoader()
                    setTimeout(() => {
                        
                        CargarCamposGarantiaPropuesta(data.Data);
                        FinalizeLoader()
                    }, 1500);
    
                    AddSelect2DivGarantiaPropuesta();        
        
                    $("#dvPropuestaExtensionTable").addClass("ocultar");
                    $("#dvPropuestaGarantia").removeClass("ocultar");    
                
                    return;
                }
                else {
                    AddSelect2DivGarantiaPropuesta();        
        
                    $("#dvPropuestaExtensionTable").addClass("ocultar");
                    $("#dvPropuestaGarantia").removeClass("ocultar");    
    
                    return;
                }
            })
            .catch(err => {
                ShowModalDialog(err, false, 'error', '', 0);
                reject(err);
            });
    })

        
}

function CargarCombosGarantiaPropuesta() {  

    let promises_arrGarantiaPropuesta = [];
    return new Promise((resolve, reject) => {
        
    
    promises_arrGarantiaPropuesta.push(LoadPropuestaCoberturaSelect('cbocoberturasgtiapropuesta', true));
    promises_arrGarantiaPropuesta.push(LoadFuncionarioSelect('cboidresponsablesolaseguradoragtiaprop', true));
    promises_arrGarantiaPropuesta.push(LoadFuncionarioSelect('cboidresppagopolizagtiaprop', true));    
    promises_arrGarantiaPropuesta.push(LoadFuncionarioSelect('cboidresponrempolizagtiaprop', true));
    promises_arrGarantiaPropuesta.push(LoadFuncionarioSelect('cboidresppolizasecopgtiaprop', true));

    Promise.all(promises_arrGarantiaPropuesta)
    .then(selectcargado=>{
        if (selectcargado) {
            resolve (true);
        }
        else {
            resolve(false);
        }
    })
    .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0); 
        reject(err); 
    })


    /*
    $('#cbocoberturasgtiapropuesta').empty();

    $('#cbocoberturasgtiapropuesta').select2({
        data:[
            {id:0,text:"Seriedad de oferta"},
            {id:1,text:"Cumplimiento"},
            {id:2,text:"Devolución de pago anticipado"},
            {id:3,text:"Pago de salarios"},
            {id:4,text:"Estabilidad y calidad de obra"},
            {id:5,text:"Calidad del servicio"},
            {id:6,text:"Calidad y correcto funcionamiento de los bienes"},
            {id:7,text:"Responsabilidad Civil Extracontractual"},
            {id:8,text:"Otros"}
        ],
        multiple: true        
    });
*/
})
}

function InicializaCamposGarantiaPropuesta() {
    $('#cbocoberturasgtiapropuesta').select2().val('').trigger("change");
    $("#txtamparogtiapropuesta").val('');
    $("#txtcdpgtiapropuesta").val('');
    $("#txtraggtiapropuesta").val('');
    $("#txtorpagtiapropuesta").val('');    
    $("#dtfecsolaseguradoragtiapropuesta").val(getFechaActual());        
    $('#cboidresponsablesolaseguradoragtiaprop').select2().val('').trigger("change");
    $("#txtaseguradoragtiapropuesta").val('');
    $("#dtfecapropolizagtiapropuesta").val('');
    $("#txtnumeropolizagtiapropuesta").val('');
    $("#dtfecpagopolizagtiapropuesta").val('');
    $("#nmvalorpolizagtiapropuesta").val('');
    $("#dtvigenciapolizainiciogtiapropuesta").val('');
    $("#dtvigenciapolizafingtiapropuesta").val('');    
    $('#cboidresppagopolizagtiaprop').select2().val('').trigger("change");
    $("#dtfecrementidadgtiapropuesta").val('');
    $("#txtconsrempolizagtiapropuesta").val('');    
    $('#cboidresponrempolizagtiaprop').select2().val('').trigger("change");
    $("#dtactupolsecopgtiapropuesta").val('');    
    $('#cboidresppolizasecopgtiaprop').select2().val('').trigger("change");  
}

function CargarCamposGarantiaPropuesta(objdatos) {
    $("#spanidsuscripciongarantia")[0].innerText = objdatos.id_suscripciongarantia;

    let strcobertura = objdatos.coberturas;
    let arraycobertura = strcobertura.split(',');

    $('#cbocoberturasgtiapropuesta').select2().val(arraycobertura).trigger("change");

    $("#txtamparogtiapropuesta").val(objdatos.descripcionamparo);
    $("#txtcdpgtiapropuesta").val(objdatos.cdp);
    $("#txtraggtiapropuesta").val(objdatos.rag);
    $("#txtorpagtiapropuesta").val(objdatos.orpa);    
    $("#dtfecsolaseguradoragtiapropuesta").val(objdatos.fecsolaseguradora.slice(0,10));        

    if (objdatos.idresponsablesolaseguradora != null) {
        $('#cboidresponsablesolaseguradoragtiaprop').select2().val(objdatos.idresponsablesolaseguradora).trigger("change");
    }
    
    $("#txtaseguradoragtiapropuesta").val(objdatos.nombreaseguradora);

    if (objdatos.fecapropoliza != null) {
        $("#dtfecapropolizagtiapropuesta").val(objdatos.fecapropoliza.slice(0,10));
    }
    
    $("#txtnumeropolizagtiapropuesta").val(objdatos.numeropoliza);

    if (objdatos.fecpagopoliza != null) {
        $("#dtfecpagopolizagtiapropuesta").val(objdatos.fecpagopoliza.slice(0,10));
    }
    
    $("#nmvalorpolizagtiapropuesta").val(objdatos.valorpoliza);

    if (objdatos.vigenciapolizainicio != null) {
        $("#dtvigenciapolizainiciogtiapropuesta").val(objdatos.vigenciapolizainicio.slice(0,10));
    }
    
    if (objdatos.vigenciapolizafin != null) {
        $("#dtvigenciapolizafingtiapropuesta").val(objdatos.vigenciapolizafin.slice(0,10));
    }

    if (objdatos.idresponsablepagopoliza != null) {
        $('#cboidresppagopolizagtiaprop').select2().val(objdatos.idresponsablepagopoliza).trigger("change");
    }

    if (objdatos.fecrementidad != null) {
        $("#dtfecrementidadgtiapropuesta").val(objdatos.fecrementidad.slice(0,10));
    }
    
    if (objdatos.consecutivoremision != null) {
        $("#txtconsrempolizagtiapropuesta").val(objdatos.consecutivoremision);    
    }
    
    if (objdatos.actupolsecop != null) {
        $("#dtactupolsecopgtiapropuesta").val(objdatos.actupolsecop.slice(0,10));
    }

    if (objdatos.idresponsableremisionpoliza != null) {
        $('#cboidresponrempolizagtiaprop').select2().val(objdatos.idresponsableremisionpoliza).trigger("change");
    }
    
    if (objdatos.idresponsablepolizasecop != null) {
        $('#cboidresppolizasecopgtiaprop').select2().val(objdatos.idresponsablepolizasecop).trigger("change");      
    }
        
}

function AddSelect2DivGarantiaPropuesta() {
    $('#cbocoberturasgtiapropuesta').select2({multiple: true});
    $('#cboidresponsablesolaseguradoragtiaprop').select2();
    $('#cboidresppagopolizagtiaprop').select2();
    $('#cboidresponrempolizagtiaprop').select2();
    $('#cboidresppolizasecopgtiaprop').select2();
}

function DestruyeSelectGarantiaPropuesta() {
    $('#cbocoberturasgtiapropuesta').select2('destroy');
    $('#cboidresponsablesolaseguradoragtiaprop').select2('destroy');
    $('#cboidresppagopolizagtiaprop').select2('destroy');
    $('#cboidresponrempolizagtiaprop').select2('destroy');
    $('#cboidresppolizasecopgtiaprop').select2('destroy');
}

function VolverTablaPropuestasdesdeGarantia() {
    $("#spanidpropuestagarantia")[0].innerText = '';
    $("#spanidsuscripciongarantia")[0].innerText = '';

    $("#txtConsPropuestaGarantia").val('');
    $("#txtNombrePropuestaGarantia").val('');    

    DestruyeSelectGarantiaPropuesta();

    $("#dvPropuestaGarantia").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");
}

function ValidatePostUpdateGarantiaPropuestaExtension(formF) {
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
                AddUpdateGarantiaPropuestaExtension();
            }
        }
    }    
}

function AddUpdateGarantiaPropuestaExtension() {
    let objgarantia = new Object();
    let urlUpdate = urlController + "Propuesta_SuscripcionGarantia/UpdatePropuesta_SuscripcionGarantia";
    StartLoader();

    let arraycobertura = $("#cbocoberturasgtiapropuesta").val();
    let strcobertura = arraycobertura.toString();

    objgarantia.id_suscripciongarantia = ($("#spanidsuscripciongarantia")[0].innerText == '') ? undefined : $("#spanidsuscripciongarantia")[0].innerText;
    objgarantia.id_propuesta = $("#spanidpropuestagarantia")[0].innerText;
    objgarantia.coberturas = strcobertura;  
    objgarantia.descripcionamparo = $("#txtamparogtiapropuesta").val();
    objgarantia.cdp = $("#txtcdpgtiapropuesta").val();
    objgarantia.rag = $("#txtraggtiapropuesta").val();
    objgarantia.orpa = $("#txtorpagtiapropuesta").val();
    objgarantia.fecsolaseguradora = $("#dtfecsolaseguradoragtiapropuesta").val();        
    objgarantia.idresponsablesolaseguradora = ($('#cboidresponsablesolaseguradoragtiaprop').val() == '') ? undefined : $('#cboidresponsablesolaseguradoragtiaprop').val();
    objgarantia.nombreaseguradora = $("#txtaseguradoragtiapropuesta").val();
    objgarantia.fecapropoliza = ($("#dtfecapropolizagtiapropuesta").val() == '') ? undefined : $("#dtfecapropolizagtiapropuesta").val();    
    objgarantia.numeropoliza = $("#txtnumeropolizagtiapropuesta").val();
    objgarantia.fecpagopoliza = ($("#dtfecpagopolizagtiapropuesta").val() == '') ? undefined : $("#dtfecpagopolizagtiapropuesta").val();
    objgarantia.valorpoliza = $("#nmvalorpolizagtiapropuesta").val();
    objgarantia.vigenciapolizainicio = ($("#dtvigenciapolizainiciogtiapropuesta").val() == '') ? undefined : $("#dtvigenciapolizainiciogtiapropuesta").val();
    objgarantia.vigenciapolizafin = ($("#dtvigenciapolizafingtiapropuesta").val() == '') ? undefined : $("#dtvigenciapolizafingtiapropuesta").val();
    objgarantia.idresponsablepagopoliza = ($("#cboidresppagopolizagtiaprop").val() == '') ? undefined : $("#cboidresppagopolizagtiaprop").val();
    objgarantia.fecrementidad = ($("#dtfecrementidadgtiapropuesta").val() == '') ? undefined : $("#dtfecrementidadgtiapropuesta").val();
    objgarantia.consecutivoremision = $("#txtconsrempolizagtiapropuesta").val();    
    objgarantia.actupolsecop = ($("#dtactupolsecopgtiapropuesta").val() == '') ? undefined : $("#dtactupolsecopgtiapropuesta").val();
    objgarantia.idresponsableremisionpoliza = ($("#cboidresponrempolizagtiaprop").val() == '') ? undefined : $("#cboidresponrempolizagtiaprop").val();
    objgarantia.idresponsablepolizasecop = ($("#cboidresppolizasecopgtiaprop").val() == '') ? undefined : $("#cboidresppolizasecopgtiaprop").val();
    
    if (objgarantia.id_suscripciongarantia == undefined) {
        urlUpdate = urlController + "Propuesta_SuscripcionGarantia/InsertPropuesta_SuscripcionGarantia";
    }    
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objgarantia),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            VolverTablaPropuestasdesdeGarantia();            
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


//#endregion

//#region ModificacionGarantiaPropuesta
function ModificacionGarantiaPropuesta(idpropuesta, consecutivo, nombre, entidadcontrata) {  
    let urlSuscribeGarantia = urlController + "Propuesta_SuscripcionGarantia/GetPropuesta_SuscripcionGarantiaByPropuesta?idpropuesta=" + idpropuesta;

    fetch(urlSuscribeGarantia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            $("#spanIdPropuestaModificaGarantia")[0].innerText = idpropuesta;
            $("#spanIdSucripcionGarantiaModificaGarantia")[0].innerText = datos.id_suscripciongarantia;
            $("#txtConsPropuestaModificaGarantia").val(consecutivo);
            $("#txtNombrePropuestaModificaGarantia").val(nombre);
                
            LoadDataTablePropuestaModificaGarantia();
        
            FinalizeLoader();

            $("#dvPropuestaExtensionTable").addClass("ocultar");
            $("#dvPropuestaModificacionGarantia").removeClass("ocultar");    
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

function LoadDataTablePropuestaModificaGarantia() {
    DataTablePropuestaModificaGarantia = $('#tblPropuestaModificacionGarantia').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_ModificacionGarantia/GetDataTablePropuestaModificacionGarantiaByGarantia", //?id_suscripciongarantia=" + $("#spanIdSucripcionGarantiaModificaGarantia")[0].innerText
            "data": {
                "id_suscripciongarantia": function() { return $("#spanIdSucripcionGarantiaModificaGarantia")[0].innerText }             
            }
        },      
        "columns": [            
            { "data": "fecsolicitud", "orderable": true, render: function (data, type, row, meta) {return row.fecsolicitud.slice(0,10)} },
            { "data": "descripcion", "orderable": true },
            { "data": "tipomodificaciondetalle", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarModificacionGarantiaPropuesta(' + row.id_modificaciongarantia + ',' + row.id_suscripciongarantia + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePropuestaModificaGarantia() {
    DataTablePropuestaModificaGarantia.ajax.reload(null, false);
}

function VolverTablaPropuestasDesdeModificaGarantia() {
    DataTablePropuestaModificaGarantia.destroy();

    $("#spanIdPropuestaModificaGarantia")[0].innerText = '';
    $("#spanIdSucripcionGarantiaModificaGarantia")[0].innerText = '';    
    $("#txtConsPropuestaModificaGarantia").val('');
    $("#txtNombrePropuestaModificaGarantia").val('');          

    $("#dvPropuestaModificacionGarantia").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");
}

function CargarCombosModificacionGarantiaPropuesta() {
    LoadTipoModificacionMinutaSelect('cboTipoModificacionGarantiaPropuesta', false);
}

function InicializaCamposModificacionGarantiaPropuesta() {
    $("#dtFecSolicitaModificacionGarantiaPropuesta").val(getFechaActual());    
    $('#cboTipoModificacionGarantiaPropuesta').select2().val('').trigger("change");
    $("#txtDescrModificacionGarantiaPropuesta").val('');
}

function AddSelect2DivModificaGarantiaPropuesta() {
    $('#cboTipoModificacionGarantiaPropuesta').select2();
}

function DestruyeSelectModificacionGarantiaPropuesta() {
    $('#cboTipoModificacionGarantiaPropuesta').select2('destroy');
}

function CrearModificacionGarantiaPropuesta() {
    $("#spanIdModificacionGarantiaPropuesta")[0].innerText = '';
    $("#spanIdSucripcionGarantiaFormModificaGarantia")[0].innerText = $("#spanIdSucripcionGarantiaModificaGarantia")[0].innerText;

    //CARRGA DATOS EN LOS CAMPOS SELECT DE LA MODIFICACION GARANTIA
    CargarCombosModificacionGarantiaPropuesta();

    InicializaCamposModificacionGarantiaPropuesta();

    AddSelect2DivModificaGarantiaPropuesta()

    removeValidationFormByForm('formAddModificacionGarantiaPropuesta');

    $("#dvPropuestaModificacionGarantia").addClass("ocultar");    
    $("#dvAddModificacionGarantiaPropuesta").removeClass("ocultar");    
}

function EditarModificacionGarantiaPropuesta(idmodificaciongarantia, idsuscripciongarantia) {
    $("#spanIdModificacionGarantiaPropuesta")[0].innerText = idmodificaciongarantia;
    $("#spanIdSucripcionGarantiaFormModificaGarantia")[0].innerText = idsuscripciongarantia;

    CargarCombosModificacionGarantiaPropuesta();    

    removeValidationFormByForm('formAddModificacionGarantiaPropuesta'); 
    let urlEditarModificacionGarantia = urlController + "Propuesta_ModificacionGarantia/GetPropuesta_ModificacionGarantiaDetails?id_modificaciongarantia=" + idmodificaciongarantia;    
    StartLoader();

    fetch(urlEditarModificacionGarantia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            CargarCamposModificacionGarantiaPropuesta(datos);

            AddSelect2DivModificaGarantiaPropuesta();
        
            FinalizeLoader();

            $("#dvPropuestaModificacionGarantia").addClass("ocultar");    
            $("#dvAddModificacionGarantiaPropuesta").removeClass("ocultar");
        
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

function  CargarCamposModificacionGarantiaPropuesta(objdatos) {
    $("#dtFecSolicitaModificacionGarantiaPropuesta").val(objdatos.fecsolicitud.slice(0,10));    
    $('#cboTipoModificacionGarantiaPropuesta').select2().val(objdatos.id_tipomodificacion).trigger("change");
    $("#txtDescrModificacionGarantiaPropuesta").val(objdatos.descripcion);
}

function VolverTablaModificacionesGarantiaPropuesta() {
    $("#dvAddModificacionGarantiaPropuesta").addClass("ocultar");    
    $("#dvPropuestaModificacionGarantia").removeClass("ocultar");
}

function ValidatePostUpdateModificacionGarantiaPropuesta(formF) {    
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
                AddUpdateModificacionGarantiaPropuesta();
            }
        }
    }    

}

function AddUpdateModificacionGarantiaPropuesta() {
    let objmodificagarantia = new Object();
    let urlUpdate = urlController + "Propuesta_ModificacionGarantia/UpdatePropuesta_ModificacionGarantia";
    StartLoader();
    
    objmodificagarantia.id_modificaciongarantia = ($("#spanIdModificacionGarantiaPropuesta")[0].innerText == '') ? undefined : $("#spanIdModificacionGarantiaPropuesta")[0].innerText;    
    objmodificagarantia.id_suscripciongarantia = $("#spanIdSucripcionGarantiaFormModificaGarantia")[0].innerText;
    
    objmodificagarantia.fecsolicitud = $("#dtFecSolicitaModificacionGarantiaPropuesta").val();
    objmodificagarantia.id_tipomodificacion = $("#cboTipoModificacionGarantiaPropuesta").val();
    objmodificagarantia.descripcion = $("#txtDescrModificacionGarantiaPropuesta").val();    
    
    if (objmodificagarantia.id_modificaciongarantia == undefined) {
        urlUpdate = urlController + "Propuesta_ModificacionGarantia/InsertPropuesta_ModificacionGarantia";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objmodificagarantia),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {     
            FinalizeLoader();

            DestruyeSelectModificacionGarantiaPropuesta();

            $("#dvAddModificacionGarantiaPropuesta").addClass("ocultar");    
            $("#dvPropuestaModificacionGarantia").removeClass("ocultar");
        
            RefreshDataTablePropuestaModificaGarantia();
            return;                  
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);      
            DestruyeSelectModificacionGarantiaPropuesta();      

            $("#dvAddModificacionGarantiaPropuesta").addClass("ocultar");    
            $("#dvPropuestaModificacionGarantia").removeClass("ocultar");

            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        DestruyeSelectModificacionGarantiaPropuesta();      

        $("#dvAddModificacionGarantiaPropuesta").addClass("ocultar");    
        $("#dvPropuestaModificacionGarantia").removeClass("ocultar");

      } );      

}

//#endregion



function TareasPropuesta(idpropuesta, consecutivo, nombre) {
    $("#spanIdPropuestaGeneral")[0].innerText = idpropuesta;    
    $("#spanConsecutivoPropuestaGeneral")[0].innerText = consecutivo;    
    $("#spanNombrePropuestaGeneral")[0].innerText = nombre;    

    if (!ExisteDivEdicionDatos('dvPropuestaTareas')) {
        CrearDivEdicionDatos('/Pages/tareas/propuestas_tareas.html', 'dvPropuestaTareas');
    }
    else {
        InicializaPropuestasTareasform();
    }

}

function CrearProyectoDesdePropuesta(idpropuesta, consecutivo, entidad, tipopropuesta, idpropuesta_entidad, id_tipopropuesta) {
    $("#spanIdPropuestaGeneral")[0].innerText = idpropuesta;    
    $("#spanConsecutivoPropuestaGeneral")[0].innerText = consecutivo;    
    //$("#spanNombrePropuestaGeneral")[0].innerText = nombre;    

    let urlMinuta = urlController + "Propuesta_SuscripcionMinuta/GetPropuesta_SuscripcionMinutaByPropuesta?idpropuesta=" + idpropuesta;
    let urlProyecto = urlController + "Proyectos_AsignacionProyecto/GetProyectos_AsignacionProyectoPropuesta?id_propuesta=" + idpropuesta;

    fetch(urlMinuta, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        let fechaSuscripcion = '';
        if (data.Ok) {                      
            let datos = data.Data;
            if (datos.firmaentidad != null) {
                fechaSuscripcion = datos.firmaentidad.slice(0,10);
            }
        }
        
        FinalizeLoader();

        fetch(urlProyecto, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
        .then( dataproyecto => {                
            if (dataproyecto.Ok) {
                ShowModalDialog('Ya fue creado un proyecto asociado con la propuesta', false, 'warning', '', 0);
                return;                        
            }
            else {
                $("#spanFechaSuscMinutPropuestaGeneral")[0].innerText = fechaSuscripcion;
                $("#spanIdTipoPropuestaGeneral")[0].innerText = id_tipopropuesta;
                $("#spanidpropuesta_entidadPropuestaGeneral")[0].innerText = idpropuesta_entidad;
                $("#spanpropuesta_entidadPropuestaGeneral")[0].innerText = entidad;
                $("#spantipopropuestaPropuestaGeneral")[0].innerText = tipopropuesta;
    
                if (!ExisteDivEdicionDatos('dvProyectoExtensionDetallePropuesta')) {
                    CrearDivEdicionDatos('/Pages/proyectoextension/detalle_ProyectoExtensionPropuesta.html', 'dvProyectoExtensionDetallePropuesta');
                }
                else {
                    CrearProyectos_AsignacionProyectoDesdePropuestaForm();
                }
           
                return;
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
          });             
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );       
        


}