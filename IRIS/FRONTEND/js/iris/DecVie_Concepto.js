var isUpdateDecVie_Concepto = false;
var DataTableDecVie_Concepto = null;

$(document).ready(function () {
    LoadDataTableDecVie_Concepto();
});

function LoadDataTableDecVie_Concepto() {
    DataTableDecVie_Concepto = $('#tblDecVie_Concepto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_Concepto/GetDataTableDecVie_Concepto"
        },      
        "columns": [
            { "data": "nmconcepto", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_Concepto(' + row.id_decvieconcepto + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_Concepto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_Concepto(' + row.id_decvieconcepto + ',`' + row.nmconcepto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_Concepto() {
    DataTableDecVie_Concepto.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_Concepto(formF, botonClose) {
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
                if (!isUpdateDecVie_Concepto) {                                          
                    ExisteDecVie_Concepto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_Concepto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_Concepto(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_Concepto() {    
    let nmconcepto = $("#txtCdDecVieConcepto").val();   
    let urlValidar = urlController + "DecVie_Concepto/GetDecVie_ConceptoNombre?cd_nmconcepto=" + nmconcepto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmconcepto + " ya está registrado.";
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

function AddUpdateDecVie_Concepto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_Concepto/UpdateDecVie_Concepto";

    objData.id_decvieconcepto = ($("#spanIdDecVie_Concepto")[0].innerText == '') ? undefined : $("#spanIdDecVie_Concepto")[0].innerText;
    objData.nmconcepto = $("#txtCdDecVieConcepto").val();
    objData.observaciones = $("#txtDecVie_Concepto").val();

    if (objData.id_decvieconcepto == undefined) {
        urlUpdate = urlController + "DecVie_Concepto/InsertDecVie_Concepto";        
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

            RefreshDataTableDecVie_Concepto();
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

function CrearDecVie_Concepto() {
    $( "#txtCdDecVieConcepto" ).prop( "disabled", false );
    $("#spanIdDecVie_Concepto")[0].innerText = '';
    $("#txtCdDecVieConcepto").val('');
    $("#txtDecVie_Concepto").val('');
    isUpdateDecVie_Concepto = false;

    removeValidationFormByForm('formDecVie_Concepto');
}

function EditarDecVie_Concepto(iddecvieconcepto) {   
    removeValidationFormByForm('formDecVie_Concepto'); 
    let urlEditar = urlController + "DecVie_Concepto/GetDecVie_ConceptoDetails?id_decvieconcepto=" + iddecvieconcepto;
    isUpdateDecVie_Concepto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_Concepto")[0].innerText = datos.id_decvieconcepto;
            $("#txtCdDecVieConcepto").val(datos.nmconcepto);
            $("#txtDecVie_Concepto").val(datos.observaciones);
            $( "#txtCdDecVieConcepto" ).prop( "disabled", false );            
            isUpdateDecVie_Concepto = true;
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

function ValidarEliminarDecVie_Concepto(iddecvieconcepto, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_Concepto(iddecvieconcepto);
            }
        });

}

function EliminarDecVie_Concepto(iddecvieconcepto) {
    let urlEliminar = urlController + "DecVie_Concepto/DeleteDecVie_Concepto?id_decvieconcepto=" + iddecvieconcepto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_Concepto();
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
