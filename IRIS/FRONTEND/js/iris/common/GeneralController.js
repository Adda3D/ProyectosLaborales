//const { V } = require("chart.js/dist/chunks/helpers.core");

var objDatosModelo = null;
var objArrCamposModelo = null;
var objArrCamposHTMLModelo = null;
var sNombreModelo = null;
var ObjModelToLoad = null;
var sSufijoControl = '';
var sCampoValidaDuplicado = '';
var sControlValidaDuplicado = '';

function NewData_ToModel(objLoad) {
    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sCampoValidaDuplicado = '';
    sControlValidaDuplicado = '';
    sSufijoControl = '';

    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }
    
    StartLoader();    

    return new Promise( (resolve, reject) => {
        //VALIDAR QUE LOS CONTROLES EN EL HTML COINCIDAN CON LOS CAMPOS
        ValidarCamposFormularioHTML(false)
        .then (respuesta => { 
            if (respuesta) {
                //PARA LOS CAMPOS SELECT CARGA LOS DATOS A LISTAR
                
                CargarCamposSelect_Model()
                .then (loaded => { 
                    if (loaded) {
                        //PONE TODO LOS DATOS EN BLANCO PREVIO A LA CARGA DE INFO
                        InicializarCampos_Model()
                        .then (inicializado => {
                            removeValidationFormByForm(ObjModelToLoad.FormEdicion); 
                            FinalizeLoader();
                            resolve(inicializado)
                        })
                        .catch (err => { reject (err)})
                    }    
                    else {
                        resolve(loaded) 
                    }
                })
                .catch (err => { reject (err)})
            }
            //else {
            //    resolve(respuesta)
            //}
            
        })
        .catch (err => { reject (err)})
    });

}

function LoadData_ToModel(objLoad, idParamGet1, idParamGet2, idParamGet3) {    
    let urlEditar = urlController + objLoad.ControllerName + '/' + objLoad.MethodGet;

    if (objLoad.ParamGetName1 != '') {
        urlEditar = urlEditar + '?' + objLoad.ParamGetName1 + '=' + idParamGet1;
    }

    if (objLoad.ParamGetName2 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName2 + '=' + idParamGet2;
    }

    if (objLoad.ParamGetName3 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName3 + '=' + idParamGet3;
    }

    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sCampoValidaDuplicado = '';
    sControlValidaDuplicado = '';
    sSufijoControl = '';

    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }

    StartLoader();    

    return new Promise( (resolve, reject) => {
        //VALIDAR QUE LOS CONTROLES EN EL HTML COINCIDAN CON LOS CAMPOS
        ValidarCamposFormularioHTML(true)
        .then (respuesta => { 
            if (respuesta) {
                //PARA LOS CAMPOS SELECT CARGA LOS DATOS A LISTAR
               CargarCamposSelect_Model()
                .then (loaded => { 
                    if (loaded) {
                        //PONE TODO LOS DATOS EN BLANCO PREVIO A LA CARGA DE INFO

                         InicializarCampos_Model()
                        .then (inicializado => {
                                fetch(urlEditar, {
                                    method: 'GET',
                                    headers: { 'Authorization': 'Bearer ' + TokenIRIS }
                                })
                                .then(response => response.json())
                                 .then(data => {
                                  if (data.Ok) {                      
                                      let datos = data.Data;
                      
                                      if (objLoad.DatosNullEdicion) {
                                          if (datos != null) {
                                              objDatosModel = datos;
                                              SetCamposFormulario();
                                          }    
                                      }
                                      else {
                                          objDatosModel = datos;
                                          SetCamposFormulario();
                                      }
                                                     
                                      removeValidationFormByForm(ObjModelToLoad.FormEdicion); 
                                      FinalizeLoader();
                                                    
                                      resolve(true);
                                  }
                                  else {
                                      ShowModalDialog(data.Message, false, 'warning', '', 0);
                                      FinalizeLoader();
                                      resolve(false);                                  
                                  }                
                                })
                                .then( resultado => {
                                  return resolve(resultado);
                                })
                                .catch (err => { reject (err);})    
                                             
                            
                        })
                        .catch (err => { reject (err)})
                    }
                    else {
                        resolve(loaded) 
                    }
                    
                })
                .catch (err => { reject (err)})
            }
            //resolve(respuesta)
        })
        .catch (err => { reject (err)})
    });
}

function LoadData_ToModelConsecutivo(objLoad, idParamGet1, idParamGet2, idParamGet3) {    
    const campoConsecutivo = document.getElementById('txtnumconsecutivo_DecVie_Consecutivo')
    let selectPrefijo = document.getElementById('cboid_prefijoconsecutivo_DecVie_Consecutivo')
        
    let urlEditar = urlController + objLoad.ControllerName + '/' + objLoad.MethodGet;

    if (objLoad.ParamGetName1 != '') {
        urlEditar = urlEditar + '?' + objLoad.ParamGetName1 + '=' + idParamGet1;
    }

    if (objLoad.ParamGetName2 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName2 + '=' + idParamGet2;
    }

    if (objLoad.ParamGetName3 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName3 + '=' + idParamGet3;
    }

    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sCampoValidaDuplicado = '';
    sControlValidaDuplicado = '';
    sSufijoControl = '';
    
    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }
    
    StartLoader();    
    
    return new Promise((resolve, reject) => {
        // VALIDAR QUE LOS CONTROLES EN EL HTML COINCIDAN CON LOS CAMPOS
        ValidarCamposFormularioHTML(true)
        .then(respuesta => { 
            if (respuesta) {
                // PARA LOS CAMPOS SELECT CARGA LOS DATOS A LISTAR
                CargarCamposSelect_Model()
                .then(loaded => { 
                    if (loaded) {
                        // PONE TODOS LOS DATOS EN BLANCO PREVIO A LA CARGA DE INFO
                        InicializarCampos_Model()
                        .then(inicializado => {
                            fetch(urlEditar, {
                                method: 'GET',
                                headers: { 'Authorization': 'Bearer ' + TokenIRIS }
                            })
                            .then(response => response.json())
                            .then(data => {
                                if (data.Ok) {                      
                                    let datos = data.Data;
                                    console.log('Datos obtenidos:', datos);  // Log de los datos obtenidos
                                    const originalConsecutivo = datos.numconsecutivo;
                                    console.log('Consecutivo original:', originalConsecutivo);  // Log del consecutivo original
                                    let originalPrefijoId = datos.id_prefijoconsecutivo; 
                                    console.log('Prefijo original ID:', originalPrefijoId);  // Log del prefijo original ID
                                    let prefijoString = originalPrefijoId.toString();
                                    console.log('Prefijo string:', prefijoString);  // Log del prefijo como string
                                    
                                    setTimeout(() => {
                                        $('#cboid_prefijoconsecutivo_DecVie_Consecutivo').val(prefijoString).trigger('change.select2');
                                        

                                    }, 500);
                                    if (objLoad.DatosNullEdicion) {
                                        if (datos != null) {
                                            objDatosModel = datos;
                                            if (campoConsecutivo === datos.numconsecutivo) {
                                                // El consecutivo no ha cambiado, no actualices el campo
                                            } else {
                                                objDatosModel = datos;
                                                SetCamposFormulario();
                                            }
                                        }    
                                    } else {
                                        objDatosModel = datos;
                                        if (campoConsecutivo === datos.numconsecutivo) {
                                            // El consecutivo no ha cambiado, no actualices el campo
                                        } else {
                                            objDatosModel = datos;
                                            SetCamposFormulario();
                                        }
                                    }

                                    removeValidationFormByForm(ObjModelToLoad.FormEdicion); 
                                    FinalizeLoader();
                                    resolve(true);
                                } else {
                                    ShowModalDialog(data.Message, false, 'warning', '', 0);
                                    FinalizeLoader();
                                    resolve(false);                                  
                                }                
                            })
                            .catch(err => reject(err));    
                        })
                        .catch(err => reject(err));
                    } else {
                        resolve(loaded);
                    }
                })
                .catch(err => reject(err));
            }
        })
        .catch(err => reject(err));
    });
    

}

