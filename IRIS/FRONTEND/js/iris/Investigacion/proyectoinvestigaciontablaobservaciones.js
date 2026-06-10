var DataTableProyectoInvestigacionObservaciones = null;
var ObjModelProyectoInvestigacionObservaciones = null;

$(document).ready(function () {
    ObjModelProyectoInvestigacionObservaciones = new Investigacion_Observacion();

    InicializaProyectoInvestigacionObservacionesform();
});

function InicializaProyectoInvestigacionObservacionesform() {
    $("#txtHermesPRJINVObservaciones").val($("#spanHermesProyectoInvestigacion")[0].innerText);
    $("#txtQuipuPRJINVObservaciones").val($("#spanQuipuProyectoInvestigacion")[0].innerText);
    $("#txtNombrePRJINVObservaciones").val($("#spanNombreProyectoInvestigacion")[0].innerText);
    
    if (DataTableProyectoInvestigacionObservaciones != null) {
        DataTableProyectoInvestigacionObservaciones.destroy();
    }

    LoadDataTableProyectoInvestigacionObservaciones();

    $("#dvProyectoInvestigacionTable").addClass("ocultar");    
    $("#dvProyectoInvestigacionTablaObservaciones").removeClass("ocultar");
}

function VolverTablaProyectoInvestigacionDesdeObservacionesForm() {
    $("#dvProyectoInvestigacionTablaObservaciones").addClass("ocultar");    
    $("#dvProyectoInvestigacionTable").removeClass("ocultar");
}
  
function LoadDataTableProyectoInvestigacionObservaciones() {
    DataTableProyectoInvestigacionObservaciones = $('#tblProyectoInvestigacionObservaciones').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,        
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_Observacion/GetDataTableInvestigacion_ObservacionByProyecto", //?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText
            "data": {
                "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText }
            }
        },      
        "columns": [                        
            { "data": "observacion", "orderable": true },            
            { "data": "fechaobservacion", "orderable": false, render: function (data, type, row, meta) {return row.fechaobservacion.slice(0,10)} },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarProyectoInvestigacionObservaciones(' + row.id_proyectoobservacion + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoInvestigacionObservaciones" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Observación" onclick="ValidarEliminarProyectoInvestigacionObservaciones(' + row.id_proyectoobservacion + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoInvestigacionObservaciones() {
    DataTableProyectoInvestigacionObservaciones.ajax.reload(null, false);    
}
  
function CrearProyectoInvestigacionObservaciones() {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionObservaciones)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoInvestigacionObservaciones)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_proyectoobservacion_Investigacion_Observacion").val('');
                    $("#txtid_crearproyecto_Investigacion_Observacion").val($("#spanIdProyectoInvestigacion")[0].innerText);
                    FinalizeLoader();    
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

function EditarProyectoInvestigacionObservaciones(id_proyectoobservacion) {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionObservaciones)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelProyectoInvestigacionObservaciones, id_proyectoobservacion)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
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

function ValidatePostUpdateProyectoInvestigacionObservacionesForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoInvestigacionObservaciones)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableProyectoInvestigacionObservaciones();
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarProyectoInvestigacionObservaciones(id_proyectoobservacion) {
    ShowDialogConfirmacion('','Seguro de eliminar datos observación ?', 'Sí, eliminar', 'No, cancelar')
    .then(borrar => {
        if (borrar) {
            EliminarProyectoInvestigacionObservaciones(id_proyectoobservacion);
        }
    });

}

function EliminarProyectoInvestigacionObservaciones(id_proyectoobservacion) {
    let urlEliminar = urlController + "Investigacion_Observacion/DeleteInvestigacion_Observacion?id_proyectoobservacion=" + id_proyectoobservacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoInvestigacionObservaciones();
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

