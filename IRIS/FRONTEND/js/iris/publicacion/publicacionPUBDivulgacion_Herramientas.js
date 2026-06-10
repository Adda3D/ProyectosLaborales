
$(document).ready(function () {    
    InicializaPublicacionDivulgacionHerramientasform();

});

function InicializaPublicacionDivulgacionHerramientasform() {    

    onclickTabPublicacionDivulgacionHerramientas('PUBDivulgacion_HerramientasRedSocial', 0);
}

function onclickTabPublicacionDivulgacionHerramientas(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDivulgacionHerramientas").find(idTab);
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicacion' + idpagina + '.html'
    let urlpagina = '/Pages/publicacion/' + sNombreHtml; 
    let lRefrescar = false;
    debugger;
    
    if (tabExists.length > 0) {
        StartLoader();
                
        if (!ExisteDivEdicionDatos(idDiv)) {            
            CrearDivEdicionDatos(urlpagina, idDiv);
        }            
        else {
            lRefrescar = true;
            RefreshDataContentDivByPaginaPublicacionDivulgacionHerramientas(idpagina);            
        }

        $("#tablePublicacionDivulgacionHerramientas ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDivulgacionHerramientas div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDivulgacionHerramientas ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDivulgacionHerramientas div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBDivulgacion_HerramientasRedSocial')) {
            //RefreshDataContentDivByPaginaPublicacionDivulgacionHerramientas(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDivulgacionHerramientas(idpagina) {   
    debugger; 
    //REDES SOCIALES
    if (idpagina == 'PUBDivulgacion_HerramientasRedSocial') {  
        LoadPublicaciones_DivulgacionHerramientasRedSocial();
    }

    //PRENSA ESCRITA
    if (idpagina == 'PUBDivulgacion_HerramientasPrensaEscrita') {
        LoadPublicaciones_DivulgacionHerramientasPrensaEscrita();
    }

    //PRENSA ORAL
    if (idpagina == 'PUBDivulgacion_HerramientasPrensaOral') {
        LoadPublicaciones_DivulgacionHerramientasPrensaOral();
    }

    //PRENSA AUDIOVISUAL
    if (idpagina == 'PUBDivulgacion_HerramientasPrensaAudioVisual') {
        LoadPublicaciones_DivulgacionHerramientasPrensaAudioVisual();
    }

    //MAILING
    if (idpagina == 'PUBDivulgacion_HerramientasMailing') {
        LoadPublicaciones_DivulgacionHerramientasMailing();
    }
    
    //UNIMEDIOS
    if (idpagina == 'PUBDivulgacion_HerramientasUnimedios') {
        LoadPublicaciones_DivulgacionHerramientasUnimedios();
    }

}




