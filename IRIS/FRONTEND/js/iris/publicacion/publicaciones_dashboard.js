//var optSelectedReports = document.querySelector("#selectReportesExcel");
//var btnSendChartVal = document.getElementById("btnGraficoSeleccionado");

//var btnReportSelected = document.querySelector("#btnReporteSeleccionado");

//var divInputReportsButton = document.querySelector("#divButtonInputsReports");
/* let parameterNumber = null;
let parameterString = null;
var RegistroAreaPublicadochart = null;
var PublicacionesxColeccionchart = null;
var RegistroFechaManuscritochart = null;
var ReportePresupuestalchart = null; */

/* var _co = 0;
var _divreportes = document.createElement("div");
var _inputTypeNumber = document.createElement("input");
var _inputTypeText = document.createElement("input");
_inputTypeText.type = "text";
_inputTypeNumber.type = "number";
_divreportes.className = "col"; */
//var _btnSendReporteSeleccionado = document.createElement("button");
/* var _labelInputReport = document.createElement("LABEL");
_labelInputReport.className = "form-label-iris"; */

//-------------------------------------------------------------------------------------------------------

var _barColors = [
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
var _getDataColors = (opacity) => {
  const colors = [
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
  return colors.map((color) => (opacity ? `${color + opacity}` : color));
};
function _loadChartPublicacionesxColeccion() {
  let urlDatos =
  urlController + `Publicaciones_DashBoard/RegistrosPublicacionesPorColeccion`;
StartLoader();
fetch(urlDatos, {
  method: "GET",
  headers: { Authorization: "Bearer " + TokenIRIS },
})
  .then((response) => response.json())
  .then((data) => {
    if (data.Ok) {
      var lisDatosArea = data.Data;
      console.log(lisDatosArea)
      if (lisDatosArea.length != 0) {
        var labels = lisDatosArea.map(function (e) {
          return e.colección + ' [' + e.año + '] ';;
        });
        var datos = lisDatosArea.map(function (e) {
          return e.count;
        });
        
        RegistroAreaPublicadochart = new Chart(
          document.getElementById("publicacionesxColeccion"),
          {
            type: "bar",
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: _getDataColors(),
                  data: datos,
                  borderWidth: 2,
                  borderRadius: 5,
                  borderSkipped: false,
                  borderColor: _getDataColors(),
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
                  text: "Publicaciones Por Coleccion",
                },
              },
            },
          }
        );
        FinalizeLoader();
      } else {
        StartLoader();
        ShowModalDialog(
          "No hay suficientes datos" + " para" + " Graficar ",
          false,
          "warning",
          "",
          0
        );
        FinalizeLoader();
      }
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

function appendInputfilterYear() {
  let InputAppend = false;
  let inputFilteryear = null;

  var divSelectChartPublicaciones = document.querySelector(
    "#divSelectChartPublicaciones"
  );
  if (!InputAppend) {
    inputFilteryear = document.createRange()
      .createContextualFragment(`<input id="inputFilterYears" type="number" pattern="[0-9]*" maxlength="4" min="2016" placeholder="Ingresa un año"  required>
  `);

    divSelectChartPublicaciones.appendChild(inputFilteryear);
    InputAppend = true;
  }
}
function appendInputfilterEvaluaciones() {
  let InputAppend = false;
  let inputFilteryear = null;

  var divSelectChartPublicaciones = document.querySelector(
    "#divSelectChartPublicaciones"
  );
  if (!InputAppend) {
    inputFilteryear = document.createRange()
      .createContextualFragment(`<input id="inputFilterEcvaluaciones" type="number" pattern="[0-9]*" maxlength="4" min="2016" placeholder="Año de Evaluacion"  required>
  `);

    divSelectChartPublicaciones.appendChild(inputFilteryear);
    InputAppend = true;
  }
}
//let inpFilterYears = document.getElementById("#inputFilterYears");

function _loadChartAllManuscritoxAnio() {
  let urlDatos =
    urlController +
    "Publicaciones_DashBoard/RegistrosPorFechaManuscritoPublicado";
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        if (lisDatos.length != 0) {
          var labels = lisDatos.map(function (e) {
            return e.anopublicacion + ' [' + e.cantidad + '] ';
          });
          var datos = lisDatos.map(function (e) {
            return e.cantidad;
          });

          RegistroFechaManuscritochart = new Chart(
            document.getElementById("AnioPublicacionManuscrito"),
            {
              type: "pie",
              plugins: [ChartDataLabels],
              data: {
                labels: labels,
                datasets: [
                  {
                    label: "Cantidad",
                    backgroundColor: _getDataColors(),
                    data: datos,
                    borderWidth: 2,
                    borderRadius: 5,
                    borderSkipped: false,
                    borderColor: _getDataColors(),
                  },
                ],
              },
              options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                  tooltip: {
                    yAlign: "bottom",
                    callbacks: {

                    },
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
                    position: 'right'
                  },
                  title: {
                    display: true,
                    text: "Manuscritos Publicados por Año",
                  },
                },
              },
            }
          );
          FinalizeLoader();
        } else {
          StartLoader();
          ShowModalDialog(
            "No hay suficientes datos" + " para" + " Graficar ",
            false,
            "warning",
            "",
            0
          );
          FinalizeLoader();
        }
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

function _loadChartManuscritoxAnio() {
    let añoInputFilter = divSelectChartPublicaciones.childNodes[9].value;
  let urlDatos =
    urlController +
    "Publicaciones_DashBoard/RegistrosPorFechaManuscritoPublicado";
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.anopublicacion;
        });
        var datos = lisDatos.map(function (e) {
          let cant = null;
          if(añoInputFilter == e.anopublicacion){
            cant= e.cantidad
          }
          console.log(cant)

          return cant;
        }); 
        let cant = 0;

        lisDatos.forEach((e) => {
          if (añoInputFilter == e.anopublicacion) {
            cant = e.cantidad;
          }
          console.log(cant);
        });
        if (cant != 0) {
          RegistroFechaManuscritochart = new Chart(
            document.getElementById("AnioPublicacionManuscrito"),
            {
              type: "bar",
              data: {
                labels: [añoInputFilter],
                datasets: [
                  {
                    label: "Cantidad",
                    backgroundColor: _getDataColors(),
                    data: [cant],
                    borderWidth: 2,
                    borderRadius: 5,
                    borderSkipped: false,
                    borderColor: _getDataColors(),
                  },
                ],
              },
              options: {
                responsive: true,
                maintainAspectRatio: false,

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
                    text: "Manuscritos Publicados por Año",
                  },
                },
              },
            }
          );
          FinalizeLoader();
        } else {
          StartLoader();
          ShowModalDialog(
            "No hay suficientes datos" + " para" + " Graficar ",
            false,
            "warning",
            "",
            0
          );
          FinalizeLoader();
        }
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
function _loadChartPublicacionesxArea(iniAnio, finAnio) {
  let urlDatos =
    urlController + `Publicaciones_DashBoard/RegistrosPorAreaPublicado?rango1=${iniAnio}&rango2=${finAnio}`;
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatosArea = data.Data;
        console.log(lisDatosArea)
        if (lisDatosArea.length != 0) {
          var labels = lisDatosArea.map(function (e) {
            return e.nmaacad + ' [' + e.anopublicacion + '] ';
          });
          var datos = lisDatosArea.map(function (e) {
            return e.cantidad;
          });
          RegistroAreaPublicadochart = new Chart(
            document.getElementById("TotalPublicacionesPorArea"),
            {
              type: "bar",
              data: {
                labels: labels,
                datasets: [
                  {
                    label: "Cantidad",
                    backgroundColor: _getDataColors(),
                    data: datos,
                    borderWidth: 2,
                    borderRadius: 5,
                    borderSkipped: false,
                    borderColor: _getDataColors(),
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
                    text: "Total Publicaciones por Area",
                  },
                },
              },
            }
          );
          FinalizeLoader();
        } else {
          StartLoader();
          ShowModalDialog(
            "No hay suficientes datos" + " para" + " Graficar ",
            false,
            "warning",
            "",
            0
          );
          FinalizeLoader();
        }
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
function _loadChartPublicacionesxEstado() {
  let urlDatos =
    urlController + "Publicaciones_DashBoard/RegistrosPublicacionesPorEstado";
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatosArea = data.Data;
        if (lisDatosArea.length != 0) {
          var labels = lisDatosArea.map(function (e) {
            return e.estadomanuscrito + ' [' + e.cantidad + '] ';
          });
          var datos = lisDatosArea.map(function (e) {
            return e.cantidad;
          });
          RegistroAreaPublicadochart = new Chart(
            document.getElementById("TotalPublicacionesPorEstado"),
            {
              type: "bar",
              data: {
                labels: labels,
                datasets: [
                  {
                    label: "Cantidad",
                    backgroundColor: _getDataColors(),
                    data: datos,
                    borderWidth: 2,
                    borderRadius: 5,
                    borderSkipped: false,
                    borderColor: _getDataColors(),
                  },
                ],
              },
              options: {
                responsive: true,
                maintainAspectRatio: false,

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
                    text: "Total Publicaciones por Estado",
                  },
                },
              },
            }
          );
          FinalizeLoader();
        } else {
          StartLoader();
          ShowModalDialog(
            "No hay suficientes datos" + " para" + " Graficar ",
            false,
            "warning",
            "",
            0
          );
          FinalizeLoader();
        }
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
function _loadChartReportePresupuestal() {
  let urlDatos =
    urlController +
    "Publicaciones_DashBoard/ReportePresupuestalPublicacionesSemestre";
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        if (lisDatos.length != 0) {
          var labels = lisDatos.map(function (e) {
            return e.estadomanuscrito;
          });
          var totServicioEditorial = lisDatos.map(function (e) {
            return e.totalservicioeditorial;
          });
          var valorProyectado = data.Data[0].valorproyectado;
          totServicioEditorial.push(valorProyectado);
          labels.push("valor proyectado");
          ReportePresupuestalchart = new Chart(
            document.getElementById("reportePresupuestal"),
            {
              type: "pie",
              plugins: [ChartDataLabels],
              data: {
                labels: labels,
                datasets: [
                  {
                    label: "Cantidad",
                    backgroundColor: _getDataColors(),
                    data: totServicioEditorial,
                  },
                ],
              },
              options: {
                responsive: true,
                maintainAspectRatio: false,

                plugins: {
                  tooltip: {
                    yAlign: "bottom",
                    callbacks: {
                      afterTitle: (context) => {
                        var porcentaje = (
                          (context[0].parsed * 100) /
                          valorProyectado
                        ).toFixed(1);
                        return porcentaje + "%";
                      },
                    },
                    enabled: true,
                  },
                  datalabels: {
                    formatter: (value, context) => {
                      var porcentaje = (
                        (value * 100) /
                        valorProyectado
                      ).toFixed(1);
                      return porcentaje + "%";
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
                  },
                  title: {
                    display: true,
                    text: "Reporte Presupuestal",
                  },
                },
              },
            }
          );
          FinalizeLoader();
        } else {
          StartLoader();
          ShowModalDialog(
            "No hay suficientes datos" + " para" + " Graficar ",
            false,
            "warning",
            "",
            0
          );
          FinalizeLoader();
        }
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
function _loadChartEstadoEvaluaciones(anioEvaluacion) {
  let urlDatos =
    urlController + `Publicaciones_DashBoard/EstadoEvaluaciones?anio=${anioEvaluacion}`;
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatosArea = data.Data;
        console.log(lisDatosArea)
        if (lisDatosArea.length != 0) {
          var labels = lisDatosArea.map(function (e) {
            return e.nmconcepto;
          });
          var datos = lisDatosArea.map(function (e) {
            return e.count;
          });
          RegistroAreaPublicadochart = new Chart(
            document.getElementById("reporteEvaluaciones"),
            {
              type: "bar",
              data: {
                labels: labels,
                datasets: [
                  {
                    label: "Cantidad",
                    backgroundColor: _getDataColors(),
                    data: datos,
                    borderWidth: 2,
                    borderRadius: 5,
                    borderSkipped: false,
                    borderColor: _getDataColors(),
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
                    text: "Estado de las evaluaciones",
                  },
                },
              },
            }
          );
          FinalizeLoader();
        } else {
          StartLoader();
          ShowModalDialog(
            "No hay suficientes datos" + " para" + " Graficar ",
            false,
            "warning",
            "",
            0
          );
          FinalizeLoader();
        }
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
/* function loadChartProyectosModalidad() {
  let urlDatos =
    urlController + "ProyectosCentroExtension/GetAllProyectosModalidad";
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.nmmodalidad;
        });
        var datos = lisDatos.map(function (e) {
          return e.count;
        });
        chartPublicacionesxColeccion = new Chart(
          document.getElementById("proyectosXModalidad"),
          {
            type: "bar",
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
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
                  text: "Proyectos por Modalidad",
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
} */

/*function loadChartTotalProyectos() {
  let urlDatos = urlController + "ProyectosCentroExtension/GetAllProyectos";
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        /* var labels = lisDatos.map(function (e) {
          return e.nmmodalidad;
        }); 
        var datos = lisDatos.map(function (e) {
          return e.totalproyectos;
        });
        chartPublicacionesxColeccion = new Chart(
          document.getElementById("totalProyectos"),
          {
            type: "bar",
            data: {
              labels: ["Total Proyectos"],
              datasets: [
                {
                  label: "Cantidad",
                  backgroundColor: getDataColors(),
                  data: datos,
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
                  text: "Total De Proyectos",
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
*/

function _createDivChart(_id, _tipoDeGrafico, _idCanvas) {
  var divcontainerAppendDivcanvaschart =
    document.querySelector("#divContainer");

  var divInnerChartsPublicaciones = document.createRange()
    .createContextualFragment(`<div class="col-md-12" id="${_id}">
<div class="col-md-12">
<label class="form-label-iris">${_tipoDeGrafico}</label>
</div>                       

<div class="col-md-12" style = "position: relative;
margin: auto;
height: 90vh;
width: 90vw;">   
<canvas id="${_idCanvas}"></canvas>                        
</div>

</div>`);
  divcontainerAppendDivcanvaschart.appendChild(divInnerChartsPublicaciones);
}
function _assignValueVariablesDivChart() {
  var chartSelected = document.querySelector("#GraficoSeleccionado");

  var _id = "";
  var _idCanvas = "";
  var _tipoDeGrafico = "";
  var opSelect = chartSelected.value;
  if (
    (opSelect != "" && opSelect === "1") ||
    opSelect === "2" ||
    opSelect === "3" ||
    opSelect === "4" ||
    opSelect === "5" ||
    opSelect === "6"
  ) {
    _createDivChart(_id, _tipoDeGrafico, _idCanvas);
    if (opSelect === "1") {
      _loadChartManuscritoxAnio();
    } else if (opSelect === "2") {
      debugger
      let iniFecha = inputFilterFecha1.value
      let finFecha = inputFilterFecha2.value
      console.log(iniFecha, finFecha)
      _loadChartPublicacionesxArea(iniFecha, finFecha);
    } else if (opSelect === "3") {
      _loadChartPublicacionesxColeccion();
    } else if (opSelect === "4") {
      _loadChartPublicacionesxEstado();
    } else if (opSelect === "5") {
      _loadChartReportePresupuestal();
    } else if (opSelect === "6") {
      let anioEvaluacion = inputFilterEcvaluaciones.value
      _loadChartEstadoEvaluaciones(anioEvaluacion);
    }
  } else if (opSelect === "8") {
    for (let i = 1; i < 8; i++) {
      if (i === 1) {
        _id = "manuscritoxAnio";
        _idCanvas = "AnioPublicacionManuscrito";
        _tipoDeGrafico = "Manuscritos publicados por Año";

        _createDivChart(_id, _tipoDeGrafico, _idCanvas);
        _loadChartAllManuscritoxAnio();
      }
      if (i === 2) {
        _id = "publicacionesxArea";
        _idCanvas = "TotalPublicacionesPorArea";
        _tipoDeGrafico = "Publicaciones por Area";

        _createDivChart(_id, _tipoDeGrafico, _idCanvas);
        _loadChartPublicacionesxArea();
      }
      if (i === 3) {
        _id = "idcoleccion";
        _idCanvas = "publicacionesxColeccion";
        _tipoDeGrafico = "Publicaciones por Coleccion";
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);
        _loadChartPublicacionesxColeccion();
      }
      if (i === 4) {
        _id = "idEstado";
        _idCanvas = "TotalPublicacionesPorEstado";
        _tipoDeGrafico = "Publicaciones por Estado";
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);
        _loadChartPublicacionesxEstado();
      }
      if (i === 5) {
        _id = "idPresupuestal";
        _idCanvas = "reportePresupuestal";
        _tipoDeGrafico = "Reporte Presupuestal";
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);
        _loadChartReportePresupuestal();
      }
      if (i === 6) {
        _id = "idEvaluaciones";
        _idCanvas = "reporteEvaluaciones";
        _tipoDeGrafico = "Reporte Evaluaciones";
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);
        _loadChartEstadoEvaluaciones();
      }
    }
  }
}
function _clear() {
  var divcontainerAppendDivcanvaschart =
    document.querySelector("#divContainer");

  divcontainerAppendDivcanvaschart.innerHTML = "";
}
function _destroyItems() {
  if (PublicacionesxColeccionchart != null) {
    PublicacionesxColeccionchart.destroy();
  } else if (RegistroFechaManuscritochart != null) {
    RegistroFechaManuscritochart.destroy();
  } else if (RegistroAreaPublicadochart != null) {
    RegistroAreaPublicadochart.destroy();
  } else if (ReportePresupuestalchart != null) {
    ReportePresupuestalchart.destroy();
  }
}

