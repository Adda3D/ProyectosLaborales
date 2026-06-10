var DataTableDecVie_CicloFinancieroPostProgram = null;
var ObjModelDecVie_CicloFinancieroPostProgram = null;
var ObjModelDecVie_CicloFinancieroPostProgramBogota = null;
var ObjModelDecVie_CicloFinancieroPostProgramConvenios = null;
var ObjModelDecVie_CicloFinancieroPostProgramFacultad = null;
var ObjModelDecVie_CicloFinancieroPostProgramUAdministrativa = null;

$(document).ready(function () {    
    ObjModelDecVie_CicloFinancieroPostProgram = new DecVie_CicloFinancieroProgramasDisponibles();

    var spanElement = $("#spanIdDecvie_CicloFinancieroProgramaPostgrado")[0];
    if (spanElement) {
        console.log("El span existe:", spanElement);
    } else {
        console.error("El span #spanIdDecvie_CicloFinancieroProgramaPostgrado no existe");
    }

    InicializaDecVie_CicloFinancieroPostProgramform($("#spanIdDecvie_CicloFinanciero")[0].innerText, $("#spanIDSemestreDecvie_CicloFinanciero")[0].innerText,
                                                $("#spanNombreSemestreDecvie_CicloFinanciero")[0].innerText);

});

var nombreSemestreGlobal = '';  // Variable global


