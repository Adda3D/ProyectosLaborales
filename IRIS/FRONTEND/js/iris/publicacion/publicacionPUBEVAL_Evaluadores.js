var DataTablePublicacionEvaluadores = null;

$(document).ready(function () {    
    InicializaPublicacionEvaluadoresform();

});


function InicializaPublicacionEvaluadoresform() {    
    
    if (DataTablePublicacionEvaluadores != null) {
        DataTablePublicacionEvaluadores.destroy();
    }

    LoadDataTablePublicacionEvaluadores(); 

}

function LoadDataTablePublicacionEvaluadores() {
    DataTablePublicacionEvaluadores = $('#tblPUBEVAL_Evaluadores').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        searching: false,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_Evaluadores/GetDataTablePublicaciones_EvaluadoresByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }                        
        },      
        "columns": [                                
            { "data": "NombreEvaluador", "orderable": false },            
            { "data": "Estado", "orderable": false },
            { "data": "actadesigcomite", "orderable": false },
            /*
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicacionEvaluador(' + row.id_evaluadores + ',' + row.id_persona + ')" /> ' + 
                           '<img src="../images/iris/evaluacion.png" class="cambiarMouse" title="Realizar Concepto" onclick="PublicacionEvaluacionRealizarConcepto(' + row.id_evaluadores + ',' + row.id_persona + ')" /> ' + 
                           '<img src="../images/iris/money.png" class="cambiarMouse" title="Información Pago" onclick="PublicacionEvaluacionRealizarPago(' + row.id_evaluadores + ',' + row.id_persona + ')" /> ' + 
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Evaluador" onclick="ValidarEliminarPublicacionEaluador(' + row.id_evaluadores + ',1)" /> ';
                },
                "className": "text-center", "orderable": false
            }
            */
            {
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="EditarPublicacionEvaluador(' + row.id_evaluadores + ',' + row.id_persona + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionEvaluacionRealizarConcepto(' + row.id_evaluadores + ',' + row.id_persona + ')"><img src="../images/iris/evaluacion.png">   Realizar Concepto</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="PublicacionEvaluacionRealizarPago(' + row.id_evaluadores + ',' + row.id_persona + ')"><img src="../images/iris/money.png">   Información Pago</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarPublicacionEaluador(' + row.id_evaluadores + ')"><img src="../images/iris/Eliminar.png">   Eliminar Evaluador</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicacionEvaluadores() {
    DataTablePublicacionEvaluadores.ajax.reload(null, false);
}

function VolverTablaPublicacionEvaluadoresDesdeCrearEvaluador() {
    DestruyeSelectPublicacionEvaluadorForm();

    $("#dvCrearPUBEVAL_Evaluadores").addClass("ocultar");    
    $("#tablePublicacionEvaluadores").removeClass("ocultar");    
    
}

function DestruyeSelectPublicacionEvaluadorForm() {
    if ($('#cboPublicacionIdEvaluador').data('select2')) {
        $('#cboPublicacionIdEstadoEvaluador').select2('destroy');        
      }    
}

function CrearPublicacionEvaluador() {
    $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText = $("#spanIdPublicacion")[0].innerText;;
    $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText = '';
    $("#spanPUBEVAL_EvaluadoresIdPersona")[0].innerText = '';
    
    $( "#cboPublicacionIdEvaluador" ).prop( "disabled", false );
    
    LoadPersonaEvaluador('cboPublicacionIdEvaluador', true);
    LoadEstadoEvaluador('cboPublicacionIdEstadoEvaluador', true);   
    
    $('cboPublicacionIdEvaluador').select2().val('').trigger("change");
    $('cboPublicacionIdEstadoEvaluador').select2().val('').trigger("change");
    $('#dtPublicacionEvaluadorfecdesigcomite').val('');
    $('#txtPublicacionEvaluadoractadesigcomite').val('');

    $('#cboPublicacionIdEvaluador').select2();
    $('#cboPublicacionIdEstadoEvaluador').select2();

    removeValidationFormByForm('formPUBEVAL_Evaluadores');   
         
    $("#tablePublicacionEvaluadores").addClass("ocultar");    
    $("#dvCrearPUBEVAL_Evaluadores").removeClass("ocultar");    
}

function EditarPublicacionEvaluador(idevaluador) {
    $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText = $("#spanIdPublicacion")[0].innerText;;
    $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText = idevaluador;
    $("#spanPUBEVAL_EvaluadoresIdPersona")[0].innerText = '';

    $( "#cboPublicacionIdEvaluador" ).prop( "disabled", true );

    LoadPersonaEvaluador('cboPublicacionIdEvaluador', true)
    .then(personaCargada=>{
        LoadEstadoEvaluador('cboPublicacionIdEstadoEvaluador', true)
        .then(EstadoCargado=>{
            let urlEditar = urlController + "Publicaciones_Evaluadores/GetPublicaciones_EvaluadoresDetails?id_evaluadores=" + idevaluador;  
    
            removeValidationFormByForm('formPUBEVAL_Evaluadores');   
            return new Promise( (resolve, reject) => {
        
            fetch(urlEditar, {
                method: 'GET',
                headers: { 'Authorization': 'Bearer ' + TokenIRIS }
            })
            .then(response => response.json())
              .then(data => {
                if (data.Ok) {                
                    let datos = data.Data;
                    debugger
                    $('#cboPublicacionIdEvaluador').select2().val(datos.id_persona).trigger("change");
                    $('#cboPublicacionIdEstadoEvaluador').select2().val(datos.id_estadoevaluador).trigger("change");
        
                    if (datos.fecdesigcomite != null) {
                        $('#dtPublicacionEvaluadorfecdesigcomite').val(datos.fecdesigcomite.slice(0,10));
                    }
                    
                    $('#txtPublicacionEvaluadoractadesigcomite').val(datos.actadesigcomite);
        
                    $('#cboPublicacionIdEvaluador').select2();
                    $('#cboPublicacionIdEstadoEvaluador').select2();
                
                    $("#tablePublicacionEvaluadores").addClass("ocultar");    
                    $("#dvCrearPUBEVAL_Evaluadores").removeClass("ocultar");    
                                    
                    FinalizeLoader();
                    return resolve(true);
                }
                else {
                    ShowModalDialog(data.Message, false, 'warning', '', 0);
                    FinalizeLoader();
                    return resolve(false);
                }            
              })
              .catch (err => {
                FinalizeLoader();
                ShowModalDialog(err, false, 'error', '', 0);
                reject(err);
                
              } );          
        })
        })   
    
       
    })
  
}


// function ValidatePostUpdatePublicacionEvaluadoresCrearEvaluador(formF) {
//     validateTextXSSLastButtonByForm(formF);

//     var formV = $("#" + formF);
//     if (formV[0].checkValidity() == false) {
//         $(formV).addClass('was-validated');
//     } else {
//         if (checkValidityXSS == false) {
//             $(formV).addClass('was-validated');
//         } else {
//             if (checkValiditySelect == false) {
//                 $(formV).addClass('was-validated');
//             } else {
//                 ExisteEvaluadorEnPublicacion()
//                     .then(existe => {
//                         if (!existe) {                                    
//                             AddUpdatePublicacionEvaluadoresCrearEvaluador();
//                         }
//                     })                                 
//             }
//         }
//     }    
// }

//Modificado ADDA VARGAS 08/06/2024
function ValidatePostUpdatePublicacionEvaluadoresCrearEvaluador(formF) {
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
                ExisteEvaluadorEnPublicacion()
                    .then(existe => {
                        if (existe) {
                            // Mostrar mensaje si ya existe, pero aún así proceder a actualizar
                            let message = "El evaluador ya está registrado para la publicación. Se actualizará la información.";
                            ShowModalDialog(message, false, 'info', '', 0);
                        }
                        // Llamar a la función para agregar o actualizar el evaluador
                        AddUpdatePublicacionEvaluadoresCrearEvaluador();
                    })                                 
            }
        }
    }    
}

