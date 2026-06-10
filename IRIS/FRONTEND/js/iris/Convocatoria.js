var DataTableConvocatoria = null;

$(document).ready(function () {
    LoadDataTableConvocatoria(); 
        
});

function LoadDataTableConvocatoria() {
    DataTableConvocatoria = $('#tblConvocatoria').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Convocatoria/GetDataTableConvocatoria"
        },      
        "columns": [  
            { "data": "naturaleza", "orderable": true },
            { "data": "tituloconvocatoria", "orderable": true },            
            { "data": "fechaapertura", "orderable": false, render: function (data, type, row, meta) {return row.fechaapertura.slice(0,10)} },
            { "data": "fechacierre", "orderable": false, render: function (data, type, row, meta) {return row.fechacierre.slice(0,10)} },
            { "data": "NombreEstado", "orderable": false },
           
           
            /*
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarConvocatoria(' + row.id_convocatoria + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarConvocatoria(' + row.id_convocatoria + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
            */
            {
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="EditarConvocatoria(' + row.id_convocatoria + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ConvocatoriaRecursoParticipante(' + row.id_convocatoria + ',`' + row.tituloconvocatoria +'`);"><img src="../images/iris/seguimiento.png">Recursos por Participante</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ConvocatoriaRequerimientoRequisito(' + row.id_convocatoria + ',`' + row.tituloconvocatoria + '`);"><img src="../images/iris/minuta.png">Requisitos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ConvocatoriaInteresados(' + row.id_convocatoria + ',`' + row.tituloconvocatoria + '`);"><img src="../images/iris/minuta.png">Interesados</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarConvocatoria(' + row.id_convocatoria + ');"><img src="../images/iris/Eliminar.png">Eliminar Convocatoria</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
                       
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.tituloconvocatoria + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableConvocatoria() {
    DataTableConvocatoria.ajax.reload(null, false);
}

function ValidarEliminarConvocatoria(idconvocatoria) {
    ShowDialogConfirmacion('','Seguro de eliminar la Convocatoria seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConvocatoria(idconvocatoria);
            }
        });
}

function EliminarConvocatoria(idconvocatoria) {
    let urlEliminar = urlController + "Convocatoria/DeleteConvocatoria?id_convocatoria=" + idconvocatoria;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConvocatoria();
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

function CrearConvocatoria() {
    debugger;
    $("#spanIdConvocatoria")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvConvocatoriaDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/ConvocatoriaDetalle.html', 'dvConvocatoriaDetalle');
    }
    else {
        CrearConvocatoriaform();
    }
}

function EditarConvocatoria(idconvocatoria) {
    $("#spanIdConvocatoria")[0].innerText = idconvocatoria;
    
    if (!ExisteDivEdicionDatos('dvConvocatoriaDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/ConvocatoriaDetalle.html', 'dvConvocatoriaDetalle');
    }
    else {
        EditarConvocatoriaform(idconvocatoria);
    }

}

function ConvocatoriaRecursoParticipante(idconvocatoria, tituloconvocatoria,) {
    debugger;
    $("#spanIdConvocatoria")[0].innerText = idconvocatoria;
    $("#spanTituloConvocatoria")[0].innerText = tituloconvocatoria;
    
    if (!ExisteDivEdicionDatos('dvConvocatoria_RecursoParticipante')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_RecursoParticipante.html', 'dvConvocatoria_RecursoParticipante');
    }
    else {
        InicializaConvocatoria_RecursoParticipanteform(idconvocatoria, tituloconvocatoria,);
    }

    
}

function ConvocatoriaRequerimientoRequisito(idconvocatoria, tituloconvocatoria,) {
    debugger;
    $("#spanIdConvocatoria")[0].innerText = idconvocatoria;
    $("#spanTituloConvocatoria")[0].innerText = tituloconvocatoria;

    if (!ExisteDivEdicionDatos('dvConvocatoria_RequerimientoRequisito')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_RequerimientoRequisito.html', 'dvConvocatoria_RequerimientoRequisito');
    }
    else {
        InicializaConvocatoria_RequerimientoRequisitoform(idconvocatoria, tituloconvocatoria,);
    }

    
}

function ConvocatoriaInteresados(idconvocatoria, tituloconvocatoria,) {
    debugger;
    $("#spanIdConvocatoria")[0].innerText = idconvocatoria;
    $("#spanTituloConvocatoria")[0].innerText = tituloconvocatoria;

    if (!ExisteDivEdicionDatos('dvConvocatoria_Interesados')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_Interesados.html', 'dvConvocatoria_Interesados');
    }
    else {
        InicializaConvocatoria_Interesadosform(idconvocatoria, tituloconvocatoria,);
    }

    
}
