var isUpdateProyectos_EstadoProducto = false;
var DataTableProyectos_EstadoProducto = null;

$(document).ready(function () {
    LoadDataTableProyectos_EstadoProducto();
});

function LoadDataTableProyectos_EstadoProducto() {
    DataTableProyectos_EstadoProducto = $('#tblProyectos_EstadoProducto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_EstadoProducto/GetDataTableProyectos_EstadoProducto"
        },      
        "columns": [
            { "data": "estadoproducto", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectos_EstadoProducto(' + row.id_estadoproducto + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectos_EstadoProducto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarProyectos_EstadoProducto(' + row.id_estadoproducto + ',`' + row.estadoproducto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectos_EstadoProducto() {
    DataTableProyectos_EstadoProducto.ajax.reload(null, false);    
}

function ValidatePostUpdateProyectos_EstadoProducto(formF, botonClose) {
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
                if (!isUpdateProyectos_EstadoProducto) {                                          
                    ExisteProyectos_EstadoProducto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateProyectos_EstadoProducto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateProyectos_EstadoProducto(botonClose);
                }                            
            }
        }
    }
}

function ExisteProyectos_EstadoProducto() {    
    let estadoproducto = $("#txtCdProyectosEstadoProducto").val();   
    let urlValidar = urlController + "Proyectos_EstadoProducto/GetProyectos_EstadoProductoNombre?cd_estadoproducto=" + estadoproducto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + estadoproducto + " ya está registrado.";
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

function AddUpdateProyectos_EstadoProducto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_EstadoProducto/UpdateProyectos_EstadoProducto";

    objData.id_estadoproducto = ($("#spanIdProyectos_EstadoProducto")[0].innerText == '') ? undefined : $("#spanIdProyectos_EstadoProducto")[0].innerText;
    objData.estadoproducto = $("#txtCdProyectosEstadoProducto").val();
   // objData.observaciones = $("#txtProyectos_EstadoProducto").val();

    if (objData.id_estadoproducto == undefined) {
        urlUpdate = urlController + "Proyectos_EstadoProducto/InsertProyectos_EstadoProducto";        
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

            RefreshDataTableProyectos_EstadoProducto();
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

function CrearProyectos_EstadoProducto() {
    $( "#txtCdProyectosEstadoProducto" ).prop( "disabled", false );
    $("#spanIdProyectos_EstadoProducto")[0].innerText = '';
    $("#txtCdProyectosEstadoProducto").val('');
    $("#txtProyectos_EstadoProducto").val('');
    isUpdateProyectos_EstadoProducto = false;

    removeValidationFormByForm('formProyectos_EstadoProducto');
}

function EditarProyectos_EstadoProducto(idestadoproducto) {   
    removeValidationFormByForm('formProyectos_EstadoProducto'); 
    let urlEditar = urlController + "Proyectos_EstadoProducto/GetProyectos_EstadoProductoDetails?id_estadoproducto=" + idestadoproducto;
    isUpdateProyectos_EstadoProducto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdProyectos_EstadoProducto")[0].innerText = datos.id_estadoproducto;
            $("#txtCdProyectosEstadoProducto").val(datos.estadoproducto);
   //         $("#txtProyectos_EstadoProducto").val(datos.observaciones);
            $( "#txtCdProyectosEstadoProducto" ).prop( "disabled", false );            
            isUpdateProyectos_EstadoProducto = true;
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

function ValidarEliminarProyectos_EstadoProducto(idestadoproducto, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectos_EstadoProducto(idestadoproducto);
            }
        });

}

function EliminarProyectos_EstadoProducto(idestadoproducto) {
    let urlEliminar = urlController + "Proyectos_EstadoProducto/DeleteProyectos_EstadoProducto?id_estadoproducto=" + idestadoproducto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectos_EstadoProducto();
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
