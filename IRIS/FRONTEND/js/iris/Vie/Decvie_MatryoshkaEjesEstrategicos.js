var DataTableMatryoshkaEjesEstrategicos = null;
var ObjModelDecvie_MatryoshkaEjeEstrategico = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaEjeEstrategico = new Decvie_MatryoshkaEjeEstrategico();

    InicializaMatryoshkaEjesEstrategicosform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableMatryoshkaEjesEstrategicos() {
    DataTableMatryoshkaEjesEstrategicos = $('#tblMatryoshkaEjesEstrategicos').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaEjeEstrategico/GetDataTableDecvie_MatryoshkaEjeEstrategicoByMatryohska",  //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "NombreEjeestrategico", "orderable": false },
            { "data": "DescripcionEje", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Eje" onclick="ValidarEliminarMatryoshkaEjesEstrategicos(' + row.id_matryoshkaejeestrategico + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableMatryoshkaEjesEstrategicos() {
    DataTableMatryoshkaEjesEstrategicos.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeEjes() {
    $("#dvDecvie_MatryoshkaEjesEstrategicos").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalMatryoshkaEjesEstrategicos() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaEjeEstrategico);
}

function InicializaMatryoshkaEjesEstrategicosform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceMatryoshkaEjesEstrategicos").val(alcance);    
    $("#txtDependenciaMatryoshkaEjesEstrategicos").val(nombredependencia);
    
    if (DataTableMatryoshkaEjesEstrategicos != null) {
        DataTableMatryoshkaEjesEstrategicos.destroy();
    }

    LoadDataTableMatryoshkaEjesEstrategicos(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaEjesEstrategicos").removeClass("ocultar");
}

function CrearMatryoshkaEjesEstrategicos() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaEjeEstrategico)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaEjeEstrategico)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkaejeestrategico_Decvie_MatryoshkaEjeEstrategico").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaEjeEstrategico").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateMatryoshkaEjesEstrategicosForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaEjeEstrategico)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Eje Estratégico Guardados', false, 'success', '', 0);  
        RefreshDataTableMatryoshkaEjesEstrategicos();
        CerrarModalMatryoshkaEjesEstrategicos();     
        
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


function ValidarEliminarMatryoshkaEjesEstrategicos(id_matryoshkaejeestrategico) {
    ShowDialogConfirmacion('','Seguro de eliminar eje de Matryoshka', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarMatryoshkaEjesEstrategicos(id_matryoshkaejeestrategico);
            }
        });
}

function EliminarMatryoshkaEjesEstrategicos(id_matryoshkaejeestrategico) {
    let urlEliminar = urlController + "Decvie_MatryoshkaEjeEstrategico/DeleteDecvie_MatryoshkaEjeEstrategico?id_matryoshkaejeestrategico=" + id_matryoshkaejeestrategico;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableMatryoshkaEjesEstrategicos();
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
