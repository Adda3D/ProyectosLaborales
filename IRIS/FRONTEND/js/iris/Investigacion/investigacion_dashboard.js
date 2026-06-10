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

function createOptionSelect() {
  let selectSemestres = document.getElementById("SelectSemestre");
  let urlDatos3 =
    urlController +
    "InvestigacionDashboard/GetDropdownPresupuestoTotalSemestreVigente";
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
          selectSemestres.appendChild(optionToInsert);
        });
      }
    });
}

function reloadCharts() {
  let divLeft = document.getElementById("divLeft");
  let divCenter = document.getElementById("divCenter");
  let divRigth = document.getElementById("divRigth");

  divLeft.innerHTML = "";
  divCenter.innerHTML = "";

  let canvasChartLeft = document.createRange()
    .createContextualFragment(`<div>
    <canvas id="primerchart"></canvas>
  </div>
  <div>
    <canvas id="estadoXproyecto"></canvas>
  </div>
`);
  let canvasChartCenter = document.createRange().createContextualFragment(`<div>
    <canvas id="chartBalanceComprometido"></canvas>
  </div>
  <div id="porcentajesPresupueto"></div>

  <div>
  <canvas id="chartConvocatoriasFuentes"></canvas>
</div>
  
  <div>
  

`);
  let canvasChartRight = document.createRange()
    .createContextualFragment(`<canvas id="primerchart"></canvas>
`);

  divLeft.append(canvasChartLeft);
  divCenter.append(canvasChartCenter);
}

