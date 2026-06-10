var isUpdateDecVie_DerechosPeticionOficina = false;
var DataTableDecVie_DerechosPeticionOficina = null;

$(document).ready(function () {
    LoadDataTableDecVie_DerechosPeticionOficina();
});

function LoadDataTableDecVie_DerechosPeticionOficina() {
    DataTableDecVie_DerechosPeticionOficina = $('#tblDecVie_DerechosPeticionOficina').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_DerechosPeticionOficina/GetDataTableDecVie_DerechosPeticionOficina"
        },      
        "columns": [
            { "data": "nmoficina", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_DerechosPeticionOficina(' + row.id_oficina + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_DerechosPeticionOficina" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_DerechosPeticionOficina(' + row.id_oficina + ',`' + row.nmoficina + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_DerechosPeticionOficina() {
    DataTableDecVie_DerechosPeticionOficina.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_DerechosPeticionOficina(formF, botonClose) {
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
                if (!isUpdateDecVie_DerechosPeticionOficina) {                                          
                    ExisteDecVie_DerechosPeticionOficina()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_DerechosPeticionOficina(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_DerechosPeticionOficina(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_DerechosPeticionOficina() {    
    let nmoficina = $("#txtCdDecVieDerechosPeticionOficina").val();   
    let urlValidar = urlController + "DecVie_DerechosPeticionOficina/GetDecVie_DerechosPeticionOficinaNombre?cd_nmoficina=" + nmoficina;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmoficina + " ya está registrado.";
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

function AddUpdateDecVie_DerechosPeticionOficina(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_DerechosPeticionOficina/UpdateDecVie_DerechosPeticionOficina";

    objData.id_oficina = ($("#spanIdDecVie_DerechosPeticionOficina")[0].innerText == '') ? undefined : $("#spanIdDecVie_DerechosPeticionOficina")[0].innerText;
    objData.nmoficina = $("#txtCdDecVieDerechosPeticionOficina").val();
    objData.observaciones = $("#txtDecVie_DerechosPeticionOficina").val();

    if (objData.id_oficina == undefined) {
        urlUpdate = urlController + "DecVie_DerechosPeticionOficina/InsertDecVie_DerechosPeticionOficina";        
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

            RefreshDataTableDecVie_DerechosPeticionOficina();
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

function CrearDecVie_DerechosPeticionOficina() {
    $( "#txtCdDecVieDerechosPeticionOficina" ).prop( "disabled", false );
    $("#spanIdDecVie_DerechosPeticionOficina")[0].innerText = '';
    $("#txtCdDecVieDerechosPeticionOficina").val('');
    $("#txtDecVie_DerechosPeticionOficina").val('');
    isUpdateDecVie_DerechosPeticionOficina = false;

    removeValidationFormByForm('formDecVie_DerechosPeticionOficina');
}

function EditarDecVie_DerechosPeticionOficina(idoficina) {   
    removeValidationFormByForm('formDecVie_DerechosPeticionOficina'); 
    let urlEditar = urlController + "DecVie_DerechosPeticionOficina/GetDecVie_DerechosPeticionOficinaDetails?id_oficina=" + idoficina;
    isUpdateDecVie_DerechosPeticionOficina = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_DerechosPeticionOficina")[0].innerText = datos.id_oficina;
            $("#txtCdDecVieDerechosPeticionOficina").val(datos.nmoficina);
            $("#txtDecVie_DerechosPeticionOficina").val(datos.observaciones);
            $( "#txtCdDecVieDerechosPeticionOficina" ).prop( "disabled", false );            
            isUpdateDecVie_DerechosPeticionOficina = true;
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

function ValidarEliminarDecVie_DerechosPeticionOficina(idoficina, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_DerechosPeticionOficina(idoficina);
            }
        });

}

function EliminarDecVie_DerechosPeticionOficina(idoficina) {
    let urlEliminar = urlController + "DecVie_DerechosPeticionOficina/DeleteDecVie_DerechosPeticionOficina?id_oficina=" + idoficina;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_DerechosPeticionOficina();
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
