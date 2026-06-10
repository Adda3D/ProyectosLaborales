    var DataTableProyectoInvestigacionTareas = null;
var ObjModelProyectoInvestigacionTareas = null;

$(document).ready(function () {
    ObjModelProyectoInvestigacionTareas = new Tarea_CrearModulo();

    InicializaProyectoInvestigacionTareasform();
});

function InicializaProyectoInvestigacionTareasform() {
    $("#txtHermesPRJINVTareas").val($("#spanHermesProyectoInvestigacion")[0].innerText);
    $("#txtQuipuPRJINVTareas").val($("#spanQuipuProyectoInvestigacion")[0].innerText);
    $("#txtNombrePRJINVTareas").val($("#spanNombreProyectoInvestigacion")[0].innerText);

    ObjModelProyectoInvestigacionTareas.SufijoNombreControl = 'ProyectoInvestigacion';
    ObjModelProyectoInvestigacionTareas.FormEdicion = 'formProyectoInvestigacionTareas';

    LoadProyectoInvestigacionTareas();

    $("#dvProyectoInvestigacionTable").addClass("ocultar");    
    $("#dvProyectoInvestigacionTablaTareas").removeClass("ocultar");
}

function VolverTablaProyectoInvestigacionDesdeTareasForm () {
    $("#dvProyectoInvestigacionTablaTareas").addClass("ocultar");    
    $("#dvProyectoInvestigacionTable").removeClass("ocultar");
}

function CerrarProyectoInvestigacionTareasDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelProyectoInvestigacionTareas);
  
}
  
function LoadProyectoInvestigacionTareas() {
    debugger;
    if (DataTableProyectoInvestigacionTareas != null) {
        DataTableProyectoInvestigacionTareas.destroy();
    }

    DataTableProyectoInvestigacionTareas = $('#tblProyectoInvestigacionTareas').DataTable({
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
            "url": urlController + "Tareas/GetDataTableTareasByRelacioncon",  
            "data": {
                "relacioncon": function() { return "PROYECTO INVESTIGACIÓN" },
                "idrelacionado": function() { return $("#spanIdProyectoInvestigacion")[0].innerText } 
            }
        },      
        "columns": [                        
            { "data": "fechaentrega", "orderable": true, render: function (data, type, row, meta) {return row.fechaentrega.slice(0,10)} },
            { "data": "detalles", "orderable": true },            
            { "data": "Responsable", "orderable": false },
            { "data": "EstadoTarea", "orderable": false },
            { "data": "avance", "orderable": true, render: function (data, type, row, meta) {
                return type === 'display'
                    ? '<progress title="' + data + '%" value="' + data + '" max="100"></progress> <label>' + data + '%</label>'
                    : data;
            } },
            { "data": "fechafin", "orderable": false, render: function (data, type, row, meta) { return (row.fechafin == null) ? "" : row.fechafin.slice(0,10)} },
            { "data": "asignadopor", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Tarea" onclick="ValidarEliminarProyectoInvestigacionTareas(' + row.id_tarea + ',`' + row.usuariocreacion + '`);" />' +
                           '<img src="../images/iris/verdetalle.png" class="cambiarMouse" title="Detalle Seguimiento" onclick="VerDetalleSeguimientoTareaUsuario(' + row.id_tarea + ',`' + row.seguimiento + '`);"  data-bs-toggle="modal" data-bs-target="#ModalDetalleSeguimientoTareaUsuario" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoInvestigacionTareas() {
    DataTableProyectoInvestigacionTareas.ajax.reload(null, false);    
}
  
function CrearProyectoInvestigacionTareas() {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionTareas)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoInvestigacionTareas)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_tarea_Tarea_CrearModuloProyectoInvestigacion").val('');
                    $("#txtrelacioncon_Tarea_CrearModuloProyectoInvestigacion").val('PROYECTO INVESTIGACIÓN');
                    $("#txtid_estadotarea_Tarea_CrearModuloProyectoInvestigacion").val('1');
                    $("#txtfuncionarioasigna_Tarea_CrearModuloProyectoInvestigacion").val(sessionStorage.getItem('usersession'));
                    $("#txtidrelacionado_Tarea_CrearModuloProyectoInvestigacion").val($("#spanIdProyectoInvestigacion")[0].innerText);
                    $("#txtconsecutivo_Tarea_CrearModuloProyectoInvestigacion").val($("#spanHermesProyectoInvestigacion")[0].innerText);
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

function ValidatePostUpdateProyectoInvestigacionTareasForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoInvestigacionTareas)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableProyectoInvestigacionTareas();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarProyectoInvestigacionTareas(id_tarea, usuario) {

    if (sessionStorage.getItem('usersession') == usuario) {
        ShowDialogConfirmacion('','Seguro de eliminar datos tarea ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectoInvestigacionTareas(id_tarea);
            }
        });
    }
    else {
        ShowModalDialog('Solo el usuario ' + usuario + ' puede eliminar datos de la tarea', false, 'warning', '', 0);
    }

}

function EliminarProyectoInvestigacionTareas(id_tarea) {
    let urlEliminar = urlController + "Tareas/DeleteTareas?id_tarea=" + id_tarea;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoInvestigacionTareas();
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

