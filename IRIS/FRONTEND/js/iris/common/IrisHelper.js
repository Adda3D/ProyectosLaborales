/* function GenerarConsecutivoDctoDependencia(controlfecha, controlidprefijo, controlprefijo) {
    let fechaconsecutivo = $('#' + controlfecha).val();
    let id_prefijoconsecutivo = $('#' + controlidprefijo).val();

    if (id_prefijoconsecutivo == undefined){
        return;
    }

    let urldatos = urlController + "Consecutivo_Annio/GetConsecutivo_Annio?id_prefijoconsecutivo=" + id_prefijoconsecutivo + "&fecha=" + fechaconsecutivo;    
  
    return new Promise( (resolve, reject) => {
      fetch(urldatos, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
        .then(data => {
            if (data.Ok) {
                $('#' + controlprefijo).val(data.Data);
                
                return resolve(true);;
            }
            else {
                return resolve(false);;
            }            
        })
        .catch (err => {
          ShowModalDialog(err, false, 'error', '', 0);
          reject(err);
        } );
    });    
} */