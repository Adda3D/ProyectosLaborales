var DataTableProyectoInvestigacionFinancieroDesembolsos = null;
var ObjModelProyecto_Investigacion_Desembolso = null;
var ObjModelProyectoInvestigacion_DetalleAportes = null;

$(document).ready(function () {    
    ObjModelProyecto_Investigacion_Desembolso = new Investigacion_Desembolso();
    ObjModelProyectoInvestigacion_DetalleAportes = new Investigacion_DetalleAportes();

    InicializaFinancieroProyectoInvestigacionDesembolsosform();

});

function InicializaFinancieroProyectoInvestigacionDesembolsosform() {        
    if (DataTableProyectoInvestigacionFinancieroDesembolsos != null) {
        DataTableProyectoInvestigacionFinancieroDesembolsos.destroy();
    }

    LoadDataTableProyectoInvestigacionFinancieroDesembolsos(); 

    LoadDataAportesProyectoInvestigacion();

}

function LoadDataTableProyectoInvestigacionFinancieroDesembolsos() {
    DataTableProyectoInvestigacionFinancieroDesembolsos = $('#tblProyectoInvestigacionDesembolsos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_Desembolso/GetDataTableInvestigacion_DesembolsoByProyecto",  //?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText
            "data": {
                "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "fechadesembolso", "orderable": true, render: function (data, type, row, meta) {return row.fechadesembolso.slice(0,10)} },
            { "data": "valordesembolso", "orderable": false },            
            { "data": "Porcentaje", "orderable": false },
            { "data": "observaciones", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Desembolso" onclick="ValidarEliminarDesembolsoProyectoInvestigacion(' + row.id_desembolso + ',1)" /> ';
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

function LoadDataAportesProyectoInvestigacion() {
    let urlAportesProyecto = urlController + "Investigacion_CrearProyecto/GetInvestigacion_CrearProyectoAportes?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText;  
    $('#txtProyectoInvestigacionAporteFacultad').val('0');
    $('#txtProyectoInvestigacionAporteVIR').val('0');
    $('#txtProyectoInvestigacionAporteDIEB').val('0');
    $('#txtProyectoInvestigacionTotalConvenio').val('0');
    $('#txtProyectoInvestigacionTotalAportadoConvenio').val('0');    

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
                $('#txtProyectoInvestigacionAporteFacultad').val(datos.aportefacultad.toLocaleString('en-US'));

            if (datos.aportevir != null)
                $('#txtProyectoInvestigacionAporteVIR').val(datos.aportevir.toLocaleString('en-US'));

            if (datos.aportedieb != null)
                $('#txtProyectoInvestigacionAporteDIEB').val(datos.aportedieb.toLocaleString('en-US'));

            if (datos.aprobadoconvenio != null)
                $('#txtProyectoInvestigacionTotalConvenio').val(datos.aprobadoconvenio.toLocaleString('en-US'));

            if (datos.aportadoconvenio != null)
                $('#txtProyectoInvestigacionTotalAportadoConvenio').val(datos.aportadoconvenio.toLocaleString('en-US'));
                
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

function RefreshDataTableProyectoInvestigacionFinancieroDesembolsos() {
    DataTableProyectoInvestigacionFinancieroDesembolsos.ajax.reload(null, false);
}

function CrearDesembolsoProyectoInvestigacion() {

    CreateHTMLFromModel(ObjModelProyecto_Investigacion_Desembolso)
    .then(htmlcreado => {
        NewData_ToModel(ObjModelProyecto_Investigacion_Desembolso)
        .then(datospreparados => {
            if (datospreparados) { 
                $("#txtid_desembolso_Investigacion_Desembolso").val('');   
                $("#txtid_crearproyecto_Investigacion_Desembolso").val($("#spanIdProyectoInvestigacion")[0].innerText);   
                FinalizeLoader();

                $("#tableProyectoInvestigacionFinancieroDesembolsos").addClass("ocultar");    
                $("#dvCrearDesembolsoProyectoInvestigacionFinanciero").removeClass("ocultar");    
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

function VolverTablaDesembolsosProyectoInvestigacionFinancieroDesdeDesembolso() {
    $("#dvCrearDesembolsoProyectoInvestigacionFinanciero").addClass("ocultar");    
    $("#tableProyectoInvestigacionFinancieroDesembolsos").removeClass("ocultar");       
}

function ValidatePostUpdateProyectoInvestigacionFinancieroDesembolso(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyecto_Investigacion_Desembolso)
    .then(datosGuardados => {
    if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del distribuidor Guardados', false, 'success', '', 0);  
        RefreshDataTableProyectoInvestigacionFinancieroDesembolsos();
        LoadDataAportesProyectoInvestigacion();
        VolverTablaDesembolsosProyectoInvestigacionFinancieroDesdeDesembolso();        
    }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarDesembolsoProyectoInvestigacion(id_desembolso) {
    ShowDialogConfirmacion('','Seguro de eliminar desembolso ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDesembolsoProyectoInvestigacion(id_desembolso);
            }
        });

}

function EliminarDesembolsoProyectoInvestigacion(id_desembolso) {
    let urlEliminar = urlController + "Investigacion_Desembolso/DeleteInvestigacion_Desembolso?id_desembolso=" + id_desembolso;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoInvestigacionFinancieroDesembolsos();
            LoadDataAportesProyectoInvestigacion();
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

function DetalleAportesProyectoInvestigacion() {
    if (ObjModelProyectoInvestigacion_DetalleAportes == null) {
        ObjModelProyectoInvestigacion_DetalleAportes = new Proyecto_DetalleAportes();
    }    

    CreateHTMLFromModel(ObjModelProyectoInvestigacion_DetalleAportes)
    .then(htmlcreado => {
        LoadData_ToModel(ObjModelProyectoInvestigacion_DetalleAportes, $("#spanIdProyectoInvestigacion")[0].innerText)
        .then(datospreparados => {
            if (datospreparados) { 
                FinalizeLoader();

                $("#tableProyectoInvestigacionFinancieroDesembolsos").addClass("ocultar");    
                $("#dvProyectoInvestigacionDetalleAportes").removeClass("ocultar");    
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

function VolverTablaDesembolsosProyectoInvestigacionFinancieroDesdeAportes(actualizaraportes) {
    if (actualizaraportes)
        LoadDataAportesProyectoInvestigacion();

    $("#dvProyectoInvestigacionDetalleAportes").addClass("ocultar");    
    $("#tableProyectoInvestigacionFinancieroDesembolsos").removeClass("ocultar");       
}

function ValidatePostUpdateProyectoInvestigacionFinancieroAportes(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoInvestigacion_DetalleAportes)
    .then(datosGuardados => {
    if (datosGuardados) {
        FinalizeLoader();
        VolverTablaDesembolsosProyectoInvestigacionFinancieroDesdeAportes(true);        
    }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}