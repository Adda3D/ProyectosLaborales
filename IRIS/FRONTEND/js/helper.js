// URL para consumir los servicios
var urlController = 'https://iris.unal.edu.co/APIirisunal/';
var urlDownload = 'https://iris.unal.edu.co';
var urlServer = location.origin;
var TokenIRIS = '83e909a2-81b2-4595-bbd9-e0ddf6a479e0';

// Variables utilizadas en el proyecto
var url;
var nombreItem;
var isPostBack = false;
var form;
var checkValiditySelect = true;
var checkValidityXSS = true;
var ObjData;
var selectPais;
var selectDepartamento;
var HabNorInterNIIFData;
var contTable = 0;
var nameTable;
var service;
var columns;
var nameTableNotaContabilidad;
var nameTableNotaContabilidadTrans;
var divContainerHTML = '';

var TipoModal = {
    Confirmacion: { Id: 1, Title: 'Confirmacion' },
    Error: { Id: 2, Title: 'Error' },
}

var TipoPersona = {
    Natural: { Id: "N", Title: 'Natural' },
    Juridica: { Id: "J", Title: 'Juridica' },
}

// CADA ITEM TIENE 4 OBJETOS
// ID DEL REGISTRO EN SQL
// TITULO DEL FORMULARIO TAL CUAL COMO ESTA EN LA BASE DE DATOS
// URL DEL HTML DEL FORMULARIO
// ID DE UN DIV CONTENEDOR PRINCIPAL DEL FORMULARIO
var MenuItems = {
    Configuracion: { Id: 100, Title: 'Configuracion', Url: '' },
    Area_Academica: { Id: 101, Title: 'Configuración Empresa', Url: 'ConfiguracionEmpresa.html', DivCont: 'divConfigEmpresaHTML' },
    Tipo_Persona: { Id: 102, Title: 'Paises', Url: 'Paises.html', DivCont: 'divPaisesHTML' },
    Persona_Formacion: { Id: 103, Title: 'Departamentos', Url: 'Estados.html', DivCont: 'divEstadosHTML' },
    Persona_TituloAlto: { Id: 104, Title: 'Ciudades', Url: 'Ciudades.html', DivCont: 'divCiudadesHTML' },
    Persona_Calificacion: { Id: 105, Title: 'Saludo', Url: 'Saludo.html', DivCont: 'divSaludoHTML' },
    Semestre: { Id: 105, Title: 'Semestre', Url: 'Semestre.html', DivCont: 'divSemestreHTML' },
    Literal_UGI: { Id: 106, Title: 'Literal UGI', Url: 'LiteralUGI.html', DivCont: 'divLiteralUGIHTML' },
    Concepto_UGI: { Id: 107, Title: 'Concepto UGI', Url: 'ConceptoUGI.html', DivCont: 'divConceptoUGIHTML' },
    Propuesta_Modalidad: { Id: 108, Title: 'Propuesta Modalidad', Url: 'PropuestaModalidad.html', DivCont: 'divPropuestaModalidadHTML' },
    Propuesta_OrigenPropuesta: { Id: 109, Title: 'Origen Propuesta', Url: 'OrigenPropuesta.html', DivCont: 'divOrigenPropuestaHTML' },
    Propuesta_TipoPropuesta: { Id: 110, Title: 'Tipo Propuesta', Url: 'TipoPropuesta.html', DivCont: 'divTipoPropuestaHTML' },
    SemePropuesta_EstadoPropuestastre: { Id: 111, Title: 'Estado Propuesta', Url: 'EstadoPropuesta.html', DivCont: 'divEstadoPropuestaHTML' },
    Propuesta_TipoModificacion: { Id: 112, Title: 'Propuesta Tipo Modificacion', Url: 'PropuestaTipoModificacion.html', DivCont: 'divPropuestaTipoModificacionTML' },
    Proyectos_TipoProyecto: { Id: 113, Title: 'Tipo Proyecto', Url: 'TipoProyecto.html', DivCont: 'divTipoProyectoHTML' },
    Proyectos_NaturalezaProyecto: { Id: 114, Title: 'Naturaleza Proyecto', Url: 'NaturalezaProyecto.html', DivCont: 'divNaturalezaProyectoHTML' },
    Proyectos_EstadoObligacion: { Id: 115, Title: 'Estado Obligacion', Url: 'EstadoObligacion.html', DivCont: 'divEstadoObligacionHTML' },
    Proyectos_EstadoContrato: { Id: 116, Title: 'Estado Contrato', Url: 'EstadoContrato.html', DivCont: 'divEstadoContratoHTML' },

    Seguridad: { Id: 110, Title: 'Seguridad', Url: '' },
    RolesUsuario: { Id: 111, Title: 'Roles Usuario', Url: 'RolesUsuario.html', DivCont: 'divRolesUsuarioHTML' },
    Usuarios: { Id: 112, Title: 'Usuarios', Url: 'Usuarios.html', DivCont: 'divUsuariosHTML' },

}


