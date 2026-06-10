var isUpdateDecVieTipoDocContractuales = false;
var DataTableDecVieTipoDocContractuales = null;

$(document).ready(function () {
    LoadDataTableDecVieTipoDocContractuales();
});

function LoadDataTableDecVieTipoDocContractuales() {
    DataTableDecVieTipoDocContractuales = $('#tblDecVieTipoDocContractuales').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_TipoDocContractuales/GetDataTableDecVie_TipoDocContractuales"
        },      
        "columns": [
            { "data": "nmdoccontractuales", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVieTipoDocContractuales(' + row.id_doccontractuales + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_TipoDocContractuales" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVieTipoDocContractuales(' + row.id_doccontractuales + ',`' + row.nmdoccontractuales + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVieTipoDocContractuales() {
    DataTableDecVieTipoDocContractuales.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_TipoDocContractuales(formF, botonClose) {
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
                if (!isUpdateDecVieTipoDocContractuales) {                                          
                    ExisteDecVieTipoDocContractuales()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVieTipoDocContractuales(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVieTipoDocContractuales(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVieTipoDocContractuales() {    
    let nmdoccontractuales = $("#txtCdDecVieTipoDocContractuales").val();   
    let urlValidar = urlController + "DecVie_TipoDocContractuales/GetDecVie_TipoDocContractualesNombre?cd_nmdoccontractuales=" + nmdoccontractuales;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmdoccontractuales + " ya está registrado.";
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

function AddUpdateDecVieTipoDocContractuales(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_TipoDocContractuales/UpdateDecVie_TipoDocContractuales";

    objData.id_doccontractuales = ($("#spanIdDecVie_TipoDocContractuales")[0].innerText == '') ? undefined : $("#spanIdDecVie_TipoDocContractuales")[0].innerText;
    objData.nmdoccontractuales = $("#txtCdDecVieTipoDocContractuales").val();
    objData.observaciones = $("#txtDecVie_TipoDocContractuales").val();

    if (objData.id_doccontractuales == undefined) {
        urlUpdate = urlController + "DecVie_TipoDocContractuales/InsertDecVie_TipoDocContractuales";        
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

            RefreshDataTableDecVieTipoDocContractuales();
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

function CrearDecVieTipoDocContractuales() {
    $( "#txtCdDecVieTipoDocContractuales" ).prop( "disabled", false );
    $("#spanIdDecVie_TipoDocContractuales")[0].innerText = '';
    $("#txtCdDecVieTipoDocContractuales").val('');
    $("#txtDecVie_TipoDocContractuales").val('');
    isUpdateDecVieTipoDocContractuales = false;

    removeValidationFormByForm('formDecVie_TipoDocContractuales');
}

function EditarDecVieTipoDocContractuales(iddecvieTipoDocContractuales) {   
    removeValidationFormByForm('formDecVie_TipoDocContractuales'); 
    let urlEditar = urlController + "DecVie_TipoDocContractuales/GetDecVie_TipoDocContractualesDetails?id_doccontractuales=" + iddecvieTipoDocContractuales;
    isUpdateDecVieTipoDocContractuales = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_TipoDocContractuales")[0].innerText = datos.id_doccontractuales;
            $("#txtCdDecVieTipoDocContractuales").val(datos.nmdoccontractuales);
            $("#txtDecVie_TipoDocContractuales").val(datos.observaciones);
            $( "#txtCdDecVieTipoDocContractuales" ).prop( "disabled", false );            
            isUpdateDecVieTipoDocContractuales = true;
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

function ValidarEliminarDecVieTipoDocContractuales(iddecvieTipoDocContractuales, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVieTipoDocContractuales(iddecvieTipoDocContractuales);
            }
        });

}

function EliminarDecVieTipoDocContractuales(iddecvieTipoDocContractuales) {
    let urlEliminar = urlController + "DecVie_TipoDocContractuales/DeleteDecVie_TipoDocContractuales?id_doccontractuales=" + iddecvieTipoDocContractuales;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVieTipoDocContractuales();
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
