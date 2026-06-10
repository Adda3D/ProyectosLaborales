var ObjModelPublicaciones_Inventario = null;

$(document).ready(function () {

    ObjModelPublicaciones_Inventario = new Publicaciones_Inventario();
   
    EditarPublicaciones_InventarioForm();
  
});

function EditarPublicaciones_InventarioForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();

      DatosPublicacionResolucionDistribucion(idPublicacion)
        .then(data => {
            if (data.Ok) {
                CreateHTMLFromModel(ObjModelPublicaciones_Inventario)
                .then(htmlcreado => {
                    $('#txtid_crearpublicacion_Publicaciones_Inventario').val(idPublicacion);
                    
                    document.getElementById('btnformPublicacionInventario').style.visibility = "visible";
             
                    if (htmlcreado) { 
                        LoadData_ToModel(ObjModelPublicaciones_Inventario, idPublicacion)
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
                document.getElementById('btnformPublicacionInventario').style.visibility = "hidden";
                FinalizeLoader();
                let message = "No existe resolución aprobación de distribución para la publicación";
                ShowModalDialog(message, false, 'warning', '', 0);
            }
        })

}
  

function ObtenerDatosPublicacionInventarioForm() {
    let idPublicacion = $("#spanIdPublicacion")[0].innerText;
    StartLoader();

    LoadData_ToModel(ObjModelPublicaciones_Inventario, idPublicacion)
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

