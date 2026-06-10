var DataTableDecvie_MatryoshkaObjetivoDep = null;
var ObjModelDecvie_MatryoshkaObjetivoDep = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaObjetivoDep = new Decvie_MatryoshkaObjetivoDep();

    InicializaDecvie_MatryoshkaObjetivoDepform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaObjetivoDep() {
    DataTableDecvie_MatryoshkaObjetivoDep = $('#tblDecvie_MatryoshkaObjetivoDep').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaObjetivoDep/GetDataTableDecvie_MatryoshkaObjetivoDepByMatryohska", //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "DescripcionObjetivoDep", "orderable": false },
            { "data": "observaciones", "orderable": true },                      
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Objetivo" onclick="ValidarEliminarDecvie_MatryoshkaObjetivoDep(' + row.id_matryoshkaobjetivodep + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ], 
        "columnDefs": [
            { "targets": 0,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreObjetivoDep + '">' + data : data;} 
            },
            
         
        ],        
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaObjetivoDep() {
    DataTableDecvie_MatryoshkaObjetivoDep.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeObjetivosDep() {
    $("#dvDecvie_MatryoshkaObjetivoDep").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaObjetivoDep() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaObjetivoDep);
}

function InicializaDecvie_MatryoshkaObjetivoDepform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaObjetivoDep").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaObjetivoDep").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaObjetivoDep != null) {
        DataTableDecvie_MatryoshkaObjetivoDep.destroy();
    }

    LoadDataTableDecvie_MatryoshkaObjetivoDep(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaObjetivoDep").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaObjetivoDep() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaObjetivoDep)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaObjetivoDep)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkaobjetivodep_Decvie_MatryoshkaObjetivoDep").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaObjetivoDep").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaObjetivoDepForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaObjetivoDep)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaObjetivoDep();
        CerrarModalDecvie_MatryoshkaObjetivoDep();     
        
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


function ValidarEliminarDecvie_MatryoshkaObjetivoDep(id_matryoshkaobjetivodep) {
    ShowDialogConfirmacion('','Seguro de eliminar el Objetivo', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaObjetivoDep(id_matryoshkaobjetivodep);
            }
        });
}

function EliminarDecvie_MatryoshkaObjetivoDep(id_matryoshkaobjetivodep) {
    let urlEliminar = urlController + "Decvie_MatryoshkaObjetivoDep/DeleteDecvie_MatryoshkaObjetivoDep?id_matryoshkaobjetivodep=" + id_matryoshkaobjetivodep;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaObjetivoDep();
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