function loadChartMontoEjecutadoSemestre(valueLiteral, valueSemestre) {
  let insertChartPieFilter = document.getElementById("primerchart");

  let montoejecutado = 0;
  let urlPresupuestofilter =
    urlController +
    `InvestigacionDashboard/GetMontoEjecutadoLiteral?literal=${valueLiteral}&semestre=${valueSemestre}`;

  fetch(urlPresupuestofilter, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatosArea = data.Data;
        montoejecutado = lisDatosArea.map(function (e) {
          return e.Monto_Ejecutado;
        });
      }
    })
    .then(() => {
      let nombreGraficoFilter = "Monto Ejecutado";
      let urlDatosFlt =
        urlController +
        `InvestigacionDashboard/GetMontoEjecutadoLiteralFilter?literal=${valueLiteral}&semestre=${valueSemestre}`;
      StartLoader();
      fetch(urlDatosFlt, {
        method: "GET",
        headers: { Authorization: "Bearer " + TokenIRIS },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.Ok) {
            var lisDatosArea = data.Data;
            if (lisDatosArea.length != 0) {
              var literal = lisDatosArea.map(function (e) {
                return e.nmliteral;
              });
              var labels = ["presupuesto Total"];
              var datos = lisDatosArea.map(function (e) {
                return e.proyectado;
              });
              datos.push(montoejecutado[0]);
              labels.push(
                lisDatosArea.map(function (e) {
                  return e.nmsemestre + " " + e.nmliteral;
                })
              );
              let chartMontoEjecutadoSemestre = new Chart(
                document.getElementById("primerchart"),
                {
                  type: "pie",
                  data: {
                    labels: labels,
                    datasets: [
                      {
                        label: "cantidad",
                        backgroundColor: _getDataColors(),
                        data: datos,
                      },
                    ],
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,

                    plugins: {
                      legend: {
                        display: true,
                      },
                      title: {
                        display: true,
                        text: "Monto Ejecutado por Semestre",
                      },
                    },
                  },
                }
              );
              insertChartPieFilter.append(chartMontoEjecutadoSemestre);
            } else {
              console.log("Error")
              StartLoader();
              ShowModalDialog(
                "No hay suficientes datos" +
                  " para" +
                  " Graficar " +
                  nombreGraficoFilter,
                false,
                "warning",
                "",
                0
              );
              FinalizeLoader();
              var literalFilter = lisDatosArea.map(function (e) {
                return e.Literal;
              });
              var labelsFilter = lisDatosArea.map(function (e) {
                return e.Semestre;
              });
              var datosFilter = lisDatosArea.map(function (e) {
                return e.Monto_Ejecutado;
              });
              let chartMontoEjecutadoSemestre = new Chart(
                document.getElementById("primerchart"),
                {
                  type: "pie",
                  data: {
                    labels: [
                      "Semestre: " + labelsFilter,
                      "Literal: " + literalFilter,
                    ],
                    datasets: [
                      {
                        label: "Monto Ejecutado",
                        backgroundColor: _getDataColors(),
                        data: datosFilter,
                      },
                    ],
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,

                    plugins: {
                      legend: {
                        display: true,
                      },
                      title: {
                        display: true,
                        text: "Monto Ejecutado por Semestre",
                      },
                    },
                  },
                }
              );
              insertChartPieFilter.append(chartMontoEjecutadoSemestre);
            }

            FinalizeLoader();
          } else {
            FinalizeLoader();
            ShowModalDialog(err, false, "warning", "", 0);
          }
        })

        .catch((err) => {
          debugger
          FinalizeLoader();
          ShowModalDialog(err, false, "error", "", 0);
        });
    })
    .catch((err) => {
      debugger
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function _loadChartMontoEjecutadoSemestre() {
  let insertChartPie = document.getElementById("primerchart");

  let presupuestoTotalDefault;
  let urlPresupuesto =
    urlController + `InvestigacionDashboard/GetComprometidoTotalPorcentaje`;
  fetch(urlPresupuesto, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatosArea = data.Data;
        presupuestoTotalDefault = lisDatosArea.map(function (e) {
          return e.total_presupuesto;
        });
      }
    })
    .then(() => {
      let urlDatos =
        urlController +
        `InvestigacionDashboard/GetDropdownMontoEjecutadoLiteral`;
      StartLoader();
      fetch(urlDatos, {
        method: "GET",
        headers: { Authorization: "Bearer " + TokenIRIS },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.Ok) {
            var lisDatosArea = data.Data;
            var literal = lisDatosArea.map(function (e) {
              return e.Literal;
            });
            var labels = lisDatosArea.map(function (e) {
              return e.Semestre + " " + e.Literal;
            });
            var datos = lisDatosArea.map(function (e) {
              return e.Monto_Ejecutado;
            });
            labels.push("Presupuesto Total");
            datos.push(presupuestoTotalDefault);
            let primerChart = new Chart(
              document.getElementById("primerchart"),
              {
                type: "pie",
                data: {
                  labels: labels,
                  datasets: [
                    {
                      label: "Cantidad",
                      backgroundColor: _getDataColors(),
                      data: datos,
                    },
                  ],
                },
                options: {
                  responsive: true,
                  maintainAspectRatio: false,

                  plugins: {
                    legend: {
                      display: true,
                    },
                    title: {
                      display: true,
                      text: "Monto Ejecutado por Semestre",
                    },
                  },
                },
              }
            );
            insertChartPie.append(primerChart);

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
    });
}

function loadChartMontoComprometidoComprometer(valueLiteral, valueSemestre) {
  let insertChartPie = document.getElementById("chartBalanceComprometido");
  let nombreGrafico = "Balance Monto Comprometido - Comprometer";
  let saldocomprometer = 0;

  let urlDatosValTot =
    urlController +
    `InvestigacionDashboard/GetMontoEjecutadoLiteralFilter?literal=${valueLiteral}&semestre=${valueSemestre}`;
  fetch(urlDatosValTot, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((res) => {
      var dat = res.Data;
      var Stotal = dat.map(function (e) {
        return e.proyectado;
      });
      let urlDatos =
        urlController +
        `InvestigacionDashboard/GetBalanceMontoComprometido_Comprometer?literal=${valueLiteral}&semestre=${valueSemestre}`;
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
                return e.Comprometido;
              });

              var literal = lisDatosArea.map(function (e) {
                return e.Literal;
              });
              saldocomprometer = Stotal[0] - labels;
              var datos = [saldocomprometer];
              let chartMontoComprometido = new Chart(
                document.getElementById("chartBalanceComprometido"),
                {
                  type: "bar",
                  data: {
                    datasets: [
                      {
                        label: "Saldo Comprometido",
                        data: labels,
                        backgroundColor: "green",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                      {
                        label: "Saldo Por Comprometer",
                        data: datos,
                        backgroundColor: "red",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                    ],
                    labels: literal,
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    indexAxis: "y",
                    legend: {
                      position: "bottom",
                    },
                    scales: {
                      x: {
                        ticks: {
                          min: 0,
                          max: 500,
                          stepSize: 1,
                        },
                      },
                      /* yAxes: [
                    {
                      ticks: {
                        beginAtZero: true,
                      },
                      stacked: true,
                    },
                  ],
                  xAxes: [
                    {
                      stacked: true,
                    },
                  ], */
                    },
                  },
                }
              );
              insertChartPie.append(chartMontoComprometido);
              FinalizeLoader();
            } else {
              StartLoader();
              ShowModalDialog(
                "No hay suficientes datos" +
                  " para" +
                  " Graficar " +
                  nombreGrafico,
                false,
                "warning",
                "",
                0
              );
              FinalizeLoader();
              var labels = lisDatosArea.map(function (e) {
                return e.Comprometido;
              });
              var datos = lisDatosArea.map(function (e) {
                return e.saldoporcomprometer;
              });
              var literal = lisDatosArea.map(function (e) {
                return e.Literal;
              });

              let chartMontoComprometido = new Chart(
                document.getElementById("chartBalanceComprometido"),
                {
                  type: "bar",
                  data: {
                    datasets: [
                      {
                        label: "Saldo Comprometido",
                        data: labels,
                        backgroundColor: "green",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                      {
                        label: "Saldo Por Comprometer",
                        data: datos,
                        backgroundColor: "red",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                    ],
                    labels: literal,
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    indexAxis: "y",
                    legend: {
                      position: "bottom",
                    },
                    scales: {
                      x: {
                        ticks: {
                          min: 0,
                          max: 500,
                          stepSize: 1,
                        },
                      },
                      /*  yAxes: [
                    {
                      ticks: {
                        beginAtZero: true,
                      },
                      stacked: true,
                    },
                  ],
                  xAxes: [
                    {
                      stacked: true,
                    },
                  ], */
                    },
                  },
                }
              );
              insertChartPie.append(chartMontoComprometido);
              FinalizeLoader();
            }
          } else {
            debugger
            FinalizeLoader();
            ShowModalDialog(err, false, "warning", "", 0);
          }
        })
        .catch((err) => {
          debugger
          FinalizeLoader();
          ShowModalDialog(err, false, "error", "", 0);
        });
    });
}

function _loadChartMontoComprometidoComprometer() {
  let insertChartPie = document.getElementById("chartBalanceComprometido");
  let saldocomprometer = 0;
  let urlDatosValTot =
    urlController + "InvestigacionDashboard/GetComprometidoTotalPorcentaje";
  fetch(urlDatosValTot, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((res) => {
      var dat = res.Data;
      let Stotal = dat.map(function (e) {
        return e.total_presupuesto;
      });
      
      let totalComprometido = dat.map(function (e) {
        return e.total_comprometido;
      });
      let datos = [Stotal - totalComprometido];
      let chartMontoComprometido = new Chart(
        document.getElementById("chartBalanceComprometido"),
        {
          type: "bar",
          data: {
            datasets: [
              {
                label: "Saldo Comprometido",
                data: totalComprometido,
                backgroundColor: "green",
                borderColor: "white",
                borderWidth: 1,
              },
              {
                label: "Saldo Por Comprometer",
                data: datos,
                backgroundColor: "red",
                borderColor: "white",
                borderWidth: 1,
              },
            ],
            labels: ["Total"],
          },
          options: {
            responsive: true,
            maintainAspectRatio: false,
            indexAxis: "y",
            legend: {
              position: "bottom",
            },
            scales: {
              x: {
                ticks: {
                  min: 0,
                  max: 500,
                  stepSize: 1,
                },
              },
              /*  yAxes: [
            {
              ticks: {
                beginAtZero: true,
              },
              stacked: true,
            },
          ],
          xAxes: [
            {
              stacked: true,
            },
          ], */
            },
          },
        }
      );
      FinalizeLoader();
      insertChartPie.append(chartMontoComprometido);
    });
}

function loadChartPresupuestoTotalSemestre() {
  let valueSemestre = divContainerSelectChart.childNodes[5].value;
  let valueLiteral = divContainerSelectChart.childNodes[6].value;

  let urlDatos =
    urlController +
    `InvestigacionDashboard/GetPresupuestoTotalSemestreVigente?literal=${valueLiteral}&semestre=${valueSemestre}`;
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatosArea = data.Data;
        var labels = lisDatosArea.map(function (e) {
          return e.Semestre;
        });
        var Literal = lisDatosArea.map(function (e) {
          return e.Semestre;
        });
        var datos = lisDatosArea.map(function (e) {
          return e.Presupuesto_Total;
        });
        RegistroAreaPublicadochart = new Chart(
          document.getElementById("presupuestoSemestre"),
          {
            type: "bar",
            data: {
              labels: ["Presupuesto total"],
              datasets: [
                {
                  label: "Valor",
                  backgroundColor: _getDataColors(),
                  data: datos,
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
                    stepSize: 100000,
                  },
                },
              },
              plugins: {
                legend: {
                  display: false,
                },
                title: {
                  display: true,
                  text: "Presupuesto Total por Semestre",
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

function Create_DivCharComprometido() {
  var divcontainer_AppendDivcanvasComprometido = document.querySelector(
    "#porcentajesPresupueto"
  );
  let color = null;
  let backgroundColor = ["red", "orange", "yellow", "green"];
  let montoEjecutado = 0;
  let porcentajeMonto = 0;
  let urlMontoEj =
    urlController +
    "InvestigacionDashboard/DropdownDiferenciaTotalComprometidoEjecutado";
  fetch(urlMontoEj, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      var lisDatosArea = data.Data;

      lisDatosArea.forEach((e) => {
        let monto = e.monto_ejecutado;
        montoEjecutado += monto;
      });

      let urlDatos =
        urlController + "InvestigacionDashboard/GetComprometidoTotalPorcentaje";
      fetch(urlDatos, {
        method: "GET",
        headers: { Authorization: "Bearer " + TokenIRIS },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.Ok) {
            var lisDatosArea = data.Data;
            let Comprometido;
            let Presupuesto;
            let porcentaje;

            lisDatosArea.forEach((e) => {
              Comprometido = e.total_comprometido;
              Presupuesto = e.total_presupuesto;
              porcentaje = e.porcentaje_presupuesto * 100;
            });
            porcentajeMonto = (montoEjecutado * 100) / Presupuesto;

            if (porcentajeMonto > 0 && porcentajeMonto <= 30) {
              color = 0;
            } else if (porcentajeMonto > 30 && porcentajeMonto <= 60) {
              color = 1;
            } else if (porcentajeMonto > 60 && porcentajeMonto < 80) {
              color = 2;
            } else if (porcentajeMonto >= 80) {
              color = 3;
            }
            var divInnerComprometido = document.createRange()
              .createContextualFragment(`  <div class="col-md-8"  >
        <div class="col-md-12" >
          <label class="form-label-iris"></label>
        </div>
    
        <div
          class="col-md-12"
          style="
            position: relative;            
            overflow: hidden;
            display: block;
  flex-wrap: wrap;
  justify-content: center;
          "
         
        >
          <div
            style="
              background-color: gray;
              width: 250px;
              height: 60px;
              margin-bottom: 10px;
              margin-top: 10px;
    
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              text-align: center;
            "
          > <label class="form-label-iris" style="font-weight: bold; ">Presupuesto Total </label>
            
            <p style = "font-size: large; ">$ ${Presupuesto.toLocaleString()}</p>
          </div>
          <div class="row" style=" clear: both;">
          <div
          class="col-md-5"

            style="
              background-color: ${backgroundColor[color]};
              width: 55%;
              height: 60px;
              margin-bottom: 10px;
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              float: left;
              text-align: center;
    
            "
          >
          <label class="form-label-iris" style="font-weight: bold; ">Monto Comprometido </label>
            <p style = "font-size: large;">$${Comprometido.toLocaleString()}</p>
          </div>
          <div
            class="col-md-5"
            id="div3"
            style="
            clear: both;
              background-color: ${backgroundColor[color]};
              width: 20%;
              height: 60px;
              float: right;
              margin-right: 60px;
              margin-left: 10px;
              border-radius: 5px; 
              display: flex;
              justify-content: center; 
              align-items: center; 
            "
          >
          <p style = "font-size: large;">${porcentaje.toFixed(2)}%</p>
          </div>
          </div>
          <div class="row" style=" clear: both;">
          <div
          class="col-md-5"
            id="div1"
            style="
              background-color: ${backgroundColor[color]};
              width: 55%;
              height: 60px;
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              float: left;
              text-align: center;
                
            "
          >
          <label class="form-label-iris" style="font-weight: bold; ">Monto Ejecutado </label>
            <p style = "font-size: large;">$${montoEjecutado.toLocaleString()}</p>
          </div>
          <div
          class="col-md-5"
            id="div2"
            style="
              background-color: ${backgroundColor[color]};
              width: 20%;
              height: 60px;
              float: right;
              margin-right: 60px;
              margin-left: 10px;

              border-radius: 5px;
              display: flex;
              justify-content: center; 
              align-items: center; 
            "
          >
          <p style = "font-size: large;">${porcentajeMonto.toFixed(2)}%</p> 
          </div>
          </div>
        </div>
      </div>`);
            divcontainer_AppendDivcanvasComprometido.appendChild(
              divInnerComprometido
            );
          }
        })
        .catch((err) => {
          FinalizeLoader();
          ShowModalDialog(err, false, "error", "", 0);
        });
    });
  FinalizeLoader();
}

function Create_DivChart(_id, _tipoDeGrafico, _idCanvas) {
  var divcontainer_AppendDivcanvaschart = document.querySelector(
    "#InnerChartsContainer"
  );

  var divInnerChartsPublicaciones = document.createRange()
    .createContextualFragment(`<div class="col-md-4" id="${_id}">
<div class="col-md-12">
<label class="form-label-iris">${_tipoDeGrafico}</label>
</div>                       

<div class="col-md-12" style = "position: relative;
margin: auto;
height: 30vh;
width: 30vw;">   
<canvas id="${_idCanvas}"></canvas>                        
</div>

</div>`);
  divcontainer_AppendDivcanvaschart.appendChild(divInnerChartsPublicaciones);
}

function assignValue_VariablesDivChart() {
  var Chart_Selected = document.querySelector("#selectChartSelected");

  var _id = "";
  var _idCanvas = "";
  var _tipoDeGrafico = "";
  var opSelect = Chart_Selected.value;
  if (
    (opSelect != "" && opSelect === "1") ||
    opSelect === "2" ||
    opSelect === "3" ||
    opSelect === "4" ||
    opSelect === "5"
  ) {
    Create_DivChart(_id, _tipoDeGrafico, _idCanvas);
    if (opSelect === "1") {
      loadChartMontoEjecutadoSemestre();
    } else if (opSelect === "2") {
      loadChartMontoComprometidoComprometer();
    } else if (opSelect === "3") {
      loadChartPresupuestoTotalSemestre();
    } else if (opSelect === "4") {
      Create_DivCharComprometido();
    } else if (opSelect === "5") {
      _loadChartReportePresupuestal();
    }
  } else if (opSelect === "8") {
    for (let i = 1; i < 8; i++) {
      if (i === 1) {
        _id = "MontoEjecutadoSem";
        _idCanvas = "MontoEjecutado";
        _tipoDeGrafico = "Monto Ejecutado";

        Create_DivChart(_id, _tipoDeGrafico, _idCanvas);
        loadChartMontoEjecutadoSemestre();
      }
      if (i === 2) {
        _id = "montoComp";
        _idCanvas = "MontoComprometidoComprometer";
        _tipoDeGrafico = "Monto Comprometido y por Comprometer";

        Create_DivChart(_id, _tipoDeGrafico, _idCanvas);
        loadChartMontoComprometidoComprometer();
      }
      if (i === 3) {
        _id = "presSemestre";
        _idCanvas = "presupuestoSemestre";
        _tipoDeGrafico = "Presupuesto Total por Semestre";
        Create_DivChart(_id, _tipoDeGrafico, _idCanvas);
        loadChartPresupuestoTotalSemestre();
      }
      if (i === 4) {
        Create_DivCharComprometido();
      }
      if (i === 5) {
        _id = "idPresupuestal";
        _idCanvas = "reportePresupuestal";
        _tipoDeGrafico = "Reporte Presupuestal";
        Create_DivChart(_id, _tipoDeGrafico, _idCanvas);
        _loadChartReportePresupuestal();
      }
    }
  }
}

function Clear() {
  var divcontainerAppendDivcanvaschart = document.querySelector(
    "#InnerChartsContainer"
  );

  divcontainerAppendDivcanvaschart.innerHTML = "";
}

//deprecated
function buttonSendChart() {
  var Chart_Selected = document.querySelector("#selectChartSelected");
  var optSelected = Chart_Selected.value;

  if (optSelected != "") {
    switch (optSelected) {
      case "1":
        _id = "MontoEjecutadoSem";
        _idCanvas = "MontoEjecutado";
        _tipoDeGrafico = "Monto Ejecutado";
        Clear();
        Create_DivChart(_id, _tipoDeGrafico, _idCanvas);
        assignValue_VariablesDivChart();
        //_destroyItems();

        break;
      case "2":
        _id = "montoComp";
        _idCanvas = "MontoComprometidoComprometer";
        _tipoDeGrafico = "Monto Comprometido y por Comprometer";
        Clear();
        Create_DivChart(_id, _tipoDeGrafico, _idCanvas);

        assignValue_VariablesDivChart();
        //_destroyItems();
        break;
      case "3":
        _id = "presSemestre";
        _idCanvas = "presupuestoSemestre";
        _tipoDeGrafico = "Presupuesto Total por Semestre";
        Clear();
        Create_DivChart(_id, _tipoDeGrafico, _idCanvas);

        assignValue_VariablesDivChart();
        //_destroyItems();

        break;
      case "4":
        Clear();
        Create_DivCharComprometido();
        // _destroyItems();
        break;
      case "5":
        _id = "idPresupuestal";
        _idCanvas = "reportePresupuestal";
        _tipoDeGrafico = "Reporte Presupuestal";
        _clear();
        _createDivChart(_id, _tipoDeGrafico, _idCanvas);

        _assignValueVariablesDivChart();
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

function _loadChartEstadoProyecto(){
  let insertChartPie = document.getElementById("estadoXproyecto");

  let urlDatos =
    urlController + `InvestigacionDashboard/GetEstadoProyecto`;
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.nmestado;
        });
        var datos = lisDatos.map(function (e) {
          return e.count;
        });
        let ChartEstadoProyecto = new Chart(
          document.getElementById("estadoXproyecto"),
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
                  text: "Proyecto por estado",
                },
              },
            },
          }
        );
        FinalizeLoader();
        insertChartPie.append(ChartEstadoProyecto);
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

function loadChartEstadoProyectoByLiteral(literal, anio, rango1, rango2){
  let insertChartPie = document.getElementById("estadoXproyecto");

  let urlDatos =
    urlController + `InvestigacionDashboard/GetProyectosEstadoByLiteral?literal=${literal}&anio=${anio}&rango1=${rango1}&rango2=${rango2}`;
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.nmestado;
        });
        var datos = lisDatos.map(function (e) {
          return e.count;
        });
        let ChartEstadoProyecto = new Chart(
          document.getElementById("estadoXproyecto"),
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
                  text: "Proyecto por estado",
                },
              },
            },
          }
        );
        FinalizeLoader();
        insertChartPie.append(ChartEstadoProyecto);
      } else {
        debugger
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      debugger
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
    
}

