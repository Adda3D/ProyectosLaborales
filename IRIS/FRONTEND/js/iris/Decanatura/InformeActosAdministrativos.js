var IdFiltroTipoInformeActosAdministrativos = '0';
var ChartInformeActosAdministrativos = null;
var DataTableInformeActosAdministrativos = null;

$(document).ready(function () {
    $('#dtfeciniInformeActosAdministrativos').val(getFechaActual());
    $('#dtfecFinInformeActosAdministrativos').val(getFechaActual());

    LoadTipoInformeActosAdministrativos('cboFiltroTipoInformeActosAdministrativos', true);
    $('#cboFiltroTipoInformeActosAdministrativos').select2();
        
});

function ActualizarFiltroTipoInformeActosAdministrativos() {    
    IdFiltroTipoInformeActosAdministrativos = $('#cboFiltroTipoInformeActosAdministrativos').val();    

    if (ChartInformeActosAdministrativos != null) {
      ChartInformeActosAdministrativos.destroy();
    }    

    $('#tableDynamicINFACTADMxTipo').addClass('ocultar');

}

function CargarInformesActosAdministrativos() {
            
    switch (IdFiltroTipoInformeActosAdministrativos) {      
      case '1':
        document.getElementById("dvTituloINFACTADMxTipo").innerHTML = "INFORME ACTOS ADMINISTRATIVOS POR TIPO ACTO"; 
        break;        
      case '2':
        document.getElementById("dvTituloINFACTADMxTipo").innerHTML = "INFORME ACTOS ADMINISTRATIVOS POR ESTADO";        
        break;        
      case '3':
          document.getElementById("dvTituloINFACTADMxTipo").innerHTML = "INFORME ACTOS ADMINISTRATIVOS POR TIPOLOGÍA";          
          break;        
      case '4':
          document.getElementById("dvTituloINFACTADMxTipo").innerHTML = "INFORME ACTOS ADMINISTRATIVOS POR DEPENDENCIA SOLICITANTE";          
          break;
      case '5':
          document.getElementById("dvTituloINFACTADMxTipo").innerHTML = "INFORME ACTOS ADMINISTRATIVOS POR MACROPROCESO";          
          break; 
      case '6':
          document.getElementById("dvTituloINFACTADMxTipo").innerHTML = "INFORME ACTOS ADMINISTRATIVOS AGRUPADO POR MES";          
          break;
    
        }

     if (IdFiltroTipoInformeActosAdministrativos == '0') {      
      ShowModalDialog('Seleccione: Tipo Informe ' + 'e ' + 'ingrese: Fecha inicial ' + 'y ' + 'Fecha final', false, 'warning', '', 0);      
    return;
    }
    else{
      if (IdFiltroTipoInformeActosAdministrativos == ""){
        ShowModalDialog('Seleccione: Tipo Informe ' + 'e ' + 'ingrese: Fecha inicial ' + 'y ' + 'Fecha final', false, 'warning', '', 0);                
    return;
      }
    }
      
    $('#tableDynamicINFACTADMxTipo').removeClass('ocultar');
    
    LoadDataTableInformeActosAdministrativos("DecVie_ActosAdministrativosInformes/GetDataTableInformeDecVie_ActosAdministrativos");

    LoadGraphInformeActosAdministrativos('bar');

}

function LoadDataTableInformeActosAdministrativos(urlInforme) {

  if (DataTableInformeActosAdministrativos != null) {
    DataTableInformeActosAdministrativos.destroy();
  }

  DataTableInformeActosAdministrativos = $('#tblINFACTADMxTipo').DataTable({
      "language": {
          "url": "/lib/dataTables/Language.json"
      },
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      "search": {
          "caseInsensitive": true
      },
      "ajax": {
          "url": urlController + urlInforme,
          "data": {
            "idtipoinforme": function() { return IdFiltroTipoInformeActosAdministrativos },
            "fechainicial": function() { return $('#dtfeciniInformeActosAdministrativos').val(); },
            "fechafinal": function() { return $('#dtfecFinInformeActosAdministrativos').val(); }
        }
      },      
      "columns": [            
          { "data": "Tipo", "orderable": false },
          { "data": "Cantidad", "orderable": false }
      ],         
      "columnDefs": [
          { "targets": 1,
            className: 'dt-body-right',
            render: DataTable.render.number(',', '.', 0, '') 
          }
      ],
      dom: 'lBfrtip',
      "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
  });
  
}

function RefreshDataTableInformeActosAdministrativos() {
  DataTableInformeActosAdministrativos.ajax.reload(null, false);
}

function LoadGraphInformeActosAdministrativos(tipografico) {
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

  switch (IdFiltroTipoInformeActosAdministrativos) {
    case '1':
      labelGrafica = "No. ACTOS ADMINISTRATIVOS POR TIPO ACTO";         
      break;        
    case '2':
      labelGrafica = "No. ACTOS ADMINISTRATIVOS POR ESTADO";
      break;        
    case '3':
        labelGrafica = "No. ACTOS ADMINISTRATIVOS POR TIPOLOGÍA";
        break;        
    case '4':
        labelGrafica = "No. ACTOS ADMINISTRATIVOS POR DEPENDENCIA SOLICITANTE";
        break;        
    case '5':
        labelGrafica = "No. ACTOS ADMINISTRATIVOS POR MACROPROCESO";
        break;                
    case '6':
        labelGrafica = "No. ACTOS ADMINISTRATIVOS POR MES";
        break;                

  }

  
  if (ChartInformeActosAdministrativos != null) {
    ChartInformeActosAdministrativos.destroy();                  
  }    

  let urldatos = urlController + "DecVie_ActosAdministrativosInformes/GetInformeDecVie_ActosAdministrativos?idtipoinforme=" + IdFiltroTipoInformeActosAdministrativos +"&fechainicial=" + 
  $('#dtfeciniInformeActosAdministrativos').val() + "&fechafinal=" + $('#dtfecFinInformeActosAdministrativos').val();    
  StartLoader();

  
  fetch(urldatos, {
    method: 'GET',
    headers: { 'Authorization': 'Bearer ' + TokenIRIS }
})
.then(response => response.json())
  .then(data => {
    if (data.Ok) {
        let lstDatos = data.Data;

        var labels = lstDatos.map(function(e) {
          return e.Tipo;
        });

        var datos = lstDatos.map(function(e) {
          return e.Cantidad;
        });

        ChartInformeActosAdministrativos = new Chart(document.getElementById("chartINFACTADMxTipo"), {
          type: tipografico,
          data: {
            labels: labels,
            datasets: [
              {
                label: "Cantidad",
                backgroundColor: barColors,
                data: datos
              }
            ]
          },
          options: {            
            plugins: {  
                                                                                               
              legend: {
                display: false
              },
              title: {
                display: true,
                text: labelGrafica
              }  
            }
          }
        });    
  
        FinalizeLoader();

    }
    else {
      FinalizeLoader();
      ShowModalDialog(err, false, 'warning', '', 0);        
    }            
  })
  .catch (err => {
    FinalizeLoader();
    ShowModalDialog(err, false, 'error', '', 0);      
  } );

}