function ExisteEvaluadorEnPublicacion() {
    let idpublicacion = $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText;
    let idpersona = $('#cboPublicacionIdEvaluador').val();
    
    let urlValidar = urlController + "Publicaciones_Evaluadores/GetPublicaciones_EvaluadoresExisteEvaluador?id_crearpublicacion=" + idpublicacion + "&id_persona=" + idpersona;

    return new Promise((resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
        .then(data => {
            if (data.Ok) {
                return resolve(true); // Devuelve true si el evaluador ya existe
            } else {
                return resolve(false); // Devuelve false si el evaluador no existe
            }            
        })
        .catch(err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
        });
    }); 
}



// function ExisteEvaluadorEnPublicacion() {
//     let idpublicacion = $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText;
//     let idpersona = $('#cboPublicacionIdEvaluador').val();
    
//     let urlValidar = urlController + "Publicaciones_Evaluadores/GetPublicaciones_EvaluadoresExisteEvaluador?id_crearpublicacion=" + idpublicacion + "&id_persona=" + idpersona;

//     return new Promise( (resolve, reject) => {
//         fetch(urlValidar, {
//             method: 'GET',
//             headers: { 'Authorization': 'Bearer ' + TokenIRIS }
//         })
//         .then(response => response.json())
//           .then(data => {
//             if (data.Ok) {
//                 let message = "El evaluador ya está registrado para la publicación.";
//                 ShowModalDialog(message, false, 'warning', '', 0);
//                 return true;
//             }
//             else {
//                 return false;
//             }            
//           })
//           .then( resultado => {
//             return resolve(resultado);
//           }) 
//           .catch (err => {
//             ShowModalDialog(err, false, 'error', '', 0);
//             reject(err);
//           } );
//       }); 
// }

