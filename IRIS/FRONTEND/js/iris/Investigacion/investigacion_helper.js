function TotalesValorPRJINV() {
    let nvalortotalPRJINV = 0;
    let svalorcontrol = 0;
    let nvalorcontrol = 0;

    //svalorcontrol = $("#nmvaloraprobado_Investigacion_CrearProyecto").val();
    //nvalorcontrol = Number(svalorcontrol);
    //nvalortotalPRJINV = nvalortotalPRJINV + nvalorcontrol;
debugger
    svalorcontrol = $("#nfvaloraportevir_Investigacion_CrearProyecto").val();
    nvalorcontrol = Number(svalorcontrol);
    nvalortotalPRJINV = nvalortotalPRJINV + nvalorcontrol;

    svalorcontrol = $("#nfvaloraportefacultad_Investigacion_CrearProyecto").val();
    nvalorcontrol = Number(svalorcontrol);
    nvalortotalPRJINV = nvalortotalPRJINV + nvalorcontrol;

    svalorcontrol = $("#nfvaloraportedieb_Investigacion_CrearProyecto").val();
    nvalorcontrol = Number(svalorcontrol);
    nvalortotalPRJINV = nvalortotalPRJINV + nvalorcontrol;

    //svalorcontrol = $("#nmvaloraporteotro_Investigacion_CrearProyecto").val();
    //nvalorcontrol = Number(svalorcontrol);
    //nvalortotalPRJINV = nvalortotalPRJINV + nvalorcontrol;

    svalorcontrol = $("#nfvaloraporteexterno_Investigacion_CrearProyecto").val();
    nvalorcontrol = Number(svalorcontrol);
    nvalortotalPRJINV = nvalortotalPRJINV + nvalorcontrol;

    let svalortotalPRJINV = nvalortotalPRJINV.toLocaleString('en-US');
        
    $('#txtvalortotalproyecto_Investigacion_CrearProyecto').val(svalortotalPRJINV);
}