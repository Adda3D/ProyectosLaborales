var DataTableDecvie_MatryoshkaObjetivoPgd = null;
var ObjModelDecvie_MatryoshkaObjetivoPgd = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaObjetivoPgd = new Decvie_MatryoshkaObjetivoPgd();

    InicializaDecvie_MatryoshkaObjetivoPgdform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaObjetivoPgd() {
    DataTableDecvie_MatryoshkaObjetivoPgd = $('#tblDecvie_MatryoshkaObjetivoPgd').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaObjetivoPgd/GetDataTableDecvie_MatryoshkaObjetivoPgdByMatryohska",  //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }                        
        },      
        "columns": [                    
            { "data": "DescripcionEstrategia", "orderable": false },
            { "data": "ObjetivoPgd", "orderable": false },                      
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Objetivo" onclick="ValidarEliminarDecvie_MatryoshkaObjetivoPgd(' + row.id_matryoshkaobjetivopgd + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }            
        ], 
        "columnDefs": [
            { "targets": 0,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.DetalleEstrategia + '">' + data : data;} 
            },
            { "targets": 1,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.ObjetivoPgd + '">' + data : data;} 
            },
         
        ],        
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaObjetivoPgd() {
    DataTableDecvie_MatryoshkaObjetivoPgd.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeObjetivos() {
    $("#dvDecvie_MatryoshkaObjetivoPgd").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaObjetivoPgd() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaObjetivoPgd);
}

function InicializaDecvie_MatryoshkaObjetivoPgdform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaObjetivoPgd").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaObjetivoPgd").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaObjetivoPgd != null) {
        DataTableDecvie_MatryoshkaObjetivoPgd.destroy();
    }

    LoadDataTableDecvie_MatryoshkaObjetivoPgd(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaObjetivoPgd").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaObjetivoPgd() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaObjetivoPgd)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaObjetivoPgd)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkaobjetivopgd_Decvie_MatryoshkaObjetivoPgd").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaObjetivoPgd").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaObjetivoPgdForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaObjetivoPgd)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaObjetivoPgd();
        CerrarModalDecvie_MatryoshkaObjetivoPgd();     
        
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


function ValidarEliminarDecvie_MatryoshkaObjetivoPgd(id_matryoshkaobjetivopgd) {
    ShowDialogConfirmacion('','Seguro de eliminar el Objetivo', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaObjetivoPgd(id_matryoshkaobjetivopgd);
            }
        });
}

function EliminarDecvie_MatryoshkaObjetivoPgd(id_matryoshkaobjetivopgd) {
    let urlEliminar = urlController + "Decvie_MatryoshkaObjetivoPgd/DeleteDecvie_MatryoshkaObjetivoPgd?id_matryoshkaobjetivopgd=" + id_matryoshkaobjetivopgd;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaObjetivoPgd();
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