function LoadData_ToModelRadicadorTec(objLoad, idParamGet1, idParamGet2, idParamGet3) {   
 
    const campoConsecutivo = document.getElementById('txtnumradicadortec_DecVie_RadicadorTec')
    let selectPrefijo = document.getElementById('cboid_prefijoconsecutivo_DecVie_RadicadorTec')
        
    let urlEditar = urlController + objLoad.ControllerName + '/' + objLoad.MethodGet;

    if (objLoad.ParamGetName1 != '') {
        urlEditar = urlEditar + '?' + objLoad.ParamGetName1 + '=' + idParamGet1;
    }

    if (objLoad.ParamGetName2 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName2 + '=' + idParamGet2;
    }

    if (objLoad.ParamGetName3 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName3 + '=' + idParamGet3;
    }

    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sCampoValidaDuplicado = '';
    sControlValidaDuplicado = '';
    sSufijoControl = '';
    
    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }
    
    StartLoader();    
    
    return new Promise((resolve, reject) => {
        console.log('Iniciando LoadData_ToModelRadicadorTec...');
        console.log('URL de edición:', urlEditar);
    
        // Validación inicial
        ValidarCamposFormularioHTML(true)
        .then(respuesta => { 
            console.log('ValidarCamposFormularioHTML completada:', respuesta);
            if (!respuesta) {
                console.error('Error en ValidarCamposFormularioHTML.');
                FinalizeLoader();
                return reject('Error en ValidarCamposFormularioHTML');
            }
    
            // Cargar datos para los selects
            CargarCamposSelect_Model()
            .then(loaded => { 
                console.log('CargarCamposSelect_Model completada:', loaded);
                if (!loaded) {
                    console.error('Error en CargarCamposSelect_Model.');
                    FinalizeLoader();
                    return reject('Error en CargarCamposSelect_Model');
                }
    
                // Inicializar campos
                InicializarCampos_Model()
                .then(inicializado => {
                    console.log('InicializarCampos_Model completada:', inicializado);
                    fetch(urlEditar, {
                        method: 'GET',
                        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
                    })
                    .then(response => {
                        console.log('Respuesta recibida del fetch:', response);
                        if (!response.ok) {
                            console.error('Error en la respuesta del fetch:', response.statusText);
                            FinalizeLoader();
                            return reject('Error en el fetch.');
                        }
                        return response.json();
                    })
                    .then(data => {
                        console.log('Datos del backend:', data);
                        if (data.Ok) {
                            const datos = data.Data;
                    
                            // Llama a la función para asignar valores al formulario
                            AsignarValoresFormulario(datos);
                    
                            // Finalizamos la carga
                            FinalizeLoader();
                            resolve(true);
                        } else {
                            console.error('Los datos del backend contienen errores:', data.Message);
                            ShowModalDialog(data.Message, false, 'warning', '', 0);
                            FinalizeLoader();
                            resolve(false);                                  
                        }                
                    })
                    .catch(err => {
                        console.error('Error al procesar los datos del backend:', err);
                        FinalizeLoader();
                        reject(err);
                    });
                    
                })
                .catch(err => {
                    console.error('Error en InicializarCampos_Model:', err);
                    FinalizeLoader();
                    reject(err);
                });
            })
            .catch(err => {
                console.error('Error en CargarCamposSelect_Model:', err);
                FinalizeLoader();
                reject(err);
            });
        })
        .catch(err => {
            console.error('Error en ValidarCamposFormularioHTML:', err);
            FinalizeLoader();
            reject(err);
        });
    });
    

}


function LoadData_ToModelCertificadosTec(objLoad, idParamGet1, idParamGet2, idParamGet3) {   
 
    const campoConsecutivo = document.getElementById('txtnumcertificadotec_DecVie_CertificadosTec');
    let selectPrefijo = document.getElementById('cboid_prefijoconsecutivo_DecVie_CertificadosTec');
        
    let urlEditar = urlController + objLoad.ControllerName + '/' + objLoad.MethodGet;

    if (objLoad.ParamGetName1 != '') {
        urlEditar = urlEditar + '?' + objLoad.ParamGetName1 + '=' + idParamGet1;
    }

    if (objLoad.ParamGetName2 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName2 + '=' + idParamGet2;
    }

    if (objLoad.ParamGetName3 != '') {
        urlEditar = urlEditar + '&' + objLoad.ParamGetName3 + '=' + idParamGet3;
    }

    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sCampoValidaDuplicado = '';
    sControlValidaDuplicado = '';
    sSufijoControl = '';
    
    if (ObjModelToLoad.SufijoNombreControl != null) {
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }
    
    StartLoader();    
    
    return new Promise((resolve, reject) => {
        console.log('Iniciando LoadData_ToModelCertificadosTec...');
        console.log('URL de edición:', urlEditar);
    
        // Validación inicial
        ValidarCamposFormularioHTML(true)
        .then(respuesta => { 
            console.log('ValidarCamposFormularioHTML completada:', respuesta);
            if (!respuesta) {
                console.error('Error en ValidarCamposFormularioHTML.');
                FinalizeLoader();
                return reject('Error en ValidarCamposFormularioHTML');
            }
    
            // Cargar datos para los selects
            CargarCamposSelect_Model()
            .then(loaded => { 
                console.log('CargarCamposSelect_Model completada:', loaded);
                if (!loaded) {
                    console.error('Error en CargarCamposSelect_Model.');
                    FinalizeLoader();
                    return reject('Error en CargarCamposSelect_Model');
                }
    
                // Inicializar campos
                InicializarCampos_Model()
                .then(inicializado => {
                    console.log('InicializarCampos_Model completada:', inicializado);
                    fetch(urlEditar, {
                        method: 'GET',
                        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
                    })
                    .then(response => {
                        console.log('Respuesta recibida del fetch:', response);
                        if (!response.ok) {
                            console.error('Error en la respuesta del fetch:', response.statusText);
                            FinalizeLoader();
                            return reject('Error en el fetch.');
                        }
                        return response.json();
                    })
                    .then(data => {
                        console.log('Datos del backend:', data);
                        if (data.Ok) {
                            const datos = data.Data;
                    
                            // Llama a la función para asignar valores al formulario
                            AsignarValoresFormulario(datos);
                    
                            // Finalizamos la carga
                            FinalizeLoader();
                            resolve(true);
                        } else {
                            console.error('Los datos del backend contienen errores:', data.Message);
                            ShowModalDialog(data.Message, false, 'warning', '', 0);
                            FinalizeLoader();
                            resolve(false);                                  
                        }                
                    })
                    .catch(err => {
                        console.error('Error al procesar los datos del backend:', err);
                        FinalizeLoader();
                        reject(err);
                    });
                    
                })
                .catch(err => {
                    console.error('Error en InicializarCampos_Model:', err);
                    FinalizeLoader();
                    reject(err);
                });
            })
            .catch(err => {
                console.error('Error en CargarCamposSelect_Model:', err);
                FinalizeLoader();
                reject(err);
            });
        })
        .catch(err => {
            console.error('Error en ValidarCamposFormularioHTML:', err);
            FinalizeLoader();
            reject(err);
        });
    });
}




