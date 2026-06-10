var isUpdateDecVie_InventarioUsoAmpliadoInsumo = false;
var DataTableDecVie_InventarioUsoAmpliadoInsumo = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioUsoAmpliadoInsumo();
});

function LoadDataTableDecVie_InventarioUsoAmpliadoInsumo() {
    DataTableDecVie_InventarioUsoAmpliadoInsumo = $('#tblDecVie_InventarioUsoAmpliadoInsumo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioUsoAmpliadoInsumo/GetDataTableDecVie_InventarioUsoAmpliadoInsumo"
        },      
        "columns": [
            { "data": "nminsumo", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioUsoAmpliadoInsumo(' + row.id_insumo + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioUsoAmpliadoInsumo" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioUsoAmpliadoInsumo(' + row.id_insumo + ',`' + row.nminsumo + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioUsoAmpliadoInsumo() {
    DataTableDecVie_InventarioUsoAmpliadoInsumo.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioUsoAmpliadoInsumo(formF, botonClose) {
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
                if (!isUpdateDecVie_InventarioUsoAmpliadoInsumo) {                                          
                    ExisteDecVie_InventarioUsoAmpliadoInsumo()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioUsoAmpliadoInsumo(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioUsoAmpliadoInsumo(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_InventarioUsoAmpliadoInsumo() {    
    let nminsumo = $("#txtCdDecVieInventarioUsoAmpliadoInsumo").val();   
    let urlValidar = urlController + "DecVie_InventarioUsoAmpliadoInsumo/GetDecVie_InventarioUsoAmpliadoInsumoNombre?cd_nminsumo=" + nminsumo;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nminsumo + " ya está registrado.";
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

function AddUpdateDecVie_InventarioUsoAmpliadoInsumo(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioUsoAmpliadoInsumo/UpdateDecVie_InventarioUsoAmpliadoInsumo";

    objData.id_insumo = ($("#spanIdDecVie_InventarioUsoAmpliadoInsumo")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioUsoAmpliadoInsumo")[0].innerText;
    objData.nminsumo = $("#txtCdDecVieInventarioUsoAmpliadoInsumo").val();
    objData.observaciones = $("#txtDecVie_InventarioUsoAmpliadoInsumo").val();

    if (objData.id_insumo == undefined) {
        urlUpdate = urlController + "DecVie_InventarioUsoAmpliadoInsumo/InsertDecVie_InventarioUsoAmpliadoInsumo";        
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

            RefreshDataTableDecVie_InventarioUsoAmpliadoInsumo();
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

function CrearDecVie_InventarioUsoAmpliadoInsumo() {
    $( "#txtCdDecVieInventarioUsoAmpliadoInsumo" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioUsoAmpliadoInsumo")[0].innerText = '';
    $("#txtCdDecVieInventarioUsoAmpliadoInsumo").val('');
    $("#txtDecVie_InventarioUsoAmpliadoInsumo").val('');
    isUpdateDecVie_InventarioUsoAmpliadoInsumo = false;

    removeValidationFormByForm('formDecVie_InventarioUsoAmpliadoInsumo');
}

function EditarDecVie_InventarioUsoAmpliadoInsumo(idinsumo) {   
    removeValidationFormByForm('formDecVie_InventarioUsoAmpliadoInsumo'); 
    let urlEditar = urlController + "DecVie_InventarioUsoAmpliadoInsumo/GetDecVie_InventarioUsoAmpliadoInsumoDetails?id_insumo=" + idinsumo;
    isUpdateDecVie_InventarioUsoAmpliadoInsumo = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioUsoAmpliadoInsumo")[0].innerText = datos.id_insumo;
            $("#txtCdDecVieInventarioUsoAmpliadoInsumo").val(datos.nminsumo);
            $("#txtDecVie_InventarioUsoAmpliadoInsumo").val(datos.observaciones);
            $( "#txtCdDecVieInventarioUsoAmpliadoInsumo" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioUsoAmpliadoInsumo = true;
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

function ValidarEliminarDecVie_InventarioUsoAmpliadoInsumo(idinsumo, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioUsoAmpliadoInsumo(idinsumo);
            }
        });

}

function EliminarDecVie_InventarioUsoAmpliadoInsumo(idinsumo) {
    let urlEliminar = urlController + "DecVie_InventarioUsoAmpliadoInsumo/DeleteDecVie_InventarioUsoAmpliadoInsumo?id_insumo=" + idinsumo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioUsoAmpliadoInsumo();
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
