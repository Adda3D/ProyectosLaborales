var DataTablePublicaciones_DepositoDistribucionComercial = null;
var ObjModelPublicaciones_DepositoDistribucionComercial = null;
var ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion = null;

$(document).ready(function () {
    ObjModelPublicaciones_DepositoDistribucionComercial = new Publicaciones_DepositoDistribucionComercial();
    ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion = new Publicaciones_DepositoDistribucionComercial();

    LoadPublicaciones_DepositoDistribucionComercial();
});

function LoadPublicaciones_DepositoDistribucionComercial() {
    if (DataTablePublicaciones_DepositoDistribucionComercial != null) {
        DataTablePublicaciones_DepositoDistribucionComercial.destroy();
    }

    DataTablePublicaciones_DepositoDistribucionComercial = $('#tblPublicaciones_DepositoDistribucionComercial').DataTable({
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
            "url": urlController + "Publicaciones_DepositoDistribucionComercial/GetDataTablePublicaciones_DepositoDistribucionComercialByPublicacion", //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [
            { "data": "id_distribucioncomercial", "orderable": true },
            { "data": "fechaentrega", "orderable": true, render: function (data, type, row, meta) {return row.fechaentrega.slice(0,10)} },
            { "data": "NombreDistribuidor", "orderable": false },
            { "data": "cantidad", "orderable": false },
            { "data": "notasdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Entrega" onclick="ValidarEliminarPublicaciones_DepositoDistribucionComercial(' + row.id_distribucioncomercial + ',`' + row.NombreDistribuidor + '`);" />';
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

function RefreshPublicaciones_DepositoDistribucionComercial() {
    DataTablePublicaciones_DepositoDistribucionComercial.ajax.reload(null, false);    
}

function CerrarPublicaciones_DepositoDistribucionComercialDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DepositoDistribucionComercial);  
}

function CerrarPublicaciones_DepositoDistribucionComercialDesdeDevolucion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion);
}
  
function CrearPublicaciones_DepositoDistribucionComercial() {
    ObjModelPublicaciones_DepositoDistribucionComercial.SufijoNombreControl = 'ENT';
    ObjModelPublicaciones_DepositoDistribucionComercial.FormEdicion = 'formPublicaciones_DepositoDistribucionComercial';

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDistribucionComercial)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoDistribucionComercial)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_distribucioncomercial_Publicaciones_DepositoDistribucionComercialENT").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DepositoDistribucionComercialENT").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DepositoDistribucionComercial(iddisposicionlegal) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDistribucionComercial)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DepositoDistribucionComercial, iddisposicionlegal)
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


function ValidatePostUpdatePublicaciones_DepositoDistribucionComercialForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoDistribucionComercial)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoDistribucionComercial();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DepositoDistribucionComercial(id_distribucioncomercial, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar entrega para ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoDistribucionComercial(id_distribucioncomercial);
            }
        });

}

function EliminarPublicaciones_DepositoDistribucionComercial(id_distribucioncomercial) {
    let urlEliminar = urlController + "Publicaciones_DepositoDistribucionComercial/DeletePublicaciones_DepositoDistribucionComercial?id_distribucioncomercial=" + id_distribucioncomercial;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DepositoDistribucionComercial();
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


/*--- REGISTRAR DEVOLUCION */

function CrearPublicaciones_DepositoDistribucionComercial_Devolucion() {
    ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion.SufijoNombreControl = 'DEV';
    ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion.FormEdicion = 'formPublicaciones_DepositoDistribucionComercial_Devolucion';
    ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion.MethodInsert = 'InsertPublicaciones_DepositoDistribucionComercial_Devolucion';

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_distribucioncomercial_Publicaciones_DepositoDistribucionComercialDEV").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DepositoDistribucionComercialDEV").val($("#spanIdPublicacion")[0].innerText);
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

function ValidatePostUpdatePublicaciones_DepositoDistribucionComercial_DevolucionForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoDistribucionComercial_Devolucion)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoDistribucionComercial();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
