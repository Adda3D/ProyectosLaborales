var DataTableProyectoExtensionTareas = null;
var ObjModelProyectoExtensionTareas = null;

$(document).ready(function () {
    ObjModelProyectoExtensionTareas = new Tarea_CrearModulo();

    InicializaProyectoExtensionTareasform();
});

function InicializaProyectoExtensionTareasform() {
    $("#txtConsProyectoExtensionTareas").val($("#spanConsecutivoProyectoExtension")[0].innerText);
    $("#txtNombreProyectoExtensionTareas").val($("#spanNombreProyectoExtension")[0].innerText);

    ObjModelProyectoExtensionTareas.SufijoNombreControl = 'ProyectoExtension';
    ObjModelProyectoExtensionTareas.FormEdicion = 'formProyectoExtensionTareas';

    LoadProyectoExtensionTareas();

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTareas").removeClass("ocultar");
}

function VolverTablaProyectosExtensionDesdeTareasForm() {
    $("#dvProyectoExtensionTareas").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");
}

function CerrarProyectoExtensionTareasDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelProyectoExtensionTareas);
  
}
  
function LoadProyectoExtensionTareas() {
    debugger;
    if (DataTableProyectoExtensionTareas != null) {
        DataTableProyectoExtensionTareas.destroy();
    }

    DataTableProyectoExtensionTareas = $('#tblProyectoExtensionTareas').DataTable({
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
                "relacioncon": function() { return "PROYECTO EXTENSIÓN" },
                "idrelacionado": function() { return $("#spanIdProyectoExtension")[0].innerText } 
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
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Tarea" onclick="ValidarEliminarProyectoExtensionTareas(' + row.id_tarea + ',`' + row.usuariocreacion + '`);" />' +
                           '<img src="../images/iris/verdetalle.png" class="cambiarMouse" title="Detalle Seguimiento" onclick="VerDetalleSeguimientoTareaUsuario(' + row.id_tarea + ',`' + row.seguimiento + '`);"  data-bs-toggle="modal" data-bs-target="#ModalDetalleSeguimientoTareaUsuario" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtensionTareas() {
    DataTableProyectoExtensionTareas.ajax.reload(null, false);    
}
  
function CrearProyectoExtensionTareas() {

    CreateHTMLFromModel(ObjModelProyectoExtensionTareas)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoExtensionTareas)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_tarea_Tarea_CrearModuloProyectoExtension").val('');                    
                    $("#txtrelacioncon_Tarea_CrearModuloProyectoExtension").val('PROYECTO EXTENSIÓN');
                    $("#txtid_estadotarea_Tarea_CrearModuloProyectoExtension").val('1');
                    $("#txtfuncionarioasigna_Tarea_CrearModuloProyectoExtension").val(sessionStorage.getItem('usersession'));
                    $("#txtidrelacionado_Tarea_CrearModuloProyectoExtension").val($("#spanIdProyectoExtension")[0].innerText);
                    $("#txtconsecutivo_Tarea_CrearModuloProyectoExtension").val($("#spanConsecutivoProyectoExtension")[0].innerText);
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

function ValidatePostUpdateProyectoExtensionTareasForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoExtensionTareas)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableProyectoExtensionTareas();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarProyectoExtensionTareas(id_tarea, usuario) {

    if (sessionStorage.getItem('usersession') == usuario) {
        ShowDialogConfirmacion('','Seguro de eliminar datos tarea ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectoExtensionTareas(id_tarea);
            }
        });
    }
    else {
        ShowModalDialog('Solo el usuario ' + usuario + ' puede eliminar datos de la tarea', false, 'warning', '', 0);
    }

}

function EliminarProyectoExtensionTareas(id_tarea) {
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
            RefreshDataTableProyectoExtensionTareas();
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

