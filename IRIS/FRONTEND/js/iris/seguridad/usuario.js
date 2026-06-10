var DataTableUsuariosApp = null;
var ObjModelUsuariosApp = null;

$(document).ready(function () {
    ObjModelUsuariosApp = new Usuario();

    LoadUsuariosApp();
});

function LoadUsuariosApp() {
    DataTableUsuariosApp = $('#tblUsuariosApp').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Usuario/GetDataTableUsuario"
        },      
        "columns": [
            { "data": "nombrecompleto", "orderable": true },
            { "data": "correoinstitucional", "orderable": true },
            { "data": "NombreRol", "orderable": false },
            { "data": "NombreDependencia", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Usuario" onclick="EditarUsuariosApp(' + row.id_usuario + ')" data-bs-toggle="modal" data-bs-target="#ModalUsuariosApp" /> ' +                        
                        '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Usuario" onclick="ValidarEliminarUsuariosApp(' + row.id_usuario + ',`' + row.nombrecompleto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableUsuariosApp() {
    DataTableUsuariosApp.ajax.reload(null, false);    
}

function CrearUsuariosApp() {

    CreateHTMLFromModel(ObjModelUsuariosApp)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelUsuariosApp)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_usuario_RUsuario").val('');   
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

function EditarUsuariosApp(id_usuario) {   

    CreateHTMLFromModel(ObjModelUsuariosApp)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelUsuariosApp, id_usuario)
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


function ValidatePostUpdateUsuariosApp(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelUsuariosApp)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshDataTableUsuariosApp();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarUsuariosApp(id_usuario, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar usuario ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarUsuariosApp(id_usuario);
            }
        });

}

function EliminarUsuariosApp(id_usuario) {
    let urlEliminar = urlController + "Usuario/DeleteUsuario?id_usuario=" + id_usuario;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableUsuariosApp();
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

