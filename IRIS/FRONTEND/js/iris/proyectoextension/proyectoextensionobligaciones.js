var DataTableProyectoExtensionObligaciones = null;

$(document).ready(function () {    
    InicializaObligacionesProyectoExtensionform($("#spanIdProyectoExtension")[0].innerText, $("#spanConsecutivoProyectoExtension")[0].innerText,
                                                $("#spanContratoProyectoExtension")[0].innerText, $("#spanNombreProyectoExtension")[0].innerText);

});


function LoadDataTableProyectoExtensionObligaciones() {
    DataTableProyectoExtensionObligaciones = $('#tblProyectoExtensionObligaciones').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_Obligaciones/GetDataTableProyectos_ObligacionesByProyecto",  //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionObligaciones")[0].innerText
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionObligaciones")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "obligacion", "orderable": true },
            { "data": "strestado", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarObligacionProyectoExtension(' + row.id_proyectoobligaciones + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoExtensionObligacion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Obligación" onclick="ValidarEliminarObligacionProyectoExtension(' + row.id_proyectoobligaciones + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtensionObligaciones() {
    DataTableProyectoExtensionObligaciones.ajax.reload(null, false);
}

function VolverTablaProyectoExtensionDesdeObligaciones() {
    $("#dvProyectoExtensionTablaObligaciones").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function InicializaObligacionesProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionObligaciones")[0].innerText = id_asignacionproyecto; // $("#spanIdProyectoExtension")[0].innerText;

    $("#txtConsProyectoExtensionObligacion").val(consecutivo);
    $("#txtContratoProyectoExtensionObligacion").val(contrato);
    $("#txtNombreProyectoExtensionObligacion").val(nombreproyecto);
    
    if (DataTableProyectoExtensionObligaciones != null) {
        DataTableProyectoExtensionObligaciones.destroy();
    }

    LoadDataTableProyectoExtensionObligaciones(); 

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaObligaciones").removeClass("ocultar");
}

function EditarObligacionesProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
/*
    if ( ! $.fn.DataTable.isDataTable( '#tblProyectoExtensionObligaciones' ) ) {
        $('#example').dataTable();
      }    
*/      
    $("#spanIdProyectoExtensionObligaciones")[0].innerText = id_asignacionproyecto;

    if (DataTableProyectoExtensionObligaciones != null) {
        DataTableProyectoExtensionObligaciones.destroy();
    }
    
    LoadDataTableProyectoExtensionObligaciones();

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaObligaciones").removeClass("ocultar");

}

function CrearObligacionProyectoExtension() {
    $("#spanProyectoExtensionIdObligacion")[0].innerText = '';
    $("#txtObligacionProyectoExtension").val('');

    LoadEstadoObligacionProyecto('cboEstadoObligacionProyectoExtension', true);    

    $('#cboEstadoObligacionProyectoExtension').select2({
        dropdownParent: $('#ModalProyectoExtensionObligacion'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    removeValidationFormByForm('formProyectoExtensionObligacionDatos');    
}

function EditarObligacionProyectoExtension(id_obligacion) {
    removeValidationFormByForm('formProyectoExtensionObligacionDatos'); 
    $("#spanProyectoExtensionIdObligacion")[0].innerText = id_obligacion;
    let urlEditar = urlController + "Proyectos_Obligaciones/GetProyectos_ObligacionesDetails?id_proyectoobligaciones=" + id_obligacion;    
    StartLoader();

    LoadEstadoObligacionProyecto('cboEstadoObligacionProyectoExtension', true);        

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtObligacionProyectoExtension").val(datos.obligacion);
            $('#cboEstadoObligacionProyectoExtension').select2().val(datos.id_estadoobligacion).trigger("change");

            $('#cboEstadoObligacionProyectoExtension').select2({
                dropdownParent: $('#ModalProyectoExtensionObligacion'),
                placeholder: "Seleccione",        
                width: 'resolve'
            });
                    
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

function ValidatePostUpdateProyectoExtensionObligacion(formF, botonCerrar) {
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
                AddUpdateProyectoExtensionObligacion(botonCerrar);
            }
        }
    }    
}

function AddUpdateProyectoExtensionObligacion(botonCerrar) {
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_Obligaciones/UpdateProyectos_Obligaciones";

    objData.id_asignacionproyecto = $("#spanIdProyectoExtensionObligaciones")[0].innerText;
	objData.id_proyectoobligaciones = ($("#spanProyectoExtensionIdObligacion")[0].innerText == '') ? undefined : $("#spanProyectoExtensionIdObligacion")[0].innerText;
	objData.obligacion = $("#txtObligacionProyectoExtension").val();
    objData.id_estadoobligacion = $("#cboEstadoObligacionProyectoExtension").val();

    if (objData.id_proyectoobligaciones == undefined) {
        urlUpdate = urlController + "Proyectos_Obligaciones/InsertProyectos_Obligaciones";        
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

            RefreshDataTableProyectoExtensionObligaciones();
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

function CerrarModalProyectoExtensionObligacion() {
    if ($('#cboEstadoObligacionProyectoExtension').data('select2')) {
        $('#cboEstadoObligacionProyectoExtension').select2('destroy');        
      }    

}

function ValidarEliminarObligacionProyectoExtension(id_obligacion) {
    ShowDialogConfirmacion('','Seguro de eliminar obligación', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarObligacionProyectoExtension(id_obligacion);
            }
        });
}

function EliminarObligacionProyectoExtension(id_obligacion) {
    let urlEliminar = urlController + "Proyectos_Obligaciones/DeleteProyectos_Obligaciones?id_proyectoobligaciones=" + id_obligacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionObligaciones();
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