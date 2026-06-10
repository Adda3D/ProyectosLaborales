var DataTableHermesProyectoInvestigacion = null;

$(document).ready(function () {
    LoadDataTableHermesProyectoInvestigacion(); 
        
});

function LoadDataTableHermesProyectoInvestigacion() {
    DataTableHermesProyectoInvestigacion = $('#tblHermesProyectoInvestigacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "HermesProyectoInvestigacion/GetDataTableHermesProyectoInvestigacion"
        },      
        "columns": [            
            { "data": "id_hermes", "orderable": true },
            { "data": "codigoquipu", "orderable": true },
            { "data": "nombreproyectodt", "orderable": false },
            { "data": "estadoactual", "orderable": true },            
            { "data": "convocatoriadt", "orderable": false},                       
            /* {
                render: function (data, type, row, meta) {
                    return '<div class=" dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="EditarHermesProyectoInvestigacion(' + row.id_hermes + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="HermesProyectoInvestigacionGastoApoyo(' + row.id_HermesProyectoInvestigacion + ',' + row.id_vigencia + ',`' + row.NombreVigencia +'`,' + row.IdDependenciaUsuarioLogueado + ',`' + row.NombreDependencia +'`);"><img src="../images/iris/seguimiento.png">Gastos Apoyo</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="HermesProyectoInvestigacionGastoOperativo(' + row.id_HermesProyectoInvestigacion + ',' + row.id_vigencia + ',`' + row.NombreVigencia +'`,' + row.IdDependenciaUsuarioLogueado + ',`' + row.NombreDependencia +'`);"><img src="../images/iris/minuta.png">Gastos Operativos</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="HermesProyectoInvestigacionExel(' + row.id_HermesProyectoInvestigacion + ');"><img src="../images/iris/excel.png">Exportar Excel</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarHermesProyectoInvestigacion(' + row.id_HermesProyectoInvestigacion + ');"><img src="../images/iris/Eliminar.png">Eliminar HermesProyectoInvestigacion</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            }  */
                       
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nombreproyecto + '">' + data : data;} 
            },
            { "targets": 4,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.convocatoria + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableHermesProyectoInvestigacion() {
    DataTableHermesProyectoInvestigacion.ajax.reload(null, false);
}

/*
function ValidarEliminarHermesProyectoInvestigacion(idHermesProyectoInvestigacion) {
    ShowDialogConfirmacion('','Seguro de eliminar la Matriz Financiera seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarHermesProyectoInvestigacion(idHermesProyectoInvestigacion);
            }
        });
}

function EliminarHermesProyectoInvestigacion(idHermesProyectoInvestigacion) {
    let urlEliminar = urlController + "HermesProyectoInvestigacion/DeleteHermesProyectoInvestigacion?id_HermesProyectoInvestigacion=" + idHermesProyectoInvestigacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableHermesProyectoInvestigacion();
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
*/

function CargarHermesProyectoInvestigacion() {
    let urlDatos = urlController + "HermesProyectoInvestigacion/CargarHermesProyectoInvestigacion";
    StartLoader();

    fetch(urlDatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            ShowModalDialog("Datos de proyectos cargados", false, 'success', '', 0);
            RefreshDataTableHermesProyectoInvestigacion();
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

function EditarHermesProyectoInvestigacion(id_HermesProyectoInvestigacion) {
    $("#spanIdHermesProyectoInvestigacion")[0].innerText = id_HermesProyectoInvestigacion;
    
    if (!ExisteDivEdicionDatos('dvHermesProyectoInvestigacionDetalle')) {
        CrearDivEdicionDatos('/Pages/Decanatura/HermesProyectoInvestigacionDetalle.html', 'dvHermesProyectoInvestigacionDetalle');
    }
    else {
        EditarHermesProyectoInvestigacionform(id_HermesProyectoInvestigacion);
    }

}


function HermesProyectoInvestigacionExel(idHermesProyectoInvestigacion,) {
    debugger;
    $("#spanIdHermesProyectoInvestigacion")[0].innerText = idHermesProyectoInvestigacion;   

    let urlExcel = urlController + "HermesProyectoInvestigacion/ExcelHermesProyectoInvestigacion?id_HermesProyectoInvestigacion=" + idHermesProyectoInvestigacion;
    StartLoader();

    fetch(urlExcel, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {      
            debugger;                 
            FinalizeLoader();
            location.href = urlDownload + data.Data;
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
