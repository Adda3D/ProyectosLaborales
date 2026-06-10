/* let optSelectedReports;
 */
//let btnSendChartVal = document.getElementById("btnChartSelected");

//let btnReportSelected = document.getElementById("btnReportSelected");
/* let _id = "";
let _idCanvas = "";
let _tipoDeGrafico = ""; */
/* let divInputReportsButton = document.getElementById("_divButtonInputsReports");
 */
/* let RegistroAreaPublicadochart = null;
let PublicacionesxColeccionchart = null;
let RegistroFechaManuscritochart = null;
let ReportePresupuestalchart = null;
let ChartProyectosTotal = null;
let ChartPropuestasOrigen = null;
let ChartProyectosNombres;
let ChartPropuestasEntidades = null; */
/* let ChartEstadoProyectos = null;
 */
/* let _co = 0;
 */ /* let _divreportes = document.createElement("div");
 */ /* let _inputTypeNumber;
  let _inputTypeText = document.createElement("input");
  _inputTypeText.type = "text";
  _inputTypeNumber.type = "number"; */
/* _divreportes.className = "col";
 */
/* let _btnSendReporteSeleccionado = document.createElement("button");
 */
/* let _labelInputReport = document.createElement("LABEL");
_labelInputReport.className = "form-label-iris"; */
/* var ChartTotalPropuestas;
var ChartPropuestasModalidad;
var ChartPropuestasTipoUsuario; */
//-------------------------------------------------------------------------------------------------------

var barColors = [
  "rgb(0,0,255)",
  "rgb(163,93,238)",
  "rgb(115,200,142)",
  "rgb(215,95,135)",
  "rgb(95,195,215)",
  "rgb(223,169,217)",
  "rgb(217,248,120)",
  "rgb(158,196,249)",
  "rgb(158,196,249)",
  "rgb(242,249,158)",
  "rgb(133,145,7)",
  "rgb(226,151,11)",
  "rgb(243,98,175)",
  "rgb(228,225,175)",
  "rgb(30,210,175)",
  "rgb(250,136,120)",
  "rgb(250,195,105)",
  "rgb(252,252,175)",
  "rgb(252,252,175)",
];
var getDataColors = (opacity) => {
  const _colors = [
    "#7448c2",
    "#21c0d7",
    "#d99e2b",
    "#cd3a81",
    "#9c99cc",
    "#e14eca",
    "#ff0000",
    "#d6ff00",
    "#0038ff",
  ];
  return _colors.map((color) => (opacity ? `${color + opacity}` : color));
};
//dropdown que recibre el año y el semestre dentro del select
function createOptionSelect() {
  let semestreFiltrado = document.getElementById("semestreFiltrado");
  let urlDatos3 =
    urlController +
    "ProyectosCentroExtension/GetDropdownSemestre";
  fetch(urlDatos3, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;

        let semestres = lisDatos.map(function (e) {
          return e.Semestre;
        });

        //Eliminar los Duplicados Recibidos
        semestres = semestres.filter((value, index, self) => {
          return self.indexOf(value) === index;
        });

        semestres.forEach((element) => {
          let optionToInsert = document.createRange()
            .createContextualFragment(`<option value="${element}">  ${element}  </option>
    `);
          semestreFiltrado.appendChild(optionToInsert);
        });
      } 
    });
}