//Valida que el fomrulario HTML tenga los controles necesarios
function ValidarCamposFormularioHTML(esEdicion) {
    return new Promise( (resolve, reject) => {
        let nombrecontrol = '';
        objArrCamposModel.forEach(element => {
            switch (element.tipo) {
                case 'int':
                    nombrecontrol = 'nm';
                    break;
                case 'select':
                    nombrecontrol = 'cbo';
                    break;
                case 'string':
                    nombrecontrol = 'txt';
                    break;
                case 'bool':
                    nombrecontrol = 'chk';
                    break;
                case 'date':
                case 'datetime': // Aquí añadimos soporte para 'datetime'
                    nombrecontrol = 'dt';
                    break;
                case 'email':
                    nombrecontrol = 'txt';
                    break;
                case 'time':
                    nombrecontrol = 'tm';
                    break;
                case 'num':
                    nombrecontrol = 'nf';
                    break;
                default:
                    nombrecontrol = '';
            }

            nombrecontrol = nombrecontrol + element.campo + '_' + sNombreModelo + sSufijoControl; 
                
            if (nombrecontrol != '') {
                let htmlcontrol = document.getElementById(nombrecontrol);

                if (htmlcontrol === null) {
                    reject ('El control ' + nombrecontrol + ' no se encuentra definido en HTML');
                }
            }
            else {
                reject ('No existe definición para el tipo de campo ' + element.tipo);
            }

            if (element.allowduplicate != null) {
                if (esEdicion) {
                    if (!element.allowduplicate) {
                        sCampoValidaDuplicado = ''; // element.campo;
                        sControlValidaDuplicado = ''; // nombrecontrol;
                        $('#' + nombrecontrol).prop( "disabled", true );
                    }
                }
                else {
                    sCampoValidaDuplicado = element.campo;
                    sControlValidaDuplicado = nombrecontrol;
                    $('#' + nombrecontrol).prop( "disabled", false );
                }
            }

            if (element.noupdate != null) {
                if (element.noupdate) {
                    $('#' + nombrecontrol).prop( "disabled", true );
                }
            }
    
        });

        resolve (true);
    });

}

function CargarCamposSelect_Model() {
    let promises_load = [];
    let datosCargados = {};  // Objeto para almacenar los datos cargados de cada select

    return new Promise((resolve, reject) => {
        objArrCamposModel.forEach(element => {
            if (element.tipo == 'select') {
                const nombrecontrol = 'cbo' + element.campo + '_' + sNombreModelo + sSufijoControl;

                if ($('#' + nombrecontrol).data('select2')) {
                    $('#' + nombrecontrol).select2('destroy');
                }

                if (typeof element.funcloadselect === 'function') {
                    promises_load.push(element.funcloadselect(nombrecontrol, element.loadnulo)
                        .then(datosCargadosSelect => {
                            datosCargados[nombrecontrol] = datosCargadosSelect;  // Agrega información al objeto
                            return true;
                        })
                        .catch(err => {
                            datosCargados[nombrecontrol] = false;  // Agrega información al objeto indicando un fallo
                            return false;
                        }));
                } else {
                    datosCargados[nombrecontrol] = false;  // Agrega información al objeto indicando un fallo
                    promises_load.push(Promise.resolve(false));
                }
            }
        });

        Promise.all(promises_load)
            .then(resultados => {
                const todosCargadosCorrectamente = resultados.every(resultado => resultado === true);

                if (todosCargadosCorrectamente) {
                    resolve(true);
                } else {
                    console.error('Al menos uno de los campos de selección no se cargó correctamente.');
                    resolve(false);
                }
            })
            .catch(err => {
                ShowModalDialog(err, false, 'error', '', 0);
                reject(err);
            });
    });
}




function InicializarCampos_Model() {
    debugger
    return new Promise( (resolve, reject) => {
        let nombrecontrol = '';
        objArrCamposModel.forEach(element => {     
            if (element.llave == '') {
                switch (element.tipo) {
                    case 'int':
                        nombrecontrol = 'nm' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).val('0');
                        break;
                    case 'num':
                        nombrecontrol = 'nf' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).val('');
                        break;
                    case 'select':                        
                        nombrecontrol = 'cbo' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).select2().val('').trigger("change");

                        if (ObjModelToLoad.IsModal) {
                            $('#' + nombrecontrol).select2({        
                                dropdownParent: $('#' + ObjModelToLoad.FormEdicion),
                                placeholder: "Seleccione",        
                                width: 'resolve'
                            });    
                        }
                        else {
                            $('#' + nombrecontrol).select2();
                        }

                        break;
                    case 'string':
                        nombrecontrol = 'txt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).val('');
                        break;
                    case 'bool':
                        nombrecontrol = 'chk' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).prop('checked', false);
                        break;
                    case 'date':
                        nombrecontrol = 'dt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).val('');

                        if (!element.nullable) {
                            $('#' + nombrecontrol).val(getFechaActual());
                        }
                        break;
                    case 'email':
                        nombrecontrol = 'txt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).val('');
                        break;
                    case 'time':
                        nombrecontrol = 'tm' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).val('');
                        break;
                }
            }

        });

        resolve (true);
    });
      
}


