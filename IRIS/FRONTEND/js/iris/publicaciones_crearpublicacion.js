var DataTablePublicaciones = null;

$(document).ready(function () {
    LoadDataTablePublicaciones(); 
        
});


function LoadDataTablePublicaciones() {
    DataTablePublicaciones = $('#tblPublicaciones').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_CrearPublicacion/GetDataTablePublicaciones"
        },      
        "columns": [                    
            { "data": "id_kardex", "orderable": true },
            { "data": "TituloDt", "orderable": true },
            { "data": "fecregmanuscrito", "orderable": true, render: function (data, type, row, meta) {return row.fecregmanuscrito.slice(0,10)} },
            { "data": "Responsable", "orderable": false },  
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/bell.png" class="cambiarMouse opciondatatable" title="Notificación Seguimiento" onclick="CrearNotificacionSeguimientoUsuario(`PUBLICACIÓN`,`' + row.id_kardex + '`);" data-bs-toggle="modal" data-bs-target="#ModalGenerarAlertaUsuario" /> ' +
                           '<img src="../images/iris/task.png" class="cambiarMouse opciondatatable" title="Tareas" onclick="TareasPublicacion(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);" /> ' +
                        '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="EditarPublicacion(' + row.id_crearpublicacion + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +                            
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="AutoresPublicacion(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/modi-seguro.png">   Autores</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ConceptoEditorialPublicacion(' + row.id_crearpublicacion + ')"><img src="../images/iris/conceptoeditorial.png">   Concepto Editorial</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionEvaluacion(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/evaluacion.png">   Evaluación</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionCesionDerechos(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/checklist.png">   Cesión Derechos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionCorreccion(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/correcto.png">   Correcciones</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionDiagramacion(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/layout.png">   Edición</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionImpresionDigitalizacion(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/print.png">   Impresión/Digitalización</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionDepositosVentas(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/money.png">   Depositos/Ventas</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionControlFinanciero(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/seguro.png">   Control Financiero</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionDivulgacion(' + row.id_crearpublicacion + ',`' + row.id_kardex + '`,`' + row.hermesidmanuscrito + '`,`' + row.titulomanuscrito + '`);"><img src="../images/iris/divulgacion.png">   Divulgación</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarPublicacion(' + row.id_crearpublicacion + ')"><img src="../images/iris/Eliminar.png">   Eliminar Publicación</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
        ],         
        "columnDefs": [
            { "targets": 1,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.titulomanuscrito + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones() {
    DataTablePublicaciones.ajax.reload(null, false);
}

function ValidarEliminarPublicacion(idPublicacion, idkardex, consecutivo) {
    ShowDialogConfirmacion('','Seguro de eliminar publicación' + idkardex + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicacion(idPublicacion);
            }
        });
}

function EliminarPublicacion(idPublicacion) {
    let urlEliminar = urlController + "Publicaciones_CrearPublicacion/DeletePublicaciones_CrearPublicacion?id_crearpublicacion=" + idPublicacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones();
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


function CrearPublicacion() {
    $("#spanIdPublicacion")[0].innerText = '';

    if (!ExisteDivEdicionPublicaciones()) {
        CrearDivEdicionPublicaciones();
    }
    else {
        CrearPublicacionform();
    }

}

function ExisteDivEdicionPublicaciones() {
    let divedicion = document.getElementById('dvPublicacionDetalle').innerHTML;

    if (divedicion == null || divedicion == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivEdicionPublicaciones() {
    let urledit = '/Pages/publicacion/detalle_publicacion.html'; 

    $.get(urledit, function (htmlexterno) {
        $('#dvPublicacionDetalle').html(htmlexterno);
    });    

}

function EditarPublicacion(idPublicacion) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;

    if (!ExisteDivEdicionPublicaciones()) {
        CrearDivEdicionPublicaciones();
    }
    else {
        EditarPublicacionform(idPublicacion);
    }

}

function ExisteDivGestionarPublicacion(idDiv) {
    let divedicion = document.getElementById(idDiv).innerHTML.trim();

    if (divedicion == null || divedicion == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivGestionarPublicacion(paginaload, idDiv) {
    //let urledit = '/Pages/publicacion/detalle_publicacion.html'; 

    $.get(paginaload, function (htmlexterno) {
        $('#' + idDiv).html(htmlexterno);
    });    
}

function ConceptoEditorialPublicacion(idPublicacion) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;

    if (!ExisteDivGestionarPublicacion('dvPublicacionConceptoEditorial')) {
        CrearDivGestionarPublicacion('/Pages/publicacion/conceptoeditorial_publicacion.html', 'dvPublicacionConceptoEditorial');
    }
    else {
        PublicacionConceptoEditorialForm(idPublicacion);
    }

}

function AutoresPublicacion(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    


    if (!ExisteDivGestionarPublicacion('dvPublicacionTablaAutores')) {
        CrearDivGestionarPublicacion('/Pages/publicacion/autores_publicacion.html', 'dvPublicacionTablaAutores');
    }
    else {
        InicializaPublicaciones_Autoresform(idPublicacion, idkardex, idhermes, nombre);
    }

}


function PublicacionEvaluacion(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    


    if (!ExisteDivGestionarPublicacion('dvPublicacionEvaluacion')) {
        CrearDivGestionarPublicacion('/Pages/publicacion/publicaciones_evaluacion.html', 'dvPublicacionEvaluacion');
    }
    else {
        InicializaPublicacionEvaluacionform(idPublicacion, idkardex, idhermes, nombre);
    }

}

function PublicacionCesionDerechos(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    


    if (!ExisteDivGestionarPublicacion('dvPublicacionCesionDerechos')) {
        CrearDivGestionarPublicacion('/Pages/publicacion/publicacionPUBEDIT_CesionDerechos.html', 'dvPublicacionCesionDerechos');
    }
    else {
        EditarPublicacionEdicionesCesionDerechosForm();
    }
}

function PublicacionCorreccion(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    


    if (!ExisteDivEdicionDatos('dvPublicacionCorreccion')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_correcion.html', 'dvPublicacionCorreccion');
    }
    else {
        InicializaPublicacionCorreccionform(idPublicacion, idkardex, idhermes, nombre);
    }

}

function PublicacionDiagramacion(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    


    if (!ExisteDivEdicionDatos('dvPublicacionDiagramacion')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_diagramacion.html', 'dvPublicacionDiagramacion');
    }
    else {
        InicializaPublicacionDiagramacionform(idPublicacion, idkardex, idhermes, nombre);
    }
}

function PublicacionImpresionDigitalizacion(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    


    if (!ExisteDivEdicionDatos('dvPublicacionImpresionDigitalizacion')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_impresiondigitalizacion.html', 'dvPublicacionImpresionDigitalizacion');
    }
    else {
        InicializaPublicacionImpresionDigitalizacionform(idPublicacion, idkardex, idhermes, nombre);
    }
}

function PublicacionDepositosVentas(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    

    if (!ExisteDivEdicionDatos('dvPublicacionDepositosVentas')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_depositosventas.html', 'dvPublicacionDepositosVentas');
    }
    else {
        InicializaPublicacionDepositosVentasform(idPublicacion, idkardex, idhermes, nombre);
    }

}

function PublicacionControlFinanciero(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    

    if (!ExisteDivEdicionDatos('dvPublicacionTablaFinanciero')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_controlfinanciero.html', 'dvPublicacionTablaFinanciero');
    }
    else {
        InicializaFinancieroPublicacionform();
    }
}

function PublicacionDivulgacion(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    


    if (!ExisteDivEdicionDatos('dvPublicacionDivulgacion')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_divulgacion.html', 'dvPublicacionDivulgacion');
    }
    else {
        InicializaPublicacionDivulgacionform(idPublicacion, idkardex, idhermes, nombre);
    }

}

function TareasPublicacion(idPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicacion")[0].innerText = idPublicacion;    
    $("#spanKardexPublicacion")[0].innerText = idkardex;
    $("#spanHermesPublicacion")[0].innerText = idhermes;
    $("#spanNombrePublicacion")[0].innerText = nombre;    

    if (!ExisteDivEdicionDatos('dvPublicacionTareas')) {
        CrearDivEdicionDatos('/Pages/tareas/publicacion_tareas.html', 'dvPublicacionTareas');
    }
    else {
        InicializaPublicacionTareasform();
    }


}