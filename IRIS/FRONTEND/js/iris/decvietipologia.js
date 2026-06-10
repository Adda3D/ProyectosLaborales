var isUpdateDecVieTipologia = false;
var DataTableDecVieTipologia = null;

$(document).ready(function () {
    LoadDataTableDecVieTipologia();
});

function LoadDataTableDecVieTipologia() {
    DataTableDecVieTipologia = $('#tblDecVieTipologia').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_Tipologia/GetDataTableDecVieTipologia"
        },      
        "columns": [
            { "data": "nmdecvietipologia", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVieTipologia(' + row.id_decvietipologia + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_Tipologia" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVieTipologia(' + row.id_decvietipologia + ',`' + row.nmdecvietipologia + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVieTipologia() {
    DataTableDecVieTipologia.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_Tipologia(formF, botonClose) {
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
                if (!isUpdateDecVieTipologia) {                                          
                    ExisteDecVieTipologia()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVieTipologia(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVieTipologia(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVieTipologia() {    
    let nmdecvietipologia = $("#txtCdDecVieTipologia").val();   
    let urlValidar = urlController + "DecVie_Tipologia/GetDecVie_TipologiaNombre?cd_nmdecvietipologia=" + nmdecvietipologia;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmdecvietipologia + " ya está registrado.";
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

function AddUpdateDecVieTipologia(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_Tipologia/UpdateDecVie_Tipologia";

    objData.id_decvietipologia = ($("#spanIdDecVie_Tipologia")[0].innerText == '') ? undefined : $("#spanIdDecVie_Tipologia")[0].innerText;
    objData.nmdecvietipologia = $("#txtCdDecVieTipologia").val();
    objData.observaciones = $("#txtDecVie_Tipologia").val();

    if (objData.id_decvietipologia == undefined) {
        urlUpdate = urlController + "DecVie_Tipologia/InsertDecVie_Tipologia";        
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

            RefreshDataTableDecVieTipologia();
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

function CrearDecVieTipologia() {
    $( "#txtCdDecVieTipologia" ).prop( "disabled", false );
    $("#spanIdDecVie_Tipologia")[0].innerText = '';
    $("#txtCdDecVieTipologia").val('');
    $("#txtDecVie_Tipologia").val('');
    isUpdateDecVieTipologia = false;

    removeValidationFormByForm('formDecVie_Tipologia');
}

function EditarDecVieTipologia(iddecvietipologia) {   
    removeValidationFormByForm('formDecVie_Tipologia'); 
    let urlEditar = urlController + "DecVie_Tipologia/GetDecVie_TipologiaDetails?id_decvietipologia=" + iddecvietipologia;
    isUpdateDecVieTipologia = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_Tipologia")[0].innerText = datos.id_decvietipologia;
            $("#txtCdDecVieTipologia").val(datos.nmdecvietipologia);
            $("#txtDecVie_Tipologia").val(datos.observaciones);
            $( "#txtCdDecVieTipologia" ).prop( "disabled", false );            
            isUpdateDecVieTipologia = true;
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

function ValidarEliminarDecVieTipologia(iddecvietipologia, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVieTipologia(iddecvietipologia);
            }
        });

}

function EliminarDecVieTipologia(iddecvietipologia) {
    let urlEliminar = urlController + "DecVie_Tipologia/DeleteDecVie_Tipologia?id_decvietipologia=" + iddecvietipologia;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVieTipologia();
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
