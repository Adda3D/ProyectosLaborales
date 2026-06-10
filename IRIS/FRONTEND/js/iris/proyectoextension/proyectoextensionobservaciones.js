var DataTableProyectoExtensionObservaciones = null;

$(document).ready(function () {    
    InicializaObservacionesProyectoExtensionform($("#spanIdProyectoExtension")[0].innerText, $("#spanConsecutivoProyectoExtension")[0].innerText,
                                                $("#spanContratoProyectoExtension")[0].innerText, $("#spanNombreProyectoExtension")[0].innerText);

});


function LoadDataTableProyectoExtensionObservaciones() {
    DataTableProyectoExtensionObservaciones = $('#tblProyectoExtensionObservaciones').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_ProyectosObservaciones/GetDataTableProyectos_ObservacionesByProyecto", //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionObservaciones")[0].innerText
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionObservaciones")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "fechaasignacion", "orderable": true, render: function (data, type, row, meta) {return row.fechaasignacion.slice(0,10)}  },
            { "data": "descripcion", "orderable": true },
            { "data": "usuariocreacion", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarObservacionProyectoExtension(' + row.id_proyectosobservaciones + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoExtensionObservacion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Obligación" onclick="ValidarEliminarObservacionProyectoExtension(' + row.id_proyectosobservaciones + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtensionObservaciones() {
    DataTableProyectoExtensionObservaciones.ajax.reload(null, false);
}

function VolverTablaProyectoExtensionDesdeObservaciones() {
    $("#dvProyectoExtensionTablaObservaciones").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function InicializaObservacionesProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionObservaciones")[0].innerText = id_asignacionproyecto; 

    $("#txtConsProyectoExtensionObservacion").val(consecutivo);
    $("#txtContratoProyectoExtensionObservacion").val(contrato);
    $("#txtNombreProyectoExtensionObservacion").val(nombreproyecto);
    
    if (DataTableProyectoExtensionObservaciones != null) {
        DataTableProyectoExtensionObservaciones.destroy();
    }

    LoadDataTableProyectoExtensionObservaciones(); 

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaObservaciones").removeClass("ocultar");
}

function EditarObservacionesProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
/*
    if ( ! $.fn.DataTable.isDataTable( '#tblProyectoExtensionObservaciones' ) ) {
        $('#tblProyectoExtensionObservaciones').dataTable();
      }    
*/      
    $("#spanIdProyectoExtensionObservaciones")[0].innerText = id_asignacionproyecto;

    if (DataTableProyectoExtensionObservaciones != null) {
        DataTableProyectoExtensionObservaciones.destroy();
    }
    
    LoadDataTableProyectoExtensionObservaciones();

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaObservaciones").removeClass("ocultar");

}

function CrearObservacionProyectoExtension() {
    $("#spanProyectoExtensionIdObservacion")[0].innerText = '';    
    $("#dtFechaObservacionProyectoExtension").val(getFechaActual());
    $("#txtObservacionProyectoExtension").val('');
    
    removeValidationFormByForm('formProyectoExtensionObservacionDatos');    
}

function EditarObservacionProyectoExtension(id_observacion) {
    removeValidationFormByForm('formProyectoExtensionObservacionDatos'); 
    $("#spanProyectoExtensionIdObservacion")[0].innerText = id_observacion;
    let urlEditar = urlController + "Proyectos_ProyectosObservaciones/GetProyectos_ProyectosObservacionesDetails?id_proyectosobservaciones=" + id_observacion;    
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#dtFechaObservacionProyectoExtension").val(datos.fechaasignacion.slice(0,10));
            $("#txtObservacionProyectoExtension").val(datos.descripcion);
                    
            FinalizeLoader();
            return;
        }
        else {
            ShowModalDialog(data.Message, false, 'warning', '', 0);
            FinalizeLoader();
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        return;
      } );         
}

function ValidatePostUpdateProyectoExtensionObservacion(formF, botonCerrar) {
    validateTextXSSLastButtonByForm(formF);

    var formV = $("#" + formF);
    if (formV[0].checkValidity() == false) {
        $(formV).addClass('was-validated');
    } else {
        if (checkValidityXSS == false) {
            $(formV).addClass('was-validated');
        } else {
            if (checkValiditySelect == false) {
                $(formV).addClass('was-validated');
            } else {
                AddUpdateProyectoExtensionObservacion(botonCerrar);
            }
        }
    }    
}

function AddUpdateProyectoExtensionObservacion(botonCerrar) {
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_ProyectosObservaciones/UpdateProyectos_ProyectosObservaciones";

    objData.id_asignacionproyecto = $("#spanIdProyectoExtensionObservaciones")[0].innerText;
	objData.id_proyectosobservaciones = ($("#spanProyectoExtensionIdObservacion")[0].innerText == '') ? undefined : $("#spanProyectoExtensionIdObservacion")[0].innerText;
	objData.descripcion = $("#txtObservacionProyectoExtension").val(); 
    objData.fechaasignacion = $("#dtFechaObservacionProyectoExtension").val();
    
    if (objData.id_proyectosobservaciones == undefined) {
        urlUpdate = urlController + "Proyectos_ProyectosObservaciones/InsertProyectos_ProyectosObservaciones";        
    }

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTableProyectoExtensionObservaciones();
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

function CerrarModalProyectoExtensionObservacion() {

}

function ValidarEliminarObservacionProyectoExtension(id_observacion) {
    ShowDialogConfirmacion('','Seguro de eliminar observación', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarObservacionProyectoExtension(id_observacion);
            }
        });
}

function EliminarObservacionProyectoExtension(id_observacion) {
    let urlEliminar = urlController + "Proyectos_ProyectosObservaciones/DeleteProyectos_ProyectosObservaciones?id_proyectosobservaciones=" + id_observacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionObservaciones();
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