var DataTableConvocatoria_RequerimientoRequisito = null;
var ObjModelConvocatoria_RequerimientoRequisito = null;

$(document).ready(function () {    
    ObjModelConvocatoria_RequerimientoRequisito = new Convocatoria_RequerimientoRequisito();

    InicializaConvocatoria_RequerimientoRequisitoform($("#spanIdConvocatoria")[0].innerText, $("#spanTituloConvocatoria")[0].innerText);

});


function LoadDataTableConvocatoria_RequerimientoRequisito() {
    DataTableConvocatoria_RequerimientoRequisito = $('#tblConvocatoria_RequerimientoRequisito').DataTable({
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
            "url": urlController + "Convocatoria_RequerimientoRequisito/GetDataTableConvocatoria_RequerimientoRequisitoByConvocatoria", //?id_convocatoria=" + $("#spanIdConvocatoria")[0].innerText
            "data": {
                "id_convocatoria": function() { return $("#spanIdConvocatoria")[0].innerText }                
            }                        
        },      
        "columns": [                    
            { "data": "nmrequisito", "orderable": true },
            { "data": "linkdocumento", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Recurso" onclick="ValidarEliminarConvocatoria_RequerimientoRequisito(' + row.id_requisito + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableConvocatoria_RequerimientoRequisito() {
    DataTableConvocatoria_RequerimientoRequisito.ajax.reload(null, false);
}

function VolverTablaConvocatoria_RequerimientoRequisitoDesdeRequisitos() {
    $("#dvConvocatoria_RequerimientoRequisito").addClass("ocultar");    
    $("#dvConvocatoriaTable").removeClass("ocultar");
    
}

function CerrarConvocatoria_RequerimientoRequisito() {
    DestruirCamposSelect_Model(ObjModelConvocatoria_RequerimientoRequisito);
}

function InicializaConvocatoria_RequerimientoRequisitoform(id_convocatoria, tituloconvocatoria,) {
    debugger;
    $("#txtTituloConvocatoria_RequerimientoRequisito").val(tituloconvocatoria);    
 // $("#txtDependenciaConvocatoria_RequerimientoRequisito").val(nombredependencia);
    
    if (DataTableConvocatoria_RequerimientoRequisito != null) {
        DataTableConvocatoria_RequerimientoRequisito.destroy();
    }

    LoadDataTableConvocatoria_RequerimientoRequisito(); 

    $("#dvConvocatoriaTable").addClass("ocultar");    
    $("#dvConvocatoria_RequerimientoRequisito").removeClass("ocultar");
}

function CrearConvocatoria_RequerimientoRequisito() {

    CreateHTMLFromModel(ObjModelConvocatoria_RequerimientoRequisito)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelConvocatoria_RequerimientoRequisito)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_requisito_Convocatoria_RequerimientoRequisito").val('');
                    $("#txtid_convocatoria_Convocatoria_RequerimientoRequisito").val($("#spanIdConvocatoria")[0].innerText);

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

function ValidatePostUpdateConvocatoria_RequerimientoRequisitoForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelConvocatoria_RequerimientoRequisito)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableConvocatoria_RequerimientoRequisito();
        CerrarConvocatoria_RequerimientoRequisito();     
        
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


function ValidarEliminarConvocatoria_RequerimientoRequisito(id_requisito) {
    ShowDialogConfirmacion('','Seguro de eliminar el Requisito', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConvocatoria_RequerimientoRequisito(id_requisito);
            }
        });
}

function EliminarConvocatoria_RequerimientoRequisito(id_requisito) {
    let urlEliminar = urlController + "Convocatoria_RequerimientoRequisito/DeleteConvocatoria_RequerimientoRequisito?id_requisito=" + id_requisito;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConvocatoria_RequerimientoRequisito();
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
