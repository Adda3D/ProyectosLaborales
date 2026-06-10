var DataTableProyectoInvestigacionResoluciones = null;
var ObjModelProyectoInvestigacionResoluciones = null;

$(document).ready(function () {
    ObjModelProyectoInvestigacionResoluciones = new Investigacion_Resolucion();

    InicializaProyectoInvestigacionResolucionesform();
});

function InicializaProyectoInvestigacionResolucionesform() {
    $("#txtHermesPRJINVResoluciones").val($("#spanHermesProyectoInvestigacion")[0].innerText);
    $("#txtQuipuPRJINVResoluciones").val($("#spanQuipuProyectoInvestigacion")[0].innerText);
    $("#txtNombrePRJINVResoluciones").val($("#spanNombreProyectoInvestigacion")[0].innerText);

    if (DataTableProyectoInvestigacionResoluciones != null) {
        DataTableProyectoInvestigacionResoluciones.destroy();
    }

    LoadDataTableProyectoInvestigacionResoluciones();

    $("#dvProyectoInvestigacionTable").addClass("ocultar");
    $("#dvProyectoInvestigacionTablaResoluciones").removeClass("ocultar");
}

function VolverTablaProyectoInvestigacionDesdeResolucionesForm() {
    $("#dvProyectoInvestigacionTablaResoluciones").addClass("ocultar");
    $("#dvProyectoInvestigacionTable").removeClass("ocultar");
}

function CerrarProyectoInvestigacionResolucionesDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelProyectoInvestigacionResoluciones);
}




// function LoadDataTableProyectoInvestigacionResoluciones() {
//     DataTableProyectoInvestigacionResoluciones = $('#tblProyectoInvestigacionResoluciones').DataTable({
//         "language": {
//             "url": "/lib/dataTables/Language.json"
//         },
//         serverSide: true,
//         processing: true,
//         "ajax": {
//             "url": urlController + "Investigacion_Resolucion/GetDataTableInvestigacion_ResolucionByProyecto",
//             "data": function(d) {
//                 d.id_crearproyecto = $("#spanIdProyectoInvestigacion").text();
//             },
//             "dataSrc": function(json) {
//                 console.log('Datos recibidos del backend:', json);
//                 return json.data || [];
//             }
//         },
//         "columns": [
//             { "data": "resolucion" },
//             { "data": "valor" },
//             {
//                 "render": function (data, type, row, meta) {
//                     return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarProyectoInvestigacionResoluciones(' + row.id_proyectoresolucion + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoInvestigacionResoluciones" /> ' +
//                            '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Resolución" onclick="ValidarEliminarProyectoInvestigacionResoluciones(' + row.id_proyectoresolucion + ');" /> ';
//                 },
//                 "className": "text-center", "orderable": false
//             }
//         ]
//     });
// }

function LoadDataTableProyectoInvestigacionResoluciones() {
    DataTableProyectoInvestigacionResoluciones = $('#tblProyectoInvestigacionResoluciones').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "ajax": {
            "url": urlController + "Investigacion_Resolucion/GetDataTableInvestigacion_ResolucionByProyecto",
            "data": function (d) {
                d.id_crearproyecto = $("#spanIdProyectoInvestigacion").text();
                console.log("Datos enviados al servidor:", d);  // Verifica los datos que se envían al backend
            },
            "dataSrc": function (json) {
                console.log('Datos recibidos del backend:', json);  // Verifica los datos recibidos del backend
                return json.data || [];
            },
            "error": function (xhr, status, error) {
                console.log("Error en la solicitud AJAX:", status, error);
                console.log("Detalles del error:", xhr.responseText);  // Muestra el contenido de la respuesta del servidor
            }

        },
        // "columns": [
        //     { "data": "numresolucion", "title": "Número de Resolución" },  // Directamente desde el DTO
        //     { "data": "valor" },
        //     {
        //         "render": function (data, type, row, meta) {
        //             return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarProyectoInvestigacionResoluciones(' + row.id_proyectoresolucion + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoInvestigacionResoluciones" /> ' +
        //                 '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Resolución" onclick="ValidarEliminarProyectoInvestigacionResoluciones(' + row.id_proyectoresolucion + ');" /> ';
        //         },
        //         "className": "text-center", "orderable": false
        //     }
        // ]

        "columns": [
                { "data": "numresolucion", "title": "Número de Resolución" },
                { "data": "valor" },
                {
                    "render": function (data, type, row, meta) {
                        return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarProyectoInvestigacionResoluciones(' + row.id_proyectoresolucion + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectoInvestigacionResoluciones" /> ' +
                            '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Resolución" onclick="ValidarEliminarProyectoInvestigacionResoluciones(' + row.id_proyectoresolucion + ');" /> ';
                    },
                    "className": "text-center", "orderable": false
                }
            ]


    });
}