//Funciones para mostrar filtradas unicamente por semestre

function loadChartMontoEjecutadoBySemestre(valueSemestre) {
  let insertChartPieFilter = document.getElementById("primerchart");

  let montoejecutado = 0;
  let urlPresupuestofilter =
    urlController +
    `InvestigacionDashboard/GetMontoEjecutadoSemestre?semestre=${valueSemestre}`;

  fetch(urlPresupuestofilter, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatosArea = data.Data;
        console.log(lisDatosArea)
        montoejecutado = lisDatosArea.map(function (e) {
          return e.monto_ejecutado;
        });
      }
    })
    .then(() => {
      let nombreGraficoFilter = "Monto Ejecutado";
      let urlDatosFlt =
        urlController +
        `InvestigacionDashboard/GetValorProyectadoSemestre?semestre=${valueSemestre}`;
      StartLoader();
      fetch(urlDatosFlt, {
        method: "GET",
        headers: { Authorization: "Bearer " + TokenIRIS },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.Ok) {
            var lisDatosArea = data.Data;
            if (lisDatosArea.length != 0) {
              
              var labels = ["presupuesto Total"];
              var datos = lisDatosArea.map(function (e) {
                return e.proyectado;
              });
              datos.push(montoejecutado[0]);
              labels.push(
                lisDatosArea.map(function (e) {
                  return e.nmsemestre;
                })
              );
              let chartMontoEjecutadoSemestre = new Chart(
                document.getElementById("primerchart"),
                {
                  type: "pie",
                  data: {
                    labels: labels,
                    datasets: [
                      {
                        label: "cantidad",
                        backgroundColor: _getDataColors(),
                        data: datos,
                      },
                    ],
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,

                    plugins: {
                      legend: {
                        display: true,
                      },
                      title: {
                        display: true,
                        text: "Monto Ejecutado por Semestre",
                      },
                    },
                  },
                }
              );
              insertChartPieFilter.append(chartMontoEjecutadoSemestre);
            } else {
              StartLoader();
              ShowModalDialog(
                "No hay suficientes datos" +
                  " para" +
                  " Graficar " +
                  nombreGraficoFilter,
                false,
                "warning",
                "",
                0
              );
              FinalizeLoader();
             
              var labelsFilter = lisDatosArea.map(function (e) {
                return e.semestre;
              });
              var datosFilter = lisDatosArea.map(function (e) {
                return e.monto_ejecutado;
              });
              let chartMontoEjecutadoSemestre = new Chart(
                document.getElementById("primerchart"),
                {
                  type: "pie",
                  data: {
                    labels: [
                      "Semestre: " + labelsFilter
                    ],
                    datasets: [
                      {
                        label: "Monto Ejecutado",
                        backgroundColor: _getDataColors(),
                        data: datosFilter,
                      },
                    ],
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,

                    plugins: {
                      legend: {
                        display: true,
                      },
                      title: {
                        display: true,
                        text: "Monto Ejecutado por Semestre",
                      },
                    },
                  },
                }
              );
              insertChartPieFilter.append(chartMontoEjecutadoSemestre);
            }

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
    })
    .catch((err) => {
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
}

function loadChartMontoComprometidoComprometerBySemestre( valueSemestre) {
  let insertChartPie = document.getElementById("chartBalanceComprometido");
  let nombreGrafico = "Balance Monto Comprometido - Comprometer";
  let saldocomprometer = 0;

  let urlDatosValTot =
    urlController +
    `InvestigacionDashboard/GetValorProyectadoSemestre?semestre=${valueSemestre}`;
    fetch(urlDatosValTot, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((res) => {
      var dat = res.Data;
      var Stotal = dat.map(function (e) {
        return e.proyectado;
      });
      let urlDatos =
        urlController +
        `InvestigacionDashboard/GetMontoComprometidoComprometerSemestre?semestre=${valueSemestre}`;
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
                return e.comprometido;
              });

              var semestre = lisDatosArea.map(function (e) {
                return e.nmsemestre;
              });
              saldocomprometer = Stotal[0] - labels;
              var datos = [saldocomprometer];
              let chartMontoComprometido = new Chart(
                document.getElementById("chartBalanceComprometido"),
                {
                  type: "bar",
                  data: {
                    datasets: [
                      {
                        label: "Saldo Comprometido",
                        data: labels,
                        backgroundColor: "green",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                      {
                        label: "Saldo Por Comprometer",
                        data: datos,
                        backgroundColor: "red",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                    ],
                    labels: semestre,
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    indexAxis: "y",
                    legend: {
                      position: "bottom",
                    },
                    scales: {
                      x: {
                        ticks: {
                          min: 0,
                          max: 500,
                          stepSize: 1,
                        },
                      },
                      /* yAxes: [
                    {
                      ticks: {
                        beginAtZero: true,
                      },
                      stacked: true,
                    },
                  ],
                  xAxes: [
                    {
                      stacked: true,
                    },
                  ], */
                    },
                  },
                }
              );
              insertChartPie.append(chartMontoComprometido);
              FinalizeLoader();
            } else {
              StartLoader();
              ShowModalDialog(
                "No hay suficientes datos" +
                  " para" +
                  " Graficar " +
                  nombreGrafico,
                false,
                "warning",
                "",
                0
              );
              FinalizeLoader();
              var labels = lisDatosArea.map(function (e) {
                return e.comprometido;
              });
              var datos = lisDatosArea.map(function (e) {
                return e.saldoporcomprometer;
              });
              var semestre = lisDatosArea.map(function (e) {
                return e.nmsemestre;
              });

              let chartMontoComprometido = new Chart(
                document.getElementById("chartBalanceComprometido"),
                {
                  type: "bar",
                  data: {
                    datasets: [
                      {
                        label: "Saldo Comprometido",
                        data: labels,
                        backgroundColor: "green",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                      {
                        label: "Saldo Por Comprometer",
                        data: datos,
                        backgroundColor: "red",
                        borderColor: "white",
                        borderWidth: 1,
                      },
                    ],
                    labels: semestre,
                  },
                  options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    indexAxis: "y",
                    legend: {
                      position: "bottom",
                    },
                    scales: {
                      x: {
                        ticks: {
                          min: 0,
                          max: 500,
                          stepSize: 1,
                        },
                      },
                      /*  yAxes: [
                    {
                      ticks: {
                        beginAtZero: true,
                      },
                      stacked: true,
                    },
                  ],
                  xAxes: [
                    {
                      stacked: true,
                    },
                  ], */
                    },
                  },
                }
              );
              insertChartPie.append(chartMontoComprometido);
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
    });
}

function loadChartEstadoProyectoBySemestre(anio, rango1, rango2){
  let insertChartPie = document.getElementById("estadoXproyecto");

  let urlDatos =
    urlController + `InvestigacionDashboard/GetProyectosEstado?anio=${anio}&rango1=${rango1}&rango2=${rango2}`;
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.nmestado;
        });
        var datos = lisDatos.map(function (e) {
          return e.count;
        });
        let ChartEstadoProyecto = new Chart(
          document.getElementById("estadoXproyecto"),
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
                  text: "Proyecto por estado",
                },
              },
            },
          }
        );
        FinalizeLoader();
        insertChartPie.append(ChartEstadoProyecto);
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

