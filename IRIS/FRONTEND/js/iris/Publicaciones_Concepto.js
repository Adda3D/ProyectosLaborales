var isUpdatePublicaciones_Concepto = false;
var DataTablePublicaciones_Concepto = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_Concepto();
});

function LoadDataTablePublicaciones_Concepto() {
    DataTablePublicaciones_Concepto = $('#tblPublicaciones_Concepto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_Concepto/GetDataTablePublicaciones_Concepto"
        },      
        "columns": [
            { "data": "nmconcepto", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_Concepto(' + row.id_concepto + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_Concepto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_Concepto(' + row.id_concepto + ',`' + row.nmconcepto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_Concepto() {
    DataTablePublicaciones_Concepto.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_Concepto(formF, botonClose) {
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
                if ($("#spanIdPublicaciones_Concepto")[0].innerText == '') {
                    ExistePublicaciones_Concepto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_Concepto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_Concepto(botonClose);
                }
            }
        }
    }
}

function ExistePublicaciones_Concepto() {    
    let nmconcepto = $("#txtCdPublicacionesConcepto").val();   
    let urlValidar = urlController + "Publicaciones_Concepto/GetPublicaciones_ConceptoNombre?cd_nmconcepto=" + nmconcepto;    

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

function AddUpdatePublicaciones_Concepto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_Concepto/UpdatePublicaciones_Concepto";

    objData.id_concepto = ($("#spanIdPublicaciones_Concepto")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_Concepto")[0].innerText;
    objData.nmconcepto = $("#txtCdPublicacionesConcepto").val();    

    if (objData.id_concepto == undefined) {
        urlUpdate = urlController + "Publicaciones_Concepto/InsertPublicaciones_Concepto";        
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

            RefreshDataTablePublicaciones_Concepto();
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

function CrearPublicaciones_Concepto() {
    $( "#txtCdPublicacionesConcepto" ).prop( "disabled", false );
    $("#spanIdPublicaciones_Concepto")[0].innerText = '';
    $("#txtCdPublicacionesConcepto").val('');
    $("#txtPublicaciones_Concepto").val('');
    isUpdatePublicaciones_Concepto = false;

    removeValidationFormByForm('formPublicaciones_Concepto');
}

function EditarPublicaciones_Concepto(idconcepto) {   
    removeValidationFormByForm('formPublicaciones_Concepto'); 
    let urlEditar = urlController + "Publicaciones_Concepto/GetPublicaciones_ConceptoDetails?id_concepto=" + idconcepto;
    isUpdatePublicaciones_Concepto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_Concepto")[0].innerText = datos.id_concepto;
            $("#txtCdPublicacionesConcepto").val(datos.nmconcepto);
            $("#txtPublicaciones_Concepto").val(datos.detalles);
            $( "#txtCdPublicacionesConcepto" ).prop( "disabled", false );            
            isUpdatePublicaciones_Concepto = true;
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

function ValidarEliminarPublicaciones_Concepto(idconcepto, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_Concepto(idconcepto);
            }
        });

}

function EliminarPublicaciones_Concepto(idconcepto) {
    let urlEliminar = urlController + "Publicaciones_Concepto/DeletePublicaciones_Concepto?id_concepto=" + idconcepto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_Concepto();
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