function AddUpdatePublicacionEvaluadoresCrearEvaluador() {
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_Evaluadores/UpdatePublicaciones_Evaluadores";
        
    objData.id_evaluadores = ($("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText == '') ? undefined : $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText;
    objData.id_crearpublicacion = $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText;
    objData.id_persona = $('#cboPublicacionIdEvaluador').val();
    objData.id_estadoevaluador = $('#cboPublicacionIdEstadoEvaluador').val();        
    objData.fecdesigcomite = $('#dtPublicacionEvaluadorfecdesigcomite').val();    
    objData.actadesigcomite = $('#txtPublicacionEvaluadoractadesigcomite').val();
        
    if (objData.id_evaluadores == undefined) {
        urlUpdate = urlController + "Publicaciones_Evaluadores/InsertPublicaciones_Evaluadores";
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
            
            DestruyeSelectPublicacionEvaluadorForm();

            $("#dvCrearPUBEVAL_Evaluadores").addClass("ocultar");    
            $("#tablePublicacionEvaluadores").removeClass("ocultar");    

            RefreshDataTablePublicacionEvaluadores();
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

function ValidarEliminarPublicacionEaluador(idevaluador) {
    ShowDialogConfirmacion('','Seguro de eliminar evaluador ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicacionEvaluador(idevaluador);
            }
        });

}

function EliminarPublicacionEvaluador(idevaluador) {
    let urlEliminar = urlController + "Publicaciones_Evaluadores/DeletePublicaciones_Evaluadores?id_evaluadores=" + idevaluador;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicacionEvaluadores();
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

function PublicacionEvaluacionRealizarConcepto(idevaluador, idpersona) {
    $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText = $("#spanIdPublicacion")[0].innerText;
    $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText = idevaluador;
    $("#spanPUBEVAL_EvaluadoresIdPersona")[0].innerText = idpersona;

    if (!ExisteDivGestionarPublicacion('dvPUBEVAL_EvaluadoresRealizacionConcepto')) {
        CrearDivGestionarPublicacion('/Pages/publicacion/publicacionPUBEVAL_Conceptos.html', 'dvPUBEVAL_EvaluadoresRealizacionConcepto');
    }
    else {
        EditarPublicacionRealizacionConceptoform();
    }

}

function PublicacionEvaluacionRealizarPago(idevaluador, idpersona) {
    $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText = $("#spanIdPublicacion")[0].innerText;
    $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText = idevaluador;
    $("#spanPUBEVAL_EvaluadoresIdPersona")[0].innerText = idpersona;

    if (!ExisteDivGestionarPublicacion('dvPUBEVAL_EvaluadoresInformacionPago')) {
        CrearDivGestionarPublicacion('/Pages/publicacion/publicacionPUBEVAL_InformacionPago.html', 'dvPUBEVAL_EvaluadoresInformacionPago');
    }
    else {
        EditarPublicacionEvalInformacionPagoForm();
    }

}
