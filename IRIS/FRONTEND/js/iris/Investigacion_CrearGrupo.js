var DataTableInvestigacion_CrearGrupo = null;

$(document).ready(function () {
    LoadDataTableInvestigacion_CrearGrupo(); 
        
});


function LoadDataTableInvestigacion_CrearGrupo() {
    DataTableInvestigacion_CrearGrupo = $('#tblInvestigacion_CrearGrupo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_CrearGrupo/GetDataTableInvestigacion_CrearGrupo"
        },      
        "columns": [                    
            { "data": "codigohermes", "orderable": true },
            { "data": "minciencias", "orderable": true, render: function (data, type, row, meta) {return row.minciencias.slice(0,4)} },
            { "data": "nombregrupo", "orderable": true },
            { "data": "NomCompleto", "orderable": false },
            { "data": "AreaCurricular", "orderable": false},
            { "data": "correogrupo", "orderable": true},            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarCrearGrupo(' + row.id_creargrupo + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarCrearGrupo(' + row.id_creargrupo + ',`' + row.codigohermes + '`);" /> ';
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

function RefreshDataTableInvestigacion_CrearGrupo() {
    DataTableInvestigacion_CrearGrupo.ajax.reload(null, false);
}

function CrearInvestigacion_CrearGrupo() {    
    $("#spanIdGrupoInvestigacion")[0].innerText = '';

    if (!ExisteDivEdicionInvestigacion_CrearGrupo()) {
        CrearDivEdicionInvestigacion_CrearGrupo();
    }
    else {
        CrearGrupoInvestigacionform();
    }
}

function ExisteDivEdicionInvestigacion_CrearGrupo() {
    let divedicion = document.getElementById('dvGrupoInvestigacionDetalle').innerHTML;

    if (divedicion == null || divedicion == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivEdicionInvestigacion_CrearGrupo() {    
    let urledit = '/Pages/Investigacion/detalle_Investigacion_CrearGrupo.html';     

    $.get(urledit, function (htmlexterno) {
        $('#dvGrupoInvestigacionDetalle').html(htmlexterno);
    });    

}

function EditarCrearGrupo(IdGrupoInvestigacion) {
    $("#spanIdGrupoInvestigacion")[0].innerText = IdGrupoInvestigacion;

    if (!ExisteDivEdicionInvestigacion_CrearGrupo()) {
        CrearDivEdicionInvestigacion_CrearGrupo();
    }
    else {
        EditarInvestigacion_CrearGrupoform(IdGrupoInvestigacion);
    }

}

function ValidarEliminarCrearGrupo(IdGrupoInvestigacion) {
    ShowDialogConfirmacion('','Seguro de eliminar Grupo Investigación?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarGrupoInvestigacion(IdGrupoInvestigacion);
            }
        });

}

function EliminarGrupoInvestigacion(IdGrupoInvestigacion) {
    let urlEliminar = urlController + "Investigacion_CrearGrupo/DeleteInvestigacion_CrearGrupo?id_creargrupo=" + IdGrupoInvestigacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableInvestigacion_CrearGrupo();
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




