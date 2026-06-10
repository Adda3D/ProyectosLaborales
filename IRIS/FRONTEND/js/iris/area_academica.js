var isUpdateAreaAcademica = false;
var DataTableAreaAcademica = null;

$(document).ready(function () {
    LoadDataTableAreaAcademica();
});

function LoadDataTableAreaAcademica() {
    DataTableAreaAcademica = $('#tblAreaAcademica').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Area_Academica/GetDatataTableArea"
        },      
        "columns": [
            { "data": "codarea", "orderable": true },
            { "data": "nmaacad", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarAreaAcademica(' + row.id_areaacad + ')" data-bs-toggle="modal" data-bs-target="#ModalArea_Academica" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarAreaAcademica(' + row.id_areaacad + ',`' + row.nmaacad + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableAreaAcademica() {
    DataTableAreaAcademica.ajax.reload(null, false);    
}

function ValidatePostUpdateArea_Academica(formF, botonClose) {
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
                if (!isUpdateAreaAcademica) {                                          
                        ExisteCodigoArea()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateAreaAcademica(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateAreaAcademica(botonClose);
                }            
            }
        }
    }
}

function ExisteCodigoArea() {    
    let codigoAreaAcademica = $("#txtCdAreaAcademica").val();   
    let urlValidar = urlController + "Area_Academica/GetArea_AcademicaCodigo?cd_areaacad=" + codigoAreaAcademica;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El código " + codigoAreaAcademica + " ya está registrado.";
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

function AddUpdateAreaAcademica(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Area_Academica/UpdateArea_Academica";

    objData.id_areaacad = ($("#spanIdArea_Academica")[0].innerText == '') ? undefined : $("#spanIdArea_Academica")[0].innerText;
    objData.codarea = $("#txtCdAreaAcademica").val();
    objData.nmaacad = $("#txtArea_Academica").val();

    if (objData.id_areaacad == undefined) {
        urlUpdate = urlController + "Area_Academica/InsertArea_Academica";        
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

            RefreshDataTableAreaAcademica();
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

function CrearAreaAcademica() {
    $( "#txtCdAreaAcademica" ).prop( "disabled", false );
    $("#spanIdArea_Academica")[0].innerText = '';
    $("#txtCdAreaAcademica").val('');
    $("#txtArea_Academica").val('');
    isUpdateAreaAcademica = false;

    removeValidationFormByForm('formArea_Academica');
}

function EditarAreaAcademica(idArea) {   
    removeValidationFormByForm('formArea_Academica'); 
    let urlEditar = urlController + "Area_Academica/GetArea_AcademicaDetails?id_areaacad=" + idArea;
    isUpdateAreaAcademica = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdArea_Academica")[0].innerText = datos.id_areaacad;
            $("#txtCdAreaAcademica").val(datos.codarea);
            $("#txtArea_Academica").val(datos.nmaacad);
            $( "#txtCdAreaAcademica" ).prop( "disabled", true );            
            isUpdateAreaAcademica = true;
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

function ValidarEliminarAreaAcademica(idArea, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarAreaAcademica(idArea);
            }
        });

}

function EliminarAreaAcademica(idArea) {
    let urlEliminar = urlController + "Area_Academica/DeleteArea_Academica?id_areaacad=" + idArea;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableAreaAcademica();
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
