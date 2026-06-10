var DataTableProyectoInvestigacionProductos = null;
var ObjModelProyectoInvestigacionProductos = null;

$(document).ready(function () {
    ObjModelProyectoInvestigacionProductos = new Investigacion_Producto();

    InicializaProyectoInvestigacionProductosform();
});

function InicializaProyectoInvestigacionProductosform() {
    $("#txtHermesPRJINVProductos").val($("#spanHermesProyectoInvestigacion")[0].innerText);
    $("#txtQuipuPRJINVProductos").val($("#spanQuipuProyectoInvestigacion")[0].innerText);
    $("#txtNombrePRJINVProductos").val($("#spanNombreProyectoInvestigacion")[0].innerText);
    
    if (DataTableProyectoInvestigacionProductos != null) {
        DataTableProyectoInvestigacionProductos.destroy();
    }

    LoadDataTableProyectoInvestigacionProductos();

    $("#dvProyectoInvestigacionTable").addClass("ocultar");    
    $("#dvProyectoInvestigacionTablaProductos").removeClass("ocultar");
}

function VolverTablaProyectoInvestigacionDesdeProductosForm() {
    $("#dvProyectoInvestigacionTablaProductos").addClass("ocultar");    
    $("#dvProyectoInvestigacionTable").removeClass("ocultar");
}
  
function LoadDataTableProyectoInvestigacionProductos() {
    DataTableProyectoInvestigacionProductos = $('#tblProyectoInvestigacionProductos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,        
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_Producto/GetDataTableInvestigacion_ProductoByProyecto",  //?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText
            "data": {
                "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText }                
            }
        },      
        "columns": [                        
            { "data": "descripcion", "orderable": true },
            { "data": "TipoProducto", "orderable": false },
            { "data": "cantidad", "orderable": false },
            { "data": "cumplidos", "orderable": false },
            { "data": "fechafin", "orderable": false, render: function (data, type, row, meta) {return row.fechafin.slice(0,10)} },
            { "data": "EstadoProducto", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarProyectoInvestigacionProductos(' + row.id_producto + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoInvestigacionProductos" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Producto" onclick="ValidarEliminarProyectoInvestigacionProductos(' + row.id_producto + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 2,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '') 
            },
            { "targets": 3,
            className: 'dt-body-right',
           render: DataTable.render.number(',', '.', 0, '') 
            }            
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoInvestigacionProductos() {
    DataTableProyectoInvestigacionProductos.ajax.reload(null, false);    
}
  
function CrearProyectoInvestigacionProductos() {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionProductos)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoInvestigacionProductos)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_producto_Investigacion_Producto").val('');
                    $("#txtid_crearproyecto_Investigacion_Producto").val($("#spanIdProyectoInvestigacion")[0].innerText);
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

function EditarProyectoInvestigacionProductos(id_producto) {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionProductos)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelProyectoInvestigacionProductos, id_producto)
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

function ValidatePostUpdateProyectoInvestigacionProductosForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoInvestigacionProductos)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       
        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableProyectoInvestigacionProductos();
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarProyectoInvestigacionProductos(id_producto) {
    ShowDialogConfirmacion('','Seguro de eliminar datos producto ?', 'Sí, eliminar', 'No, cancelar')
    .then(borrar => {
        if (borrar) {
            EliminarProyectoInvestigacionProductos(id_producto);
        }
    });

}

function EliminarProyectoInvestigacionProductos(id_producto) {
    let urlEliminar = urlController + "Investigacion_Producto/DeleteInvestigacion_Producto?id_producto=" + id_producto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoInvestigacionProductos();
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

