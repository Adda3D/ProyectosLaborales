var DataTablePublicacionEvaluadores = null;

$(document).ready(function () {    
    InicializaPublicacionEvaluacionform($("#spanIdPublicacion")[0].innerText, $("#spanKardexPublicacion")[0].innerText,
                                                $("#spanHermesPublicacion")[0].innerText, $("#spanNombrePublicacion")[0].innerText);

});

function VolverTablaPublicacionesDesdeEvaluacion() {
    $("#dvPublicacionEvaluacion").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaPublicacionEvaluacionform(IdPublicacion, kardex, hermes, nombrepublicacion) {    
    $("#txtKardexPublicacionEvaluacion").val(kardex);
    $("#txtHermesPublicacionEvaluacion").val(hermes);
    $("#txtNombrePublicacionEvaluacion").val(nombrepublicacion);

    onclickTabPublicacionEvaluacion('PUBEVAL_Evaluadores', 0);

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionEvaluacion").removeClass("ocultar");
}

function onclickTabPublicacionEvaluacion(idpagina, id_partida) {
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsPublicacionEvaluacion").find(idTab);
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicacion' + idpagina + '.html'
    let urlpagina = '/Pages/publicacion/' + sNombreHtml; 
    
    if (tabExists.length > 0) {
        StartLoader();
                
        if (!ExisteDivGestionarPublicacion(idDiv)) {
            CrearDivGestionarPublicacion(urlpagina, idDiv);
        }
        else {
            RefreshDataContentDivByPagina(idpagina);
        }

/*
        if (!ExisteDivContentTabPublicacionEvaluacion(idpagina)) {
            CrearDivContentTabPublicacionEvaluacion(idpagina);
        }
        else {
            RefreshDataContentDivByPagina(idpagina);
        }
*/    
        $("#tablePublicacionEvaluacion ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionEvaluacion div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionEvaluacion ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionEvaluacion div #tab" + idpagina).addClass('active show');       
        FinalizeLoader();
        return;
    }    
}

function RefreshDataContentDivByPagina(idpagina) {
    //EVALUADORES
    if (idpagina == 'PUBEVAL_Evaluadores') {
        InicializaPublicacionEvaluadoresform();        
    }

    //EVALUACION FINAL
    if (idpagina == 'PUBEVAL_Evaluacion') {
        EditarPublicacionEvaluacionInicialForm();
    }

    //EVALUACION APROBACION
    if (idpagina == 'PUBEVAL_Aprobacion') {
        EditarPublicacionEvaluacionAprobacionForm();
    }

    //EVALUACION OBSERVACIONES
    if (idpagina == 'PUBEVAL_Observacion') {
        EditarPublicacionEvaluacionObservacionesForm();
    }
    
}

function ExisteDivContentTabPublicacionEvaluacion(idpagina) {
    let idDiv = "dvCont" + idpagina;
    let divontenido = document.getElementById(idDiv).innerHTML.trim();

    if (divontenido == null || divontenido == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivContentTabPublicacionEvaluacion(idpagina) {
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicacion' + idpagina + '.html'
    let urledit = '/Pages/publicacion/' + sNombreHtml; 

    $.get(urledit, function (htmlexterno) {
        $('#' + idDiv).html(htmlexterno);
    });    

}

function PublicacionEvaluacionTotalPago4xmil(inputorigen, inputdestino) {
    let valorneto = $('#' + inputorigen).val();
    valorneto = Number(valorneto);
    let valorimpuesto = valorneto * 4 / 1000;
    let valortotal = valorneto + valorimpuesto;
    $('#' + inputdestino).val(valortotal.toLocaleString('en-US'));   
}