function Create_DivCharComprometidoSemestre(semestre, anio, rango1, rango2) {
  var divcontainer_AppendDivcanvasComprometido = document.querySelector(
    "#porcentajesPresupueto"
  );
  let color = null;
  let backgroundColor = ["red", "orange", "yellow", "green"];
  let montoEjecutado = 0;
  let porcentajeMonto = 0;
  let urlMontoEj =
    urlController +
    `InvestigacionDashboard/GetPresuspuestoTotalComprometidoEjecutadoBySemestre?anio=${anio}&rango1=${rango1}&rango2=${rango2}`;
  fetch(urlMontoEj, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      var lisDatosArea = data.Data;
      lisDatosArea.forEach((e) => {
        let monto = e.monto_ejecutado;
        montoEjecutado += monto;
      });

      let urlDatos =
        urlController + `InvestigacionDashboard/GetPresuspuestoTotalComprometidoBySemestre?semestre=${semestre}&anio=${anio}&rango1=${rango1}&rango2=${rango2}`;
      fetch(urlDatos, {
        method: "GET",
        headers: { Authorization: "Bearer " + TokenIRIS },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.Ok) {
            var lisDatosArea = data.Data;
            let Comprometido;
            let Presupuesto;
            let porcentaje;

            lisDatosArea.forEach((e) => {
              Comprometido = e.total_comprometido;
              Presupuesto = e.total_presupuesto;
              porcentaje = e.porcentaje_presupuesto * 100;
            });
            porcentajeMonto = (montoEjecutado * 100) / Presupuesto;

            if (porcentajeMonto > 0 && porcentajeMonto <= 30) {
              color = 0;
            } else if (porcentajeMonto > 30 && porcentajeMonto <= 60) {
              color = 1;
            } else if (porcentajeMonto > 60 && porcentajeMonto < 80) {
              color = 2;
            } else if (porcentajeMonto >= 80) {
              color = 3;
            }
            var divInnerComprometido = document.createRange()
              .createContextualFragment(`  <div class="col-md-8"  >
        <div class="col-md-12" >
          <label class="form-label-iris"></label>
        </div>
    
        <div
          class="col-md-12"
          style="
            position: relative;            
            overflow: hidden;
            display: block;
  flex-wrap: wrap;
  justify-content: center;
          "
         
        >
          <div
            style="
              background-color: gray;
              width: 250px;
              height: 60px;
              margin-bottom: 10px;
              margin-top: 10px;
    
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              text-align: center;
            "
          > <label class="form-label-iris" style="font-weight: bold; ">Presupuesto Total </label>
            
            <p style = "font-size: large; ">$ ${Presupuesto.toLocaleString()}</p>
          </div>
          <div class="row" style=" clear: both;">
          <div
          class="col-md-5"

            style="
              background-color: ${backgroundColor[color]};
              width: 55%;
              height: 60px;
              margin-bottom: 10px;
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              float: left;
              text-align: center;
    
            "
          >
          <label class="form-label-iris" style="font-weight: bold; ">Monto Comprometido </label>
            <p style = "font-size: large;">$${Comprometido.toLocaleString()}</p>
          </div>
          <div
            class="col-md-5"
            id="div3"
            style="
            clear: both;
              background-color: ${backgroundColor[color]};
              width: 20%;
              height: 60px;
              float: right;
              margin-right: 60px;
              margin-left: 10px;
              border-radius: 5px; 
              display: flex;
              justify-content: center; 
              align-items: center; 
            "
          >
          <p style = "font-size: large;">${porcentaje.toFixed(2)}%</p>
          </div>
          </div>
          <div class="row" style=" clear: both;">
          <div
          class="col-md-5"
            id="div1"
            style="
              background-color: ${backgroundColor[color]};
              width: 55%;
              height: 60px;
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              float: left;
              text-align: center;
                
            "
          >
          <label class="form-label-iris" style="font-weight: bold; ">Monto Ejecutado </label>
            <p style = "font-size: large;">$${montoEjecutado.toLocaleString()}</p>
          </div>
          <div
          class="col-md-5"
            id="div2"
            style="
              background-color: ${backgroundColor[color]};
              width: 20%;
              height: 60px;
              float: right;
              margin-right: 60px;
              margin-left: 10px;

              border-radius: 5px;
              display: flex;
              justify-content: center; 
              align-items: center; 
            "
          >
          <p style = "font-size: large;">${porcentajeMonto.toFixed(2)}%</p> 
          </div>
          </div>
        </div>
      </div>`);
            divcontainer_AppendDivcanvasComprometido.appendChild(
              divInnerComprometido
            );
          }
        })
        .catch((err) => {
          FinalizeLoader();
          ShowModalDialog(err, false, "error", "", 0);
        });
    });
  FinalizeLoader();
}

