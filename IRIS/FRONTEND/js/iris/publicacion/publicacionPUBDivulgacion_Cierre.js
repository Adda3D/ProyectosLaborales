
$(document).ready(function () {    
    InicializaPublicacionDivulgacionCierreform();

});

function InicializaPublicacionDivulgacionCierreform() {    

    onclickTabPublicacionDivulgacionCierre('PUBDivulgacion_CierreBitacora', 0);
}

function onclickTabPublicacionDivulgacionCierre(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDivulgacionCierre").find(idTab);
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
            RefreshDataContentDivByPaginaPublicacionDivulgacionCierre(idpagina);            
        }

        $("#tablePublicacionDivulgacionCierre ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDivulgacionCierre div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDivulgacionCierre ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDivulgacionCierre div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBDivulgacion_CierreBitacora')) {
            //RefreshDataContentDivByPaginaPublicacionDivulgacionCierre(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDivulgacionCierre(idpagina) {   
    debugger; 
    //BITACORA
    if (idpagina == 'PUBDivulgacion_CierreBitacora') {  
        EditarPublicacionDivulgacionCierreBitacoraForm();
    }

    //RETROALIMENTACION AUTORES
    if (idpagina == 'PUBDivulgacion_CierreRetroAutores') {
        LoadPublicaciones_DivulgacionCierreAutores();
    }

    //AGRADECIMIENTO INVITADOS
    if (idpagina == 'PUBDivulgacion_CierreRetroInvitados') {
        LoadPublicaciones_DivulgacionCierreRetroInvitados();
    }

}




