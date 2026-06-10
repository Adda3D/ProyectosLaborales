// Valida el select2 cuando hace el evento Blur 
function validateSelectOneSelect2() {
    var selects = $('select');
    var idSelect;
    var spanRequired;

    $('select').next('.select2').find('.select2-selection').on('blur', function () {
        var itemSelected = $(this)[0].innerText;
        var idSpan = $(this)[0].childNodes[0].id;
        var Required = false;

        for (var i = 0; i < selects.length; i++) {
            var idSpan2 = "select2-" + selects[i].id + "-container";

            if (idSpan == idSpan2) {
                if (selects[i].required) {
                    idSelect = selects[i].id;
                    spanRequired = $("#" + idSelect).data('span');
                    Required = true;
                    break;
                }
            }
        }

        if (Required) {
            let fieldValue = itemSelected;
            
            if ((fieldValue != "Seleccione")) {
                if (fieldValue != null) {
                    $('span[aria-labelledby="' + idSpan + '"]').removeClass("is-invalid_form");
                    $('span[aria-labelledby="' + idSpan + '"]').addClass("is-valid_form");

                    $("#" + spanRequired).addClass('ocultar');
                } else {
                    $('span[aria-labelledby="' + idSpan + '"]').addClass("is-invalid_form");
                    $('span[aria-labelledby="' + idSpan + '"]').removeClass("is-valid_form");

                    $("#" + spanRequired).removeClass('ocultar');
                }
            } else {
                $('span[aria-labelledby="' + idSpan + '"]').addClass("is-invalid_form");
                $('span[aria-labelledby="' + idSpan + '"]').removeClass("is-valid_form");

                $("#" + spanRequired).removeClass('ocultar');
            }
        } else {
            $('span[aria-labelledby="' + idSpan + '"]').removeClass("is-invalid_form");
            $('span[aria-labelledby="' + idSpan + '"]').addClass("is-valid_form");
        }
    });
}

// Valida el select2 cuando hace click al boton guardar 
function validateSelectOneSelect2LastButton() {
    checkValiditySelect = true;
    //var selectsObligatorios = $('select[required]');
    var selects = $('select');
    var spanRequired;

    for (var i = 0; i < selects.length; i++) {
        var idSpan = selects[i].id;
        let fieldValue = selects[i].value;

        if (selects[i].required) {
            spanRequired = $("#" + idSpan).data('span');

            if ((fieldValue != "")) {
                if (fieldValue != null) {
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-invalid_form");
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-valid_form");

                    $("#" + spanRequired).addClass('ocultar');
                } else {
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-invalid_form");
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-valid_form");

                    $("#" + spanRequired).removeClass('ocultar');

                    checkValiditySelect = false;
                }
            } else {
                $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-invalid_form");
                $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-valid_form");

                $("#" + spanRequired).removeClass('ocultar');

                checkValiditySelect = false;
            }
        } else {
            $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-invalid_form");
            $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-valid_form");
        }
    }
}

function validateSelectOneSelect2LastButtonByForm(formulario) {
    checkValiditySelect = true;
    //var selectsObligatorios = $('select[required]');
    var selects = $('form#' + formulario + ' select');
    var spanRequired;

    for (var i = 0; i < selects.length; i++) {
        var idSpan = selects[i].id;
        let fieldValue = selects[i].value;

        if (selects[i].required) {
            spanRequired = $("#" + idSpan).data('span');

            if ((fieldValue != "")) {
                if (fieldValue != null) {
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-invalid_form");
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-valid_form");

                    $("#" + spanRequired).addClass('ocultar');
                } else {
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-invalid_form");
                    $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-valid_form");

                    $("#" + spanRequired).removeClass('ocultar');

                    checkValiditySelect = false;
                }
            } else {
                $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-invalid_form");
                $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-valid_form");

                $("#" + spanRequired).removeClass('ocultar');

                checkValiditySelect = false;
            }
        } else {
            $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-invalid_form");
            $('span[aria-labelledby="select2-' + idSpan + '-container"]').addClass("is-valid_form");
        }
    }
}