function Create_DivCharComprometidoSemestreLiteral(semestre, literal, anio, rango1, rango2) {
  var divcontainer_AppendDivcanvasComprometido = document.querySelector(
    "#porcentajesPresupueto"
  );
  let color = null;
  let backgroundColor = ["red", "orange", "yellow", "green", "gray"];
  let montoEjecutado = 0;
  let porcentajeMonto = 0;
  let urlMontoEj =
    urlController +
    `InvestigacionDashboard/GetPresuspuestoTotalComprometidoEjecutadoByLiteralAndSemestre?literal=${literal}&anio=${anio}&rango1=${rango1}&rango2=${rango2}`;
  fetch(urlMontoEj, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      var lisDatosArea = data.Data;

      lisDatosArea.forEach((e) => {
        let monto = e.monto_ejecutado;
        montoEjecutado += monto;
      });

      let urlDatos =
        urlController + `InvestigacionDashboard/GetPresuspuestoTotalComprometidoBySemestreAndLiteral?semestre=${semestre}&literal=${literal}&anio=${anio}&rango1=${rango1}&rango2=${rango2}`;
      fetch(urlDatos, {
        method: "GET",
        headers: { Authorization: "Bearer " + TokenIRIS },
      })
        .then((response) => response.json())
        .then((data) => {
          console.log(data)
          if (data.Ok) {
            var lisDatosArea = data.Data;
            let Comprometido;
            let Presupuesto;
            let porcentaje;

            lisDatosArea.forEach((e) => {
              if(e.total_comprometido==null){
                e.total_comprometido=0
              }
              if(e.total_presupuesto==null){
                e.total_presupuesto=0
              }
              if(e.porcentaje_presupuesto==null){
                e.porcentaje_presupuesto=0
              }
              Comprometido = e.total_comprometido;
              Presupuesto = e.total_presupuesto;
              porcentaje = e.porcentaje_presupuesto * 100;
            });
            porcentajeMonto = (montoEjecutado * 100) / Presupuesto;
            console.log(Presupuesto)
            if(Presupuesto==0){
              porcentajeMonto=0
            }
            console.log(porcentajeMonto)

            if (porcentajeMonto > 0 && porcentajeMonto <= 30) {
              color = 0;
            } else if (porcentajeMonto > 30 && porcentajeMonto <= 60) {
              color = 1;
            } else if (porcentajeMonto > 60 && porcentajeMonto < 80) {
              color = 2;
            } else if (porcentajeMonto >= 80) {
              color = 3;
            } else if (porcentajeMonto == 0){
              color = 4
            }

            var divInnerComprometido = document.createRange()
              .createContextualFragment(`  <div class="col-md-8"  >
        <div class="col-md-12" >
          <label class="form-label-iris"></label>
        </div>
    
        <div
          class="col-md-12"
          style="
            position: relative;            
            overflow: hidden;
            display: block;
  flex-wrap: wrap;
  justify-content: center;
          "
         
        >
          <div
            style="
              background-color: gray;
              width: 250px;
              height: 60px;
              margin-bottom: 10px;
              margin-top: 10px;
    
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              text-align: center;
            "
          > <label class="form-label-iris" style="font-weight: bold; ">Presupuesto Total </label>
            
            <p style = "font-size: large; ">$ ${Presupuesto.toLocaleString()}</p>
          </div>
          <div class="row" style=" clear: both;">
          <div
          class="col-md-5"

            style="
              background-color: ${backgroundColor[color]};
              width: 55%;
              height: 60px;
              margin-bottom: 10px;
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              float: left;
              text-align: center;
    
            "
          >
          <label class="form-label-iris" style="font-weight: bold; ">Monto Comprometido </label>
            <p style = "font-size: large;">$${Comprometido.toLocaleString()}</p>
          </div>
          <div
            class="col-md-5"
            id="div3"
            style="
            clear: both;
              background-color: ${backgroundColor[color]};
              width: 20%;
              height: 60px;
              float: right;
              margin-right: 60px;
              margin-left: 10px;
              border-radius: 5px; 
              display: flex;
              justify-content: center; 
              align-items: center; 
            "
          >
          <p style = "font-size: large;">${porcentaje.toFixed(2)}%</p>
          </div>
          </div>
          <div class="row" style=" clear: both;">
          <div
          class="col-md-5"
            id="div1"
            style="
              background-color: ${backgroundColor[color]};
              width: 55%;
              height: 60px;
              clip-path: polygon(
                0 0px,
                calc(100% - 30px) 0,
                100% 14px,
                100% 100%,
                0 100%
              );
              border-radius: 10px;
              float: left;
              text-align: center;
                
            "
          >
          <label class="form-label-iris" style="font-weight: bold; ">Monto Ejecutado </label>
            <p style = "font-size: large;">$${montoEjecutado.toLocaleString()}</p>
          </div>
          <div
          class="col-md-5"
            id="div2"
            style="
              background-color: ${backgroundColor[color]};
              width: 20%;
              height: 60px;
              float: right;
              margin-right: 60px;
              margin-left: 10px;

              border-radius: 5px;
              display: flex;
              justify-content: center; 
              align-items: center; 
            "
          >
          <p style = "font-size: large;">${porcentajeMonto.toFixed(2)}%</p> 
          </div>
          </div>
        </div>
      </div>`);
            divcontainer_AppendDivcanvasComprometido.appendChild(
              divInnerComprometido
            );
          }
        })
        .catch((err) => {
          debugger
          
          FinalizeLoader();
          ShowModalDialog(err, false, "error", "", 0);
        });
    });
  FinalizeLoader();
}


