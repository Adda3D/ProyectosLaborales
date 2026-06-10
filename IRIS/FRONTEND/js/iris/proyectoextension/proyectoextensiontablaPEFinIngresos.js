var DataTableProyectoExtensionFinancieroDesembolsos = null;
var ObjModelProyecto_Seguimiento_Desembolso = null;
var ObjModelProyectoExtension_DetalleAportes = null;

$(document).ready(function () {    
    ObjModelProyecto_Seguimiento_Desembolso = new Proyecto_Seguimiento_Desembolso();
    ObjModelProyectoExtension_DetalleAportes = new Proyecto_DetalleAportes();

    InicializaFinancieroProyectoExtensionDesembolsosform($("#spanIdProyectoExtension")[0].innerText);

});

function InicializaFinancieroProyectoExtensionDesembolsosform(id_asignacionproyecto) {
    $("#spanIdProyectoExtensionFinanciero")[0].innerText = id_asignacionproyecto; 
    
    if (DataTableProyectoExtensionFinancieroDesembolsos != null) {
        DataTableProyectoExtensionFinancieroDesembolsos.destroy();
    }

    LoadDataTableProyectoExtensionFinancieroDesembolsos(); 

    LoadDataAportesProyectoExtension();

}

function LoadDataTableProyectoExtensionFinancieroDesembolsos() {
    DataTableProyectoExtensionFinancieroDesembolsos = $('#tblProyectoExtensionDesembolsos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Seguimiento_Desembolso/GetDataTableProyectoDesembolsosByProyecto",  //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionFinanciero")[0].innerText
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionFinanciero")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "fechadesembolso", "orderable": true, render: function (data, type, row, meta) {return row.fechadesembolso.slice(0,10)} },
            { "data": "valordesembolso", "orderable": false },            
            { "data": "Porcentaje", "orderable": false },
            { "data": "notas", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Desembolso" onclick="ValidarEliminarDesembolsoProyectoExtension(' + row.id_segdesembolso + ',1)" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 1,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$') 
            },
            { "targets": 2,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 2, '') 
            }            
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function LoadDataAportesProyectoExtension() {
    let urlAportesProyecto = urlController + "Proyectos_AsignacionProyecto/GetProyectos_AsignacionProyectoAportes?id_proyecto=" + $("#spanIdProyectoExtension")[0].innerText;  
    $('#txtProyectoExtensionAporteFacultad').val('0');
    $('#txtProyectoExtensionAporteVIR').val('');
    $('#txtProyectoExtensionAporteDIEB').val('');
    $('#txtProyectoExtensionTotalConvenio').val('');
    $('#txtProyectoExtensionTotalAportadoConvenio').val('');    

    StartLoader();

    fetch(urlAportesProyecto, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            if (datos.aportefacultad != null)
                $('#txtProyectoExtensionAporteFacultad').val(datos.aportefacultad.toLocaleString('en-US'));

            if (datos.aportevir != null)
                $('#txtProyectoExtensionAporteVIR').val(datos.aportevir.toLocaleString('en-US'));

            if (datos.aportedieb != null)
                $('#txtProyectoExtensionAporteDIEB').val(datos.aportedieb.toLocaleString('en-US'));

            if (datos.aprobadoconvenio != null)
                $('#txtProyectoExtensionTotalConvenio').val(datos.aprobadoconvenio.toLocaleString('en-US'));

            if (datos.aportadoconvenio != null)
                $('#txtProyectoExtensionTotalAportadoConvenio').val(datos.aportadoconvenio.toLocaleString('en-US'));
                
            FinalizeLoader();
        
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

function RefreshDataTableProyectoExtensionFinancieroDesembolsos() {
    DataTableProyectoExtensionFinancieroDesembolsos.ajax.reload(null, false);
}

function CrearDesembolsoProyectoExtension() {

    CreateHTMLFromModel(ObjModelProyecto_Seguimiento_Desembolso)
    .then(htmlcreado => {
        NewData_ToModel(ObjModelProyecto_Seguimiento_Desembolso)
        .then(datospreparados => {
            if (datospreparados) { 
                $("#txtid_segdesembolso_Proyecto_Seguimiento_Desembolso").val('');   
                $("#txtid_asignacionproyecto_Proyecto_Seguimiento_Desembolso").val($("#spanIdProyectoExtension")[0].innerText);   
                FinalizeLoader();

                $("#tableProyectoExtensionFinancieroDesembolsos").addClass("ocultar");    
                $("#dvCrearDesembolsoProyectoExtensionFinanciero").removeClass("ocultar");    
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })      
    })
    .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })      

}

function VolverTablaDesembolsosProyectoExtensionFinancieroDesdeDesembolso() {
    $("#dvCrearDesembolsoProyectoExtensionFinanciero").addClass("ocultar");    
    $("#tableProyectoExtensionFinancieroDesembolsos").removeClass("ocultar");       
}

function ValidatePostUpdateProyectoExtensionFinancieroDesembolso(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyecto_Seguimiento_Desembolso)
    .then(datosGuardados => {
    if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del distribuidor Guardados', false, 'success', '', 0);  
        RefreshDataTableProyectoExtensionFinancieroDesembolsos();
        LoadDataAportesProyectoExtension();
        VolverTablaDesembolsosProyectoExtensionFinancieroDesdeDesembolso();        
    }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarDesembolsoProyectoExtension(id_segdesembolso) {
    ShowDialogConfirmacion('','Seguro de eliminar desembolso ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDesembolsoProyectoExtension(id_segdesembolso);
            }
        });

}

function EliminarDesembolsoProyectoExtension(id_segdesembolso) {
    let urlEliminar = urlController + "Seguimiento_Desembolso/DeleteSeguimiento_Desembolso?id_segdesembolso=" + id_segdesembolso;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionFinancieroDesembolsos();
            LoadDataAportesProyectoExtension();
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

function DetalleAportesProyectoExtension() {
    if (ObjModelProyectoExtension_DetalleAportes == null) {
        ObjModelProyectoExtension_DetalleAportes = new Proyecto_DetalleAportes();
    }    

    CreateHTMLFromModel(ObjModelProyectoExtension_DetalleAportes)
    .then(htmlcreado => {
        LoadData_ToModel(ObjModelProyectoExtension_DetalleAportes, $("#spanIdProyectoExtension")[0].innerText)
        .then(datospreparados => {
            if (datospreparados) { 
                FinalizeLoader();

                $("#tableProyectoExtensionFinancieroDesembolsos").addClass("ocultar");    
                $("#dvProyectoExtensionDetalleAportes").removeClass("ocultar");    
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })      
    })
    .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })        
}

function VolverTablaDesembolsosProyectoExtensionFinancieroDesdeAportes(actualizaraportes) {
    if (actualizaraportes)
        LoadDataAportesProyectoExtension();

    $("#dvProyectoExtensionDetalleAportes").addClass("ocultar");    
    $("#tableProyectoExtensionFinancieroDesembolsos").removeClass("ocultar");       
}

function ValidatePostUpdateProyectoExtensionFinancieroAportes(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoExtension_DetalleAportes)
    .then(datosGuardados => {
    if (datosGuardados) {
        FinalizeLoader();
        VolverTablaDesembolsosProyectoExtensionFinancieroDesdeAportes(true);        
    }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}