function LoadDataTableDecVie_CicloFinancieroPostProgram() {
    DataTableDecVie_CicloFinancieroPostProgram = $('#tblModalCicloFinancieroProgramas').DataTable({
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
            "url": urlController + "DecVie_CicloFinancieroPostProgram/GetDataTableDecVie_CicloFinancieroPostProgramByCiclo",
            "data": {
                "id_ciclofinanciero": function() { return $("#spanIdDecvie_CicloFinanciero")[0].innerText }
            }
        },      
        "columns": [                    
            { "data": "Objprogramapostgrado.tipoprograma", "orderable": false },
            { "data": "Objprogramapostgrado.observaciones", "orderable": false }, // Nueva columna: Código Programa
            { "data": "NombreProgramaPostgrado", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="CicloFinancieroProgramas_Bogota(' + row.id_postprogram + ',' + row.id_programapostgrado + ',' + row.id_ciclofinanciero + ')" data-bs-toggle="modal" data-bs-target="#ModalCicloFinancieroProgramas_Bogota"><img src="../images/iris/Editar.png">   Información </> </li>' +                            
                            // '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="CicloFinancieroProgramas_Convenio(' + row.id_postprogram + ',' + row.id_programapostgrado + ',' + row.id_ciclofinanciero + ')"data-bs-toggle="modal" data-bs-target="#ModalCicloFinancieroProgramas_Convenio"><img src="../images/iris/seguimiento.png">   Añadir Convenio </> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" data-bs-toggle="modal" data-bs-target="#ModalCicloFinancieroConvenios"><img src="../images/iris/seguimiento.png">   Añadir Convenio </li>'
+


                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="CicloFinancieroProgramas_Facultad(' + row.id_postprogram + ')"data-bs-toggle="modal" data-bs-target="#ModalCicloFinancieroProgramas_Facultad."><img src="../images/iris/minuta.png">   Secretaría Facultad</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="CicloFinancieroProgramas_UAdministrativa(' + row.id_postprogram + ')"data-bs-toggle="modal" data-bs-target="#ModalCicloFinancieroProgramas_UAdministrativa."><img src="../images/iris/modificar.png">   Unidad Administrativa</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarDecVie_CicloFinancieroPostProgram(' + row.id_postprogram + ');"><img src="../images/iris/Eliminar.png">   Eliminar Programa</> </li>' +
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


function RefreshDataTableDecVie_CicloFinancieroPostProgram() {
    DataTableDecVie_CicloFinancieroPostProgram.ajax.reload(null, false);
}

function VolverCiclosDesdeProgramas() {
    $("#dvDecvie_CicloFinancieroProgramas").addClass("ocultar");    
    $("#dvDecvie_CicloFinancieroTable").removeClass("ocultar");
    
}

function CerrarModalCicloFinancieroProgramas() {
    DestruirCamposSelect_Model(ObjModelDecVie_CicloFinancieroPostProgram);
}

function InicializaDecVie_CicloFinancieroPostProgramform(id_ciclofinanciero, id_semestre, NombreSemestreCiclofinanciero) {
    $("#txtSemestreCicloFinancieroProgramas").val(NombreSemestreCiclofinanciero);
    
    if (DataTableDecVie_CicloFinancieroPostProgram != null) {
        DataTableDecVie_CicloFinancieroPostProgram.destroy();
    }

    LoadDataTableDecVie_CicloFinancieroPostProgram(); 

    $("#dvDecvie_CicloFinancieroTable").addClass("ocultar");    
    $("#dvDecvie_CicloFinancieroProgramas").removeClass("ocultar");

    nombreSemestreGlobal = NombreSemestreCiclofinanciero;
}

// function CrearCicloFinancieroProgramas() {
//     console.log($("#spanIdDecvie_CicloFinanciero"));
//     CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgram)
//         .then(htmlcreado => {
//             NewData_ToModel(ObjModelDecVie_CicloFinancieroPostProgram)
            
//             .then(datospreparados => {
//                 if (datospreparados) { 
//                     console.log($("#spanIdDecvie_CicloFinanciero"));

//                     $("#txtid_postprogram_DecVie_CicloFinancieroPostProgram").val('');
//                     $("#txtid_ciclofinanciero_DecVie_CicloFinancieroPostProgram").val($("#spanIdDecvie_CicloFinanciero")[0].innerText);

//                     FinalizeLoader();
    
//                 }
//             })
//             .catch (err => {
//                 FinalizeLoader();
//                 ShowModalDialog(err, false, 'error', '', 0);
//             })      
//         })
//         .catch (err => {
//             FinalizeLoader();
//             ShowModalDialog(err, false, 'error', '', 0);
//         })      

//         $('#ModalLabelCicloFinancieroProgramas').text('Añadir Programa para semestre ' + NombreSemestreCiclofinanciero);
// }

function CrearCicloFinancieroProgramas() {
    console.log($("#spanIdDecvie_CicloFinanciero"));
    CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgram)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_CicloFinancieroPostProgram)
            .then(datospreparados => {
                if (datospreparados) { 
                    console.log($("#spanIdDecvie_CicloFinanciero"));

                    $("#txtid_postprogram_DecVie_CicloFinancieroPostProgram").val('');
                    $("#txtid_ciclofinanciero_DecVie_CicloFinancieroPostProgram").val($("#spanIdDecvie_CicloFinanciero")[0].innerText);

                    FinalizeLoader();
                }
            })
            .catch (err => {
                FinalizeLoader();
                ShowModalDialog(err, false, 'error', '', 0);
            })      
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        });

    // Usar la variable global
    $('#ModalLabelCicloFinancieroProgramas').text('Añadir Programa para semestre ' + nombreSemestreGlobal);
}



function ValidatePostUpdateCicloFinancieroProgramasForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CicloFinancieroPostProgram)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        //ShowModalDialog('Datos del Eje Estratégico Guardados', false, 'success', '', 0);  
        RefreshDataTableDecVie_CicloFinancieroPostProgram();
        CerrarModalCicloFinancieroProgramas();     
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })
  
}


function ValidarEliminarDecVie_CicloFinancieroPostProgram(id_postprogram) {
    ShowDialogConfirmacion('','Seguro de eliminar el Programa del Ciclo Financiero?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_CicloFinancieroPostProgram(id_postprogram);
            }
        });
}

