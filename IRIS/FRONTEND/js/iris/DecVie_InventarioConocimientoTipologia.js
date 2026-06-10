var isUpdateDecVie_InventarioConocimientoTipologia = false;
var DataTableDecVie_InventarioConocimientoTipologia = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioConocimientoTipologia();
});

function LoadDataTableDecVie_InventarioConocimientoTipologia() {
    DataTableDecVie_InventarioConocimientoTipologia = $('#tblDecVie_InventarioConocimientoTipologia').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioConocimientoTipologia/GetDataTableDecVie_InventarioConocimientoTipologia"
        },      
        "columns": [
            { "data": "nmtipologia", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioConocimientoTipologia(' + row.id_conocimientotipologia + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioConocimientoTipologia" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioConocimientoTipologia(' + row.id_conocimientotipologia + ',`' + row.nmtipologia + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioConocimientoTipologia() {
    DataTableDecVie_InventarioConocimientoTipologia.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioConocimientoTipologia(formF, botonClose) {
    debugger;
    validateTextXSSLastButtonByForm(formF);

    var formV = $("#" + formF);
    if (formV[0].checkValidity() == false) {
        $(formV).addClass('was-validated');
    } else {
        if (checkValidityXSS == false) {
            $(formV).addClass('was-validated');
        } else {
            if (checkValiditySelect == false) {
                $(formV).addClass('was-validated');
            } else {
                if (!isUpdateDecVie_InventarioConocimientoTipologia) {                                          
                    ExisteDecVie_InventarioConocimientoTipologia()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioConocimientoTipologia(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioConocimientoTipologia(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_InventarioConocimientoTipologia() {    
    let nmtipologia = $("#txtCdDecVieInventarioConocimientoTipologia").val();   
    let urlValidar = urlController + "DecVie_InventarioConocimientoTipologia/GetDecVie_InventarioConocimientoTipologiaNombre?cd_nmtipologia=" + nmtipologia;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipologia + " ya está registrado.";
                ShowModalDialog(message, false, 'warning', '', 0);
                return true;
            }
            else {
                return false;
            }            
          })
          .then( resultado => {
            return resolve(resultado);
          }) 
          .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      });
}

function AddUpdateDecVie_InventarioConocimientoTipologia(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioConocimientoTipologia/UpdateDecVie_InventarioConocimientoTipologia";

    objData.id_conocimientotipologia = ($("#spanIdDecVie_InventarioConocimientoTipologia")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioConocimientoTipologia")[0].innerText;
    objData.nmtipologia = $("#txtCdDecVieInventarioConocimientoTipologia").val();
    objData.observaciones = $("#txtDecVie_InventarioConocimientoTipologia").val();

    if (objData.id_conocimientotipologia == undefined) {
        urlUpdate = urlController + "DecVie_InventarioConocimientoTipologia/InsertDecVie_InventarioConocimientoTipologia";        
    }

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTableDecVie_InventarioConocimientoTipologia();
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );          
}

function CrearDecVie_InventarioConocimientoTipologia() {
    $( "#txtCdDecVieInventarioConocimientoTipologia" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioConocimientoTipologia")[0].innerText = '';
    $("#txtCdDecVieInventarioConocimientoTipologia").val('');
    $("#txtDecVie_InventarioConocimientoTipologia").val('');
    isUpdateDecVie_InventarioConocimientoTipologia = false;

    removeValidationFormByForm('formDecVie_InventarioConocimientoTipologia');
}

function EditarDecVie_InventarioConocimientoTipologia(idconocimientotipologia) {   
    removeValidationFormByForm('formDecVie_InventarioConocimientoTipologia'); 
    let urlEditar = urlController + "DecVie_InventarioConocimientoTipologia/GetDecVie_InventarioConocimientoTipologiaDetails?id_conocimientotipologia=" + idconocimientotipologia;
    isUpdateDecVie_InventarioConocimientoTipologia = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioConocimientoTipologia")[0].innerText = datos.id_conocimientotipologia;
            $("#txtCdDecVieInventarioConocimientoTipologia").val(datos.nmtipologia);
            $("#txtDecVie_InventarioConocimientoTipologia").val(datos.observaciones);
            $( "#txtCdDecVieInventarioConocimientoTipologia" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioConocimientoTipologia = true;
            FinalizeLoader();
            return;
        }
        else {
            ShowModalDialog(data.Message, false, 'warning', '', 0);
            FinalizeLoader();
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      

}

function ValidarEliminarDecVie_InventarioConocimientoTipologia(idconocimientotipologia, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioConocimientoTipologia(idconocimientotipologia);
            }
        });

}

function EliminarDecVie_InventarioConocimientoTipologia(idconocimientotipologia) {
    let urlEliminar = urlController + "DecVie_InventarioConocimientoTipologia/DeleteDecVie_InventarioConocimientoTipologia?id_conocimientotipologia=" + idconocimientotipologia;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioConocimientoTipologia();
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
