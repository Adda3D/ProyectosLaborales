var isUpdateLiteral_UGI = false;
var DataTableLiteral_UGI = null;

$(document).ready(function () {
    LoadDataTableLiteral_UGI();
});

function LoadDataTableLiteral_UGI() {
    DataTableLiteral_UGI = $('#tblLiteral_UGI').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Literal_UGI/GetDataTableLiteral_UGI"
        },      
        "columns": [
            { "data": "nmliteral", "orderable": true },
            { "data": "grupoproducto", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarLiteral_UGI(' + row.id_literal + ')" data-bs-toggle="modal" data-bs-target="#ModalLiteral_UGI" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarLiteral_UGI(' + row.id_literal + ',`' + row.nmliteral + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableLiteral_UGI() {
    DataTableLiteral_UGI.ajax.reload(null, false);    
}

function ValidatePostUpdateLiteral_UGI(formF, botonClose) {
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
                if (!isUpdateLiteral_UGI) {                                          
                    ExisteLiteral_UGI()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateLiteral_UGI(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateLiteral_UGI(botonClose);
                }           
            }
        }
    }
}

function ExisteLiteral_UGI() {    
    let nmliteral = $("#txtCdLiteralUGI").val();   
    let urlValidar = urlController + "Literal_UGI/GetLiteral_UGINombre?cd_nmliteral=" + nmliteral;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmliteral + " ya está registrado.";
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

function AddUpdateLiteral_UGI(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Literal_UGI/UpdateLiteral_UGI";

    objData.id_literal = ($("#spanIdLiteral_UGI")[0].innerText == '') ? undefined : $("#spanIdLiteral_UGI")[0].innerText;
    objData.nmliteral = $("#txtCdLiteralUGI").val();
    objData.grupoproducto = $("#txtLiteral_UGI").val();

    if (objData.id_literal == undefined) {
        urlUpdate = urlController + "Literal_UGI/InsertLiteral_UGI";        
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

            RefreshDataTableLiteral_UGI();
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

function CrearLiteral_UGI() {
    $( "#txtCdLiteralUGI" ).prop( "disabled", false );
    $("#spanIdLiteral_UGI")[0].innerText = '';
    $("#txtCdLiteralUGI").val('');
    $("#txtLiteral_UGI").val('');
    isUpdateLiteral_UGI = false;

    removeValidationFormByForm('formLiteral_UGI');
}

function EditarLiteral_UGI(idliteral) {   
    removeValidationFormByForm('formLiteral_UGI'); 
    let urlEditar = urlController + "Literal_UGI/GetLiteral_UGIDetails?id_literal=" + idliteral;
    isUpdateLiteral_UGI = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdLiteral_UGI")[0].innerText = datos.id_literal;
            $("#txtCdLiteralUGI").val(datos.nmliteral);
            $("#txtLiteral_UGI").val(datos.grupoproducto);
            $( "#txtCdLiteralUGI" ).prop( "disabled", false );            
            isUpdateLiteral_UGI = true;
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

function ValidarEliminarLiteral_UGI(idliteral, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarLiteral_UGI(idliteral);
            }
        });

}

function EliminarLiteral_UGI(idliteral) {
    let urlEliminar = urlController + "Literal_UGI/DeleteLiteral_UGI?id_literal=" + idliteral;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableLiteral_UGI();
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
