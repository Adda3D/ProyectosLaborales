var DataTableUGI_LiteralSemestre = null;
var ObjModelUGI_LiteralSemestre = null;

$(document).ready(function () {    
    ObjModelUGI_LiteralSemestre = new UGI_LiteralSemestre();
    InicializaUGI_LiteralSemestreform();
                                                                                   

});


function LoadDataTableUGI_LiteralSemestre() {
    DataTableUGI_LiteralSemestre = $('#tblModalUGILiteralSemestre').DataTable({
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
            "url": urlController + "UGI_LiteralSemestre/GetDataTableUGI_LiteralSemestreBySemestre",  //?id_ugisemestre=" + $("#spanIdUGI_Semestre")[0].innerText
            "data": {
                "id_ugisemestre": function() { return $("#spanIdUGI_Semestre")[0].innerText }             
            }
        },      
        "columns": [                    
         // { "data": "NombreSemestre", "orderable": false },
            { "data": "NombreLiteral", "orderable": false },
            { "data": "valorproyectado", "orderable": false },
            /*
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Eje" onclick="ValidarEliminarUGI_LiteralSemestre(' + row.id_postprogram + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }*/
            {
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="VentanaConceptos_UGISemestre(' + row.id_ugisemestre + ',' + row.id_semestre + ',`' + row.NombreSemestre +'`,' + row.id_ugiliteralsemestre + ',' + row.id_literal + ',`' + row.NombreLiteral + '`);"><img src="../images/iris/Editar.png">Conceptos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarUGI_LiteralSemestre(' + row.id_ugiliteralsemestre + ');"><img src="../images/iris/Eliminar.png">   Eliminar Literal</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
                        
        ],       
        "columnDefs": [
            { "targets": 1,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            }
        ],              
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableUGI_LiteralSemestre() {
    DataTableUGI_LiteralSemestre.ajax.reload(null, false);
}

function VolverEjecucionDesdeLiterales() {
    RefreshDataTableUGI_Semestre();
    
    $("#dvUGI_LiteralSemestre").addClass("ocultar");    
    $("#dvUGI_SemestreTable").removeClass("ocultar");
    
}

function CerrarUGILiteralSemestre() {
    DestruirCamposSelect_Model(ObjModelUGI_LiteralSemestre);
}

function InicializaUGI_LiteralSemestreform() {
    $("#txtEjecucion_UGISemestre").val($("#spanNombreSemestreUGI_Semestre")[0].innerText);
       
    
    if (DataTableUGI_LiteralSemestre != null) {
        DataTableUGI_LiteralSemestre.destroy();
    }

    LoadDataTableUGI_LiteralSemestre(); 

    $("#dvUGI_SemestreTable").addClass("ocultar");    
    $("#dvUGI_LiteralSemestre").removeClass("ocultar");
}

function CrearUGILiteralSemestre() {
    debugger;
    CreateHTMLFromModel(ObjModelUGI_LiteralSemestre)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelUGI_LiteralSemestre)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_ugiliteralsemestre_UGI_LiteralSemestre").val('');
                    $("#txtid_ugisemestre_UGI_LiteralSemestre").val($("#spanIdUGI_Semestre")[0].innerText);

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

function ValidatePostUpdateUGILiteralSemestreForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelUGI_LiteralSemestre)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Literal Guardados', false, 'success', '', 0);  
        RefreshDataTableUGI_LiteralSemestre();
        CerrarUGILiteralSemestre();     
        
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


function ValidarEliminarUGI_LiteralSemestre(id_ugiliteralsemestre) {
    ShowDialogConfirmacion('','Seguro de eliminar el Literal de la Ejecución del Semestre?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarUGI_LiteralSemestre(id_ugiliteralsemestre);
            }
        });
}

function EliminarUGI_LiteralSemestre(id_ugiliteralsemestre) {
    let urlEliminar = urlController + "UGI_LiteralSemestre/DeleteUGI_LiteralSemestre?id_ugiliteralsemestre=" + id_ugiliteralsemestre;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableUGI_LiteralSemestre();
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

function VentanaConceptos_UGISemestre (id_ugisemestre, id_semestre, NombreSemestre, id_ugiliteralsemestre, id_literal, NombreLiteral ) {
    $("#spanIdUGI_Semestre")[0].innerText = id_ugisemestre;
    $("#spanSemestreUGI_Semestre")[0].innerText = id_semestre; 
    $("#spanNombreSemestreUGI_Semestre")[0].innerText = NombreSemestre;
    $("#spanIdUGI_LiteralesSemestre")[0].innerText = id_ugiliteralsemestre;
    $("#spanIdLiteralUGI_LiteralesSemestre")[0].innerText = id_literal;
    $("#spanNombreLiteralUGI_LiteralesSemestre")[0].innerText = NombreLiteral;

    if (!ExisteDivEdicionDatos('dvUGI_ConceptoSemestre')) {
        CrearDivEdicionDatos('/Pages/Ugi/UGI_ConceptoSemestre.html', 'dvUGI_ConceptoSemestre');
    }
    else {
        InicializaUGI_ConceptoSemestreform();
    }

    
}