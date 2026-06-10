var isUpdateCiudad = false;
var DataTableCiudad = null;


$(document).ready(function () {
    LoadDataTableCiudad();    
});

function LoadDataTableCiudad() {
    DataTableCiudad = $('#tblCiudad').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
        /*
        buttons: [
            {
                text: 'My button',
                action: function ( e, dt, node, config ) {
                    alert( 'Button activated' );
                }
            }
        ] */       
    });
}

