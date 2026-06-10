var ObjModelDecVie_RadicadorTec = null;


$(document).ready(function () {

  ObjModelDecVie_RadicadorTec = new DecVie_RadicadorTec();

    if ($("#spanIdDecVie_RadicadorTec")[0].innerText == '') {
        //Cambio ADDAVARGAS 20/04/2024 comentado
        //CrearDecVie_RadicadorTecform();
        console.log("Se activo en el DecVie_RadicadorTecDetalle linea 9")
    }
    else {
        EditarDecVie_RadicadorTecform($("#spanIdDecVie_RadicadorTec")[0].innerText);
    }

});

//SE AÑADE CAMBIO ADDA VARGAS 28 DE JULIO 2025
// Actualmente esta dentro de la función AsignarValoresFormulario, 
// lo cual hace que cada vez que se edite un radicado, se cree un nuevo listener 
// y eso puede generar errores de duplicado.
let dependenciaManual = false;
let yaAsignadaPorFuncionario = false;

$('#dtfecha_DecVie_RadicadorTec').on('change', function() {
    const fechaBase = $(this).val().slice(0,10); // yyyy-mm-dd
    const fechaVencimiento = sumarDiasHabilesConFestivos(fechaBase, 15, festivosColombia);
    $('#dtfecha_vencimiento_DecVie_RadicadorTec').val(fechaVencimiento);
});

$('#cbodependenciadestino_DecVie_RadicadorTec').on('change', function () {
    const idDependencia = $(this).val();

    if (!idDependencia || idDependencia === '') {
        dependenciaManual = false;
        yaAsignadaPorFuncionario = false;
        console.log("Reiniciando lista de funcionarios: opción 'Seleccione' en dependencia.");
        FiltrarFuncionariosPorDependencia('');
        return;
    }

    dependenciaManual = true;
    yaAsignadaPorFuncionario = false;
    console.log("Filtrando funcionarios por dependencia:", idDependencia);
    FiltrarFuncionariosPorDependencia(idDependencia);
});

$('#cboidfuncionario_DecVie_RadicadorTec').on('change', function () {
    const idFuncionario = $(this).val();
    if (parseInt(idFuncionario) === 3) {
        console.log("Funcionario 'Sin especificar'. No se asigna dependencia.");
        return;
    }

    const idDependenciaActual = $('#cbodependenciadestino_DecVie_RadicadorTec').val();

    // Si la dependencia no ha sido elegida manualmente
    if (!dependenciaManual && !yaAsignadaPorFuncionario) {
        fetch(urlController + 'Funcionario/GetFuncionarioDetails?idfuncionario=' + idFuncionario, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
        .then(data => {
            if (data.Ok && data.Data) {
                const idDepend = data.Data.id_depend;
                console.log('Dependencia asignada por funcionario:', idDepend);

                const $dep = $('#cbodependenciadestino_DecVie_RadicadorTec');
                $dep.val(idDepend).trigger('change');

                yaAsignadaPorFuncionario = true;
                dependenciaManual = true; // desde aquí ya no debe volver a asignar automáticamente
            }
        })
        .catch(err => console.error('Error obteniendo dependencia del funcionario:', err));
    }
});




function CerrarDecVie_RadicadorTecDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_RadicadorTec);
    
    $("#dvDecVie_RadicadorTecDetalle").addClass("ocultar");    
    $("#dvDecVie_RadicadorTecTable").removeClass("ocultar");
    

}

