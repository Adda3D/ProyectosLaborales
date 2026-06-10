var DataTablePublicaciones_DivulgacionMediosInvitados = null;
var ObjModelPublicaciones_DivulgacionMediosInvitados = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionMediosInvitados = new Publicaciones_DivulgacionActividadInvitados();

    LoadPublicaciones_DivulgacionMediosInvitados();
});

function LoadPublicaciones_DivulgacionMediosInvitados() {
    if (DataTablePublicaciones_DivulgacionMediosInvitados != null) {
        DataTablePublicaciones_DivulgacionMediosInvitados.destroy();
    }

    DataTablePublicaciones_DivulgacionMediosInvitados = $('#tblPublicaciones_DivulgacionMediosInvitados').DataTable({
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
            "url": urlController + "Publicaciones_DivulgacionActividadInvitados/GetDataTablePublicaciones_DivulgacionActividadInvitadosByPublicacion", //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }                        
        },      
        "columns": [
            { "data": "nombrecompleto", "orderable": true },
            { "data": "institucion", "orderable": true },
            { "data": "email", "orderable": true },
            { "data": "telefono", "orderable": true },
            { "data": "divulgacionnombre", "orderable": false, render: function ( data, type, row ) {
                if ( type === 'display' ) {
                  if(data ==1){
                    return '<input type="checkbox" checked class="notclick">';                    
                  }else{
                    return '<input type="checkbox" class="notclick">';
                  }
                }
                return data;
              }, className: "dt-body-center" },
            { "data": "divulgacionfoto", "orderable": false, render: function ( data, type, row ) {
                if ( type === 'display' ) {
                  if(data ==1){
                    return '<input type="checkbox" checked class="notclick">';                    
                  }else{
                    return '<input type="checkbox" class="notclick">';
                  }
                }
                return data;
              }, className: "dt-body-center" },
            { "data": "divulgacionperfil", "orderable": false, render: function ( data, type, row ) {
                if ( type === 'display' ) {
                  if(data ==1){
                    return '<input type="checkbox" checked class="notclick">';
                  }else{
                    return '<input type="checkbox" class="notclick">';
                  }
                }
                return data;
              }, className: "dt-body-center" },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_DivulgacionMediosInvitados(' + row.id_invitados + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionMediosInvitados" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Invitado" onclick="ValidarEliminarPublicaciones_DivulgacionMediosInvitados(' + row.id_invitados + ',`' + row.nombrecompleto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionMediosInvitados() {
    DataTablePublicaciones_DivulgacionMediosInvitados.ajax.reload(null, false);    
}

function CerrarPublicaciones_DivulgacionMediosInvitadosDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DivulgacionMediosInvitados);  
}
  
function CrearPublicaciones_DivulgacionMediosInvitados() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionMediosInvitados)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionMediosInvitados)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_invitados_Publicaciones_DivulgacionActividadInvitados").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionActividadInvitados").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DivulgacionMediosInvitados(id_invitados) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionMediosInvitados)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionMediosInvitados, id_invitados)
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


function ValidatePostUpdatePublicaciones_DivulgacionMediosInvitadosForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionMediosInvitados)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionMediosInvitados();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DivulgacionMediosInvitados(id_invitados, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar invitado ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionMediosInvitados(id_invitados);
            }
        });

}

function EliminarPublicaciones_DivulgacionMediosInvitados(id_invitados) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionActividadInvitados/DeletePublicaciones_DivulgacionActividadInvitados?id_invitados=" + id_invitados;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DivulgacionMediosInvitados();
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