function EliminarDecVie_CicloFinancieroPostProgram(id_postprogram) {
    let urlEliminar = urlController + "DecVie_CicloFinancieroPostProgram/DeleteDecVie_CicloFinancieroPostProgram?id_postprogram=" + id_postprogram;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_CicloFinancieroPostProgram();
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

//#region SEDE BOGOTA
// function CicloFinancieroProgramas_Bogota(id_postprogram) {
//     if (ObjModelDecVie_CicloFinancieroPostProgramBogota == null) {
//         ObjModelDecVie_CicloFinancieroPostProgramBogota = new DecVie_CicloFinancieroPostProgramBogota();
//     }
        
//     ObjModelDecVie_CicloFinancieroPostProgramBogota.FormEdicion = 'formCicloFinancieroProgramas_BogotaDetalle';

//     CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgramBogota)
//       .then(htmlcreado => {
//           $('#txtid_postprogram_DecVie_CicloFinancieroPostProgramBogota').val(id_postprogram);
                    
//           LoadData_ToModel(ObjModelDecVie_CicloFinancieroPostProgramBogota, id_postprogram)
//           .then(datoscargados => {
//               if (datoscargados) { 
//                   FinalizeLoader();
//               }
//           })    
//           .catch (err => {
//               FinalizeLoader();
//               ShowModalDialog(err, false, 'error', '', 0);
//           })      
//       })
//       .catch (err => {
//           FinalizeLoader();
//           ShowModalDialog(err, false, 'error', '', 0);
//       })  
// }

// function CicloFinancieroProgramas_Bogota(id_postprogram, id_programapostgrado) {
//     if (ObjModelDecVie_CicloFinancieroPostProgramBogota == null) {
//         ObjModelDecVie_CicloFinancieroPostProgramBogota = new DecVie_CicloFinancieroPostProgramBogota();
//     }

//     ObjModelDecVie_CicloFinancieroPostProgramBogota.FormEdicion = 'formCicloFinancieroProgramas_BogotaDetalle';

//     CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgramBogota)
//       .then(htmlcreado => {
//           $('#txtid_postprogram_DecVie_CicloFinancieroPostProgramBogota').val(id_postprogram);
                    
//           LoadData_ToModel(ObjModelDecVie_CicloFinancieroPostProgramBogota, id_postprogram)
//           .then(datoscargados => {
//               if (datoscargados) { 
//                   FinalizeLoader();
//               }
//           })    
//           .catch (err => {
//               FinalizeLoader();
//               ShowModalDialog(err, false, 'error', '', 0);
//           })      
//       })
//       .catch (err => {
//           FinalizeLoader();
//           ShowModalDialog(err, false, 'error', '', 0);
//       })  

//     // Llamada AJAX para obtener los detalles del programa Postgrado
//     $.ajax({
//         "url": urlController + "Decvie_CicloFinancieroProgramaPostgrado/GetDecvie_CicloFinancieroProgramaPostgradoDetails",
//         "data": {
//             "id_programapostgrado": id_programapostgrado
//         },
//         "method": "GET",
//         "success": function (response) {
//             // Verificar la respuesta completa del servidor
//             console.log("Respuesta completa del servidor:", response);

//             // Verificar que el campo Data existe
//             var data = response.Data;

//             if (!data) {
//                 console.error("El campo Data no se encontró en la respuesta.");
//                 return;
//             }

//             // Verificamos que el campo nmprogramapostgrado exista en Data
//             if (data.hasOwnProperty('nmprogramapostgrado')) {
//                 console.log("Nombre del programa:", data.nmprogramapostgrado);
//             } else {
//                 console.error("No se encontró el campo nmprogramapostgrado en la respuesta.");
//                 return; // Salimos si no está disponible
//             }

//             // Obtenemos el nombre del programa y el código
//             var nombrePrograma = data.nmprogramapostgrado;
//             var codigoPrograma = data.observaciones || 'Sin código';  // En caso de que 'observaciones' esté vacío

//             // Verificar si el nombre del programa está disponible
//             if (!nombrePrograma) {
//                 console.error("El nombre del programa no se encontró.");
//                 return; // Salimos de la función si no se encuentra el nombre del programa
//             }

//             // Actualizamos el título del modal con el nombre del programa
//             $('#ModalLabelCicloFinancieroProgramas_Bogota').text('Datos del programa: ' + nombrePrograma + ' (' + codigoPrograma + ')');

//             // Ahora realizamos la segunda llamada AJAX para obtener los detalles del Ciclo Financiero
//             $.ajax({
//                 "url": urlController + "DecVie_CicloFinancieroPostProgram/GetDecVie_CicloFinancieroPostProgramDetails",
//                 "data": {
//                     "id_postprogram": id_postprogram
//                 },
//                 "method": "GET",
//                 "success": function (data) {
//                     // Aquí cargamos los detalles del Ciclo Financiero en el formulario del modal
//                     $('#txtid_postprogram_DecVie_CicloFinancieroPostProgramBogota').val(data.id_postprogram);
//                     $('#txtNombrePrograma').val(nombrePrograma); // Cargamos el nombre del programa
//                     $('#txtCodigoPrograma').val(codigoPrograma); // Cargamos el código del programa

//                     // Cargar otros campos adicionales según lo que necesites...
//                 },
//                 "error": function (err) {
//                     console.error('Error al obtener los detalles del Ciclo Financiero:', err);
//                 }
//             });
//         },

         
//         "error": function (err) {
//             console.error('Error al obtener los detalles del programa postgrado:', err);
//         }
//     });

//     // Mostramos el modal
//     $('#ModalCicloFinancieroProgramas_Bogota').modal('show');
// }


function CicloFinancieroProgramas_Bogota(id_postprogram, id_programapostgrado) {
    // Inicializamos el modelo si no existe
    if (ObjModelDecVie_CicloFinancieroPostProgramBogota == null) {
        ObjModelDecVie_CicloFinancieroPostProgramBogota = new DecVie_CicloFinancieroPostProgramBogota();
    }
    // Establecemos el formulario de edición
    ObjModelDecVie_CicloFinancieroPostProgramBogota.FormEdicion = 'formCicloFinancieroProgramas_BogotaDetalle';
    // Generamos el HTML basado en el modelo
    CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgramBogota)
      .then(htmlcreado => {
          // Establecemos el valor de id_postprogram en el formulario
          $('#txtid_postprogram_DecVie_CicloFinancieroPostProgramBogota').val(id_postprogram);
          // Cargamos los datos al modelo basándonos en el id_postprogram
          LoadData_ToModel(ObjModelDecVie_CicloFinancieroPostProgramBogota, id_postprogram)
          .then(datoscargados => {
              if (datoscargados) { 
                  FinalizeLoader(); // Si los datos se cargaron correctamente
              }
          })    
          .catch (err => {
              FinalizeLoader();
              ShowModalDialog(err, false, 'error', '', 0); // Mostramos un error si ocurre algo
          });
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0); // Mostramos un error si ocurre algo al generar el HTML
      });

    // Llamamos a la función para obtener y actualizar los detalles del programa postgrado
    ObtenerDetallesProgramaPostgrado(id_programapostgrado);

    // Mostramos el modal
    $('#ModalCicloFinancieroProgramas_Bogota').modal('show');
}



