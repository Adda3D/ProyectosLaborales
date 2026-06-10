var DataTableMatrizFinanciera_GastoOperativo = null;
var ObjModelMatrizFinanciera_GastoOperativo = null;

$(document).ready(function () {    
    ObjModelMatrizFinanciera_GastoOperativo = new MatrizFinanciera_GastoOperativo();

    InicializaMatrizFinanciera_GastoOperativoform($("#spanIdMatrizFinanciera")[0].innerText, $("#spanIdVigenciaMatrizFinanciera")[0].innerText, $("#spanNombreVigenciaMatrizFinanciera")[0].innerText);

});


function LoadDataTableMatrizFinanciera_GastoOperativo() {
    DataTableMatrizFinanciera_GastoOperativo = $('#tblMatrizFinanciera_GastoOperativo').DataTable({
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
            "url": urlController + "MatrizFinanciera_GastoOperativo/GetDataTableMatrizFinanciera_GastoOperativoByMatriz", //?id_matrizfinanciera=" + $("#spanIdMatrizFinanciera")[0].innerText
            "data": {
                "id_matrizfinanciera": function() { return $("#spanIdMatrizFinanciera")[0].innerText }                
            }
        },      
        "columns": [                    
            { "data": "id_gastooperativo", "orderable": true },
            { "data": "NombreDependencia", "orderable": true },
            { "data": "NombreTipoOperativo", "orderable": false },
            { "data": "totalpersonascontratadas", "orderable": false },
            { "data": "valortotal", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarMatrizFinanciera_GastoOperativo(' + row.id_gastooperativo + ')" data-bs-toggle="modal" data-bs-target="#ModalMatrizFinanciera_GastoOperativo" /> ' +
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Eje" onclick="ValidarEliminarMatrizFinanciera_GastoOperativo(' + row.id_gastooperativo + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableMatrizFinanciera_GastoOperativo() {
    DataTableMatrizFinanciera_GastoOperativo.ajax.reload(null, false);
}

function VolverMatrizFinancieraDesdeGastoOperativo() {
    $("#dvMatrizFinanciera_GastoOperativo").addClass("ocultar");    
    $("#dvMatrizFinancieraTable").removeClass("ocultar");
    
}

function CerrarModalMatrizFinanciera_GastoOperativo() {
    DestruirCamposSelect_Model(ObjModelMatrizFinanciera_GastoOperativo);
}

function InicializaMatrizFinanciera_GastoOperativoform(id_matrizfinanciera, id_vigencia, MatrizFinancieraVigencia) {
    $("#txtVigenciaMatrizFinanciera_GastoOperativo").val(MatrizFinancieraVigencia);
    
    
    if (DataTableMatrizFinanciera_GastoOperativo != null) {
        DataTableMatrizFinanciera_GastoOperativo.destroy();
    }

    LoadDataTableMatrizFinanciera_GastoOperativo(); 

    $("#dvMatrizFinancieraTable").addClass("ocultar");    
    $("#dvMatrizFinanciera_GastoOperativo").removeClass("ocultar");
}

function CrearMatrizFinanciera_GastoOperativo() {

    CreateHTMLFromModel(ObjModelMatrizFinanciera_GastoOperativo)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelMatrizFinanciera_GastoOperativo)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_gastooperativo_MatrizFinanciera_GastoOperativo").val('');                    
                    $("#txtid_matrizfinanciera_MatrizFinanciera_GastoOperativo").val($("#spanIdMatrizFinanciera")[0].innerText);

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

function ValidatePostUpdateMatrizFinanciera_GastoOperativoForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelMatrizFinanciera_GastoOperativo)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Eje Estratégico Guardados', false, 'success', '', 0);  
        RefreshDataTableMatrizFinanciera_GastoOperativo();
        CerrarModalMatrizFinanciera_GastoOperativo();     
        
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


function ValidarEliminarMatrizFinanciera_GastoOperativo(id_gastooperativo) {
    ShowDialogConfirmacion('','Seguro de eliminar Gasto', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarMatrizFinanciera_GastoOperativo(id_gastooperativo);
            }
        });
}

function EliminarMatrizFinanciera_GastoOperativo(id_gastooperativo) {
    let urlEliminar = urlController + "MatrizFinanciera_GastoOperativo/DeleteMatrizFinanciera_GastoOperativo?id_gastooperativo=" + id_gastooperativo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableMatrizFinanciera_GastoOperativo();
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

function EditarMatrizFinanciera_GastoOperativo(id_gastooperativo) {
    
    ObjModelMatrizFinanciera_GastoOperativo.FormEdicion = 'formMatrizFinanciera_GastoOperativoDetalle';
 
     CreateHTMLFromModel(ObjModelMatrizFinanciera_GastoOperativo)
       .then(htmlcreado => {
           $('#txtid_gastooperativo_MatrizFinanciera_GastoOperativo').val(id_gastooperativo);
                     
           LoadData_ToModel(ObjModelMatrizFinanciera_GastoOperativo, id_gastooperativo)
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