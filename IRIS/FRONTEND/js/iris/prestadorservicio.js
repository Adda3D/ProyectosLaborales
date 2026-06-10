var DataTablePrestadorServicio = null;

$(document).ready(function () {
    LoadDataTablePrestadorServicio(); 
        
});


function LoadDataTablePrestadorServicio() {
    DataTablePrestadorServicio = $('#tblPrestadorServicio').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Persona/GetDataTablePersona"
        },      
        "columns": [            
            { "data": "nombrecompleto", "orderable": true },
            { "data": "numidentificacion", "orderable": true },
            { "data": "telefono", "orderable": true },
            { "data": "celular", "orderable": true },
            { "data": "correo1", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPrestadorServicio(' + row.id_persona + ')" /> ' /* +                           
                           '<img src="../images/iris/seguimiento.png" class="cambiarMouse" title="Proyectos" onclick="ProyectosPrestadorServicio(' + row.id_persona + ');" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Prestador" onclick="ValidarEliminarPrestadorServicio(' + row.id_persona + ',`' + row.nombrecompleto + '`);" />  */;
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePrestadorServicio() {
    DataTablePrestadorServicio.ajax.reload(null, false);
}

function ExisteDivEdicionPrestadorServicio() {
    let divedicion = document.getElementById('dvPrestadorServicioDetalle').innerHTML;

    if (divedicion == null || divedicion == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivEdicionPrestadorServicio() {
    let urledit = '/Pages/prestadorservicio/detalle_prestadorservicio.html'; 

    //let newDivedicion = document.createElement("div");
    //newDivedicion.id = 'dvPrestadorServicioDetalle';
    //newDivedicion.className = "row ocultar col-md-12 scroll";
    //document.body.appendChild(newDivedicion);

    $.get(urledit, function (htmlexterno) {
        $('#dvPrestadorServicioDetalle').html(htmlexterno);
    });    

}

function CrearPrestadorServicio() {
    $("#spanIdPrestadorServicio")[0].innerText = '';

    if (!ExisteDivEdicionPrestadorServicio()) {
        CrearDivEdicionPrestadorServicio();
    }
    else {
        CrearPrestadorServicioform();
    }

}

function EditarPrestadorServicio(idpersona) {
    $("#spanIdPrestadorServicio")[0].innerText = idpersona;

    if (!ExisteDivEdicionPrestadorServicio()) {
        CrearDivEdicionPrestadorServicio();
    }
    else {
        EditarPrestadorServicioform(idpersona);
    }

}

