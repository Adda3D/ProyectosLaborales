var isUpdateDecVie_SerieDocumental = false;
var DataTableDecVie_SerieDocumental = null;

$(document).ready(function () {
    LoadDataTableDecVie_SerieDocumental();
});

function LoadDataTableDecVie_SerieDocumental() {
    DataTableDecVie_SerieDocumental = $('#tblDecVie_SerieDocumental').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_SerieDocumental/GetDataTableDecVie_SerieDocumental"
        },      
        "columns": [
            { "data": "nminstancia", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_SerieDocumental(' + row.id_seriedocumental + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_SerieDocumental" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_SerieDocumental(' + row.id_seriedocumental + ',`' + row.nminstancia + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_SerieDocumental() {
    DataTableDecVie_SerieDocumental.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_SerieDocumental(formF, botonClose) {
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
                if (!isUpdateDecVie_SerieDocumental) {                                          
                    ExisteDecVie_SerieDocumental()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_SerieDocumental(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_SerieDocumental(botonClose);
                }            
            }
        }
    }
}

function ExisteDecVie_SerieDocumental() {    
    let nminstancia = $("#txtCdDecVieSerieDocumental").val();   
    let urlValidar = urlController + "DecVie_SerieDocumental/GetDecVie_SerieDocumentalNombre?cd_nminstancia=" + nminstancia;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nminstancia + " ya está registrado.";
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

function AddUpdateDecVie_SerieDocumental(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_SerieDocumental/UpdateDecVie_SerieDocumental";

    objData.id_seriedocumental = ($("#spanIdDecVie_SerieDocumental")[0].innerText == '') ? undefined : $("#spanIdDecVie_SerieDocumental")[0].innerText;
    objData.nminstancia = $("#txtCdDecVieSerieDocumental").val();
    objData.observaciones = $("#txtDecVie_SerieDocumental").val();

    if (objData.id_seriedocumental == undefined) {
        urlUpdate = urlController + "DecVie_SerieDocumental/InsertDecVie_SerieDocumental";        
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

            RefreshDataTableDecVie_SerieDocumental();
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

function CrearDecVie_SerieDocumental() {
    $( "#txtCdDecVieSerieDocumental" ).prop( "disabled", false );
    $("#spanIdDecVie_SerieDocumental")[0].innerText = '';
    $("#txtCdDecVieSerieDocumental").val('');
    $("#txtDecVie_SerieDocumental").val('');
    isUpdateDecVie_SerieDocumental = false;

    removeValidationFormByForm('formDecVie_SerieDocumental');
}

function EditarDecVie_SerieDocumental(idseriedocumental) {   
    removeValidationFormByForm('formDecVie_SerieDocumental'); 
    let urlEditar = urlController + "DecVie_SerieDocumental/GetDecVie_SerieDocumentalDetails?id_seriedocumental=" + idseriedocumental;
    isUpdateDecVie_SerieDocumental = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_SerieDocumental")[0].innerText = datos.id_seriedocumental;
            $("#txtCdDecVieSerieDocumental").val(datos.nminstancia);
            $("#txtDecVie_SerieDocumental").val(datos.observaciones);
            $( "#txtCdDecVieSerieDocumental" ).prop( "disabled", false );            
            isUpdateDecVie_SerieDocumental = true;
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

function ValidarEliminarDecVie_SerieDocumental(idseriedocumental, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_SerieDocumental(idseriedocumental);
            }
        });

}

function EliminarDecVie_SerieDocumental(idseriedocumental) {
    let urlEliminar = urlController + "DecVie_SerieDocumental/DeleteDecVie_SerieDocumental?id_seriedocumental=" + idseriedocumental;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_SerieDocumental();
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
