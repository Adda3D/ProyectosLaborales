var DataTablePublicaciones_DivulgacionHerramientasPrensaEscrita = null;
var ObjModelPublicaciones_DivulgacionHerramientasPrensaEscrita = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionHerramientasPrensaEscrita = new Publicaciones_DivulgacionHerramientaPrensaEscrita();

    LoadPublicaciones_DivulgacionHerramientasPrensaEscrita();
});

function LoadPublicaciones_DivulgacionHerramientasPrensaEscrita() {
    debugger;
    if (DataTablePublicaciones_DivulgacionHerramientasPrensaEscrita != null) {
        DataTablePublicaciones_DivulgacionHerramientasPrensaEscrita.destroy();
    }

    DataTablePublicaciones_DivulgacionHerramientasPrensaEscrita = $('#tblPublicaciones_DivulgacionHerramientasPrensaEscrita').DataTable({
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
            "url": urlController + "Publicaciones_DivulgacionHerramienta/GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText + "&id_tipomedio=2"
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText },
                "id_tipomedio": function() { return 2 }
            }
        },      
        "columns": [
            { "data": "nombre", "orderable": true },
            { "data": "lugar", "orderable": true },            
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "enlace", "orderable": true },
            { "data": "Observacionesdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_DivulgacionHerramientasPrensaEscrita(' + row.id_herramienta + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionHerramientasPrensaEscrita" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Publicación" onclick="ValidarEliminarPublicaciones_DivulgacionHerramientasPrensaEscrita(' + row.id_herramienta + ',`' + row.nombre + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 4,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionHerramientasPrensaEscrita() {
    DataTablePublicaciones_DivulgacionHerramientasPrensaEscrita.ajax.reload(null, false);    
}
  
function CrearPublicaciones_DivulgacionHerramientasPrensaEscrita() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaEscrita)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaEscrita)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_herramienta_Publicaciones_DivulgacionHerramientaPrensaEscrita").val('');
                    $("#txtid_tipomedio_Publicaciones_DivulgacionHerramientaPrensaEscrita").val('2');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionHerramientaPrensaEscrita").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DivulgacionHerramientasPrensaEscrita(id_herramienta) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaEscrita)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaEscrita, id_herramienta)
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


function ValidatePostUpdatePublicaciones_DivulgacionHerramientasPrensaEscritaForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionHerramientasPrensaEscrita)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionHerramientasPrensaEscrita();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DivulgacionHerramientasPrensaEscrita(id_herramienta, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar publicación en ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionHerramientasPrensaEscrita(id_herramienta);
            }
        });

}

function EliminarPublicaciones_DivulgacionHerramientasPrensaEscrita(id_herramienta) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionHerramienta/DeletePublicaciones_DivulgacionHerramienta?id_herramienta=" + id_herramienta;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DivulgacionHerramientasPrensaEscrita();
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
