function inicio(obj1,obj2,obj3,acc,div,pag){
        var parametros = {
                "obj1" : obj1, "obj2" : obj2, "obj3" : obj3, "acc" : acc, "div" : div               
        };
        $.ajax({
                data:  parametros,
                url:   pag,
                type:  'post',
                beforeSend: function () {
                        $(div).html("Procesando, espere por favor...");
                },
                success:  function (response) {
                        $(div).html(response);
                }
        });
		
}

var es_firefox = navigator.userAgent.toLowerCase().indexOf('firefox') > -1;

 $(".close").click(function() {
  $("#secBuscar").css("display","none");
});
$("#btnBuscar").click(function() {
  $("#secBuscar").css("display","block");
});
/*!
* AerWebCopy Engine [version 6.3.0]
* Copyright Aeroson Systems & Co.
* File mirrored from https://nostoca.org/gobiernoabierto/assets/js/script.js
* At UTC time: 2022-04-19 12:46:02.629339
*/
