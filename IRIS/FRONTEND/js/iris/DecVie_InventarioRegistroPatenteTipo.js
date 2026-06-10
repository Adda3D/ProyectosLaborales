var isUpdateDecVie_InventarioRegistroPatenteTipo = false;
var DataTableDecVie_InventarioRegistroPatenteTipo = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioRegistroPatenteTipo();
});

function LoadDataTableDecVie_InventarioRegistroPatenteTipo() {
    DataTableDecVie_InventarioRegistroPatenteTipo = $('#tblDecVie_InventarioRegistroPatenteTipo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioRegistroPatenteTipo/GetDataTableDecVie_InventarioRegistroPatenteTipo"
        },      
        "columns": [
            { "data": "nmpatentetipo", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_InventarioRegistroPatenteTipo(' + row.id_patentetipo + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_InventarioRegistroPatenteTipo" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_InventarioRegistroPatenteTipo(' + row.id_patentetipo + ',`' + row.nmpatentetipo + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_InventarioRegistroPatenteTipo() {
    DataTableDecVie_InventarioRegistroPatenteTipo.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_InventarioRegistroPatenteTipo(formF, botonClose) {
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
                if (!isUpdateDecVie_InventarioRegistroPatenteTipo) {                                          
                    ExisteDecVie_InventarioRegistroPatenteTipo()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_InventarioRegistroPatenteTipo(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_InventarioRegistroPatenteTipo(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_InventarioRegistroPatenteTipo() {    
    let nmpatentetipo = $("#txtCdDecVieInventarioRegistroPatenteTipo").val();   
    let urlValidar = urlController + "DecVie_InventarioRegistroPatenteTipo/GetDecVie_InventarioRegistroPatenteTipoNombre?cd_nmpatentetipo=" + nmpatentetipo;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmpatentetipo + " ya está registrado.";
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

function AddUpdateDecVie_InventarioRegistroPatenteTipo(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_InventarioRegistroPatenteTipo/UpdateDecVie_InventarioRegistroPatenteTipo";

    objData.id_patentetipo = ($("#spanIdDecVie_InventarioRegistroPatenteTipo")[0].innerText == '') ? undefined : $("#spanIdDecVie_InventarioRegistroPatenteTipo")[0].innerText;
    objData.nmpatentetipo = $("#txtCdDecVieInventarioRegistroPatenteTipo").val();
    objData.observaciones = $("#txtDecVie_InventarioRegistroPatenteTipo").val();

    if (objData.id_patentetipo == undefined) {
        urlUpdate = urlController + "DecVie_InventarioRegistroPatenteTipo/InsertDecVie_InventarioRegistroPatenteTipo";        
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

            RefreshDataTableDecVie_InventarioRegistroPatenteTipo();
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

function CrearDecVie_InventarioRegistroPatenteTipo() {
    $( "#txtCdDecVieInventarioRegistroPatenteTipo" ).prop( "disabled", false );
    $("#spanIdDecVie_InventarioRegistroPatenteTipo")[0].innerText = '';
    $("#txtCdDecVieInventarioRegistroPatenteTipo").val('');
    $("#txtDecVie_InventarioRegistroPatenteTipo").val('');
    isUpdateDecVie_InventarioRegistroPatenteTipo = false;

    removeValidationFormByForm('formDecVie_InventarioRegistroPatenteTipo');
}

function EditarDecVie_InventarioRegistroPatenteTipo(idpatentetipo) {   
    removeValidationFormByForm('formDecVie_InventarioRegistroPatenteTipo'); 
    let urlEditar = urlController + "DecVie_InventarioRegistroPatenteTipo/GetDecVie_InventarioRegistroPatenteTipoDetails?id_patentetipo=" + idpatentetipo;
    isUpdateDecVie_InventarioRegistroPatenteTipo = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_InventarioRegistroPatenteTipo")[0].innerText = datos.id_patentetipo;
            $("#txtCdDecVieInventarioRegistroPatenteTipo").val(datos.nmpatentetipo);
            $("#txtDecVie_InventarioRegistroPatenteTipo").val(datos.observaciones);
            $( "#txtCdDecVieInventarioRegistroPatenteTipo" ).prop( "disabled", false );            
            isUpdateDecVie_InventarioRegistroPatenteTipo = true;
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

function ValidarEliminarDecVie_InventarioRegistroPatenteTipo(idpatentetipo, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioRegistroPatenteTipo(idpatentetipo);
            }
        });

}

function EliminarDecVie_InventarioRegistroPatenteTipo(idpatentetipo) {
    let urlEliminar = urlController + "DecVie_InventarioRegistroPatenteTipo/DeleteDecVie_InventarioRegistroPatenteTipo?id_patentetipo=" + idpatentetipo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioRegistroPatenteTipo();
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
