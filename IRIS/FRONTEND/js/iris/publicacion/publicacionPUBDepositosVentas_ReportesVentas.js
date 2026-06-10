var DataTablePublicaciones_DepositoControlRepVentas = null;
var ObjModelPublicaciones_DepositoControlRepVentas = null;

$(document).ready(function () {
    ObjModelPublicaciones_DepositoControlRepVentas = new Publicaciones_DepositoControlRepVentas();

    LoadPublicaciones_DepositoControlRepVentas();
});

function LoadPublicaciones_DepositoControlRepVentas() {
    if (DataTablePublicaciones_DepositoControlRepVentas != null) {
        DataTablePublicaciones_DepositoControlRepVentas.destroy();
    }

    DataTablePublicaciones_DepositoControlRepVentas = $('#tblPublicaciones_DepositoControlRepVentas').DataTable({
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
            "url": urlController + "Publicaciones_DepositoControlRepVentas/GetDataTablePublicaciones_DepositoControlRepVentasByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [
            { "data": "id_repventas", "orderable": true },
            { "data": "fecreporte", "orderable": true, render: function (data, type, row, meta) {return row.fecreporte.slice(0,10)} },
            { "data": "NombreDistribuidor", "orderable": false },
            { "data": "unidadesvendidas", "orderable": false },
            { "data": "valorventas", "orderable": false },
            { "data": "valorcomision", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Reporte" onclick="ValidarEliminarPublicaciones_DepositoControlRepVentas(' + row.id_repventas + ',`' + row.NombreDistribuidor + '`);" />';
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
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$') 
            },
            { "targets": 5,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$') 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DepositoControlRepVentas() {
    DataTablePublicaciones_DepositoControlRepVentas.ajax.reload(null, false);    
}

function CerrarPublicaciones_DepositoControlRepVentasDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DepositoControlRepVentas);  
}
  
function CrearPublicaciones_DepositoControlRepVentas() {

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoControlRepVentas)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoControlRepVentas)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_repventas_Publicaciones_DepositoControlRepVentas").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DepositoControlRepVentas").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DepositoControlRepVentas(iddisposicionlegal) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoControlRepVentas)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DepositoControlRepVentas, iddisposicionlegal)
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


function ValidatePostUpdatePublicaciones_DepositoControlRepVentasForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoControlRepVentas)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoControlRepVentas();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DepositoControlRepVentas(id_repventas, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar reporte ventas de ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoControlRepVentas(id_repventas);
            }
        });

}

function EliminarPublicaciones_DepositoControlRepVentas(id_repventas) {
    let urlEliminar = urlController + "Publicaciones_DepositoControlRepVentas/DeletePublicaciones_DepositoControlRepVentas?id_repventas=" + id_repventas;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DepositoControlRepVentas();
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
