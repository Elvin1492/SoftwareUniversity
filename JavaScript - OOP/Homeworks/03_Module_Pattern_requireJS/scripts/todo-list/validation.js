define(function() {
    'use strict';

    var Validation;

    Validation = (function() {
        // ------------------ NON-EMPTY STRING ------------------------
        function validateNonEmptyString(value, variableName) {
            if (typeof(value) != 'string' || !value) {
                var errorMesage = document.getElementById('section-error-mesage');
                errorMesage.style.display = "block";
                throw new Error(variableName + " should be non-empty ");
            }
        }

        // ------------------ NON EMPTY OBJCT------------------------
        function validateNonEmptyObject(value, className, variableName) {
            if (!(value instanceof className)) {
                throw new Error(variableName + " should be non-empty " +
                    className.prototype.constructor.name + ".");
            }
        }

        return {
        	validateString: validateNonEmptyString,
        	validateObject: validateNonEmptyObject
        };
    }());

    return Validation;
});