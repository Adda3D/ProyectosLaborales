var DataTablePublicaciones_DepositoControlInventarioMovimientos = null;
var ObjModelPublicaciones_DepositoControlInventarioMovimientos = null;

$(document).ready(function () {
    ObjModelPublicaciones_DepositoControlInventarioMovimientos = new Publicaciones_DepositoControlInventarioMovimientos();    

    LoadPublicaciones_DepositoControlInventarioMovimientos();
});

function LoadPublicaciones_DepositoControlInventarioMovimientos() {
    if (DataTablePublicaciones_DepositoControlInventarioMovimientos != null) {
        DataTablePublicaciones_DepositoControlInventarioMovimientos.destroy();
    }

    DataTablePublicaciones_DepositoControlInventarioMovimientos = $('#tblPublicaciones_DepositoControlInventarioMovimientos').DataTable({
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
            "url": urlController + "Publicaciones_DepositoControlInventarioMovimientos/GetDataTablePublicaciones_DepositoControlInventarioMovimientosByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [
            { "data": "id_movimientos", "orderable": true },
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "NombreBodega", "orderable": false },
            { "data": "TipoMovimiento", "orderable": false },
            { "data": "cantidad", "orderable": false },
            { "data": "descripciondt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Ajuste" onclick="ValidarEliminarPublicaciones_DepositoControlInventarioMovimientos(' + row.id_movimientos + ',`' + row.NombreBodega + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 4,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '') 
            },
            { "targets": 5,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.descripcion + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DepositoControlInventarioMovimientos() {
    DataTablePublicaciones_DepositoControlInventarioMovimientos.ajax.reload(null, false);    
}

function CerrarPublicaciones_DepositoControlInventarioMovimientosDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DepositoControlInventarioMovimientos);  
}
  
function CrearPublicaciones_DepositoControlInventarioMovimientos() {

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoControlInventarioMovimientos)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoControlInventarioMovimientos)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_movimientos_Publicaciones_DepositoControlInventarioMovimientos").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DepositoControlInventarioMovimientos").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DepositoControlInventarioMovimientos(iddisposicionlegal) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoControlInventarioMovimientos)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DepositoControlInventarioMovimientos, iddisposicionlegal)
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


function ValidatePostUpdatePublicaciones_DepositoControlInventarioMovimientosForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoControlInventarioMovimientos)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoControlInventarioMovimientos();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DepositoControlInventarioMovimientos(id_movimientos, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ajuste ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoControlInventarioMovimientos(id_movimientos);
            }
        });

}

function EliminarPublicaciones_DepositoControlInventarioMovimientos(id_movimientos) {
    let urlEliminar = urlController + "Publicaciones_DepositoControlInventarioMovimientos/DeletePublicaciones_DepositoControlInventarioMovimientos?id_movimientos=" + id_movimientos;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DepositoControlInventarioMovimientos();
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

