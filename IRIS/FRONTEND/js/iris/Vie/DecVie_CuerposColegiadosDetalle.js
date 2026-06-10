var ObjModelDecVie_CuerposColegiados = null;


$(document).ready(function () {

  ObjModelDecVie_CuerposColegiados = new DecVie_CuerposColegiados();

    if ($("#spanIdDecVie_CuerposColegiados")[0].innerText == '') {
        CrearDecVie_CuerposColegiadosform();
    }
    else {
        EditarDecVie_CuerposColegiadosform($("#spanIdDecVie_CuerposColegiados")[0].innerText);
    }

});

function CerrarDecVie_CuerposColegiadosDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_CuerposColegiados);
    
    $("#dvDecVie_CuerposColegiadosDetalle").addClass("ocultar");    
    $("#dvDecVie_CuerposColegiadosTable").removeClass("ocultar");

}

function CrearDecVie_CuerposColegiadosform() {
    $("#spanIdDecVie_CuerposColegiadosForm")[0].innerText = '';
    $("#txtid_cuerposcolegiados_DecVie_CuerposColegiados").val('');   
    StartLoader();    
  //  alert('CrearDecVie_CuerposColegiadosform 1 ');

    NewData_ToModel(ObjModelDecVie_CuerposColegiados)
        .then(datospreparados => {
            if (datospreparados) { 
                FinalizeLoader();
              //  alert('CrearDecVie_CuerposColegiadosform 2 ');

                $("#dvDecVie_CuerposColegiadosTable").addClass("ocultar");    
                $("#dvDecVie_CuerposColegiadosDetalle").removeClass("ocultar");            
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  

}

function EditarDecVie_CuerposColegiadosform(idcuerposcolegiados) {
    $("#spanIdDecVie_CuerposColegiadosForm")[0].innerText = idcuerposcolegiados;
    $("#txtid_cuerposcolegiados_DecVie_CuerposColegiados").val(idcuerposcolegiados);
    StartLoader();    

    LoadData_ToModel(ObjModelDecVie_CuerposColegiados, idcuerposcolegiados)
        .then(datoscargados => {
            if (datoscargados) { 
                FinalizeLoader();

                $("#dvDecVie_CuerposColegiadosTable").addClass("ocultar");    
                $("#dvDecVie_CuerposColegiadosDetalle").removeClass("ocultar");            
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  

}

function ValidatePostUpdateDecVie_CuerposColegiados(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_CuerposColegiados)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos Cuerpo Colegiado Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_CuerposColegiados();
      CerrarDecVie_CuerposColegiadosDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

