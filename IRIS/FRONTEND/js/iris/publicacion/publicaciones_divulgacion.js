
$(document).ready(function () {    
    InicializaPublicacionDivulgacionform($("#spanIdPublicacion")[0].innerText, $("#spanKardexPublicacion")[0].innerText,
                                                $("#spanHermesPublicacion")[0].innerText, $("#spanNombrePublicacion")[0].innerText);

});

function VolverTablaPublicacionesDesdeDivulgacion() {
    $("#dvPublicacionDivulgacion").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaPublicacionDivulgacionform(IdPublicacion, kardex, hermes, nombrepublicacion) {
    $("#txtKardexPublicacionDivulgacion").val(kardex);
    $("#txtHermesPublicacionDivulgacion").val(hermes);
    $("#txtNombrePublicacionDivulgacion").val(nombrepublicacion);

    onclickTabPublicacionDivulgacion('PUBDivulgacion_Inicio', 0);

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionDivulgacion").removeClass("ocultar");
}

function onclickTabPublicacionDivulgacion(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDivulgacion").find(idTab);
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicacion' + idpagina + '.html'
    let urlpagina = '/Pages/publicacion/' + sNombreHtml; 
    let lRefrescar = false;
    debugger;
    
    if (tabExists.length > 0) {
        StartLoader();
                
        if (!ExisteDivEdicionDatos(idDiv)) {
            //lRefrescar = false;
            CrearDivEdicionDatos(urlpagina, idDiv);
        }            
        else {
            lRefrescar = true;
            RefreshDataContentDivByPaginaPublicacionDivulgacion(idpagina);
            
        }

        $("#tablePublicacionDivulgacion ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDivulgacion div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDivulgacion ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDivulgacion div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBDivulgacion_Inicio')) {
            RefreshDataContentDivByPaginaPublicacionDivulgacion(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDivulgacion(idpagina) {   
    debugger; 
    //INICIO
    if (idpagina == 'PUBDivulgacion_Inicio') {      
        EditarPublicaciones_DivulgacionInicioForm();      
    }

    //PLAN
    if (idpagina == 'PUBDivulgacion_Plan') {
        InicializaPublicacionDivulgacionPlanform();        
    }

    //MEDIOS
    if (idpagina == 'PUBDivulgacion_Medios') {
        InicializaPublicacionDivulgacionMediosform();        
    }

    //HERRAMIENTAS
    if (idpagina == 'PUBDivulgacion_Herramientas') {
        InicializaPublicacionDivulgacionHerramientasform();        
    }

    //CIERRE
    if (idpagina == 'PUBDivulgacion_Cierre') {
        InicializaPublicacionDivulgacionCierreform();
    }
    
}




