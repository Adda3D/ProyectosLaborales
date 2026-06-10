var DataTableDecVie_CertificadosTec = null;

$(document).ready(function () {
    LoadDataTableDecVie_CertificadosTec(); 
});

function LoadDataTableDecVie_CertificadosTec() {
    DataTableDecVie_CertificadosTec = $('#tblDecVie_CertificadosTec').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_CertificadosTec/GetDataTableDecVie_CertificadosTec"
        },
        "columns": [
            { "data": "id_decviecertificadostec", "orderable": true }, // ID
            { 
                "data": "fecha", 
                "orderable": true, 
                render: function (data, type, row, meta) {
                    return row.fecha.slice(0, 10); 
                } 
            }, // Fecha
            { "data": "numcertificadotec", "orderable": true }, // Certificado
            { "data": "asunto", "orderable": true }, // Asunto
            { "data": "tsersubserdocu", "orderable": false }, // Solicitante    
            { "data": "tipo", "orderable": false},
            { "data": "estado_pago", "orderable": false }, // Estado Pago
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_CertificadosTec(' + row.id_decviecertificadostec + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Certificado" onclick="ValidarEliminarDecVie_CertificadosTec(' + row.id_decviecertificadostec + ',`' + row.numcertificadotec + '`);" />';
                },
                "className": "text-center", 
                "orderable": false
            }
        ],
        "columnDefs": [
            { 
                "targets": 2,
                render: function (data, type, full, meta) {
                    return type === 'display' ? '<div title="' + full.numcertificadotec + '">' + data : data;
                }
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]] 
    });
}

function LoadDecvieTipoCertificado() {
    return new Promise((resolve) => {
        var select = $('#cboid_certificado_tipo_DecVie_CertificadosTec');
        select.append('<option value="PREGRADO">PREGRADO</option>');
        select.append('<option value="POSTGRADO">POSTGRADO</option>');
        resolve();
    });
}

function LoadDecvieTipo() {
    return new Promise((resolve) => {
        var select = $('#cbotipo_DecVie_CertificadosTec');
        select.append('<option value="CERTIFICADO">CERTIFICADO</option>');
        select.append('<option value="VERIFICACION">VERIFICACION</option>');

        // Agregar evento para detectar cambios en el valor
        select.on('change', function () {
            var selectedValue = $(this).val();
            if (selectedValue === 'VERIFICACION') {
                $('#cboestado_pago_DecVie_CertificadosTec').closest('.col-md-2').addClass('d-none');
            } else {
                $('#cboestado_pago_DecVie_CertificadosTec').closest('.col-md-2').removeClass('d-none');
            }
        });

        resolve();
    });
}


function LoadDecvieEstadoPago() {
    return new Promise((resolve) => {
        var select = $('#cboestado_pago_DecVie_CertificadosTec');
        select.append('<option value="NO APLICA" selected>NO APLICA</option>');
        select.append('<option value="NO PAGO">NO PAGO</option>');
        select.append('<option value="PAGADO">PAGADO</option>');
        resolve();
    });
}

function RefreshDataTableDecVie_CertificadosTec() {
    DataTableDecVie_CertificadosTec.ajax.reload(null, false);
}

function ValidarEliminarDecVie_CertificadosTec(iddecviecertificadostec, numcertificadotec) {
    ShowDialogConfirmacion('','Seguro de eliminar el certificado ' + numcertificadotec + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_CertificadosTec(iddecviecertificadostec);
            }
        });
}

function EliminarDecVie_CertificadosTec(iddecviecertificadostec) {
    let urlEliminar = urlController + "DecVie_CertificadosTec/DeleteDecVie_CertificadosTec?id_decviecertificadostec=" + iddecviecertificadostec;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_CertificadosTec();
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
      });
}

function CrearDecVie_CertificadosTec() {
    $("#spanIdDecVie_CertificadosTec")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_CertificadosTecDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_CertificadosTecDetalle.html', 'dvDecVie_CertificadosTecDetalle');
    }
    else {
        CrearDecVie_CertificadosTecform();
    }
}

function EditarDecVie_CertificadosTec(iddecviecertificadostec) {
    $("#spanIdDecVie_CertificadosTec")[0].innerText = iddecviecertificadostec;
    
    if (!ExisteDivEdicionDatos('dvDecVie_CertificadosTecDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_CertificadosTecDetalle.html', 'dvDecVie_CertificadosTecDetalle');
    }
    else {
        EditarDecVie_CertificadosTecform(iddecviecertificadostec);
    }
}
