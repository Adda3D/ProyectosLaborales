var DataTableDecvie_CicloFinanciero = null;


$(document).ready(function () {
    LoadDataTableDecvie_CicloFinanciero(); 
        
});

function LoadDataTableDecvie_CicloFinanciero() {    
    DataTableDecvie_CicloFinanciero = $('#tblDecvie_CicloFinanciero').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Decvie_CicloFinanciero/GetDataTableDecvie_CicloFinanciero"
        },      
        "columns": [                    
            { "data": "id_ciclofinanciero", "orderable": true },
            { "data": "NombreSemestre", "orderable": false },
            { "data": "observaciones", "orderable": false },
            {                
                
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +                         
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ProgramasCicloFinanciero(' + row.id_ciclofinanciero + ',' + row.id_semestre + ',`' + row.NombreSemestre + '`);"><img src="../images/iris/seguimiento.png">Programas</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="CicloFinancieroPosgradoExcel(' + row.id_ciclofinanciero + ',' + row.id_semestre + ',`' + row.NombreSemestre + '`);"><img src="../images/iris/excel.png">Exportar Excel</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarDecvie_CicloFinanciero(' + row.id_ciclofinanciero + ',`' + row.id_semestre + '`,`' + row.NombreSemestre + '`);"><img src="../images/iris/Eliminar.png">   Eliminar Ciclo Financiero</> </li>' + 
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
                
            } 
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreSemestre + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_CicloFinanciero() {
    DataTableDecvie_CicloFinanciero.ajax.reload(null, false);
}

function ValidarEliminarDecvie_CicloFinanciero(idciclofinanciero) {
    ShowDialogConfirmacion('','Seguro de eliminar el Ciclo Financiero seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_CicloFinanciero(idciclofinanciero);
            }
        });
}

function EliminarDecvie_CicloFinanciero(idciclofinanciero) {
    let urlEliminar = urlController + "Decvie_CicloFinanciero/DeleteDecvie_CicloFinanciero?id_ciclofinanciero=" + idciclofinanciero;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_CicloFinanciero();
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

function CrearDecvie_CicloFinanciero() {
    $("#spanIdDecvie_CicloFinanciero")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecvie_CicloFinancieroDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_CicloFinancieroDetalle.html', 'dvDecvie_CicloFinancieroDetalle');
    }
    else {
        CrearDecvie_CicloFinancieroform();
    }
}

function EditarDecvie_CicloFinanciero(idciclofinanciero) {
    $("#spanIdDecvie_CicloFinanciero")[0].innerText = idciclofinanciero;
    
    if (!ExisteDivEdicionDatos('dvDecvie_CicloFinancieroDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_CicloFinancieroDetalle.html', 'dvDecvie_CicloFinancieroDetalle');
    }
    else {
        EditarDecvie_CicloFinanciero(idciclofinanciero);
    }

}

function ProgramasCicloFinanciero (idciclofinanciero,id_semestre, NombreSemestre) {
    debugger;
    $("#spanIdDecvie_CicloFinanciero")[0].innerText = idciclofinanciero;
    $("#spanIDSemestreDecvie_CicloFinanciero")[0].innerText = id_semestre;
    $("#spanNombreSemestreDecvie_CicloFinanciero")[0].innerText = NombreSemestre;

    if (!ExisteDivEdicionDatos('dvDecvie_CicloFinancieroProgramas')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_CicloFinancieroProgramas.html', 'dvDecvie_CicloFinancieroProgramas');
    }
    else {
        InicializaDecVie_CicloFinancieroPostProgramform(idciclofinanciero, id_semestre, NombreSemestre);
    }

    
}

function CicloFinancieroPosgradoExcel(idciclofinanciero,id_semestre, NombreSemestre) {
    debugger;
    $("#spanIdDecvie_CicloFinanciero")[0].innerText = idciclofinanciero;
    $("#spanIDSemestreDecvie_CicloFinanciero")[0].innerText = id_semestre;
    $("#spanNombreSemestreDecvie_CicloFinanciero")[0].innerText = NombreSemestre;

    let urlExcel = urlController + "Decvie_CicloFinanciero/ExcelDecvie_CicloFinanciero?id_ciclofinanciero=" + idciclofinanciero;
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