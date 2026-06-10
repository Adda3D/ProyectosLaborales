var isUpdateDecVie_Colegiados = false;
var DataTableDecVie_Colegiados = null;

$(document).ready(function () {
    LoadDataTableDecVie_Colegiados();
});

function LoadDataTableDecVie_Colegiados() {
    DataTableDecVie_Colegiados = $('#tblDecVie_Colegiados').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_Colegiados/GetDataTableDecVie_Colegiados"
        },      
        "columns": [
            { "data": "nmcolegiado", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_Colegiados(' + row.id_colegiado + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_Colegiados" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_Colegiados(' + row.id_colegiado + ',`' + row.nmcolegiado + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_Colegiados() {
    DataTableDecVie_Colegiados.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_Colegiados(formF, botonClose) {
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
                if (!isUpdateDecVie_Colegiados) {                                          
                    ExisteDecVie_Colegiados()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_Colegiados(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_Colegiados(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_Colegiados() {    
    let nmcolegiado = $("#txNombreDecVie_Colegiados").val();   
    let urlValidar = urlController + "DecVie_Colegiados/GetDecVie_ColegiadosNombre?cd_nmcolegiado=" + nmcolegiado;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmcolegiado + " ya está registrado.";
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

function AddUpdateDecVie_Colegiados(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_Colegiados/UpdateDecVie_Colegiados";

    objData.id_colegiado = ($("#spanIdDecVie_Colegiados")[0].innerText == '') ? undefined : $("#spanIdDecVie_Colegiados")[0].innerText;
    objData.nmcolegiado = $("#txNombreDecVie_Colegiados").val();
    objData.observaciones = $("#txtObservacionesDecVie_Colegiados").val();

    if (objData.id_colegiado == undefined) {
        urlUpdate = urlController + "DecVie_Colegiados/InsertDecVie_Colegiados";        
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

            RefreshDataTableDecVie_Colegiados();
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

function CrearDecVie_Colegiados() {
    $( "#txNombreDecVie_Colegiados" ).prop( "disabled", false );
    $("#spanIdDecVie_Colegiados")[0].innerText = '';
    $("#txNombreDecVie_Colegiados").val('');
    $("#txtObservacionesDecVie_Colegiados").val('');
    isUpdateDecVie_Colegiados = false;

    removeValidationFormByForm('formDecVie_Colegiados');
}

function EditarDecVie_Colegiados(idcolegiado) {   
    removeValidationFormByForm('formDecVie_Colegiados'); 
    let urlEditar = urlController + "DecVie_Colegiados/GetDecVie_ColegiadosDetails?id_colegiado=" + idcolegiado;
    isUpdateDecVie_Colegiados = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_Colegiados")[0].innerText = datos.id_colegiado;
            $("#txNombreDecVie_Colegiados").val(datos.nmcolegiado);
            $("#txtObservacionesDecVie_Colegiados").val(datos.observaciones);
            $( "#txNombreDecVie_Colegiados" ).prop( "disabled", false );            
            isUpdateDecVie_Colegiados = true;
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

function ValidarEliminarDecVie_Colegiados(idcolegiado, nombrecolegiado) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecolegiado + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_Colegiados(idcolegiado);
            }
        });

}

function EliminarDecVie_Colegiados(idcolegiado) {
    let urlEliminar = urlController + "DecVie_Colegiados/DeleteDecVie_Colegiados?id_colegiado=" + idcolegiado;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_Colegiados();
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
