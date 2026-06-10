var DataTableDecVie_ActosAdministrativos = null;

$(document).ready(function () {
    LoadDataTableDecVie_ActosAdministrativos(); 
        
});


function LoadDataTableDecVie_ActosAdministrativos() {
    DataTableDecVie_ActosAdministrativos = $('#tblDecVie_ActosAdministrativos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_ActosAdministrativos/GetDataTableDecVie_ActosAdministrativos"
        },      
        "columns": [                    
            { "data": "id_actoadministrativo", "orderable": true },
            { "data": "consecutivoactoadministrativo", "orderable": true },
            { "data": "SolicitanteActosAdmi", "orderable": false },
            { "data": "EstadoActoAdmi", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_ActosAdministrativos(' + row.id_actoadministrativo + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_ActosAdministrativos(' + row.id_actoadministrativo + ',`' + row.consecutivoactoadministrativo + '`);" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nombreproyecto + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_ActosAdministrativos() {
    DataTableDecVie_ActosAdministrativos.ajax.reload(null, false);
}

function ValidarEliminarDecVie_ActosAdministrativos(idactoadministrativo, consecutivoactoadministrativo) {
    ShowDialogConfirmacion('','Seguro de eliminar el Acto Administrativo con consecutivo ' + consecutivoactoadministrativo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_ActosAdministrativos(idactoadministrativo);
            }
        });
}

function EliminarDecVie_ActosAdministrativos(idactoadministrativo) {
    let urlEliminar = urlController + "DecVie_ActosAdministrativos/DeleteDecVie_ActosAdministrativos?id_actoadministrativo=" + idactoadministrativo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_ActosAdministrativos();
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      

}

function ExisteDivEdicionDecVie_ActosAdministrativos() {
    let divedicion = document.getElementById('dvDecVie_ActosAdministrativosDetalle').innerHTML;

    if (divedicion == null || divedicion == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivEdicionDecVie_ActosAdministrativos() {
    let urledit = '/Pages/Vie/DecVie_ActosAdministrativosDetalle.html'; 

    //let newDivedicion = document.createElement("div");
    let newDivedicion = document.getElementById('dvDecVie_ActosAdministrativosDetalle');
    //newDivedicion.id = 'dvProyectoExtensionDetalle';
    //newDivedicion.className = "row ocultar col-md-12 scroll";
    //document.body.appendChild(newDivedicion);

    $.get(urledit, function (htmlexterno) {
        $('#dvDecVie_ActosAdministrativosDetalle').html(htmlexterno);
    });    

}

function CrearDecVie_ActosAdministrativos() {
    $("#spanIdDecVie_ActosAdministrativos")[0].innerText = '';

    if (!ExisteDivEdicionDecVie_ActosAdministrativos()) {
        CrearDivEdicionDecVie_ActosAdministrativos();
    }
    else {
        CrearDecVie_ActosAdministrativosform();
    }

}

function EditarDecVie_ActosAdministrativos(idactoadministrativo) {
    $("#spanIdDecVie_ActosAdministrativos")[0].innerText = idactoadministrativo;

    if (!ExisteDivEdicionDecVie_ActosAdministrativos()) {
        CrearDivEdicionDecVie_ActosAdministrativos();
    }
    else {
        EditarDecVie_ActosAdministrativosform(idactoadministrativo);
    }

}

function ExportarExcelFunction() {
    debugger;
  /*  $("#spanIdDecvie_CicloFinanciero")[0].innerText = idciclofinanciero;
    $("#spanIDSemestreDecvie_CicloFinanciero")[0].innerText = id_semestre;
    $("#spanNombreSemestreDecvie_CicloFinanciero")[0].innerText = NombreSemestre;*/

    let urlExcel = urlController + "DecVie_ActosAdministrativos/ExcelDecVie_ActosAdministrativos";
    StartLoader();

    fetch(urlExcel, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {      
            debugger;                 
            FinalizeLoader();
            location.href = urlDownload + data.Data;
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      

}