function RefreshDataTableProyectoInvestigacionResoluciones() {
    DataTableProyectoInvestigacionResoluciones.ajax.reload(null, false);
}

function CrearProyectoInvestigacionResoluciones() {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionResoluciones)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoInvestigacionResoluciones)
                .then(datospreparados => {
                    if (datospreparados) {
                        //$("#txtid_proyectoresolucion_Investigacion_Resolucion").val('');
                        $("#txtid_crearproyecto_Investigacion_Resolucion").val($("#spanIdProyectoInvestigacion")[0].innerText);
                        FinalizeLoader();
                    }
                })
                .catch(err => {
                    FinalizeLoader();
                    ShowModalDialog(err, false, 'error', '', 0);
                })
        })
        .catch(err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })
}

function CrearProyectoInvestigacionResoluciones1() {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionResoluciones)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectoInvestigacionResoluciones)
                .then(datospreparados => {
                    if (datospreparados) {
                        $("#txtid_proyectoresolucion_Investigacion_Resolucion").val('');
                        $("#txtid_crearproyecto_Investigacion_Resolucion").val($("#spanIdProyectoInvestigacion")[0].innerText);
                        FinalizeLoader();
                    }
                })
                .catch(err => {
                    FinalizeLoader();
                    ShowModalDialog(err, false, 'error', '', 0);
                })
        })
        .catch(err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })
}

function EditarProyectoInvestigacionResoluciones(idproyectoresolucion) {

    CreateHTMLFromModel(ObjModelProyectoInvestigacionResoluciones)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelProyectoInvestigacionResoluciones, idproyectoresolucion)
                .then(datoscargados => {
                    if (datoscargados) {
                        FinalizeLoader();
                    }
                })
                .catch(err => {
                    FinalizeLoader();
                    ShowModalDialog(err, false, 'error', '', 0);
                })
        })
        .catch(err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })

}

function ValidatePostUpdateProyectoInvestigacionResolucionesForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectoInvestigacionResoluciones)
        .then(datosGuardados => {
            if (datosGuardados) {
                FinalizeLoader();

                for (var i = 0; i < 2; i++) {
                    $('#' + botonClose).click();
                }

                CerrarProyectoInvestigacionResolucionesDesdeEdicion();

                RefreshDataTableProyectoInvestigacionResoluciones();
            }
        })
        .catch(err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })

}

function ValidarEliminarProyectoInvestigacionResoluciones(IdResolucion) {
    ShowDialogConfirmacion('', 'Seguro de eliminar datos Resolución ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectoInvestigacionResoluciones(IdResolucion);
            }
        });

}

function EliminarProyectoInvestigacionResoluciones(IdResolucion) {
    let urlEliminar = urlController + "Investigacion_Resolucion/DeleteInvestigacion_Resolucion?id_proyectoresolucion=" + IdResolucion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
        .then(response => response.json())
        .then(data => {
            if (data.Ok) {
                FinalizeLoader();
                RefreshDataTableProyectoInvestigacionResoluciones();
                return;
            }
            else {
                FinalizeLoader();
                ShowModalDialog(data.Message, false, 'warning', '', 0);
                return;
            }
        })
        .catch(err => {
            ShowModalDialog(err, false, 'error', '', 0);
        });

}

