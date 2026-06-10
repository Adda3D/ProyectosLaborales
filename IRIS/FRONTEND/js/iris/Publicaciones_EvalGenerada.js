var isUpdatePublicaciones_EvalGenerada = false;
var DataTablePublicaciones_EvalGenerada = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EvalGenerada();
});

function LoadDataTablePublicaciones_EvalGenerada() {
    DataTablePublicaciones_EvalGenerada = $('#tblPublicaciones_EvalGenerada').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EvalGenerada/GetDataTablePublicaciones_EvalGenerada"
        },      
        "columns": [
            { "data": "conevalgenerada", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EvalGenerada(' + row.id_evalgenerada + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EvalGenerada" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EvalGenerada(' + row.id_evalgenerada + ',`' + row.conevalgenerada + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EvalGenerada() {
    DataTablePublicaciones_EvalGenerada.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EvalGenerada(formF, botonClose) {
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
                if (!isUpdatePublicaciones_EvalGenerada) {                                          
                    ExistePublicaciones_EvalGenerada()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EvalGenerada(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EvalGenerada(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EvalGenerada() {    
    let conevalgenerada = $("#txtCdPublicacionesEvalGenerada").val();   
    let urlValidar = urlController + "Publicaciones_EvalGenerada/GetPublicaciones_EvalGeneradaNombre?cd_conevalgenerada=" + conevalgenerada;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + conevalgenerada + " ya está registrado.";
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

function AddUpdatePublicaciones_EvalGenerada(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EvalGenerada/UpdatePublicaciones_EvalGenerada";

    objData.id_evalgenerada = ($("#spanIdPublicaciones_EvalGenerada")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EvalGenerada")[0].innerText;
    objData.conevalgenerada = $("#txtCdPublicacionesEvalGenerada").val();
   // objData.observaciones = $("#txtPublicaciones_EvalGenerada").val();

    if (objData.id_evalgenerada == undefined) {
        urlUpdate = urlController + "Publicaciones_EvalGenerada/InsertPublicaciones_EvalGenerada";        
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

            RefreshDataTablePublicaciones_EvalGenerada();
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

function CrearPublicaciones_EvalGenerada() {
    $( "#txtCdPublicacionesEvalGenerada" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EvalGenerada")[0].innerText = '';
    $("#txtCdPublicacionesEvalGenerada").val('');
    $("#txtPublicaciones_EvalGenerada").val('');
    isUpdatePublicaciones_EvalGenerada = false;

    removeValidationFormByForm('formPublicaciones_EvalGenerada');
}

function EditarPublicaciones_EvalGenerada(idevalgenerada) {   
    removeValidationFormByForm('formPublicaciones_EvalGenerada'); 
    let urlEditar = urlController + "Publicaciones_EvalGenerada/GetPublicaciones_EvalGeneradaDetails?id_evalgenerada=" + idevalgenerada;
    isUpdatePublicaciones_EvalGenerada = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EvalGenerada")[0].innerText = datos.id_evalgenerada;
            $("#txtCdPublicacionesEvalGenerada").val(datos.conevalgenerada);
   //         $("#txtPublicaciones_EvalGenerada").val(datos.observaciones);
            $( "#txtCdPublicacionesEvalGenerada" ).prop( "disabled", false );            
            isUpdatePublicaciones_EvalGenerada = true;
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

function ValidarEliminarPublicaciones_EvalGenerada(idevalgenerada, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EvalGenerada(idevalgenerada);
            }
        });

}

function EliminarPublicaciones_EvalGenerada(idevalgenerada) {
    let urlEliminar = urlController + "Publicaciones_EvalGenerada/DeletePublicaciones_EvalGenerada?id_evalgenerada=" + idevalgenerada;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EvalGenerada();
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
