var isUpdateDecVie_RevSigep = false;
var DataTableDecVie_RevSigep = null;

$(document).ready(function () {
    LoadDataTableDecVie_RevSigep();
});

function LoadDataTableDecVie_RevSigep() {
    DataTableDecVie_RevSigep = $('#tblDecVie_RevSigep').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_RevSigep/GetDataTableDecVie_RevSigep"
        },      
        "columns": [
            { "data": "nmrevsigep", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_RevSigep(' + row.id_revsigep + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_RevSigep" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_RevSigep(' + row.id_revsigep + ',`' + row.nmrevsigep + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_RevSigep() {
    DataTableDecVie_RevSigep.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_RevSigep(formF, botonClose) {
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
                if (!isUpdateDecVie_RevSigep) {                                          
                    ExisteDecVie_RevSigep()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_RevSigep(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_RevSigep(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_RevSigep() {    
    let nmrevsigep = $("#txtCdDecVieRevSigep").val();   
    let urlValidar = urlController + "DecVie_RevSigep/GetDecVie_RevSigepNombre?cd_nmrevsigep=" + nmrevsigep;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmrevsigep + " ya está registrado.";
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

function AddUpdateDecVie_RevSigep(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_RevSigep/UpdateDecVie_RevSigep";

    objData.id_revsigep = ($("#spanIdDecVie_RevSigep")[0].innerText == '') ? undefined : $("#spanIdDecVie_RevSigep")[0].innerText;
    objData.nmrevsigep = $("#txtCdDecVieRevSigep").val();
    objData.observaciones = $("#txtDecVie_RevSigep").val();

    if (objData.id_revsigep == undefined) {
        urlUpdate = urlController + "DecVie_RevSigep/InsertDecVie_RevSigep";        
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

            RefreshDataTableDecVie_RevSigep();
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

function CrearDecVie_RevSigep() {
    $( "#txtCdDecVieRevSigep" ).prop( "disabled", false );
    $("#spanIdDecVie_RevSigep")[0].innerText = '';
    $("#txtCdDecVieRevSigep").val('');
    $("#txtDecVie_RevSigep").val('');
    isUpdateDecVie_RevSigep = false;

    removeValidationFormByForm('formDecVie_RevSigep');
}

function EditarDecVie_RevSigep(idrevsigep) {   
    removeValidationFormByForm('formDecVie_RevSigep'); 
    let urlEditar = urlController + "DecVie_RevSigep/GetDecVie_RevSigepDetails?id_revsigep=" + idrevsigep;
    isUpdateDecVie_RevSigep = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_RevSigep")[0].innerText = datos.id_revsigep;
            $("#txtCdDecVieRevSigep").val(datos.nmrevsigep);
            $("#txtDecVie_RevSigep").val(datos.observaciones);
            $( "#txtCdDecVieRevSigep" ).prop( "disabled", false );            
            isUpdateDecVie_RevSigep = true;
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

function ValidarEliminarDecVie_RevSigep(idrevsigep, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_RevSigep(idrevsigep);
            }
        });

}

function EliminarDecVie_RevSigep(idrevsigep) {
    let urlEliminar = urlController + "DecVie_RevSigep/DeleteDecVie_RevSigep?id_revsigep=" + idrevsigep;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_RevSigep();
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
