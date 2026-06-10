var DataTableConvocatoria_Interesados = null;
var ObjModelConvocatoria_Interesados = null;

$(document).ready(function () {    
    ObjModelConvocatoria_Interesados = new Convocatoria_Interesados();

    InicializaConvocatoria_Interesadosform($("#spanIdConvocatoria")[0].innerText, $("#spanTituloConvocatoria")[0].innerText);

});


function LoadDataTableConvocatoria_Interesados() {
    DataTableConvocatoria_Interesados = $('#tblConvocatoria_Interesados').DataTable({
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
            "url": urlController + "Convocatoria_Interesados/GetDataTableConvocatoria_InteresadosByConvocatoria", //?id_convocatoria=" + $("#spanIdConvocatoria")[0].innerText
            "data": {
                "id_convocatoria": function() { return $("#spanIdConvocatoria")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "nombreinteresado", "orderable": true },
            { "data": "correointeresado", "orderable": false },
            { "data": "consecutivocorreo", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Recurso" onclick="ValidarEliminarConvocatoria_Interesados(' + row.id_interesados + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableConvocatoria_Interesados() {
    DataTableConvocatoria_Interesados.ajax.reload(null, false);
}

function VolverTablaConvocatoria_InteresadosDesdeInteresados() {
    $("#dvConvocatoria_Interesados").addClass("ocultar");    
    $("#dvConvocatoriaTable").removeClass("ocultar");
    
}

function CerrarConvocatoria_Interesados() {
    DestruirCamposSelect_Model(ObjModelConvocatoria_Interesados);
}

function InicializaConvocatoria_Interesadosform(id_convocatoria, tituloconvocatoria,) {
    debugger;
    $("#txtTituloConvocatoria_Interesados").val(tituloconvocatoria);    
 // $("#txtDependenciaConvocatoria_Interesados").val(nombredependencia);
    
    if (DataTableConvocatoria_Interesados != null) {
        DataTableConvocatoria_Interesados.destroy();
    }

    LoadDataTableConvocatoria_Interesados(); 

    $("#dvConvocatoriaTable").addClass("ocultar");    
    $("#dvConvocatoria_Interesados").removeClass("ocultar");
}

function CrearConvocatoria_Interesados() {

    CreateHTMLFromModel(ObjModelConvocatoria_Interesados)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelConvocatoria_Interesados)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_interesados_Convocatoria_Interesados").val('');
                    $("#txtid_convocatoria_Convocatoria_Interesados").val($("#spanIdConvocatoria")[0].innerText);

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

function ValidatePostUpdateConvocatoria_InteresadosForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelConvocatoria_Interesados)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Interesado Guardados', false, 'success', '', 0);  
        RefreshDataTableConvocatoria_Interesados();
        CerrarConvocatoria_Interesados();     
        
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


function ValidarEliminarConvocatoria_Interesados(id_interesados) {
    ShowDialogConfirmacion('','Seguro de eliminar el Requisito', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConvocatoria_Interesados(id_interesados);
            }
        });
}

function EliminarConvocatoria_Interesados(id_interesados) {
    let urlEliminar = urlController + "Convocatoria_Interesados/DeleteConvocatoria_Interesados?id_interesados=" + id_interesados;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConvocatoria_Interesados();
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
