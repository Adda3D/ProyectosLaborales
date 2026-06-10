function DuplicarSelect(selectorigen, selectdestino) {  
  $('#' + selectdestino).empty();
  let options = document.getElementById(selectorigen).innerHTML;

  options = document.getElementById(selectdestino).innerHTML + options;

  document.getElementById(selectdestino).innerHTML = options;
}


function LoadTipoDocumentoSelect(select) {
    $('#' + select).empty();
    let urlTipoDocumento = urlController + "Tipo_Documento/GetAllTipo_Documento";    

    return new Promise( (resolve, reject) => {
      fetch(urlTipoDocumento, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
        .then(data => {
          if (data.Ok) {
            let tipos = data.Data;

            for (var i = 0; i < tipos.length; i++) {
                $('#' + select).append('<option value="' + tipos[i].id_tipodocumento + '">' + tipos[i].nmtipodoc + '</option>');
            }
  
            return resolve(true);
          }
          else {
            return resolve(false);
          }            
        })
        .catch (err => {
          ShowModalDialog(err, false, 'error', '', 0);
          reject(err);
        } );
    });
}

function LoadTipoEntidadSelect(select) {
    $('#' + select).empty();
    let urlTipoEntidad = urlController + "Persona_TipoEntidad/GetAllPersona_TipoEntidad";   
    
    return new Promise( (resolve, reject) => {
      fetch(urlTipoEntidad, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
        .then(data => {
          if (data.Ok) {
            let tipos = data.Data;

            for (var i = 0; i < tipos.length; i++) {
                $('#' + select).append('<option value="' + tipos[i].id_tipoentidad + '">' + tipos[i].nmtipoent + '</option>');
            }
  
            return resolve(true);
          }
          else {
            return resolve(false);
          }            
        })
        .catch (err => {
          ShowModalDialog(err, false, 'error', '', 0);
          reject(err);
        } );
    });
        
}

//ES TIPOPERSONA O NATURALEZA
function LoadTipoPersonaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlTipoEntidad = urlController + "Tipo_Persona/GetAllTipo_Persona";    

  return new Promise( (resolve, reject) => {
    fetch(urlTipoEntidad, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
          let tipos = data.Data;

          if (tienenulo) {
            $('#' + select).append('<option value="">Seleccione</option>');
          }

          for (var i = 0; i < tipos.length; i++) {
              $('#' + select).append('<option value="' + tipos[i].id_tipopersona + '">' + tipos[i].nmtipoper + '</option>');
          }

          return resolve(true);
        }
        else {
          return resolve(false);
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaContratante(select, tienenulo) {
  $('#' + select).empty();
  let urlPropuestaContratante = urlController + "propuesta_entidad/GetAllPropuestaEntidad";    

  return new Promise( (resolve, reject) => {
    fetch(urlPropuestaContratante, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let contratantes = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < contratantes.length; i++) {
              $('#' + select).append('<option value="' + contratantes[i].idpropuesta_entidad + '">' + contratantes[i].razonsocial + '</option>');
            }            
            return resolve(true);
        }
        else {
          return resolve(false);
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaModalidad(select) {
  $('#' + select).empty();
  let urlPropuestaContratante = urlController + "Propuesta_Modalidad/GetAllPropuesta_Modalidad";    

  return new Promise( (resolve, reject) => {
    fetch(urlPropuestaContratante, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let modalidades = data.Data;

            for (var i = 0; i < modalidades.length; i++) {
              $('#' + select).append('<option value="' + modalidades[i].id_modalidad + '">' + modalidades[i].nmmodalidad + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaOrigen(select) {
  $('#' + select).empty();
  let urlPropuestaContratante = urlController + "Propuesta_OrigenPropuesta/GetAllPropuesta_OrigenPropuesta";    

  return new Promise( (resolve, reject) => {
    fetch(urlPropuestaContratante, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let origenpropuesta = data.Data;

            for (var i = 0; i < origenpropuesta.length; i++) {
              $('#' + select).append('<option value="' + origenpropuesta[i].id_origenpropuesta + '">' + origenpropuesta[i].nmorigenpropuesta + '</option>');
            }            
            return resolve(true);
        }
        else {
          return resolve(false);
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaTipoPropuesta(select, tienenulo) {
  $('#' + select).empty();
  let urlPropuestaContratante = urlController + "Propuesta_TipoPropuesta/GetAllPropuesta_TipoPropuesta";    

  return new Promise( (resolve, reject) => {
    fetch(urlPropuestaContratante, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tipopropuesta = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < tipopropuesta.length; i++) {
              $('#' + select).append('<option value="' + tipopropuesta[i].id_tipopropuesta + '">' + tipopropuesta[i].nmtipopropuesta + '</option>');
            }            
            return resolve(true);
        }
        else {
          return resolve(false);
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaTipoUsuario(select) {
  $('#' + select).empty();
  let urlPropuestaTipoUsuario = urlController + "Propuesta_TipoUsuario/GetAllPropuesta_TipoUsuario";    

  return new Promise( (resolve, reject) => {
    fetch(urlPropuestaTipoUsuario, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let propuestatipousuario = data.Data;

            for (var i = 0; i < propuestatipousuario.length; i++) {
              $('#' + select).append('<option value="' + propuestatipousuario[i].id_propuestatipousuario + '">' + propuestatipousuario[i].nmpropuestatipousuario + '</option>');
            }            
            return resolve(true);
        }
        else {
          return resolve(false);
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaEstado(select) {
  $('#' + select).empty();
  let urlPropuestaEstado = urlController + "Propuesta_EstadoPropuesta/GetAllPropuesta_EstadoPropuesta";    

  return new Promise( (resolve, reject) => {
    fetch(urlPropuestaEstado, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let propuestaestado = data.Data;

            for (var i = 0; i < propuestaestado.length; i++) {
              $('#' + select).append('<option value="' + propuestaestado[i].id_estadopropuesta + '">' + propuestaestado[i].nmestadopropuesta + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadFuncionarioSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlfuncionario = urlController + "Funcionario/GetAllFuncionario";    

  return new Promise( (resolve, reject) => {
    fetch(urlfuncionario, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let funcionariolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < funcionariolst.length; i++) {
              $('#' + select).append('<option value="' + funcionariolst[i].idfuncionario + '">' + funcionariolst[i].nombrecompleto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaTipoAprobacionSelect(select) {
  $('#' + select).empty();
  let urltipoaprobacion = urlController + "Propuesta_AprobacionConsejoFacultad/GetAllPropuesta_AprobacionConsejoFacultad";    

  return new Promise( (resolve, reject) => {
    fetch(urltipoaprobacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tipoaprobacionlst = data.Data;

            $('#' + select).append('<option value="">Seleccione</option>');

            for (var i = 0; i < tipoaprobacionlst.length; i++) {
              $('#' + select).append('<option value="' + tipoaprobacionlst[i].id_aprobacionconsejofacultad + '">' + tipoaprobacionlst[i].nmaprconfac + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });  
}

function LoadDependenciaSelect(select) {
  $('#' + select).empty();
  let urlDependencia = urlController + "Dependencia/GetAllDependencia";    

  return new Promise( (resolve, reject) => {
    fetch(urlDependencia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let dependencias = data.Data;

            for (var i = 0; i < dependencias.length; i++) {
              $('#' + select).append('<option value="' + dependencias[i].id_depend + '">' + dependencias[i].nmdepend + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDependenciaSelectNulo(select, tienenulo) {
  $('#' + select).empty();
  let urlDependencia = urlController + "Dependencia/GetAllDependencia";    

  return new Promise( (resolve, reject) => {
    fetch(urlDependencia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let dependencias = data.Data;            

            if (tienenulo) {
              $('#' + select).append('<option value="null">Seleccione</option>');
            }

            for (var i = 0; i < dependencias.length; i++) {
              $('#' + select).append('<option value="' + dependencias[i].id_depend + '">' + dependencias[i].nmdepend + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadAreaAcademicaSelect(select) {
  $('#' + select).empty();
  let urlAreaAcademica = urlController + "Area_Academica/GetAllArea_Academica";    

  return new Promise( (resolve, reject) => {
    fetch(urlAreaAcademica, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstarea = data.Data;

            for (var i = 0; i < lstarea.length; i++) {
              $('#' + select).append('<option value="' + lstarea[i].id_areaacad + '">' + lstarea[i].nmaacad + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}


function LoadAvalConsejoSelect(select) {
  $('#' + select).empty();
  let urlAreaAcademica = urlController + "Propuesta_AvalConsejoFacultad/GetAllPropuesta_AvalConsejoFacultad";    
  StartLoader();

  return new Promise( (resolve, reject) => {
    fetch(urlAreaAcademica, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        FinalizeLoader();
        if (data.Ok) {
            let lstavales = data.Data;

            for (var i = 0; i < lstavales.length; i++) {
              $('#' + select).append('<option value="' + lstavales[i].id_avalconfac + '">' + lstavales[i].numeroaval + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadTipoModificacionMinutaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urltipomodificacion = urlController + "Propuesta_TipoModificacion/GetAllPropuesta_TipoModificacion";    

  return new Promise( (resolve, reject) => {
    fetch(urltipomodificacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tipomodificacionlst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < tipomodificacionlst.length; i++) {
              $('#' + select).append('<option value="' + tipomodificacionlst[i].id_tipomodificacion + '">' + tipomodificacionlst[i].nmtipomodificacion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPropuestaCoberturaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urltipocobertura = urlController + "Propuesta_Cobertura/GetAllPropuesta_Cobertura";    

  return new Promise( (resolve, reject) => {
    fetch(urltipocobertura, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tipocoberturalst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < tipocoberturalst.length; i++) {
              $('#' + select).append('<option value="' + tipocoberturalst[i].id_cobertura + '">' + tipocoberturalst[i].nmcobertura + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPersonaGeneroSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlgenero = urlController + "Persona_Genero/GetAllPersona_Genero";    

  return new Promise( (resolve, reject) => {
    fetch(urlgenero, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let generolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < generolst.length; i++) {
              $('#' + select).append('<option value="' + generolst[i].id_genero + '">' + generolst[i].nmgenero + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPersonaTipoServicioSelect(select, tienenulo) {
  $('#' + select).empty();
  let urltiposervicio = urlController + "Persona_TipoServicio/GetAllPersona_TipoServicio";    

  return new Promise( (resolve, reject) => {
    fetch(urltiposervicio, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tiposerviciolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < tiposerviciolst.length; i++) {
              $('#' + select).append('<option value="' + tiposerviciolst[i].id_tiposervicio + '">' + tiposerviciolst[i].nmtiposerv + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPersonaFormacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urltipoformacion = urlController + "Persona_Formacion/GetAllPersona_Formacion";    

  return new Promise( (resolve, reject) => {
    fetch(urltipoformacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tipoformacionlst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < tipoformacionlst.length; i++) {
              $('#' + select).append('<option value="' + tipoformacionlst[i].id_formacion + '">' + tipoformacionlst[i].nmformacion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPersonaTituloAltoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urltituloalto = urlController + "Persona_TituloAlto/GetAllPersona_TituloAlto";    

  return new Promise( (resolve, reject) => {
    fetch(urltituloalto, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tituloaltolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < tituloaltolst.length; i++) {
              $('#' + select).append('<option value="' + tituloaltolst[i].id_tituloalto + '">' + tituloaltolst[i].nmtituloalto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

//CARGA LA CALIFICACION QUE SE PUEDE ASIGNAR AL PRESTADOR DE SERVICIOS BASADO EN UNA REGLA FIJA
function LoadPersonaCalificacionSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="0">NO APLICA</option>');
    $('#' + select).append('<option value="1">DEFICIENTE</option>');
    $('#' + select).append('<option value="2">MALO</option>');
    $('#' + select).append('<option value="3">REGULAR</option>');
    $('#' + select).append('<option value="4">BUENO</option>');
    $('#' + select).append('<option value="5">EXCELENTE</option>');

    return resolve(true);
  });  

}

function LoadTipoProyecto(select, tienenulo) {
  $('#' + select).empty();
  let urltipoproyecto = urlController + "Proyectos_TipoProyecto/GetAllProyectos_TipoProyecto";    

  return new Promise( (resolve, reject) => {
    fetch(urltipoproyecto, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tipoproyectolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < tipoproyectolst.length; i++) {
              $('#' + select).append('<option value="' + tipoproyectolst[i].id_tipoproyecto + '">' + tipoproyectolst[i].tipoproyecto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadNaturalezaProyecto(select, tienenulo) {
  $('#' + select).empty();
  let urlnatproyecto = urlController + "Proyectos_NaturalezaProyecto/GetAllProyectos_NaturalezaProyecto";    

  return new Promise( (resolve, reject) => {
    fetch(urlnatproyecto, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let natproyectolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < natproyectolst.length; i++) {
              $('#' + select).append('<option value="' + natproyectolst[i].id_naturalezaproyecto + '">' + natproyectolst[i].naturalezaproyecto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

// function LoadPrestadorServicio(select, tienenulo) {
//   $('#' + select).empty();
//   let urlprestadorservicio = urlController + "Persona/GetAllPersona";    

//   return new Promise( (resolve, reject) => {
//     fetch(urlprestadorservicio, {
//         method: 'GET',
//         headers: { 'Authorization': 'Bearer ' + TokenIRIS }
//     })
//     .then(response => response.json())
//       .then(data => {
//         if (data.Ok) {
//             let prestadorserviciolst = data.Data;

//             if (tienenulo) {
//               $('#' + select).append('<option value="">Seleccione</option>');
//             }
            
//             for (var i = 0; i < prestadorserviciolst.length; i++) {
//               $('#' + select).append('<option value="' + prestadorserviciolst[i].id_persona + '">' + prestadorserviciolst[i].nombrecompleto + '</option>');
//             }            
//             return resolve(true);;
//         }
//         else {
//           return resolve(false);;
//         }            
//       })
//       .catch (err => {
//         ShowModalDialog(err, false, 'error', '', 0);
//         reject(err);
//       } );
//   });

// }

//CAMBIO ADDA
function LoadPrestadorServicio(select, tienenulo) {
  debugger;
  $('#' + select).empty();
  let urlprestadorservicio = urlController + "Persona/GetAllPersona";    

  return new Promise((resolve, reject) => {
      fetch(urlprestadorservicio, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
      .then(data => {
          if (data.Ok) {
              let prestadorserviciolst = data.Data;

              if (tienenulo) {
                  $('#' + select).append('<option value="">Seleccione</option>');
              }
              
              for (var i = 0; i < prestadorserviciolst.length; i++) {
                  $('#' + select).append('<option value="' + prestadorserviciolst[i].id_persona + '" data-identificacion="' + prestadorserviciolst[i].numidentificacion + '">' + prestadorserviciolst[i].nombrecompleto + '</option>');
              }            
              return resolve(true);
          }
          else {
              return resolve(false);
          }            
      })
      .catch(err => {
          ShowModalDialog(err, false, 'error', '', 0);
          reject(err);
      });
  });
}


function LoadAlcanceProyecto(select, tienenulo) {
  $('#' + select).empty();
  let urlalcance = urlController + "Proyectos_AlcanceProyecto/GetAllProyectos_AlcanceProyecto";    

  return new Promise( (resolve, reject) => {
    fetch(urlalcance, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let alcancelst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < alcancelst.length; i++) {
              $('#' + select).append('<option value="' + alcancelst[i].id_alcanceproyecto + '">' + alcancelst[i].alcanceproyecto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadEstadoContrato(select, tienenulo) {
  $('#' + select).empty();
  let urlestado = urlController + "Proyectos_EstadoContrato/GetAllProyectos_EstadoContrato";    

  return new Promise( (resolve, reject) => {
    fetch(urlestado, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let estadolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < estadolst.length; i++) {
              $('#' + select).append('<option value="' + estadolst[i].id_estadocontrato + '">' + estadolst[i].estadocontrato + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadRegistroRUP(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="1">PENDIENTE</option>');
    $('#' + select).append('<option value="2">EN TRÁMITE</option>');
    $('#' + select).append('<option value="3">GUARDADO PARCIAL</option>');
    $('#' + select).append('<option value="4">DEVUELTO</option>');
    $('#' + select).append('<option value="5">NO ACTUALIZABLE</option>');
    $('#' + select).append('<option value="6">REGISTRADO</option>');

    return resolve(true);
  });  

}


function LoadEntregaArchivo(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="1">PENDIENTE</option>');
    $('#' + select).append('<option value="2">EN TRÁMITE</option>');
    $('#' + select).append('<option value="3">REGISTRADO</option>');
  
    return resolve(true);
  });  

}

function LoadEstadoObligacionProyecto(select, tienenulo) {
  $('#' + select).empty();
  let urlestado = urlController + "Proyectos_EstadoObligacion/GetAllProyectos_EstadoObligacion";    

  return new Promise( (resolve, reject) => {
    fetch(urlestado, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let estadolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < estadolst.length; i++) {
              $('#' + select).append('<option value="' + estadolst[i].id_estadoobligacion + '">' + estadolst[i].estadoobligacion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadEstadoObligacionProyecto1(select, tienenulo) {
  $('#' + select).empty();
  let urlestado = urlController + "Proyectos_EstadoObligacion/GetAllProyectos_EstadoObligacion";    

  return new Promise( (resolve, reject) => {
    fetch(urlestado, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let estadolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < estadolst.length; i++) {
              $('#' + select).append('<option value="' + estadolst[i].id_estadoobligacion + '">' + estadolst[i].estadoobligacion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadTipoProductoProyecto(select, tienenulo) {
  $('#' + select).empty();
  let urltipoproducto = urlController + "Proyectos_TipoProducto/GetAllProyectos_TipoProducto";    

  return new Promise( (resolve, reject) => {
    fetch(urltipoproducto, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let tipoproductolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < tipoproductolst.length; i++) {
              $('#' + select).append('<option value="' + tipoproductolst[i].id_tipoproducto + '">' + tipoproductolst[i].tipoproducto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadEstadoProductoProyecto(select, tienenulo) {
  $('#' + select).empty();
  let urlestadoproducto = urlController + "Proyectos_EstadoProducto/GetAllProyectos_EstadoProducto";    

  return new Promise( (resolve, reject) => {
    fetch(urlestadoproducto, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let estadoproductolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < estadoproductolst.length; i++) {
              $('#' + select).append('<option value="' + estadoproductolst[i].id_estadoproducto + '">' + estadoproductolst[i].estadoproducto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadSeguimientoPartida(select, tienenulo) {
  $('#' + select).empty();
  let urlpartida = urlController + "Seguimiento_Partida/GetAllSeguimiento_Partida";    

  return new Promise( (resolve, reject) => {
    fetch(urlpartida, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let partidalst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < partidalst.length; i++) {
              $('#' + select).append('<option value="' + partidalst[i].id_partida + '">' + partidalst[i].nombrepartida + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadSeguimientoRubro(select, tienenulo) {
  $('#' + select).empty();
  let urlrubro = urlController + "Seguimiento_Rubro/GetAllSeguimiento_Rubro";    

  return new Promise( (resolve, reject) => {
    fetch(urlrubro, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let rubrolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < rubrolst.length; i++) {
              $('#' + select).append('<option value="' + rubrolst[i].id_rubro + '">' + rubrolst[i].nombrerubro + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadSeguimientoRubroByPartida(select, tienenulo, idpartida) {
  $('#' + select).empty();
  let urlrubro = urlController + "Seguimiento_Rubro/GetAllSeguimiento_RubroByPartida?id_partida=" + idpartida;    

  return new Promise( (resolve, reject) => {
    fetch(urlrubro, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let rubrolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < rubrolst.length; i++) {
              $('#' + select).append('<option value="' + rubrolst[i].id_rubro + '">' + rubrolst[i].nombrerubro + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadSeguimientoConceptoByRubro(select, tienenulo, idrubro) {
  $('#' + select).empty();
  let urlrubro = urlController + "Seguimiento_Concepto/GetSeguimiento_ConceptoByRubro?id_rubro=" + idrubro;    

  return new Promise( (resolve, reject) => {
    fetch(urlrubro, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let rubrolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < rubrolst.length; i++) {
              $('#' + select).append('<option value="' + rubrolst[i].id_segconcepto + '">' + rubrolst[i].nombreconcepto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

//CARGA EL VÍNCULO DEL PRESTADOR QUE SE PUEDE ASIGNAR AL GASTO BASADO EN UNA REGLA FIJA
function LoadPrestadorVinculoSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="1">NO APLICA</option>');
    $('#' + select).append('<option value="2">ÁREA</option>');
    $('#' + select).append('<option value="3">PREGRADO</option>');
    $('#' + select).append('<option value="4">POSGRADO</option>');
    $('#' + select).append('<option value="5">EGRESADO</option>');
    
    return resolve(true);
  });  

}

function LoadSemestreSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlsemestre = urlController + "Semestre/GetAllSemestre";

  return new Promise( (resolve, reject) => {
    fetch(urlsemestre, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let semestrelst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < semestrelst.length; i++) {
              $('#' + select).append('<option value="' + semestrelst[i].id_semestre + '">' + semestrelst[i].nmsemestre + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadLiteral_UGI(select, tienenulo) {
  $('#' + select).empty();
  let urlliteral = urlController + "Literal_UGI/GetAllLiteral_UGI";    

  return new Promise( (resolve, reject) => {
    fetch(urlliteral, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let literaleslst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < literaleslst.length; i++) {
              $('#' + select).append('<option value="' + literaleslst[i].id_literal + '">' + literaleslst[i].nmliteral + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadOrigenPublicacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlorigen = urlController + "Publicaciones_OrigenManuscrito/GetAllPublicaciones_OrigenManuscrito";    

  return new Promise( (resolve, reject) => {
    fetch(urlorigen, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_origenmanuscrito + '">' + lstdatos[i].nmorigenmanuscrito + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadTipoPublicacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urltipo = urlController + "Publicaciones_TipoObra/GetAllPublicaciones_TipoObra";    

  return new Promise( (resolve, reject) => {
    fetch(urltipo, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_tipoobra + '">' + lstdatos[i].nmtipoobra + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadGrupoInvestigacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urltipo = urlController + "Investigacion_CrearGrupo/GetAllInvestigacion_CrearGrupo";    

  return new Promise( (resolve, reject) => {
    fetch(urltipo, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_creargrupo + '">' + lstdatos[i].nombregrupo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadPublicacionColeccionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Coleccion/GetAllPublicaciones_Coleccion";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_coleccion + '">' + lstdatos[i].nmcoleccion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadPublicacionCoedicionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Coedicion/GetAllPublicaciones_Coedicion";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_coedicion + '">' + lstdatos[i].numcoedicion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadPublicacionFormatoDistribucionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_FormatoDistribucion/GetAllPublicaciones_FormatoDistribucion";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_formatodistribucion + '">' + lstdatos[i].nmformatodis + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadPublicacionComplejidadSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Complejidad/GetAllPublicaciones_Complejidad";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_complejidad + '">' + lstdatos[i].nmcomplejidad + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadPublicacionIdiomaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Idioma/GetAllPublicaciones_Idioma";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_idioma + '">' + lstdatos[i].nmidioma + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadPublicacionCaracterEditorialSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_CarProyEditorial/GetAllPublicaciones_CarProyEditorial";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_carproyeditorial + '">' + lstdatos[i].nmcarproyeditorial + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadSistemaCitacionPublicacionSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="1">En Revisión</option>');  
    $('#' + select).append('<option value="2">APA</option>');  
    $('#' + select).append('<option value="3">HARVARD</option>');
    $('#' + select).append('<option value="4">ISO 690</option>');
    $('#' + select).append('<option value="5">VANCOUVER</option>');
    $('#' + select).append('<option value="6">ACS</option>');
    $('#' + select).append('<option value="7">CHICAGO</option>');
    $('#' + select).append('<option value="8">IEEE</option>');
    $('#' + select).append('<option value="9">MLA</option>');  
      
    return resolve(true);
  });  

}

function LoadRecomendacionImpresionPublicacionSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="1">A Color</option>');
    $('#' + select).append('<option value="2">Blanco / Negro</option>');

    return resolve(true);
  });  

}


function LoadSiNoNoAplicaSelect(select, tienenulo) {
  $('#' + select).empty();

  return new Promise( (resolve, reject) => {
    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }
  
    $('#' + select).append('<option value="0">NO APLICA</option>');
    $('#' + select).append('<option value="1">SI</option>');
    $('#' + select).append('<option value="2">NO</option>');

    return resolve(true);
  });  

}

function LoadPersonaTipoEvaluadorSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="1">INTERNO</option>');
    $('#' + select).append('<option value="2">EXTERNO</option>');

    return resolve(true);
  });  

}

function LoadPersonaEvaluador(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Persona/GetAllPersonaEvaluador";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_persona + '">' + lstdatos[i].nombrecompleto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
    
}

function LoadEstadoEvaluador(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_EstadoEvaluador/GetAllPublicaciones_EstadoEvaluador";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_estadoevaluador + '">' + lstdatos[i].nmestadoevaluador + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadPublicacionEvaluadoresSelect(select, tienenulo, idPublicacion) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Evaluadores/GetPublicaciones_EvaluadoresByPublicacion?id_crearpublicacion=" + idPublicacion;    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_evaluadores + '">' + lstdatos[i].NombreEvaluador + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPublicacionConceptoEstadoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_EstadoConcepto/GetAllPublicaciones_EstadoConcepto";

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_estadoconcepto + '">' + lstdatos[i].nmestadoconcepto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadPublicacionConceptoFinalSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Concepto/GetAllPublicaciones_Concepto";

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_concepto + '">' + lstdatos[i].nmconcepto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadPublicacionConceptoNroEvaluacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_EvalGenerada/GetAllPublicaciones_EvalGenerada";

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_evalgenerada + '">' + lstdatos[i].conevalgenerada + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadPublicacionEvaluacionInicialSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_EvaluacionInicial/GetAllPublicaciones_EvaluacionInicial";

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstdatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < lstdatos.length; i++) {
              $('#' + select).append('<option value="' + lstdatos[i].id_evaluacioninicial + '">' + lstdatos[i].nmevalinicial + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadPublicacionAprobacionTipoPublicacionSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="IMPRESO">Libro Impreso</option>');
    $('#' + select).append('<option value="ELECTRONICO">Publicación Electrónica</option>');

    return resolve(true);
  });  

}


function LoadMacroprocesoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlMacroproceso = urlController + "DecVie_Macroproceso/GetAllDecVie_Macroproceso";    

  return new Promise( (resolve, reject) => {
    fetch(urlMacroproceso, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let macroproceso = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }


            for (var i = 0; i < macroproceso.length; i++) {
              $('#' + select).append('<option value="' + macroproceso[i].id_decviemacroproceso + '">' + macroproceso[i].nmdecviemacroproceso + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVieTipologiaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlDecVieTipologia = urlController + "DecVie_Tipologia/GetAllDecVie_Tipologia";    

  return new Promise( (resolve, reject) => {
    fetch(urlDecVieTipologia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let DecVieTipologia = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }


            for (var i = 0; i < DecVieTipologia.length; i++) {
              $('#' + select).append('<option value="' + DecVieTipologia[i].id_decvietipologia + '">' + DecVieTipologia[i].nmdecvietipologia + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_InventarioConocimientoTipologiaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlDecVieTipologia = urlController + "DecVie_InventarioConocimientoTipologia/GetAllDecVie_InventarioConocimientoTipologia";    

  return new Promise( (resolve, reject) => {
    fetch(urlDecVieTipologia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let DecVieTipologia = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }


            for (var i = 0; i < DecVieTipologia.length; i++) {
              $('#' + select).append('<option value="' + DecVieTipologia[i].id_conocimientotipologia + '">' + DecVieTipologia[i].nmtipologia + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_InventarioConocimientoEnfasisSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlDecVieTipologia = urlController + "DecVie_InventarioConocimientoEnfasis/GetAllDecVie_InventarioConocimientoEnfasis";    

  return new Promise( (resolve, reject) => {
    fetch(urlDecVieTipologia, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let DecVieTipologia = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }


            for (var i = 0; i < DecVieTipologia.length; i++) {
              $('#' + select).append('<option value="' + DecVieTipologia[i].id_conocimientoenfasis + '">' + DecVieTipologia[i].nmenfasis + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_InventarioConocimientoImpactoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlDecVieTipoActo = urlController + "DecVie_InventarioConocimientoImpacto/GetAllDecVie_InventarioConocimientoImpacto";    

  return new Promise( (resolve, reject) => {
    fetch(urlDecVieTipoActo, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let DecVieTipoActo = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
              
            for (var i = 0; i < DecVieTipoActo.length; i++) {
              $('#' + select).append('<option value="' + DecVieTipoActo[i].id_conocimientoimpacto + '">' + DecVieTipoActo[i].nmimpacto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_InventarioRegistroPatenteTipoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlDecVieTipoActo = urlController + "DecVie_InventarioRegistroPatenteTipo/GetAllDecVie_InventarioRegistroPatenteTipo";    

  return new Promise( (resolve, reject) => {
    fetch(urlDecVieTipoActo, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let DecVieTipoActo = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
              
            for (var i = 0; i < DecVieTipoActo.length; i++) {
              $('#' + select).append('<option value="' + DecVieTipoActo[i].id_patentetipo + '">' + DecVieTipoActo[i].nmpatentetipo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVieTipoActoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlDecVieTipoActo = urlController + "DecVie_ActosAdministrativosTipo/GetAllDecVie_ActosAdministrativosTipo";    

  return new Promise( (resolve, reject) => {
    fetch(urlDecVieTipoActo, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let DecVieTipoActo = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
              
            for (var i = 0; i < DecVieTipoActo.length; i++) {
              $('#' + select).append('<option value="' + DecVieTipoActo[i].id_tipoactoadministrativo + '">' + DecVieTipoActo[i].nmidtipoactoadministrativo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVieEstadoActoAdministrativoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlDecVieEstadoActo = urlController + "DecVie_ActosAdministrativosEstado/GetAllDecVie_ActosAdministrativosEstado";    

  return new Promise( (resolve, reject) => {
    fetch(urlDecVieEstadoActo, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let DecVieEstadoActo = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < DecVieEstadoActo.length; i++) {
              $('#' + select).append('<option value="' + DecVieEstadoActo[i].id_estadoactoadministrativo + '">' + DecVieEstadoActo[i].nmestadoactoadministrativo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}


function LoadDecvieconcepto(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_Concepto/GetAllDecVie_Concepto";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_decvieconcepto + '">' + lstDatos[i].nmconcepto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}


function LoadDecVie_OrigenSolicitud(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_OrigenSolicitud/GetAllDecVie_OrigenSolicitud";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_origensolicitud + '">' + lstDatos[i].nmorigensolicitud + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_Instancias(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_Instancias/GetAllDecVie_Instancias";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_instancia + '">' + lstDatos[i].nminstancia + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_AlcanceSolicitud(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_AlcanceSolicitud/GetAllDecVie_AlcanceSolicitud";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_alcancesolicitud + '">' + lstDatos[i].nmalcancesolicitud + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_Estado(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_Estado/GetAllDecVie_Estado";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_decvieestado + '">' + lstDatos[i].nmdecvieestado + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadPublicacionTipoCorreccionselect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="ESTILO">De Estilo</option>');
    $('#' + select).append('<option value="ORTOTIPOGRAFICA">Ortotipográfica</option>');

    return resolve(true);
  });  

}
function LoadunidadproductoraDecVie_RadicadorCorSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="D">Digital</option>');
    $('#' + select).append('<option value="F">Físico</option>');

    return resolve(true);
  });  

}

function LoadDecVie_ColegiadosSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_Colegiados/GetAllDecVie_Colegiados";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_colegiado + '">' + lstDatos[i].nmcolegiado + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadEstadoCorreccionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_EstadoCorreccion/GetAllPublicaciones_EstadoCorreccion";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadocorreccion + '">' + lstDatos[i].nmestadocorreccion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadpublicacionTipologiaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Tipologia/GetAllPublicaciones_Tipologia";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_tipologia + '">' + lstDatos[i].nmtipologia + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}


function LoadpublicacionTipodiagramacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_TipoDiagramacion/GetAllPublicaciones_TipoDiagramacion";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_tipodiagramacion + '">' + lstDatos[i].nmtipodiagramacion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadpublicacionEstadodiagramacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_EstadoDiagramacion/GetAllPublicaciones_EstadoDiagramacion";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadodiagramacion + '">' + lstDatos[i].nmestadodiagramacion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadpublicacionEstadoCubiertaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_EstadoCubierta/GetAllPublicaciones_EstadoCubierta";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadocubierta + '">' + lstDatos[i].nmestadocubierta + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_InventarioUsoAmpliadoInsumoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_InventarioUsoAmpliadoInsumo/GetAllDecVie_InventarioUsoAmpliadoInsumo";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_insumo + '">' + lstDatos[i].nminsumo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_InventarioUsoAmpliadoAhorroSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_InventarioUsoAmpliadoAhorro/GetAllDecVie_InventarioUsoAmpliadoAhorro";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_ahorro + '">' + lstDatos[i].nmahorro + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_InventarioConocimientoSoporteSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_InventarioConocimientoSoporte/GetAllDecVie_InventarioConocimientoSoporte";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_conocimientosoporte + '">' + lstDatos[i].nmsoporte + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_InventarioObsolescenciaConceptoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_InventarioObsolescenciaConcepto/GetAllDecVie_InventarioObsolescenciaConcepto";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_obsolescenciaconcepto + '">' + lstDatos[i].nmconcepto + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function SumarTotales(controlsumando1, controlsumando2, controlsumando3, controlsumando4, totalcontrol, sufijo) {
  let tControl = null;
  let nvalortotal = 0;
  let svalorsumando = '';
  let nvalorsumando = 0;
  let sufijonombrecontrol = (sufijo == null) ? '' : sufijo;
  $('#' + totalcontrol).val('0');

  if (controlsumando1 != null) {
    tControl = document.getElementById(controlsumando1);

    if (tControl != null) {
      svalorsumando = $('#' + controlsumando1).val();
      nvalorsumando = Number(svalorsumando);
  
      nvalortotal += nvalorsumando;
    }  
  }

  if (controlsumando2 != null) {
    tControl = document.getElementById(controlsumando2);

    if (tControl != null) {
      svalorsumando = $('#' + controlsumando2).val();
      nvalorsumando = Number(svalorsumando);
  
      nvalortotal += nvalorsumando;
    }  
  }

  if (controlsumando3 != null) {
    tControl = document.getElementById(controlsumando3);

    if (tControl != null) {
      svalorsumando = $('#' + controlsumando3).val();
      nvalorsumando = Number(svalorsumando);
  
      nvalortotal += nvalorsumando;
    }  
  }

  if (controlsumando4 != null) {
    tControl = document.getElementById(controlsumando4);

    if (tControl != null) {
      svalorsumando = $('#' + controlsumando4).val();
      nvalorsumando = Number(svalorsumando);
  
      nvalortotal += nvalorsumando;
    }  
  }

  $('#' + totalcontrol).val(nvalortotal);

}

function LoadImpresionTipoEncuadernacionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_ImpresionEncuadernacion/GetAllPublicaciones_ImpresionEncuadernacion";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_encuadernacion + '">' + lstDatos[i].nmencuadernacion + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadImpresionTipoPapelSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_ImpresionPapel/GetAllPublicaciones_ImpresionPapel";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_papel + '">' + lstDatos[i].nmpapel + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadImpresionTipoImpresionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_ImpresionTipo/GetAllPublicaciones_ImpresionTipo";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_impresiontipo + '">' + lstDatos[i].nmimpresiontipo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadImpresionTipoGramajeSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_ImpresionGramaje/GetAllPublicaciones_ImpresionGramaje";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_gramaje + '">' + lstDatos[i].nmgramaje + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadImpresionTintasTacoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_ImpresionTintasTaco/GetAllPublicaciones_ImpresionTintasTaco";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_tintastaco + '">' + lstDatos[i].nmtintastaco + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadDecVie_PlanAccionAlcanceAnnoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionAlcanceAnno/GetAllDecVie_PlanAccionAlcanceAnno";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_alcanceanno + '">' + lstDatos[i].nmalcanceanno + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadCorrespondencia_PrefijoConsecutivoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Correspondencia_PrefijoConsecutivo/GetAllCorrespondencia_PrefijoConsecutivo";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_prefijoconsecutivo + '">' + lstDatos[i].nmprefijo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadCorrespondencia_PrefijoConsecutivoByDependenciaSelect(select, tienenulo, iddependencia) {  
  $('#' + select).empty();
  let urldatos = urlController + "Correspondencia_PrefijoConsecutivo/GetCorrespondencia_PrefijoConsecutivoByDependencia?id_depend=" + iddependencia;      

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_prefijoconsecutivo + '">' + lstDatos[i].nmprefijo + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadOficinaDecVieSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_DerechosPeticionOficina/GetAllDecVie_DerechosPeticionOficina";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_oficina + '">' + lstDatos[i].nmoficina + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadEstadoDerechoPeticionSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_DerechosPeticionEstado/GetAllDecVie_DerechosPeticionEstado";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadoderpet + '">' + lstDatos[i].nmestadoderpet + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadpublicacionDisposicionLegalSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_DepositoDisposicionLegal/GetAllPublicaciones_DepositoDisposicionLegal";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].iddisposicionlegal + '">' + lstDatos[i].disposicionlegal + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadpublicacionComercializadorSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_Distribuidor/GetAllPublicaciones_Distribuidor";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].iddistribuidor + '">' + lstDatos[i].distribuidor + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadpublicacionBodegaInventarioSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_DepositoControlInventarioBodega/GetAllPublicaciones_DepositoControlInventarioBodega";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_bodega + '">' + lstDatos[i].nmbodega + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadpublicacionTipoMovimientoInventarioSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Publicaciones_DepositoTipoMov/GetAllPublicaciones_DepositoTipoMov";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_tipomov + '">' + lstDatos[i].nmtipomov + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadInvitadoNacionalSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="NACIONAL">NACIONAL</option>');
    $('#' + select).append('<option value="INTERNACIONAL">INTERNACIONAL</option>');
    
    return resolve(true);
  });  

}

function LoadFeriaEventoSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="FERIA">FERIA</option>');
    $('#' + select).append('<option value="EVENTO">EVENTO</option>');
    
    return resolve(true);
  });  

}

function LoadDecVie_PlanAccionLineaPoliticaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionLineaPolitica/GetAllDecVie_PlanAccionLineaPolitica";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_lineapolitica + '">' + lstDatos[i].lineapolitica + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionEjeEstrategicoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionEjeEstrategico/GetAllDecVie_PlanAccionEjeEstrategico";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_ejeestrategico + '">' + lstDatos[i].ejeestrategico + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionObjetivoEstrategicoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionObjetivoEstrategico/GetAllDecVie_PlanAccionObjetivoEstrategico";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_objetivoestrategico + '">' + lstDatos[i].objetivoestrategico + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionProgramaPgdSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionProgramaPgd/GetAllDecVie_PlanAccionProgramaPgd";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_programapgd + '">' + lstDatos[i].nmprogramapgd + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionObjetivosPgdVriSedeSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionObjetivosPgdVriSede/GetAllDecVie_PlanAccionObjetivosPgdVriSede";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_objetivopgdvrisede + '">' + lstDatos[i].nmobjetivopgdvrisede + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionObjetivoDependenciaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionObjetivoDependencia/GetAllDecVie_PlanAccionObjetivoDependencia";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_objetivodependencia + '">' + lstDatos[i].nmobjetivodependencia.substring(0,50) + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionMetaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionMeta/GetAllDecVie_PlanAccionMeta";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_meta + '">' + lstDatos[i].nmmeta + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionIndicadoresEstrategicosSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionIndicadoresEstrategicos/GetAllDecVie_PlanAccionIndicadoresEstrategicos";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_indicadoresestrategicos + '">' + lstDatos[i].nmindicadoresestrategicos.substring(0,50) + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionNuevosIndicadoresSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionNuevosIndicadores/GetAllDecVie_PlanAccionNuevosIndicadores";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_nuevosindicadores + '">' + lstDatos[i].nmnuevosindicadores.substring(0,50) + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionTipoIndicadorSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionTipoIndicador/GetAllDecVie_PlanAccionTipoIndicador";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_tipoindicador + '">' + lstDatos[i].nmtipoindicador + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionAlcanceSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionAlcance/GetAllDecVie_PlanAccionAlcance";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_planaccionalcance + '">' + lstDatos[i].descripcionalcance + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecvie_MatryoshkaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Decvie_Matryoshka/GetAllDecvie_Matryoshka";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_matryoska + '">' + lstDatos[i].alcance + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecvie_MatryoshkaObjetivoDepSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Decvie_MatryoshkaObjetivoDep/GetAllDecvie_MatryoshkaObjetivoDep";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_matryoshkaobjetivodep + '">' + lstDatos[i].DescripcionObjetivoDep + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecvie_MatryoshkaMetaDepSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Decvie_MatryoshkaMetaDep/GetAllDecvie_MatryoshkaMetaDep";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_matryoshkametadep + '">' + lstDatos[i].NombreMeta + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_PlanAccionActividadesSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_PlanAccionActividades/GetAllDecVie_PlanAccionActividades";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_actividades + '">' + lstDatos[i].nmactividad + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecvie_MatryoshkaEstrategiaSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Decvie_MatryoshkaEstrategia/GetAllDecvie_MatryoshkaEstrategia";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_matryoshkaestrategia + '">' + lstDatos[i].estrategia.substring(0,50) + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadRolUsuarioSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Rol/GetAllRol";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].idrol + '">' + lstDatos[i].nombre + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadTipoProgramaPostgradoSelect(select, tienenulo) {
  $('#' + select).empty();

  return new Promise( (resolve, reject) => {
    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="ESPECIALIZACIÓN">ESPECIALIZACIÓN</option>');
    $('#' + select).append('<option value="MAESTRÍA">MAESTRÍA</option>');
    $('#' + select).append('<option value="DOCTORADO">DOCTORADO</option>');

    return resolve(true);
  });  
}

 
function LoadDecvie_CicloFinancieroProgramasPostgradoSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Decvie_CicloFinancieroProgramaPostgrado/GetAllDecvie_CicloFinancieroProgramaPostgrado";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_programapostgrado + '">' + lstDatos[i].nmprogramapostgrado + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadEstadoTareaSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Estado_Tarea/GetAllEstado_Tarea";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadotarea + '">' + lstDatos[i].nmestadotarea + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadEstadoTareaFiltroSelect(select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Estado_Tarea/GetAllEstado_Tarea";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            $('#' + select).append('<option value="-1">No Finalizadas</option>');
            $('#' + select).append('<option value="0">Todas</option>');

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadotarea + '">' + lstDatos[i].nmestadotarea + '</option>');
            }            
            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });  
}
 
function LoadFuncionarioCorreoSelect(select, tienenulo) {
  $('#' + select).empty();
  let urlfuncionario = urlController + "Funcionario/GetAllFuncionario";    

  return new Promise( (resolve, reject) => {
    fetch(urlfuncionario, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let funcionariolst = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }
            
            for (var i = 0; i < funcionariolst.length; i++) {
              $('#' + select).append('<option value="' + funcionariolst[i].correo + '">' + funcionariolst[i].nombrecompleto + '</option>');
            }            
            return resolve(true);
        }
        else {
          return resolve(false);
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });

}

function LoadSeguimiento_RubroSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Seguimiento_Rubro/GetAllSeguimiento_Rubro";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_rubro + '">' + lstDatos[i].nombrerubro + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_TipoDocContractualesSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_TipoDocContractuales/GetAllDecVie_TipoDocContractuales";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_doccontractuales + '">' + lstDatos[i].nmdoccontractuales + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadrevisionprecontractualSelect(select, tienenulo) {
  $('#' + select).empty();

  return new Promise( (resolve, reject) => {
    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="Revisado">Revisado</option>');
    $('#' + select).append('<option value="No Revisado">No Revisado</option>');   

    return resolve(true);
  });  
}

function LoadDecVie_RevSigepSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_RevSigep/GetAllDecVie_RevSigep";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_revsigep + '">' + lstDatos[i].nmrevsigep + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_AsuntosDisciplinariosSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_AsuntosDisciplinarios/GetAllDecVie_AsuntosDisciplinarios";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_asuntosdisciplinarios + '">' + lstDatos[i].nmasuntosdisciplinarios + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_ConceptoDecanaturaSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_ConceptoDecanatura/GetAllDecVie_ConceptoDecanatura";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_conceptodecanatura + '">' + lstDatos[i].nmconceptodecanatura + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadDecVie_EstadoPreAvalSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "DecVie_EstadoPreAval/GetAllDecVie_EstadoPreAval";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadopreaval + '">' + lstDatos[i].nmestadopreaval + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadEstadoTramiteSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="PENDIENTE">PENDIENTE</option>');
    $('#' + select).append('<option value="REVISION">EN REVISIÓN</option>');
    $('#' + select).append('<option value="COMPLETO">COMPLETO</option>');
  
    return resolve(true);
  });  

}
function LoadConcepto_UGISelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Concepto_UGI/GetAllConcepto_UGI";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_conceptougi + '">' + lstDatos[i].concepto + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadNaturalezaConvocatoriaSelect(select, tienenulo) {
  $('#' + select).empty();

  return new Promise( (resolve, reject) => {
    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="INTERNO">INTERNO</option>');
    $('#' + select).append('<option value="EXTERNO">EXTERNO</option>');
  
    return resolve(true);
  });  
}

function LoadConvocatoria_AlcanceSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Convocatoria_Alcance/GetAllConvocatoria_Alcance";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_alcance + '">' + lstDatos[i].nmalcance + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadConvocatoria_FuenteCNVSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Convocatoria_FuenteCnv/GetAllConvocatoria_FuenteCnv";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_fuentecnv + '">' + lstDatos[i].nmfuentecnv + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadConvocatoria_EstadoCNVSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Convocatoria_EstadoCnv/GetAllConvocatoria_EstadoCnv";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estadocnv + '">' + lstDatos[i].nmestadocnv + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadConvocatoriaSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Convocatoria/GetAllConvocatoria";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_convocatoria + '">' + lstDatos[i].tituloconvocatoria + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadEstadoProyectoSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "Investigacion_EstadoProyecto/GetAllInvestigacion_EstadoProyecto";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_estado + '">' + lstDatos[i].nmestado + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadAnnoPublicacionSelect(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="2018">2018</option>');
    $('#' + select).append('<option value="2019">2019</option>');
    $('#' + select).append('<option value="2020">2020</option>');
    $('#' + select).append('<option value="2021">2021</option>');
    $('#' + select).append('<option value="2022">2022</option>');
    $('#' + select).append('<option value="2023">2023</option>');
    $('#' + select).append('<option value="2024">2024</option>');
    $('#' + select).append('<option value="2025">2025</option>');
    $('#' + select).append('<option value="2026">2026</option>');
    $('#' + select).append('<option value="2027">2027</option>');
    $('#' + select).append('<option value="2028">2028</option>');
    $('#' + select).append('<option value="2029">2029</option>');
    $('#' + select).append('<option value="2030">2030</option>');
    $('#' + select).append('<option value="2031">2031</option>');
    $('#' + select).append('<option value="2032">2032</option>');
    $('#' + select).append('<option value="2033">2033</option>');
    $('#' + select).append('<option value="2034">2034</option>');
    $('#' + select).append('<option value="2035">2035</option>');
    
    return resolve(true);
  });  

}

function LoadMatrizFinanciera_VigenciaSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "MatrizFinanciera_Vigencia/GetAllMatrizFinanciera_Vigencia";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_vigencia + '">' + lstDatos[i].nmvigencia + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadMatrizFinanciera_TipoOperativoSelect (select, tienenulo) {
  $('#' + select).empty();
  let urldatos = urlController + "MatrizFinanciera_TipoOperativo/GetAllMatrizFinanciera_TipoOperativo";    

  return new Promise( (resolve, reject) => {
    fetch(urldatos, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            let lstDatos = data.Data;

            if (tienenulo) {
              $('#' + select).append('<option value="">Seleccione</option>');
            }

            for (var i = 0; i < lstDatos.length; i++) {
              $('#' + select).append('<option value="' + lstDatos[i].id_tipooperativo + '">' + lstDatos[i].nmtipooperativo + '</option>');
            }            

            return resolve(true);;
        }
        else {
          return resolve(false);;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });
}

function LoadTipoInformeActosAdministrativos(select, tienenulo) {
  return new Promise( (resolve, reject) => {
    $('#' + select).empty();

    if (tienenulo) {
      $('#' + select).append('<option value="">Seleccione</option>');
    }

    $('#' + select).append('<option value="1">Por Tipo Acto</option>');
    $('#' + select).append('<option value="2">Por Estado Proceso</option>');
    $('#' + select).append('<option value="3">Por Tipología</option>');
    $('#' + select).append('<option value="4">Por Dependencia Solicitante</option>');
    $('#' + select).append('<option value="5">Por Macroproceso</option>');
    $('#' + select).append('<option value="6">Agrupado Por Mes</option>');

    resolve(true);
  });  
}