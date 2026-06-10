var DataTablePublicaciones_DivulgacionCierreAutores = null;
var ObjModelPublicaciones_DivulgacionCierreAutores = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionCierreAutores = new Publicaciones_AutoresCierre();

    LoadPublicaciones_DivulgacionCierreAutores();
});

function LoadPublicaciones_DivulgacionCierreAutores() {
    if (DataTablePublicaciones_DivulgacionCierreAutores != null) {
        DataTablePublicaciones_DivulgacionCierreAutores.destroy();
    }

    DataTablePublicaciones_DivulgacionCierreAutores = $('#tblPublicaciones_DivulgacionCierreAutores').DataTable({
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
            "url": urlController + "Publicaciones_Autores/GetDataTablePublicaciones_AutoresByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }
        },      
        "columns": [
            { "data": "NombrePersona", "orderable": false },
            { "data": "EmailAutor", "orderable": false },            
            { "data": "retroalimentacionevento", "orderable": false, render: function ( data, type, row ) {
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
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Retroalimentación Autor" onclick="EditarPublicaciones_DivulgacionCierreAutores(' + row.id_autores + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionCierreAutores" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 3,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.retroalimentacionnotas + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionCierreAutores() {
    DataTablePublicaciones_DivulgacionCierreAutores.ajax.reload(null, false);    
}

function CerrarPublicaciones_DivulgacionCierreAutoresesDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DivulgacionCierreAutores);  
}
  

function EditarPublicaciones_DivulgacionCierreAutores(id_autores) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionCierreAutores)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionCierreAutores, id_autores)
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


function ValidatePostUpdatePublicaciones_DivulgacionCierreAutoresForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionCierreAutores)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionCierreAutores();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

