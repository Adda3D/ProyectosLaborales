var DataTableTareasUsuario = null;
var IdEstadoTareaFiltro = -1;
var sCorreoFuncionarioAsignado = sessionStorage.getItem('usersession') + "@unal.edu.co";

$(document).ready(function () {   
    LoadEstadoTareaFiltroSelect('cboFiltroTareasUsuario', false);
    $('#cboFiltroTareasUsuario').select2();    

    IdEstadoTareaFiltro = -1;

    if (DataTableTareasUsuario != null) {
        RefreshDataTableTareasUsuario();
    }
    else {
        LoadDataTableTareasUsuario();
    }

    RefrescarNotificacionesUsuario();

});

function LoadDataTableTareasUsuario() {
    debugger;    

    DataTableTareasUsuario = $('#tblTareasUsuario').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        searching: false,
        "search": {
            "caseInsensitive": true
        },
        "createdRow": function (row, data, dataIndex, cells) {       
            if (data.id_estadotarea == 4) {
                $(row).css("background-color", "#d1f5e1"); //c7ffdf
            }
            else {
                if (data.DiasVence >= -2) {
                    $(row).css("background-color", "#ff6161"); //d03e3e
                }
                else 
                    if (data.DiasVence >= -5) {
                        $(row).css("background-color", "#ffbc70");  //e7b798
                    }
                    else {
                        if (data.DiasVence >= -8) {
                            $(row).css("background-color", "#fbf8d0");  //f5f3b2
                        }
                    }    
            }
        },
        "ajax": {
            "url": urlController + "Tareas/GetDataTableTareasByFuncionarioEstado",
            "data": {
                "idfuncionario": function() { return sCorreoFuncionarioAsignado } ,
                "id_estadotarea": function() { return IdEstadoTareaFiltro } 
            }
        },      
        "columns": [                        
            { "data": "fechaentrega", "orderable": true, render: function (data, type, row, meta) {return row.fechaentrega.slice(0,10)} },
            { "data": "relacioncon", "orderable": true },
            { "data": "consecutivo", "orderable": true },
            { "data": "detalles", "orderable": true },
            { "data": "EstadoTarea", "orderable": false },
            { "data": "avance", "orderable": true, render: function (data, type, row, meta) {
                return type === 'display'
                    ? '<progress title="' + data + '%" value="' + data + '" max="100"></progress> <label>' + data + '%</label>'
                    : data;
            } },           
            { "data": "DiasVence", "orderable": false }, 
            { "data": "fechafin", "orderable": false, render: function (data, type, row, meta) { return (row.fechafin == null) ? "" : row.fechafin.slice(0,10)} },
            { "data": "asignadopor", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/seguimiento.png" class="cambiarMouse" title="Seguimiento Tarea" onclick="GenerarSeguimientoTareaUsuario(' + row.id_tarea + ');"  data-bs-toggle="modal" data-bs-target="#ModalSeguimientoTareaUsuario" /> ' + 
                           '<img src="../images/iris/verdetalle.png" class="cambiarMouse" title="Detalle Seguimiento" onclick="VerDetalleSeguimientoTareaUsuario(' + row.id_tarea + ',`' + row.seguimiento + '`);"  data-bs-toggle="modal" data-bs-target="#ModalDetalleSeguimientoTareaUsuario" /> ' +
                           '<img src="../images/iris/avance.png" class="cambiarMouse" title="Estado y Avance" onclick="EstadoAvanceTareaUsuario(' + row.id_tarea + ');"  data-bs-toggle="modal" data-bs-target="#ModalEstadoAvanceTareaUsuario" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        /*
        "columnDefs": [
            { "targets": 0,
                width: '20%'
            },
            { "targets": 1,
                width: '20%',
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '') 
            },
            { "targets": 2,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            },
            { "targets": 0,
                width: '20%'
            }
        ],    */           
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableTareasUsuario() {
    DataTableTareasUsuario.ajax.reload(null, false);    
}

function ActualizarFiltroTareasUsuario() {
    debugger;
    IdEstadoTareaFiltro = $('#cboFiltroTareasUsuario').val();
    RefreshDataTableTareasUsuario();
}
