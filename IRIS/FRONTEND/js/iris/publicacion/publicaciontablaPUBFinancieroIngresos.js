var DataTablePublicacionFinancieroDesembolsos = null;
var ObjModelPublicacion_Desembolso = null;
var ObjModelPublicacion_DetalleAportes = null;

$(document).ready(function () {    
    ObjModelPublicacion_Desembolso = new Publicacion_Desembolso();
    ObjModelPublicacion_DetalleAportes = new Publicacion_DetalleAportes();

    InicializaFinancieroPublicacionDesembolsosform();

});

function InicializaFinancieroPublicacionDesembolsosform() {        
    if (DataTablePublicacionFinancieroDesembolsos != null) {
        DataTablePublicacionFinancieroDesembolsos.destroy();
    }

    LoadDataTablePublicacionFinancieroDesembolsos(); 

    LoadDataAportesPublicacion();

}

function LoadDataTablePublicacionFinancieroDesembolsos() {
    DataTablePublicacionFinancieroDesembolsos = $('#tblPublicacionDesembolsos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicacion_Desembolso/GetDataTablePublicacion_DesembolsoByPublicacion",  
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "fechadesembolso", "orderable": true, render: function (data, type, row, meta) {return row.fechadesembolso.slice(0,10)} },
            { "data": "valordesembolso", "orderable": false },            
            { "data": "Porcentaje", "orderable": false },
            { "data": "observaciones", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Desembolso" onclick="ValidarEliminarDesembolsoPublicacion(' + row.id_desembolso + ',1)" /> ';
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

function LoadDataAportesPublicacion() {
    let urlAportesPublicacion = urlController + "Publicaciones_CrearPublicacion/GetPublicaciones_CrearPublicacionAportes?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText;  
    $('#txtPublicacionAporteFacultad').val('0');
    $('#txtPublicacionAporteVIR').val('0');
    $('#txtPublicacionAporteDIEB').val('0');
    $('#txtPublicacionTotalConvenio').val('0');
    $('#txtPublicacionTotalAportadoConvenio').val('0');    

    StartLoader();

    fetch(urlAportesPublicacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            if (datos.aportefacultad != null)
                $('#txtPublicacionAporteFacultad').val(datos.aportefacultad.toLocaleString('en-US'));

            if (datos.aportevir != null)
                $('#txtPublicacionAporteVIR').val(datos.aportevir.toLocaleString('en-US'));

            if (datos.aportedieb != null)
                $('#txtPublicacionAporteDIEB').val(datos.aportedieb.toLocaleString('en-US'));

            if (datos.aprobadoconvenio != null)
                $('#txtPublicacionTotalConvenio').val(datos.aprobadoconvenio.toLocaleString('en-US'));

            if (datos.aportadoconvenio != null)
                $('#txtPublicacionTotalAportadoConvenio').val(datos.aportadoconvenio.toLocaleString('en-US'));
                
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

function RefreshDataTablePublicacionFinancieroDesembolsos() {
    DataTablePublicacionFinancieroDesembolsos.ajax.reload(null, false);
}

function CrearDesembolsoPublicacion() {

    CreateHTMLFromModel(ObjModelPublicacion_Desembolso)
    .then(htmlcreado => {
        NewData_ToModel(ObjModelPublicacion_Desembolso)
        .then(datospreparados => {
            if (datospreparados) { 
                $("#txtid_desembolso_Publicacion_Desembolso").val('');   
                $("#txtid_crearpublicacion_Publicacion_Desembolso").val($("#spanIdPublicacion")[0].innerText);   
                FinalizeLoader();

                $("#tablePublicacionFinancieroDesembolsos").addClass("ocultar");    
                $("#dvCrearDesembolsoPublicacionFinanciero").removeClass("ocultar");    
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

function VolverTablaDesembolsosPublicacionFinancieroDesdeDesembolso() {
    $("#dvCrearDesembolsoPublicacionFinanciero").addClass("ocultar");    
    $("#tablePublicacionFinancieroDesembolsos").removeClass("ocultar");       
}

function ValidatePostUpdatePublicacionFinancieroDesembolso(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacion_Desembolso)
    .then(datosGuardados => {
    if (datosGuardados) {
        FinalizeLoader();        
        RefreshDataTablePublicacionFinancieroDesembolsos();
        LoadDataAportesPublicacion();
        VolverTablaDesembolsosPublicacionFinancieroDesdeDesembolso();        
    }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarDesembolsoPublicacion(id_desembolso) {
    ShowDialogConfirmacion('','Seguro de eliminar desembolso ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDesembolsoPublicacion(id_desembolso);
            }
        });

}

function EliminarDesembolsoPublicacion(id_desembolso) {
    let urlEliminar = urlController + "Publicacion_Desembolso/DeletePublicacion_Desembolso?id_desembolso=" + id_desembolso;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicacionFinancieroDesembolsos();
            LoadDataAportesPublicacion();
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

function DetalleAportesPublicacion() {
    if (ObjModelPublicacion_DetalleAportes == null) {
        ObjModelPublicacion_DetalleAportes = new Publicacion_DetalleAportes();
    }    

    CreateHTMLFromModel(ObjModelPublicacion_DetalleAportes)
    .then(htmlcreado => {
        LoadData_ToModel(ObjModelPublicacion_DetalleAportes, $("#spanIdPublicacion")[0].innerText)
        .then(datospreparados => {
            if (datospreparados) { 
                FinalizeLoader();

                $("#tablePublicacionFinancieroDesembolsos").addClass("ocultar");    
                $("#dvPublicacionDetalleAportes").removeClass("ocultar");    
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

function VolverTablaDesembolsosPublicacionFinancieroDesdeAportes(actualizaraportes) {
    if (actualizaraportes)
        LoadDataAportesPublicacion();

    $("#dvPublicacionDetalleAportes").addClass("ocultar");    
    $("#tablePublicacionFinancieroDesembolsos").removeClass("ocultar");       
}

function ValidatePostUpdatePublicacionFinancieroAportes(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacion_DetalleAportes)
    .then(datosGuardados => {
    if (datosGuardados) {
        FinalizeLoader();
        VolverTablaDesembolsosPublicacionFinancieroDesdeAportes(true);        
    }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}