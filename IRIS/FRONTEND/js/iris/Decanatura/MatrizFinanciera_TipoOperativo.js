var DataTableMatrizFinanciera_TipoOperativo = null;
var ObjModelMatrizFinanciera_TipoOperativo = null;

$(document).ready(function () {    
    LoadDataTableMatrizFinanciera_TipoOperativo(); 
    ObjModelMatrizFinanciera_TipoOperativo = new MatrizFinanciera_TipoOperativo();

});


function LoadDataTableMatrizFinanciera_TipoOperativo() {
    DataTableMatrizFinanciera_TipoOperativo = $('#tblMatrizFinanciera_TipoOperativo').DataTable({
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
            "url": urlController + "MatrizFinanciera_TipoOperativo/GetDataTableMatrizFinanciera_TipoOperativo"
        },      
        "columns": [                    
            { "data": "id_tipooperativo", "orderable": true },
            { "data": "codtipooperativo", "orderable": false },
            { "data": "nmtipooperativo", "orderable": false },                       
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Eje" onclick="ValidarEliminarMatrizFinanciera_TipoOperativo(' + row.id_tipooperativo + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableMatrizFinanciera_TipoOperativo() {
    DataTableMatrizFinanciera_TipoOperativo.ajax.reload(null, false);
}

function CerrarModalMatrizFinanciera_TipoOperativo() {
    DestruirCamposSelect_Model(ObjModelMatrizFinanciera_TipoOperativo);
}

function CrearMatrizFinanciera_TipoOperativo() {

    CreateHTMLFromModel(ObjModelMatrizFinanciera_TipoOperativo)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelMatrizFinanciera_TipoOperativo)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_tipooperativo_MatrizFinanciera_TipoOperativo").val('');
                    
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

function ValidatePostUpdateMatrizFinanciera_TipoOperativoForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelMatrizFinanciera_TipoOperativo)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Eje Estratégico Guardados', false, 'success', '', 0);  
        RefreshDataTableMatrizFinanciera_TipoOperativo();
        CerrarModalMatrizFinanciera_TipoOperativo();     
        
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


function ValidarEliminarMatrizFinanciera_TipoOperativo(id_tipooperativo) {
    ShowDialogConfirmacion('','Seguro de eliminar el Tipo Operativo?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarMatrizFinanciera_TipoOperativo(id_tipooperativo);
            }
        });
}

function EliminarMatrizFinanciera_TipoOperativo(id_tipooperativo) {
    let urlEliminar = urlController + "MatrizFinanciera_TipoOperativo/DeleteMatrizFinanciera_TipoOperativo?id_tipooperativo=" + id_tipooperativo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableMatrizFinanciera_TipoOperativo();
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
