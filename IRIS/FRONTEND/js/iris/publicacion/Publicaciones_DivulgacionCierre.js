

function CrearPublicaciones_DivulgacionCierre() {
    $("#txtRetroalimentacionDivulgacionCierre" ).prop( "disabled", false );
    $("#spanIdPublicaciones_DivulgacionCierre")[0].innerText = '';
    $("#txtRetroalimentacionDivulgacionCierre").val('');
    $("#txtAgradecimientosDivulgacionCierre").val('');
    $('#chkDifundidaCierre').prop('checked', false); 
    $("#txtBitacoraDivulgacionCierre").val('');
    $("#txtObservacionDivulgacionCierre").val('');
  
    
    
  // isUpdatePublicaciones_DivulgacionCierre = false;

    removeValidationFormByForm('formPublicaciones_DivulgacionCierre');    

}

function EditarPublicaciones_DivulgacionCierre(idcierre) {   
    removeValidationFormByForm('formPublicaciones_DivulgacionCierre'); 
    let urlEditar = urlController + "Publicaciones_DivulgacionCierre/GetPublicaciones_DivulgacionCierreDetails?id_cierre=" + idcierre;
   // isUpdatePublicaciones_DivulgacionCierre = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtRetroalimentacionDivulgacionCierre" ).prop( "disabled", true );
            $("#spanIdPublicaciones_DivulgacionCierre")[0].innerText = datos.id_avalconfac;
            $("#txtRetroalimentacionDivulgacionCierre").val(datos.numeroaval);
            $("#txtAgradecimientosDivulgacionCierre").val(datos.descripcionaval);
            $('#chkDifundidaCierre').prop('checked', false); 
            $("#txtObservacionDivulgacionCierre").val(datos.observaciones);
            $("#cboPublicacionDivulgacionCierre").val(datos.id_crearpublicacion);

          //  isUpdatePublicaciones_DivulgacionCierre = true;
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

function ValidarEliminarPublicaciones_DivulgacionCierre(idcierre, numeroval) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + numeroval + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionCierre(idcierre);
            }
        });

}

function EliminarPublicaciones_DivulgacionCierre(idcierre) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionCierre/DeletePublicaciones_DivulgacionCierre?id_cierre=" + idcierre;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();            
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

function ValidatePostUpdatePublicaciones_DivulgacionCierre(formF) {
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
                                                        
                  
                    AddUpdatePublicaciones_DivulgacionCierre();
                   
                    
                
            }
        }
    }
}

function ExistePublicaciones_DivulgacionCierre() {    
    let idcierre = $("#spanIdPublicaciones_DivulgacionCierre").val();   
    let urlValidar = urlController + "Publicaciones_DivulgacionCierre/GetPublicaciones_DivulgacionCierreDetails?id_cierre=" + idcierre;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "No. identificación " + idcierre + " ya está registrado.";
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

function AddUpdatePublicaciones_DivulgacionCierre(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_DivulgacionCierre/UpdatePublicaciones_DivulgacionCierre";

	objData.id_cierre = ($("#spanIdPublicaciones_DivulgacionCierre")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_DivulgacionCierre")[0].innerText;
	objData.retroalimentacion = $("#txtRetroalimentacionDivulgacionCierre").val();
	objData.agradecimientos = $("#txtAgradecimientosDivulgacionCierre").val();
    objData.infdifundida = $('#chkDifundidaCierre').is(':checked');
	objData.bitacora = $("#txtBitacoraDivulgacionCierre").val();
    objData.observaciones = $("#txtObservacionDivulgacionCierre").val();
    objData.id_crearpublicacion=10;

    if (objData.id_cierre == undefined) {
        urlUpdate = urlController + "Publicaciones_DivulgacionCierre/InsertPublicaciones_DivulgacionCierre";        
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


