var DataTablePublicaciones_DepositoDisposicionLegal = null;
var ObjModelPublicaciones_DepositoDisposicionLegal = null;

$(document).ready(function () {
    ObjModelPublicaciones_DepositoDisposicionLegal = new Publicaciones_DepositoDisposicionLegal();

    LoadPublicaciones_DepositoDisposicionLegal();
});

function LoadPublicaciones_DepositoDisposicionLegal() {
    DataTablePublicaciones_DepositoDisposicionLegal = $('#tblPublicaciones_DepositoDisposicionLegal').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DepositoDisposicionLegal/GetDataTablePublicaciones_DepositoDisposicionLegal"
        },      
        "columns": [
            { "data": "disposicionlegal", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_DepositoDisposicionLegal(' + row.iddisposicionlegal + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DepositoDisposicionLegal" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_DepositoDisposicionLegal(' + row.iddisposicionlegal + ',`' + row.disposicionlegal + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DepositoDisposicionLegal() {
    DataTablePublicaciones_DepositoDisposicionLegal.ajax.reload(null, false);    
}

function CrearPublicaciones_DepositoDisposicionLegal() {

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDisposicionLegal)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DepositoDisposicionLegal)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtiddisposicionlegal_Publicaciones_DepositoDisposicionLegal").val('');   
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

function EditarPublicaciones_DepositoDisposicionLegal(iddisposicionlegal) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DepositoDisposicionLegal)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DepositoDisposicionLegal, iddisposicionlegal)
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


function ValidatePostUpdatePublicaciones_DepositoDisposicionLegal(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoDisposicionLegal)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DepositoDisposicionLegal();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DepositoDisposicionLegal(iddisposicionlegal, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoDisposicionLegal(iddisposicionlegal);
            }
        });

}

function EliminarPublicaciones_DepositoDisposicionLegal(iddisposicionlegal) {
    let urlEliminar = urlController + "Publicaciones_DepositoDisposicionLegal/DeletePublicaciones_DepositoDisposicionLegal?iddisposicionlegal=" + iddisposicionlegal;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DepositoDisposicionLegal();
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
