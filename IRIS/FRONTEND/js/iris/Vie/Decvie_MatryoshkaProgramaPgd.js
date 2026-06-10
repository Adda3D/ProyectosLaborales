var DataTableDecvie_MatryoshkaProgramaPgd = null;
var ObjModelDecvie_MatryoshkaProgramaPgd = null;

$(document).ready(function () {    
    ObjModelDecvie_MatryoshkaProgramaPgd = new Decvie_MatryoshkaProgramaPgd();

    InicializaDecvie_MatryoshkaProgramaPgdform($("#spanIdDecvie_Matryoshka")[0].innerText, $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText,
                                                $("#spanDependenciaDecvie_Matryoshka")[0].innerText);

});


function LoadDataTableDecvie_MatryoshkaProgramaPgd() {
    DataTableDecvie_MatryoshkaProgramaPgd = $('#tblDecvie_MatryoshkaProgramaPgd').DataTable({
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
            "url": urlController + "Decvie_MatryoshkaProgramaPgd/GetDataTableDecvie_MatryoshkaProgramaPgdByMatryohska", //?id_matryoska=" + $("#spanIdDecvie_Matryoshka")[0].innerText
            "data": {
                "id_matryoska": function() { return $("#spanIdDecvie_Matryoshka")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "NombreProgramaPGD", "orderable": false },
            { "data": "DescripcionProgramaPGD", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Programa" onclick="ValidarEliminarDecvie_MatryoshkaProgramaPgd(' + row.id_matryoshkaprogramapgd + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_MatryoshkaProgramaPgd() {
    DataTableDecvie_MatryoshkaProgramaPgd.ajax.reload(null, false);
}

function VolverTablaMatryoshkaDesdeProgramas() {
    $("#dvDecvie_MatryoshkaProgramaPgd").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");
    
}

function CerrarModalDecvie_MatryoshkaProgramaPgd() {
    DestruirCamposSelect_Model(ObjModelDecvie_MatryoshkaProgramaPgd);
}

function InicializaDecvie_MatryoshkaProgramaPgdform(idmatryoshka, alcance, nombredependencia) {
    $("#txtAlcanceDecvie_MatryoshkaProgramaPgd").val(alcance);    
    $("#txtDependenciaDecvie_MatryoshkaProgramaPgd").val(nombredependencia);
    
    if (DataTableDecvie_MatryoshkaProgramaPgd != null) {
        DataTableDecvie_MatryoshkaProgramaPgd.destroy();
    }

    LoadDataTableDecvie_MatryoshkaProgramaPgd(); 

    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaProgramaPgd").removeClass("ocultar");
}

function CrearDecvie_MatryoshkaProgramaPgd() {

    CreateHTMLFromModel(ObjModelDecvie_MatryoshkaProgramaPgd)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_MatryoshkaProgramaPgd)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshkaprogramapgd_Decvie_MatryoshkaProgramaPgd").val('');
                    $("#txtid_matryoska_Decvie_MatryoshkaProgramaPgd").val($("#spanIdDecvie_Matryoshka")[0].innerText);

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

function ValidatePostUpdateDecvie_MatryoshkaProgramaPgdForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_MatryoshkaProgramaPgd)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
        RefreshDataTableDecvie_MatryoshkaProgramaPgd();
        CerrarModalDecvie_MatryoshkaProgramaPgd();     
        
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


function ValidarEliminarDecvie_MatryoshkaProgramaPgd(id_matryoshkaprogramapgd) {
    ShowDialogConfirmacion('','Seguro de eliminar el Programa', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_MatryoshkaProgramaPgd(id_matryoshkaprogramapgd);
            }
        });
}

function EliminarDecvie_MatryoshkaProgramaPgd(id_matryoshkaprogramapgd) {
    let urlEliminar = urlController + "Decvie_MatryoshkaProgramaPgd/DeleteDecvie_MatryoshkaProgramaPgd?id_matryoshkaprogramapgd=" + id_matryoshkaprogramapgd;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_MatryoshkaProgramaPgd();
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
