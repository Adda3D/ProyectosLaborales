var DataTablePublicaciones_DivulgacionMediosAutores = null;
var ObjModelPublicaciones_DivulgacionMediosAutores = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionMediosAutores = new Publicaciones_AutoresLanzamiento();

    LoadPublicaciones_DivulgacionMediosAutores();
});

function LoadPublicaciones_DivulgacionMediosAutores() {
    if (DataTablePublicaciones_DivulgacionMediosAutores != null) {
        DataTablePublicaciones_DivulgacionMediosAutores.destroy();
    }

    DataTablePublicaciones_DivulgacionMediosAutores = $('#tblPublicaciones_DivulgacionMediosAutores').DataTable({
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
            { "data": "CelularAutor", "orderable": false },
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
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Validar Datos Autor" onclick="EditarPublicaciones_DivulgacionMediosAutoreses(' + row.id_autores + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionMediosAutores" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionMediosAutores() {
    DataTablePublicaciones_DivulgacionMediosAutores.ajax.reload(null, false);    
}

function CerrarPublicaciones_DivulgacionMediosAutoresesDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DivulgacionMediosAutores);  
}
  
/*
function CrearPublicaciones_DivulgacionMediosAutoreses() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionMediosAutores)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionMediosAutores)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtiddivulgacionplanactividad_Publicaciones_DivulgacionMediosAutores").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionMediosAutores").val($("#spanIdPublicacion")[0].innerText);
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
*/

function EditarPublicaciones_DivulgacionMediosAutoreses(id_autores) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionMediosAutores)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionMediosAutores, id_autores)
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


function ValidatePostUpdatePublicaciones_DivulgacionMediosAutoresForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionMediosAutores)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionMediosAutores();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

/*
function ValidarEliminarPublicaciones_DivulgacionMediosAutores(iddivulgacionplanactividad, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar actividad ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionMediosAutores(iddivulgacionplanactividad);
            }
        });

}

function EliminarPublicaciones_DivulgacionMediosAutores(iddivulgacionplanactividad) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionMediosAutores/DeletePublicaciones_DivulgacionMediosAutores?iddivulgacionplanactividad=" + iddivulgacionplanactividad;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DivulgacionMediosAutores();
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
*/
