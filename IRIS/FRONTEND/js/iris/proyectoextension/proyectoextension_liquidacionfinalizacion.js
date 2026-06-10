
$(document).ready(function () {    
    InicializaProyectoExtensionLiquidacionform();

});

function VolverTablaProyectoExtensionDesdeLiquidacion() {
    $("#dvProyectoExtensionLiquidacionFinalizacion").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function InicializaProyectoExtensionLiquidacionform() {    
    $("#txtConsProyectoExtensionLiquidacion").val($("#spanConsecutivoProyectoExtension")[0].innerText);
    $("#txtContratoProyectoExtensionLiquidacion").val($("#spanContratoProyectoExtension")[0].innerText);
    $("#txtNombreProyectoExtensionLiquidacion").val($("#spanNombreProyectoExtension")[0].innerText);
    $("#txtFechaInicioProyectoExtensionLiquidacion").val($("#spanFechaInicioProyectoExtension")[0].innerText);
    $("#txtFechaFinProyectoExtensionLiquidacion").val($("#spanFechaFinalizaProyectoExtension")[0].innerText);

    onclickTabProyectoExtensionLiquidacion('PEL_Liquidacion');

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionLiquidacionFinalizacion").removeClass("ocultar");
}

function onclickTabProyectoExtensionLiquidacion(idpagina) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsProyectoExtensionLiquidacion").find(idTab);
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'proyectoextension' + idpagina + '.html'
    let urlpagina = '/Pages/proyectoextension/' + sNombreHtml; 
    let lRefrescar = false;
    
    if (tabExists.length > 0) {
        StartLoader();
                
        if (!ExisteDivEdicionDatos(idDiv)) {
            CrearDivEdicionDatos(urlpagina, idDiv);
        }
        else {
            RefreshDataContentDivByPaginaProyectoExtensionLiquidacion(idpagina);
            lRefrescar = true;
        }

        $("#tableProyectoExtensionLiquidacion ul li .nav-link.tabPrin").removeClass('active show');
        $("#tableProyectoExtensionLiquidacion div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tableProyectoExtensionLiquidacion ul li #nav" + idpagina).addClass('active show');
        $("#tableProyectoExtensionLiquidacion div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
//        if (lRefrescar && (idpagina == 'PUBDiagramacion_SeguimientoD2D7' || idpagina == 'PUBDiagramacion_SeguimientoD8D14' || idpagina == 'PUBDiagramacion_DiagramacionFinal')) {
//            RefreshDataContentDivByPaginaProyectoExtensionLiquidacion(idpagina);
//        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaProyectoExtensionLiquidacion(idpagina) {   
    debugger; 
    //LIQUIDACION
    if (idpagina == 'PEL_Liquidacion') {   
        EditarproyectoextensionPEL_LiquidacionForm();    
    }

    //SUSCRIPCION ACTA
    if (idpagina == 'PEL_SuscripcionActa') {
        EditarproyectoextensionPEL_SuscripcionActaForm();
    }

    //MODULO RUP
    if (idpagina == 'PEL_ModuloRUP') {
        EditarproyectoextensionPEL_ModuloRUPForm();
    }
    
}




