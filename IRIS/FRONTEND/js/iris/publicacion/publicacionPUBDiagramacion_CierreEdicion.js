var ObjModelPublicaciones_CierreEdicion = null;

$(document).ready(function () {

    ObjModelPublicaciones_CierreEdicion = new Publicaciones_CierreEdicion();
   
    EditarPublicaciones_CierreEdicionForm();
  
});

function EditarPublicaciones_CierreEdicionForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_CierreEdicion)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_CierreEdicion').val(idPublicacion);
            $('#txtid_cierreedicion_Publicaciones_CierreEdicion').val('');         
            
            LoadData_ToModel(ObjModelPublicaciones_CierreEdicion, idPublicacion)
            .then(datoscargados => {
                if (datoscargados) { 
                    HabilitarControlesISBNPublicaciones_CierreEdicion();
                    FinalizeLoader();
                }
            })    
            .catch (err => {
                FinalizeLoader();
                ShowModalDialog(err, false, 'error', '', 0);
            })      
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  
}
  
function ValidatePostUpdatePublicacionCierreEdicionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_CierreEdicion)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos cierre edición guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function HabilitarControlISBNPublicaciones_CierreEdicion(controlestado, controlnro) {    
    document.getElementById(controlnro).disabled = true;
    document.getElementById(controlnro).required = false;

    if ($('#' + controlestado).val() == 1) {
        document.getElementById(controlnro).disabled = false;
        document.getElementById(controlnro).required = true;
    }

}

function HabilitarControlesISBNPublicaciones_CierreEdicion() {
    HabilitarControlISBNPublicaciones_CierreEdicion('cboisbndigital_Publicaciones_CierreEdicion','txtnroisbndigital_Publicaciones_CierreEdicion');
    HabilitarControlISBNPublicaciones_CierreEdicion('cboisbnimpreso_Publicaciones_CierreEdicion','txtnroisbnimpreso_Publicaciones_CierreEdicion');
    HabilitarControlISBNPublicaciones_CierreEdicion('cboisbndemanda_Publicaciones_CierreEdicion','txtnroisbndemanda_Publicaciones_CierreEdicion');    
}
  