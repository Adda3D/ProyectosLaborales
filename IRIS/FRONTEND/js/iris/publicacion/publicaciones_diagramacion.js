
$(document).ready(function () {    
    InicializaPublicacionDiagramacionform($("#spanIdPublicacion")[0].innerText, $("#spanKardexPublicacion")[0].innerText,
                                                $("#spanHermesPublicacion")[0].innerText, $("#spanNombrePublicacion")[0].innerText);

});

function VolverTablaPublicacionesDesdeDiagramacion() {
    $("#dvPublicacionDiagramacion").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaPublicacionDiagramacionform(IdPublicacion, kardex, hermes, nombrepublicacion) {   
    $("#txtKardexPublicacionDiagramacion").val(kardex);
    $("#txtHermesPublicacionDiagramacion").val(hermes);
    $("#txtNombrePublicacionDiagramacion").val(nombrepublicacion);

    onclickTabPublicacionDiagramacion('PUBDiagramacion_Designacion', 0);

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionDiagramacion").removeClass("ocultar");
}

function onclickTabPublicacionDiagramacion(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDiagramacion").find(idTab);
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
            RefreshDataContentDivByPaginaPublicacionDiagramacion(idpagina);
            lRefrescar = true;
        }

        $("#tablePublicacionDiagramacion ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDiagramacion div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDiagramacion ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDiagramacion div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBDiagramacion_SeguimientoD2D7' || idpagina == 'PUBDiagramacion_SeguimientoD8D14' || idpagina == 'PUBDiagramacion_DiagramacionFinal')) {
            RefreshDataContentDivByPaginaPublicacionDiagramacion(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDiagramacion(idpagina) {   
    debugger; 
    //DESIGNACION
    if (idpagina == 'PUBDiagramacion_Designacion') {        
        EditarPublicaciones_DesignacionForm();
    }

    //Diagramacion del Taco
    if (idpagina == 'PUBDiagramacion_Taco') {
        EditarPublicaciones_DiagramacionTacoForm();
    }

    //Diagramacion de la Cubierta
    if (idpagina == 'PUBDiagramacion_Cubierta') {
        EditarPublicaciones_DiagramacionCubiertaForm();
    }

    //Diagramacion Secciones D2 a D7
    if (idpagina == 'PUBDiagramacion_SeguimientoD2D7') {
        InicializaPublicacionDiagramacionformD2aD7();
    }

    //Diagramacion Secciones D8 a D14
    if (idpagina == 'PUBDiagramacion_SeguimientoD8D14') {
        InicializaPublicacionDiagramacionformD8aD14();
    }

    if (idpagina == 'PUBDiagramacion_CierreEdicion') {
        EditarPublicaciones_CierreEdicionForm();
    }

    //Diagramacion Secciones D15 a D19
    if (idpagina == 'PUBDiagramacion_DiagramacionFinal') {
        InicializaPublicacionDiagramacionformD15aD19();
    }

    
}




