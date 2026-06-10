var DataTableDecvie_MatryoshkaActividadDep = null;
var ObjModelDecvie_MatryoshkaActividadDep = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaActividadDep = new Decvie_MatryoshkaActividadDep();

    InicializaDecvie_MatryoshkaActividadDepform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaActividadDep() {
    DataTableDecvie_MatryoshkaActividadDep = $('#tblDecvie_MatryoshkaActividadDep').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaActividadDep/GetDataTableDecvie_MatryoshkaActividadDepByMatryohska",  //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "NombreMeta", "orderable": false },
            { "data": "NombreActividad", "orderable": false },                                  
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Objetivo" onclick="ValidarEliminarDecvie_MatryoshkaActividadDep(' + row.id_matryoshkaactividaddep + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ], 
        "columnDefs": [
            { "targets": 0,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreMeta + '">' + data : data;} 
            },
            
            { "targets": 1,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreActividad + '">' + data : data;} 
            },
         
        ],        
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaActividadDep() {
    DataTableDecvie_MatryoshkaActividadDep.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeActividades() {
    $("#dvDecvie_MatryoshkaActividadDep").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaActividadDep() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaActividadDep);
}

function InicializaDecvie_MatryoshkaActividadDepform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaActividadDep").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaActividadDep").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaActividadDep != null) {
        DataTableDecvie_MatryoshkaActividadDep.destroy();
    }

    LoadDataTableDecvie_MatryoshkaActividadDep(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaActividadDep").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaActividadDep() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaActividadDep)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaActividadDep)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkaactividaddep_Decvie_MatryoshkaActividadDep").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaActividadDep").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaActividadDepForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaActividadDep)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaActividadDep();
        CerrarModalDecvie_MatryoshkaActividadDep();     
        
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


function ValidarEliminarDecvie_MatryoshkaActividadDep(id_matryoshkaactividaddep) {
    ShowDialogConfirmacion('','Seguro de eliminar la Meta', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaActividadDep(id_matryoshkaactividaddep);
            }
        });
}

function EliminarDecvie_MatryoshkaActividadDep(id_matryoshkaactividaddep) {
    let urlEliminar = urlController + "Decvie_MatryoshkaActividadDep/DeleteDecvie_MatryoshkaActividadDep?id_matryoshkaactividaddep=" + id_matryoshkaactividaddep;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaActividadDep();
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