function SetCamposFormulario() {
    objArrCamposModel.forEach(element => {
        switch (element.tipo) {
            case 'int':
                setControlNumberFormulario(element.campo);                
                break;
            case 'select':
                setControlSelectFormulario(element.campo);                
                break;
            case 'string':
                setControlTextFormulario(element.campo);                
                break;
            case 'bool':
                setControlBoolFormulario(element.campo);                
                break;
            case 'date':
                setControlDateFormulario(element.campo);                
                break;
            case 'email':
                setControlTextFormulario(element.campo);                
                break;
            case 'time':
                setControlHoraFormulario(element.campo);                
                break;
            case 'num':
                setControlFormatoNumero(element.campo);                
                break;
        }

    });

}

function setControlSpanFormulario(sCampo) {
    let nombrecontrol = 'spanid' + sCampo + '_' + sNombreModelo + sSufijoControl;
    $('#' + nombrecontrol)[0].innerText = objDatosModel[sCampo];
}

function setControlSelectFormulario(sCampo) {
        let nombrecontrol = 'cbo' + sCampo + '_' + sNombreModelo + sSufijoControl;

        if (objDatosModel[sCampo] != null) {
            $('#' + nombrecontrol).select2().val(objDatosModel[sCampo]).trigger("change");
        }

        if (ObjModelToLoad.IsModal) {
            $('#' + nombrecontrol).select2({        
                dropdownParent: $('#' + ObjModelToLoad.FormEdicion),
                placeholder: "Seleccione",        
                width: 'resolve'
            });    
        }
        else {
            $('#' + nombrecontrol).select2();
        }

}

function setControlNumberFormulario(sCampo) {
        let nombrecontrol = 'nm' + sCampo + '_' + sNombreModelo + sSufijoControl;

        $('#' + nombrecontrol).val('0');

        if (objDatosModel[sCampo] != null) {
            $('#' + nombrecontrol).val(objDatosModel[sCampo]);
        }        
}

function setControlTextFormulario(sCampo) {    
        let nombrecontrol = 'txt' + sCampo + '_' + sNombreModelo + sSufijoControl;

        $('#' + nombrecontrol).val(objDatosModel[sCampo]);
        
}

function setControlBoolFormulario(sCampo) {
        let nombrecontrol = 'chk' + sCampo + '_' + sNombreModelo + sSufijoControl;

        if (objDatosModel[sCampo] != null)
        $('#' + nombrecontrol).prop('checked', objDatosModel[sCampo]);        
}

function setControlDateFormulario(sCampo) {
        let nombrecontrol = 'dt' + sCampo + '_' + sNombreModelo + sSufijoControl;

        if (objDatosModel[sCampo] != null) {
            $('#' + nombrecontrol).val(objDatosModel[sCampo].slice(0,10));
        }        
}

function setControlHoraFormulario(sCampo) {
    let nombrecontrol = 'tm' + sCampo + '_' + sNombreModelo + sSufijoControl;

    if (objDatosModel[sCampo] != null) {
        $('#' + nombrecontrol).val(objDatosModel[sCampo].slice(0,10));
    }        
}

function setControlFormatoNumero(sCampo) {
    let nombrecontrol = 'nf' + sCampo + '_' + sNombreModelo + sSufijoControl;    
    //console.log(objDatosModel[sCampo]);
    //$('#' + nombrecontrol).val(objDatosModel[sCampo]);
    $('#' + nombrecontrol).val(formatNumber(String(objDatosModel[sCampo])));

        //CAmbio Fredys
     if (objDatosModel[sCampo] != null) {
        $('#' + nombrecontrol).val(objDatosModel[sCampo]);
    }      
}

function DestruirCamposSelect_Model(objLoad) {
        objArrCamposModel = objLoad.Campos;
        sNombreModelo = objLoad.Nombre;
        ObjModelToLoad = objLoad;
        sSufijoControl = '';

        if (ObjModelToLoad.SufijoNombreControl != null){
            sSufijoControl = ObjModelToLoad.SufijoNombreControl;
        }        

        return new Promise( (resolve, reject) => {
            let nombrecontrol = '';
            objArrCamposModel.forEach(element => { 
                if (element.tipo == 'select') {
                    nombrecontrol = 'cbo' + element.campo + '_' + sNombreModelo + sSufijoControl;

                    if ($('#' + nombrecontrol).data('select2')) {
                        $('#' + nombrecontrol).select2('destroy');
                    }
                }

            });

            resolve (true);
        });
    
}

// function ValidatePostUpdateModel_EdicionForm(objLoad) {
//         objArrCamposModel = objLoad.Campos;
//         sNombreModelo = objLoad.Nombre;
//         ObjModelToLoad = objLoad;
//         sSufijoControl = '';

//         if (ObjModelToLoad.SufijoNombreControl != null){
//             sSufijoControl = ObjModelToLoad.SufijoNombreControl;
//         }    

//         return new Promise( (resolve, reject) => {
//             let formF = ObjModelToLoad.FormEdicion;

//             validateTextXSSLastButtonByForm(formF);
        
//             var formV = $("#" + formF);
//             if (formV[0].checkValidity() == false) {
//                 $(formV).addClass('was-validated');
//             } else {
//                 if (checkValidityXSS == false) {
//                     $(formV).addClass('was-validated');
//                 } else {
//                     if (checkValiditySelect == false) {
//                         $(formV).addClass('was-validated');
//                     } else {
//                         ExisteValorDuplicadoModel()
//                         .then(existe => {
//                             if (!existe) {                                    
//                                 AddUpdateDatabase_Model()
//                                 .then(guardado => { resolve (guardado)})
//                                 .catch(err => { reject (err)})
//                             }
//                         })
//                         .catch(err => { reject (err)}) 


//                     }
//                 }
//             }    
        
//         });

// }

function AddUpdateDatabase_Model() {

    return new Promise( (resolve, reject) => {
        let objData = new Object();

        let urlUpdate = urlController + ObjModelToLoad.ControllerName + '/' + ObjModelToLoad.MethodUpdate;    
        StartLoader();   

        let nombrecontrol = '';
        objArrCamposModel.forEach(element => {
            
            if (element.noupdate == null) {
                switch (element.tipo) {
                    case 'int':
                        nombrecontrol = 'nm' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).val();
                        break;
                    case 'num':                        
                    
                        nombrecontrol = 'nf' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).val();
                        let valorCampo = $('#' + nombrecontrol).val();
                        let nmr = valorCampo.replace(/,/g, ""); 
                        let valorCampoToInt = parseInt(nmr);
                        objData[element.campo] = valorCampoToInt;

                        debugger
                        break;
                    case 'select':
                        nombrecontrol = 'cbo' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).val();
                        break;
                    case 'string':
                        nombrecontrol = 'txt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                    
                        if (element.llave == 'primary') {
                            objData[element.campo] = ($('#' + nombrecontrol).val() == '') ? undefined : $('#' + nombrecontrol).val()
                        }
                        else {
                            objData[element.campo] = $('#' + nombrecontrol).val();
                        }
                        // se realiza un replace para eliminar las comillas dobles ("") de los textos ya que provocaban conflicto con el normal flujo del aplicativo
                        if(objData[element.campo]!= null){

                            let textWithoutSpecialCharacters = objData[element.campo];
                            textWithoutSpecialCharacters = textWithoutSpecialCharacters.replace(/"/g, '');
                            objData[element.campo] = textWithoutSpecialCharacters;
                        }
                        //console.log(objData[element.campo])
                        break;
                    case 'bool':
                        nombrecontrol = 'chk' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).is(':checked');
                        break;
                    case 'date':
                        nombrecontrol = 'dt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).val();
                        break;
                        
                    case 'datetime':
                        nombrecontrol = 'dt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).val();
                        break;

                    case 'email':
                        nombrecontrol = 'txt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).val();
                        break;
                    case 'time':
                        nombrecontrol = 'tm' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        objData[element.campo] = $('#' + nombrecontrol).val();
                        break;
                   
                }    
            }
    
        });   
                
        if (objData[ObjModelToLoad.CampoLlave] == undefined) {
            urlUpdate = urlController + ObjModelToLoad.ControllerName + '/' + ObjModelToLoad.MethodInsert;
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

                resolve (true);
                return;
            }
            else {
                FinalizeLoader();
                reject (data.Message);
            }            
          })
          .catch (err => {
            FinalizeLoader();
            reject (err);
            //ShowModalDialog(err, false, 'error', '', 0);
          } );       
  
    });
    
}


