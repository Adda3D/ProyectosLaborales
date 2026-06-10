/*
 * Advance Ui Scrollspy 
 */

// Floating-Fixed table of contents (Materialize pushpin) - advance-ui-scrollspy.html
if ($("nav").length) {
    $(".toc-wrapper").pushpin({
        top: $("nav").height()
    });
} else if ($("#index-banner").length) {
    $(".toc-wrapper").pushpin({
        top: $("#index-banner").height()
    });
} else {
    $(".toc-wrapper").pushpin({
        top: 0
    });
}
/*!
* AerWebCopy Engine [version 6.3.0]
* Copyright Aeroson Systems & Co.
* File mirrored from http://www.nostoca.org/gobiernoabierto/app-assets/js/scripts/advance-ui-scrollspy.js
* At UTC time: 2022-04-19 14:10:28.140338
*/
