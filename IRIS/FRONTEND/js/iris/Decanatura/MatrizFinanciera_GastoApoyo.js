var DataTableMatrizFinanciera_GastoApoyo = null;
var ObjModelMatrizFinanciera_GastoApoyo = null;

$(document).ready(function () {    
    ObjModelMatrizFinanciera_GastoApoyo = new MatrizFinanciera_GastoApoyo();

    InicializaMatrizFinanciera_GastoApoyoform($("#spanIdMatrizFinanciera")[0].innerText, $("#spanIdVigenciaMatrizFinanciera")[0].innerText, $("#spanNombreVigenciaMatrizFinanciera")[0].innerText);
                                                

});


function LoadDataTableMatrizFinanciera_GastoApoyo() {
    DataTableMatrizFinanciera_GastoApoyo = $('#tblMatrizFinanciera_GastoApoyo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        searching: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "MatrizFinanciera_GastoApoyo/GetDataTableMatrizFinanciera_GastoApoyoByMatriz", // ?id_matrizfinanciera=" + $("#spanIdMatrizFinanciera")[0].innerText
            "data": {
                "id_matrizfinanciera": function() { return $("#spanIdMatrizFinanciera")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "id_gastoapoyo", "orderable": true },
            { "data": "NombreDependencia", "orderable": true },
            { "data": "totalpersonascontratadas", "orderable": false },
            { "data": "valortotal", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarMatrizFinanciera_GastoApoyo(' + row.id_gastoapoyo + ')" data-bs-toggle="modal" data-bs-target="#ModalMatrizFinanciera_GastoApoyo" /> ' +
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Eje" onclick="ValidarEliminarMatrizFinanciera_GastoApoyo(' + row.id_gastoapoyo + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableMatrizFinanciera_GastoApoyo() {
    DataTableMatrizFinanciera_GastoApoyo.ajax.reload(null, false);
}

function VolverMatrizFinancieraDesdeGastoApoyo() {
    $("#dvMatrizFinanciera_GastoApoyo").addClass("ocultar");    
    $("#dvMatrizFinancieraTable").removeClass("ocultar");
    
}

function CerrarModalMatrizFinanciera_GastoApoyo() {
    DestruirCamposSelect_Model(ObjModelMatrizFinanciera_GastoApoyo);
}

function InicializaMatrizFinanciera_GastoApoyoform(id_matrizfinanciera, id_vigencia, NombreVigencia) {
    debugger;
    $("#txtVigenciaMatrizFinanciera_GastoApoyo").val(NombreVigencia);    
    
    if (DataTableMatrizFinanciera_GastoApoyo != null) {
        DataTableMatrizFinanciera_GastoApoyo.destroy();
    }

    LoadDataTableMatrizFinanciera_GastoApoyo(); 

    $("#dvMatrizFinancieraTable").addClass("ocultar");    
    $("#dvMatrizFinanciera_GastoApoyo").removeClass("ocultar");
}

function CrearMatrizFinanciera_GastoApoyo() {

    CreateHTMLFromModel(ObjModelMatrizFinanciera_GastoApoyo)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelMatrizFinanciera_GastoApoyo)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_gastoapoyo_MatrizFinanciera_GastoApoyo").val('');                    
                    $("#txtid_matrizfinanciera_MatrizFinanciera_GastoApoyo").val($("#spanIdMatrizFinanciera")[0].innerText);

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

function ValidatePostUpdateMatrizFinanciera_GastoApoyoForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelMatrizFinanciera_GastoApoyo)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Eje Estratégico Guardados', false, 'success', '', 0);  
        RefreshDataTableMatrizFinanciera_GastoApoyo();
        CerrarModalMatrizFinanciera_GastoApoyo();     
        
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


function ValidarEliminarMatrizFinanciera_GastoApoyo(id_gastoapoyo) {
    ShowDialogConfirmacion('','Seguro de eliminar Gasto', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarMatrizFinanciera_GastoApoyo(id_gastoapoyo);
            }
        });
}

function EliminarMatrizFinanciera_GastoApoyo(id_gastoapoyo) {
    let urlEliminar = urlController + "MatrizFinanciera_GastoApoyo/DeleteMatrizFinanciera_GastoApoyo?id_gastoapoyo=" + id_gastoapoyo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableMatrizFinanciera_GastoApoyo();
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

function EditarMatrizFinanciera_GastoApoyo(id_gastoapoyo) {
    if (ObjModelMatrizFinanciera_GastoApoyo == null) {
        ObjModelMatrizFinanciera_GastoApoyo = new MatrizFinanciera_GastoApoyo();
    }
        
    ObjModelMatrizFinanciera_GastoApoyo.FormEdicion = 'formMatrizFinanciera_GastoApoyoDetalle';

    CreateHTMLFromModel(ObjModelMatrizFinanciera_GastoApoyo)
      .then(htmlcreado => {
          $('#txtid_gastoapoyo_MatrizFinanciera_GastoApoyo').val(id_gastoapoyo);
                    
          LoadData_ToModel(ObjModelMatrizFinanciera_GastoApoyo, id_gastoapoyo)
          .then(datoscargados => {
              if (datoscargados) { 
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