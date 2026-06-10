var DataTableHermesProyectoExtension = null;

$(document).ready(function () {
    LoadDataTableHermesProyectoExtension(); 
        
});

function LoadDataTableHermesProyectoExtension() {
    DataTableHermesProyectoExtension = $('#tblHermesProyectoExtension').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "HermesProyectoExtension/GetDataTableHermesProyectoExtension"
        },      
        "columns": [            
            { "data": "id_hermes", "orderable": true },
            { "data": "codigo_quipu", "orderable": true },
            { "data": "nombreproyectodt", "orderable": false },
            { "data": "estado", "orderable": true },            
            { "data": "convocatoriadt", "orderable": false},                       
            /* {
                render: function (data, type, row, meta) {
                    return '<div class=" dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="EditarHermesProyectoExtension(' + row.id_hermes + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="HermesProyectoExtensionGastoApoyo(' + row.id_HermesProyectoExtension + ',' + row.id_vigencia + ',`' + row.NombreVigencia +'`,' + row.IdDependenciaUsuarioLogueado + ',`' + row.NombreDependencia +'`);"><img src="../images/iris/seguimiento.png">Gastos Apoyo</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="HermesProyectoExtensionGastoOperativo(' + row.id_HermesProyectoExtension + ',' + row.id_vigencia + ',`' + row.NombreVigencia +'`,' + row.IdDependenciaUsuarioLogueado + ',`' + row.NombreDependencia +'`);"><img src="../images/iris/minuta.png">Gastos Operativos</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="HermesProyectoExtensionExel(' + row.id_HermesProyectoExtension + ');"><img src="../images/iris/excel.png">Exportar Excel</> </li>' +
//                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarHermesProyectoExtension(' + row.id_HermesProyectoExtension + ');"><img src="../images/iris/Eliminar.png">Eliminar HermesProyectoExtension</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            }  */
                       
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nombre_proyecto + '">' + data : data;} 
            },
            { "targets": 4,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nombre_convocatoria + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableHermesProyectoExtension() {
    DataTableHermesProyectoExtension.ajax.reload(null, false);
}

/*
function ValidarEliminarHermesProyectoExtension(idHermesProyectoExtension) {
    ShowDialogConfirmacion('','Seguro de eliminar la Matriz Financiera seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarHermesProyectoExtension(idHermesProyectoExtension);
            }
        });
}

function EliminarHermesProyectoExtension(idHermesProyectoExtension) {
    let urlEliminar = urlController + "HermesProyectoExtension/DeleteHermesProyectoExtension?id_HermesProyectoExtension=" + idHermesProyectoExtension;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableHermesProyectoExtension();
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

function CargarHermesProyectoExtension() {
    let urlDatos = urlController + "HermesProyectoExtension/CargarHermesProyectoExtension";
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
            RefreshDataTableHermesProyectoExtension();
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

function EditarHermesProyectoExtension(id_HermesProyectoExtension) {
    $("#spanIdHermesProyectoExtension")[0].innerText = id_HermesProyectoExtension;
    
    if (!ExisteDivEdicionDatos('dvHermesProyectoExtensionDetalle')) {
        CrearDivEdicionDatos('/Pages/Decanatura/HermesProyectoExtensionDetalle.html', 'dvHermesProyectoExtensionDetalle');
    }
    else {
        EditarHermesProyectoExtensionform(id_HermesProyectoExtension);
    }

}


function HermesProyectoExtensionExel(idHermesProyectoExtension,) {
    debugger;
    $("#spanIdHermesProyectoExtension")[0].innerText = idHermesProyectoExtension;   

    let urlExcel = urlController + "HermesProyectoExtension/ExcelHermesProyectoExtension?id_HermesProyectoExtension=" + idHermesProyectoExtension;
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
