var DataTableProyectoExtension = null;

$(document).ready(function () {
    LoadDataTableProyectoExtension(); 
        
});


function LoadDataTableProyectoExtension() {
    DataTableProyectoExtension = $('#tblProyectoExtension').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,        
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_AsignacionProyecto/GetDataTableProyectos_AsignacionProyecto"
        },      
        "columns": [                    
            { "data": "id_asignacionproyecto", "orderable": true },
            { "data": "consecutivo", "orderable": true },
            { "data": "numcontratoconvenio", "orderable": true },            
            { "data": "yearsuscripcion", "orderable": true, render: function (data, type, row, meta) {return row.yearsuscripcion.slice(0,4)} },
            { "data": "nmproyectodt", "orderable": true },
            { "data": "nombreentidad", "orderable": false },
            { "data": "fichaquipu", "orderable": true },
            { "data": "codigohermes", "orderable": true },
            { "data": "fecacuerdovoluntades", "orderable": false, render: function (data, type, row, meta) {return row.fecacuerdovoluntades.slice(0,10)}  },
            { "data": "fecterminacion", "orderable": false, render: function (data, type, row, meta) {return row.fecterminacion.slice(0,10)}  },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/bell.png" class="cambiarMouse opciondatatable" title="Notificación Seguimiento" onclick="CrearNotificacionSeguimientoUsuario(`PROYECTO EXTENSIÓN`,`' + row.consecutivo + '`);" data-bs-toggle="modal" data-bs-target="#ModalGenerarAlertaUsuario" /> ' +
                           '<img src="../images/iris/task.png" class="cambiarMouse opciondatatable" title="Tareas" onclick="TareasProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`);" /> ' +
                        '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="EditarProyectoExtension(' + row.id_asignacionproyecto + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +                            
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ModificacionMinutaProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`,'+ row.id_propuesta + ');"><img src="../images/iris/modificar.png">   Modificaciones Minuta</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ModificacionGarantiaProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`,'+ row.id_propuesta + ');"><img src="../images/iris/acuerdo.png">   Modificaciones Garantía</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ObligacionesProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/seguimiento.png">   Obligaciones Proyecto</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ObservacionesProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/minuta.png">   Observaciones Proyecto</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ProductosProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/modificar.png">   Productos Proyecto</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="FinancieroProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/seguro.png">   Control Financiero</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="AcuerdosProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/acuerdo.png">   Acuerdos Interfic</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ProfesoresProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/modi-seguro.png">   Profesores</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="LiquidacionFinalizacionProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`,'+ row.id_propuesta + ',`' + row.fecacuerdovoluntades.slice(0,10) + '`,`' + row.fecterminacion.slice(0,10) + '`);"><img src="../images/iris/projectclose.png">   Liquidación</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarProyectoExtension(' + row.id_asignacionproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`);"><img src="../images/iris/Eliminar.png">   Eliminar Proyecto</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
            
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nombreproyecto + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtension() {
    DataTableProyectoExtension.ajax.reload(null, false);
}

function ValidarEliminarProyectoExtension(idProyecto, consecutivo, contrato) {
    ShowDialogConfirmacion('','Seguro de eliminar proyecto con consecutivo ' + consecutivo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectoExtension(idProyecto);
            }
        });
}

function EliminarProyectoExtension(idProyecto) {
    let urlEliminar = urlController + "Proyectos_AsignacionProyecto/DeleteProyectos_AsignacionProyecto?id_asignacionproyecto=" + idProyecto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtension();
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

function CrearProyectoExtension() {
    $("#spanIdProyectoExtension")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvProyectoExtensionDetalle')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/detalle_ProyectoExtension.html', 'dvProyectoExtensionDetalle');
    }
    else {
        CrearProyectoExtensionform();
    }

}

function EditarProyectoExtension(idproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = idproyecto;

    if (!ExisteDivEdicionDatos('dvProyectoExtensionDetalle')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/detalle_ProyectoExtension.html', 'dvProyectoExtensionDetalle');
    }
    else {
        EditarProyectoExtensionform(idproyecto);        
    }
}

function ObligacionesProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionTablaObligaciones')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/proyectoextensiontablaobligaciones.html', 'dvProyectoExtensionTablaObligaciones');
    }
    else {
        InicializaObligacionesProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto);
    }
}


function ObservacionesProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionTablaObservaciones')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/proyectoextensiontablaobservaciones.html', 'dvProyectoExtensionTablaObservaciones');
    }
    else {
        InicializaObservacionesProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto);
    }
}

function ProductosProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionTablaProductos')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/proyectoextensiontablaproductos.html', 'dvProyectoExtensionTablaProductos');
    }
    else {
        InicializaProductosProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto);
    }
}


function ProfesoresProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionTablaProfesores')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/proyectoextensiontablaprofesores.html', 'dvProyectoExtensionTablaProfesores');
    }
    else {
        InicializaProfesoresProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto);
    }
}


function FinancieroProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionTablaFinanciero')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/proyectoextensioncontrolfinanciero.html', 'dvProyectoExtensionTablaFinanciero');
    }
    else {
        InicializaFinancieroProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto);
    }

}

function AcuerdosProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionTablaAcuerdos')) {
        CrearDivEdicionDatos('/Pages/ProyectoExtension/proyectoextensiontablaacuerdos.html', 'dvProyectoExtensionTablaAcuerdos');
    }
    else {
        InicializaAcuerdosProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto);
    }

}


function TareasProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionTareas')) {
        CrearDivEdicionDatos('/Pages/tareas/proyectoextension_tareas.html', 'dvProyectoExtensionTareas');
    }
    else {
        InicializaProyectoExtensionTareasform();
    }

}

function ModificacionMinutaProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto, id_propuesta) {
    if (id_propuesta == null) {
        ShowModalDialog('Proyecto no tiene Id de propuesta asociado', false, 'warning', '', 0);
        return;
    }

    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    
    $("#spanid_propuestaProyectoExtension")[0].innerText = id_propuesta;  

    let urlMinuta = urlController + "Propuesta_SuscripcionMinuta/GetPropuesta_SuscripcionMinutaByPropuesta?idpropuesta=" + id_propuesta;

    fetch(urlMinuta, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;                        
            $("#spanId_suscripcionminutaProyectoExtension")[0].innerText = datos.id_suscripcionminuta;

            FinalizeLoader();

            if (!ExisteDivEdicionDatos('dvProyectoExtensionModificacionMinuta')) {
                CrearDivEdicionDatos('/Pages/proyectoextension/proyectoextension_modificacionminuta.html', 'dvProyectoExtensionModificacionMinuta');
            }
            else {
                InicializaProyectoExtensionModificaMinutaform();
            }
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

function ModificacionGarantiaProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto, id_propuesta) {
    if (id_propuesta == null) {
        ShowModalDialog('Proyecto no tiene Id de propuesta asociado', false, 'warning', '', 0);
        return;
    }

    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    
    $("#spanid_propuestaProyectoExtension")[0].innerText = id_propuesta;  
    
    let urlGarantia = urlController + "Propuesta_SuscripcionGarantia/GetPropuesta_SuscripcionGarantiaByPropuesta?idpropuesta=" + id_propuesta;    

    fetch(urlGarantia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                           
            let datos = data.Data;                        
            $("#spanId_suscripciongarantiaProyectoExtension")[0].innerText = datos.id_suscripciongarantia;

            FinalizeLoader();

            if (!ExisteDivEdicionDatos('dvProyectoExtensionModificacionGarantia')) {
                CrearDivEdicionDatos('/Pages/proyectoextension/proyectoextension_modificaciongarantia.html', 'dvProyectoExtensionModificacionGarantia');
            }
            else {
                InicializaProyectoExtensionModificacionGarantiaform();
            }
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

function LiquidacionFinalizacionProyectoExtension(id_asignacionproyecto, consecutivo, contrato, nombreproyecto, id_propuesta, fechainicio, fechafin) {
    if (id_propuesta == null) {
        ShowModalDialog('Proyecto no tiene Id de propuesta asociado', false, 'warning', '', 0);
        return;
    }

    $("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;
    $("#spanConsecutivoProyectoExtension")[0].innerText = consecutivo;
    $("#spanContratoProyectoExtension")[0].innerText = contrato;
    $("#spanNombreProyectoExtension")[0].innerText = nombreproyecto;    
    $("#spanid_propuestaProyectoExtension")[0].innerText = id_propuesta;  
    $("#spanFechaInicioProyectoExtension")[0].innerText = fechainicio;  
    $("#spanFechaFinalizaProyectoExtension")[0].innerText = fechafin;  
    
    if (!ExisteDivEdicionDatos('dvProyectoExtensionLiquidacionFinalizacion')) {
        CrearDivEdicionDatos('/Pages/proyectoExtension/proyectoextension_liquidacionfinalizacion.html', 'dvProyectoExtensionLiquidacionFinalizacion');
    }
    else {
        InicializaProyectoExtensionLiquidacionform();
    }

}