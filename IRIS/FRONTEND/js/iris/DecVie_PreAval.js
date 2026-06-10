var DataTableDecVie_PreAval = null;
var ObjModelDecVie_PreAval = null;
var ObjModelDecVie_PreAvalSolicitud = null;
var ObjModelDecVie_PreAvalRevision = null;
var ObjModelDecVie_PreAvalConceptoDecanatura = null;

$(document).ready(function () {
    LoadDataTableDecVie_PreAval();
    ObjModelDecVie_PreAval = new DecVie_PreAvalSolicitud();
        
});

function LoadDataTableDecVie_PreAval() {
    DataTableDecVie_PreAval = $('#tblDecVie_PreAval').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PreAval/GetDataTableDecVie_PreAval"
        },      
        "columns": [                    
            { "data": "id_preaval", "orderable": true },
            { "data": "consecutivo", "orderable": true },
            { "data": "tiposolucitud", "orderable": true },
            { "data": "NombreMacroproceso", "orderable": false },
            { "data": "NombreDependencia", "orderable": false },
            { "data": "NombreEstadoPreaval", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                            '<li class="dropdown-item cambiarMouse form-label-iris opciones_datatable dropdown-iris" onclick="DecVie_PreAval_Revision(' + row.id_preaval + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_PreAval_Revision"><img src="../images/iris/Editar.png"> Revisiones</> </li>' +                            
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="DecVie_PreAval_ConceptoDecanatura(' + row.id_preaval + ')"data-bs-toggle="modal" data-bs-target="#ModalDecVie_PreAval_ConceptoDecanatura"><img src="../images/iris/seguimiento.png">Concepto Decanatura</> </li>' +
                         /* '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="CicloFinancieroProgramas_Facultad(' + row.id_postprogram + ')"data-bs-toggle="modal" data-bs-target="#ModalCicloFinancieroProgramas_Facultad"><img src="../images/iris/minuta.png">   Secretaría Facultad</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="CicloFinancieroProgramas_UAdministrativa(' + row.id_postprogram + ')"data-bs-toggle="modal" data-bs-target="#ModalCicloFinancieroProgramas_UAdministrativa"><img src="../images/iris/modificar.png">   Unidad Administrativa</> </li>' + */
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarDecVie_PreAval(' + row.id_preaval + ');"><img src="../images/iris/Eliminar.png"> Eliminar PreAval</> </li>' + 
                        '</ul>' +
                        '</div>';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.consecutivo + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PreAval() {
    DataTableDecVie_PreAval.ajax.reload(null, false);
}

function ValidarEliminarDecVie_PreAval(idpreaval) {
    ShowDialogConfirmacion('','Seguro de eliminar el PreAval seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PreAval(idpreaval);
            }
        });
}

function EliminarDecVie_PreAval(idpreaval) {
    let urlEliminar = urlController + "DecVie_PreAval/DeleteDecVie_PreAval?id_preaval=" + idpreaval;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PreAval();
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

function CrearDecVie_PreAval() {
    $("#spanIdDecVie_PreAval")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_PreAvalDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PreAvalDetalle.html', 'dvDecVie_PreAvalDetalle');
    }
    else {
        CrearDecVie_PreAvalform();
    }
}

function EditarDecVie_PreAval(idpreaval) {
    $("#spanIdDecVie_PreAval")[0].innerText = idpreaval;
    
    if (!ExisteDivEdicionDatos('dvDecVie_PreAvalDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PreAvalDetalle.html', 'dvDecVie_PreAvalDetalle');
    }
    else {
        EditarDecVie_PreAvalform(idpreaval);
    }

}

//#region Preaval Revisión
function DecVie_PreAval_Revision(id_preaval) {
    if (ObjModelDecVie_PreAvalRevision == null) {
        ObjModelDecVie_PreAvalRevision = new DecVie_PreAvalRevision();
    }
        
    ObjModelDecVie_PreAvalRevision.FormEdicion = 'formDecVie_PreAval_RevisionDetalle';

    CreateHTMLFromModel(ObjModelDecVie_PreAvalRevision)
      .then(htmlcreado => {
          $('#txtid_preaval_DecVie_PreAvalRevision').val(id_preaval);
              
          LoadData_ToModel(ObjModelDecVie_PreAvalRevision, id_preaval)
          .then(datoscargados => {
              if (datoscargados) { 
                  FinalizeLoader();
              }
          })    
          .catch (err => {
              FinalizeLoader();
              ShowModalDialog(err, false, 'error', '', 0);
          })      
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
      })  
}

function ValidatePostUpdateDecVie_PreAval_RevisionForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PreAvalRevision)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos revisión Guardados', false, 'success', '', 0);
        RefreshDataTableDecVie_PreAval (); 
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })
}

//#endregion

//#region Preaval Concepto Decanatura
function DecVie_PreAval_ConceptoDecanatura(id_preaval) {
    if (ObjModelDecVie_PreAvalConceptoDecanatura == null) {
        ObjModelDecVie_PreAvalConceptoDecanatura = new DecVie_PreAvalConceptoDecanatura();
    }
        
    ObjModelDecVie_PreAvalConceptoDecanatura.FormEdicion = 'formDecVie_PreAval_ConceptoDecanaturaDetalle';

    CreateHTMLFromModel(ObjModelDecVie_PreAvalConceptoDecanatura)
      .then(htmlcreado => {
          $('#txtid_preaval_DecVie_PreAval_ConceptoDecanatura').val(id_preaval);
              
          LoadData_ToModel(ObjModelDecVie_PreAvalConceptoDecanatura, id_preaval)
          .then(datoscargados => {
              if (datoscargados) { 
                  FinalizeLoader();
              }
          })    
          .catch (err => {
              FinalizeLoader();
              ShowModalDialog(err, false, 'error', '', 0);
          })      
      })
      .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
      })  
}

function ValidatePostUpdateDecVie_PreAval_ConceptoDecanaturaForm(formF, botonCerrar) {

    ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PreAvalConceptoDecanatura)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
        ShowModalDialog('Datos Concepto Decanatura Guardados', false, 'success', '', 0);
        RefreshDataTableDecVie_PreAval (); 
        
        for (var i = 0; i < 2; i++) {
            $('#' + botonCerrar).click();
        }
    
      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })
}

//#endregion
