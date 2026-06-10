var DataTableProyectoExtensionModificaMinuta = null;
//var ObjModelPublicaciones_DivulgacionMediosInvitados = null;

$(document).ready(function () {
    //ObjModelPublicaciones_DivulgacionMediosInvitados = new Publicaciones_DivulgacionActividadInvitados();

    InicializaProyectoExtensionModificaMinutaform();    
});

function InicializaProyectoExtensionModificaMinutaform() {
    $("#txtConsProyectoExtensionModificacionMinuta").val($("#spanConsecutivoProyectoExtension")[0].innerText);
    $("#txtContratoProyectoExtensionModificacionMinuta").val($("#spanContratoProyectoExtension")[0].innerText);
    $("#txtNombreProyectoExtensionModificacionMinuta").val($("#spanNombreProyectoExtension")[0].innerText);
    
    //$("#spanIdProyectoExtension")[0].innerText = id_asignacionproyecto;

    if (DataTableProyectoExtensionModificaMinuta != null) {
        DataTableProyectoExtensionModificaMinuta.destroy();
    }

    LoadDataTableProyectoExtensionModificaMinuta(); 

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionModificacionMinuta").removeClass("ocultar");

}

function VolverTablaProyectoExtensionDesdeModificaMinuta() {
    $("#dvProyectoExtensionModificacionMinuta").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function LoadDataTableProyectoExtensionModificaMinuta() {
    DataTableProyectoExtensionModificaMinuta = $('#tblProyectoExtensionModificacionMinuta').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_ModificacionMinuta/GetDataTablePropuestaModificacionMinutaByPropuesta",  //?id_propuesta=" + $("#spanid_propuestaProyectoExtension")[0].innerText
            "data": {
                "id_propuesta": function() { return $("#spanid_propuestaProyectoExtension")[0].innerText }             
            }
        },      
        "columns": [                        
            { "data": "fecsolmodvol", "orderable": true, render: function (data, type, row, meta) {return row.fecsolmodvol.slice(0,10)} },
            { "data": "descripcionmodificacion", "orderable": true },
            { "data": "tipomodificaciondetalle", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectoExtensionModificacionMinuta(' + row.id_modificacionminuta + ',' + row.id_suscripcionminuta + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });


}

function RefreshDataTableProyectoExtensionModificaMinuta() {
    DataTableProyectoExtensionModificaMinuta.ajax.reload(null, false);    
}

function ValidarEliminarPublicaciones_DivulgacionMediosInvitados(id_invitados, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar invitado ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionMediosInvitados(id_invitados);
            }
        });

}

function EliminarPublicaciones_DivulgacionMediosInvitados(id_invitados) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionActividadInvitados/DeletePublicaciones_DivulgacionActividadInvitados?id_invitados=" + id_invitados;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionModificaMinuta();
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

function CrearProyectoExtensionModificacionMinuta() {
    $("#spanId_modificacionminutaProyectoExtension")[0].innerText = '';    

    if (!ExisteDivEdicionDatos('dvProyectoExtensionModificacionMinutaDetalle')) {
        CrearDivEdicionDatos('/Pages/proyectoextension/proyectoextension_modificacionminutaDetalle.html', 'dvProyectoExtensionModificacionMinutaDetalle');
    }
    else {
        CrearPropuesta_ModificacionMinutaform();
    }
}

function EditarProyectoExtensionModificacionMinuta(id_modificacionminuta, Id_suscripcionminuta) {
    $("#spanId_modificacionminutaProyectoExtension")[0].innerText = id_modificacionminuta;
    $("#spanId_suscripcionminutaProyectoExtension")[0].innerText = Id_suscripcionminuta;
    
    if (!ExisteDivEdicionDatos('dvProyectoExtensionModificacionMinutaDetalle')) {
        CrearDivEdicionDatos('/Pages/proyectoextension/proyectoextension_modificacionminutaDetalle.html', 'dvProyectoExtensionModificacionMinutaDetalle');
    }
    else {
        EditarPropuesta_ModificacionMinutaform(id_modificacionminuta);
    }

}