// SE EJECUTA CUANDO CARGA UNA PAGINA
Pace.on("start", function () {
    StartLoaderPage();
});

// SE EJECUTA CUANDO TEERMINAN DE CARGAR LAS FUNCIONES DE UNA PAGINA
Pace.on("done", function () {
    setTimeout(function () {
        FinalizeLoaderPage();
    }, 1000);
});

$(document).ready(function () {
  //  GetInputSecurityGeneral();
});

// Ejecuta la animación de cargar
function StartLoader() {
    $('#dvLoader').css('display', 'block');
    //var $dvLoader = $('div#dvLoader').html('<p><img src="../images/loader1.gif" /></p>');
}

function StartLoaderPage() {
    //$('#dvLoaderPage').css('display', 'block');
    var $dvLoader = $('div#dvLoaderPage').html('<p><img src="../images/loader1.gif" /></p>');
}

// Finaliza la animación de cargar
function FinalizeLoader() {
    //$("#dvLoader").empty();
    $('#dvLoader').css('display', 'none');
}

function FinalizeLoaderPage() {
    //$("#dvLoaderPage").empty();
    $('#dvLoaderPage').css('display', 'none');
}

function getParameterUrlByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function ShowModalDialog(Message, Recharge, tipoModal,Titulo, Toast) {    
    icono = 'success';

    icono = tipoModal;
/*
    switch (tipoModal) {
        case 1:
            icono = 'info';
            break;
        case 2:
            icono = 'error';
            break;
        case 3:
            icono = 'info';
            break;
        case 4:
            icono = 'question';
            break;
        case 5:
            icono = 'warning';
            break;                
    }
*/    
    swal.fire({
        title: Titulo,
        text: Message,
        icon: icono,
        confirmButtonText: "Aceptar",
    });
    
}

function ShowDialogConfirmacion(titulo, texto, textobotonconfirma, textobotoncancela) {
    
    return new Promise( (resolve) => {
        Swal.fire({
            title: titulo,
            text: texto,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: textobotonconfirma,
            cancelButtonText: textobotoncancela,
        })
        .then(resultado => {
            resolve(resultado.isConfirmed);
        }); 
    });    

}

function ShowModalDialogDataTable(Message, Recharge, tipoModal, nameTable) {
    type = BootstrapDialog.TYPE_PRIMARY;
    titulo = 'Información';

    switch (tipoModal) {
        case 1:
            type = BootstrapDialog.TYPE_PRIMARY;
            titulo = 'Información';
            break;
        case 2:
            type = BootstrapDialog.TYPE_DANGER;
            titulo = 'Advertencia';
            break;
        case 3:
            type = BootstrapDialog.TYPE_INFO;
            titulo = 'Información';
            break;
        case 4:
            type = BootstrapDialog.TYPE_SUCCESS;
            titulo = 'Información';
            break;
        case 5:
            type = BootstrapDialog.TYPE_WARNING;
            titulo = 'Advertencia';
            break;
        default:
            type = BootstrapDialog.TYPE_PRIMARY;
            titulo = 'Información';
            break;
    }

    if (TipoModal.Error.Id == tipoModal) {
        type = BootstrapDialog.TYPE_DANGER;
        titulo = 'Advertencia';
    }

    BootstrapDialog.show({
        type: type,
        title: titulo,
        message: Message,
        closable: false,
        buttons: [{
            label: 'Aceptar',
            cssClass: 'btn-primary',
            action: function (dialog) {
                var contModals = $('.modal.fade.show');
                
                if (contModals.length > 1) {
                    dialog.close();
                    setTimeout(function () {
                        $("body").addClass('modal-open');
                    }, 100);
                } else {
                    dialog.close();
                }

                if (Recharge) {
                    StartLoader();
                    $('#' + nameTable).DataTable().ajax.reload();
                }
            }
        }],
        onshown: function (dialog) {
            if (TipoModal.Error.Id == tipoModal) {
                $(".modal-dialog").addClass("modal-lg");
                $(".bootstrap-dialog-message").addClass("modalConfirmation");
            } else {
                FinalizeLoader();
            }
        },
    });
}

