var DataTablePublicaciones_DepositoControlCertVentas = null;
var ObjModelPublicaciones_DepositoControlCertVentas = null;

$(document).ready(function () {
    ObjModelPublicaciones_DepositoControlCertVentas = new Publicaciones_DepositoControlCertVentas();

    LoadPublicaciones_DepositoControlCertVentas();
});

function LoadPublicaciones_DepositoControlCertVentas() {
    if (DataTablePublicaciones_DepositoControlCertVentas != null) {
        DataTablePublicaciones_DepositoControlCertVentas.destroy();
    }


    DataTablePublicaciones_DepositoControlCertVentas = $('#tblPublicaciones_DepositoControlCertVentas').DataTable({
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
            "url": urlController + "Publicaciones_DepositoControlCertVentas/GetDataTablePublicaciones_DepositoControlCertVentasByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [
            { "data": "id_certventas", "orderable": true },
            { "data": "fecenvio", "orderable": true, render: function (data, type, row, meta) {return row.fecenvio.slice(0,10)} },
            { "data": "libroscert", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Certificado" onclick="ValidarEliminarPublicaciones_DepositoControlCertVentas(' + row.id_certventas + ',`' + row.libroscert + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 2,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '') 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DepositoControlCertVentas() {
    DataTablePublicaciones_DepositoControlCertVentas.ajax.reload(null, false);    
}

function CerrarPublicaciones_DepositoControlCertVentasDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DepositoControlCertVentas);  
}
  
function CrearPublicaciones_DepositoControlCertVentas() {

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoControlCertVentas)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoControlCertVentas)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_certventas_Publicaciones_DepositoControlCertVentas").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DepositoControlCertVentas").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DepositoControlCertVentas(iddisposicionlegal) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoControlCertVentas)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DepositoControlCertVentas, iddisposicionlegal)
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


function ValidatePostUpdatePublicaciones_DepositoControlCertVentasForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoControlCertVentas)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoControlCertVentas();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DepositoControlCertVentas(id_certventas, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar certificado ventas?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoControlCertVentas(id_certventas);
            }
        });

}

function EliminarPublicaciones_DepositoControlCertVentas(id_certventas) {
    let urlEliminar = urlController + "Publicaciones_DepositoControlCertVentas/DeletePublicaciones_DepositoControlCertVentas?id_certventas=" + id_certventas;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DepositoControlCertVentas();
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
