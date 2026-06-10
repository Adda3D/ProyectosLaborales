var DataTableDecvie_Matryoshka = null;
var IdFiltroDependenciaUsuarioMatryoshka = null;

$(document).ready(function () {
    debugger;

    LoadDependenciaSelectNulo('cboFiltroDependenciaUsuario', false)
    .then(datoscargados => {
        if (datoscargados) {
            if (IdDependenciaUsuarioLogueado != null) {
                $('#cboFiltroDependenciaUsuario').select2().val(IdDependenciaUsuarioLogueado).trigger("change");
                IdFiltroDependenciaUsuarioMatryoshka = IdDependenciaUsuarioLogueado;
                $("#cboFiltroDependenciaUsuario" ).prop( "disabled", true );
            }
            else {
                $("#cboFiltroDependenciaUsuario").val($("#cboFiltroDependenciaUsuario option:first").val()).trigger('change');
                $("#cboFiltroDependenciaUsuario" ).prop( "disabled", false );
            }
        
            $('#cboFiltroDependenciaUsuario').select2();
            
            if (DataTableDecvie_Matryoshka == null) {
                LoadDataTableDecvie_Matryoshka();
            }        
        }
    })
        
});

function ActualizarFiltroDependenciaMatryoshkaUsuario() {    
    IdFiltroDependenciaUsuarioMatryoshka = $('#cboFiltroDependenciaUsuario').val();    

    if (DataTableDecvie_Matryoshka == null) {
        LoadDataTableDecvie_Matryoshka();
    }
    else {
        RefreshDataTableDecvie_Matryoshka();
    }        
}


function LoadDataTableDecvie_Matryoshka() {
    DataTableDecvie_Matryoshka = $('#tblDecvie_Matryoshka').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Decvie_Matryoshka/GetDataTableDecvie_MatryoshkaByDependencia",    
            "data": {
                "id_depend": function() { return IdFiltroDependenciaUsuarioMatryoshka }                
            }            
        },      
        "columns": [                    
            //{ "data": "id_matryoska", "orderable": true },
            { "data": "alcance", "orderable": true },
            { "data": "NombreDependencia", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<div class="dropdown-acciones">' +
                        '<img src="../images/iris/dot-20.png" class="cambiarMouse hover08" data-bs-toggle="dropdown" title="Click Para ver opciones"></>' +
                        '<ul class="dropdown-menu opciones_datatable"> ' +
                         //   '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris opciones_datatable" onclick="EditarDecvie_Matryoshka(' + row.id_matryoska + ')"><img src="../images/iris/Editar.png">   Editar Datos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="EjesEstrategicosMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/seguimiento.png">   Eje Estratégicos</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ProgramaPgdMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/minuta.png">   Programas</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="EstrategiaMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/modificar.png">   Estrategias</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ObjetivosPGDMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/seguro.png">   Objetivos PGD VRI SEDE</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ObjetivosDepMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/editar.png">   Objetivos Dependencia</> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="MetasDependenciaMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/editar-1.png"> Metas </> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ActividadesDependenciaMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/modi-seguro.png"> Actividades </> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="IndicadorEstrategicoMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/evaluacion.png"> Indicador Estratégico </> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="NuevoIndicadorMatryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/seguimiento-blue.png"> Nuevo Indicador </> </li>' +
                            '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="MatryoshkaExcel(' + row.id_matryoska  + ');"><img src="../images/iris/excel.png">Exportar Excel</> </li>' +
                         //   '<li class="dropdown-item cambiarMouse form-label-iris dropdown-iris" onclick="ValidarEliminarDecvie_Matryoshka(' + row.id_matryoska + ',`' + row.alcance + '`,`' + row.NombreDependencia + '`);"><img src="../images/iris/Eliminar.png">   Eliminar Matryoshka</> </li>' +
                        '</ul>' +
                        '</div>';
                },                                        
                "className": "text-center", "orderable": false
            } 
                       
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.alcance + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_Matryoshka() {
    DataTableDecvie_Matryoshka.ajax.reload(null, false);
}

function ValidarEliminarDecvie_Matryoshka(idmatryoshka) {
    ShowDialogConfirmacion('','Seguro de eliminar la Matryoshka seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_Matryoshka(idmatryoshka);
            }
        });
}

