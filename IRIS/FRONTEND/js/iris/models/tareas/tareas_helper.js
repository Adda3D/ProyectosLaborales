var ObjModelSeguimientoTareaUsuario = null;
var ObjModelEstadoAvanceTareaUsuario = null;
var ObjModelAlerta_SeguimientoUsuario = null;
var ObjModelAlerta_SeguimientoUsuarioGeneral = null;
var DataTableAlerta_SeguimientoUsuario = null;
var EstadoAlertaSeguimientoFiltro = "ABIERTA";

function GenerarSeguimientoTareaUsuario(id_tarea) {
    ObjModelSeguimientoTareaUsuario = new Tarea_Seguimiento();


    CreateHTMLFromModel(ObjModelSeguimientoTareaUsuario)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelSeguimientoTareaUsuario)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtUsuarioSeguimiento_Tarea_Seguimiento").val(sessionStorage.getItem('usersession'));
                    $("#txtidtareaseguimiento_Tarea_Seguimiento").val('');
                    $("#txtid_tarea_Tarea_Seguimiento").val(id_tarea);
                    $( "#dtfecharealiza_Tarea_Seguimiento" ).prop( "disabled", true );
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


function ValidatePostUpdateModalSeguimientoTareaUsuarioForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelSeguimientoTareaUsuario)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableTareasUsuario();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })


}

function VerDetalleSeguimientoTareaUsuario(id_tarea, seguimiento) {    
    if (seguimiento != "null") {
        document.getElementById("dvDetalleSeguimientoTareaUsuario").innerText = seguimiento;    
    }
    else {
        document.getElementById("dvDetalleSeguimientoTareaUsuario").innerText = 'TAREA SIN SEGUIMIENTOS REGISTRADOS';
    }
    
}

function CerrarEstadoAvanceTareaUsuarioDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelEstadoAvanceTareaUsuario);
  
}

