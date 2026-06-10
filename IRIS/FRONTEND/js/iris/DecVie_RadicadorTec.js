
var DataTableDecVie_RadicadorTec = null;


//Cambio realizado el 28 de julio
$(document).ready(function () {
    // Recuperar el username que debiste guardar después del login
    let usuario = sessionStorage.getItem("usuario");
    if (!usuario) {
        // Si no existe, redirigir a login o mostrar mensaje
        alert("No se detectó usuario logueado. Por favor, inicia sesión.");
        window.location.href = "/login.html"; // Cambia si tu ruta es diferente
        return;
    }

    // Ahora sí, pide el idfuncionario a la API usando el username guardado
    fetch(urlController + 'Funcionario/GetIdFuncionarioByUsuario?usuario=' + usuario, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
    .then(data => {
        if (data.Ok && data.Data && data.Data.idfuncionario) {
            window.FuncionarioActualID = data.Data.idfuncionario;
            // Carga la tabla filtrando por responsable
            LoadDataTableDecVie_RadicadorTec();
        } else {
            alert("No se pudo obtener el idfuncionario para este usuario.");
        }
    })
    .catch(err => {
        console.error('Error obteniendo funcionario:', err);
        alert("Error obteniendo funcionario.");
    });
});


function VerTodos() {
    window.FuncionarioActualID = null;
    RefreshDataTableDecVie_RadicadorTec();
}


function ObtenerFuncionarioActual() {
    return fetch(urlController + 'Funcionario/GetFuncionarioSesion', {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
    .then(data => {
        if (data.Ok && data.Data && data.Data.idfuncionario) {
            return data.Data.idfuncionario;
        } else {
            console.warn('No se pudo obtener el funcionario actual.');
            return null;
        }
    })
    .catch(err => {
        console.error('Error obteniendo funcionario de sesión:', err);
        return null;
    });
}


function LoadDataTableDecVie_RadicadorTec() {
    DataTableDecVie_RadicadorTec = $('#tblDecVie_RadicadorTec').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_RadicadorTec/GetDataTableDecVie_RadicadorTecPrueba",
            "type": "GET",
            "headers": { 'Authorization': 'Bearer ' + TokenIRIS },
            "data": function (d) {
                d.filtroFuncionario = window.FuncionarioActualID;
            }
        },

        "columns": [
            { "data": "id_decvieradicadortec", "orderable": true }, // ID
            { 
                "data": "fecha", 
                "orderable": true, 
                render: function (data, type, row, meta) {
                    // Mismo enfoque que en consecutivos: corta la fecha al formato YYYY-MM-DD
                    return row.fecha.slice(0, 10); 
                } 
            }, // Fecha
            { "data": "numradicadortec", "orderable": true }, // Radicado
            { "data": "asunto", "orderable": true }, // Asunto
            { "data": "tsersubserdocu", "orderable": false }, // Solicitante
            { "data": "fecha_vencimiento", 
                "orderable": true, 
                render: function(data, type, row) {
                    return data ? data.slice(0, 10) : '';}
                }, 
            {
                "data": "id_decviemacroproceso",       // <-- AQUÍ
                "orderable": true,
                "render": function(data, type, row) {
                    var estado = (data || '').trim().toUpperCase();
                    var color = "";

                    if (estado === "COMPLETADO") {
                        // Completado siempre verde
                        color = "background-color: #51cb6c; color: white;";
                    } else if (estado === "EN TRAMITE") {
                        // Si es EN TRAMITE, revisa si está por vencerse
                        if (row.fecha_vencimiento) {
                            var hoy = new Date();
                            var vencimiento = new Date(row.fecha_vencimiento);
                            // Normaliza hora a 00:00:00 para ambos
                            hoy.setHours(0,0,0,0); vencimiento.setHours(0,0,0,0);
                            var diffMs = vencimiento - hoy;
                            var diffDias = Math.ceil(diffMs / (1000 * 60 * 60 * 24));
                            if (diffDias <= 2) {
                                color = "background-color: #fa4c4c; color: white;"; // Rojo
                            } else {
                                color = "background-color: #ffb703; color: black;"; // Naranja
                            }
                        } else {
                            color = "background-color: #ffb703; color: black;"; // Naranja default
                        }
                    } else if (estado === "TRAMITADO") {
                        // Si es EN TRAMITE, revisa si está por vencerse
                        if (row.fecha_vencimiento) {
                            var hoy = new Date();
                            var vencimiento = new Date(row.fecha_vencimiento);
                            // Normaliza hora a 00:00:00 para ambos
                            hoy.setHours(0,0,0,0); vencimiento.setHours(0,0,0,0);
                            var diffMs = vencimiento - hoy;
                            var diffDias = Math.ceil(diffMs / (1000 * 60 * 60 * 24));
                            if (diffDias <= 2) {
                                color = "background-color: #fa4c4c; color: white;"; // Rojo
                            } else {
                                color = "background-color: #9ec70cff; color: black;"; // Naranja
                            }
                        } else {
                            color = "background-color: #9ec70cff; color: black;"; // Naranja default
                        }
                    } else if (estado === "RADICADO") {
                        // Si es EN TRAMITE, revisa si está por vencerse
                        if (row.fecha_vencimiento) {
                            var hoy = new Date();
                            var vencimiento = new Date(row.fecha_vencimiento);
                            // Normaliza hora a 00:00:00 para ambos
                            hoy.setHours(0,0,0,0); vencimiento.setHours(0,0,0,0);
                            var diffMs = vencimiento - hoy;
                            var diffDias = Math.ceil(diffMs / (1000 * 60 * 60 * 24));
                            if (diffDias <= 2) {
                                color = "background-color: #fa4c4c; color: white;"; // Rojo
                            } else {
                                color = "background-color: #51a4cbff; color: black;"; // Naranja
                            }
                        } else {
                            color = "background-color: #51a4cbff; color: black;"; // Naranja default
                        } 
                    }else if (estado === "A PUNTO DE VENCER") {
                        // Completado siempre verde
                        color = "background-color: #fa4c4c; color: white;";
                    }

                    return '<span style="' + color + ' padding: 3px 8px; border-radius: 5px;">' + (data || '') + '</span>';
                }

            },
                    { "data": "usuariocreacion", "orderable": false }, // Responsable Radicador
            {  "data": "NombreDependencia", "orderable": false},
            
            {
                render: function (data, type, row, meta) {
                    // Opciones de edición y eliminación
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_RadicadorTec(' + row.id_decvieradicadortec + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_RadicadorTec(' + row.id_decvieradicadortec + ',`' + row.numradicadortec + '`);" />';
                },
                "className": "text-center", 
                "orderable": false
            }
        ],
        "columnDefs": [
            { 
                "targets": 2,
                render: function (data, type, full, meta) {
                    return type === 'display' ? '<div title="' + full.numradicadortec + '">' + data : data;
                }
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]] // Configuración de paginación
    });
}


function LoadDecvieconceptoRadicador() {
    return new Promise((resolve) => {
        var select = $('#cboid_decvieconcepto_DecVie_RadicadorTec');
        select.append('<option value="CORREO ELECTRONICO">CORREO ELECTRONICO</option>');
        // select.append('<option value="VERIFICACION">VERIFICACION</option>');
        // select.append('<option value="CERTIFICADO">CERTIFICADO</option>');
        select.append('<option value="SIN ASIGNAR">SIN ASIGNAR</option>');

        resolve(); // Indica que la tarea se completó.
    });
}

function LoadDecvieEstadoRadicador() {
    return new Promise((resolve) => {
        var select = $('#cboid_decviemacroproceso_DecVie_RadicadorTec');
        select.empty(); 
        select.append('<option value="RADICADO">RADICADO</option>');
        select.append('<option value="EN TRAMITE">EN TRAMITE</option>');
        select.append('<option value="A PUNTO DE VENCER">A PUNTO DE VENCER</option>');
        select.append('<option value="TRAMITADO">TRAMITADO</option>');
        select.append('<option value="COMPLETADO">COMPLETADO</option>');
        
        resolve(); // Indica que la tarea se completó.
    });
}


function RefreshDataTableDecVie_RadicadorTec() {
    DataTableDecVie_RadicadorTec.ajax.reload(null, false);
}

function ValidarEliminarDecVie_RadicadorTec(iddecvieradicadortec, numradicadortec) {
    ShowDialogConfirmacion('','Seguro de eliminar el radicador ' + numradicadortec + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_RadicadorTec(iddecvieradicadortec);
            }
        });
}

function EliminarDecVie_RadicadorTec(iddecvieradicadortec) {
    let urlEliminar = urlController + "DecVie_RadicadorTec/DeleteDecVie_RadicadorTec?id_decvieradicadortec=" + iddecvieradicadortec;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_RadicadorTec();
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

function CrearDecVie_RadicadorTec() {
    $("#spanIdDecVie_RadicadorTec")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_RadicadorTecDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_RadicadorTecDetalle.html', 'dvDecVie_RadicadorTecDetalle');
    }
    else {
        CrearDecVie_RadicadorTecform();
    }
}

function EditarDecVie_RadicadorTec(iddecvieradicadortec) {
    $("#spanIdDecVie_RadicadorTec")[0].innerText = iddecvieradicadortec;
    
    if (!ExisteDivEdicionDatos('dvDecVie_RadicadorTecDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_RadicadorTecDetalle.html', 'dvDecVie_RadicadorTecDetalle');
    }
    else {
        EditarDecVie_RadicadorTecform(iddecvieradicadortec);
    }
}
