
$(document).ready(function () {    
    InicializaPublicacionDepositosVentasform($("#spanIdPublicacion")[0].innerText, $("#spanKardexPublicacion")[0].innerText,
                                                $("#spanHermesPublicacion")[0].innerText, $("#spanNombrePublicacion")[0].innerText);

});

function VolverTablaPublicacionesDesdeDepositosVentas() {
    $("#dvPublicacionDepositosVentas").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaPublicacionDepositosVentasform(IdPublicacion, kardex, hermes, nombrepublicacion) {
    $("#txtKardexPublicacionDepositosVentas").val(kardex);
    $("#txtHermesPublicacionDepositosVentas").val(hermes);
    $("#txtNombrePublicacionDepositosVentas").val(nombrepublicacion);

    onclickTabPublicacionDepositosVentas('PUBDepositosVentas_Resolucion', 0);

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionDepositosVentas").removeClass("ocultar");
}

function onclickTabPublicacionDepositosVentas(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDepositosVentas").find(idTab);
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicacion' + idpagina + '.html'
    let urlpagina = '/Pages/publicacion/' + sNombreHtml; 
    let lRefrescar = false;
    
    if (tabExists.length > 0) {
        StartLoader();
                
        if (!ExisteDivEdicionDatos(idDiv)) {
            CrearDivEdicionDatos(urlpagina, idDiv);
        }
        else {
            RefreshDataContentDivByPaginaPublicacionDepositosVentas(idpagina);
            lRefrescar = true;
        }

        $("#tablePublicacionDepositosVentas ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDepositosVentas div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDepositosVentas ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDepositosVentas div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBDepositosVentas_Resolucion')) {
            RefreshDataContentDivByPaginaPublicacionDepositosVentas(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDepositosVentas(idpagina) {   
    debugger; 
    //RESOLUCIÓN
    if (idpagina == 'PUBDepositosVentas_Resolucion') {        
        EditarPublicaciones_DepositoResolucionForm();
    }

    //DIGITALIZACION
    if (idpagina == 'PUBDepositosVentas_Precios') {
        EditarPublicaciones_DepositoPreciosForm();
    }

    //ACTA DE COSTOS    
    if (idpagina == 'PUBDepositosVentas_ActaCostos') {
        EditarPublicaciones_DepositoControlActaForm();
    }

    //DISPOSICIONES LEGALES
    if (idpagina == 'PUBDepositosVentas_DisposicionLegal') {
        LoadPublicaciones_DepositoDistribucion();        
    }

    //DISTRIBUCION COMERCIAL
    if (idpagina == 'PUBDepositosVentas_DistribucionComercial') {
        LoadPublicaciones_DepositoDistribucionComercial();        
    }

    //REPORTES VENTAS
    if (idpagina == 'PUBDepositosVentas_ReportesVentas') {
        LoadPublicaciones_DepositoControlRepVentas();        
    }

    //CERTIFICADOS VENTAS
    if (idpagina == 'PUBDepositosVentas_CertificadosVentas') {
        LoadPublicaciones_DepositoControlCertVentas();        
    }
    
    //INGRESOS VENTAS
    if (idpagina == 'PUBDepositosVentas_IngresosVentas') {
        EditarPublicaciones_IngresosPorVentasForm();        
    }

    //INVENTARIO
    if (idpagina == 'PUBDepositosVentas_Inventario') {
        EditarPublicaciones_InventarioForm();
    }
    
    //AJUSTES INVENTARIO    
    if (idpagina == 'PUBDepositosVentas_AjustesInventario') {
        LoadPublicaciones_DepositoControlInventarioMovimientos();        
    }
    
}




