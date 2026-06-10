
$(document).ready(function () {    
    InicializaPublicacionImpresionDigitalizacionform($("#spanIdPublicacion")[0].innerText, $("#spanKardexPublicacion")[0].innerText,
                                                $("#spanHermesPublicacion")[0].innerText, $("#spanNombrePublicacion")[0].innerText);

});

function VolverTablaPublicacionesDesdeImpresionDigitalizacion() {
    $("#dvPublicacionImpresionDigitalizacion").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaPublicacionImpresionDigitalizacionform(IdPublicacion, kardex, hermes, nombrepublicacion) {
    $("#txtKardexPublicacionImpresionDigitalizacion").val(kardex);
    $("#txtHermesPublicacionImpresionDigitalizacion").val(hermes);
    $("#txtNombrePublicacionImpresionDigitalizacion").val(nombrepublicacion);

    onclickTabPublicacionImpresionDigitalizacion('PUBImpresionDigitalizacion_Impresion', 0);

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionImpresionDigitalizacion").removeClass("ocultar");
}

function onclickTabPublicacionImpresionDigitalizacion(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionImpresionDigitalizacion").find(idTab);
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
            RefreshDataContentDivByPaginaPublicacionImpresionDigitalizacion(idpagina);
            lRefrescar = true;
        }

        $("#tablePublicacionImpresionDigitalizacion ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionImpresionDigitalizacion div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionImpresionDigitalizacion ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionImpresionDigitalizacion div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBImpresionDigitalizacion_Impresion')) {
            RefreshDataContentDivByPaginaPublicacionImpresionDigitalizacion(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionImpresionDigitalizacion(idpagina) {   
    debugger; 
    //IMPRESIÓN
    if (idpagina == 'PUBImpresionDigitalizacion_Impresion') {        
        EditarPublicaciones_ImpresionForm();
    }

    //DIGITALIZACION
    if (idpagina == 'PUBImpresionDigitalizacion_Digitalizacion') {
        EditarPublicaciones_DigitalizacionForm();
    }
    
}




