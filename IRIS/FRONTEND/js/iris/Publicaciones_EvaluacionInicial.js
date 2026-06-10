var isUpdatePublicaciones_EvaluacionInicial = false;
var DataTablePublicaciones_EvaluacionInicial = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EvaluacionInicial();
});

function LoadDataTablePublicaciones_EvaluacionInicial() {
    DataTablePublicaciones_EvaluacionInicial = $('#tblPublicaciones_EvaluacionInicial').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EvaluacionInicial/GetDataTablePublicaciones_EvaluacionInicial"
        },      
        "columns": [
            { "data": "nmevalinicial", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EvaluacionInicial(' + row.id_evaluacioninicial + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EvaluacionInicial" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EvaluacionInicial(' + row.id_evaluacioninicial + ',`' + row.nmevalinicial + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EvaluacionInicial() {
    DataTablePublicaciones_EvaluacionInicial.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EvaluacionInicial(formF, botonClose) {
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
                if (!isUpdatePublicaciones_EvaluacionInicial) {                                          
                    ExistePublicaciones_EvaluacionInicial()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EvaluacionInicial(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EvaluacionInicial(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EvaluacionInicial() {    
    let nmevalinicial = $("#txtCdPublicacionesEvaluacionInicial").val();   
    let urlValidar = urlController + "Publicaciones_EvaluacionInicial/GetPublicaciones_EvaluacionInicialNombre?cd_nmevalinicial=" + nmevalinicial;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmevalinicial + " ya está registrado.";
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

function AddUpdatePublicaciones_EvaluacionInicial(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EvaluacionInicial/UpdatePublicaciones_EvaluacionInicial";

    objData.id_evaluacioninicial = ($("#spanIdPublicaciones_EvaluacionInicial")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EvaluacionInicial")[0].innerText;
    objData.nmevalinicial = $("#txtCdPublicacionesEvaluacionInicial").val();
   // objData.observaciones = $("#txtPublicaciones_EvaluacionInicial").val();

    if (objData.id_evaluacioninicial == undefined) {
        urlUpdate = urlController + "Publicaciones_EvaluacionInicial/InsertPublicaciones_EvaluacionInicial";        
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

            RefreshDataTablePublicaciones_EvaluacionInicial();
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

function CrearPublicaciones_EvaluacionInicial() {
    $( "#txtCdPublicacionesEvaluacionInicial" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EvaluacionInicial")[0].innerText = '';
    $("#txtCdPublicacionesEvaluacionInicial").val('');
    $("#txtPublicaciones_EvaluacionInicial").val('');
    isUpdatePublicaciones_EvaluacionInicial = false;

    removeValidationFormByForm('formPublicaciones_EvaluacionInicial');
}

function EditarPublicaciones_EvaluacionInicial(idevaluacioninicial) {   
    removeValidationFormByForm('formPublicaciones_EvaluacionInicial'); 
    let urlEditar = urlController + "Publicaciones_EvaluacionInicial/GetPublicaciones_EvaluacionInicialDetails?id_evaluacioninicial=" + idevaluacioninicial;
    isUpdatePublicaciones_EvaluacionInicial = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EvaluacionInicial")[0].innerText = datos.id_evaluacioninicial;
            $("#txtCdPublicacionesEvaluacionInicial").val(datos.nmevalinicial);
   //         $("#txtPublicaciones_EvaluacionInicial").val(datos.observaciones);
            $( "#txtCdPublicacionesEvaluacionInicial" ).prop( "disabled", false );            
            isUpdatePublicaciones_EvaluacionInicial = true;
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

function ValidarEliminarPublicaciones_EvaluacionInicial(idevaluacioninicial, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EvaluacionInicial(idevaluacioninicial);
            }
        });

}

function EliminarPublicaciones_EvaluacionInicial(idevaluacioninicial) {
    let urlEliminar = urlController + "Publicaciones_EvaluacionInicial/DeletePublicaciones_EvaluacionInicial?id_evaluacioninicial=" + idevaluacioninicial;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EvaluacionInicial();
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
