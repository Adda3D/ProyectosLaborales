
$(document).ready(function () {    
    InicializaPublicacionDiagramacionformD8aD14();

});

function InicializaPublicacionDiagramacionformD8aD14() {
debugger;
    onclickTabPublicacionDiagramacionD8aD14('PUBDiagramacion_SeccionD8');

}

function onclickTabPublicacionDiagramacionD8aD14(idpagina) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDiagramacionD8aD14").find(idTab);
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicacion' + idpagina + '.html'
    let urlpagina = '/Pages/publicacion/' + sNombreHtml; 
    debugger;
    
    if (tabExists.length > 0) {
        StartLoader();
                
        if (!ExisteDivEdicionDatos(idDiv)) {
            CrearDivEdicionDatos(urlpagina, idDiv);
        }
        else {
            RefreshDataContentDivByPaginaPublicacionDiagramacionD8aD14(idpagina);
        }

        $("#tablePublicacionDiagramacionD8aD14 ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDiagramacionD8aD14 div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDiagramacionD8aD14 ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDiagramacionD8aD14 div #tab" + idpagina).addClass('active show');       
        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDiagramacionD8aD14(idpagina) {    
    //D8
    if (idpagina == 'PUBDiagramacion_SeccionD8') {                
        EditarPublicacionesDiagramacionSeccionD8Form();    
    }

    //D9
    if (idpagina == 'PUBDiagramacion_SeccionD9') {        
        EditarPublicacionesDiagramacionSeccionD9Form();
    }

    //D10
    if (idpagina == 'PUBDiagramacion_SeccionD10') {
        EditarPublicacionesDiagramacionSeccionD10Form();
    }

    //D11
    if (idpagina == 'PUBDiagramacion_SeccionD11') {        
        EditarPublicacionesDiagramacionSeccionD11Form();
    }

    //D12
    if (idpagina == 'PUBDiagramacion_SeccionD12') {        
        EditarPublicacionesDiagramacionSeccionD12Form();
    }

    //D13
    if (idpagina == 'PUBDiagramacion_SeccionD13') {        
        EditarPublicacionesDiagramacionSeccionD13Form();
    }

    //D14
    if (idpagina == 'PUBDiagramacion_SeccionD14') {        
        EditarPublicacionesDiagramacionSeccionD14Form();
    }

}




