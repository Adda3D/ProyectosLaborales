var DataTablePublicaciones_DivulgacionCierreRetroInvitados = null;
var ObjModelPublicaciones_DivulgacionCierreRetroInvitados = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionCierreRetroInvitados = new Publicaciones_DivulgacionActividadInvitadosCierre();

    LoadPublicaciones_DivulgacionCierreRetroInvitados();
});

function LoadPublicaciones_DivulgacionCierreRetroInvitados() {
    if (DataTablePublicaciones_DivulgacionCierreRetroInvitados != null) {
        DataTablePublicaciones_DivulgacionCierreRetroInvitados.destroy();
    }

    DataTablePublicaciones_DivulgacionCierreRetroInvitados = $('#tblPublicaciones_DivulgacionCierreRetroInvitados').DataTable({
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
            "url": urlController + "Publicaciones_DivulgacionActividadInvitados/GetDataTablePublicaciones_DivulgacionActividadInvitadosByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [
            { "data": "nombrecompleto", "orderable": true },            
            { "data": "email", "orderable": true },            
            { "data": "agradecimientoevento", "orderable": false, render: function ( data, type, row ) {
                if ( type === 'display' ) {
                  if(data ==1){
                    return '<input type="checkbox" checked class="notclick">';                    
                  }else{
                    return '<input type="checkbox" class="notclick">';
                  }
                }
                return data;
              }, className: "dt-body-center" },
            { "data": "Notasdt", "orderable": false },              
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Validación Invitado" onclick="EditarPublicaciones_DivulgacionCierreRetroInvitados(' + row.id_invitados + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionCierreRetroInvitados" /> ';
                           
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 3,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.agradecimientonotas + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionCierreRetroInvitados() {
    DataTablePublicaciones_DivulgacionCierreRetroInvitados.ajax.reload(null, false);    
}
  
function EditarPublicaciones_DivulgacionCierreRetroInvitados(id_invitados) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionCierreRetroInvitados)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionCierreRetroInvitados, id_invitados)
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


function ValidatePostUpdatePublicaciones_DivulgacionCierreRetroInvitadosForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionCierreRetroInvitados)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionCierreRetroInvitados();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

