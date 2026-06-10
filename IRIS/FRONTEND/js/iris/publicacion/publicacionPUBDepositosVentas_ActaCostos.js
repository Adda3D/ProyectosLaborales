var ObjModelPublicaciones_DepositoControlActa = null;

$(document).ready(function () {

    ObjModelPublicaciones_DepositoControlActa = new Publicaciones_DepositoControlActa();
   
    EditarPublicaciones_DepositoControlActaForm();
  
});

function EditarPublicaciones_DepositoControlActaForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   

      DatosPublicacionResolucionDistribucion(idPublicacion)
        .then(data => {
            if (data.Ok) {
                CreateHTMLFromModel(ObjModelPublicaciones_DepositoControlActa)
                .then(htmlcreado => {
                    $('#txtid_crearpublicacion_Publicaciones_DepositoControlActa').val(idPublicacion);
                    $('#txtid_actacosto_Publicaciones_DepositoControlActa').val('');                                        
                    document.getElementById('nmcostounitario_Publicaciones_DepositoControlActa').step = '.01';
                    document.getElementById('btnformPublicacionDistribucionActaCostos').style.visibility = "visible";
             
                    LoadData_ToModel(ObjModelPublicaciones_DepositoControlActa, idPublicacion)
                    .then(datoscargados => {
                        $('#nmtirajetotal_Publicaciones_DepositoControlActa').val(data.Data.tirajetotal);
                        if (datoscargados) {                     
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
            else {
                document.getElementById('btnformPublicacionDistribucionActaCostos').style.visibility = "hidden";
                FinalizeLoader();
                let message = "No existe resolución aprobación de distribución para la publicación";
                ShowModalDialog(message, false, 'warning', '', 0);
            }
        })

}
  

function ValidatePostUpdatePublicacionDistribucionActaCostosForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoControlActa)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Acta de Costos guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function Publicacion_TotalyCostoUnitario() {    
    SumarTotales('nmcostodirecto_Publicaciones_DepositoControlActa','nmcostoindirecto_Publicaciones_DepositoControlActa',null,null,'nmcostototal_Publicaciones_DepositoControlActa');

    let sTotalCosto = $('#nmcostototal_Publicaciones_DepositoControlActa').val();
    let sTirajeTotal = $('#nmtirajetotal_Publicaciones_DepositoControlActa').val(); 
    let nTirajetotal = Number(sTirajeTotal);
    let nTotalCosto = Number(sTotalCosto);
    let nCostoUnitario = 0;

    if (nTirajetotal > 0) {
        nCostoUnitario = nTotalCosto / nTirajetotal;
        nCostoUnitario = nCostoUnitario.toFixed(2);
    }

    $('#nmcostounitario_Publicaciones_DepositoControlActa').val(nCostoUnitario); 
}
  