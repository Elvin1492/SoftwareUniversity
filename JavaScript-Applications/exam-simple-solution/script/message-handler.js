var messageHandler = (function() {

    var ajaxError = function(error) {
        var errorMessage = error.responseJSON;
        noty({
            text: 'Error: ' + errorMessage.error,
            type: 'error',
            layout: 'center',
            timeout: 1500
        });
    };

    var fillAllDataError = function() {
        noty({
            text: 'Please fill out all input fields.',
            type: 'warning',
            layout: 'center',
            timeout: 1500
        });
    };

    var registerSuccess = function() {
        noty({
            text: 'Registration successfull!',
            type: 'success',
            layout: 'center',
            timeout: 1500
        });
    };

    var deleteSuccess = function(id) {   
        noty({
            text: 'Bookmark deleted successfull!',
            type: 'success',
            layout: 'center',
            timeout: 1500
        });
    };

      var bookmarkdAddedSuccess = function() {   
        noty({
            text: 'Bookmark added successfull!',
            type: 'success',
            layout: 'center',
            timeout: 1500
        });
    };

    return {
        ajaxError: ajaxError,
        fillAllDataError: fillAllDataError,
        registerSuccess: registerSuccess,
        deleteSuccess: deleteSuccess,
        addSuccess: bookmarkdAddedSuccess
    };
}());