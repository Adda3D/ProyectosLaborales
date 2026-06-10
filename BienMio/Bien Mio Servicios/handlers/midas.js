const Estate = require("../models/Estate");
const _ = require("lodash");
const axios = require("axios").default;

const baseUrl = "https://midas.cartagena.gov.co/api";

exports.FindEstate = (cadastralReference = undefined) => {
  let state = undefined;
  if (cadastralReference) {
    const data = {
      criterio: cadastralReference, //"010100790010000",
      layersVisible: ["Predios"],
    };
    state = new Promise((resolve, reject) => {
      axios
        .post(`${baseUrl}/Search/Criterio`, data)
        .then((res) => {
          const data = res.data;
          let dataProcessed = undefined;
          if ((data.estado = "ok")) {
            if (data.datos !== null) {
              data.datos.map((item) =>{
                if (item.capa ==="Predios"){
                  dataProcessed = item
                }
              })
              // dataProcessed = _.find(data.datos, (item) => {
              //   item.capa === "Predios";
              // });
              console.log(dataProcessed);
              resolve(dataProcessed.resultado[0].data.INFORMACION);
            }
          }
          resolve(undefined);
        })
        .catch(function (e) {
          reject(e);
        });
    });
  }
  return state;
};
