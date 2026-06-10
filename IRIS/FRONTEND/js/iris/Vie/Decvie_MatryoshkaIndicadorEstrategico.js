var DataTableDecvie_MatryoshkaIndicadorEstrategico = null;
var ObjModelDecvie_MatryoshkaIndicadorEstrategico = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaIndicadorEstrategico = new Decvie_MatryoshkaIndicadorEstrategico();

    InicializaDecvie_MatryoshkaIndicadorEstrategicoform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaIndicadorEstrategico() {
    DataTableDecvie_MatryoshkaIndicadorEstrategico = $('#tblDecvie_MatryoshkaIndicadorEstrategico').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaIndicadorEstrategico/GetDataTableDecvie_MatryoshkaIndicadorEstrategicoByMatryohska",  //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "NombreCortoIndicador", "orderable": false },
            { "data": "observaciones", "orderable": true },                      
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Indicador" onclick="ValidarEliminarDecvie_MatryoshkaIndicadorEstrategico(' + row.id_matryoshkaindicadorestrategico + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ], 
        "columnDefs": [
            { "targets": 0,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreIndicador + '">' + data : data;} 
            },
            
         
        ],        
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaIndicadorEstrategico() {
    DataTableDecvie_MatryoshkaIndicadorEstrategico.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeIndicadores() {
    $("#dvDecvie_MatryoshkaIndicadorEstrategico").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaIndicadorEstrategico() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaIndicadorEstrategico);
}

function InicializaDecvie_MatryoshkaIndicadorEstrategicoform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaIndicadorEstrategico").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaIndicadorEstrategico").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaIndicadorEstrategico != null) {
        DataTableDecvie_MatryoshkaIndicadorEstrategico.destroy();
    }

    LoadDataTableDecvie_MatryoshkaIndicadorEstrategico(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaIndicadorEstrategico").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaIndicadorEstrategico() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaIndicadorEstrategico)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaIndicadorEstrategico)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkaindicadorestrategico_Decvie_MatryoshkaIndicadorEstrategico").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaIndicadorEstrategico").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaIndicadorEstrategicoForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaIndicadorEstrategico)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaIndicadorEstrategico();
        CerrarModalDecvie_MatryoshkaIndicadorEstrategico();     
        
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


function ValidarEliminarDecvie_MatryoshkaIndicadorEstrategico(id_matryoshkaindicadorestrategico) {
    ShowDialogConfirmacion('','Seguro de eliminar el Indicador', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaIndicadorEstrategico(id_matryoshkaindicadorestrategico);
            }
        });
}

function EliminarDecvie_MatryoshkaIndicadorEstrategico(id_matryoshkaindicadorestrategico) {
    let urlEliminar = urlController + "Decvie_MatryoshkaIndicadorEstrategico/DeleteDecvie_MatryoshkaIndicadorEstrategico?id_matryoshkaindicadorestrategico=" + id_matryoshkaindicadorestrategico;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaIndicadorEstrategico();
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
