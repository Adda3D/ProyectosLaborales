var DataTablePublicaciones_Autores = null;

$(document).ready(function () {    
    InicializaPublicaciones_Autoresform($("#spanIdPublicacion")[0].innerText, $("#spanKardexPublicacion")[0].innerText,
                                                $("#spanHermesPublicacion")[0].innerText, $("#spanNombrePublicacion")[0].innerText);

});


function LoadDataTablePublicaciones_Autores() {
    DataTablePublicaciones_Autores = $('#tblPublicaciones_Autores').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_Autores/GetDataTablePublicaciones_AutoresByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }             
            }
        },      
        "columns": [                    
            { "data": "NombrePersona", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Retirar Autor" onclick="ValidarEliminarAutorPublicaciones_Autores(' + row.id_autores + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_Autores() {
    DataTablePublicaciones_Autores.ajax.reload(null, false);
}

function VolverTablaPublicaciones_AutoresDesdeAutores() {
    $("#dvPublicacionTablaAutores").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaPublicaciones_Autoresform(iidPublicacion, idkardex, idhermes, nombre) {
    $("#spanIdPublicaciones_Autores")[0].innerText = iidPublicacion; 

    $("#txtConsPublicaciones_Autores").val(idkardex);
    $("#txtTituloPublicaciones_Autores").val(idhermes);
    $("#txtNombrePublicaciones_Autores").val(nombre);
    
    if (DataTablePublicaciones_Autores != null) {
        DataTablePublicaciones_Autores.destroy();
    }

    LoadDataTablePublicaciones_Autores(); 

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionTablaAutores").removeClass("ocultar");
}

function CrearAutorPublicaciones_Autores() {
    $("#spanPublicaciones_AutoresIdAutor")[0].innerText = '';

    LoadPrestadorServicio('cboAutorPublicaciones_Autores', true);          

    $('#cboAutorPublicaciones_Autores').select2({
        dropdownParent: $('#ModalPublicaciones_Autores'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    removeValidationFormByForm('formPublicaciones_AutoresDatos');    
}

function ValidatePostUpdatePublicaciones_Autores(formF, botonCerrar) {
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
                ExistePublicaciones_Autores()
                    .then(existe => {
                        if (!existe) {                                    
                            AddUpdateExistePublicaciones_Autores(botonCerrar);
                        }
                    })                 
            }
        }
    }    
}

function ExistePublicaciones_Autores() {
    debugger;
    let idpublicacion = $("#spanIdPublicaciones_Autores")[0].innerText;
    let id_persona = $("#cboAutorPublicaciones_Autores").val();

    let urlValidar = urlController + "Publicaciones_Autores/GetPublicaciones_AutoresByPublicacionPersona?id_crearpublicacion=" +idpublicacion  + "&id_persona=" + id_persona;

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El autor ya está registrado para la publicaión.";
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

function AddUpdateExistePublicaciones_Autores(botonCerrar) {
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_Autores/UpdatePublicaciones_Autores";

    objData.id_autores = undefined;
	objData.id_crearpublicacion = ($("#spanIdPublicaciones_Autores")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_Autores")[0].innerText;    
    objData.id_persona = $("#cboAutorPublicaciones_Autores").val();
    
    if (objData.id_autores == undefined) {
        urlUpdate = urlController + "Publicaciones_Autores/InsertPublicaciones_Autores";        
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

            RefreshDataTablePublicaciones_Autores();
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

function CerrarModalPublicaciones_Autores() {
    if ($('#cboAutorPublicaciones_Autores').data('select2')) {
        $('#cboAutorPublicaciones_Autores').select2('destroy');        
      }    

}

function ValidarEliminarAutorPublicaciones_Autores(id_autores) {
    ShowDialogConfirmacion('','Seguro de eliminar autor', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_Autores(id_autores);
            }
        });
}

function EliminarPublicaciones_Autores(id_autores) {
    let urlEliminar = urlController + "Publicaciones_Autores/DeletePublicaciones_Autores?id_autores=" + id_autores;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_Autores();
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