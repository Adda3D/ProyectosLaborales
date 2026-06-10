var DataTableDecvie_MatryoshkaNuevoIndicador = null;
var ObjModelDecvie_MatryoshkaNuevoIndicador = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaNuevoIndicador = new Decvie_MatryoshkaNuevoIndicador();

    InicializaDecvie_MatryoshkaNuevoIndicadorform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaNuevoIndicador() {
    DataTableDecvie_MatryoshkaNuevoIndicador = $('#tblDecvie_MatryoshkaNuevoIndicador').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaNuevoIndicador/GetDataTableDecvie_MatryoshkaNuevoIndicadorByMatryohska",  //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "NombreCortoObjetivoDependencia", "orderable": false },
            { "data": "NombreCortoNuevoIndicador", "orderable": true },
            { "data": "descripcion", "orderable": true }, 
            { "data": "ejecucion", "orderable": true },                     
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Indicador" onclick="ValidarEliminarDecvie_MatryoshkaNuevoIndicador(' + row.id_matryoshkanuevoindicador + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ], 
        "columnDefs": [
            { "targets": 0,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreLargoObjetivoDependencia + '">' + data : data;} 
            },
            { "targets": 1,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.NombreLargoNuevoIndicador + '">' + data : data;} 
            },
         
        ],        
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaNuevoIndicador() {
    DataTableDecvie_MatryoshkaNuevoIndicador.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeNuevoIndicador() {
    $("#dvDecvie_MatryoshkaNuevoIndicador").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaNuevoIndicador() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaNuevoIndicador);
}

function InicializaDecvie_MatryoshkaNuevoIndicadorform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaNuevoIndicador").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaNuevoIndicador").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaNuevoIndicador != null) {
        DataTableDecvie_MatryoshkaNuevoIndicador.destroy();
    }

    LoadDataTableDecvie_MatryoshkaNuevoIndicador(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaNuevoIndicador").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaNuevoIndicador() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaNuevoIndicador)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaNuevoIndicador)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkanuevoindicador_Decvie_MatryoshkaNuevoIndicador").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaNuevoIndicador").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaNuevoIndicadorForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaNuevoIndicador)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaNuevoIndicador();
        CerrarModalDecvie_MatryoshkaNuevoIndicador();     
        
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


function ValidarEliminarDecvie_MatryoshkaNuevoIndicador(id_matryoshkanuevoindicador) {
    ShowDialogConfirmacion('','Seguro de eliminar el Indicador', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaNuevoIndicador(id_matryoshkanuevoindicador);
            }
        });
}

function EliminarDecvie_MatryoshkaNuevoIndicador(id_matryoshkanuevoindicador) {
    let urlEliminar = urlController + "Decvie_MatryoshkaNuevoIndicador/DeleteDecvie_MatryoshkaNuevoIndicador?id_matryoshkanuevoindicador=" + id_matryoshkanuevoindicador;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaNuevoIndicador();
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
