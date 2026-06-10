var DataTableDecvie_MatryoshkaMetaDep = null;
var ObjModelDecvie_MatryoshkaMetaDep = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaMetaDep = new Decvie_MatryoshkaMetaDep();

    InicializaDecvie_MatryoshkaMetaDepform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaMetaDep() {
    DataTableDecvie_MatryoshkaMetaDep = $('#tblDecvie_MatryoshkaMetaDep').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaMetaDep/GetDataTableDecvie_MatryoshkaMetaDepByMatryohska", //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "DetalleObjetivoDep", "orderable": false },
            { "data": "NombreMeta", "orderable": false },                                  
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Objetivo" onclick="ValidarEliminarDecvie_MatryoshkaMetaDep(' + row.id_matryoshkametadep + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ], 
        "columnDefs": [
            { "targets": 0,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NomObjetivoDep + '">' + data : data;} 
            },
            
            { "targets": 1,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreMeta + '">' + data : data;} 
            },
         
        ],        
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaMetaDep() {
    DataTableDecvie_MatryoshkaMetaDep.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeMetas() {
    $("#dvDecvie_MatryoshkaMetaDep").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaMetaDep() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaMetaDep);
}

function InicializaDecvie_MatryoshkaMetaDepform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaMetaDep").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaMetaDep").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaMetaDep != null) {
        DataTableDecvie_MatryoshkaMetaDep.destroy();
    }

    LoadDataTableDecvie_MatryoshkaMetaDep(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaMetaDep").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaMetaDep() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaMetaDep)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaMetaDep)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkametadep_Decvie_MatryoshkaMetaDep").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaMetaDep").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaMetaDepForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaMetaDep)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaMetaDep();
        CerrarModalDecvie_MatryoshkaMetaDep();     
        
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


function ValidarEliminarDecvie_MatryoshkaMetaDep(id_matryoshkametadep) {
    ShowDialogConfirmacion('','Seguro de eliminar la Meta', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaMetaDep(id_matryoshkametadep);
            }
        });
}

function EliminarDecvie_MatryoshkaMetaDep(id_matryoshkametadep) {
    let urlEliminar = urlController + "Decvie_MatryoshkaMetaDep/DeleteDecvie_MatryoshkaMetaDep?id_matryoshkametadep=" + id_matryoshkametadep;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaMetaDep();
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
