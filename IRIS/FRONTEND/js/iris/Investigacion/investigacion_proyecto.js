var DataTableProyectoInvestigacion = null;

$(document).ready(function () {
    LoadDataTableProyectoInvestigacion();

});


function LoadDataTableProyectoInvestigacion() {
    DataTableProyectoInvestigacion = $('#tblProyectoInvestigacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_CrearProyecto/GetDataTableInvestigacion_CrearProyecto"
        },
        "columns": [
            { "data": "id_crearproyecto", "orderable": true },
            { "data": "codigohermes", "orderable": true },
            { "data": "nmproyectodt", "orderable": true },
            { "data": "empresa", "orderable": true },
            { "data": "NombreNaturaleza", "orderable": false },
            { "data": "quipu", "orderable": true },
            { "data": "NombreDirector", "orderable": false },
            { "data": "fechainicio", "orderable": true, render: function (data, type, row, meta) { return row.fechainicio.slice(0, 10) } },
            { "data": "fechaentrega", "orderable": true, render: function (data, type, row, meta) { return row.fechaentrega.slice(0, 10) } },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/bell.png" class="cambiarMouse opciondatatable" title="Notificación Seguimiento" onclick="CrearNotificacionSeguimientoUsuario(`PROYECTO INVESTIGACION`,`' + row.codigohermes + '`);" data-bs-toggle="modal" data-bs-target="#ModalGenerarAlertaUsuario" /> ' +
                        '<img src="../images/iris/task.png" class="cambiarMouse opciondatatable" title="Tareas" onclick="TareasProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`);" /> ' +
                        '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                        '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="EditarProyectoInvestigacion(' + row.id_crearproyecto + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +
                        //SE añade nuevo  
                        '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="NuevaResolución(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`)"><img src="../images/iris/Editar.png">   Añadir Resolución</> </li>' +
                        // '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ModificacionMinutaProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`,'+ row.id_propuesta + ');"><img src="../images/iris/modificar.png">   Modificaciones Minuta</> </li>' +
                        // '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ModificacionGarantiaProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.consecutivo + '`,`' + row.numcontratoconvenio + '`,`' + row.nombreproyecto + '`,'+ row.id_propuesta + ');"><img src="../images/iris/acuerdo.png">   Modificaciones Garantía</> </li>' + 
                        '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ObligacionesProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/seguimiento.png">   Obligaciones Proyecto</> </li>' +
                        '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ObservacionesProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/minuta.png">   Observaciones Proyecto</> </li>' +
                        '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ProductosProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/modificar.png">   Productos Proyecto</> </li>' +
                        '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="FinancieroProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/seguro.png">   Control Financiero</> </li>' +
                        //'<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="AcuerdosProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/acuerdo.png">   Acuerdos Interfic</> </li>' +
                        //'<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ProfesoresProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`);"><img src="../images/iris/modi-seguro.png">   Profesores</> </li>' +
                        //'<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="LiquidacionFinalizacionProyectoInvestigacion(' + row.id_crearproyecto + ',`' + row.codigohermes + '`,`' + row.quipu + '`,`' + row.nombreproyecto + '`,'+ row.id_propuesta + ');"><img src="../images/iris/projectclose.png">   Liquidación</> </li>' +
                        '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarProyectoInvestigacion(' + row.id_crearproyecto + ');"><img src="../images/iris/Eliminar.png">   Eliminar Proyecto</> </li>' +
                        '</ul>' +
                        '</div>';
                },
                "className": "text-center", "orderable": false
            }

        ],
        "columnDefs": [
            {
                "targets": 2,
                render: function (data, type, full, meta) { return type === 'display' ? '<div title="' + full.nombreproyecto + '">' + data : data; }
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });
}


    function NuevaResolución(idproyecto, hermes, quipu, nombreproyecto) {
        $("#spanIdProyectoInvestigacion")[0].innerText = idproyecto;
        $("#spanHermesProyectoInvestigacion")[0].innerText = hermes;
        $("#spanQuipuProyectoInvestigacion")[0].innerText = quipu;
        $("#spanNombreProyectoInvestigacion")[0].innerText = nombreproyecto;

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionTablaResoluciones')) {
            CrearDivEdicionDatos('/Pages/investigacion/proyectoinvestigaciontablaresoluciones.html', 'dvProyectoInvestigacionTablaResoluciones');
        }
        else {
            InicializaProyectoInvestigacionResolucionesform();
        }
    }

    function RefreshDataTableProyectoInvestigacion() {
        DataTableProyectoInvestigacion.ajax.reload(null, false);
    }

    function ValidarEliminarProyectoInvestigacion(idProyecto) {
        ShowDialogConfirmacion('', 'Seguro de eliminar proyecto ?', 'Sí, eliminar', 'No, cancelar')
            .then(borrar => {
                if (borrar) {
                    EliminarProyectoInvestigacion(idProyecto);
                }
            });
    }

    function EliminarProyectoInvestigacion(idProyecto) {
        let urlEliminar = urlController + "Investigacion_CrearProyecto/DeleteInvestigacion_CrearProyecto?id_crearproyecto=" + idProyecto;
        StartLoader();

        fetch(urlEliminar, {
            method: 'DELETE',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
            .then(response => response.json())
            .then(data => {
                if (data.Ok) {
                    FinalizeLoader();
                    RefreshDataTableProyectoInvestigacion();
                    return;
                }
                else {
                    FinalizeLoader();
                    ShowModalDialog(data.Message, false, 'warning', '', 0);
                    return;
                }
            })
            .catch(err => {
                ShowModalDialog(err, false, 'error', '', 0);
            });

    }

    function CrearProyectoInvestigacion() {
        $("#spanIdProyectoInvestigacion")[0].innerText = '';

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionDetalle')) {
            CrearDivEdicionDatos('/Pages/investigacion/detalle_ProyectoInvestigacion.html', 'dvProyectoInvestigacionDetalle');
        }
        else {
            CrearInvestigacion_CrearProyectoform();
        }

    }

    function EditarProyectoInvestigacion(idproyecto) {
        $("#spanIdProyectoInvestigacion")[0].innerText = idproyecto;

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionDetalle')) {
            CrearDivEdicionDatos('/Pages/investigacion/detalle_proyectoinvestigacion.html', 'dvProyectoInvestigacionDetalle');
        }
        else {
            EditarInvestigacion_CrearProyectoform();
        }
    }


    function ObligacionesProyectoInvestigacion(idproyecto, hermes, quipu, nombreproyecto) {
        $("#spanIdProyectoInvestigacion")[0].innerText = idproyecto;
        $("#spanHermesProyectoInvestigacion")[0].innerText = hermes;
        $("#spanQuipuProyectoInvestigacion")[0].innerText = quipu;
        $("#spanNombreProyectoInvestigacion")[0].innerText = nombreproyecto;

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionTablaObligaciones')) {
            CrearDivEdicionDatos('/Pages/investigacion/proyectoinvestigaciontablaobligaciones.html', 'dvProyectoInvestigacionTablaObligaciones');
        }
        else {
            InicializaProyectoInvestigacionObligacionesform();
        }
    }

    function ObservacionesProyectoInvestigacion(idproyecto, hermes, quipu, nombreproyecto) {
        $("#spanIdProyectoInvestigacion")[0].innerText = idproyecto;
        $("#spanHermesProyectoInvestigacion")[0].innerText = hermes;
        $("#spanQuipuProyectoInvestigacion")[0].innerText = quipu;
        $("#spanNombreProyectoInvestigacion")[0].innerText = nombreproyecto;

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionTablaObservaciones')) {
            CrearDivEdicionDatos('/Pages/investigacion/proyectoinvestigaciontablaobservaciones.html', 'dvProyectoInvestigacionTablaObservaciones');
        }
        else {
            InicializaProyectoInvestigacionObservacionesform();
        }
    }


    function ProductosProyectoInvestigacion(idproyecto, hermes, quipu, nombreproyecto) {
        $("#spanIdProyectoInvestigacion")[0].innerText = idproyecto;
        $("#spanHermesProyectoInvestigacion")[0].innerText = hermes;
        $("#spanQuipuProyectoInvestigacion")[0].innerText = quipu;
        $("#spanNombreProyectoInvestigacion")[0].innerText = nombreproyecto;

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionTablaProductos')) {
            CrearDivEdicionDatos('/Pages/investigacion/proyectoinvestigaciontablaproductos.html', 'dvProyectoInvestigacionTablaProductos');
        }
        else {
            InicializaProyectoInvestigacionProductosform();
        }
    }

    function FinancieroProyectoInvestigacion(idproyecto, hermes, quipu, nombreproyecto) {
        debugger;
        $("#spanIdProyectoInvestigacion")[0].innerText = idproyecto;
        $("#spanHermesProyectoInvestigacion")[0].innerText = hermes;
        $("#spanQuipuProyectoInvestigacion")[0].innerText = quipu;
        $("#spanNombreProyectoInvestigacion")[0].innerText = nombreproyecto;

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionTablaFinanciero')) {
            CrearDivEdicionDatos('/Pages/investigacion/proyectoinvestigacioncontrolfinanciero.html', 'dvProyectoInvestigacionTablaFinanciero');
        }
        else {
            InicializaFinancieroProyectoInvestigacionform();
        }
    }

    function TareasProyectoInvestigacion(idproyecto, hermes, quipu, nombreproyecto) {
        $("#spanIdProyectoInvestigacion")[0].innerText = idproyecto;
        $("#spanHermesProyectoInvestigacion")[0].innerText = hermes;
        $("#spanQuipuProyectoInvestigacion")[0].innerText = quipu;
        $("#spanNombreProyectoInvestigacion")[0].innerText = nombreproyecto;

        if (!ExisteDivEdicionDatos('dvProyectoInvestigacionTablaTareas')) {
            CrearDivEdicionDatos('/Pages/tareas/proyectoinvestigacion_tareas.html', 'dvProyectoInvestigacionTablaTareas');
        }
        else {
            InicializaProyectoInvestigacionTareasform();
        }
    }