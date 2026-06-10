var objDatosModelo = null;
var objArrCamposModel = null;
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
                                              console.log(datos);
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
                    nombrecontrol = 'dt';
                    break;
                case 'email':
                    nombrecontrol = 'txt';
                    break;
                case 'time':
                    nombrecontrol = 'tm';
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

    return new Promise( (resolve, reject) => {
        let nombrecontrol = '';
        objArrCamposModel.forEach(element => { 
            if (element.tipo == 'select') {                

                nombrecontrol = 'cbo' + element.campo + '_' + sNombreModelo + sSufijoControl;

                if ($('#' + nombrecontrol).data('select2')) {
                    $('#' + nombrecontrol).select2('destroy');
                }

                if (element.funcloadselect != '') {
                    promises_load.push(element.funcloadselect(nombrecontrol, element.loadnulo));
                    /*
                    .then(datoscargados => {
                        if (datoscargados) {
                            resolve(true);
                        }
                        else {
                            resolve(false);
                        }
                    })
                    .catch (err => { reject (err)}))*/
                }
            }

        });

        Promise.all(promises_load)
        .then(selectcargado => {
            if (selectcargado) {
                resolve (true);
            }
            else {
                resolve(false);
            }
        })
        .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0); 
            reject(err); 
        });
    });
}

function InicializarCampos_Model() {
    
    return new Promise( (resolve, reject) => {
        let nombrecontrol = '';
        objArrCamposModel.forEach(element => {     
            if (element.llave == '') {
                switch (element.tipo) {
                    case 'int':
                        nombrecontrol = 'nm' + element.campo + '_' + sNombreModelo + sSufijoControl;
                        $('#' + nombrecontrol).val('0');
                        break;
                    case 'select':     
                    debugger;                   
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
                    case 'date':
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
                    ExisteValorDuplicadoModel()
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
                case 'date':
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
