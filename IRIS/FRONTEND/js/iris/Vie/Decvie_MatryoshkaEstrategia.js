var DataTableDecvie_MatryoshkaEstrategia = null;
var ObjModelDecvie_MatryoshkaEstrategia = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaEstrategia = new Decvie_MatryoshkaEstrategia();

    InicializaDecvie_MatryoshkaEstrategiaform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaEstrategia() {
    DataTableDecvie_MatryoshkaEstrategia = $('#tblDecvie_MatryoshkaEstrategia').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaEstrategia/GetDataTableDecvie_MatryoshkaEstrategiaByMatryohska",  //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "descripcionEstrategia", "orderable": false },           
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Estrategia" onclick="ValidarEliminarDecvie_MatryoshkaEstrategia(' + row.id_matryoshkaestrategia + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ], 
        "columnDefs": [
            { "targets": 0,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.estrategia + '">' + data : data;} 
            },
         
        ],        
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaEstrategia() {
    DataTableDecvie_MatryoshkaEstrategia.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeEstrategias() {
    $("#dvDecvie_MatryoshkaEstrategia").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaEstrategia() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaEstrategia);
}

function InicializaDecvie_MatryoshkaEstrategiaform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaEstrategia").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaEstrategia").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaEstrategia != null) {
        DataTableDecvie_MatryoshkaEstrategia.destroy();
    }

    LoadDataTableDecvie_MatryoshkaEstrategia(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaEstrategia").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaEstrategia() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaEstrategia)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaEstrategia)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkaestrategia_Decvie_MatryoshkaEstrategia").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaEstrategia").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaEstrategiaForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaEstrategia)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaEstrategia();
        CerrarModalDecvie_MatryoshkaEstrategia();     
        
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


function ValidarEliminarDecvie_MatryoshkaEstrategia(id_matryoshkaestrategia) {
    ShowDialogConfirmacion('','Seguro de eliminar el Programa', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaEstrategia(id_matryoshkaestrategia);
            }
        });
}

function EliminarDecvie_MatryoshkaEstrategia(id_matryoshkaestrategia) {
    let urlEliminar = urlController + "Decvie_MatryoshkaEstrategia/DeleteDecvie_MatryoshkaEstrategia?id_matryoshkaestrategia=" + id_matryoshkaestrategia;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaEstrategia();
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
