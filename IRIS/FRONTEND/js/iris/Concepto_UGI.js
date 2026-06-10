var DataTableConcepto_UGI = null;

$(document).ready(function () {
    LoadDataTableConcepto_UGI();
});

function LoadDataTableConcepto_UGI() {
    DataTableConcepto_UGI = $('#tblConcepto_UGI').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Concepto_UGI/GetDataTableConcepto_UGI"
        },      
        "columns": [            
            { "data": "concepto", "orderable": true },
        //  { "data": "nombreliteral", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarConcepto_UGI(' + row.id_conceptougi + ')" data-bs-toggle="modal" data-bs-target="#ModalConcepto_UGI" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarConcepto_UGI(' + row.id_conceptougi + ',`' + row.concepto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}


function RefreshDataTableConcepto_UGI() {
    DataTableConcepto_UGI.ajax.reload(null, false);
}

function CrearConcepto_UGI() {
    $("#spanIDConcepto_UGI")[0].innerText = '';
    $("#txtConcepto_UGI").val('');

 /*   LoadLiteral_UGI('cboliteralConcepto_UGI', false);    

    $('#cboliteralConcepto_UGI').select2({
        dropdownParent: $('#ModalConcepto_UGI'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });*/
    
    removeValidationFormByForm('formConcepto_UGIDatos');    
}

function EditarConcepto_UGI(id_conceptougi) {
    removeValidationFormByForm('formConcepto_UGIDatos'); 
    
    $("#spanIDConcepto_UGI")[0].innerText = id_conceptougi;
    let urlEditar = urlController + "Concepto_UGI/GetConcepto_UGIDetails?id_conceptougi=" + id_conceptougi;    
    StartLoader();

  //  LoadLiteral_UGI('cboliteralConcepto_UGI', false);        

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtConcepto_UGI").val(datos.concepto);
         /*   $('#cboliteralConcepto_UGI').select2().val(datos.id_literal).trigger("change");

            $('#cboliteralConcepto_UGI').select2({
                dropdownParent: $('#ModalConcepto_UGI'),
                placeholder: "Seleccione",        
                width: 'resolve'
            });*/
                    
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

function ValidatePostUpdateConcepto_UGI(formF, botonCerrar) {
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
                AddUpdateConcepto_UGI(botonCerrar);
            }
        }
    }    
}

function AddUpdateConcepto_UGI(botonCerrar) {
    var objData = new Object();
    let urlUpdate = urlController + "Concepto_UGI/UpdateConcepto_UGI";
    
	objData.id_conceptougi = ($("#spanIDConcepto_UGI")[0].innerText == '') ? undefined : $("#spanIDConcepto_UGI")[0].innerText;
	objData.concepto = $("#txtConcepto_UGI").val();
  //  objData.id_literal = $("#cboliteralConcepto_UGI").val();

    if (objData.id_conceptougi == undefined) {
        urlUpdate = urlController + "Concepto_UGI/InsertConcepto_UGI";        
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

            RefreshDataTableConcepto_UGI();
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

function CerrarModalConcepto_UGI() {
    if ($('#txtConcepto_UGI').data('select2')) {
        $('#txtConcepto_UGI').select2('destroy');        
      }    

}

function ValidarEliminarConcepto_UGI(id_conceptougi) {
    ShowDialogConfirmacion('','Seguro de eliminar Concepto', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConcepto_UGI(id_conceptougi);
            }
        });
}

function EliminarConcepto_UGI(id_conceptougi) {
    let urlEliminar = urlController + "Concepto_UGI/DeleteConcepto_UGI?id_conceptougi=" + id_conceptougi;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConcepto_UGI();
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

/*function LoadLiteral_UGI(select, tienenulo) {
    $('#' + select).empty();
    let urlliteral = urlController + "Literal_UGI/GetAllLiteral_UGI";    
  
    return new Promise( (resolve, reject) => {
      fetch(urlliteral, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
        .then(data => {
          if (data.Ok) {
              let literaleslst = data.Data;
  
              if (tienenulo) {
                $('#' + select).append('<option value="">Seleccione</option>');
              }
              
              for (var i = 0; i < literaleslst.length; i++) {
                $('#' + select).append('<option value="' + literaleslst[i].id_literal + '">' + literaleslst[i].nmliteral + '</option>');
              }            
              return resolve(true);;
          }
          else {
            return resolve(false);;
          }            
        })
        .catch (err => {
          ShowModalDialog(err, false, 'error', '', 0);
          reject(err);
        } );
    });
      
}*/