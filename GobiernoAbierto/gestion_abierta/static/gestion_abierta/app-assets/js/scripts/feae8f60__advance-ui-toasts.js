/*
 * Toasts - Advanced UI 
 */

// Basic Toast

$('.toast-basic').on('click', function () {
    M.toast({
        html: 'I am a toast!'
    })
})

// Custom Toast

$('.toast-custom').on('click', function () {
    var toastHTML = '<span>I am toast content</span><button class="btn-flat toast-action">Undo</button>';
    M.toast({
        html: toastHTML
    });
});

// Toast With Callback 

$('.toast-callback').on('click', function () {
    M.toast({
        html: 'I am a toast',
        completeCallback: function () {
            alert('Your toast was dismissed')
        }
    })
});

$('.toast-rounded').on('click', function () {
    M.toast({
        html: 'I am a toast!',
        classes: 'rounded'
    });
})
/*!
* AerWebCopy Engine [version 6.3.0]
* Copyright Aeroson Systems & Co.
* File mirrored from http://www.nostoca.org/gobiernoabierto/app-assets/js/scripts/advance-ui-toasts.js
* At UTC time: 2022-04-19 14:10:28.779747
*/
