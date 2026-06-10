var DataTableProyectoExtensionModificacionGarantia = null;

$(document).ready(function () {

    InicializaProyectoExtensionModificacionGarantiaform();    
});

function InicializaProyectoExtensionModificacionGarantiaform() {
    $("#txtConsProyectoExtensionModificacionGarantia").val($("#spanConsecutivoProyectoExtension")[0].innerText);
    $("#txtContratoProyectoExtensionModificacionGarantia").val($("#spanContratoProyectoExtension")[0].innerText);
    $("#txtNombreProyectoExtensionModificacionGarantia").val($("#spanNombreProyectoExtension")[0].innerText);

    if (DataTableProyectoExtensionModificacionGarantia != null) {
        DataTableProyectoExtensionModificacionGarantia.destroy();
    }

    LoadDataTableProyectoExtensionModificacionGarantia(); 

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionModificacionGarantia").removeClass("ocultar");

}

function VolverTablaProyectoExtensionDesdeModificaGarantia() {
    $("#dvProyectoExtensionModificacionGarantia").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function LoadDataTableProyectoExtensionModificacionGarantia() {
    DataTableProyectoExtensionModificacionGarantia = $('#tblProyectoExtensionModificacionGarantia').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_ModificacionGarantia/GetDataTablePropuestaModificacionGarantiaByPropuesta",  //?id_propuesta=" + $("#spanid_propuestaProyectoExtension")[0].innerText
            "data": {
                "id_propuesta": function() { return $("#spanid_propuestaProyectoExtension")[0].innerText }             
            }
        },      
        "columns": [                    
            { "data": "fecsolicitud", "orderable": true, render: function (data, type, row, meta) {return row.fecsolicitud.slice(0,10)} },
            { "data": "descripcion", "orderable": true },
            { "data": "tipomodificaciondetalle", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectoExtensionModificacionGarantia(' + row.id_modificaciongarantia + ',' + row.id_suscripciongarantia + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });


}

function RefreshDataTableProyectoExtensionModificacionGarantia() {
    DataTableProyectoExtensionModificacionGarantia.ajax.reload(null, false);    
}

function CrearProyectoExtensionModificacionGarantia() {
    $("#spanId_modificacionGarantiaProyectoExtension")[0].innerText = '';    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionModificacionGarantiaDetalle')) {
        CrearDivEdicionDatos('/Pages/proyectoextension/proyectoextension_modificaciongarantiaDetalle.html', 'dvProyectoExtensionModificacionGarantiaDetalle');
    }
    else {
        CrearPropuesta_ModificacionGarantiaform();
    }
}

function EditarProyectoExtensionModificacionGarantia(id_modificaciongarantia, id_suscripciongarantia) {
    $("#spanId_modificacionGarantiaProyectoExtension")[0].innerText = id_modificaciongarantia;
    $("#spanId_suscripciongarantiaProyectoExtension")[0].innerText = id_suscripciongarantia;
    
    if (!ExisteDivEdicionDatos('dvProyectoExtensionModificacionGarantiaDetalle')) {
        CrearDivEdicionDatos('/Pages/proyectoextension/proyectoextension_modificaciongarantiaDetalle.html', 'dvProyectoExtensionModificacionGarantiaDetalle');
    }
    else {
        EditarPropuesta_ModificacionGarantiaform(id_modificaciongarantia);
    }

}