function ObtenerDetallesProgramaPostgrado(id_programapostgrado) {
    $.ajax({
        url: urlController + "Decvie_CicloFinancieroProgramaPostgrado/GetDecvie_CicloFinancieroProgramaPostgradoDetails",
        data: {
            id_programapostgrado: id_programapostgrado
        },
        method: "GET",
        success: function(response) {
            var data = response.Data;

            if (!data) {
                console.error("No se encontraron datos del programa postgrado.");
                return;
            }

            var nombrePrograma = data.nmprogramapostgrado;
            var codigoPrograma = data.observaciones || 'Sin código'; // Si observaciones está vacío

            // Verificar que el nombre del programa sea válido
            if (!nombrePrograma) {
                console.error("No se encontró el nombre del programa.");
                return;
            }

            // Actualizamos el título del modal con el nombre del programa y el código
            $('#ModalLabelCicloFinancieroProgramas_Bogota').text('Datos del programa: ' + nombrePrograma + ' (' + codigoPrograma + ')');
        },
        error: function(err) {
            console.error("Error al obtener los detalles del programa postgrado:", err);
        }
    });
}


function ValidatePostUpdateCicloFinancieroProgramas_BogotaForm(formF, botonCerrar) {
    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CicloFinancieroPostProgramBogota)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos Programa Guardados', false, 'success', '', 0);  
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click(); // Cerramos el modal
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    });
}



