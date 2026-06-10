var DataTableRolesUsuario = null;
var ObjModelRolesUsuario = null;

$(document).ready(function () {
    ObjModelRolesUsuario = new RolUsuario();

    LoadRolesUsuario();
});

function LoadRolesUsuario() {
    DataTableRolesUsuario = $('#tblRolesUsuario').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Rol/GetDataTableRol"
        },      
        "columns": [
            { "data": "nombre", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    if (row.idrol != 1) {
                        return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarRolesUsuario(' + row.idrol + ')" data-bs-toggle="modal" data-bs-target="#ModalRolesUsuario" /> ' +
                        '<img src="../images/iris/menuopciones.png" class="cambiarMouse" title="Configurar Acceso" onclick="AccesosRolesUsuario(' + row.idrol + ',`' + row.nombre + '`);" />' +
                        '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Rol" onclick="ValidarEliminarRolesUsuario(' + row.idrol + ',`' + row.nombre + '`);" />';
                    }
                    else {
                        return '';
                    }
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshRolesUsuario() {
    DataTableRolesUsuario.ajax.reload(null, false);    
}

function CrearRolesUsuario() {

    CreateHTMLFromModel(ObjModelRolesUsuario)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelRolesUsuario)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtidrol_RolUsuario").val('');   
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

function EditarRolesUsuario(idrol) {   

    CreateHTMLFromModel(ObjModelRolesUsuario)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelRolesUsuario, idrol)
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


function ValidatePostUpdateRolesUsuario(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelRolesUsuario)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshRolesUsuario();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarRolesUsuario(idrol, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar rol ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarRolesUsuario(idrol);
            }
        });

}

function EliminarRolesUsuario(idrol) {
    let urlEliminar = urlController + "Rol/DeleteRol?id_rol=" + idrol;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshRolesUsuario();
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

function AccesosRolesUsuario(idrol, nombre) {
    $("#spanIdRolUsuario")[0].innerText = idrol;    
    $("#spanNombreRolUsuario")[0].innerText = nombre;

    if (!ExisteDivEdicionDatos('dvRolUsuarioAccesos')) {
        CrearDivEdicionDatos('/Pages/seguridad/rolusuarioaccesos.html', 'dvRolUsuarioAccesos');
    }
    else {
        EditarRolUsuarioAccesosForm();
    }

}