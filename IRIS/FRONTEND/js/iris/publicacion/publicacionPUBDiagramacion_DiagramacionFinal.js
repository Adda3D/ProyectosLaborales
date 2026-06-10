
$(document).ready(function () {    
    InicializaPublicacionDiagramacionformD15aD19();

});

function InicializaPublicacionDiagramacionformD15aD19() {
debugger;
    onclickTabPublicacionDiagramacionD15aD19('PUBDiagramacion_SeccionD15');

}

function onclickTabPublicacionDiagramacionD15aD19(idpagina) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDiagramacionD15aD19").find(idTab);
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
            RefreshDataContentDivByPaginaPublicacionDiagramacionD15aD19(idpagina);
        }

        $("#tablePublicacionDiagramacionD15aD19 ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDiagramacionD15aD19 div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDiagramacionD15aD19 ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDiagramacionD15aD19 div #tab" + idpagina).addClass('active show');       
        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDiagramacionD15aD19(idpagina) {    
    //D15
    if (idpagina == 'PUBDiagramacion_SeccionD15') {                
        EditarPublicacionesDiagramacionSeccionD15Form();    
    }

    //D16
    if (idpagina == 'PUBDiagramacion_SeccionD16') {        
        EditarPublicacionesDiagramacionSeccionD16Form();
    }

    //D18
    if (idpagina == 'PUBDiagramacion_SeccionD18') {
        EditarPublicacionesDiagramacionSeccionD18Form();
    }

    //D19
    if (idpagina == 'PUBDiagramacion_SeccionD19') {        
        EditarPublicacionesDiagramacionSeccionD19Form();
    }

}




