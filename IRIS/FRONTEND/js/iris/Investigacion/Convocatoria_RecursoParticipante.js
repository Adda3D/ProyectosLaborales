var DataTableConvocatoria_RecursoParticipante = null;
var ObjModelConvocatoria_RecursoParticipante = null;

$(document).ready(function () {    
    ObjModelConvocatoria_RecursoParticipante = new Convocatoria_RecursoParticipante();

    InicializaConvocatoria_RecursoParticipanteform($("#spanIdConvocatoria")[0].innerText, $("#spanTituloConvocatoria")[0].innerText);

});


function LoadDataTableConvocatoria_RecursoParticipante() {
    DataTableConvocatoria_RecursoParticipante = $('#tblConvocatoria_RecursoParticipante').DataTable({
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
            "url": urlController + "Convocatoria_RecursoParticipante/GetDataTableConvocatoria_RecursoParticipanteByConvocatoria", //?id_convocatoria=" + $("#spanIdConvocatoria")[0].innerText
            "data": {
                "id_convocatoria": function() { return $("#spanIdConvocatoria")[0].innerText }                
            }                        
        },      
        "columns": [                    
            { "data": "nmrecurso", "orderable": true },
            { "data": "valorrecurso", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Recurso" onclick="ValidarEliminarConvocatoria_RecursoParticipante(' + row.id_recursoparticipante + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],        
        "columnDefs": [
            { "targets": 1,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '') 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableConvocatoria_RecursoParticipante() {
    DataTableConvocatoria_RecursoParticipante.ajax.reload(null, false);
}

function VolverTablaConvocatoria_RecursoParticipanteDesdeRecursos() {
    $("#dvConvocatoria_RecursoParticipante").addClass("ocultar");    
    $("#dvConvocatoriaTable").removeClass("ocultar");
    
}

function CerrarConvocatoria_RecursoParticipante() {
    DestruirCamposSelect_Model(ObjModelConvocatoria_RecursoParticipante);
}

function InicializaConvocatoria_RecursoParticipanteform(id_convocatoria, tituloconvocatoria,) {
    debugger;
    $("#txtTituloConvocatoria_RecursoParticipante").val(tituloconvocatoria);    
 // $("#txtDependenciaConvocatoria_RecursoParticipante").val(nombredependencia);
    
    if (DataTableConvocatoria_RecursoParticipante != null) {
        DataTableConvocatoria_RecursoParticipante.destroy();
    }

    LoadDataTableConvocatoria_RecursoParticipante(); 

    $("#dvConvocatoriaTable").addClass("ocultar");    
    $("#dvConvocatoria_RecursoParticipante").removeClass("ocultar");
}

function CrearConvocatoria_RecursoParticipante() {

    CreateHTMLFromModel(ObjModelConvocatoria_RecursoParticipante)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelConvocatoria_RecursoParticipante)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_recursoparticipante_Convocatoria_RecursoParticipante").val('');
                    $("#txtid_convocatoria_Convocatoria_RecursoParticipante").val($("#spanIdConvocatoria")[0].innerText);

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

function ValidatePostUpdateConvocatoria_RecursoParticipanteForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelConvocatoria_RecursoParticipante)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableConvocatoria_RecursoParticipante();
        CerrarConvocatoria_RecursoParticipante();     
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })
  
}


function ValidarEliminarConvocatoria_RecursoParticipante(id_recursoparticipante) {
    ShowDialogConfirmacion('','Seguro de eliminar el Recurso', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConvocatoria_RecursoParticipante(id_recursoparticipante);
            }
        });
}

function EliminarConvocatoria_RecursoParticipante(id_recursoparticipante) {
    let urlEliminar = urlController + "Convocatoria_RecursoParticipante/DeleteConvocatoria_RecursoParticipante?id_recursoparticipante=" + id_recursoparticipante;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConvocatoria_RecursoParticipante();
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
