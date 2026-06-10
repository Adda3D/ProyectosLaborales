$(document).ready(function () {

    if ($("#spanIdPublicacion")[0].innerText == '') {
        CrearPublicacionform();
    }
    else {
        EditarPublicacionform($("#spanIdPublicacion")[0].innerText);
    }

});

function VolverTablaPublicacionesDesdeEdicion() {
    DestruyeSelectPublicacion();

    $("#dvPublicacionDetalle").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function CrearPublicacionform() {
    $("#spanIdPublicacionForm")[0].innerText = '';
    
    CargarCombosDetallePublicacion();

    InicializaCamposDetallePublicacion();

    AddSelect2DivDetallePublicacion();
    removeValidationFormByForm('formPublicacionDetalle');

    $("#txtidkardexPublicacion").prop( "disabled", false );

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionDetalle").removeClass("ocultar");            
}


function EditarPublicacionform(idPublicacion) {
    $("#spanIdPublicacionForm")[0].innerText = idPublicacion;

    CargarCombosDetallePublicacion()
    .then(()=>{

    

    removeValidationFormByForm('formPublicacionDetalle');
    let urlEditaPublicacion = urlController + "Publicaciones_CrearPublicacion/GetPublicaciones_CrearPublicacionDetails?id_crearpublicacion=" + idPublicacion;  
    StartLoader();

    fetch(urlEditaPublicacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            CargarCamposPublicacion(datos);

            AddSelect2DivDetallePublicacion();
            $("#txtidkardexPublicacion").prop( "disabled", true );
        
            FinalizeLoader();

            $("#dvPublicacionesTable").addClass("ocultar");    
            $("#dvPublicacionDetalle").removeClass("ocultar");            
        
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
    })
}

function CargarCombosDetallePublicacion() {
    let promises_arrDetPub = [];
    return new Promise((resolve, reject)=>{

        promises_arrDetPub.push(LoadOrigenPublicacionSelect('cboOrigenPublicacion', true));
        promises_arrDetPub.push(LoadTipoPublicacionSelect('cboTipoPublicacion', true));
        promises_arrDetPub.push(LoadGrupoInvestigacionSelect('cboGrupoInvestigacionPublicacion', true));
        promises_arrDetPub.push(LoadPublicacionColeccionSelect('cboColeccionPublicacion', true));
        promises_arrDetPub.push(LoadPublicacionCaracterEditorialSelect('cbocarproyeditorialPublicacion', true));
        promises_arrDetPub.push(LoadPublicacionCoedicionSelect('cboCoedicionPublicacion', true));
        promises_arrDetPub.push(LoadFuncionarioSelect('cboResponsablePublicacion', true));
        promises_arrDetPub.push(LoadAreaAcademicaSelect('cboAreaAcademicaPublicacion', true));
        promises_arrDetPub.push(LoadPublicacionFormatoDistribucionSelect('cboFormatoDistPublicacion', true));
        promises_arrDetPub.push(LoadPublicacionComplejidadSelect('cboComplejidadPublicacion', true));
        promises_arrDetPub.push(LoadPublicacionIdiomaSelect('cboIdiomaPublicacion', true));
        promises_arrDetPub.push(LoadAnnoPublicacionSelect('cboAnnioPublicacionPublicacion', true));
        promises_arrDetPub.push(LoadManuscritosEstadoSelect('cboEstadoPublicacion', true));
        
        Promise.all(promises_arrDetPub)
        .then(selectcargado=>{
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
        })
    })
    
}

function InicializaCamposDetallePublicacion() {
    $('#txtidkardexPublicacion').val('');
    $('#dtfecregmanuscritoPublicacion').val(getFechaActual());    
    $('#txtTituloPublicacion').val('');
    $('cboOrigenPublicacion').select2().val('').trigger("change");
    $('#txtproyextedcontinuaPublicacion').val('');
    $('#cboTipoPublicacion').select2().val('').trigger("change");
    $('#cboGrupoInvestigacionPublicacion').select2().val('').trigger("change");
    $('#cboColeccionPublicacion').select2().val('').trigger("change");
    $("#cboColeccionPublicacion").prop('disabled', false);
    $('#nmNroColeccionPublicacion').val('1');
    $("#nmNroColeccionPublicacion").prop('disabled', false);
    $('#nmNroEdicionPublicacion').val('1');
    $('#cbocarproyeditorialPublicacion').select2().val('').trigger("change");    
    $('#cboCoedicionPublicacion').select2().val('').trigger("change");
    $('#cboResponsablePublicacion').select2().val('').trigger("change");
    $('#txtGestorUnijusPublicacion').val('');
    $('#dtfeciniruteditPublicacion').val(getFechaActual());
    $('#cboAreaAcademicaPublicacion').select2().val('').trigger("change");
    $('#txtHermesIDPublicacion').val('');    
    $('#cboFormatoDistPublicacion').select2().val('').trigger("change");
    $('#cboComplejidadPublicacion').select2().val('').trigger("change");
    $('#cboIdiomaPublicacion').select2().val('').trigger("change");    
    $('#nmCaracteresPublicacion').val('0');
    $('#txtCuartillasPublicacion').val('');
    $('#txtPaginasPublicacion').val('');
    $('#txtLiteralugiPublicacion').val('');
    $('#txtResolucionugiPublicacion').val('');
    $('#txtFichaQuipuPublicacion').val('');
    $('#txtPalabraclavePublicacion').val('');
    $('#txtComentariosPublicacion').val('');  
    $('#cboAnnioPublicacionPublicacion').select2().val('').trigger("change");    
    $('#chkReimpresionPublicacion').prop('checked', false);
    $('#cboEstadoPublicacion').select2().val('').trigger("change");
    
}

function AddSelect2DivDetallePublicacion() {
    $('#cboOrigenPublicacion').select2();
    $('#cboTipoPublicacion').select2();
    $('#cboGrupoInvestigacionPublicacion').select2();
    $('#cboColeccionPublicacion').select2();
    $('#cbocarproyeditorialPublicacion').select2();    
    $('#cboCoedicionPublicacion').select2();
    $('#cboResponsablePublicacion').select2();
    $('#cboAreaAcademicaPublicacion').select2();
    $('#cboFormatoDistPublicacion').select2();
    $('#cboComplejidadPublicacion').select2();
    $('#cboIdiomaPublicacion').select2();
    $('#cboEstadoPublicacion').select2();
}

function DestruyeSelectPublicacion() {
    if ($('#cboOrigenPublicacion').data('select2')) {
        $('#cboOrigenPublicacion').select2('destroy');        
      }    

    if ($('#cboTipoPublicacion').data('select2')) {
        $('#cboTipoPublicacion').select2('destroy');        
      }    

    if ($('#cboGrupoInvestigacionPublicacion').data('select2')) {
        $('#cboGrupoInvestigacionPublicacion').select2('destroy');        
      }    

    if ($('#cboColeccionPublicacion').data('select2')) {
        $('#cboColeccionPublicacion').select2('destroy');        
      }    

    if ($('#cbocarproyeditorialPublicacion').data('select2')) {
        $('#cbocarproyeditorialPublicacion').select2('destroy');        
      }    
            
    if ($('#cboCoedicionPublicacion').data('select2')) {
        $('#cboCoedicionPublicacion').select2('destroy');        
      }    

    if ($('#cboResponsablePublicacion').data('select2')) {
        $('#cboResponsablePublicacion').select2('destroy');        
      }    

    if ($('#cboAreaAcademicaPublicacion').data('select2')) {
        $('#cboAreaAcademicaPublicacion').select2('destroy');        
      }    

    if ($('#cboFormatoDistPublicacion').data('select2')) {
        $('#cboFormatoDistPublicacion').select2('destroy');        
      }    

    if ($('#cboComplejidadPublicacion').data('select2')) {
        $('#cboComplejidadPublicacion').select2('destroy');        
      }    

    if ($('#cboIdiomaPublicacion').data('select2')) {
        $('#cboIdiomaPublicacion').select2('destroy');        
      }
      if ($('#cboEstadoPublicacion').data('select2')) {
        $('#cboEstadoPublicacion').select2('destroy');        
      }  

}

function CargarCamposPublicacion(objdatos) {
    $('#txtidkardexPublicacion').val(objdatos.id_kardex);
    $('#dtfecregmanuscritoPublicacion').val(objdatos.fecregmanuscrito.slice(0, 10));    
    $('#txtTituloPublicacion').val(objdatos.titulomanuscrito);
    $('#cboOrigenPublicacion').select2().val(objdatos.id_origenmanuscrito).trigger("change");
    $('#txtproyextedcontinuaPublicacion').val(objdatos.hermesidproyextedcontinua);
    $('#cboTipoPublicacion').select2().val(objdatos.id_tipoobra).trigger("change");

    if (objdatos.id_creargrupo != null) {
        $('#cboGrupoInvestigacionPublicacion').select2().val(objdatos.id_creargrupo).trigger("change");
    }
    
    $('#cboColeccionPublicacion').select2().val(objdatos.id_coleccion).trigger("change");
    $("#cboColeccionPublicacion").prop('disabled', true);

    $('#nmNroColeccionPublicacion').val('1');
    if (objdatos.nrocoleccion != null) {
        $('#nmNroColeccionPublicacion').val(objdatos.nrocoleccion);
    }
    
    $("#nmNroColeccionPublicacion").prop('enable', true); 
    
    $('#nmNroEdicionPublicacion').val('1');
    if (objdatos.nroedicion != null) {
        $('#nmNroEdicionPublicacion').val(objdatos.nroedicion);
    }

    $('#cbocarproyeditorialPublicacion').select2().val(objdatos.id_carproyeditorial).trigger("change");    

    if (objdatos.id_coedicion != null) {
        $('#cboCoedicionPublicacion').select2().val(objdatos.id_coedicion).trigger("change");
    }
    
    $('#cboResponsablePublicacion').select2().val(objdatos.idfuncionario).trigger("change");
    $('#txtGestorUnijusPublicacion').val(objdatos.geseditunijus);
    $('#dtfeciniruteditPublicacion').val(objdatos.fecinirutedit.slice(0, 10));
    $('#cboAreaAcademicaPublicacion').select2().val(objdatos.id_areaacad).trigger("change");
    $('#txtHermesIDPublicacion').val(objdatos.hermesidmanuscrito);    
    $('#cboFormatoDistPublicacion').select2().val(objdatos.id_formatodistribucion).trigger("change");
    $('#cboComplejidadPublicacion').select2().val(objdatos.id_complejidad).trigger("change");
    $('#cboIdiomaPublicacion').select2().val(objdatos.id_idioma).trigger("change");    
    $('#nmCaracteresPublicacion').val(objdatos.numerocaracteres);
    //$('#txtCuartillasPublicacion').val(objdatos.);
    //$('#txtPaginasPublicacion').val(objdatos.);
    $('#txtLiteralugiPublicacion').val(objdatos.literal_ugi);
    $('#txtResolucionugiPublicacion').val(objdatos.resolucion_ugi);
    $('#txtFichaQuipuPublicacion').val(objdatos.ficha_quipu);
    $('#txtPalabraclavePublicacion').val(objdatos.palabraclave);
    $('#txtComentariosPublicacion').val(objdatos.comentregistro);
    $('#cboAnnioPublicacionPublicacion').select2().val(objdatos.anopublicacion).trigger("change");  
    $('#chkReimpresionPublicacion').prop('checked', objdatos.reimpresion);
    $('#cboEstadoPublicacion').select2().val(objdatos.idestadomanuscrito).trigger("change");

    TotalCuartillaPagina();
}

function TotalCuartillaPagina() {
    let nrocaracteres = $('#nmCaracteresPublicacion').val();
    ncaracteres = Number(nrocaracteres);
    let ncuartillas = Math.trunc(ncaracteres / 1800);
    let npaginas = Math.trunc(ncaracteres / 2200);    
    
    $('#txtCuartillasPublicacion').val(ncuartillas.toLocaleString('en-US'));       
    $('#txtPaginasPublicacion').val(npaginas.toLocaleString('en-US'));
}

/* function AsignarConsecutivoColeccion() {
    let idcoleccion = $('#cboColeccionPublicacion').val();   
    let urlValidar = urlController + "Publicaciones_Coleccion/GetPublicaciones_ColeccionConsecutivo?id_coleccion=" + idcoleccion;    

    fetch(urlValidar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {
            $('#nmNroColeccionPublicacion').val(data.Data);
        }
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      });

} */

function ValidatePostUpdatePublicacion(formF) {
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
                if ($("#spanIdPublicacionForm")[0].innerText == '') {
                    ExisteKardexPublicacion()
                        .then(existe => {
                            if (!existe) {                                    
                                AddUpdatePublicacion();
                            }
                        })
                }
                else {
                    AddUpdatePublicacion();
                }                
            }
        }
    }    
}