function CrearDecVie_RadicadorTecform() {
    $("#cboid_prefijoconsecutivo_DecVie_RadicadorTec").off("change").on("change", function() {
        // Deshabilita el control para evitar cambios mientras se procesa la solicitud
        $(this).prop("disabled", true);
        GenerarRadicadorTecDctoDependencia('dtfecha_DecVie_RadicadorTec', 'cboid_prefijoconsecutivo_DecVie_RadicadorTec', 'txtnumradicadortec_DecVie_RadicadorTec')
            .finally(() => {
                // Vuelve a habilitar el control una vez completada la solicitud
                $(this).prop("disabled", false);
            });
    });
    $("#cboid_prefijoconsecutivo_DecVie_RadicadorTec").prop( "disabled", false );
    $("#dtfecha_DecVie_RadicadorTec").prop( "disabled", false );
    $("#cboid_depend_DecVie_RadicadorTec").prop( "disabled", false );

    $("#spanIdDecVie_RadicadorTecForm")[0].innerText = '';
    $("#txtid_decvieradicadortec_DecVie_RadicadorTec").val('');

    $("#txtasunto_DecVie_RadicadorTec").prop("disabled", false);
    $("#txttsersubserdocu_DecVie_RadicadorTec").prop("disabled", false);
     
    $('#tablaHistorialAuditoria').closest('div').hide();
    StartLoader(); 

    NewData_ToModel(ObjModelDecVie_RadicadorTec)
        .then(datospreparados => {
            if (datospreparados) { 
                $("#txtnumradicadortec_DecVie_RadicadorTec").prop( "disabled", true );
                FinalizeLoader();

                $("#dvDecVie_RadicadorTecTable").addClass("ocultar");    
                $("#dvDecVie_RadicadorTecDetalle").removeClass("ocultar");            
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  
        

}


function EditarDecVie_RadicadorTecform(iddecvieradicadortec) {
    console.log('→ EditarDecVie_RadicadorTecform:', iddecvieradicadortec);
    $("#spanIdDecVie_RadicadorTecForm")[0].innerText = iddecvieradicadortec;
    $("#txtid_decvieradicadortec_DecVie_RadicadorTec").val(iddecvieradicadortec);
    $("#txtnumradicadortec_DecVie_RadicadorTec").prop("disabled", true);
    $("#cboid_prefijoconsecutivo_DecVie_RadicadorTec").prop("disabled", true);
    $("#dtfecha_DecVie_RadicadorTec").prop("disabled", true);
    $("#cboid_depend_DecVie_RadicadorTec").prop("disabled", true);
    $("#txtasunto_DecVie_RadicadorTec").prop("disabled", true);
    $("#txttsersubserdocu_DecVie_RadicadorTec").prop("disabled", true);
    $('#tablaHistorialAuditoria').closest('div').show();
    CargarHistorialAuditoria(iddecvieradicadortec);

    // Limpiar observaciones:
    $("#txtobservaciones_DecVie_RadicadorTec").val('');
    console.log('→ Limpiando campo observaciones');

    LoadData_ToModelRadicadorTec(ObjModelDecVie_RadicadorTec, iddecvieradicadortec)
        .then(datoscargados => {
            console.log('✓ datos cargados para edición:', datoscargados);
            if (datoscargados) { 
                FinalizeLoader();
                $("#dvDecVie_RadicadorTecTable").addClass("ocultar");    
                $("#dvDecVie_RadicadorTecDetalle").removeClass("ocultar");            
            }
        })
        .catch(err => {
            console.error("✗ ERROR en LoadData_ToModelRadicadorTec:", err);
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        });         
}


function ValidatePostUpdateDecVie_RadicadorTec(formF) {
    ObjModelDecVie_RadicadorTec.fecha_vencimiento = $('#dtfecha_vencimiento_DecVie_RadicadorTec').val();
    const estadoSeleccionado = $('#cboid_decviemacroproceso_DecVie_RadicadorTec').val();
    const observacionActual = $('#txtobservaciones_DecVie_RadicadorTec').val();
    const usuarioActual = sessionStorage.getItem("usuario");
    
    ValidatePostUpdateModel_EdicionForm_Data2(ObjModelDecVie_RadicadorTec)
        .then(datosGuardados => {
            console.log("✓ Respuesta de ValidatePostUpdateModel_EdicionForm_Data2:", datosGuardados);

            // Toma el id actualizado del registro guardado:
            const idRadicado = datosGuardados.Data && datosGuardados.Data.id_decvieradicadortec
                ? datosGuardados.Data.id_decvieradicadortec
                : ObjModelDecVie_RadicadorTec.id_decvieradicadortec; // fallback

            if (datosGuardados.Ok) {
                // Guarda cambio de estado en auditoría
                console.log("→ GuardarAuditoriaRadicadorTec [ESTADO]", {
                    id: idRadicado,
                    estadoSeleccionado,
                    usuarioActual
                });
                GuardarAuditoriaRadicadorTec(
                    idRadicado,
                    "ESTADO",
                    estadoSeleccionado,
                    usuarioActual
                );

                // Si hay observación, guarda también en auditoría
                if (observacionActual !== '') {
                    console.log("→ GuardarAuditoriaRadicadorTec [OBSERVACION]", {
                        id: idRadicado,
                        observacionActual,
                        usuarioActual
                    });
                    GuardarAuditoriaRadicadorTec(
                        idRadicado,
                        "OBSERVACION",
                        observacionActual,
                        usuarioActual
                    );
                }

                FinalizeLoader();
                ShowModalDialog('Datos Guardados, radicador ' + datosGuardados.Data.numradicadortec, false, 'success', '', 0);  
                RefreshDataTableDecVie_RadicadorTec();
                CerrarDecVie_RadicadorTecDesdeEdicion();   
                $('#txtobservaciones_DecVie_RadicadorTec').val('');
            } else {
                console.warn("✗ datosGuardados.Ok es false", datosGuardados);
            }
        })

        .catch(err => {
            console.error("✗ ERROR en ValidatePostUpdateModel_EdicionForm_Data2:", err);
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        });
}


function CargarHistorialAuditoria(idRadicado) {
    // Limpiar tabla
    $("#tablaHistorialAuditoria tbody").empty();

    fetch(urlController + "DecVie_RadicadorTecAuditoria/GetHistorialByRadicador?id_decvieradicadortec=" + idRadicado, {
        method: "GET",
        headers: { "Authorization": "Bearer " + TokenIRIS }
    })
    .then(resp => resp.json())
    .then(data => {
        if (data.Ok && data.Data && data.Data.length > 0) {
            data.Data.forEach(row => {
                let texto = "";
                if (row.tipo_cambio === "ESTADO") {
                    texto = `El usuario <b>${row.usuario}</b> ha cambiado el estado a <b>${row.valor_nuevo}</b>`;
                } else if (row.tipo_cambio === "OBSERVACION") {
                    texto = `El usuario <b>${row.usuario}</b> ha cambiado la observación: ${row.valor_nuevo}`;
                }
                $("#tablaHistorialAuditoria tbody").append(`
                    <tr>
                        <td>${row.fecha_cambio.replace("T", " ").slice(0, 16)}</td>
                        <td>${texto}</td>
                    </tr>
                `);
            });
        } else {
            $("#tablaHistorialAuditoria tbody").append('<tr><td colspan="2"><i>Sin historial</i></td></tr>');
        }
    })
    .catch(err => {
        $("#tablaHistorialAuditoria tbody").append('<tr><td colspan="2">Error cargando historial</td></tr>');
        console.error(err);
    });
}


function GuardarAuditoriaRadicadorTec(idRadicador, tipoCambio, valorNuevo, usuarioCambio) {
    const payload = {
        id_decvieradicadortec: idRadicador,
        tipo_cambio: tipoCambio,
        valor_nuevo: valorNuevo,
        usuario: usuarioCambio,
        fecha_cambio: (new Date()).toISOString().slice(0, 19)
    };
    console.log("→ GuardarAuditoriaRadicadorTec POST", payload);

    fetch(urlController + "DecVie_RadicadorTecAuditoria/InsertAuditoria", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + TokenIRIS
        },
        body: JSON.stringify(payload)
    })
    .then(resp => {
        console.log("← Respuesta bruta InsertAuditoria:", resp);
        return resp.json();
    })
    .then(data => {
        console.log("← Respuesta JSON InsertAuditoria:", data);
        if (data.Ok) {
            CargarHistorialAuditoria(idRadicador); // recarga la tabla
        } else {
            console.warn("✗ No Ok en respuesta de InsertAuditoria", data);
        }
    })
    .catch(err => {
        console.error("✗ ERROR en GuardarAuditoriaRadicadorTec:", err);
    });
}




function AsignarValoresFormulario(datos) {
    console.log('Asignando valores al formulario...');

    // Fecha
    const fechaFormateada = datos.fecha ? datos.fecha.slice(0, 16) : '';
    console.log('Fecha formateada:', fechaFormateada);
    document.getElementById('dtfecha_DecVie_RadicadorTec').value = fechaFormateada;

    // Dependencia
    console.log('Dependencia:', datos.id_depend);
    $('#cboid_depend_DecVie_RadicadorTec').val(datos.id_depend).trigger('change');

    // Prefijo
    // Validar opciones del select Prefijo
    console.log('Opciones disponibles en Prefijo:', $('#cboid_prefijoconsecutivo_DecVie_RadicadorTec').html());

    // Validar y asignar Prefijo
    const prefijoId = datos.id_prefijoconsecutivo;
    console.log('Asignando Prefijo con ID:', prefijoId);
    if (!$('#cboid_prefijoconsecutivo_DecVie_RadicadorTec option[value="' + prefijoId + '"]').length) {
        console.warn('El prefijo no está en las opciones. Añadiendo manualmente.');
        $('#cboid_prefijoconsecutivo_DecVie_RadicadorTec').append(
            `<option value="${prefijoId}">${datos.Objprefijo?.nmprefijo || 'Sin Nombre'}</option>`
        );
    }
    // Radicador
    console.log('Radicador:', datos.numradicadortec);
    document.getElementById('txtnumradicadortec_DecVie_RadicadorTec').value = datos.numradicadortec;

    // Concepto
    console.log('Concepto:', datos.id_decvieconcepto);
    $('#cboid_decvieconcepto_DecVie_RadicadorTec').val(datos.id_decvieconcepto).trigger('change');

    // Folios
    console.log('Folios:', datos.nfolios);
    document.getElementById('nmnfolios_DecVie_RadicadorTec').value = datos.nfolios;

    // Procedencia
    console.log('Procedencia:', datos.tsersubserdocu);
    document.getElementById('txttsersubserdocu_DecVie_RadicadorTec').value = datos.tsersubserdocu;

    // Asunto
    console.log('Asunto:', datos.asunto);
    document.getElementById('txtasunto_DecVie_RadicadorTec').value = datos.asunto;

    // Otro Asunto
    console.log('Otro Asunto:', datos.otroasunto);
    document.getElementById('txtotroasunto_DecVie_RadicadorTec').value = datos.otroasunto;

    // DNI
    console.log('DNI:', datos.dni);
    document.getElementById('txtdni_DecVie_RadicadorTec').value = datos.dni;

    // Personas Relacionadas
    console.log('Personas Relacionadas:', datos.personasrelacionadas);
    document.getElementById('txtpersonasrelacionadas_DecVie_RadicadorTec').value = datos.personasrelacionadas;

     // //SE AÑADE CAMBIO ADDA VARGAS 28 DE JULIO 2025
    // Dependencia Destino
    // Dependencia Destino y Responsable
    $('#cbodependenciadestino_DecVie_RadicadorTec').val(datos.dependenciadestino).trigger('change');
    setTimeout(() => {
        FiltrarFuncionariosPorDependencia(datos.dependenciadestino);
        setTimeout(() => {
            $('#cboidfuncionario_DecVie_RadicadorTec').val(datos.idfuncionario).trigger('change');
        },);
    },);

    // Observaciones
    //console.log('Observaciones:', datos.observaciones);
    //document.getElementById('txtobservaciones_DecVie_RadicadorTec').value = datos.observaciones;

    // Interno (TC)
    console.log('Interno:', datos.interno);
    document.getElementById('chkinterno_DecVie_RadicadorTec').checked = datos.interno;

    // Externo (Derecho Petición)
    console.log('Externo:', datos.externo);
    document.getElementById('chkexterno_DecVie_RadicadorTec').checked = datos.externo;

    // Responsable
    // Dependencia Destino y Responsable
    $('#cbodependenciadestino_DecVie_RadicadorTec').val(datos.dependenciadestino).trigger('change');
    FiltrarFuncionariosPorDependencia(datos.dependenciadestino, function() {
        // Aquí SÍ puedes asignar el responsable porque el select ya está lleno
        $('#cboidfuncionario_DecVie_RadicadorTec').val(datos.idfuncionario).trigger('change');
    });

    //cambio realizado 28 de julio
    // $('#cboidfuncionario_DecVie_RadicadorTec').val(datos.idfuncionario).trigger('change');
    // Fecha de Vencimiento (si existe en el objeto datos)
    document.getElementById('dtfecha_vencimiento_DecVie_RadicadorTec').value = datos.fecha_vencimiento ? datos.fecha_vencimiento.slice(0, 10) : '';

    // Estado (Macroproceso)
    console.log('Estado (id_decviemacroproceso):', datos.id_decviemacroproceso);
    $('#cboid_decviemacroproceso_DecVie_RadicadorTec').val(datos.id_decviemacroproceso).trigger('change');


    // Fecha de envío a dependencia
    const fechaEnvioFormateada = datos.recibido_dependencia ? datos.recibido_dependencia.slice(0, 10) : '';
    console.log('Fecha Envio:', fechaEnvioFormateada);
    document.getElementById('dtrecibido_dependencia_DecVie_RadicadorTec').value = fechaEnvioFormateada;

    console.log('Valores asignados al formulario.');
}


function CargarPrefijosDependencia_RadicadorTecDtalle() {
    let iddependenciaRadicadorTec = $('#cboid_depend_DecVie_RadicadorTec').val();

    if (!iddependenciaRadicadorTec) {
        console.warn('El valor de id_dependenciaRadicadorTec está vacío. No se realiza ninguna acción.');
        return; // Detén la ejecución si el valor es inválido
    }

    console.log('Cargando prefijos para la dependencia:', iddependenciaRadicadorTec);

    LoadCorrespondencia_PrefijoConsecutivoByDependenciaSelect(
        'cboid_prefijoconsecutivo_DecVie_RadicadorTec',
        true,
        iddependenciaRadicadorTec
    );
}


function GenerarRadicadorTecDctoDependencia(controlfecha, controlidprefijo, controlprefijo) {
    let fecharadicadortec = $('#' + controlfecha).val();
    let id_prefijoconsecutivo = $('#' + controlidprefijo).val();

    if (id_prefijoconsecutivo == undefined){
        return;
    }

    let urldatos = urlController + "Consecutivo_Annio/GetConsecutivo_Annio?id_prefijoconsecutivo=" + id_prefijoconsecutivo + "&fecha=" + fecharadicadortec;    
  
    return new Promise( (resolve, reject) => {
      fetch(urldatos, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
        .then(data => {
            if (data.Ok) {
                $('#' + controlprefijo).val(data.Data);
                
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


//Se AÑADE EL 28 DE JULIO DEL 2025 POR CAMBIO SOLICITADO EN SECRETARIA

function FiltrarFuncionariosPorDependencia(idDependenciaSeleccionada, callback) {
    const selectFuncionarios = $('#cboidfuncionario_DecVie_RadicadorTec');
    selectFuncionarios.empty();

    // Siempre agregar "Sin especificar"
    selectFuncionarios.append(`<option value="3">Sin especificar</option>`);

    if (!idDependenciaSeleccionada || idDependenciaSeleccionada === '') {
        selectFuncionarios.empty();
        selectFuncionarios.append(`<option value="3">Sin especificar</option>`);
        if (typeof callback === 'function') callback();
        return;
    }

    // Si la dependencia es "Sin asignar" (27), no cargues más
    if (parseInt(idDependenciaSeleccionada) === 27) {
        if (typeof callback === 'function') callback();
        return;
    }

    fetch(urlController + 'Funcionario/GetFuncionariosPorDependencia?id_depend=' + idDependenciaSeleccionada, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
    .then(data => {
        if (data.Ok && Array.isArray(data.Data)) {
            data.Data.forEach(func => {
                if (func.idfuncionario !== 3) {
                    selectFuncionarios.append(
                        `<option value="${func.idfuncionario}">${func.nombres} ${func.apellidos}</option>`
                    );
                }
            });
        }
        // <-- Ejecuta callback SÓLO después de llenar el select
        if (typeof callback === 'function') callback();
    })
    .catch(err => {
        console.error('Error cargando funcionarios:', err);
        if (typeof callback === 'function') callback();
    });
}


function AsignarDependenciaPorFuncionario(idFuncionarioSeleccionado) {
    if (parseInt(idFuncionarioSeleccionado) === 3) {
        console.log("Funcionario 'Sin especificar', no se asigna dependencia.");
        return;
    }

    fetch(urlController + 'Funcionario/GetFuncionarioDetails?idfuncionario=' + idFuncionarioSeleccionado, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })

    .then(response => response.json())
    .then(data => {
        if (data.Ok && data.Data) {
            const idDepend = data.Data.id_depend;
            console.log('Asignando dependencia:', idDepend);
            $('#cbodependenciadestino_DecVie_RadicadorTec').val(idDepend).trigger('change');
        } else {
            console.warn('No se encontró el funcionario.');
        }
    })
    .catch(err => {
        console.error('Error consultando funcionario:', err);
    });
}


// --- Lista de festivos Colombia 2024/2025 (añade los que necesites)
const festivosColombia = [
    "2024-01-01", "2024-01-08", "2024-03-25", "2024-03-28", "2024-03-29", "2024-05-01", "2024-05-13",
    "2024-06-03", "2024-06-10", "2024-07-01", "2024-07-20", "2024-08-07", "2024-08-19",
    "2024-10-14", "2024-11-04", "2024-11-11", "2024-12-08", "2024-12-25",
    // --- 2025 (añade según el calendario oficial)
    "2025-01-01", "2025-01-06", "2025-03-24", "2025-04-17", "2025-04-18", "2025-05-01", "2025-06-02",
    "2025-06-23", "2025-07-20", "2025-08-07", "2025-08-18", "2025-10-13", "2025-11-03", "2025-11-17",
    "2025-12-08", "2025-12-25"
];

// --- Función para sumar N días hábiles (lunes a viernes, excluyendo festivos)
function sumarDiasHabilesConFestivos(fechaStr, diasHabiles, festivos) {
    let fecha = new Date(fechaStr);
    let sumados = 0;
    while (sumados < diasHabiles) {
        fecha.setDate(fecha.getDate() + 1);

        // Si no es sábado (6) ni domingo (0)
        if (fecha.getDay() !== 0 && fecha.getDay() !== 6) {
            // YYYY-MM-DD
            const fechaFormateada = fecha.toISOString().slice(0, 10);
            if (!festivos.includes(fechaFormateada)) {
                sumados++;
            }
        }
    }
    // Devuelve YYYY-MM-DD (para input type="date")
    return fecha.toISOString().slice(0, 10);
}