function showInputFilterYear() {

  var divSelectChartPublicaciones = document.querySelector(
    "#divSelectChartPublicaciones"
  );
  var chartSelected = document.querySelector("#GraficoSeleccionado");

  var optSelected = chartSelected.value;
  let inputEliminar = divSelectChartPublicaciones.childNodes[9];
  let inputYearAreaCurricular = divSelectChartPublicaciones.childNodes[10];
  let inputYearAreaCurricular2 = divSelectChartPublicaciones.childNodes[11];
  let inputYearAreaCurricular3 = divSelectChartPublicaciones.childNodes[12];
  console.log("matriz "+ divSelectChartPublicaciones.childNodes)
  if (optSelected == "1") {
    if (divSelectChartPublicaciones.childNodes[9]) {
      divSelectChartPublicaciones.removeChild(inputEliminar);
    }
    appendInputfilterYear();
  }

  if (optSelected == "2") {
    if (divSelectChartPublicaciones.childNodes[10] && divSelectChartPublicaciones.childNodes[11] || divSelectChartPublicaciones.childNodes[12]) {
      divSelectChartPublicaciones.removeChild(inputYearAreaCurricular);
      divSelectChartPublicaciones.removeChild(inputYearAreaCurricular2);
    }
    appendInputFecha()
  }
  
  if (optSelected != "2" && divSelectChartPublicaciones.childNodes[10] && divSelectChartPublicaciones.childNodes[11]) {
    divSelectChartPublicaciones.removeChild(inputYearAreaCurricular);
    divSelectChartPublicaciones.removeChild(inputYearAreaCurricular2);
    divSelectChartPublicaciones.removeChild(inputYearAreaCurricular3);
  }
  if (optSelected == "6") {
    if (divSelectChartPublicaciones.childNodes[9]) {
      divSelectChartPublicaciones.removeChild(inputEliminar);
    }
    appendInputfilterEvaluaciones();
  }
  if (optSelected != "6" && divSelectChartPublicaciones.childNodes[9]) {
    divSelectChartPublicaciones.removeChild(inputEliminar);
  }
  if (optSelected != "1" && divSelectChartPublicaciones.childNodes[9]) {
    divSelectChartPublicaciones.removeChild(inputEliminar);
  }

  console.log(divSelectChartPublicaciones.childNodes)
}
function appendInputFecha() {
  let InputAppend = false;
  let inputFilteryear = null;

  var divSelectChartPublicaciones = document.querySelector(
    "#divSelectChartPublicaciones"
  );
  if (!InputAppend) {
    inputFilteryear = document.createRange()
      .createContextualFragment(`<input id="inputFilterFecha1" type="number" pattern="[0-9]*" maxlength="4" min="2016" placeholder="Rango 1"  required>
  `);

    divSelectChartPublicaciones.appendChild(inputFilteryear);
    InputAppend = true;
    inputFilteryear = document.createRange()
      .createContextualFragment(`<input id="inputFilterFecha2" type="number" pattern="[0-9]*" maxlength="4" min="2016" placeholder="Rango 2"  required>
  `);

    divSelectChartPublicaciones.appendChild(inputFilteryear);
    InputAppend = true;
  }
}


