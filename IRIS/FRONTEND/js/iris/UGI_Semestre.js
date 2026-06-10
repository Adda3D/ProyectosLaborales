var DataTableUGI_Semestre = null;
var ObjModelUGI_LiteralSemestre = null;

$(document).ready(function () {
    LoadDataTableUGI_Semestre(); 
        
});

function LoadDataTableUGI_Semestre() {
    DataTableUGI_Semestre = $('#tblUGI_Semestre').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "UGI_Semestre/GetDataTableUGI_Semestre"
        },      
        "columns": [                    
            { "data": "id_ugisemestre", "orderable": true },
            { "data": "NombreSemestre", "orderable": false },
            { "data": "numresolucion", "orderable": true },
            { "data": "fecresolucion", "orderable": true, render: function (data, type, row, meta) {return row.fecresolucion.slice(0,10)} },
            { "data": "valortotalsemestre", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="VentanaUgisemestre_Literal(' + row.id_ugisemestre + ',' + row.id_semestre + ',`' + row.NombreSemestre + '`);"><img src="../images/iris/Editar.png">Literales</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="UGISemestreExcel(' + row.id_ugisemestre + ',' + row.id_semestre + ',`' + row.NombreSemestre + '`);"><img src="../images/iris/excel.png">Exportar Excel</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarUGI_Semestre(' + row.id_ugisemestre + ');"><img src="../images/iris/Eliminar.png">Eliminar Semestre</> </li>' +
                        '</ul>' +
                        '</div>';
                    /*return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarUGI_Semestre(' + row.id_ugisemestre + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarUGI_Semestre(' + row.id_ugisemestre + ');" /> ';*/
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.numresolucion + '">' + data : data;} 
            },
            { "targets": 4,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableUGI_Semestre() {
    DataTableUGI_Semestre.ajax.reload(null, false);
}

function ValidarEliminarUGI_Semestre(idugisemestre) {
    ShowDialogConfirmacion('','Seguro de eliminar la Ejecución seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarUGI_Semestre(idugisemestre);
            }
        });
}

function EliminarUGI_Semestre(idugisemestre) {
    let urlEliminar = urlController + "UGI_Semestre/DeleteUGI_Semestre?id_ugisemestre=" + idugisemestre;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableUGI_Semestre();
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

function CrearUGI_Semestre() {
    $("#spanIdUGI_Semestre")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvUGI_SemestreDetalle')) {
        CrearDivEdicionDatos('/Pages/Ugi/UGI_SemestreDetalle.html', 'dvUGI_SemestreDetalle');
    }
    else {
        CrearUGI_Semestreform();
    }
}

function EditarUGI_Semestre(idugisemestre) {
    $("#spanIdUGI_Semestre")[0].innerText = idugisemestre;
    
    if (!ExisteDivEdicionDatos('dvUGI_SemestreDetalle')) {
        CrearDivEdicionDatos('/Pages/Ugi/UGI_SemestreDetalle.html', 'dvUGI_SemestreDetalle');
    }
    else {
        EditarUGI_Semestreform(idugisemestre);
    }

}

function VentanaUgisemestre_Literal (id_ugisemestre, id_semestre, NombreSemestre) {
    $("#spanIdUGI_Semestre")[0].innerText = id_ugisemestre;
    $("#spanSemestreUGI_Semestre")[0].innerText = id_semestre; 
    $("#spanNombreSemestreUGI_Semestre")[0].innerText = NombreSemestre;   

    if (!ExisteDivEdicionDatos('dvUGI_LiteralSemestre')) {
        CrearDivEdicionDatos('/Pages/Ugi/UGI_LiteralSemestre.html', 'dvUGI_LiteralSemestre');
    }
    else {
        InicializaUGI_LiteralSemestreform();
    }

    
}
function UGISemestreExcel(id_ugisemestre,id_semestre, NombreSemestre) {
    debugger;
    $("#spanIdUGI_Semestre")[0].innerText = id_ugisemestre;
    $("#spanSemestreUGI_Semestre")[0].innerText = id_semestre; 
    $("#spanNombreSemestreUGI_Semestre")[0].innerText = NombreSemestre; 

    let urlExcel = urlController + "UGI_Semestre/ExcelUGI_Semestre?id_ugisemestre=" + id_ugisemestre;
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