function loadChartFuentesBySemestre(anio, rango1, rango2){
  let insertChartPie = document.getElementById("chartConvocatoriasFuentes");

  let urlDatos =
    urlController + `InvestigacionDashboard/GetConvovatoriasPorFuenteBySemestre?anio=${anio}&rango1=${rango1}&rango2=${rango2}`;
  StartLoader();
  fetch(urlDatos, {
    method: "GET",
    headers: { Authorization: "Bearer " + TokenIRIS },
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.Ok) {
        var lisDatos = data.Data;
        var labels = lisDatos.map(function (e) {
          return e.nmfuentecnv;
        });
        var datos = lisDatos.map(function (e) {
          return e.count;
        });
        let ChartConvocatorias = new Chart(
          document.getElementById("chartConvocatoriasFuentes"),
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
                  text: "Convocatorias Internas",
                },
              },
            },
          }
        );
        FinalizeLoader();
        insertChartPie.append(ChartConvocatorias);
      } else {
        debugger
        FinalizeLoader();
        ShowModalDialog(err, false, "warning", "", 0);
      }
    })
    .catch((err) => {
      debugger
      FinalizeLoader();
      ShowModalDialog(err, false, "error", "", 0);
    });
    
}



//OnChange para mostrar las funciones filtradas por semestre
function onChangeSemestre(Semestre){
  reloadCharts();
  let valueSemestre = Semestre.value;
  let año = parseInt(valueSemestre.substring(0,4)); //variable para obtener el año a partir del semestre seleccionado 
  let mes = valueSemestre.substring(5,7)//variable para obtener el mes a partir del semestre seleccionado 
  let rango1, rango2;  //variables para definir el rango y ajustarlo al qry que se tiene 
  


  if(mes == "01"){ //si pertenece al primer semestre del año, se añade el rango del 1 al 6 mes 
    rango1 = 1;
    rango2 = 6
  }else{
    rango1=7;
    rango2=12
  }

  if(valueSemestre != 0){
    loadChartMontoEjecutadoBySemestre(valueSemestre)
    loadChartMontoComprometidoComprometerBySemestre(valueSemestre)
    loadChartEstadoProyectoBySemestre(año, rango1, rango2)
    Create_DivCharComprometidoSemestre(valueSemestre, año, rango1, rango2)
  }else{
    showChartsDefault()
    ShowModalDialog("Seleccione una opción válida", false, "error", "", 0);

  }
}