function btnSentChart() {
  var divcontainerAppendDivcanvaschart =
    document.querySelector("#divContainer");
  var chartSelected = document.querySelector("#GraficoSeleccionado");
  var divSelectChartPublicaciones = document.querySelector(
    "#divSelectChartPublicaciones"
  );
  var optSelected = chartSelected.value;

  if (optSelected != "") {
    switch (optSelected) {
      case "1":
        var valueINput = divSelectChartPublicaciones.childNodes[9].value;

        if (valueINput != "") {
          _id = "manuscritoxAnio";
          _idCanvas = "AnioPublicacionManuscrito";
          _tipoDeGrafico = "Manuscritos publicados por Año";
          _clear();
          _createDivChart(_id, _tipoDeGrafico, _idCanvas);
          _assignValueVariablesDivChart();
          divcontainerAppendDivcanvaschart.removeChild(
            divcontainerAppendDivcanvaschart.childNodes[1]
          );
          //_destroyItems();
        }
        break;
      case "2":
        _id = "publicacionesxArea";
        _idCanvas = "TotalPublicacionesPorArea";
        _tipoDeGrafico = "Publicaciones por Area";
        _clear();
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);

        _assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschart.removeChild(
          divcontainerAppendDivcanvaschart.childNodes[1]
        );
        //_destroyItems();
        break;
      case "3":
        _id = "idcoleccion";
        _idCanvas = "publicacionesxColeccion";
        _tipoDeGrafico = "Publicaciones por Coleccion";
        _clear();
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);
        _assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschart.removeChild(
          divcontainerAppendDivcanvaschart.childNodes[1]
        );
        //_destroyItems();

        break;
      case "4":
        _id = "idEstado";
        _idCanvas = "TotalPublicacionesPorEstado";
        _tipoDeGrafico = "Publicaciones por Estado";
        _clear();
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);

        _assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschart.removeChild(
          divcontainerAppendDivcanvaschart.childNodes[1]
        );
        // _destroyItems();
        break;
      case "5":
        _id = "idPresupuestal";
        _idCanvas = "reportePresupuestal";
        _tipoDeGrafico = "Reporte Presupuestal";
        _clear();
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);

        _assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschart.removeChild(
          divcontainerAppendDivcanvaschart.childNodes[1]
        );
        break;
      case "6":
        _id = "idEvaluaciones";
        _idCanvas = "reporteEvaluaciones";
        _tipoDeGrafico = "Reporte Evaluaciones";
        _clear();
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);

        _assignValueVariablesDivChart();
        divcontainerAppendDivcanvaschart.removeChild(
          divcontainerAppendDivcanvaschart.childNodes[1]
        );
        //_destroyItems();
        break;
      case "8":
        _clear();
        _assignValueVariablesDivChart();
        break;
      default:
        break;
    }
  } else {
    _clear();
    ShowModalDialog(
      "Seleccione: Grafico " + "y " + "Tipo de gráfico",
      false,
      "warning",
      "",
      0
    );
  }
}

//Excel
function _GenerarReporteExcelGenerico(urlreporte) {
  let urlExcel = urlController + urlreporte;
  // `ProyectosCentroExtension/ExcelMatrizConoPropuestas?id_propuesta=${parameterNumber}`;
  StartLoader();

  fetch(urlExcel, {
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

function downloadRep() {
  var opSelect = selectReportesExcel.value;
  if (opSelect != "") {
    switch (opSelect) {
      case "1":
        _GenerarReporteExcelGenerico(
          `ProyectosCentroExtension/ExcelContratacion`
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
function _clearInputReports() {
  _divreportes.innerHTML = "";
}
