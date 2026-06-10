var isUpdateProyectos_TipoProducto = false;
var DataTableProyectos_TipoProducto = null;

$(document).ready(function () {
    LoadDataTableProyectos_TipoProducto();
});

function LoadDataTableProyectos_TipoProducto() {
    DataTableProyectos_TipoProducto = $('#tblProyectos_TipoProducto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_TipoProducto/GetDataTableProyectoTipoProducto"
        },      
        "columns": [
            { "data": "tipoproducto", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectos_TipoProducto(' + row.id_tipoproducto + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectos_TipoProducto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarProyectos_TipoProducto(' + row.id_tipoproducto + ',`' + row.tipoproducto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectos_TipoProducto() {
    DataTableProyectos_TipoProducto.ajax.reload(null, false);    
}

function ValidatePostUpdateProyectos_TipoProducto(formF, botonClose) {
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
                if (!isUpdateProyectos_TipoProducto) {                                          
                    ExisteProyectos_TipoProducto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateProyectos_TipoProducto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateProyectos_TipoProducto(botonClose);
                }                            
            }
        }
    }
}

function ExisteProyectos_TipoProducto() {    
    let tipoproducto = $("#txtCdProyectosTipoProducto").val();   
    let urlValidar = urlController + "Proyectos_TipoProducto/GetProyectos_TipoProductoNombre?cd_tipoproducto=" + tipoproducto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + tipoproducto + " ya está registrado.";
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

function AddUpdateProyectos_TipoProducto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_TipoProducto/UpdateProyectos_TipoProducto";

    objData.id_tipoproducto = ($("#spanIdProyectos_TipoProducto")[0].innerText == '') ? undefined : $("#spanIdProyectos_TipoProducto")[0].innerText;
    objData.tipoproducto = $("#txtCdProyectosTipoProducto").val();
   // objData.observaciones = $("#txtProyectos_TipoProducto").val();

    if (objData.id_tipoproducto == undefined) {
        urlUpdate = urlController + "Proyectos_TipoProducto/InsertProyectos_TipoProducto";        
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

            RefreshDataTableProyectos_TipoProducto();
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

function CrearProyectos_TipoProducto() {
    $( "#txtCdProyectosTipoProducto" ).prop( "disabled", false );
    $("#spanIdProyectos_TipoProducto")[0].innerText = '';
    $("#txtCdProyectosTipoProducto").val('');
    $("#txtProyectos_TipoProducto").val('');
    isUpdateProyectos_TipoProducto = false;

    removeValidationFormByForm('formProyectos_TipoProducto');
}

function EditarProyectos_TipoProducto(idtipoproducto) {   
    removeValidationFormByForm('formProyectos_TipoProducto'); 
    let urlEditar = urlController + "Proyectos_TipoProducto/GetProyectos_TipoProductoDetails?id_tipoproducto=" + idtipoproducto;
    isUpdateProyectos_TipoProducto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdProyectos_TipoProducto")[0].innerText = datos.id_tipoproducto;
            $("#txtCdProyectosTipoProducto").val(datos.tipoproducto);
   //         $("#txtProyectos_TipoProducto").val(datos.observaciones);
            $( "#txtCdProyectosTipoProducto" ).prop( "disabled", false );            
            isUpdateProyectos_TipoProducto = true;
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

function ValidarEliminarProyectos_TipoProducto(idtipoproducto, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectos_TipoProducto(idtipoproducto);
            }
        });

}

function EliminarProyectos_TipoProducto(idtipoproducto) {
    let urlEliminar = urlController + "Proyectos_TipoProducto/DeleteProyectos_TipoProducto?id_tipoproducto=" + idtipoproducto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectos_TipoProducto();
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
