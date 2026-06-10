var DataTablePublicaciones_DivulgacionHerramientasMailing = null;
var ObjModelPublicaciones_DivulgacionHerramientasMailing = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionHerramientasMailing = new Publicaciones_DivulgacionHerramientaMailing();

    LoadPublicaciones_DivulgacionHerramientasMailing();
});

function LoadPublicaciones_DivulgacionHerramientasMailing() {
    debugger;
    if (DataTablePublicaciones_DivulgacionHerramientasMailing != null) {
        DataTablePublicaciones_DivulgacionHerramientasMailing.destroy();
    }

    DataTablePublicaciones_DivulgacionHerramientasMailing = $('#tblPublicaciones_DivulgacionHerramientasMailing').DataTable({
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
            "url": urlController + "Publicaciones_DivulgacionHerramienta/GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText + "&id_tipomedio=5"
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText },
                "id_tipomedio": function() { return 5 }
            }
        },      
        "columns": [                        
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "numeroenvios", "orderable": false },
            { "data": "Observacionesdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_DivulgacionHerramientasMailing(' + row.id_herramienta + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionHerramientasMailing" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Mailing" onclick="ValidarEliminarPublicaciones_DivulgacionHerramientasMailing(' + row.id_herramienta + ',`' + row.nombre + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 0,
                width: '20%'
            },
            { "targets": 1,
                width: '20%',
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '') 
            },
            { "targets": 2,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            },
            { "targets": 0,
                width: '20%'
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionHerramientasMailing() {
    DataTablePublicaciones_DivulgacionHerramientasMailing.ajax.reload(null, false);    
}
  
function CrearPublicaciones_DivulgacionHerramientasMailing() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasMailing)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasMailing)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_herramienta_Publicaciones_DivulgacionHerramientaMailing").val('');
                    $("#txtid_tipomedio_Publicaciones_DivulgacionHerramientaMailing").val('5');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionHerramientaMailing").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DivulgacionHerramientasMailing(id_herramienta) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasMailing)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasMailing, id_herramienta)
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


function ValidatePostUpdatePublicaciones_DivulgacionHerramientasMailingForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionHerramientasMailing)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionHerramientasMailing();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DivulgacionHerramientasMailing(id_herramienta, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar datos mailing ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionHerramientasMailing(id_herramienta);
            }
        });

}

function EliminarPublicaciones_DivulgacionHerramientasMailing(id_herramienta) {
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
            RefreshPublicaciones_DivulgacionHerramientasMailing();
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