function ExisteValorDuplicadoModel() {    
    return new Promise( (resolve, reject) => {  
        
        if (sCampoValidaDuplicado == '') {
            resolve (false);
        }
        else {
            let ValorValidar = $('#' + sControlValidaDuplicado).val();
            let urlValidar = urlController + ObjModelToLoad.ControllerName + '/' + ObjModelToLoad.MethodValidarDuplicado + '?' + ObjModelToLoad.ParamDuplicadoName + '=' + ValorValidar;
        
            fetch(urlValidar, {
                method: 'GET',
                headers: { 'Authorization': 'Bearer ' + TokenIRIS }
            })
            .then(response => response.json())
              .then(data => {
                if (data.Ok) {
                    let message = "El campo " + sCampoValidaDuplicado + ", no admite duplicados. El valor: " + ValorValidar + " ya está registrado.";
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
        }           
      });
}


function ExisteValorDuplicadoModelConsecutivo() {    
    return new Promise( (resolve, reject) => {  


        
                if (sCampoValidaDuplicado == '') {
                    resolve (false);
                }
                else {
                    let ValorValidar = $('#' + sControlValidaDuplicado).val();
                    let urlValidar = urlController + ObjModelToLoad.ControllerName + '/' + ObjModelToLoad.MethodValidarDuplicado + '?' + ObjModelToLoad.ParamDuplicadoName + '=' + ValorValidar;
                
                    fetch(urlValidar, {
                        method: 'GET',
                        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
                    })
                    .then(response => response.json())
                      .then(data => {
                        if (data.Ok) {
                            let message = "El campo " + sCampoValidaDuplicado + ", no admite duplicados. El valor: " + ValorValidar + " ya está registrado.";
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
                } 
            

       
      });
}




/****** CREAR LOS COMPONENTES HTML A PARTIR DE LA DEIFNICION DE CAMPO DEL MODELO */  
function CreateHTMLFromModel(objLoad) {
    objArrCamposHTMLModelo = objLoad.CamposHTML;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sCampoValidaDuplicado = '';
    sControlValidaDuplicado = '';
    sSufijoControl = '';

    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }
    
    let HTMLparacontrol = '';
    let formularioHTML = '';
    
    StartLoader();    

    return new Promise( (resolve, reject) => {
        if (!ExisteDivEdicionDatos(ObjModelToLoad.FormEdicion)) {
            objArrCamposHTMLModelo.forEach(filaHTML => {
                formularioHTML = formularioHTML + '<div class="form-group row mb-1">';
                filaHTML.forEach(element => {
                    HTMLparacontrol = '';
                    switch (element.tipo) {
                        case 'int':
                            HTMLparacontrol = CrearControlParaNumeros(element);
                            break;
                        case 'select':
                            HTMLparacontrol = CrearControlParaSelect(element);
                            break;
                        case 'string':
                            HTMLparacontrol = CrearControlParaText(element);                    
                            break;
                        case 'textarea':
                            HTMLparacontrol = CrearControlParaTextArea(element);
                            break;    
                        case 'bool':
                            HTMLparacontrol = CrearControlParaTextBoolean(element);
                            break;
                        case 'date':
                            HTMLparacontrol = CrearControlParaTextFecha(element);
                            break;
                        case 'email':
                            HTMLparacontrol = CrearControlParaCorreo(element);                            
                            break;
                        case 'time':
                            HTMLparacontrol = CrearControlParaHora(element);                            
                            break;
                        case 'num':
                            HTMLparacontrol = CrearControlParaFormatoNumero(element);                    
                            break;
                            
                    }
        
                    formularioHTML = formularioHTML + HTMLparacontrol;
                });
                formularioHTML = formularioHTML + '</div>';
            });
            
            $('#' + ObjModelToLoad.FormEdicion).html(formularioHTML);
        }

        resolve(true)
    });

} 

function SetColumnasControl(definicioncontrol) {
    let clasecolumnas = 'col-md-2';

    if (definicioncontrol.numcols != null) {
        clasecolumnas = 'col-md-' + definicioncontrol.numcols;
    }

    return clasecolumnas;
}

function CrearControlParaNumeros(elementHTML) {
    let identControlHTML = 'nm' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;    
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let dataspanControlHTML = 'span' + identControlHTML;
    let minControlHTML = (elementHTML.minimo == null) ? '0' : elementHTML.minimo;
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';
    let funcioncambiar = (elementHTML.funconchange == null) ? '' : '" onchange="' + elementHTML.funconchange;

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';

    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';

    //CREA EL CONTROL NUMBER
    textoHTMLControl = textoHTMLControl + '<input type="number" class="form-control iris iris-number" id="' + identControlHTML + funcioncambiar +
                                          '" title="' + titleControlHTML + '" min="' + minControlHTML + '" data-span="span' + dataspanControlHTML + '" ' + requiredControlHTML + '/>';

                                          //INCLUYE SI ES UN CAMPO REQUERIDO
    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';                                        

    //INCLUYE SPAN VALIDACION DE DE ENTRADA DE DATOS
    textoHTMLControl = textoHTMLControl + '<div id="' + dataspanControlHTML + '" class="color-required ocultar">No se acepta el ingreso de caracteres especiales o palabras restringidas</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

}

function CrearControlParaSelect(elementHTML) {
    let identControlHTML = 'cbo' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';
    let funcioncambiar = (elementHTML.funconchange == null) ? '' : '" onchange="' + elementHTML.funconchange;

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';

    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<div class="col-md-12">';
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';
    textoHTMLControl = textoHTMLControl + '</div>';

    //CREA EL CONTROL SELECT
    textoHTMLControl = textoHTMLControl + '<div class="col-md-12 font-size-iris">';
    textoHTMLControl = textoHTMLControl + '<select class="form-combo iris input-sm w-100 font-size-iris" style="width: 100%;" id="' + identControlHTML + funcioncambiar +
                                        '" title="' + titleControlHTML + '" ' + requiredControlHTML + '></select>';

    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';
    textoHTMLControl = textoHTMLControl + '</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

/*    
    <div class="col-md-2">
        <div class="col-md-12">
            <label class="form-label-iris">Corrector</label>
        </div>
        <div class="col-md-12 font-size-iris">
            <select class="form-combo iris input-sm w-100 font-size-iris" style="width: 100%;" id="cboid_persona_Publicaciones_TipoCorreccion" required></select>    
            <div class="invalid-feedback">
                Corrector es un campo obligatorio
            </div>
        </div>
    </div>    
*/

}

function CrearControlParaText(elementHTML) {
    let identControlHTML = 'txt' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;
    let maxlenghtControlHTML = (elementHTML.maxlength == null) ? '' : elementHTML.maxlength;
    let placeholderControlHTML = (elementHTML.placeholder == null) ? '' : elementHTML.placeholder;
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let dataspanControlHTML = 'span' + identControlHTML;    
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';

    if (elementHTML.llave != '') {
        let textoHTMLControl = '<input type="text" class="ocultar" id="' + identControlHTML + '"/>';
        return textoHTMLControl;
    }
    
    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';

    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';

    //CREA EL CONTROL TEXT
    textoHTMLControl = textoHTMLControl + '<input type="text" class="form-control iris" id="' + identControlHTML + '" maxlength="' + maxlenghtControlHTML +
                                        '" placeholder="' + placeholderControlHTML + '" title="' + titleControlHTML + '" data-span="span' + dataspanControlHTML + '" ' + requiredControlHTML + '/>';

    //INCLUYE SI ES UN CAMPO REQUERIDO
    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';                                        

    //INCLUYE SPAN VALIDACION DE DE ENTRADA DE DATOS
    textoHTMLControl = textoHTMLControl + '<div id="' + dataspanControlHTML + '" class="color-required ocultar">No se acepta el ingreso de caracteres especiales o palabras restringidas</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

/*    
    <div class="col-md-2">
        <label class="form-label-iris" for="txtcontratocorreccion_Publicaciones_TipoCorreccion">No. Contrato</label>
        <input type="text" class="form-control iris" id="txtcontratocorreccion_Publicaciones_TipoCorreccion" maxlength="50" placeholder="Contrato" data-span="spantxtcontratocorreccion_Publicaciones_TipoCorreccion" required/>
        <div class="invalid-feedback">
            No. Contrato es un campo obligatorio
        </div>
        <div id="spantxtcontratocorreccion_Publicaciones_TipoCorreccion" class="color-required ocultar">
            No se acepta el ingreso de caracteres especiales o palabras restringidas
        </div>
    </div>
*/

}

function CrearControlParaTextArea(elementHTML) {
    let identControlHTML = 'txt' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;
    let maxlenghtControlHTML = (elementHTML.maxlength == null) ? '' : elementHTML.maxlength;
    let placeholderControlHTML = (elementHTML.placeholder == null) ? '' : elementHTML.placeholder;
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let dataspanControlHTML = 'span' + identControlHTML;
    let rowsControlHTML = (elementHTML.numrows == null) ? 2 : elementHTML.numrows;
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';

    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';

    //CREA EL CONTROL TEXTAREA
    textoHTMLControl = textoHTMLControl + '<textarea class="form-control iris" id="' + identControlHTML + '" maxlength="' + maxlenghtControlHTML + '" rows="' + rowsControlHTML +
                                        '" placeholder="' + placeholderControlHTML + '" title="' + titleControlHTML + '" data-span="span' + dataspanControlHTML + '" ' + requiredControlHTML + '></textarea>';

    //INCLUYE SI ES UN CAMPO REQUERIDO
    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';                                        

    //INCLUYE SPAN VALIDACION DE DE ENTRADA DE DATOS
    textoHTMLControl = textoHTMLControl + '<div id="' + dataspanControlHTML + '" class="color-required ocultar">No se acepta el ingreso de caracteres especiales o palabras restringidas</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

/*
    <div class="col-md-6">
        <label class="form-label-iris" for="txtPublicacionEvaluacionObservaciones">Observaciones Evaluación</label>
        <textarea class="form-control iris" id="txtPublicacionEvaluacionObservaciones" maxlength="1500" rows="4" placeholder="Comentarios" data-span="spantxtPublicacionEvaluacionObservaciones" required ></textarea>
        <div class="invalid-feedback">
            Observaciones Evaluación es un campo obligatorio
        </div>
        <div id="spantxtPublicacionEvaluacionObservaciones" class="color-required ocultar">
            No se acepta el ingreso de caracteres especiales o palabras restringidas
        </div>
    </div>
*/

}


function CrearControlParaTextBoolean(elementHTML) {
    let identControlHTML = 'chk' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + ' d-flex justify-content-center align-items-center">';

    //CREA LA ETIQUETA y CHECKBOX
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + 
                                        '<input type="checkbox" class="form-check-input iris-check" id="' + identControlHTML + '"/>' + elementHTML.etiqueta + '</label>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

/*
    <div class="col-md-2 d-flex justify-content-center align-items-center">
        <label class="form-label-iris" for="chkreqindices_Publicaciones_TipoCorreccion"><input type="checkbox" class="form-check-input iris-check" id="chkreqindices_Publicaciones_TipoCorreccion"/>Requiere Indices</label>
    </div>
*/
}


function CrearControlParaTextFecha(elementHTML) {
    let identControlHTML = 'dt' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;
    let maxlenghtControlHTML = (elementHTML.maxlength == null) ? '' : elementHTML.maxlength;
    let placeholderControlHTML = (elementHTML.placeholder == null) ? '' : elementHTML.placeholder;
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let dataspanControlHTML = 'span' + identControlHTML;    
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';

    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';

    //CREA EL CONTROL TEXT
    textoHTMLControl = textoHTMLControl + '<input type="date" class="form-control iris" id="' + identControlHTML + 
                                        '" title="' + titleControlHTML + '" data-span="span' + dataspanControlHTML + '" ' + requiredControlHTML + '/>';

    //INCLUYE SI ES UN CAMPO REQUERIDO
    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';                                        

    //INCLUYE SPAN VALIDACION DE DE ENTRADA DE DATOS
    textoHTMLControl = textoHTMLControl + '<div id="' + dataspanControlHTML + '" class="color-required ocultar">No se acepta el ingreso de caracteres especiales o palabras restringidas</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

/*    
    <div class="col-md-2">
        <label class="form-label-iris" for="dtfechaorpa2_Publicaciones_TipoCorreccion">Fecha ORPA02</label>                                
        <input type="date" class="form-control iris" id="dtfechaorpa2_Publicaciones_TipoCorreccion" title="Fecha Registro Manuscrito" data-span="spandtfechaorpa2_Publicaciones_TipoCorreccion" />
        <div class="invalid-feedback">
            Fecha ORPA02 es un campo obligatorio
        </div>
        <div id="spandtfechaorpa2_Publicaciones_TipoCorreccion" class="color-required ocultar">
        No se acepta el ingreso de caracteres especiales
        </div>       
    </div>        
*/

}

function CrearControlParaCorreo(elementHTML) {
    let identControlHTML = 'txt' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;
    let maxlenghtControlHTML = (elementHTML.maxlength == null) ? '' : elementHTML.maxlength;
    let placeholderControlHTML = (elementHTML.placeholder == null) ? '' : elementHTML.placeholder;
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let dataspanControlHTML = 'span' + identControlHTML;    
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';

    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';

    //CREA EL CONTROL TEXT
    textoHTMLControl = textoHTMLControl + '<input type="email" class="form-control iris" id="' + identControlHTML + '" maxlength="' + maxlenghtControlHTML +
                                        '" placeholder="' + placeholderControlHTML + '" title="' + titleControlHTML + '" data-span="span' + dataspanControlHTML + '" ' + requiredControlHTML + '/>';

    //INCLUYE SI ES UN CAMPO REQUERIDO
    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';                                        

    //INCLUYE SPAN VALIDACION DE DE ENTRADA DE DATOS
    textoHTMLControl = textoHTMLControl + '<div id="' + dataspanControlHTML + '" class="color-required ocultar">No se acepta el ingreso de caracteres especiales o palabras restringidas</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

}

function CrearControlParaHora(elementHTML) {
    let identControlHTML = 'tm' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;
    let maxlenghtControlHTML = (elementHTML.maxlength == null) ? '' : elementHTML.maxlength;
    let placeholderControlHTML = (elementHTML.placeholder == null) ? '' : elementHTML.placeholder;
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let dataspanControlHTML = 'span' + identControlHTML;    
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';

    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';

    //CREA EL CONTROL TEXT
    textoHTMLControl = textoHTMLControl + '<input type="time" class="form-control iris" id="' + identControlHTML + 
                                        '" title="' + titleControlHTML + '" data-span="span' + dataspanControlHTML + '" ' + requiredControlHTML + '/>';

    //INCLUYE SI ES UN CAMPO REQUERIDO
    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';                                        

    //INCLUYE SPAN VALIDACION DE DE ENTRADA DE DATOS
    textoHTMLControl = textoHTMLControl + '<div id="' + dataspanControlHTML + '" class="color-required ocultar">No se acepta el ingreso de caracteres especiales o palabras restringidas</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;    
}

function CrearControlParaFormatoNumero(elementHTML) {
    debugger;
    let identControlHTML = 'nf' + elementHTML.campo + '_' + sNombreModelo + sSufijoControl;
    let maxlenghtControlHTML = (elementHTML.maxlength == null) ? '' : elementHTML.maxlength;    
    let titleControlHTML = (elementHTML.title == null) ? '' : elementHTML.title;
    let dataspanControlHTML = 'span' + identControlHTML;
    let minControlHTML = (elementHTML.minimo == null) ? '0' : elementHTML.minimo;
    let requiredControlHTML = (elementHTML.nullable == true) ? '' : ' required';
    let etiquetaRequiredControlHTML = (elementHTML.nullable == true) ? '' : ' *';
    let funcioncambiar = (elementHTML.funconchange == null) ? '' : '" onchange="' + elementHTML.funconchange;    
    //pattern="^\\$\\d{1,3}(,\\d{3})*(\\.\\d+)?$"

    //INICIALIZA EL DIV
    let textoHTMLControl = '<div class="' + SetColumnasControl(elementHTML) + '">';
    
    //CREA LA ETIQUETA
    textoHTMLControl = textoHTMLControl + '<label class="form-label-iris" for="' + identControlHTML + '">' + elementHTML.etiqueta + etiquetaRequiredControlHTML + '</label>';

    //CREA EL CONTROL NUMBER
    textoHTMLControl = textoHTMLControl + '<input type="text" class="form-control iris iris-number" onblur="formatCurrency($(this), \'blur\');" onkeyup="formatCurrency($(this));" data-type="currency"  id="' + identControlHTML + funcioncambiar +
                                          '" title="' + titleControlHTML + '" min="' + minControlHTML + '" data-span="span' + dataspanControlHTML + '" ' + requiredControlHTML + '/>';

                                          //INCLUYE SI ES UN CAMPO REQUERIDO
    textoHTMLControl = textoHTMLControl + '<div class="invalid-feedback">' + elementHTML.etiqueta + ' es un campo obligatorio </div>';                                        

    //INCLUYE SPAN VALIDACION DE DE ENTRADA DE DATOS
    textoHTMLControl = textoHTMLControl + '<div id="' + dataspanControlHTML + '" class="color-required ocultar">No se acepta el ingreso de caracteres especiales o palabras restringidas</div>';

    //CIERRA EL DIV
    textoHTMLControl = textoHTMLControl + '</div>';

    return textoHTMLControl;

}

function ValidatePostUpdateModel_EdicionForm_Data2(objLoad) {
    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sSufijoControl = '';

    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }    

    return new Promise( (resolve, reject) => {
        let formF = ObjModelToLoad.FormEdicion;

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
                    ExisteValorDuplicadoModelConsecutivo()
                    .then(existe => {
                        if (!existe) {    
                            const fecha = document.getElementById('dtfecha_DecVie_RadicadorTec').value;
                            console.log("Fecha capturada antes de enviar:", fecha);                                
                            AddUpdateDatabase_Model_Data()
                            .then(datasaved => { resolve (datasaved)})
                            .catch(err => { reject (err)})
                        }
                    })
                    .catch(err => { reject (err)}) 


                }
            }
        }    
    
    });

}

function ValidatePostUpdateModel_EdicionForm_Data(objLoad) {
    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sSufijoControl = '';

    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }    

    return new Promise( (resolve, reject) => {
        let formF = ObjModelToLoad.FormEdicion;

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
                    ExisteValorDuplicadoModelConsecutivo()
                    .then(existe => {
                        if (!existe) {                                    
                            AddUpdateDatabase_Model_Data()
                            .then(datasaved => { resolve (datasaved)})
                            .catch(err => { reject (err)})
                        }
                    })
                    .catch(err => { reject (err)}) 


                }
            }
        }    
    
    });

}

