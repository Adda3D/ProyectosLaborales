import axios from "axios";
import _ from "lodash";

// const axios = require("axios").default;

const baseUrl = "https://midas.cartagena.gov.co/api";

export const findEstate = (cadastralReference) => {
  let state = undefined;
  const reference = (cadastralReference.replace("\n", "")).trim();
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
              resolve(dataProcessed.resultado[0].data.INFORMACION);
            }
          }
          resolve(undefined);
        })
        .catch(function (e) {
          reject(e);
        });
    });
  return state;
};
