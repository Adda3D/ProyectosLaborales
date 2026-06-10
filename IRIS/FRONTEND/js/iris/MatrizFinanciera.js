var DataTableMatrizFinanciera = null;

$(document).ready(function () {
    LoadDataTableMatrizFinanciera(); 
        
});

function LoadDataTableMatrizFinanciera() {
    DataTableMatrizFinanciera = $('#tblMatrizFinanciera').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "MatrizFinanciera/GetDataTableMatrizFinanciera"
        },      
        "columns": [            
            { "data": "id_matrizfinanciera", "orderable": true },
            { "data": "NombreVigencia", "orderable": false },
            { "data": "presupuestogeneral", "orderable": false },
            { "data": "presupuestogeneralcomprometido", "orderable": false },            
            { "data": "presupuestogeneralcomprometer", "orderable": false},
            
           
           
            /*
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarMatrizFinanciera(' + row.id_matrizfinanciera + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarMatrizFinanciera(' + row.id_matrizfinanciera + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
            */
            {
                render: function (data, type, row, meta) {
                    return '<div class=" dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="EditarMatrizFinanciera(' + row.id_matrizfinanciera + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="MatrizFinancieraGastoApoyo(' + row.id_matrizfinanciera + ',' + row.id_vigencia + ',`' + row.NombreVigencia +'`);"><img src="../images/iris/seguimiento.png">Gastos Apoyo</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="MatrizFinancieraGastoOperativo(' + row.id_matrizfinanciera + ',' + row.id_vigencia + ',`' + row.NombreVigencia +'`);"><img src="../images/iris/minuta.png">Gastos Operativos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="MatrizFinancieraExel(' + row.id_matrizfinanciera + ');"><img src="../images/iris/excel.png">Exportar Excel</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarMatrizFinanciera(' + row.id_matrizfinanciera + ');"><img src="../images/iris/Eliminar.png">Eliminar MatrizFinanciera</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
                       
        ],         
        "columnDefs": [
            { "targets": 2,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            },
            { "targets": 3,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
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

function RefreshDataTableMatrizFinanciera() {
    DataTableMatrizFinanciera.ajax.reload(null, false);
}

function ValidarEliminarMatrizFinanciera(idmatrizfinanciera) {
    ShowDialogConfirmacion('','Seguro de eliminar la Matriz Financiera seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarMatrizFinanciera(idmatrizfinanciera);
            }
        });
}

function EliminarMatrizFinanciera(idmatrizfinanciera) {
    let urlEliminar = urlController + "MatrizFinanciera/DeleteMatrizFinanciera?id_matrizfinanciera=" + idmatrizfinanciera;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableMatrizFinanciera();
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

function CrearMatrizFinanciera() {
    debugger;
    $("#spanIdMatrizFinanciera")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvMatrizFinancieraDetalle')) {
        CrearDivEdicionDatos('/Pages/Decanatura/MatrizFinancieraDetalle.html', 'dvMatrizFinancieraDetalle');
    }
    else {
        CrearMatrizFinancieraform();
    }
}

function EditarMatrizFinanciera(id_matrizfinanciera) {
    $("#spanIdMatrizFinanciera")[0].innerText = id_matrizfinanciera;
    
    if (!ExisteDivEdicionDatos('dvMatrizFinancieraDetalle')) {
        CrearDivEdicionDatos('/Pages/Decanatura/MatrizFinancieraDetalle.html', 'dvMatrizFinancieraDetalle');
    }
    else {
        EditarMatrizFinancieraform(id_matrizfinanciera);
    }

}

function MatrizFinancieraGastoApoyo(id_matrizfinanciera, id_vigencia, NombreVigencia) {    
    $("#spanIdMatrizFinanciera")[0].innerText = id_matrizfinanciera;
    $("#spanIdVigenciaMatrizFinanciera")[0].innerText = id_vigencia;
    $("#spanNombreVigenciaMatrizFinanciera")[0].innerText = NombreVigencia;    
    
    
    if (!ExisteDivEdicionDatos('dvMatrizFinanciera_GastoApoyo')) {
        CrearDivEdicionDatos('/Pages/Decanatura/MatrizFinanciera_GastoApoyo.html', 'dvMatrizFinanciera_GastoApoyo');
    }
    else {
        InicializaMatrizFinanciera_GastoApoyoform(id_matrizfinanciera, id_vigencia, NombreVigencia);
    }

    
}

function MatrizFinancieraGastoOperativo(id_matrizfinanciera, id_vigencia, MatrizFinancieraVigencia) {
    debugger;
    $("#spanIdMatrizFinanciera")[0].innerText = id_matrizfinanciera;
    $("#spanIdVigenciaMatrizFinanciera")[0].innerText = id_vigencia;
    $("#spanNombreVigenciaMatrizFinanciera")[0].innerText = MatrizFinancieraVigencia;   
    

    if (!ExisteDivEdicionDatos('dvMatrizFinanciera_GastoOperativo')) {
        CrearDivEdicionDatos('/Pages/Decanatura/MatrizFinanciera_GastoOperativo.html', 'dvMatrizFinanciera_GastoOperativo');
    }
    else {
        InicializaMatrizFinanciera_GastoOperativoform(id_matrizfinanciera, id_vigencia, MatrizFinancieraVigencia);
    }

}

function MatrizFinancieraExel(idmatrizfinanciera,) {
    debugger;
    $("#spanIdMatrizFinanciera")[0].innerText = idmatrizfinanciera;   
 
    let urlExcel = urlController + "MatrizFinanciera/ExcelMatrizFinanciera?id_matrizfinanciera=" + idmatrizfinanciera;
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

function MatrizFinancieraValorXComprometerGeneral() {
    let svalorinicial = $('#nmpresupuestogeneral_MatrizFinanciera').val();
    let scambio = $('#nmpresupuestogeneralcomprometido_MatrizFinanciera').val();
    nvalorinicial = Number(svalorinicial);
    ncambio = Number(scambio);

    let nvalortotal = nvalorinicial - ncambio;
    
    $('#nmpresupuestogeneralcomprometer_MatrizFinanciera').val(nvalortotal);
}

function MatrizFinancieraValorXComprometerUGI() {
    let svalorinicial = $('#nmpresupuestougi_MatrizFinanciera').val();
    let scambio = $('#nmpresupuestougicomprometido_MatrizFinanciera').val();
    nvalorinicial = Number(svalorinicial);
    ncambio = Number(scambio);

    let nvalortotal = nvalorinicial - ncambio;
    
    $('#nmpresupuestougicomprometer_MatrizFinanciera').val(nvalortotal);
}

function MatrizFinancieraValorXComprometerEST() {
    let svalorinicial = $('#nmpresupuestoestudiantes_MatrizFinanciera').val();
    let scambio = $('#nmpresupuestoestudiantescomprometido_MatrizFinanciera').val();
    nvalorinicial = Number(svalorinicial);
    ncambio = Number(scambio);

    let nvalortotal = nvalorinicial - ncambio;
    
    $('#nmpresupuestoestudiantescomprometer_MatrizFinanciera').val(nvalortotal);
}