// Genera la tabla de la libreria DataTable con todas sus propiedades incluyendo el idioma a español
function GenerateTable(nameTable, service, columns, accion) {
    if (nameTable != '') {
        table = $('#' + nameTable).DataTable({
            "language": {
                "url": "../Content/Template/js/plugins/dataTables/Language.json"
            },
            serverSide: true,
            processing: true,
            "search": {
                "caseInsensitive": true
            },
            "ajax": {
                url: service,
            },
            "columns": columns,
            "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
            "initComplete": function (settings, json) {
                if (contTable == 0) {
                    if (accion == undefined) {
                        contTable++;
                        //GetItemsMenuPage(1);

                        $(".buttons-excel").addClass("ocultar");
                    }
                }
                $("table").css('width', '100%');

                switch (nombreItem) {
                    case MenuItems.NotaContabilidad.Title:
                        nameTableNotaContabilidad = table;
                        $('#dvNotaContabilidadGeneral #tblNotaContabilidad_filter input').unbind();
                        $('#dvNotaContabilidadGeneral #tblNotaContabilidad_filter input').bind('keyup', function (e) {
                            if (e.keyCode == 13) {
                                nameTableNotaContabilidad.search($(this).val()).draw();
                            }
                        });
                        break;
                }
                
                AddSelect2Forms();
                validateSelectOneSelect2();
            }
        });
        
        //setTimeout(function () {
        //    switch (nombreItem) {
        //        case MenuItems.NotaContabilidad.Title:
        //            $('#' + nameTable + '_filter input').unbind();
        //            $('#' + nameTable + '_filter input').bind('keyup', function (e) {
        //                if (e.keyCode == 13) {
        //                    table2.filter($(this).val());
        //                }
        //            });
        //            break;
        //    }
        //}, 3000);
    }
}

function GenTableSelectAutocomplete(nameTable, service, columns, accion) {
    if (nameTable != '') {
        table = $('#' + nameTable).DataTable({
            "language": {
                "url": "../Content/Template/js/plugins/dataTables/Language.json"
            },
            serverSide: true,
            processing: true,
            "search": {
                "caseInsensitive": true
            },
            "ajax": {
                url: service,
            },
            "columns": columns,
            "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
            "initComplete": function (settings, json) {
                if (contTable == 0) {
                    if (accion == undefined) {
                        contTable++;
                        //GetItemsMenuPage(1);

                        $(".buttons-excel").addClass("ocultar");
                        $("table").css('width', '100%');
                        setTimeout(function () {
                            if (nombreItem == MenuItems.CuentasBancarias.Title) {
                                crearComboboxAutocomplete('cbCuentaContable', 'Cuenta contable');
                                crearComboboxAutocomplete('cbCuentaPosfechado', 'Cuenta posfechado');

                                $('#dvCuentasBancos #cbBanco').select2();
                                $('#dvCuentasBancos #cbTipoCuenta').select2();
                                validateSelectOneSelect2();
                            } else if (nombreItem == MenuItems.PagosReciboCaja.Title) {
                                crearComboboxAutocomplete('cbCuentaBancoPagRecCaja', 'Cuenta banco');

                                $('#dvPagosReciboCaja #cbTipo').select2();
                                $('#dvPagosReciboCaja #cbEstado').select2();
                                validateSelectOneSelect2();
                            } else if (nombreItem == MenuItems.PagosComprobanteEgreso.Title) {
                                crearComboboxAutocomplete('cbCuentaBancoPagComprEgreso', 'Cuenta banco');

                                $('#dvPagosComprEgreso #cbTipo').select2();
                                $('#dvPagosComprEgreso #cbEstado').select2();
                                validateSelectOneSelect2();
                            } else if (nombreItem == MenuItems.NotaContabilidad.Title) {
                                crearComboboxAutocomplete('cbTipoModal', 'Tipo');

                                $('#cbImprimir').select2();
                                $('#cbCentroCosto').select2();
                                $('#cbOficina').select2();
                                validateSelectOneSelect2();
                            }
                        }, 1000);
                    }
                }
            }
        });
    }
}

