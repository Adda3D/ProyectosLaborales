var ObjModelPublicaciones_IngresosPorVentas = null;

$(document).ready(function () {

    ObjModelPublicaciones_IngresosPorVentas = new Publicaciones_IngresosPorVentas();
   
    EditarPublicaciones_IngresosPorVentasForm();
  
});

function EditarPublicaciones_IngresosPorVentasForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();

      DatosPublicacionResolucionDistribucion(idPublicacion)
        .then(data => {
            if (data.Ok) {
                CreateHTMLFromModel(ObjModelPublicaciones_IngresosPorVentas)
                .then(htmlcreado => {
                    $('#txtid_crearpublicacion_Publicaciones_IngresosPorVentas').val(idPublicacion);
                    
                    document.getElementById('nmingresounitario_Publicaciones_IngresosPorVentas').step = '.01';
                    document.getElementById('nmcostounitario_Publicaciones_IngresosPorVentas').step = '.01';
                    document.getElementById('nmmargenvalor_Publicaciones_IngresosPorVentas').step = '.01';
                    document.getElementById('nmmargenporcentaje_Publicaciones_IngresosPorVentas').step = '.01';
                    document.getElementById('btnformPublicacionIngresosPorVentas').style.visibility = "visible";
             
                    if (htmlcreado) { 
                        LoadData_ToModel(ObjModelPublicaciones_IngresosPorVentas, idPublicacion)
                        .then(datosCargados => {
                            if (datosCargados) {
                                FinalizeLoader();
                            }                
                        })
                        .catch(err => {
                            FinalizeLoader();
                            ShowModalDialog(err, false, 'error', '', 0);
                        })    
                    }

                })
                .catch (err => {
                    FinalizeLoader();
                    ShowModalDialog(err, false, 'error', '', 0);
                })          
            }
            else {
                document.getElementById('btnformPublicacionIngresosPorVentas').style.visibility = "hidden";
                FinalizeLoader();
                let message = "No existe resolución aprobación de distribución para la publicación";
                ShowModalDialog(message, false, 'warning', '', 0);
            }
        })

}
  

function ObtenerDatosPublicacionIngresosPorVentasForm() {
    let idPublicacion = $("#spanIdPublicacion")[0].innerText;
    StartLoader();

    LoadData_ToModel(ObjModelPublicaciones_IngresosPorVentas, idPublicacion)
    .then(datosCargados => {
        if (datosCargados) {
            FinalizeLoader();
        }                
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })    

}

