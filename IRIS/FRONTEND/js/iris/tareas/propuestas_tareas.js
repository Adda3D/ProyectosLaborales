var DataTablePropuestasTareas = null;
var ObjModelPropuestasTareas = null;

$(document).ready(function () {
    ObjModelPropuestasTareas = new Tarea_CrearModulo();

    InicializaPropuestasTareasform();
});

function InicializaPropuestasTareasform() {
    $("#txtConsPropuestaTareas").val($("#spanConsecutivoPropuestaGeneral")[0].innerText);
    $("#txtNombrePropuestaTareas").val($("#spanNombrePropuestaGeneral")[0].innerText);

    ObjModelPropuestasTareas.SufijoNombreControl = 'Propuesta';
    ObjModelPropuestasTareas.FormEdicion = 'formPropuestasTareas';

    LoadPropuestasTareas();

    $("#dvPropuestaExtensionTable").addClass("ocultar");    
    $("#dvPropuestaTareas").removeClass("ocultar");
}

function VolverTablaPropuestasDesdeTareasForm() {
    $("#dvPropuestaTareas").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");
}

function CerrarPropuestaTareasDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPropuestasTareas);
  
}
  
function LoadPropuestasTareas() {
    debugger;
    if (DataTablePropuestasTareas != null) {
        DataTablePropuestasTareas.destroy();
    }

    DataTablePropuestasTareas = $('#tblPropuestasTareas').DataTable({
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
                "relacioncon": function() { return "PROPUESTA" },
                "idrelacionado": function() { return $("#spanIdPropuestaGeneral")[0].innerText } 
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
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Tarea" onclick="ValidarEliminarPropuestasTareas(' + row.id_tarea + ',`' + row.usuariocreacion + '`);" />' +
                           '<img src="../images/iris/verdetalle.png" class="cambiarMouse" title="Detalle Seguimiento" onclick="VerDetalleSeguimientoTareaUsuario(' + row.id_tarea + ',`' + row.seguimiento + '`);"  data-bs-toggle="modal" data-bs-target="#ModalDetalleSeguimientoTareaUsuario" /> ';                           
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePropuestasTareas() {
    DataTablePropuestasTareas.ajax.reload(null, false);    
}
  
function CrearPropuestasTareas() {

    CreateHTMLFromModel(ObjModelPropuestasTareas)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPropuestasTareas)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_tarea_Tarea_CrearModuloPropuesta").val('');
                    $("#txtrelacioncon_Tarea_CrearModuloPropuesta").val('PROPUESTA');
                    $("#txtid_estadotarea_Tarea_CrearModuloPropuesta").val('1'); 
                    $("#txtfuncionarioasigna_Tarea_CrearModuloPropuesta").val(sessionStorage.getItem('usersession'));
                    $("#txtidrelacionado_Tarea_CrearModuloPropuesta").val($("#spanIdPropuestaGeneral")[0].innerText);
                    $("#txtconsecutivo_Tarea_CrearModuloPropuesta").val($("#spanConsecutivoPropuestaGeneral")[0].innerText);
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

/*
function EditarPropuestasTareas(id_tarea) {   

    CreateHTMLFromModel(ObjModelPropuestasTareas)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPropuestasTareas, id_tarea)
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
*/

function ValidatePostUpdatePropuestasTareasForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPropuestasTareas)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTablePropuestasTareas();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPropuestasTareas(id_tarea, usuario) {

    if (sessionStorage.getItem('usersession') == usuario) {
        ShowDialogConfirmacion('','Seguro de eliminar datos tarea ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestasTareas(id_tarea);
            }
        });
    }
    else {
        ShowModalDialog('Solo el usuario ' + usuario + ' puede eliminar datos de la tarea', false, 'warning', '', 0);
    }
    
}

function EliminarPropuestasTareas(id_tarea) {
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
            RefreshDataTablePropuestasTareas();
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

