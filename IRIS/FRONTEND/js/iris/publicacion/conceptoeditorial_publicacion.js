$(document).ready(function () {

    PublicacionConceptoEditorialForm($("#spanIdPublicacion")[0].innerText);

});

function LoadGrupoInvestigacionSelectTEMP(select, tienenulo) {
    $('#' + select).empty();

    if (tienenulo) {
        $('#' + select).append('<option value="">Seleccione</option>');
      }

    $('#' + select).append('<option value="11">Grupo 11</option>');
    $('#' + select).append('<option value="10">Grupo 10</option>');

}


function VolverTablaPublicacionesDesdeConcepto() {
    DestruyeSelectConceptoEditorialPublicacion();

    $("#dvPublicacionConceptoEditorial").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function PublicacionConceptoEditorialForm(idPublicacion) {
    $("#spanIdPublicacionFormConcepto")[0].innerText = idPublicacion;
    $("#spanIdConceptoEditorial")[0].innerText = '';
    
    CargarCombosConceptoEditorialPublicacion();

    InicializaCamposConceptoEditorialPublicacion();

    removeValidationFormByForm('formPublicacionConceptoEditorial');    
    let urlConceptoPublicacion = urlController + "Publicaciones_ConceptoEditorial/GetPublicaciones_ConceptoEditorialByPublicacion?id_crearpublicacion=" + idPublicacion;  
    StartLoader();

    fetch(urlConceptoPublicacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            CargarCamposConceptoEditorialPublicacion(datos);

            AddSelect2DivConceptoEditorialPublicacion();
                    
            FinalizeLoader();

            $("#dvPublicacionesTable").addClass("ocultar");    
            $("#dvPublicacionConceptoEditorial").removeClass("ocultar");            
        
            return;
        }
        else {
            FinalizeLoader();
            AddSelect2DivConceptoEditorialPublicacion();

            $("#dvPublicacionesTable").addClass("ocultar");    
            $("#dvPublicacionConceptoEditorial").removeClass("ocultar");            
                    
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );       

}

function CargarCombosConceptoEditorialPublicacion() {
    LoadSistemaCitacionPublicacionSelect('cboSistemaCitacionPublica', true);
    LoadRecomendacionImpresionPublicacionSelect('cboRecomendacionImpresionPublica', true);
    LoadSiNoNoAplicaSelect('cboIndiceAnaliticosPublica', false);
    LoadSiNoNoAplicaSelect('cboSelloEditorialPublica', false);
}

function InicializaCamposConceptoEditorialPublicacion() {
    $('#chkManuscOriginalPublicacion').prop('checked', false);
    $('#dtfechaManuscOriginalPublicacion').val('');
    $('#chkManuscDefinitivoPublicacion').prop('checked', false);
    $('#dtfechaManuscDefinitivoPublicacion').val('');
    $('#chkConcEditorialPublicacion').prop('checked', false);
    $('#dtfechaElaboraPreliminarPublicacion').val('');
    $('#txtconcepteditpreliminarPublicacion').val('');
    $('#dtfechaElaboraFinalPublicacion').val('');
    $('#txtconcepteditfinalPublicacion').val('');
    $('#cboSistemaCitacionPublica').select2().val('').trigger("change");
    $('#nmnumimgajenolicPublicacion').val('0');
    $('#nmnumimgajenoslicPublicacion').val('0');
    $('#nmnumimgpropioPublicacion').val('0');
    $('#nmnumimgblanconegroPublicacion').val('0');
    $('#nmnumimgcolorPublicacion').val('0');
    $('#nmnumtablasPublicacion').val('0');
    $('#nmnumtblcolorPublicacion').val('0');
    $('#nmnumtblblanconegroPublicacion').val('0');
    $('#cboRecomendacionImpresionPublica').select2().val('').trigger("change");
    $('#cboIndiceAnaliticosPublica').select2().val('').trigger("change");
    $('#cboSelloEditorialPublica').select2().val('').trigger("change");
    $('#chkestraduccionPublicacion').prop('checked', false);
    $('#chkescomercializablePublicacion').prop('checked', false);
    $('#txtresenacubiertaPublicacion').val('');
}

function AddSelect2DivConceptoEditorialPublicacion() {
    $('#cboSistemaCitacionPublica').select2();
    $('#cboRecomendacionImpresionPublica').select2();
    $('#cboIndiceAnaliticosPublica').select2();
    $('#cboSelloEditorialPublica').select2();
}

function DestruyeSelectConceptoEditorialPublicacion() {
    if ($('#cboSistemaCitacionPublica').data('select2')) {
        $('#cboSistemaCitacionPublica').select2('destroy');        
      }    

    if ($('#cboRecomendacionImpresionPublica').data('select2')) {
        $('#cboRecomendacionImpresionPublica').select2('destroy');        
      }    

    if ($('#cboIndiceAnaliticosPublica').data('select2')) {
        $('#cboIndiceAnaliticosPublica').select2('destroy');        
      }    

    if ($('#cboSelloEditorialPublica').data('select2')) {
        $('#cboSelloEditorialPublica').select2('destroy');        
      }    
}

function CargarCamposConceptoEditorialPublicacion(objdatos) {
    $("#spanIdConceptoEditorial")[0].innerText = objdatos.id_conceptoeditorial;

    $('#chkManuscOriginalPublicacion').prop('checked', objdatos.manuscritooriginal);

    if (objdatos.fecentregaoriginal != null) {
        $('#dtfechaManuscOriginalPublicacion').val(objdatos.fecentregaoriginal.slice(0,10));
    }
    
    $('#chkManuscDefinitivoPublicacion').prop('checked', objdatos.manuscirtodefinitivo);

    if (objdatos.fecentregadefinitivo != null) {
        $('#dtfechaManuscDefinitivoPublicacion').val(objdatos.fecentregadefinitivo.slice(0,10));
    }
    
    $('#chkConcEditorialPublicacion').prop('checked', objdatos.conceptoeditorial);

    if (objdatos.fechaelaboracion != null) {
        $('#dtfechaElaboraPreliminarPublicacion').val(objdatos.fechaelaboracion.slice(0,10));
    }
    
    $('#txtconcepteditpreliminarPublicacion').val(objdatos.concepteditpreliminar);

    if (objdatos.fechaelabfinal != null) {
        $('#dtfechaElaboraFinalPublicacion').val(objdatos.fechaelabfinal.slice(0,10));
    }
    
    $('#txtconcepteditfinalPublicacion').val(objdatos.concepteditfinal);

    if (objdatos.id_sistemacitacion != null) {
        $('#cboSistemaCitacionPublica').select2().val(objdatos.id_sistemacitacion).trigger("change");
    }
    
    $('#nmnumimgajenolicPublicacion').val(objdatos.numimgajenolic);
    $('#nmnumimgajenoslicPublicacion').val(objdatos.numimgajenoslic);
    $('#nmnumimgpropioPublicacion').val(objdatos.numimgpropio);
    $('#nmnumimgblanconegroPublicacion').val(objdatos.numimgblanconegro);
    $('#nmnumimgcolorPublicacion').val(objdatos.numimgcolor);
    $('#nmnumtablasPublicacion').val(objdatos.numtablas);
    $('#nmnumtblcolorPublicacion').val(objdatos.numtblcolor);
    $('#nmnumtblblanconegroPublicacion').val(objdatos.numtblblanconegro);

    if (objdatos.idrecomendacionimpre != null) {
        $('#cboRecomendacionImpresionPublica').select2().val(objdatos.idrecomendacionimpre).trigger("change");
    }
    
    $('#cboIndiceAnaliticosPublica').select2().val(objdatos.indicesanaliticos).trigger("change");
    $('#cboSelloEditorialPublica').select2().val(objdatos.selloeditorial).trigger("change");
    $('#chkestraduccionPublicacion').prop('checked', objdatos.estraduccion);
    $('#chkescomercializablePublicacion').prop('checked', objdatos.escomercializable);
    $('#txturlconcepeditPublicacion').val(objdatos.urlconcepedit);
    $('#txtresenacubiertaPublicacion').val(objdatos.resenacubierta);
}


function ValidatePostUpdatePublicacionConcepto(formF) {
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
                AddUpdatePublicacionConceptoEditorial();
            }
        }
    }    
}