function showChartsDefault() {
  _loadChartMontoEjecutadoSemestre();

  _loadChartMontoComprometidoComprometer();
  Create_DivCharComprometido();
  createOptionSelect();
  _loadChartEstadoProyecto();
}

showChartsDefault();

function loadChartsFilterLiteral(btn) {
  let selectSemestres = document.getElementById("SelectSemestre");
  let valueSemestre = selectSemestres.value;
  let año = parseInt(valueSemestre.substring(0,4)); //variable para obtener el año a partir del semestre seleccionado 
  let mes = valueSemestre.substring(5,7)//variable para obtener el mes a partir del semestre seleccionado 
  let semestre = valueSemestre.substring(5,7)//variable para obtener el mes a partir del semestre seleccionado 
  let rango1, rango2;  //variables para definir el rango y ajustarlo al qry que se tiene 
  
  if(mes == "01"){ //si pertenece al primer semestre del año, se añade el rango del 1 al 6 mes 
    rango1 = 1;
    rango2 = 6
  }else{
    rango1=7;
    rango2=12
  }


  if (valueSemestre != "") {
    let valueBtn = btn.value;
    reloadCharts();
   
    if(valueBtn == 'A'){
      reloadCharts();
      
      loadChartFuentesBySemestre(año, rango1, rango2)

    }
    loadChartMontoEjecutadoSemestre(valueBtn, valueSemestre);
    loadChartMontoComprometidoComprometer(valueBtn, valueSemestre);
    loadChartEstadoProyectoByLiteral(valueBtn, año, rango1, rango2)
    Create_DivCharComprometidoSemestreLiteral(valueSemestre, valueBtn, año, rango1, rango2)
  } else {
    ShowModalDialog("Seleccione: Semestre ", false, "warning", "", 0);
  }
}




//Debe actualizar todas las graficas bien sea cambiando el semestre o eligiendo semestre y literal 

