var DataTablePublicacionFinancieroGastosServicios = null;

$(document).ready(function () {    
    InicializaFinancieroPublicacionGastosServiciosform();

});


function InicializaFinancieroPublicacionGastosServiciosform() {    
    if (DataTablePublicacionFinancieroGastosServicios != null) {
        DataTablePublicacionFinancieroGastosServicios.destroy();
    }

    LoadDataTablePublicacionFinancieroGastosServicios(); 

}

function LoadDataTablePublicacionFinancieroGastosServicios() {
    DataTablePublicacionFinancieroGastosServicios = $('#tblPublicacionGastosServicios').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicacion_Gasto/GetDataTablePublicacion_GastoByPublicacion", 
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText } ,
                "id_partida": function() { return 3 } 
            }
        },      
        "columns": [                    
            { "data": "nombregasto", "orderable": true },
            { "data": "NombreConcepto", "orderable": false },            
            { "data": "fechalegalizacionorden", "orderable": false, render: function (data, type, row, meta) {return row.fechalegalizacionorden.slice(0,10)} },
            { "data": "tipo", "orderable": true },
            { "data": "numorden", "orderable": true },
            { "data": "fechainicio", "orderable": false, render: function (data, type, row, meta) {return row.fechainicio.slice(0,10)} },
            { "data": "fechafinal", "orderable": false, render: function (data, type, row, meta) {return row.fechafinal.slice(0,10)} },
            { "data": "estado", "orderable": true },
            { "data": "valortotal", "orderable": false },
            { "data": "Total4mil", "orderable": false },
            { "data": "TotalPagado", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Aplicar Pago" onclick="GenerarPagoGastoServiciosPublicacion(' + row.id_crearpublicacion + ',' + row.id_publicaciongasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
                           '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarGastoServiciosPublicacion(' + row.id_publicaciongasto + ')" /> ' + 
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Gasto" onclick="ValidarEliminarGastoPublicacion(' + row.id_publicaciongasto + ',1)" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 8,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            },
            { "targets": 9,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            },
            { "targets": 10,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            }            
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicacionFinancieroGastosServicios() {
    DataTablePublicacionFinancieroGastosServicios.ajax.reload(null, false);
}

function CrearGastoServiciosPublicacion() {
    CrearGasto_Publicacion(3);
}

function EditarGastoServiciosPublicacion(id_publicaciongasto) {
    EditarGasto_Publicacion(id_publicaciongasto, 3);
}

function GenerarPagoGastoServiciosPublicacion(idpublicacion, id_publicaciongasto, rubro, descripcion, prestador ) {
    GenerarPagoGastoPublicacion(idpublicacion, id_publicaciongasto, rubro, descripcion, prestador, 'Gastos Adquisición Servicios', 3 );
}