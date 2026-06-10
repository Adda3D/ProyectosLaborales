var DataTablePublicaciones_DepositoDistribucion = null;
var ObjModelPublicaciones_DepositoDistribucion = null;
var ObjModelPublicaciones_DepositoDistribucion_Devolucion = null;

$(document).ready(function () {
    ObjModelPublicaciones_DepositoDistribucion = new Publicaciones_DepositoDistribucion();
    ObjModelPublicaciones_DepositoDistribucion_Devolucion = new Publicaciones_DepositoDistribucion();

    LoadPublicaciones_DepositoDistribucion();
});

function LoadPublicaciones_DepositoDistribucion() {
    if (DataTablePublicaciones_DepositoDistribucion != null) {
        DataTablePublicaciones_DepositoDistribucion.destroy();
    }

    DataTablePublicaciones_DepositoDistribucion = $('#tblPublicaciones_DepositoDistribucion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        searching: false,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DepositoDistribucion/GetDataTablePublicaciones_DepositoDistribucionByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [
            { "data": "id_distribucion", "orderable": true },
            { "data": "fechaentrega", "orderable": true, render: function (data, type, row, meta) {return row.fechaentrega.slice(0,10)} },
            { "data": "NombreDisposicion", "orderable": false },
            { "data": "cantidad", "orderable": false },
            { "data": "notasdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Entrega" onclick="ValidarEliminarPublicaciones_DepositoDistribucion(' + row.id_distribucion + ',`' + row.NombreDisposicion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 3,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '') 
            },
            { "targets": 4,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.notas + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DepositoDistribucion() {
    DataTablePublicaciones_DepositoDistribucion.ajax.reload(null, false);    
}

function CerrarCrearPublicaciones_DepositoDistribucionDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DepositoDistribucion);  
}

function CerrarCrearPublicaciones_DepositoDistribucionDesdeDevolucion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DepositoDistribucion_Devolucion);      
}

function CrearPublicaciones_DepositoDistribucion() {
    ObjModelPublicaciones_DepositoDistribucion.SufijoNombreControl = 'ENT';
    ObjModelPublicaciones_DepositoDistribucion.FormEdicion = 'formPublicaciones_DepositoDistribucion';

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDistribucion)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoDistribucion)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_distribucion_Publicaciones_DepositoDistribucionENT").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DepositoDistribucionENT").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DepositoDistribucion(iddisposicionlegal) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDistribucion)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DepositoDistribucion, iddisposicionlegal)
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


function ValidatePostUpdatePublicaciones_DepositoDistribucionForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoDistribucion)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoDistribucion();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DepositoDistribucion(id_distribucion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar entrega para ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoDistribucion(id_distribucion);
            }
        });

}

function EliminarPublicaciones_DepositoDistribucion(id_distribucion) {
    let urlEliminar = urlController + "Publicaciones_DepositoDistribucion/DeletePublicaciones_DepositoDistribucion?id_distribucion=" + id_distribucion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DepositoDistribucion();
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

/*---- PARA GESTIONAR DEVOLUCIONES */
function CrearPublicaciones_DepositoDistribucion_Devolucion() {
    ObjModelPublicaciones_DepositoDistribucion_Devolucion.SufijoNombreControl = 'DEV';
    ObjModelPublicaciones_DepositoDistribucion_Devolucion.FormEdicion = 'formPublicaciones_DepositoDistribucion_Devolucion';
    ObjModelPublicaciones_DepositoDistribucion_Devolucion.MethodInsert = 'InsertPublicaciones_DepositoDistribucion_Devolucion';

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDistribucion_Devolucion)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoDistribucion_Devolucion)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_distribucion_Publicaciones_DepositoDistribucionDEV").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DepositoDistribucionDEV").val($("#spanIdPublicacion")[0].innerText);
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

function ValidatePostUpdatePublicaciones_DepositoDistribucion_DevolucionForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoDistribucion_Devolucion)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoDistribucion();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