//Crea el tab principal INICIO no se puede cerrar por el usuario
function TabInicio() {
    let idmenu = 0;
    let nombreItem = 'INICIO';
    let migapan = 'Inicio';
    let url = 'pages/inicio.html';

    var tabMenuLi = "<li class='liopcion liselected' id='li" + idmenu + "' data-idmenu='" + idmenu + "'>" +
                        "<a class='nav-link tabPrin active' id='nav" + idmenu + "' data-toggle='tab' href='#" + nombreItem + "' onclick='onclickTab(\"" + idmenu + "\")'>" + nombreItem + 
                        "</a>" +
                    "</li>";

    var tabMenuDiv = "<div data-idmenu='" + idmenu + "' data-breadcrumb='" + migapan + "' role='tabpanel' id='tab" + idmenu + "' class='tab-pane tabPrin active'>" +
                        "<div class='panel-body' id='dvCont" + idmenu + "'>" +
                        "</div>" +
                     "</div>";

    $("#ulTabsPrincipal").append(tabMenuLi);
    $("#dvTabsContent").append(tabMenuDiv);
    document.getElementById("textbreadcrumb").innerHTML = 'Está en: <a href="#" target="_self" title=' + migapan + '>' + migapan + '</a>';    

    $.get(url, function (htmlexterno) {
        $('#dvCont' + idmenu).html(htmlexterno);
    });

    $(".navbar-header a").click(function () {
        $("body.pace-done").toggleClass("mini-navbar");
    });

}

//Crea el tab principal ALERTAS SEGUIMIENTO no se puede cerrar por el usuario
function TabAlertasSeguimiento() {
    let idmenu = 9999;
    let nombreItem = 'ALERTAS';
    let migapan = 'Alertas';
    let url = 'pages/tareas/alertas_seguimiento.html';

    var tabMenuLi = "<li class='liopcion liselected' id='li" + idmenu + "' data-idmenu='" + idmenu + "'>" +
                        "<a class='nav-link tabPrin active' id='nav" + idmenu + "' data-toggle='tab' href='#" + nombreItem + "' onclick='onclickTab(\"" + idmenu + "\")'>" + nombreItem + 
                        "</a>" +
                    "</li>";

    var tabMenuDiv = "<div data-idmenu='" + idmenu + "' data-breadcrumb='" + migapan + "' role='tabpanel' id='tab" + idmenu + "' class='tab-pane tabPrin active'>" +
                        "<div class='panel-body' id='dvCont" + idmenu + "'>" +
                        "</div>" +
                     "</div>";

    $("#ulTabsPrincipal").append(tabMenuLi);
    $("#dvTabsContent").append(tabMenuDiv);
    document.getElementById("textbreadcrumb").innerHTML = 'Está en: <a href="#" target="_self" title=' + migapan + '>' + migapan + '</a>';    

    $.get(url, function (htmlexterno) {
        $('#dvCont' + idmenu).html(htmlexterno);
    });

    $(".navbar-header a").click(function () {
        $("body.pace-done").toggleClass("mini-navbar");
    });

    $("#dvTabsPrincipal ul li #nav" + idmenu).addClass('ocultar');
    $("#dvTabsPrincipal div #tab" + idmenu).addClass('ocultar');       

}

function CargarOpcionExterna(idopcion) {
    let idmenu = 'opcmenu' + idopcion;
    let opcionmenu = document.getElementById(idmenu);

    if (opcionmenu != null) {
        ItemsMenu(opcionmenu)
    }
    else {
        ShowModalDialog('Opción no habilitada para su usuario ', false, 'warning', '', 0);  
    }
}

