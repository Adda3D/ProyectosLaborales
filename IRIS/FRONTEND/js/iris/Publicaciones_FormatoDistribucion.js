var isUpdatePublicaciones_FormatoDistribucion = false;
var DataTablePublicaciones_FormatoDistribucion = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_FormatoDistribucion();
});

function LoadDataTablePublicaciones_FormatoDistribucion() {
    DataTablePublicaciones_FormatoDistribucion = $('#tblPublicaciones_FormatoDistribucion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_FormatoDistribucion/GetDataTablePublicaciones_FormatoDistribucion"
        },      
        "columns": [
            { "data": "nmformatodis", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_FormatoDistribucion(' + row.id_formatodistribucion + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_FormatoDistribucion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_FormatoDistribucion(' + row.id_formatodistribucion + ',`' + row.nmformatodis + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_FormatoDistribucion() {
    DataTablePublicaciones_FormatoDistribucion.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_FormatoDistribucion(formF, botonClose) {
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
                if (!isUpdatePublicaciones_FormatoDistribucion) {                                          
                    ExistePublicaciones_FormatoDistribucion()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_FormatoDistribucion(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_FormatoDistribucion(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_FormatoDistribucion() {    
    let nmformatodis = $("#txtCdPublicacionesFormatoDistribucion").val();   
    let urlValidar = urlController + "Publicaciones_FormatoDistribucion/GetPublicaciones_FormatoDistribucionNombre?cd_nmformatodis=" + nmformatodis;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmformatodis + " ya está registrado.";
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

function AddUpdatePublicaciones_FormatoDistribucion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_FormatoDistribucion/UpdatePublicaciones_FormatoDistribucion";

    objData.id_formatodistribucion = ($("#spanIdPublicaciones_FormatoDistribucion")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_FormatoDistribucion")[0].innerText;
    objData.nmformatodis = $("#txtCdPublicacionesFormatoDistribucion").val();
    objData.observaciones = $("#txtPublicaciones_FormatoDistribucion").val();

    if (objData.id_formatodistribucion == undefined) {
        urlUpdate = urlController + "Publicaciones_FormatoDistribucion/InsertPublicaciones_FormatoDistribucion";        
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

            RefreshDataTablePublicaciones_FormatoDistribucion();
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

function CrearPublicaciones_FormatoDistribucion() {
    $( "#txtCdPublicacionesFormatoDistribucion" ).prop( "disabled", false );
    $("#spanIdPublicaciones_FormatoDistribucion")[0].innerText = '';
    $("#txtCdPublicacionesFormatoDistribucion").val('');
    $("#txtPublicaciones_FormatoDistribucion").val('');
    isUpdatePublicaciones_FormatoDistribucion = false;

    removeValidationFormByForm('formPublicaciones_FormatoDistribucion');
}

function EditarPublicaciones_FormatoDistribucion(idformatodistribucion) {   
    removeValidationFormByForm('formPublicaciones_FormatoDistribucion'); 
    let urlEditar = urlController + "Publicaciones_FormatoDistribucion/GetPublicaciones_FormatoDistribucionDetails?id_formatodistribucion=" + idformatodistribucion;
    isUpdatePublicaciones_FormatoDistribucion = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_FormatoDistribucion")[0].innerText = datos.id_formatodistribucion;
            $("#txtCdPublicacionesFormatoDistribucion").val(datos.nmformatodis);
            $("#txtPublicaciones_FormatoDistribucion").val(datos.observaciones);
            $( "#txtCdPublicacionesFormatoDistribucion" ).prop( "disabled", false );            
            isUpdatePublicaciones_FormatoDistribucion = true;
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

function ValidarEliminarPublicaciones_FormatoDistribucion(idformatodistribucion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_FormatoDistribucion(idformatodistribucion);
            }
        });

}

function EliminarPublicaciones_FormatoDistribucion(idformatodistribucion) {
    let urlEliminar = urlController + "Publicaciones_FormatoDistribucion/DeletePublicaciones_FormatoDistribucion?id_formatodistribucion=" + idformatodistribucion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_FormatoDistribucion();
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