function ValidatePostUpdateModel_EdicionForm(objLoad) {
    objArrCamposModel = objLoad.Campos;
    sNombreModelo = objLoad.Nombre;
    ObjModelToLoad = objLoad;
    sSufijoControl = '';

    if (ObjModelToLoad.SufijoNombreControl != null){
        sSufijoControl = ObjModelToLoad.SufijoNombreControl;
    }    

    return new Promise( (resolve, reject) => {
        let formF = ObjModelToLoad.FormEdicion;

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
                    ExisteValorDuplicadoModel()
                    .then(existe => {
                        if (!existe) {                                    
                            AddUpdateDatabase_Model()
                            .then(guardado => { resolve (guardado)})
                            .catch(err => { reject (err)})
                        }
                    })
                    .catch(err => { reject (err)}) 


                }
            }
        }    
    
    });

}



function AddUpdateDatabase_Model_Data() {
    return new Promise( (resolve, reject) => {
        let objData = new Object();

        let urlUpdate = urlController + ObjModelToLoad.ControllerName + '/' + ObjModelToLoad.MethodUpdate;    
        StartLoader();   

        let nombrecontrol = '';
        objArrCamposModel.forEach(element => {
            switch (element.tipo) {
                case 'int':
                    nombrecontrol = 'nm' + element.campo + '_' + sNombreModelo + sSufijoControl;
                    objData[element.campo] = $('#' + nombrecontrol).val();
                    break;
                case 'num':
                    nombrecontrol = 'nf' + element.campo + '_' + sNombreModelo + sSufijoControl;
    
                    if (element.llave == 'primary') {
                        objData[element.campo] = ($('#' + nombrecontrol).val() == '') ? undefined : $('#' + nombrecontrol).val()
                    }
                    else {
                        objData[element.campo] = $('#' + nombrecontrol).val();
                    }
                    
                    break;
                case 'select':
                    nombrecontrol = 'cbo' + element.campo + '_' + sNombreModelo + sSufijoControl;
                    objData[element.campo] = $('#' + nombrecontrol).val();
                    break;
                case 'string':
                    nombrecontrol = 'txt' + element.campo + '_' + sNombreModelo + sSufijoControl;
    
                    if (element.llave == 'primary') {
                        objData[element.campo] = ($('#' + nombrecontrol).val() == '') ? undefined : $('#' + nombrecontrol).val()
                    }
                    else {
                        objData[element.campo] = $('#' + nombrecontrol).val();
                    }
                    
                    break;
                case 'bool':
                    nombrecontrol = 'chk' + element.campo + '_' + sNombreModelo + sSufijoControl;
                    objData[element.campo] = $('#' + nombrecontrol).is(':checked');
                    break;

                    // case 'date':
                    // nombrecontrol = 'dt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                    // objData[element.campo] = $('#' + nombrecontrol).val();
                    // break;
                case 'date':
                        nombrecontrol = 'dt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        const valorFechaCompleto = $('#' + nombrecontrol).val();
                    
                        if (!valorFechaCompleto) {
                            console.warn(`El campo de fecha "${element.campo}" está vacío. Se enviará como null.`);
                            objData[element.campo] = null; // Opcional: Decide si enviar `null` o un valor predeterminado
                        } else {
                            // Validar si incluye hora (longitud esperada es 16 para YYYY-MM-DDTHH:mm)
                            if (valorFechaCompleto.length < 16) {
                                console.warn(`El campo de fecha "${element.campo}" no incluye la hora. Asegúrate de que sea datetime-local.`);
                            }
                            objData[element.campo] = valorFechaCompleto; // Enviar el valor completo
                        }
                    
                        console.log(`Campo "${element.campo}" procesado como fecha:`, objData[element.campo]);
                    break;
                
                    case 'datetime':
                        nombrecontrol = 'dt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        const valorFechaHora = $('#' + nombrecontrol).val();
                    
                        if (!valorFechaHora) {
                            console.warn(`El campo "${element.campo}" de tipo datetime está vacío.`);
                            objData[element.campo] = null;
                        } else {
                            console.log(`Campo "${element.campo}" capturado como datetime:`, valorFechaHora);
                            objData[element.campo] = valorFechaHora;
                        }
                        break;
                           
                    
                case 'email':
                    nombrecontrol = 'txt' + element.campo + '_' + sNombreModelo + sSufijoControl;
                    objData[element.campo] = $('#' + nombrecontrol).val();
                    break;
                case 'time':
                    nombrecontrol = 'tm' + element.campo + '_' + sNombreModelo + sSufijoControl;
                    objData[element.campo] = $('#' + nombrecontrol).val();
                    break;
                
            }
    
        });   
                
        if (objData[ObjModelToLoad.CampoLlave] == undefined) {
            urlUpdate = urlController + ObjModelToLoad.ControllerName + '/' + ObjModelToLoad.MethodInsert;
        }
        console.log(urlUpdate)
        fetch(urlUpdate, {
            method: 'POST',
            body: JSON.stringify(objData),
            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
        })
        .then(response => response.json())
          .then(data => {
            console.log(data)
            if (data.Ok) {           
                FinalizeLoader();

                resolve (data);
                return;
            }
            else {
                FinalizeLoader();
                reject (data.Message);
            }            
          })
          .catch (err => {
            FinalizeLoader();
            reject (err);
            //ShowModalDialog(err, false, 'error', '', 0);
          } );       
  
    });
    
}