// Ejecuta y realiza el evento clic de los items del menú
function ItemsMenu(obj) {        
    StartLoader();
    
    var jerarquia = obj.attributes["data-jerarquia"].value;
    var idmenu;

    if (jerarquia == "1") {
        url = obj.attributes["url"].value;
        nombreItem = obj.children[1].innerHTML;
    } else if (jerarquia == "2") {
        url = obj.attributes["url"].value;
        nombreItem = obj.text;
        idmenu = obj.attributes["data-id"].value;
    }    

    var esIE = window.navigator.userAgent.indexOf('Trident/') > 0;
    var esIEE = navigator.userAgent.indexOf('Edge') >= 0;
    var idTab = "#tab" + idmenu;

    /*
    if (esIE) {
        url = obj.attributes[1].value;
    } else if (esIEE) {
        url = obj.attributes[1].value;
    }
*/
    var contLi = $("#ulTabsPrincipal li").length;
    var tabExists = $("#dvTabsContent").find(idTab);
    
    $("#dvTabsPrincipal ul li .nav-link.tabPrin").removeClass('active show');
    $("#dvTabsPrincipal div .tab-pane.tabPrin").removeClass('active show');

    if (tabExists.length > 0) {
        $("#dvTabsPrincipal ul li #nav" + idmenu).addClass('active show');
        $("#dvTabsPrincipal div #tab" + idmenu).addClass('active show');
        document.getElementById("textbreadcrumb").innerHTML = 'Está en: <a href="#" target="_self" title=' + obj.attributes["data-breadcrumb"].value + '>' + obj.attributes["data-breadcrumb"].value + '</a>';
        //onclickTab(nombreItem);
        FinalizeLoader();
        return;
    }

    var tabMenuLi = "<li class='liopcion liselected' id='li" + idmenu + "' data-idmenu='" + idmenu + "'>" +
                        "<a class='nav-link tabPrin active' id='nav" + idmenu + "' data-toggle='tab' href='#" + nombreItem + "' onclick='onclickTab(\"" + idmenu + "\")'>" + nombreItem + 
                        "<svg style='color: #4557c0' onclick='onclickTabClose(" + idmenu + ")' xmlns='../images/iris/x-circle-fill.svg' width='16' height='16' fill='currentColor' class='bi bi-x-circle-fill cambiarMouse closetab' viewBox='0 0 16 16'>" +
                            "<path d='M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z' />" +
                        "</svg>" + "</a>" +
                    "</li>";

    var tabMenuDiv = "<div data-idmenu='" + idmenu + "' data-breadcrumb='" + obj.attributes["data-breadcrumb"].value + "' role='tabpanel' id='tab" + idmenu + "' class='tab-pane tabPrin active' >" +
                        "<div class='panel-body' id='dvCont" + idmenu + "'>" +
                        "</div>" +
                     "</div>";

    $("#ulTabsPrincipal").append(tabMenuLi);
    $("#dvTabsContent").append(tabMenuDiv);
    document.getElementById("textbreadcrumb").innerHTML = 'Está en: <a href="#" target="_self" title=' + obj.attributes["data-breadcrumb"].value + '>' + obj.attributes["data-breadcrumb"].value + '</a>';    
    //document.getElementById("textbreadcrumb").innerHTML = 'Está en: <p title=' + obj.attributes["data-breadcrumb"].value + '>' + obj.attributes["data-breadcrumb"].value + '</p>';    

    $('select').removeAttr('data-select2-id');
    $('option').removeAttr('data-select2-id');
    $('div').removeAttr('data-select2-id');

    $.get(url, function (htmlexterno) {
        $('#dvCont' + idmenu).html(htmlexterno);
    });

    $(".navbar-header a").click(function () {
        $("body.pace-done").toggleClass("mini-navbar");
    });

    FinalizeLoader();
}

function onclickTab(idopcion) {
    nombreItem = idopcion; 
    var idTab = "#tab" + idopcion;
    var tabExists = $("#dvTabsContent").find(idTab);
    
    if (tabExists.length > 0) {            
        $("#dvTabsPrincipal ul li .nav-link.tabPrin").removeClass('active show');
        $("#dvTabsPrincipal div .tab-pane.tabPrin").removeClass('active show');

        $("#dvTabsPrincipal ul li #nav" + idopcion).addClass('active show');
        $("#dvTabsPrincipal div #tab" + idopcion).addClass('active show');       

        document.getElementById("textbreadcrumb").innerHTML = 'Está en: <a href="#" target="_self" title=' + tabExists[0].attributes["data-breadcrumb"].value + '>' + tabExists[0].attributes["data-breadcrumb"].value + '</a>';
        FinalizeLoader();
        return;
    }
}

function onclickTabClose(idmenu) {
    $("#li" + idmenu).remove();
    $("#tab" + idmenu).remove();

    $("#dvTabsPrincipal ul li .nav-link").removeClass('active show');
    $("#dvTabsPrincipal div .tab-pane").removeClass('active show');

    var conteoTabs = $("#dvTabsPrincipal #ulTabsPrincipal li").length;
    var tabizquierdo = conteoTabs - 1;

    if (tabizquierdo >= 0) {
        var itemNombre = $("#dvTabsPrincipal #ulTabsPrincipal li")[tabizquierdo].children[0].text;
        var idTab1 = $("#dvTabsPrincipal #ulTabsPrincipal li")[tabizquierdo].attributes[1].value;
        var idOpcion = $("#dvTabsPrincipal #ulTabsPrincipal li")[tabizquierdo].attributes["data-idmenu"].value;
        $("#dvTabsPrincipal ul li #nav" + idTab1).addClass('active show');
        $("#dvTabsPrincipal div #tab" + idTab1).addClass('active show');
        onclickTab(idOpcion);
    }
}

