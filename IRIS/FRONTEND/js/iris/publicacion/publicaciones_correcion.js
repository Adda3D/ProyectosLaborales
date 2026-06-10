
$(document).ready(function () {    
    InicializaPublicacionCorreccionform($("#spanIdPublicacion")[0].innerText, $("#spanKardexPublicacion")[0].innerText,
                                                $("#spanHermesPublicacion")[0].innerText, $("#spanNombrePublicacion")[0].innerText);

});

function VolverTablaPublicacionesDesdeCorreccion() {
    $("#dvPublicacionCorreccion").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaPublicacionCorreccionform(IdPublicacion, kardex, hermes, nombrepublicacion) {
    $("#txtKardexPublicacionCorreccion").val(kardex);
    $("#txtHermesPublicacionCorreccion").val(hermes);
    $("#txtNombrePublicacionCorreccion").val(nombrepublicacion);

    onclickTabPublicacionCorreccion('PUBCORRECCION_Definicion', 0);

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionCorreccion").removeClass("ocultar");
}

function onclickTabPublicacionCorreccion(idpagina, id_partida) {
    debugger;
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionCorreccion").find(idTab);
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicacion' + idpagina + '.html'
    let urlpagina = '/Pages/publicacion/' + sNombreHtml; 
    
    if (tabExists.length > 0) {
        StartLoader();
                
        if (!ExisteDivEdicionDatos(idDiv)) {
            CrearDivEdicionDatos(urlpagina, idDiv);
        }
        else {
            RefreshDataContentDivByPaginaPublicacionCorreccion(idpagina);
        }

        $("#tablePublicacionCorreccion ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionCorreccion div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionCorreccion ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionCorreccion div #tab" + idpagina).addClass('active show');       
        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPaginaPublicacionCorreccion(idpagina) {    
    
    //CONTRATO
    if (idpagina == 'PUBCORRECCION_Definicion') {        
        EditarPublicaciones_TipoCorreccionForm();
    }

    //Correccion C1.1
    if (idpagina == 'PUBCORRECCION_Estilo1_1') {
        EditarPublicaciones_EstadoCorParam1_1Form();
    }

    //Correccion C1.2
    if (idpagina == 'PUBCORRECCION_Estilo1_2') {
        EditarPublicaciones_EstadoCorParam1_2Form();
    }

    //Correccion C1.3
    if (idpagina == 'PUBCORRECCION_Estilo1_3') {
        EditarPublicaciones_EstadoCorParam1_3Form();
    }
 
}




