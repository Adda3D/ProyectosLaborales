(function(){
    'use strict';
  
    $(document).ready(function(){
  	    //let form = $('.bootstrap-form');
  	    //// On form submit take action, like an AJAX call
        //$(form).submit(function(e){
        //    if(this.checkValidity() == false) {
        //        $(this).addClass('was-validated');
        //        e.preventDefault();
        //        e.stopPropagation();
        //    }
        //});        

        // On every :input focusout validate if empty
        $(':input').blur(function () {
            let fieldType = this.type;
            var idCuenta = this.id;

    	    switch(fieldType){
    	        case 'text':
    	        case 'number':
    		    case 'password':
                case 'textarea':
                    validateText($(this));
                    validateTextXSS($(this));
                    break;
    		    case 'email':
                    validateEmail($(this));
                    break;
    		    case 'checkbox':
    			    validateCheckBox($(this));
    			    break;
    		    case 'select-one':
    			    validateSelectOne($(this));
    			    break;
    		    case 'select-multiple':
    			    validateSelectMultiple($(this));
    			    break;
    		    default:
	    		    break;
    	    }
	    });

	    // On every :input focusin remove existing validation messages if any
        $(':input').click(function(){
    	    $(this).removeClass('is-valid is-invalid');
	    });

        // On every :input focusin remove existing validation messages if any
        $(':input').keydown(function () {
            $(this).removeClass('is-valid is-invalid');
        });

	    // Reset form and remove validation messages
        $(':reset').click(function(){
            $(':input, :checked').removeClass('is-valid is-invalid');
    	    $(form).removeClass('was-validated');
        });
    });

    // Validate Text and password
    function validateText(thisObj) {
        let fieldValue = thisObj.val();
        var spanRequired = thisObj.data('span');
        $("#" + spanRequired).addClass('ocultar');

        if(fieldValue.length > 0) {
            $(thisObj).addClass('is-valid');
            //$("#" + spanRequired).addClass('ocultar');
        } else {
            if (thisObj[0].required) {
                $(thisObj).addClass('is-invalid');
                //$("#" + spanRequired).removeClass('ocultar');
            } else {
                $(thisObj).addClass('is-valid');
                //$("#" + spanRequired).addClass('ocultar');
            }
        }
    }

    // Validate Text
    function validateTextXSS(thisObj) {
        let fieldValue = thisObj.val();
        var spanRequired = thisObj.data('span');
        var pattern = '<>()/*="';
        $(thisObj).removeClass('is-valid_form');
        $(thisObj).removeClass('is-invalid_form');

        for (var i = 0; i < fieldValue.length; i++) {
            var character = fieldValue[i];

            for (var j = 0; j < pattern.length; j++) {
                var patternCharacter = pattern[j];

                if (character == patternCharacter) {
                    $(thisObj).addClass('is-invalid_form');
                    $(thisObj).removeClass('is-valid_form');
                    $("#" + spanRequired).removeClass('ocultar');
                    return;
                } else {
                    $(thisObj).addClass('is-valid_form');
                    $(thisObj).removeClass('is-invalid_form');
                    $("#" + spanRequired).addClass('ocultar');
                }
            }
        }
    }

    // Validate Email
    function validateEmail(thisObj) {
        let fieldValue = thisObj.val();
        let pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
        var spanRequired = thisObj.data('span');

        if(pattern.test(fieldValue)) {
            $(thisObj).addClass('is-valid');
            $("#" + spanRequired).addClass('ocultar');
        } else {
            if (thisObj[0].required) {
                $(thisObj).addClass('is-invalid');
                $("#" + spanRequired).removeClass('ocultar');
            } else {
                $(thisObj).addClass('is-valid');
                $("#" + spanRequired).addClass('ocultar');
            }
        }
    }

    // Validate CheckBox
    function validateCheckBox(thisObj) {
        var spanRequired = thisObj.data('span');

        if($(':checkbox:checked').length > 0) {
            $(thisObj).addClass('is-valid');
            $("#" + spanRequired).addClass('ocultar');
        } else {
            if (thisObj[0].required) {
                $(thisObj).addClass('is-invalid');
                $("#" + spanRequired).removeClass('ocultar');
            } else {
                $(thisObj).addClass('is-valid');
                $("#" + spanRequired).addClass('ocultar');
            }
        }
    }

    // Validate Select One Tag
    function validateSelectOne(thisObj) {
        let fieldValue = thisObj.val();
        var spanRequired = thisObj.data('span');

        if ((fieldValue != "")) {
            if (fieldValue != null) {
                $(thisObj).addClass('is-valid');
                $("#" + spanRequired).addClass('ocultar');
            } else {
                $(thisObj).addClass('is-invalid');
                $("#" + spanRequired).removeClass('ocultar');
            }
        } else {
            if (thisObj[0].required) {
                $(thisObj).addClass('is-invalid');
                $("#" + spanRequired).removeClass('ocultar');
            } else {
                $(thisObj).addClass('is-valid');
                $("#" + spanRequired).addClass('ocultar');
            }
        }        
    }

    // Validate Select Multiple Tag
    function validateSelectMultiple(thisObj) {
        let fieldValue = thisObj.val();
        var spanRequired = thisObj.data('span');
        
        if(fieldValue.length > 0) {
            $(thisObj).addClass('is-valid');
            $("#" + spanRequired).addClass('ocultar');
        } else {
            if (thisObj[0].required) {
                $(thisObj).addClass('is-invalid');
                $("#" + spanRequired).removeClass('ocultar');
            } else {
                $(thisObj).addClass('is-valid');
                $("#" + spanRequired).addClass('ocultar');
            }
        }
    }

})();