function EstadoAvanceTareaUsuario(id_tarea) {
    ObjModelEstadoAvanceTareaUsuario = new Tarea_EstadoAvanceModel();

    CreateHTMLFromModel(ObjModelEstadoAvanceTareaUsuario)
      .then(htmlcreado => {
          LoadData_ToModel(ObjModelEstadoAvanceTareaUsuario, id_tarea)
          .then(datoscargados => {
              if (datoscargados) { 
                  $("#txtusuario_Tarea_EstadoAvance").val(sessionStorage.getItem('usersession'));
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

function ValidatePostUpdateModalEstadoAvanceTareaUsuarioForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelEstadoAvanceTareaUsuario)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableTareasUsuario();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })


}

/*****  PARA GESTION DE NOTIFICACIONES SEGUIMIENTO */
function CrearNotificacionSeguimientoUsuario(opcion, consecutivo) {
    ObjModelAlerta_SeguimientoUsuario = new Alerta_Seguimiento();
    
    CreateHTMLFromModel(ObjModelAlerta_SeguimientoUsuario)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelAlerta_SeguimientoUsuario)
            .then(datospreparados => {
                if (datospreparados) { 
                    document.getElementById("ModalLabelGenerarAlertaUsuario").innerText = 'Notificación Seguimiento para: ' + opcion;
                    $("#txtidalertaseguimiento_Alerta_Seguimiento").val('');
                    $("#txtopcion_Alerta_Seguimiento").val(opcion);
                    $("#txtusuario_Alerta_Seguimiento").val(sessionStorage.getItem('usersession'));
                    $("#txtestado_Alerta_Seguimiento").val('ABIERTA');
                    $("#txtconsecutivo_Alerta_Seguimiento").val(consecutivo);
                    $( "#txtconsecutivo_Alerta_Seguimiento" ).prop( "disabled", true );
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

function CrearNotificacionSeguimientoUsuarioGeneral() {
    ObjModelAlerta_SeguimientoUsuarioGeneral = new Alerta_SeguimientoGeneral();
    
    CreateHTMLFromModel(ObjModelAlerta_SeguimientoUsuarioGeneral)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelAlerta_SeguimientoUsuarioGeneral)
            .then(datospreparados => {
                if (datospreparados) { 
                    document.getElementById("ModalLabelGenerarAlertaUsuarioGeneral").innerText = 'Crear Notificación Seguimiento';
                    $("#txtidalertaseguimiento_Alerta_SeguimientoGeneral").val('');
                    $("#txtopcion_Alerta_SeguimientoGeneral").val('');
                    $("#txtusuario_Alerta_SeguimientoGeneral").val(sessionStorage.getItem('usersession'));
                    $("#txtestado_Alerta_SeguimientoGeneral").val('ABIERTA');
                    $("#txtconsecutivo_Alerta_SeguimientoGeneral").val('');
                    //$( "#txtconsecutivo_Alerta_Seguimiento" ).prop( "disabled", true );
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

function ValidatePostUpdateModalGenerarAlertaUsuarioForm(formF, botonClose) {
    ValidatePostUpdateModel_EdicionForm(ObjModelAlerta_SeguimientoUsuario)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefrescarNotificacionesUsuario();        
        ShowModalDialog('Alerta Segumiento Creada', false, 'success', '', 0);       

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })
}

function ValidatePostUpdateModalGenerarAlertaUsuarioGeneralForm(formF, botonClose) {
    ValidatePostUpdateModel_EdicionForm(ObjModelAlerta_SeguimientoUsuarioGeneral)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefrescarNotificacionesUsuario();
        RefreshDataTableAlerta_SeguimientoUsuario();
        ShowModalDialog('Alerta Segumiento Creada', false, 'success', '', 0);       

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })
}

function ValidarDescartarAlertaSeguimientoUsuario(idalertaseguimiento) {
    
        ShowDialogConfirmacion('','Seguro de descartar la alerta de seguimiento ?', 'Sí, descartar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                DescartarAlertaSeguimientoUsuario(idalertaseguimiento);
            }
        });
}

function DescartarAlertaSeguimientoUsuario(idalertaseguimiento) {
    let urlDescartar = urlController + "Alerta_Seguimiento/UpdateAlerta_SeguimientoCerrar?idalertaseguimiento=" + idalertaseguimiento;
    StartLoader();

    fetch(urlDescartar, {
        method: 'POST',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefrescarNotificacionesUsuario();

            if (DataTableAlerta_SeguimientoUsuario != null) {
                RefreshDataTableAlerta_SeguimientoUsuario();
            }
            
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

function MostrarTabAlertas() {
    let idtabalertas = 9999;
    $("#dvTabsPrincipal ul li #nav" + idtabalertas).removeClass('ocultar');
    $("#dvTabsPrincipal div #tab" + idtabalertas).removeClass('ocultar');       

    onclickTab(idtabalertas);
    InicializaAlerta_SeguimientoUsuarioForm();
}

function RefrescarNotificacionesUsuario() {
    let urlGetNotificaciones = urlController + 'Alerta_Seguimiento/GetAlerta_SeguimientoByUsuarioEstado?usuario=' + sessionStorage.getItem('usersession') + '&estado=ABIERTA'
    $("#dvnotificacionesusuario").removeClass("ocultar");   
    document.getElementById("lblnronotificacionesusuario").innerText = "0";    
    let htmlnotificaciones = '';
    
    StartLoader();    

    fetch(urlGetNotificaciones, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
    .then(data => {
      if (data.Ok) {                      
          let datos = data.Data;
          let numfila = 0;
          document.getElementById("lblnronotificacionesusuario").innerText = datos.length;      
          
          datos.forEach(element => {
            if (numfila < 5) {  //SOLO MUESTRA LOS 5 PRIMEROS
                numfila += 1;
                htmlnotificaciones += '<li>';
                htmlnotificaciones += '<div class="notification_wrapper">';
                htmlnotificaciones += '<div class="notification-menu">';
                htmlnotificaciones += '<div class="notification-title" title="' + element.observaciones + '">';
                htmlnotificaciones += '<label class="cambiarMouse notification-label">' + element.tituloalerta + '</label>';
                htmlnotificaciones += '</div>';
                htmlnotificaciones += '<div class="notification-description">Seguimiento ' + element.opcion + '\n Consecutivo ' + element.consecutivo + '</div>';
                htmlnotificaciones += '<div class="notification-due">Vence en ' + element.fechavence.slice(0,10) + '</div>';
                htmlnotificaciones += '</div>';
    
                htmlnotificaciones += '<div class="notification-dismissIcon" role="button" aria-label="Descartar Alerta" title="Descartar alerta">';
                htmlnotificaciones += '<img src="/images/iris/trash.png" onclick="ValidarDescartarAlertaSeguimientoUsuario(' + element.idalertaseguimiento + ');"/>';
                htmlnotificaciones += '</div>';
    
                htmlnotificaciones += '</div>';
                htmlnotificaciones += '</li>';
                htmlnotificaciones += '<li class="dropdown-divider"></li>';    
            }
          });

          if (datos.length > 0) {
            htmlnotificaciones += '<li>';
            htmlnotificaciones += '<div class="text-center link-block form-label-iris">';
            htmlnotificaciones += '<a class="dropdown-item" href="#">';
            htmlnotificaciones += '<strong onclick="MostrarTabAlertas();">Ver Todas las alertas</strong>';
            htmlnotificaciones += '<i class="fa fa-angle-right"></i>';
            htmlnotificaciones += '</li>';
          }

          document.getElementById("listanotificacionesusuario").innerHTML = htmlnotificaciones;          

          FinalizeLoader();
                        
          //resolve(true);
      }
      else {
          FinalizeLoader();
          ShowModalDialog(data.Message, false, 'warning', '', 0);          
          //resolve(false);                                  
      }                
    })
    .catch (err => { 
        FinalizeLoader();        
        ShowModalDialog('Carrgando notificaciones usuario ' + err, false, 'error', '', 0);
        //reject (err);
    })         

    
}

function InicializaAlerta_SeguimientoUsuarioForm() {
    if (DataTableAlerta_SeguimientoUsuario == null) {
        LoadDataTableAlerta_SeguimientoUsuario();
    }
    else {
        RefreshDataTableAlerta_SeguimientoUsuario();
    }
}

function LoadDataTableAlerta_SeguimientoUsuario() {
    EstadoAlertaSeguimientoFiltro = "ABIERTA";
    $('#cboFiltroAlertaSeguimientoUsuario').select2();

    DataTableAlerta_SeguimientoUsuario = $('#tblAlertasSeguimientoUsuario').DataTable({
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
            if (data.estado == "CERRADA") {
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
            "url": urlController + "Alerta_Seguimiento/GetDataTableAlerta_SeguimientoByFuncionarioEstado",// "Tareas/GetDataTableTareasByFuncionarioEstado?idfuncionario=6&id_estadotarea=0",
            "data": {
                "usuario": function() { return sessionStorage.getItem('usersession') } ,
                "estado": function() { return EstadoAlertaSeguimientoFiltro } 
            }
        },      
        "columns": [                        
            { "data": "fechavence", "orderable": true, render: function (data, type, row, meta) {return row.fechavence.slice(0,10)} },
            { "data": "opcion", "orderable": false },                        
            { "data": "consecutivo", "orderable": true },                        
            { "data": "tituloalerta", "orderable": true },                        
            { "data": "estado", "orderable": false },
            { "data": "DiasVence", "orderable": false }, 
            { "data": "fechafinaliza", "orderable": false, render: function (data, type, row, meta) { return (row.fechafinaliza == null) ? "" : row.fechafinaliza.slice(0,10)} },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/trash.png" class="cambiarMouse" title="Descartar Alerta" onclick="ValidarDescartarAlertaSeguimientoUsuario(' + row.idalertaseguimiento + ');" /> ' ;
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 3,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableAlerta_SeguimientoUsuario() {
    DataTableAlerta_SeguimientoUsuario.ajax.reload(null, false);    
}

function ActualizarFiltroDataTableAlerta_SeguimientoUsuario() {    
    EstadoAlertaSeguimientoFiltro = $('#cboFiltroAlertaSeguimientoUsuario').val();
    RefreshDataTableAlerta_SeguimientoUsuario();
}
