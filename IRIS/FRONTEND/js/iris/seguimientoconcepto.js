var DataTableSeguimientoConcepto = null;

$(document).ready(function () {   
    LoadDataTableSeguimientoConcepto();
});


function LoadDataTableSeguimientoConcepto() {
    DataTableSeguimientoConcepto = $('#tblSeguimientoConcepto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Seguimiento_Concepto/GetDataTableSeguimiento_Concepto"
        },      
        "columns": [                    
            { "data": "codigointernoconcepto", "orderable": true },
            { "data": "nombreconcepto", "orderable": true },
            { "data": "NombrePartida", "orderable": false },
            { "data": "NombreRubro", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarSeguimiento_Concepto(' + row.id_segconcepto + ')" data-bs-toggle="modal" data-bs-target="#ModalSeguimientoConcepto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Concepto" onclick="ValidarEliminarSeguimiento_Concepto(' + row.id_segconcepto + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDataTableSeguimientoConcepto() {
    DataTableSeguimientoConcepto.ajax.reload(null, false);
}

function CargarRubros() {    
    let idPartida = $("#cboIdPartidaSeguimientoConcepto").val();

    if (idPartida != null){
        LoadSeguimientoRubroByPartida('cboIdRubroSeguimientoConcepto', false, idPartida);
    }
    
    if ($('#cboIdRubroSeguimientoConcepto').data('select2')) {
        $('#cboIdRubroSeguimientoConcepto').select2('destroy');        
      }                

    $('#cboIdRubroSeguimientoConcepto').select2().val('').trigger("change");

    $('#cboIdRubroSeguimientoConcepto').select2({
        dropdownParent: $('#ModalSeguimientoConcepto'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });

}

function CrearSeguimiento_Concepto() {
    $("#spanIdSeguimientoConcepto")[0].innerText = '';
    $("#txtCodigoSeguimientoConcepto").val('');
    $("#txtNombreSeguimientoConcepto").val('');
    $( "#cboIdPartidaSeguimientoConcepto" ).prop( "disabled", false );
    $( "#cboIdRubroSeguimientoConcepto" ).prop( "disabled", false );

    LoadSeguimientoPartida('cboIdPartidaSeguimientoConcepto', true);  
    $('#cboIdRubroSeguimientoConcepto').empty();

    $('#cboIdPartidaSeguimientoConcepto').select2({
        dropdownParent: $('#ModalSeguimientoConcepto'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });

    $('#cboIdRubroSeguimientoConcepto').select2({
        dropdownParent: $('#ModalSeguimientoConcepto'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    removeValidationFormByForm('formSeguimientoConcepto');    
}

function EditarSeguimiento_Concepto(id_segconcepto) {
    removeValidationFormByForm('formSeguimientoConcepto'); 
    $("#spanIdSeguimientoConcepto")[0].innerText = id_segconcepto;
    let urlEditar = urlController + "Seguimiento_Concepto/GetSeguimiento_ConceptoDetails?id_concepto=" + id_segconcepto;    
    StartLoader();

    LoadSeguimientoPartida('cboIdPartidaSeguimientoConcepto', false);        

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtCodigoSeguimientoConcepto").val(datos.codigointernoconcepto);
            $("#txtNombreSeguimientoConcepto").val(datos.nombreconcepto);
            $('#cboIdPartidaSeguimientoConcepto').select2().val(datos.id_partida).trigger("change");

            LoadSeguimientoRubroByPartida('cboIdRubroSeguimientoConcepto', false, datos.id_partida);
            $('#cboIdRubroSeguimientoConcepto').select2().val(datos.id_rubro).trigger("change");

            $('#cboIdPartidaSeguimientoConcepto').select2({
                dropdownParent: $('#ModalSeguimientoConcepto'),
                placeholder: "Seleccione",        
                width: 'resolve'
            });

            $('#cboIdRubroSeguimientoConcepto').select2({
                dropdownParent: $('#ModalSeguimientoConcepto'),
                placeholder: "Seleccione",        
                width: 'resolve'
            });

            $( "#cboIdPartidaSeguimientoConcepto" ).prop( "disabled", true );
            $( "#cboIdRubroSeguimientoConcepto" ).prop( "disabled", true );        
                    
            FinalizeLoader();
            return;
        }
        else {
            ShowModalDialog(data.Message, false, 'warning', '', 0);
            FinalizeLoader();
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        return;
      } );         
}

function ValidatePostUpdateSeguimientoConcepto(formF, botonCerrar) {
    validateTextXSSLastButtonByForm(formF);

    var formV = $("#" + formF);
    if (formV[0].checkValidity() == false) {
        $(formV).addClass('was-validated');
    } else {
        if (checkValidityXSS == false) {
            $(formV).addClass('was-validated');
        } else {
            if (checkValiditySelect == false) {
                $(formV).addClass('was-validated');
            } else {
                AddUpdateSeguimientoConcepto(botonCerrar);
            }
        }
    }    
}

function AddUpdateSeguimientoConcepto(botonCerrar) {
    var objData = new Object();
    let urlUpdate = urlController + "Seguimiento_Concepto/UpdateSeguimiento_Concepto";
    
	objData.id_segconcepto = ($("#spanIdSeguimientoConcepto")[0].innerText == '') ? undefined : $("#spanIdSeguimientoConcepto")[0].innerText;
    objData.codigointernoconcepto = $("#txtCodigoSeguimientoConcepto").val();
    objData.nombreconcepto = $("#txtNombreSeguimientoConcepto").val();
	objData.id_partida = $("#cboIdPartidaSeguimientoConcepto").val();
    objData.id_rubro = $("#cboIdRubroSeguimientoConcepto").val();

    if (objData.id_segconcepto == undefined) {
        urlUpdate = urlController + "Seguimiento_Concepto/InsertSeguimiento_Concepto";        
    }

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTableDataTableSeguimientoConcepto();
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );      
}

function CerrarModalUpdateSeguimientoConcepto() {
    if ($('#cboIdPartidaSeguimientoConcepto').data('select2')) {
        $('#cboIdPartidaSeguimientoConcepto').select2('destroy');        
      }    

    if ($('#cboIdRubroSeguimientoConcepto').data('select2')) {
        $('#cboIdRubroSeguimientoConcepto').select2('destroy');        
      }                
}

function ValidarEliminarSeguimiento_Concepto(id_segconcepto) {
    ShowDialogConfirmacion('','Seguro de eliminar concepto', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarSeguimiento_Concepto(id_segconcepto);
            }
        });
}

function EliminarSeguimiento_Concepto(id_segconcepto) {
    let urlEliminar = urlController + "Seguimiento_Concepto/DeleteSeguimiento_Concepto?id_concepto=" + id_segconcepto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableSeguimientoConcepto();
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