function EliminarDecvie_Matryoshka(idmatryoshka) {
    let urlEliminar = urlController + "Decvie_Matryoshka/DeleteDecvie_Matryoshka?id_matryoska=" + idmatryoshka;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_Matryoshka();
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

function CrearDecvie_Matryoshka() {
    $("#spanIdDecvie_Matryoshka")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaDetalle.html', 'dvDecvie_MatryoshkaDetalle');
    }
    else {
        CrearDecvie_Matryoshkaform();
    }
}

function EditarDecvie_Matryoshka(idmatryoshka) {
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    
    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaDetalle.html', 'dvDecvie_MatryoshkaDetalle');
    }
    else {
        EditarDecvie_Matryoshkaform(idmatryoshka);
    }

}

function EjesEstrategicosMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaEjesEstrategicos')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaEjesEstrategicos.html', 'dvDecvie_MatryoshkaEjesEstrategicos');
    }
    else {
        InicializaMatryoshkaEjesEstrategicosform(idmatryoshka, alcance, nombredependencia);
    }

    
}

function ProgramaPgdMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaProgramaPgd')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaProgramaPgd.html', 'dvDecvie_MatryoshkaProgramaPgd');
    }
    else {
        InicializaDecvie_MatryoshkaProgramaPgdform(idmatryoshka, alcance, nombredependencia);
    }

    
}

function EstrategiaMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaEstrategia')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaEstrategia.html', 'dvDecvie_MatryoshkaEstrategia');
    }
    else {
        InicializaDecvie_MatryoshkaEstrategiaform(idmatryoshka, alcance, nombredependencia);
    }

    
}

function ObjetivosPGDMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaObjetivoPgd')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaObjetivoPgd.html', 'dvDecvie_MatryoshkaObjetivoPgd');
    }
    else {
        InicializaDecvie_MatryoshkaObjetivoPgdform(idmatryoshka, alcance, nombredependencia);
    }

    
}

function ObjetivosDepMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaObjetivoDep')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaObjetivoDep.html', 'dvDecvie_MatryoshkaObjetivoDep');
    }
    else {
        InicializaDecvie_MatryoshkaObjetivoDepform(idmatryoshka, alcance, nombredependencia);
    }

    
}

function MetasDependenciaMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaMetaDep')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaMetaDep.html', 'dvDecvie_MatryoshkaMetaDep');
    }
    else {
        InicializaDecvie_MatryoshkaMetaDepform(idmatryoshka, alcance, nombredependencia);
    }

    
}

function ActividadesDependenciaMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaActividadDep')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaActividadDep.html', 'dvDecvie_MatryoshkaActividadDep');
    }
    else {
        InicializaDecvie_MatryoshkaActividadDepform(idmatryoshka, alcance, nombredependencia);
    }

    
}

function IndicadorEstrategicoMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaIndicadorEstrategico')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaIndicadorEstrategico.html', 'dvDecvie_MatryoshkaIndicadorEstrategico');
    }
    else {
        InicializaDecvie_MatryoshkaIndicadorEstrategicoform(idmatryoshka, alcance, nombredependencia);
    }
}

function NuevoIndicadorMatryoshka(idmatryoshka, alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = idmatryoshka;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance;
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia;

    if (!ExisteDivEdicionDatos('dvDecvie_MatryoshkaNuevoIndicador')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_MatryoshkaNuevoIndicador.html', 'dvDecvie_MatryoshkaNuevoIndicador');
    }
    else {
        InicializaDecvie_MatryoshkaNuevoIndicadorform(idmatryoshka, alcance, nombredependencia);
    }
}

function MatryoshkaExcel(id_matryoska,alcance, nombredependencia) {
    debugger;
    $("#spanIdDecvie_Matryoshka")[0].innerText = id_matryoska;
    $("#spanAlcancePoliticaDecvie_Matryoshka")[0].innerText = alcance; 
    $("#spanDependenciaDecvie_Matryoshka")[0].innerText = nombredependencia; 

    let urlExcel = urlController + "Decvie_Matryoshka/ExcelDecvie_Matryoshka?id_matryoska=" + id_matryoska;
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