// Elimina las clases de validacion cuando da clic en boton Cancelar o Guardar
function removeValidationForm() {
    $(':input, :checked').removeClass('is-valid is-invalid');
    $(':input, :checked').removeClass('is-valid_form is-invalid_form');
    $(form).removeClass('was-validated');

    $('div.color-required').addClass('ocultar');

    var selects = $('select');

    for (var i = 0; i < selects.length; i++) {
        var idSpan = selects[i].id;

        $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-invalid_form is-valid_form");
    }
}

function removeValidationFormByForm(formulario) {
    var formEC = $("#" + formulario);
    $('form#' + formulario + ' :input, :checked').removeClass('is-valid is-invalid');
    $('form#' + formulario + ' :input, :checked').removeClass('is-valid_form is-invalid_form');
    $(formEC).removeClass('was-validated');

    $('div.color-required').addClass('ocultar');

    var selects = $('form#' + formulario + ' select');

    for (var i = 0; i < selects.length; i++) {
        var idSpan = selects[i].id;

        $('span[aria-labelledby="select2-' + idSpan + '-container"]').removeClass("is-invalid_form is-valid_form");
    }
}

// Validate TextXSS cuando hace click al boton guardar 
function validateTextXSSLastButton() {
    checkValidityXSS = true;
    var inputText = $('input:text, textarea');
    var spanRequired;
    var pattern = '<>()/*="';

    for (var k = 0; k < inputText.length; k++) {
        $(inputText[k]).removeClass('is-valid_form');
        $(inputText[k]).removeClass('is-invalid_form');

        var idSpan = inputText[k].id;
        let fieldValue = inputText[k].value;

        if (idSpan != '') {
            spanRequired = $("#" + idSpan).data('span');

            if (spanRequired != undefined) {
                for (var i = 0; i < fieldValue.length; i++) {
                    var character = fieldValue[i];

                    for (var j = 0; j < pattern.length; j++) {
                        var patternCharacter = pattern[j];

                        if (character == patternCharacter) {
                            $(inputText[k]).addClass('is-invalid_form');
                            $(inputText[k]).removeClass('is-valid_form');
                            $("#" + spanRequired).removeClass('ocultar');
                            checkValidityXSS = false;
                            return;
                        } else {
                            $(inputText[k]).addClass('is-valid_form');
                            $(inputText[k]).removeClass('is-invalid_form');
                            $("#" + spanRequired).addClass('ocultar');
                        }
                    }
                }
            }
        }
    }
}

function validateTextXSSLastButtonByForm(formulario) {
    checkValidityXSS = true;
    var inputText = $('form#' + formulario + ' input:text, textarea');
    var spanRequired;
    var pattern = '<>()/*="';

    for (var k = 0; k < inputText.length; k++) {
        $(inputText[k]).removeClass('is-valid_form');
        $(inputText[k]).removeClass('is-invalid_form');

        var idSpan = inputText[k].id;
        let fieldValue = inputText[k].value;        

        if (idSpan != '') {
            spanRequired = $("#" + idSpan).data('span');

            if (spanRequired != undefined) {
                for (var i = 0; i < fieldValue.length; i++) {
                    var character = fieldValue[i];

                    for (var j = 0; j < pattern.length; j++) {
                        var patternCharacter = pattern[j];

                        if (character == patternCharacter) {
                            $(inputText[k]).addClass('is-invalid_form');
                            $(inputText[k]).removeClass('is-valid_form');
                            $("#" + spanRequired).removeClass('ocultar');
                            checkValidityXSS = false;
                            return;
                        } else {
                            $(inputText[k]).addClass('is-valid_form');
                            $(inputText[k]).removeClass('is-invalid_form');
                            $("#" + spanRequired).addClass('ocultar');
                        }
                    }
                }
            }
        }        
    }
}