function loadChartPropuestasModalidad(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllPropuestasModalidad?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.modalidadpropuesta + " [" + e.totalmodalidadpropuesta + "] ";
        });
        var datos = lisDatos.map(function (e) {
          return e.totalmodalidadpropuesta;
        });
        let ChartPropuestasModalidad = new Chart(
          document.getElementById("propuestasXModalidad"),
          {
            type: "bar",
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderRadius: 5,
                  borderSkipped: false,
                  borderColor: getDataColors(),
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              indexAxis: "y",
              scales: {
                x: {
                  ticks: {
                    min: 0,
                    max: 500,
                    stepSize: 1,
                  },
                },
              },
              plugins: {
                legend: {
                  display: false,
                },
                title: {
                  display: true,
                  text: "Propuestas por Modalidad",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function loadChartTotalPropuestas(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllPropuestas?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.estadopropuesta + " [" + e.totalestadopropuesta + "]";
        });
        var datos = lisDatos.map(function (e) {
          return e.totalestadopropuesta;
        });
        let ChartTotalPropuestas = new Chart(
          document.getElementById("totalPropuestas"),
          {
            type: "pie",
            plugins: [ChartDataLabels],
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderSkipped: false,
                  borderColor: getDataColors(),
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              plugins: {
                tooltip: {
                  yAlign: "bottom",
                  callbacks: {},
                  enabled: true,
                },
                datalabels: {
                  formatter: (value, context) => {
                    return value;
                  },
                  color: "#fff",
                  anchor: "end",
                  align: "start",
                  offset: -10,
                  borderWidth: 2,
                  borderColor: "white",
                  borderRadius: 25,
                  backgroundColor: (context) => {
                    return context.dataset.backgroundColor;
                  },
                },
                legend: {
                  display: true,
                  position: "right",
                },
                title: {
                  display: true,
                  text: "Numero De Propuestas",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function loadChartPropuestasTipoUsuario(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllPropuestasTipoUsuario?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.nmpropuestatipousuario + " [" + e.totalportipousuario + "] ";
        });
        var datos = lisDatos.map(function (e) {
          return e.totalportipousuario;
        });
        let ChartPropuestasTipoUsuario = new Chart(
          document.getElementById("totalpropuestasportipousuario"),
          {
            type: "bar",
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderRadius: 5,
                  borderSkipped: false,
                  borderColor: getDataColors(),
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              indexAxis: "y",
              scales: {
                x: {
                  ticks: {
                    min: 0,
                    max: 500,
                    stepSize: 1,
                  },
                },
              },
              plugins: {
                legend: {
                  display: false,
                },
                title: {
                  display: true,
                  text: "Total Propuestas por Tipo de Usuario",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function loadChartPropuestasOrigen(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllPropuestasOrigen?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.origenpropuesta + " [" + e.totalorigenpropuesta + "] ";
        });
        var datos = lisDatos.map(function (e) {
          return e.totalorigenpropuesta;
        });
        let ChartPropuestasOrigen = new Chart(
          document.getElementById("totalorigenpropuesta"),
          {
            type: "bar",
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderRadius: 5,
                  borderSkipped: false,
                  borderColor: getDataColors(),
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              indexAxis: "y",
              scales: {
                x: {
                  ticks: {
                    min: 0,
                    max: 500,
                    stepSize: 1,
                  },
                },
              },
              plugins: {
                legend: {
                  display: false,
                },
                title: {
                  display: true,
                  text: "Total Propuestas De acuerdo a su Origen",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function loadChartNombresProyectosEjecucion(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllNombreProyectosEjecucion?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.nmmodalidad + " [" + e.cantmodalidad + "] ";
        });
        var datos = lisDatos.map(function (e) {
          return e.cantmodalidad;
        });
        let ChartProyectosNombres = new Chart(
          document.getElementById("nombresproyectosejecucion"),
          {
            type: "pie",
            plugins: [ChartDataLabels],
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderRadius: 5,
                  borderSkipped: false,
                  borderColor: getDataColors(),
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              plugins: {
                tooltip: {
                  yAlign: "bottom",
                  callbacks: {},
                  enabled: true,
                },
                datalabels: {
                  formatter: (value, context) => {
                    return value;
                  },
                  color: "#fff",
                  anchor: "end",
                  align: "start",
                  offset: -10,
                  borderWidth: 2,
                  borderColor: "white",
                  borderRadius: 25,
                  backgroundColor: (context) => {
                    return context.dataset.backgroundColor;
                  },
                },
                legend: {
                  display: true,
                  position: "right",
                },
                title: {
                  display: true,
                  text: "Modalidad Proyectos en Ejecución",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function loadChartTotalProyectosEjecucion(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllTotalProyectosEjecucion?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;

        var datos = lisDatos.map(function (e) {
          return e.totalproyectos;
        });
        let ChartProyectosTotal = new Chart(
          document.getElementById("totalproyectosejecucion"),
          {
            type: "bar",
            data: {
              labels: ["Total Proyectos en Ejecución"],
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderRadius: 5,
                  borderSkipped: false,
                  borderColor: getDataColors(),
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              indexAxis: "x",
              scales: {
                y: {
                  ticks: {
                    min: 0,
                    max: 500,
                    stepSize: 1,
                  },
                },
              },
              plugins: {
                legend: {
                  display: false,
                },
                title: {
                  display: true,
                  text: "Total Proyectos en Ejecución: " + "[" + datos + "] ",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}


function loadChartPropuestasEntidades(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllTotalEntidadesPropuestas?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.razonsocial + " [" + e.count + "] ";
        });
        var datos = lisDatos.map(function (e) {
          return e.count;
        });
        let ChartPropuestasEntidades = new Chart(
          document.getElementById("propuestasporentidades"),
          {
            type: "doughnut",
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 0.5,
                  borderSkipped: false,
                  borderColor: "white",
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              /* indexAxis: "y",
              scales: {
                x: {
                  ticks: {
                    min: 0,
                    max: 500,
                    stepSize: 1,
                  },
                },
              }, */
              plugins: {
                legend: {
                  display: true,
                  position: "bottom",
                  align: "start",
                  fullSize: true,
                },
                title: {
                  display: false,
                  text: "Propuestas por Entidades",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function loadChartEstadoProyectos(valueYear, valueRango1, valueRango2) {
  let urlDatos =
    urlController +
    `ProyectosCentroExtension/GetAllEstadoProyectos?annio=${valueYear}&rango1=${valueRango1}&rango2=${valueRango2}`;
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.transferenciascope;
        });
        var datos = lisDatos.map(function (e) {
          return e.total;
        });
        let ChartEstadoProyectos = new Chart(
          document.getElementById("estadoProyectos"),
          {
            type: "bar",
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderRadius: 5,
                  borderSkipped: false,
                  borderColor: getDataColors(),
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              indexAxis: "y",
              scales: {
                x: {
                  ticks: {
                    min: 0,
                    max: 500,
                    stepSize: 1,
                  },
                },
              },
              plugins: {
                legend: {
                  display: false,
                },
                title: {
                  display: true,
                  text: "Estado Proyectos",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function createDivChart(id, tipoDeGrafico, idCanvas) {
  let divcontainerAppendDivcanvaschartExtension = document.getElementById(
    "divcontainerAppendDivcanvaschart"
  );
  var divInnerChartsExtension = document.createRange()
    .createContextualFragment(`<div class="col-md-12" id="${id}">
<div class="col-md-12">
<label class="form-label-iris">${tipoDeGrafico}</label>
</div>                       

<div class="col-md-12" style = "
margin: auto;
height: 90vh;
width: 90vw;">   
<canvas id="${idCanvas}"></canvas>                        
</div>

</div>`);
  divcontainerAppendDivcanvaschartExtension.appendChild(
    divInnerChartsExtension
  );
}
function assignValueVariablesDivChart() {
  let id = "";
  let idCanvas = "";
  let tipoDeGrafico = "";

  //separar año y semestre
  let semestreFiltrado = document.getElementById("semestreFiltrado");
  var valueSemestre = semestreFiltrado.value;
  console.log(valueSemestre);
  let year = parseInt(valueSemestre.substring(0, 4)); // Los primeros 4 caracteres son el año
  let semester = valueSemestre.substring(5, 7); //el resto es el semestre

  let valueYear = year;
  let rango1, rango2;

  if(semester == "01"){ //si pertenece al primer semestre del año, se añade el rango del 1 al 6 mes 
    rango1 = 1;
    rango2 = 6
  }else{
    rango1=7;
    rango2=12
  }
  let chartSelectedExtension = document.getElementById("optionSelectedChart");
  var opSelectedExtension = chartSelectedExtension.value;
  if (
    (opSelectedExtension != "" && opSelectedExtension === "1") ||
    opSelectedExtension === "2" ||
    opSelectedExtension === "3" ||
    opSelectedExtension === "4" ||
    opSelectedExtension == "5" ||
    opSelectedExtension == "6" ||
    opSelectedExtension == "7" ||
    opSelectedExtension == "8"
  ) {
    createDivChart(id, tipoDeGrafico, idCanvas);
    if (opSelectedExtension === "1") {
      loadChartTotalPropuestas(valueYear, rango1, rango2);
    } else if (opSelectedExtension === "2") {
      loadChartPropuestasModalidad(valueYear, rango1, rango2);
    } else if (opSelectedExtension === "3") {
      loadChartPropuestasTipoUsuario(valueYear, rango1, rango2);
    } else if (opSelectedExtension === "4") {
      loadChartPropuestasOrigen(valueYear, rango1, rango2);
    } else if (opSelectedExtension === "5") {
      loadChartPropuestasEntidades(valueYear, rango1, rango2);
    } else if (opSelectedExtension === "6") {
      loadChartTotalProyectosEjecucion(valueYear, rango1, rango2);
    } else if (opSelectedExtension === "7") {
      loadChartNombresProyectosEjecucion(valueYear, rango1, rango2);
    } else if (opSelectedExtension === "8") {
      loadChartEstadoProyectos(valueYear, rango1, rango2);
    } 
  } else if (opSelectedExtension === "9") {
    for (let i = 1; i < 9; i++) {
      if (i === 1) {
        id = "Total_Propuestas";
        idCanvas = "totalPropuestas";
        tipoDeGrafico = "Numero Propuestas";

        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartTotalPropuestas(valueYear, rango1, rango2);
      }
      if (i === 2) {
        id = "propuestasmodalidad";
        idCanvas = "propuestasXModalidad";
        tipoDeGrafico = "Propuestas por Modalidad";

        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartPropuestasModalidad(valueYear, rango1, rango2);
      }
      if (i === 3) {
        id = "propTipoUsuario";
        idCanvas = "totalpropuestasportipousuario";
        tipoDeGrafico = "Propuestas por Tipo de usuario";

        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartPropuestasTipoUsuario(valueYear, rango1, rango2);
      }
      if (i === 4) {
        id = "propOrigenPropuesta";
        idCanvas = "totalorigenpropuesta";
        tipoDeGrafico = "Propuestas de Acuerdo a su Origen";

        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartPropuestasOrigen(valueYear, rango1, rango2);
      }
      if (i === 5) {
        id = "propEntidades";
        idCanvas = "propuestasporentidades";
        tipoDeGrafico = "Propuestas por Entidades";
        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartPropuestasEntidades(valueYear, rango1, rango2);
      }
      if (i === 6) {
        id = "totproyectosejecucion";
        idCanvas = "totalproyectosejecucion";
        tipoDeGrafico = "Proyectos en Ejecucion";

        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartTotalProyectosEjecucion(valueYear, rango1, rango2);
      }
      if (i === 7) {
        id = "modproyectosejecucion";
        idCanvas = "nombresproyectosejecucion";
        tipoDeGrafico = "Modalidad Proyectos en Ejecucion";

        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartNombresProyectosEjecucion(valueYear, rango1, rango2);
      }
      if (i === 8) {
        id = "EstadoXProyectos";
        idCanvas = "estadoProyectos";
        tipoDeGrafico = "Seguimiento Estado Proyectos";

        createDivChart(id, tipoDeGrafico, idCanvas);
        loadChartEstadoProyectos(valueYear, rango1, rango2);
      }
    }
  } 
}
function clear() {
  let divcontainerAppendDivcanvaschart = document.getElementById(
    "divcontainerAppendDivcanvaschart"
  );
  divcontainerAppendDivcanvaschart.innerHTML = "";
}
function destroyItems() {
  if (ChartTotalPropuestas != null) {
    ChartTotalPropuestas.destroy();
  }
  if (ChartPropuestasModalidad != null) {
    ChartPropuestasModalidad.destroy();
  }
  if (ChartPropuestasTipoUsuario != null) {
    ChartPropuestasTipoUsuario.destroy();
  }
  if (ChartPropuestasOrigen != null) {
    ChartPropuestasOrigen.destroy();
  }
  if (ChartProyectosTotal != null) {
    ChartProyectosTotal.destroy();
  }
  if (ChartProyectosNombres != null) {
    ChartProyectosNombres.destroy();
  }
  if (ChartPropuestasEntidades != null) {
    ChartPropuestasEntidades.destroy();
  }
  if (ChartEstadoProyectos != null) {
    ChartEstadoProyectos.destroy();
  }
}

function btnShowChart() {
  let divcontainerAppendDivcanvaschartExtension = document.getElementById(
    "divcontainerAppendDivcanvaschart"
  );
  let id = "";
  let idCanvas = "";
  let tipoDeGrafico = "";
  let semestreFiltrado = document.getElementById("semestreFiltrado");
  var semestreError = semestreFiltrado.value;
  let chartSelectedExtension = document.getElementById("optionSelectedChart");
  var optSelectedExtension = chartSelectedExtension.value;
  if (optSelectedExtension != "" && semestreError != "") {
    switch (optSelectedExtension) {
      case "1":
        id = "Total_Propuestas";
        idCanvas = "totalPropuestas";
        tipoDeGrafico = "Numero Propuestas";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );

        //    _destroyItems();
        break;
      case "2":
        id = "propuestasmodalidad";
        idCanvas = "propuestasXModalidad";
        tipoDeGrafico = "Propuestas por Modalidad";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );

        //    _destroyItems();
        break;
      case "3":
        id = "propTipoUsuario";
        idCanvas = "totalpropuestasportipousuario";
        tipoDeGrafico = "Propuestas por Tipo de usuario";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );

        //  _destroyItems();
        break;
      case "4":
        id = "propOrigenPropuesta";
        idCanvas = "totalorigenpropuesta";
        tipoDeGrafico = "Propuestas de Acuerdo a su Origen";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );

        //    _destroyItems();
        break;
      case "5":
        id = "propEntidades";
        idCanvas = "propuestasporentidades";
        tipoDeGrafico = "Propuestas por Entidades";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );
        //    _destroyItems();
        break;
      case "6":
        id = "totproyectosejecucion";
        idCanvas = "totalproyectosejecucion";
        tipoDeGrafico = "Proyectos en Ejecucion";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );

        //  _destroyItems();
        break;
      case "7":
        id = "modproyectosejecucion";
        idCanvas = "nombresproyectosejecucion";
        tipoDeGrafico = "Modalidad Proyectos en Ejecucion";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );

        //  _destroyItems();
        break;
      case "8":
        id = "EstadoXProyectos";
        idCanvas = "estadoProyectos";
        tipoDeGrafico = "Seguimiento Estado Proyectos";
        clear();
        createDivChart(id, tipoDeGrafico, idCanvas);
        assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschartExtension.removeChild(
          divcontainerAppendDivcanvaschartExtension.childNodes[1]
        );

        //  _destroyItems();
        break;
      case "9":
        debugger;
        clear();
        assignValueVariablesDivChart();
        break;
      default:
        break;
    }
  } 
    else {    
      clear();
      ShowModalDialog(
        "Seleccione: Grafico " + "y " + "Semestre",
        false,
        "warning",
        "",
        0
      );
    }      
}



//muestra el semestre dentro del select
function showChartsDefault() {
  createOptionSelect();
}
showChartsDefault();

//Excel
function _GenerarReporteExcelGenerico(_urlreporte) {
  let _urlExcel = urlController + _urlreporte;
  // `ProyectosCentroExtension/ExcelMatrizConoPropuestas?id_propuesta=${parameterNumber}`;
  StartLoader();

  fetch(_urlExcel, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        FinalizeLoader();
        location.href = urlDownload + data.Data;
        return;
      } else {
        FinalizeLoader();
        ShowModalDialog(data.Message, false, "warning", "", 0);
        return;
      }
    })
    .catch((err) => {
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function btnDownloadReport() {
  let optSelectedReports = document.getElementById("optionSelectedReport");
  var _opSelect = optSelectedReports.value;
  if (_opSelect != "") {
    switch (_opSelect) {
      case "1":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelBalancePropuestas`
        );

        break;
      case "2":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelListadoPropuesta`
        );
        break;
      case "3":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelProyeccionProximosProyectos`
        );
        break;
      case "4":
        _GenerarReporteExcelGenerico(
          "ProyectosCentroExtension/ExcelProyectosPEC"
        );
        break;
      case "5":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelMatrizConoPropuestas`
        );
        //MatrizConoPropuestasExcel();
        break;
      case "6":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelMatrizLiquidacionFinalizacionProyectos`
        );
        break;
      case "7":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelMatrizAsignacionProyectos`
        );
        break;
      case "8":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelNumProyectos`
        );
        break;
      case "9":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelTablaRegistroProyectos`
        );
        break;
      case "10":
        _GenerarReporteExcelGenerico(
          "ProyectosCentroExtension/ExcelSeguimientoCumplimientoContrapartidas"
        );
        break;
      case "11":
        _GenerarReporteExcelGenerico(
          "ProyectosCentroExtension/ExcelProyectosPendientesIngreso"
        );
        break;
      case "12":
        _GenerarReporteExcelGenerico(
          "ProyectosCentroExtension/ExcelSeguimientoSuscripcionActasLiquidacion"
        );
        break;
      case "13":
        _GenerarReporteExcelGenerico(
          "ProyectosCentroExtension/ExcelEstadoProyectos"
        );
        break;
      default:
        break;
    }
  } else {
    _clearInputReports();
    ShowModalDialog("Seleccione: Reporte   ", false, "warning", "", 0);
  }
}
