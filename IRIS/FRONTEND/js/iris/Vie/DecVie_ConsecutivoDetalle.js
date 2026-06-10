var ObjModelDecVie_Consecutivo = null;


$(document).ready(function () {

  ObjModelDecVie_Consecutivo = new DecVie_Consecutivo();

    if ($("#spanIdDecVie_Consecutivo")[0].innerText == '') {
        console.log("Se activo en el DecVie_ConsecutivoDetalle linea 9")
    }
    else {
        EditarDecVie_Consecutivoform($("#spanIdDecVie_Consecutivo")[0].innerText);
    }

});

function CerrarDecVie_ConsecutivoDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_Consecutivo);
    
    $("#dvDecVie_ConsecutivoDetalle").addClass("ocultar");    
    $("#dvDecVie_ConsecutivoTable").removeClass("ocultar");
    

}

function CrearDecVie_Consecutivoform() {
    console.log("Iniciando CrearDecVie_Consecutivoform");

    $("#cboid_prefijoconsecutivo_DecVie_Consecutivo").off("change").on("change", function () {
        $(this).prop("disabled", true);
        console.log("Prefijo cambiado, generando consecutivo...");
        GenerarConsecutivoDctoDependencia('dtfecha_DecVie_Consecutivo', 'cboid_prefijoconsecutivo_DecVie_Consecutivo', 'txtnumconsecutivo_DecVie_Consecutivo')
            .finally(() => {
                $(this).prop("disabled", false);
                console.log("Prefijo procesado.");
            });
    });

    // Asegurarse de que los campos estén habilitados inicialmente
    $("#cboid_prefijoconsecutivo_DecVie_Consecutivo").prop("disabled", false);
    $("#dtfecha_DecVie_Consecutivo").prop("disabled", false);
    $("#cboid_depend_DecVie_Consecutivo").prop("disabled", false);

    // Resetear valores
    $("#spanIdDecVie_ConsecutivoForm")[0].innerText = '';
    $("#txtid_decvieconsecutivo_DecVie_Consecutivo").val('');
    console.log("Campos reseteados");

    StartLoader();

    // Procesar datos con el modelo
    NewData_ToModel(ObjModelDecVie_Consecutivo)
        .then(datospreparados => {
            console.log("Datos preparados:", datospreparados);

            if (datospreparados) {
                console.log("Consecutivo generado con éxito. Deshabilitando el campo.");
                $("#txtnumconsecutivo_DecVie_Consecutivo").prop("disabled", true);
                FinalizeLoader();

                // Cambiar visibilidad de las secciones
                $("#dvDecVie_ConsecutivoTable").addClass("ocultar");
                $("#dvDecVie_ConsecutivoDetalle").removeClass("ocultar");
            }
        })
        .catch(err => {
            console.error("Error en CrearDecVie_Consecutivoform:", err);
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        });
}



function EditarDecVie_Consecutivoform(iddecvieconsecutivo) {
    $("#spanIdDecVie_ConsecutivoForm")[0].innerText = iddecvieconsecutivo;
    $("#txtid_decvieconsecutivo_DecVie_Consecutivo").val(iddecvieconsecutivo);
    $("#txtnumconsecutivo_DecVie_Consecutivo").prop( "disabled", true );
    $("#cboid_prefijoconsecutivo_DecVie_Consecutivo").prop( "disabled", true );
    $("#dtfecha_DecVie_Consecutivo").prop( "disabled", true );
    $("#cboid_depend_DecVie_Consecutivo").prop( "disabled", true );
    $("#cboid_prefijoconsecutivo_DecVie_Consecutivo").prop( "onchange", false );
    LoadData_ToModelConsecutivo(ObjModelDecVie_Consecutivo, iddecvieconsecutivo)
    .then(datoscargados => {
        if (datoscargados) { 
            FinalizeLoader();

            $("#dvDecVie_ConsecutivoTable").addClass("ocultar");    
            $("#dvDecVie_ConsecutivoDetalle").removeClass("ocultar");            
        }
    })
    .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })          

}

function ValidatePostUpdateDecVie_Consecutivo(formF) {

    console.log("Inicio de la validación del formulario:", formF);

    let form = $("#" + formF);
    if (form.length === 0) {
        console.error("Formulario no encontrado con el ID:", formF);
        return;
    }

    console.log("Formulario encontrado:", form);

    // Listar los campos presentes en el formulario
    form.find("input, select, textarea").each(function () {
        console.log("Campo ID:", $(this).attr("id"), 
                    "Valor:", $(this).val(), 
                    "Habilitado:", !$(this).prop("disabled"), 
                    "Visible:", $(this).is(":visible"));
    });

    // Intentar serializar los datos
    let serializedData = form.serializeArray();
    console.log("Datos serializados del formulario:", serializedData);

    if (serializedData.length === 0) {
        console.warn("No se encontraron datos válidos en el formulario. Revisa los campos.");
    } else {
        console.log("Datos capturados correctamente:", serializedData);
    }

    ValidatePostUpdateModel_EdicionForm_Data(ObjModelDecVie_Consecutivo)
        .then(datosGuardados => {
            if (datosGuardados.Ok) {
                FinalizeLoader();
                ShowModalDialog('Datos Guardados, consecutivo ' + datosGuardados.Data.numconsecutivo, false, 'success', '', 0);  
                RefreshDataTableDecVie_Consecutivo();
                CerrarDecVie_ConsecutivoDesdeEdicion();                        
            }
        })
        .catch(err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })
}


function CargarPrefijosDependencia_ConsecutivoDtalle() {
    
    let iddependenciaConsecutivo = $('#cboid_depend_DecVie_Consecutivo').val();

    LoadCorrespondencia_PrefijoConsecutivoByDependenciaSelect('cboid_prefijoconsecutivo_DecVie_Consecutivo', true, iddependenciaConsecutivo);    
}

function GenerarConsecutivoDctoDependencia(controlfecha, controlidprefijo, controlprefijo) {
    let fechaconsecutivo = $('#' + controlfecha).val();
    let id_prefijoconsecutivo = $('#' + controlidprefijo).val();

    if (id_prefijoconsecutivo == undefined){
        return;
    }

    let urldatos = urlController + "Consecutivo_Annio/GetConsecutivo_Annio?id_prefijoconsecutivo=" + id_prefijoconsecutivo + "&fecha=" + fechaconsecutivo;    
  
    return new Promise( (resolve, reject) => {
      fetch(urldatos, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
        .then(data => {
            if (data.Ok) {
                $('#' + controlprefijo).val(data.Data);
                
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
