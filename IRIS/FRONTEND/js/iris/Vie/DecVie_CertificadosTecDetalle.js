var ObjModelDecVie_CertificadosTec = null;

$(document).ready(function () {

  ObjModelDecVie_CertificadosTec = new DecVie_CertificadosTec();

  if ($("#spanIdDecVie_CertificadosTec")[0].innerText == '') {
      console.log("Se activó en el DecVie_CertificadosTecDetalle línea 9");
  } else {
      EditarDecVie_CertificadosTecform($("#spanIdDecVie_CertificadosTec")[0].innerText);
  }
});

function CerrarDecVie_CertificadosTecDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_CertificadosTec);
  
  $("#dvDecVie_CertificadosTecDetalle").addClass("ocultar");
  $("#dvDecVie_CertificadosTecTable").removeClass("ocultar");
}

function CrearDecVie_CertificadosTecform() {
    validarElemento('#cboid_prefijoconsecutivo_DecVie_CertificadosTec');

  $("#cboid_prefijoconsecutivo_DecVie_CertificadosTec").off("change").on("change", function() {
      $(this).prop("disabled", true);
      GenerarCertificadosTecDctoDependencia('dtfecha_DecVie_CertificadosTec', 'cboid_prefijoconsecutivo_DecVie_CertificadosTec', 'txtnumcertificadotec_DecVie_CertificadosTec')
          .finally(() => {
              $(this).prop("disabled", false);
          });
  });
  $("#cboid_prefijoconsecutivo_DecVie_CertificadosTec").prop("disabled", false);
  $("#dtfecha_DecVie_CertificadosTec").prop("disabled", false);
  $("#cboid_depend_DecVie_CertificadosTec").prop("disabled", false);

  $("#spanIdDecVie_CertificadosTecForm")[0].innerText = '';
  $("#txtid_decviecertificadostec_DecVie_CertificadosTec").val('');
   
  StartLoader();

  NewData_ToModel(ObjModelDecVie_CertificadosTec)
      .then(datospreparados => {
          if (datospreparados) { 
              $("#txtnumcertificadotec_DecVie_CertificadosTec").prop("disabled", true);
              FinalizeLoader();

              $("#dvDecVie_CertificadosTecTable").addClass("ocultar");
              $("#dvDecVie_CertificadosTecDetalle").removeClass("ocultar");            
          }
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
      });
}

function EditarDecVie_CertificadosTecform(iddecviecertificadostec) {
  console.log('ID enviado al backend para edición:', iddecviecertificadostec);
  console.log('ObjModelDecVie_CertificadosTec:', ObjModelDecVie_CertificadosTec);
  
  $("#spanIdDecVie_CertificadosTecForm")[0].innerText = iddecviecertificadostec;
  $("#txtid_decviecertificadostec_DecVie_CertificadosTec").val(iddecviecertificadostec);
  $("#txtnumcertificadotec_DecVie_CertificadosTec").prop("disabled", true);
  $("#cboid_prefijoconsecutivo_DecVie_CertificadosTec").prop("disabled", true);
  $("#dtfecha_DecVie_CertificadosTec").prop("disabled", true);
  $("#cboid_depend_DecVie_CertificadosTec").prop("disabled", true);

  LoadData_ToModelCertificadosTec(ObjModelDecVie_CertificadosTec, iddecviecertificadostec)
      .then(datoscargados => {
          if (datoscargados) { 
              FinalizeLoader();

              $("#dvDecVie_CertificadosTecTable").addClass("ocultar");
              $("#dvDecVie_CertificadosTecDetalle").removeClass("ocultar");            
          }
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
      });
}

function ValidatePostUpdateDecVie_CertificadosTec(formF) {
    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CertificadosTec)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos Certificado Guardados', false, 'success', '', 0);  
        RefreshDataTableDecVie_CertificadosTec();
        CerrarDecVie_CertificadosTecDesdeEdicion();                        
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    });
  }
  

function AsignarValoresFormulario(datos) {
  console.log('Asignando valores al formulario...');

  const fechaFormateada = datos.fecha ? datos.fecha.slice(0, 16) : '';
  console.log('Fecha formateada:', fechaFormateada);
  document.getElementById('dtfecha_DecVie_CertificadosTec').value = fechaFormateada;

  console.log('Dependencia:', datos.id_depend);
  $('#cboid_depend_DecVie_CertificadosTec').val(datos.id_depend).trigger('change');

  console.log('Prefijo:', datos.id_prefijoconsecutivo);
  $('#cboid_prefijoconsecutivo_DecVie_CertificadosTec').val(datos.id_prefijoconsecutivo).trigger('change');

  console.log('Certificado:', datos.numcertificadotec);
  document.getElementById('txtnumcertificadotec_DecVie_CertificadosTec').value = datos.numcertificadotec;

  console.log('Procedencia:', datos.tsersubserdocu);
  document.getElementById('txttsersubserdocu_DecVie_CertificadosTec').value = datos.tsersubserdocu;

  console.log('Asunto:', datos.asunto);
  document.getElementById('txtasunto_DecVie_CertificadosTec').value = datos.asunto;

  console.log('Estado Pago:', datos.id_estado_pago);
  $('#cboestado_pago_DecVie_CertificadosTec').val(datos.id_estado_pago).trigger('change');

  console.log('Observaciones:', datos.observaciones);
  document.getElementById('txtobservaciones_DecVie_CertificadosTec').value = datos.observaciones;

  console.log('Valores asignados al formulario.');
}

// Función para verificar elementos antes de acceder
function validarElemento(selector) {
    if (!$(selector).length) {
        console.error(`Elemento con selector ${selector} no encontrado.`);
    }
}

function CargarPrefijosDependencia_CertificadosTecDetalle() {
    let iddependenciaCertificadosTec = $('#cboid_depend_DecVie_CertificadosTec').val();

    if (!iddependenciaCertificadosTec) {
        console.warn('El valor de id_dependenciaCertificadosTec está vacío. No se realiza ninguna acción.');
        return; 
    }

    console.log('Cargando prefijos para la dependencia:', iddependenciaCertificadosTec);

    LoadCorrespondencia_PrefijoConsecutivoByDependenciaSelect(
        'cboid_prefijoconsecutivo_DecVie_CertificadosTec',
        true,
        iddependenciaCertificadosTec
    );
}

function GenerarCertificadosTecDctoDependencia(controlfecha, controlidprefijo, controlprefijo) {
  let fechaCertificado = $('#' + controlfecha).val();
  let id_prefijoconsecutivo = $('#' + controlidprefijo).val();

  if (id_prefijoconsecutivo === undefined) {
      return;
  }

  let urldatos = urlController + "Consecutivo_Annio/GetConsecutivo_Annio?id_prefijoconsecutivo=" + id_prefijoconsecutivo + "&fecha=" + fechaCertificado;    
  return new Promise((resolve, reject) => {
      fetch(urldatos, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
      .then(data => {
          if (data.Ok) {
              $('#' + controlprefijo).val(data.Data);
              return resolve(true);
          } else {
              return resolve(false);
          }
      })
      .catch(err => {
          ShowModalDialog(err, false, 'error', '', 0);
          reject(err);
      });
  });
}
