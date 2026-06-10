var DataTableUGI_ConceptoSemestre = null;
var ObjModelUGI_ConceptoSemestre = null;

$(document).ready(function () {    
    ObjModelUGI_ConceptoSemestre = new UGI_ConceptoSemestre();
    InicializaUGI_ConceptoSemestreform();
                                                                                   

});


function LoadDataTableUGI_ConceptoSemestre() {
    DataTableUGI_ConceptoSemestre = $('#tblModalUGIConceptoSemestre').DataTable({
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
            "url": urlController + "UGI_ConceptoSemestre/GetDataTableUGI_ConceptoSemestreBySemestre",  //?id_ugiliteralsemestre=" + $("#spanIdUGI_LiteralesSemestre")[0].innerText
            "data": {
                "id_ugiliteralsemestre": function() { return $("#spanIdUGI_LiteralesSemestre")[0].innerText }             
            }
        },      
        "columns": [                    
            { "data": "NombreSemestre", "orderable": false },
            { "data": "NombreLiteralSemestre", "orderable": false },
            { "data": "NombreConcepto", "orderable": false },
            { "data": "valorproyectado", "orderable": false },
            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Eje" onclick="ValidarEliminarUGI_ConceptoSemestre(' + row.id_ugiconceptosemestre + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }                        
        ],   
        "columnDefs": [
            { "targets": 3,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            }
        ],              
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableUGI_ConceptoSemestre() {
    DataTableUGI_ConceptoSemestre.ajax.reload(null, false);
}

function VolverLiteralesDesdeConcepto() {
    RefreshDataTableUGI_LiteralSemestre();
    
    $("#dvUGI_ConceptoSemestre").addClass("ocultar");    
    $("#dvUGI_LiteralSemestreTable").removeClass("ocultar");
    
}

function CerrarUGIConceptoSemestre() {
    DestruirCamposSelect_Model(ObjModelUGI_ConceptoSemestre);
}

function InicializaUGI_ConceptoSemestreform() {
    $("#txtEjecucion_UGIConceptoSemestre").val($("#spanNombreSemestreUGI_Semestre")[0].innerText);
    $("#txtNombreLiteral_UGIConceptoSemestre").val($("#spanNombreLiteralUGI_LiteralesSemestre")[0].innerText);
       
    
    if (DataTableUGI_ConceptoSemestre != null) {
        DataTableUGI_ConceptoSemestre.destroy();
    }

    LoadDataTableUGI_ConceptoSemestre(); 

    $("#dvUGI_LiteralSemestreTable").addClass("ocultar");    
    $("#dvUGI_ConceptoSemestre").removeClass("ocultar");
}

function CrearUGIConceptoSemestre() {
    debugger;
    CreateHTMLFromModel(ObjModelUGI_ConceptoSemestre)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelUGI_ConceptoSemestre)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_ugiconceptosemestre_UGI_ConceptoSemestre").val('');
                    $("#txtid_ugisemestre_UGI_ConceptoSemestre").val($("#spanIdUGI_Semestre")[0].innerText);
                    $("#txtid_ugiliteralsemestre_UGI_ConceptoSemestre").val($("#spanIdUGI_LiteralesSemestre")[0].innerText);

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

function ValidatePostUpdateUGIConceptoSemestreForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelUGI_ConceptoSemestre)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del COncepto Guardados', false, 'success', '', 0);  
        RefreshDataTableUGI_ConceptoSemestre();
        CerrarUGIConceptoSemestre();     
        
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


function ValidarEliminarUGI_ConceptoSemestre(id_ugiconceptosemestre) {
    ShowDialogConfirmacion('','Seguro de eliminar el Concepto del Literal?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarUGI_ConceptoSemestre(id_ugiconceptosemestre);
            }
        });
}

function EliminarUGI_ConceptoSemestre(id_ugiconceptosemestre) {
    let urlEliminar = urlController + "UGI_ConceptoSemestre/DeleteUGI_ConceptoSemestre?id_ugiconceptosemestre=" + id_ugiconceptosemestre;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableUGI_ConceptoSemestre();
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