function ValidatePostUpdateCicloFinancieroProgramas_BogotaForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CicloFinancieroPostProgramBogota)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos Programa Guardados', false, 'success', '', 0);  
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}



//#endregion

//#region Programas Convenios
function CicloFinancieroProgramas_Convenio(id_postprogram) {
    if (ObjModelDecVie_CicloFinancieroPostProgramConvenios == null) {
        ObjModelDecVie_CicloFinancieroPostProgramConvenios = new DecVie_CicloFinancieroPostProgramConvenios();
    }
        
    ObjModelDecVie_CicloFinancieroPostProgramConvenios.FormEdicion = 'formCicloFinancieroProgramas_ConvenioDetalle';

    CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgramConvenios)
      .then(htmlcreado => {
          $('#txtid_postprogram_DecVie_CicloFinancieroPostProgramConvenios').val(id_postprogram);
              
          LoadData_ToModel(ObjModelDecVie_CicloFinancieroPostProgramConvenios, id_postprogram)
          .then(datoscargados => {
              if (datoscargados) { 
                  FinalizeLoader();
              }
          })    
          .catch (err => {
              FinalizeLoader();
              ShowModalDialog(err, false, 'error', '', 0);
          })      
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
      })  
}

function ValidatePostUpdateCicloFinancieroProgramas_ConvenioForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CicloFinancieroPostProgramConvenios)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos Convenios Guardados', false, 'success', '', 0);  
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

//#endregion

//#region Facultad
function CicloFinancieroProgramas_Facultad(id_postprogram) {
    if (ObjModelDecVie_CicloFinancieroPostProgramFacultad == null) {
        ObjModelDecVie_CicloFinancieroPostProgramFacultad = new DecVie_CicloFinancieroPostProgramFacultad();
    }
        
    ObjModelDecVie_CicloFinancieroPostProgramFacultad.FormEdicion = 'formCicloFinancieroProgramas_FacultadDetalle';

    CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgramFacultad)
      .then(htmlcreado => {
          $('#txtid_postprogram_DecVie_CicloFinancieroPostProgramFacultad').val(id_postprogram);
              
          LoadData_ToModel(ObjModelDecVie_CicloFinancieroPostProgramFacultad, id_postprogram)
          .then(datoscargados => {
              if (datoscargados) { 
                  FinalizeLoader();
              }
          })    
          .catch (err => {
              FinalizeLoader();
              ShowModalDialog(err, false, 'error', '', 0);
          })      
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
      })  
}

function ValidatePostUpdateCicloFinancieroProgramas_FacultadForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CicloFinancieroPostProgramFacultad)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos Facultad Guardados', false, 'success', '', 0);  
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

//#endregion

//#region Unidad Administrativa
function CicloFinancieroProgramas_UAdministrativa(id_postprogram) {
    if (ObjModelDecVie_CicloFinancieroPostProgramUAdministrativa == null) {
        ObjModelDecVie_CicloFinancieroPostProgramUAdministrativa = new DecVie_CicloFinancieroPostProgramUAdministrativa();
    }
        
    ObjModelDecVie_CicloFinancieroPostProgramUAdministrativa.FormEdicion = 'formCicloFinancieroProgramas_UAdministrativaDetalle';

    CreateHTMLFromModel(ObjModelDecVie_CicloFinancieroPostProgramUAdministrativa)
      .then(htmlcreado => {
          $('#txtid_postprogram_DecVie_CicloFinancieroPostProgramUAdministrativa').val(id_postprogram);
              
          LoadData_ToModel(ObjModelDecVie_CicloFinancieroPostProgramUAdministrativa, id_postprogram)
          .then(datoscargados => {
              if (datoscargados) { 
                  FinalizeLoader();
              }
          })    
          .catch (err => {
              FinalizeLoader();
              ShowModalDialog(err, false, 'error', '', 0);
          })      
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
      })  
}

function ValidatePostUpdateCicloFinancieroProgramas_UAdministrativaForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CicloFinancieroPostProgramUAdministrativa)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos Unidad Administrativa Guardados', false, 'success', '', 0);  
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

//#endregion