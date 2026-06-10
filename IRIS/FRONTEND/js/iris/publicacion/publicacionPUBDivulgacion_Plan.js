
$(document).ready(function () {    
    InicializaPublicacionDivulgacionPlanform();

});

function InicializaPublicacionDivulgacionPlanform() {    

    onclickTabPublicacionDivulgacionPlan('PUBDivulgacion_PlanDatos', 0);
}

function onclickTabPublicacionDivulgacionPlan(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionDivulgacionPlan").find(idTab);
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
            RefreshDataContentDivByPaginaPublicacionDivulgacionPlan(idpagina);            
        }

        $("#tablePublicacionDivulgacionPlan ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionDivulgacionPlan div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionDivulgacionPlan ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionDivulgacionPlan div #tab" + idpagina).addClass('active show');       

        //NECESARIOS PARA MOSTRAR LA PESTAÑA INICIAL AL REVISITAR LA SECCIÓN
        if (lRefrescar && (idpagina == 'PUBDivulgacion_PlanDatos')) {
            RefreshDataContentDivByPaginaPublicacionDivulgacionPlan(idpagina);
        }

        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionDivulgacionPlan(idpagina) {   
    debugger; 
    //DATOS
    if (idpagina == 'PUBDivulgacion_PlanDatos') {     
        EditarPublicaciones_DivulgacionPlanDatosForm();             
    }

    //ACTIVIDADES
    if (idpagina == 'PUBDivulgacion_PlanActividades') {
        LoadPublicaciones_DivulgacionPlanActividad();        
    }

    
}




