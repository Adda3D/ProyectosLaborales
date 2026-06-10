var isUpdateDecVie_ConceptoDecanatura = false;
var DataTableDecVie_ConceptoDecanatura = null;

$(document).ready(function () {
    LoadDataTableDecVie_ConceptoDecanatura();
});

function LoadDataTableDecVie_ConceptoDecanatura() {
    DataTableDecVie_ConceptoDecanatura = $('#tblDecVie_ConceptoDecanatura').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_ConceptoDecanatura/GetDataTableDecVie_ConceptoDecanatura"
        },      
        "columns": [
            { "data": "nmconceptodecanatura", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_ConceptoDecanatura(' + row.id_conceptodecanatura + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_ConceptoDecanatura" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_ConceptoDecanatura(' + row.id_conceptodecanatura + ',`' + row.nmconceptodecanatura + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_ConceptoDecanatura() {
    DataTableDecVie_ConceptoDecanatura.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_ConceptoDecanatura(formF, botonClose) {
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
                if (!isUpdateDecVie_ConceptoDecanatura) {                                          
                    ExisteDecVie_ConceptoDecanatura()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_ConceptoDecanatura(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_ConceptoDecanatura(botonClose);
                }              
            }
        }
    }
}

function ExisteDecVie_ConceptoDecanatura() {    
    let nmconceptodecanatura = $("#txtCdDecVieConceptoDecanatura").val();   
    let urlValidar = urlController + "DecVie_ConceptoDecanatura/GetDecVie_ConceptoDecanaturaNombre?cd_nmconceptodecanatura=" + nmconceptodecanatura;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmconceptodecanatura + " ya está registrado.";
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

function AddUpdateDecVie_ConceptoDecanatura(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_ConceptoDecanatura/UpdateDecVie_ConceptoDecanatura";

    objData.id_conceptodecanatura = ($("#spanIdDecVie_ConceptoDecanatura")[0].innerText == '') ? undefined : $("#spanIdDecVie_ConceptoDecanatura")[0].innerText;
    objData.nmconceptodecanatura = $("#txtCdDecVieConceptoDecanatura").val();
    objData.observaciones = $("#txtDecVie_ConceptoDecanatura").val();

    if (objData.id_conceptodecanatura == undefined) {
        urlUpdate = urlController + "DecVie_ConceptoDecanatura/InsertDecVie_ConceptoDecanatura";        
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

            RefreshDataTableDecVie_ConceptoDecanatura();
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

function CrearDecVie_ConceptoDecanatura() {
    $( "#txtCdDecVieConceptoDecanatura" ).prop( "disabled", false );
    $("#spanIdDecVie_ConceptoDecanatura")[0].innerText = '';
    $("#txtCdDecVieConceptoDecanatura").val('');
    $("#txtDecVie_ConceptoDecanatura").val('');
    isUpdateDecVie_ConceptoDecanatura = false;

    removeValidationFormByForm('formDecVie_ConceptoDecanatura');
}

function EditarDecVie_ConceptoDecanatura(idconceptodecanatura) {   
    removeValidationFormByForm('formDecVie_ConceptoDecanatura'); 
    let urlEditar = urlController + "DecVie_ConceptoDecanatura/GetDecVie_ConceptoDecanaturaDetails?id_conceptodecanatura=" + idconceptodecanatura;
    isUpdateDecVie_ConceptoDecanatura = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_ConceptoDecanatura")[0].innerText = datos.id_conceptodecanatura;
            $("#txtCdDecVieConceptoDecanatura").val(datos.nmconceptodecanatura);
            $("#txtDecVie_ConceptoDecanatura").val(datos.observaciones);
            $( "#txtCdDecVieConceptoDecanatura" ).prop( "disabled", false );            
            isUpdateDecVie_ConceptoDecanatura = true;
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

function ValidarEliminarDecVie_ConceptoDecanatura(idconceptodecanatura, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_ConceptoDecanatura(idconceptodecanatura);
            }
        });

}

function EliminarDecVie_ConceptoDecanatura(idconceptodecanatura) {
    let urlEliminar = urlController + "DecVie_ConceptoDecanatura/DeleteDecVie_ConceptoDecanatura?id_conceptodecanatura=" + idconceptodecanatura;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_ConceptoDecanatura();
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
