function ExistePublicacionResolucionDistribucion(idPublicacion) { 
    let urlValidar = urlController + "Publicaciones_DepositoResolucion/GetPublicaciones_DepositoResolucionByPublicacion?id_crearpublicacion=" + idPublicacion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                return true;
            }
            else {
                return false;
            }            
          })
          .then( resultado => {
            return resolve(resultado);
          }) 
          .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      });

}

function DatosPublicacionResolucionDistribucion(idPublicacion) { 
    let urlValidar = urlController + "Publicaciones_DepositoResolucion/GetPublicaciones_DepositoResolucionByPublicacion?id_crearpublicacion=" + idPublicacion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
             resolve(data);
          })
          .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      });

}

function DatosConceptoEditorialResenaCubierta(idPublicacion) {
  let urlConceptoPublicacion = urlController + "Publicaciones_ConceptoEditorial/GetPublicaciones_ConceptoEditorialByPublicacion?id_crearpublicacion=" + idPublicacion;  

  return new Promise( (resolve, reject) => {
    fetch(urlConceptoPublicacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                
//          $('#' + htmlcontrol ).val(data.Data.resenacubierta);
          resolve(data.Data.resenacubierta);
        }
        else {
          resolve('');
        }            
      })
      .then( resultado => {
        return resolve(resultado);
      }) 
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
        reject(err);
      } );
  });


}

