var DataTableTareasGeneral = null;
var ObjModelTareasGeneral = null;
var IdEstadoTareaGeneralFiltro = -1;

$(document).ready(function () {
    ObjModelTareasGeneral = new Tarea_CrearModuloGeneral();

    LoadEstadoTareaFiltroSelect('cboFiltroTareasGeneral', false);
    $('#cboFiltroTareasGeneral').select2();    

    IdEstadoTareaGeneralFiltro = -1;

    InicializaTareasGeneralform();
});

function InicializaTareasGeneralform() {
    ObjModelTareasGeneral.SufijoNombreControl = 'TareasGeneral';
    ObjModelTareasGeneral.FormEdicion = 'formTareasGeneral';

    LoadTareasGeneral();

}

function CerrarTareasGeneralDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelTareasGeneral);
  
}
  
function LoadTareasGeneral() {
    debugger;
    if (DataTableTareasGeneral != null) {
        DataTableTareasGeneral.destroy();
    }

    DataTableTareasGeneral = $('#tblTareasGeneral').DataTable({
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
            "url": urlController + "Tareas/GetDataTableTareasByAsignadoPorEstado",  
            "data": {
                "asignadopor": function() { return sessionStorage.getItem('usersession') },
                "id_estadotarea": function() { return IdEstadoTareaGeneralFiltro }
            }
        },      
        "columns": [                        
            { "data": "fechaentrega", "orderable": true, render: function (data, type, row, meta) {return row.fechaentrega.slice(0,10)} },
            { "data": "relacioncon", "orderable": true },
            { "data": "consecutivo", "orderable": true },
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
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Tarea" onclick="ValidarEliminarTareasGeneral(' + row.id_tarea + ',`' + row.usuariocreacion + '`);" />' +
                           '<img src="../images/iris/verdetalle.png" class="cambiarMouse" title="Detalle Seguimiento" onclick="VerDetalleSeguimientoTareaUsuario(' + row.id_tarea + ',`' + row.seguimiento + '`);"  data-bs-toggle="modal" data-bs-target="#ModalDetalleSeguimientoTareaUsuario" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableTareasGeneral() {
    DataTableTareasGeneral.ajax.reload(null, false);    
}
  
function CrearTareasGeneral() {

    CreateHTMLFromModel(ObjModelTareasGeneral)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelTareasGeneral)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_tarea_Tarea_CrearModuloGenerlTareasGeneral").val('');
                    $("#txtrelacioncon_Tarea_CrearModuloGenerlTareasGeneral").val('GENERAL');
                    $("#txtid_estadotarea_Tarea_CrearModuloGeneralTareasGeneral").val('1');
                    $("#txtfuncionarioasigna_Tarea_CrearModuloGeneralTareasGeneral").val(sessionStorage.getItem('usersession'));
                    //$("#txtidrelacionado_Tarea_CrearModuloTareasGeneral").val($("#spanIdTareasGeneral")[0].innerText);
                    //$("#txtconsecutivo_Tarea_CrearModuloTareasGeneral").val($("#spanHermesTareasGeneral")[0].innerText);
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

function ValidatePostUpdateTareasGeneralForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelTareasGeneral)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableTareasGeneral();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarTareasGeneral(id_tarea, usuario) {

    if (sessionStorage.getItem('usersession') == usuario) {
        ShowDialogConfirmacion('','Seguro de eliminar datos tarea ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarTareasGeneral(id_tarea);
            }
        });
    }
    else {
        ShowModalDialog('Solo el usuario ' + usuario + ' puede eliminar datos de la tarea', false, 'warning', '', 0);
    }

}

function EliminarTareasGeneral(id_tarea) {
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
            RefreshDataTableTareasGeneral();
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

function ActualizarFiltroTareasGeneral() {
    IdEstadoTareaGeneralFiltro = $('#cboFiltroTareasGeneral').val();
    RefreshDataTableTareasGeneral();
}
