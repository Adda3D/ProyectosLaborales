var DataTableProyectoInvestigacionObligaciones = null;
var ObjModelProyectoInvestigacionObligaciones = null;

$(document).ready(function () {
    ObjModelProyectoInvestigacionObligaciones = new Investigacion_Obligacion();

    InicializaProyectoInvestigacionObligacionesform();
});

function InicializaProyectoInvestigacionObligacionesform() {
    $("#txtHermesPRJINVObligaciones").val($("#spanHermesProyectoInvestigacion")[0].innerText);
    $("#txtQuipuPRJINVObligaciones").val($("#spanQuipuProyectoInvestigacion")[0].innerText);
    $("#txtNombrePRJINVObligaciones").val($("#spanNombreProyectoInvestigacion")[0].innerText);
    
    if (DataTableProyectoInvestigacionObligaciones != null) {
        DataTableProyectoInvestigacionObligaciones.destroy();
    }

    LoadDataTableProyectoInvestigacionObligaciones();

    $("#dvProyectoInvestigacionTable").addClass("ocultar");    
    $("#dvProyectoInvestigacionTablaObligaciones").removeClass("ocultar");
}

function VolverTablaProyectoInvestigacionDesdeObligacionesForm() {
    $("#dvProyectoInvestigacionTablaObligaciones").addClass("ocultar");    
    $("#dvProyectoInvestigacionTable").removeClass("ocultar");
}

function CerrarProyectoInvestigacionObligacionesDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelProyectoInvestigacionObligaciones); 
}
  
function LoadDataTableProyectoInvestigacionObligaciones() {
    DataTableProyectoInvestigacionObligaciones = $('#tblProyectoInvestigacionObligaciones').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,        
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_Obligacion/GetDataTableInvestigacion_ObligacionByProyecto", //?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText
            "data": {
                "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText }                
            }
        },      
        "columns": [                        
            { "data": "obligacion", "orderable": true },            
            { "data": "EstadoObligacion", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarProyectoInvestigacionObligaciones(' + row.id_proyectoobligacion + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoInvestigacionObligaciones" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Obligación" onclick="ValidarEliminarProyectoInvestigacionObligaciones(' + row.id_proyectoobligacion + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoInvestigacionObligaciones() {
    DataTableProyectoInvestigacionObligaciones.ajax.reload(null, false);    
}
  
function CrearProyectoInvestigacionObligaciones() {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionObligaciones)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoInvestigacionObligaciones)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_proyectoobligacion_Investigacion_Obligacion").val('');
                    $("#txtid_crearproyecto_Investigacion_Obligacion").val($("#spanIdProyectoInvestigacion")[0].innerText);
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

function CrearProyectoInvestigacionObligaciones1() {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionObligaciones)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoInvestigacionObligaciones)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_proyectoobligacion_Investigacion_Obligacion").val('');
                    $("#txtid_crearproyecto_Investigacion_Obligacion").val($("#spanIdProyectoInvestigacion")[0].innerText);
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

function EditarProyectoInvestigacionObligaciones(idproyectoobligacion) {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionObligaciones)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelProyectoInvestigacionObligaciones, idproyectoobligacion)
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

function ValidatePostUpdateProyectoInvestigacionObligacionesForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoInvestigacionObligaciones)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        CerrarProyectoInvestigacionObligacionesDesdeEdicion();

        RefreshDataTableProyectoInvestigacionObligaciones();
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarProyectoInvestigacionObligaciones(IdObligacion) {
    ShowDialogConfirmacion('','Seguro de eliminar datos obligación ?', 'Sí, eliminar', 'No, cancelar')
    .then(borrar => {
        if (borrar) {
            EliminarProyectoInvestigacionObligaciones(IdObligacion);
        }
    });

}

function EliminarProyectoInvestigacionObligaciones(IdObligacion) {
    let urlEliminar = urlController + "Investigacion_Obligacion/DeleteInvestigacion_Obligacion?id_proyectoobligacion=" + IdObligacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoInvestigacionObligaciones();
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

