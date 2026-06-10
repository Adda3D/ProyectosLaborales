var isUpdateDecVie_SubSerieDoc = false;
var DataTableDecVie_SubSerieDoc = null;

$(document).ready(function () {
    LoadDataTableDecVie_SubSerieDoc();
});

function LoadDataTableDecVie_SubSerieDoc() {
    DataTableDecVie_SubSerieDoc = $('#tblDecVie_SubSerieDoc').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_SubSerieDoc/GetDataTableDecVie_SubSerieDoc"
        },      
        "columns": [
            { "data": "nmsubseriedoc", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_SubSerieDoc(' + row.id_subseriedoc + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_SubSerieDoc" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_SubSerieDoc(' + row.id_subseriedoc + ',`' + row.nmsubseriedoc + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_SubSerieDoc() {
    DataTableDecVie_SubSerieDoc.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_SubSerieDoc(formF, botonClose) {
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
                if (!isUpdateDecVie_SubSerieDoc) {                                          
                    ExisteDecVie_SubSerieDoc()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_SubSerieDoc(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_SubSerieDoc(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_SubSerieDoc() {    
    let nmsubseriedoc = $("#txtCdDecVieSubSerieDoc").val();   
    let urlValidar = urlController + "DecVie_SubSerieDoc/GetDecVie_SubSerieDocNombre?cd_nmsubseriedoc=" + nmsubseriedoc;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmsubseriedoc + " ya está registrado.";
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

function AddUpdateDecVie_SubSerieDoc(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_SubSerieDoc/UpdateDecVie_SubSerieDoc";

    objData.id_subseriedoc = ($("#spanIdDecVie_SubSerieDoc")[0].innerText == '') ? undefined : $("#spanIdDecVie_SubSerieDoc")[0].innerText;
    objData.nmsubseriedoc = $("#txtCdDecVieSubSerieDoc").val();
    objData.observaciones = $("#txtDecVie_SubSerieDoc").val();

    if (objData.id_subseriedoc == undefined) {
        urlUpdate = urlController + "DecVie_SubSerieDoc/InsertDecVie_SubSerieDoc";        
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

            RefreshDataTableDecVie_SubSerieDoc();
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

function CrearDecVie_SubSerieDoc() {
    $( "#txtCdDecVieSubSerieDoc" ).prop( "disabled", false );
    $("#spanIdDecVie_SubSerieDoc")[0].innerText = '';
    $("#txtCdDecVieSubSerieDoc").val('');
    $("#txtDecVie_SubSerieDoc").val('');
    isUpdateDecVie_SubSerieDoc = false;

    removeValidationFormByForm('formDecVie_SubSerieDoc');
}

function EditarDecVie_SubSerieDoc(idsubseriedoc) {   
    removeValidationFormByForm('formDecVie_SubSerieDoc'); 
    let urlEditar = urlController + "DecVie_SubSerieDoc/GetDecVie_SubSerieDocDetails?id_subseriedoc=" + idsubseriedoc;
    isUpdateDecVie_SubSerieDoc = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_SubSerieDoc")[0].innerText = datos.id_subseriedoc;
            $("#txtCdDecVieSubSerieDoc").val(datos.nmsubseriedoc);
            $("#txtDecVie_SubSerieDoc").val(datos.observaciones);
            $( "#txtCdDecVieSubSerieDoc" ).prop( "disabled", false );            
            isUpdateDecVie_SubSerieDoc = true;
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

function ValidarEliminarDecVie_SubSerieDoc(idsubseriedoc, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_SubSerieDoc(idsubseriedoc);
            }
        });

}

function EliminarDecVie_SubSerieDoc(idsubseriedoc) {
    let urlEliminar = urlController + "DecVie_SubSerieDoc/DeleteDecVie_SubSerieDoc?id_subseriedoc=" + idsubseriedoc;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_SubSerieDoc();
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