function CerrarTabs() {
    var conteoTabs = $("#dvTabsPrincipal #ulTabsPrincipal li").length;

    for (var j = 0; j < conteoTabs; j++) {
        var idOpcion = $("#dvTabsPrincipal #ulTabsPrincipal li")[0].attributes["data-idmenu"].value;
        onclickTabClose(idOpcion);
    }

    $("#username").val('');
    $("#password").val('');
    
    $("#loginiris").removeClass("ocultar");
    $("#dvmainiris").addClass("imagenlogin");                
    $("#menuiris").addClass("ocultar");
    $("#mainiris").addClass("ocultar");  
    document.getElementById("textbreadcrumb").innerHTML = '';
    $("#dvnotificacionesusuario").addClass("ocultar");    
    $("#menu_usuario").empty();
    sessionStorage.clear();
          
}

// Permite cargar los items del menú
function GetItemsMenuPage(idRole) {
    $("#side-menu").empty();
    var fila = '';
    
    for (var i = 0; i < ObjData.length; i++) {
        var entityRolMenu = ObjData[i].EntityRolMenu;

        if (entityRolMenu.length > 0) {
            fila += '<li class="">' +
                '<a href="#" aria-expanded="false">' +
                '<i class="' + ObjData[i].ClassImage + '"></i>' +
                '<span class="nav-label">' + ObjData[i].NombreItem + '</span>' +
                '<span class="fa arrow"></span></a>';

            fila += '<ul class="nav nav-second-level collapse" aria-expanded="false" style="height: 0px;">';

            for (var j = 0; j < entityRolMenu.length; j++) {
                var entityRolMenuHijos = entityRolMenu[j].EntityRolMenu;

                if (entityRolMenuHijos.length > 0) {
                    fila += '<li class="">' +
                        '<a href="#" aria-expanded="true">' + entityRolMenu[j].NombreItem + '<span class="fa arrow"></span></a>';

                    fila += '<ul class="nav nav-third-level collapse" aria-expanded="false" style="height: 0px;">';

                    for (var k = 0; k < entityRolMenuHijos.length; k++) {
                        fila += '<li><a url="' + entityRolMenuHijos[k].Url + '" onclick="' + entityRolMenuHijos[k].Onclick + '" data-jerarquia="2" data-id="' + entityRolMenuHijos[k].IdMenu + '">' + entityRolMenuHijos[k].NombreItem + '</a></li>';
                    }

                    fila += '</ul></li>';
                } else {
                    fila += '<li><a url="' + entityRolMenu[j].Url + '" onclick="' + entityRolMenu[j].Onclick + '" data-jerarquia="2" data-id="' + entityRolMenu[j].IdMenu + '">' + entityRolMenu[j].NombreItem + '</a></li>';
                }
            }

            fila += '</ul></li>';
        } else {
            fila += '<li>' +
                '<a url="' + ObjData[i].Url + '" onclick="' + ObjData[i].Onclick + '" aria-expanded="false" data-jerarquia="1" data-id="' + ObjData[i].IdMenu + '">' +
                '<i class="' + ObjData[i].ClassImage + '"></i>' +
                '<span class="nav-label">' + ObjData[i].NombreItem + '</span>' +
                '</a></li>';
        }
    }

    $("#side-menu").append(fila);

    var sideMenu = $('#side-menu').metisMenu();

    sideMenu.on('shown.metisMenu', function (e) {
        fix_height();
    });

    FinalizeLoader();
}

//onkeypress="return soloNumeros(event)"
function soloNumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}

