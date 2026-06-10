
$(document).ready(function () {    
    InicializaPublicacionDiagramacionformD2aD7();

});

function InicializaPublicacionDiagramacionformD2aD7() {
debugger;
    onclickTabPublicacionDiagramacionD2aD7('PUBDiagramacion_SeccionD2');

}

function onclickTabPublicacionDiagramacionD2aD7(idpagina) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDiagramacionD2aD7").find(idTab);
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
            RefreshDataContentDivByPaginaPublicacionDiagramacionD2aD7(idpagina);
        }

        $("#tablePublicacionDiagramacionD2aD7 ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDiagramacionD2aD7 div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDiagramacionD2aD7 ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDiagramacionD2aD7 div #tab" + idpagina).addClass('active show');  
        
        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDiagramacionD2aD7(idpagina) {    
    //D2
    if (idpagina == 'PUBDiagramacion_SeccionD2') {                
        EditarPublicacionesDiagramacionSeccionD2Form();    
    }

    //D3
    if (idpagina == 'PUBDiagramacion_SeccionD3') {        
        EditarPublicacionesDiagramacionSeccionD3Form();
    }

    //c6
    if (idpagina == 'PUBDiagramacion_SeccionC6') {
        EditarPublicacionesDiagramacionSeccionC6Form();
    }

    //D4
    if (idpagina == 'PUBDiagramacion_SeccionD4') {        
        EditarPublicacionesDiagramacionSeccionD4Form();
    }

    //D5
    if (idpagina == 'PUBDiagramacion_SeccionD5') {        
        EditarPublicacionesDiagramacionSeccionD5Form();
    }

    //D6
    if (idpagina == 'PUBDiagramacion_SeccionD6') {        
        EditarPublicacionesDiagramacionSeccionD6Form();
    }

    //D7
    if (idpagina == 'PUBDiagramacion_SeccionD7') {        
        EditarPublicacionesDiagramacionSeccionD7Form();
    }

}




