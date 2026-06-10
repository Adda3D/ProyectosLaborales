var isUpdateInvestigacion_CrearLinea = false;
var DataTableInvestigacion_CrearLinea = null;

$(document).ready(function () {
    LoadDataTableInvestigacion_CrearLinea();
     
});


function LoadDataTableInvestigacion_CrearLinea() {
    DataTableInvestigacion_CrearLinea = $('#tblInvestigacion_CrearLinea').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_CrearLinea/GetDataTableInvestigacion_CrearLinea"
        },      
        "columns": [            
            { "data": "linea", "orderable": true },
            { "data": "campointeres", "orderable": true },
            //{ "data": "NomGrupo", "orderable": true },
           // { "data": "correo", "orderable": false },
            { "data": "NomGrupo", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarInvestigacion_CrearLinea(' + row.id_crearlinea + ')" data-bs-toggle="modal" data-bs-target="#ModalInvestigacion_CrearLinea" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarInvestigacion_CrearLinea(' + row.id_crearlinea + ',`' + row.nombrecompleto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableInvestigacion_CrearLinea() {
    DataTableInvestigacion_CrearLinea.ajax.reload(null, false);
}

function CrearInvestigacion_CrearLinea() {
    $("#txtLineaInvestigacion_CrearLinea" ).prop( "disabled", false );
    $("#spanIdInvestigacion_CrearLinea")[0].innerText = '';
    $("#txtLineaInvestigacion_CrearLinea").val('');
    $("#txtCampoInvestigacion_CrearLinea").val('');
    //$("#txtApellidoFuncionario").val('');
   // $("#txtEmailFuncionario").val('');

   LoadGrupoInvestigacionSelect('cboGrupoInvestigacionCrearLinea', true);    

    $('#cboGrupoInvestigacionCrearLinea').select2({
        dropdownParent: $('#ModalInvestigacion_CrearLinea'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    isUpdateInvestigacion_CrearLinea = false;

    removeValidationFormByForm('formModalInvestigacion_CrearLinea');
}

function EditarInvestigacion_CrearLinea(idcrearlinea) {   
    removeValidationFormByForm('formModalInvestigacion_CrearLinea'); 
    let urlEditar = urlController + "Investigacion_CrearLinea/GetInvestigacion_CrearLineaDetails?id_crearlinea=" + idcrearlinea;
    isUpdateInvestigacion_CrearLinea = false;
    StartLoader();

    LoadGrupoInvestigacionSelect('cboGrupoInvestigacionCrearLinea', true);   

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtLineaInvestigacion_CrearLinea" ).prop( "disabled", false );
            $("#spanIdInvestigacion_CrearLinea")[0].innerText = datos.id_crearlinea;
            $("#txtLineaInvestigacion_CrearLinea").val(datos.linea);
            $("#txtCampoInvestigacion_CrearLinea").val(datos.campointeres);
            //$("#txtApellidoFuncionario").val(datos.apellidos);
            //$("#txtEmailFuncionario").val(datos.correo);
            $('#cboGrupoInvestigacionCrearLinea').select2().val(datos.id_creargrupo).trigger("change");

            $('#cboGrupoInvestigacionCrearLinea').select2({
                dropdownParent: $('#ModalInvestigacion_CrearLinea'),
                placeholder: "Seleccione",        
                width: 'resolve'
            });
        
            isUpdateInvestigacion_CrearLinea = true;
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



function ValidarEliminarInvestigacion_CrearLinea(id_crearlinea, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarInvestigacion_CrearLinea(id_crearlinea);
            }
        });

}

function EliminarInvestigacion_CrearLinea(idcrearlinea) {
    let urlEliminar = urlController + "Investigacion_CrearLinea/DeleteInvestigacion_CrearLinea?id_crearlinea=" + idcrearlinea;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableInvestigacion_CrearLinea();
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

function ValidatePostUpdateInvestigacion_CrearLinea(formF, botonClose) {
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
                AddUpdateInvestigacion_CrearLinea(botonClose);
                /*if (!isUpdateInvestigacion_CrearLinea) {                                       
                    ExisteInvestigacion_CrearLinea()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateInvestigacion_CrearLinea(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateInvestigacion_CrearLinea(botonClose);
                } */           
            }
        }
    }
}

function ExisteInvestigacion_CrearLinea() {    
    let lineaInvestigacion_CrearLinea = $("#txtLineaInvestigacion_CrearLinea").val();   
    let urlValidar = urlController + "Investigacion_CrearLinea/GetInvestigacion_CrearLineaNombre?cd_linea=" + lineaInvestigacion_CrearLinea;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "La Línea: " + lineaInvestigacion_CrearLinea + " ya está registrada.";
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

function AddUpdateInvestigacion_CrearLinea(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Investigacion_CrearLinea/UpdateInvestigacion_CrearLinea";

	objData.id_crearlinea = ($("#spanIdInvestigacion_CrearLinea")[0].innerText == '') ? undefined : $("#spanIdInvestigacion_CrearLinea")[0].innerText;
	objData.id_creargrupo = $("#cboGrupoInvestigacionCrearLinea").val();
	objData.linea = $("#txtLineaInvestigacion_CrearLinea").val();
	objData.campointeres = $("#txtCampoInvestigacion_CrearLinea").val();
	//objData.apellidos = $("#txtApellidoFuncionario").val();
	//objData.correo = $("#txtEmailFuncionario").val();

    if (objData.id_crearlinea == undefined) {
        urlUpdate = urlController + "Investigacion_CrearLinea/InsertInvestigacion_CrearLinea";        
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

            $('#cboGrupoInvestigacionCrearLinea').select2('destroy');
            
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTableInvestigacion_CrearLinea();
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

function CerrarModalUpdateInvestigacionCrearLinea() {
    if ($('#cboGrupoInvestigacionCrearLinea').data('select2')) {
        $('#cboGrupoInvestigacionCrearLinea').select2('destroy');        
      }   
    
}