function ExportarExcelFunction(name, Metodo) {
    StartLoader();
    $.ajax({
        type: "POST",
        url: urlController + 'ExportarExcel/' + Metodo + '?name=' + name,
        headers: { 'Authorization': 'Bearer ' + TokenIRIS },
    }).done(function (data) {
        
        if (typeof data.Data != 'undefined') {
            var error = data.TrazaError;
            ShowModalDialog(error, false, 5);
        } else {
            console.log(data);
            location.href = data;
            FinalizeLoader();
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        ShowModalDialog(jqXHR.responseJSON.MessageDetail, false, 2);
    });
}


function ReadCookie(nombre) {    
    var micookie = "";
    var lista = document.cookie.split(";");
    for (i in lista) {
        var busca = lista[i].search(nombre);
        if (busca > -1) { micookie = lista[i] }
    }
    var igual = micookie.indexOf("=");
    var valor = micookie.substring(igual + 1);
    return valor;
}

function DeleteCookie() {
    document.cookie = "Session-Email=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
    document.cookie = "Session-BaseDatos=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
    document.cookie = "Url-Page=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
    document.cookie = "Name-Page=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
    location.href = "Login.html";
}

function abrirNuevoTab(url) {
    var win = window.open(url, '_blank');
    win.focus();
}


function validaPorcentaje(divContainer) {    
    var campo = $("#" + divContainer + " #txtPorcentaje").val();

    if (campo != '') {
        campo = parseInt($("#" + divContainer + " #txtPorcentaje").val());

        if ((campo < 1) || (campo > 100)) {
            alert("El valor ingresado no es correcto. Debe estar entre 1 y 100");
            $("#" + divContainer + " #txtPorcentaje").val('')
        }
    }
}


// SE AGREGA EN EL EVENTO ONCHANGE DEL CAMPO FECHA
function CompararFechas(fecha1, fecha2) {
    //Split de las fechas recibidas para separarlas
    var x = fecha1.split("-");
    var z = fecha2.split("-");

    //Cambiamos el orden al formato americano, de esto yyyy/mm/dd a esto mm/dd/yyyy
    fecha1 = x[1] + "-" + x[2] + "-" + x[0];
    fecha2 = z[1] + "-" + z[2] + "-" + z[0];

    //Comparamos las fechas
    if (Date.parse(fecha1) > Date.parse(fecha2)) {
        return true;
    } else {
        return false;
    }
}

//Digito de Verificación
function calcularDigitoVerificacion(myNit) {
    var vpri,
        x,
        y,
        z;

    // Se limpia el Nit
    myNit = myNit.replace(/\s/g, ""); // Espacios
    myNit = myNit.replace(/,/g, ""); // Comas
    myNit = myNit.replace(/\./g, ""); // Puntos
    myNit = myNit.replace(/-/g, ""); // Guiones

    // Se valida el nit
    if (isNaN(myNit)) {
        console.log("El nit/cédula '" + myNit + "' no es válido(a).");
        return "";
    };

    // Procedimiento
    vpri = new Array(16);
    z = myNit.length;

    vpri[1] = 3;
    vpri[2] = 7;
    vpri[3] = 13;
    vpri[4] = 17;
    vpri[5] = 19;
    vpri[6] = 23;
    vpri[7] = 29;
    vpri[8] = 37;
    vpri[9] = 41;
    vpri[10] = 43;
    vpri[11] = 47;
    vpri[12] = 53;
    vpri[13] = 59;
    vpri[14] = 67;
    vpri[15] = 71;

    x = 0;
    y = 0;
    for (var i = 0; i < z; i++) {
        y = (myNit.substr(i, 1));
        // console.log ( y + "x" + vpri[z-i] + ":" ) ;

        x += (y * vpri[z - i]);
        // console.log ( x ) ;    
    }

    y = x % 11;
    // console.log ( y ) ;

    return (y > 1) ? 11 - y : y;
}

// Calcular
function calcularDV(campoNum, campoDV) {
    // Verificar que haya un numero
    let nit = document.getElementById(campoNum).value;
    let isNitValid = nit >>> 0 === parseFloat(nit) ? true : false; // Validate a positive integer

    // Si es un número se calcula el Dígito de Verificación
    if (isNitValid) {
        let inputDigVerificacion = document.getElementById(campoDV);
        inputDigVerificacion.value = calcularDigitoVerificacion(nit);
    } else {
        document.getElementById(campoDV).value = "";
    }
}

//fecha actual del sistema
function getFechaActual() {    
    let date = new Date();
    let annio = date.getFullYear();
    let strannio = annio.toString();
    let mes = date.getMonth() + 1;
    let dia = date.getDate();    
    let strmes = mes.toString();
    strmes = strmes.padStart(2, "0");
    let strdia = dia.toString();
    strdia = strdia.padStart(2, "0");

    let todaystr = strannio.concat("-",strmes,"-",strdia); //date.toLocaleDateString('en-US', options);

    return todaystr;

}

function Float2AndFloat4(evt, input) {
    var decimalesValor = localStorage.DecimalesValor;
    
    if (decimalesValor == "1") {
        var float1 = filterFloat1(evt, input);
        return float1;
    } else if (decimalesValor == "2") {
        var float2 = filterFloat2(evt, input);
        return float2;
    } else if (decimalesValor == "3") {
        var float3 = filterFloat3(evt, input);
        return float3;
    } else if (decimalesValor == "4") {
        var float4 = filterFloat4(evt, input);
        return float4;
    }
}

function filterFloat1(evt, input) {
    // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
    var key = window.Event ? evt.which : evt.keyCode;
    var chark = String.fromCharCode(key);
    var tempValue = input.value + chark;
    if (key >= 48 && key <= 57) {
        if (filter1(tempValue) === false) {
            return false;
        } else {
            return true;
        }
    } else {
        if (key == 8 || key == 13 || key == 0) {
            return true;
        } else if (key == 46) {
            if (filter1(tempValue) === false) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
}

function filter1(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,1})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }
}

