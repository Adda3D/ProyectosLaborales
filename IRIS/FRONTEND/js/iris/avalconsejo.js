var isUpdateAvalConsejo = false;
var DataTableAvalConsejo = null;

$(document).ready(function () {
    LoadDataTableAvalConsejo(); 
     
});


function LoadDataTableAvalConsejo() {
    DataTableAvalConsejo = $('#tblAvalConsejo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_AvalConsejoFacultad/GetDataTablePropuestaAvalConsejoFacultad"
        },      
        "columns": [            
            { "data": "numeroaval", "orderable": true },
            { "data": "descripcionaval", "orderable": false },
            { "data": "enlaceavalconfac", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaAvalConsejo(' + row.id_avalconfac + ')" data-bs-toggle="modal" data-bs-target="#ModalAvalConsejo" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarAvalConsejo(' + row.id_avalconfac + ',`' + row.numeroaval + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDataTableAvalConsejo() {
    DataTableAvalConsejo.ajax.reload(null, false);
}

function CrearAvalConsejo() {
    $("#txtNroAvalConsejo" ).prop( "disabled", false );
    $("#spanIdAvalConsejo")[0].innerText = '';
    $("#txtNroAvalConsejo").val('');
    $("#txtDescrAvalConsejo").val('');
    $("#txtObservacionAvalConsejo").val('');
    $("#txtEnlaceAvalConsejo").val('');
    
    isUpdateAvalConsejo = false;

    removeValidationFormByForm('formAvalConsejo');
}

function EditarPropuestaAvalConsejo(idAvalConsejo) {   
    removeValidationFormByForm('formAvalConsejo'); 
    let urlEditar = urlController + "Propuesta_AvalConsejoFacultad/GetPropuesta_AvalConsejoFacultadDetails?id_avalconfac=" + idAvalConsejo;
    isUpdateAvalConsejo = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtNroAvalConsejo" ).prop( "disabled", true );
            $("#spanIdAvalConsejo")[0].innerText = datos.id_avalconfac;
            $("#txtNroAvalConsejo").val(datos.numeroaval);
            $("#txtDescrAvalConsejo").val(datos.descripcionaval);
            $("#txtObservacionAvalConsejo").val(datos.observacionesaval);
            $("#txtEnlaceAvalConsejo").val(datos.enlaceavalconfac);

            isUpdateAvalConsejo = true;
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

function ValidarEliminarAvalConsejo(idAvalConsejo, numeroaval) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + numeroaval + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaAvalConsejo(idAvalConsejo);
            }
        });

}

function EliminarPropuestaAvalConsejo(idAvalConsejo) {
    let urlEliminar = urlController + "Propuesta_AvalConsejoFacultad/DeletePropuesta_AvalConsejoFacultad?id_avalconfac=" + idAvalConsejo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableAvalConsejo();
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

function ValidatePostUpdateAvalConsejo(formF, botonClose) {
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
                if (!isUpdateAvalConsejo) {                                          
                    ExisteIdentificacionAvalConsejo()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateAvalConsejo(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateAvalConsejo(botonClose);
                }            
            }
        }
    }
}

function ExisteIdentificacionAvalConsejo() {    
    let nroAvalConsejo = $("#txtNroAvalConsejo").val();   
    let urlValidar = urlController + "Propuesta_AvalConsejoFacultad/GetPropuesta_AvalConsejoFacultadDetails?numeroaval=" + nroAvalConsejo;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "No. identificación " + nroAvalConsejo + " ya está registrado.";
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

function AddUpdateAvalConsejo(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_AvalConsejoFacultad/UpdatePropuesta_AvalConsejoFacultad";

	objData.id_avalconfac = ($("#spanIdAvalConsejo")[0].innerText == '') ? undefined : $("#spanIdAvalConsejo")[0].innerText;
	objData.numeroaval = $("#txtNroAvalConsejo").val();
	objData.descripcionaval = $("#txtDescrAvalConsejo").val();
	objData.observacionesaval = $("#txtObservacionAvalConsejo").val();
	objData.enlaceavalconfac = $("#txtEnlaceAvalConsejo").val();

    if (objData.id_avalconfac == undefined) {
        urlUpdate = urlController + "Propuesta_AvalConsejoFacultad/InsertPropuesta_AvalConsejoFacultad";        
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
            
            RefreshDataTableDataTableAvalConsejo();

            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

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


