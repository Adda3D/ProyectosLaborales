
$(document).ready(function () {    
    InicializaPublicacionDivulgacionMediosform();

});

function InicializaPublicacionDivulgacionMediosform() {    

    onclickTabPublicacionDivulgacionMedios('PUBDivulgacion_MediosLanzamiento', 0);
}

function onclickTabPublicacionDivulgacionMedios(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDivulgacionMedios").find(idTab);
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
            RefreshDataContentDivByPaginaPublicacionDivulgacionMedios(idpagina);            
        }

        $("#tablePublicacionDivulgacionMedios ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDivulgacionMedios div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDivulgacionMedios ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDivulgacionMedios div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBDivulgacion_MediosLanzamiento')) {
            RefreshDataContentDivByPaginaPublicacionDivulgacionMedios(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDivulgacionMedios(idpagina) {   
    debugger; 
    //LANZAMIENTO
    if (idpagina == 'PUBDivulgacion_MediosLanzamiento') {  
        EditarPublicaciones_DivulgacionActividadLanzamientoForm();   
    }

    //AUTORES
    if (idpagina == 'PUBDivulgacion_MediosAutores') {
        LoadPublicaciones_DivulgacionMediosAutores();
    }

    //INVITADOS
    if (idpagina == 'PUBDivulgacion_MediosInvitados') {        
        LoadPublicaciones_DivulgacionMediosInvitados();        
    }

    //FERIAS-EVENTOS
    if (idpagina == 'PUBDivulgacion_MediosFeriasEventos') {
        LoadPublicaciones_DivulgacionActividadFeriaEvento();
    }
    
}