function filterFloat2(evt, input) {
    // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
    var key = window.Event ? evt.which : evt.keyCode;
    var chark = String.fromCharCode(key);
    var tempValue = input.value + chark;
    if (key >= 48 && key <= 57) {
        if (filter2(tempValue) === false) {
            return false;
        } else {
            return true;
        }
    } else {
        if (key == 8 || key == 13 || key == 0) {
            return true;
        } else if (key == 46) {
            if (filter2(tempValue) === false) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
}

function filter2(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,2})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }
}

function filterFloat3(evt, input) {
    // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
    var key = window.Event ? evt.which : evt.keyCode;
    var chark = String.fromCharCode(key);
    var tempValue = input.value + chark;
    if (key >= 48 && key <= 57) {
        if (filter3(tempValue) === false) {
            return false;
        } else {
            return true;
        }
    } else {
        if (key == 8 || key == 13 || key == 0) {
            return true;
        } else if (key == 46) {
            if (filter3(tempValue) === false) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
}

function filter3(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,3})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }
}

function filterFloat4(evt, input) {
    // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
    var key = window.Event ? evt.which : evt.keyCode;
    var chark = String.fromCharCode(key);
    var tempValue = input.value + chark;
    if (key >= 48 && key <= 57) {
        if (filter4(tempValue) === false) {
            return false;
        } else {
            return true;
        }
    } else {
        if (key == 8 || key == 13 || key == 0) {
            return true;
        } else if (key == 46) {
            if (filter4(tempValue) === false) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
}

function filter4(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,4})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }
}

function GetInputSecurityGeneral() {
    var baseDatosEmpresa = ReadCookie('Session-BaseDatos');
    var idsuscripcion = ReadCookie('Session-IdSuscripcion');
    
    $.ajax({
        type: "GET",
        url: urlController + 'TokenSecurity/GetTokenTridentData?email=' + ReadCookie('Session-Email') + '&basedatos=' + baseDatosEmpresa + '&idsuscripcion=' + idsuscripcion,
        async: false
    }).done(function (data) {        
        if (data == null) {
            FinalizeLoader();
            var error = "Error: Token no puede ser encontrado.";
            ShowModalDialog(error, false, 5);
        } else {
            Token = data;
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        ShowModalDialog(jqXHR.responseJSON.MessageDetail, false, 2);
    });
}

function AddSelect2Forms() {
    var selectsForms = $('#' + divContainerHTML + ' select');
    
    for (var i = 0; i < selectsForms.length; i++) {
        var idSelect = selectsForms[i].id;
        var claseSelect = selectsForms[i].className;
        selectsForms[i].className = claseSelect + ' ' + 'select2_' + i;

        if (!$('#' + divContainerHTML + ' .select2_' + i).hasClass("select2-hidden-accessible")) {
            if (!$('#' + divContainerHTML + ' .select2_' + i).hasClass("tipoWidget")) {
                $('#' + divContainerHTML + ' .select2_' + i).select2();
            }
        }
    }
}

function AddSelect2FormsCont() {
    var selectsForms = $('#' + divContainerHTML + ' select');

    for (var i = 0; i < selectsForms.length; i++) {
        var idSelect = selectsForms[i].id;
        var claseSelect = selectsForms[i].className;
        selectsForms[i].className = claseSelect + ' ' + 'select2_' + i;

        if (!$('#' + divContainerHTML + ' .select2_' + i).hasClass("select2-hidden-accessible")) {
            if (!$('#' + divContainerHTML + ' .select2_' + i).hasClass("tipoWidget")) {
                $('#' + divContainerHTML + ' .select2_' + i).select2();
            }
        }
    }
}

function cerrarModalGeneral(idModal) {
    $('#' + idModal).modal('toggle');
}

function ExisteDivEdicionDatos(NombreDiv) {
    let divedicion = document.getElementById(NombreDiv).innerHTML.trim();

    if (divedicion == null || divedicion == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivEdicionDatos(urlPagina, NombreDiv) {    
    $.get(urlPagina, function (htmlexterno) {
        $('#' + NombreDiv).html(htmlexterno);
    });    

}