/*
$("input[data-type='currency']").on({
    keyup: function() {
        alert("key up llamado?");
        formatCurrency($(this));
      },
    blur: function() { 
    alert("blur up llamado?");
      formatCurrency($(this), " ;
    }
}); */

function formatNumber(n) {
    // format number 1000000 to 1,234,567
    return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    
  }

function  formatCurrency(input, blur) {
    debugger;
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.
    
    // get input value
    var input_val = input[0].value;
    
    // don't validate empty input
    if (input_val === "") { return; }
    
    // original length
    var original_len = input_val.length;
  
    // initial caret position 
    var caret_pos = input.prop("selectionStart");
      
    // check for decimal
    if (input_val.indexOf(".") >= 0) {
  
      // get position of first decimal
      // this prevents multiple decimals from
      // being entered
      var decimal_pos = input_val.indexOf(".");
  
      // split number by decimal point
      var left_side = input_val.substring(0, decimal_pos);
      var right_side = input_val.substring(decimal_pos);
  
      // add commas to left side of number
      left_side = formatNumber(left_side);
  
      // validate right side
      right_side = formatNumber(right_side);
      
      // On blur make sure 2 numbers after decimal
      if (blur === "blur") {
        right_side += "00";
      }
      
      // Limit decimal to only 2 digits
      right_side = right_side.substring(0, 2);
  
      // join number by .
      input_val = "$" + left_side /*+ "." + right_side*/;
  
    } else {
      // no decimal entered
      // add commas to number
      // remove all non-digits
      input_val = formatNumber(input_val);
      input_val = /*"$" +*/ input_val;
      
      // final formatting
      if (blur === "blur") {
        input_val /*+= ".00"*/;
      }
    }
    
    // send updated string to input
    input.val(input_val);
  
    // put caret back in the right position
    var updated_len = input_val.length;
    caret_pos = updated_len - original_len + caret_pos;
    input[0].setSelectionRange(caret_pos, caret_pos);
  }