function AddUpdatePublicacionConceptoEditorial() {
    let objPublicacion = new Object();    
    let urlUpdate = urlController + "Publicaciones_ConceptoEditorial/UpdatePublicaciones_ConceptoEditorial";
    StartLoader();
    
    objPublicacion.id_conceptoeditorial = ($("#spanIdConceptoEditorial")[0].innerText == '') ? undefined : $("#spanIdConceptoEditorial")[0].innerText;

    objPublicacion.id_crearpublicacion = $("#spanIdPublicacionFormConcepto")[0].innerText;
    objPublicacion.manuscritooriginal = $('#chkManuscOriginalPublicacion').is(':checked');
    objPublicacion.fecentregaoriginal = $('#dtfechaManuscOriginalPublicacion').val();
    objPublicacion.manuscirtodefinitivo = $('#chkManuscDefinitivoPublicacion').is(':checked');
    objPublicacion.fecentregadefinitivo = $('#dtfechaManuscDefinitivoPublicacion').val();
    objPublicacion.conceptoeditorial = $('#chkConcEditorialPublicacion').is(':checked');
    objPublicacion.fechaelaboracion = $('#dtfechaElaboraPreliminarPublicacion').val();
    objPublicacion.concepteditpreliminar = $('#txtconcepteditpreliminarPublicacion').val();
    objPublicacion.fechaelabfinal = $('#dtfechaElaboraFinalPublicacion').val();
    objPublicacion.concepteditfinal = $('#txtconcepteditfinalPublicacion').val();
    objPublicacion.id_sistemacitacion = $('#cboSistemaCitacionPublica').val();
    objPublicacion.numimgajenolic = $('#nmnumimgajenolicPublicacion').val();
    objPublicacion.numimgajenoslic = $('#nmnumimgajenoslicPublicacion').val();
    objPublicacion.numimgpropio = $('#nmnumimgpropioPublicacion').val();
    objPublicacion.numimgblanconegro = $('#nmnumimgblanconegroPublicacion').val();
    objPublicacion.numimgcolor = $('#nmnumimgcolorPublicacion').val(); 
    objPublicacion.numtablas = $('#nmnumtablasPublicacion').val();
    objPublicacion.numtblcolor = $('#nmnumtblcolorPublicacion').val();
    objPublicacion.numtblblanconegro = $('#nmnumtblblanconegroPublicacion').val();
    objPublicacion.idrecomendacionimpre = $('#cboRecomendacionImpresionPublica').val();
    objPublicacion.urlconcepedit = $('#txturlconcepeditPublicacion').val(); //añadido recientemente
    objPublicacion.indicesanaliticos = $('#cboIndiceAnaliticosPublica').val();
    objPublicacion.selloeditorial = $('#cboSelloEditorialPublica').val();
    objPublicacion.estraduccion = $('#chkestraduccionPublicacion').is(':checked');
    objPublicacion.escomercializable = $('#chkescomercializablePublicacion').is(':checked');
    objPublicacion.resenacubierta = $('#txtresenacubiertaPublicacion').val();
                    
    if (objPublicacion.id_conceptoeditorial == undefined) {
        urlUpdate = urlController + "Publicaciones_ConceptoEditorial/InsertPublicaciones_ConceptoEditorial";
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

            DestruyeSelectConceptoEditorialPublicacion();

            $("#dvPublicacionConceptoEditorial").addClass("ocultar");    
            $("#dvPublicacionesTable").removeClass("ocultar");

            ShowModalDialog('Concepto editorial guardado', false, 'success', '', 0);
        
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


function EnableFechaOriginal() {
    document.getElementById("dtfechaManuscOriginalPublicacion").disabled = !$('#chkManuscOriginalPublicacion').is(':checked');
}

function EnableFechaDefinitivo() {
    document.getElementById("dtfechaManuscDefinitivoPublicacion").disabled = !$('#chkManuscDefinitivoPublicacion').is(':checked');
}