function ExisteKardexPublicacion() {    
    let nrokardex = $('#txtidkardexPublicacion').val();   
    let urlValidar = urlController + "Publicaciones_CrearPublicacion/GetPublicaciones_CrearPublicacionCodigo?cd_id_kardex=" + nrokardex;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "Ya existe una publicación registrada con el kardex " + nrokardex;
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

function AddUpdatePublicacion() {
    debugger;
    let objPublicacion = new Object();    
    let urlUpdate = urlController + "Publicaciones_CrearPublicacion/UpdatePublicaciones_CrearPublicacion";
    StartLoader();
    
    objPublicacion.id_crearpublicacion = ($("#spanIdPublicacionForm")[0].innerText == '') ? undefined : $("#spanIdPublicacionForm")[0].innerText;
    
    objPublicacion.id_kardex = $('#txtidkardexPublicacion').val();
    objPublicacion.fecregmanuscrito = $('#dtfecregmanuscritoPublicacion').val();    
    objPublicacion.titulomanuscrito = $('#txtTituloPublicacion').val();
    objPublicacion.id_origenmanuscrito = $('#cboOrigenPublicacion').val();
    objPublicacion.hermesidproyextedcontinua = $('#txtproyextedcontinuaPublicacion').val();
    objPublicacion.id_tipoobra = $('#cboTipoPublicacion').val();
    objPublicacion.id_creargrupo = $('#cboGrupoInvestigacionPublicacion').val();
    objPublicacion.id_coleccion = $('#cboColeccionPublicacion').val();
    objPublicacion.nrocoleccion = $('#nmNroColeccionPublicacion').val();
    objPublicacion.nroedicion = $('#nmNroEdicionPublicacion').val();
    objPublicacion.id_carproyeditorial = $('#cbocarproyeditorialPublicacion').val();    
    objPublicacion.id_coedicion = $('#cboCoedicionPublicacion').val(); 
    objPublicacion.idfuncionario = $('#cboResponsablePublicacion').val();
    objPublicacion.geseditunijus = $('#txtGestorUnijusPublicacion').val();
    objPublicacion.fecinirutedit = $('#dtfeciniruteditPublicacion').val();
    objPublicacion.id_areaacad = $('#cboAreaAcademicaPublicacion').val();
    objPublicacion.hermesidmanuscrito = $('#txtHermesIDPublicacion').val(); 
    objPublicacion.id_formatodistribucion = $('#cboFormatoDistPublicacion').val();
    objPublicacion.id_complejidad = $('#cboComplejidadPublicacion').val();
    objPublicacion.id_idioma = $('#cboIdiomaPublicacion').val();
    objPublicacion.numerocaracteres = $('#nmCaracteresPublicacion').val();
    objPublicacion.literal_ugi = $('#txtLiteralugiPublicacion').val();
    objPublicacion.resolucion_ugi = $('#txtResolucionugiPublicacion').val();
    objPublicacion.ficha_quipu = $('#txtFichaQuipuPublicacion').val();
    objPublicacion.palabraclave = $('#txtPalabraclavePublicacion').val();
    objPublicacion.comentregistro = $('#txtComentariosPublicacion').val();
    objPublicacion.anopublicacion = $('#cboAnnioPublicacionPublicacion').val();
    objPublicacion.reimpresion = $('#chkReimpresionPublicacion').is(':checked');
    objPublicacion.idestadomanuscrito = $('#cboEstadoPublicacion').val();
                
    if (objPublicacion.id_crearpublicacion == undefined) {
        urlUpdate = urlController + "Publicaciones_CrearPublicacion/InsertPublicaciones_CrearPublicacion";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objPublicacion),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {     
            FinalizeLoader();

            DestruyeSelectPublicacion();

            $("#dvPublicacionDetalle").addClass("ocultar");    
            $("#dvPublicacionesTable").removeClass("ocultar");
        
            RefreshDataTablePublicaciones();
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