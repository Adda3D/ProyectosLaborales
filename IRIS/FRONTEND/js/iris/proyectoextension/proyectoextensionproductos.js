var DataTableProyectoExtensionProductos = null;

$(document).ready(function () {    
    InicializaProductosProyectoExtensionform($("#spanIdProyectoExtension")[0].innerText, $("#spanConsecutivoProyectoExtension")[0].innerText,
                                                $("#spanContratoProyectoExtension")[0].innerText, $("#spanNombreProyectoExtension")[0].innerText);

});


function LoadDataTableProyectoExtensionProductos() {
    DataTableProyectoExtensionProductos = $('#tblProyectoExtensionProductos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_NuevoProducto/GetDataTableProyectos_ProductosByProyecto",  //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionProductos")[0].innerText
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionProductos")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "descripcion", "orderable": true },
            { "data": "strtipoproducto", "orderable": false },            
            { "data": "fechaentrega", "orderable": true, render: function (data, type, row, meta) {return row.fechaentrega.slice(0,10)} },
            { "data": "strestadoproducto", "orderable": false },
            { "data": "numpersonas", "orderable": false }, 
            { "data": "numhoras", "orderable": false }, 
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarProductoProyectoExtension(' + row.id_nuevoproducto + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoExtensionProducto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Producto" onclick="ValidarEliminarProductoProyectoExtension(' + row.id_nuevoproducto + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtensionProductos() {
    DataTableProyectoExtensionProductos.ajax.reload(null, false);
}

function VolverTablaProyectoExtensionDesdeProductos() {
    $("#dvProyectoExtensionTablaProductos").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function InicializaProductosProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionProductos")[0].innerText = id_asignacionproyecto; 

    $("#txtConsProyectoExtensionProducto").val(consecutivo);
    $("#txtContratoProyectoExtensionProducto").val(contrato);
    $("#txtNombreProyectoExtensionProducto").val(nombreproyecto);
    
    if (DataTableProyectoExtensionProductos != null) {
        DataTableProyectoExtensionProductos.destroy();
    }

    LoadDataTableProyectoExtensionProductos(); 

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaProductos").removeClass("ocultar");
}

function EditarProductosProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
/*
    if ( ! $.fn.DataTable.isDataTable( '#tblProyectoExtensionProductos' ) ) {
        $('#example').dataTable();
      }    
*/      
    $("#spanIdProyectoExtensionProductos")[0].innerText = id_asignacionproyecto;

    if (DataTableProyectoExtensionProductos != null) {
        DataTableProyectoExtensionProductos.destroy();
    }
    
    LoadDataTableProyectoExtensionProductos();

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaProductos").removeClass("ocultar");

}

function CrearProductoProyectoExtension() {
    $("#spanProyectoExtensionIdProducto")[0].innerText = '';
    $("#txtProductoProyectoExtension").val('');
    $("#nmpersonasproductoProyectoExtension").val('');
    $("#nmhorasproductoProyectoExtension").val('');            
    $('#dtFechaProductoProyectoExtension').val(getFechaActual());

    LoadTipoProductoProyecto('cboTipoProductoProyectoExtension', true);    
    LoadEstadoProductoProyecto('cboEstadoProductoProyectoExtension', true);    

    $('#cboTipoProductoProyectoExtension').select2({
        dropdownParent: $('#ModalProyectoExtensionProducto'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });

    $('#cboEstadoProductoProyectoExtension').select2({
        dropdownParent: $('#ModalProyectoExtensionProducto'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    removeValidationFormByForm('formProyectoExtensionProductoDatos');    
}

function EditarProductoProyectoExtension(id_producto) {
    removeValidationFormByForm('formProyectoExtensionProductoDatos'); 
    $("#spanProyectoExtensionIdProducto")[0].innerText = id_producto;
    let urlEditar = urlController + "Proyectos_NuevoProducto/GetProyectos_NuevoProductoDetails?id_nuevoproducto=" + id_producto;    
    StartLoader();

    LoadTipoProductoProyecto('cboTipoProductoProyectoExtension', false);    
    LoadEstadoProductoProyecto('cboEstadoProductoProyectoExtension', false);    

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtProductoProyectoExtension").val(datos.descripcion);
            $("#nmpersonasproductoProyectoExtension").val(datos.numpersonas);
            $("#nmhorasproductoProyectoExtension").val(datos.numhoras);            
            $('#dtFechaProductoProyectoExtension').val(datos.fechaentrega.slice(0,10));
            
            $('#cboTipoProductoProyectoExtension').select2().val(datos.id_tipoproducto).trigger("change");
            $('#cboEstadoProductoProyectoExtension').select2().val(datos.id_estadoproducto).trigger("change");

            $('#cboTipoProductoProyectoExtension').select2({
                dropdownParent: $('#ModalProyectoExtensionProducto'),
                placeholder: "Seleccione",        
                width: 'resolve'
            });
        
            $('#cboEstadoProductoProyectoExtension').select2({
                dropdownParent: $('#ModalProyectoExtensionProducto'),
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

function ValidatePostUpdateProyectoExtensionProducto(formF, botonCerrar) {
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
                AddUpdateProyectoExtensionProducto(botonCerrar);
            }
        }
    }    
}

function AddUpdateProyectoExtensionProducto(botonCerrar) {
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_NuevoProducto/UpdateProyectos_NuevoProducto";

    objData.id_asignacionproyecto = $("#spanIdProyectoExtensionProductos")[0].innerText;
	objData.id_nuevoproducto = ($("#spanProyectoExtensionIdProducto")[0].innerText == '') ? undefined : $("#spanProyectoExtensionIdProducto")[0].innerText;
	objData.descripcion = $("#txtProductoProyectoExtension").val();
    objData.fechaentrega = $('#dtFechaProductoProyectoExtension').val();    
    objData.numpersonas = $("#nmpersonasproductoProyectoExtension").val();
    objData.numhoras = $("#nmhorasproductoProyectoExtension").val();
    objData.id_tipoproducto = $("#cboTipoProductoProyectoExtension").val();
    objData.id_estadoproducto = $("#cboEstadoProductoProyectoExtension").val();

    if (objData.id_nuevoproducto == undefined) {
        urlUpdate = urlController + "Proyectos_NuevoProducto/InsertProyectos_NuevoProducto";        
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

            RefreshDataTableProyectoExtensionProductos();
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

function CerrarModalProyectoExtensionProducto() {
    if ($('#cboTipoProductoProyectoExtension').data('select2')) {
        $('#cboTipoProductoProyectoExtension').select2('destroy');        
      }    

      if ($('#cboEstadoProductoProyectoExtension').data('select2')) {
        $('#cboEstadoProductoProyectoExtension').select2('destroy');        
      }    

}

function ValidarEliminarProductoProyectoExtension(id_producto) {
    ShowDialogConfirmacion('','Seguro de eliminar producto', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProductoProyectoExtension(id_producto);
            }
        });
}

function EliminarProductoProyectoExtension(id_producto) {
    let urlEliminar = urlController + "Proyectos_NuevoProducto/DeleteProyectos_NuevoProducto?id_nuevoproducto=" + id_producto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionProductos();
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