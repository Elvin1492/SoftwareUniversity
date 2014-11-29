(function() {
    // on document ready
    $(function() {
        $('#first-time-visit').hide();
        $('#greeting-message').hide();

        // add event listener on button for adding new user
        $('#add-user').on('click', function() {
            var username = $('#username').val();

            if (/^\s*$/.test(username)) {
                addItemError();
                $('#add-user').val('');
                return;
            }
            // get the username, hide the login section and greet the user
            localStorage.setItem('user', username);
            $('#first-time-visit').hide();
            $('#greeting-message').text('Hello ' + username + '!').show();
        });

        // add event listener on button for clearing history
        $('#clear-history').on('click', function() {
            window.localStorage.clear();
            window.sessionStorage.clear();
            location.reload(true);
            $('#greeting-message').hide();
        });

        // chek if the user is visiting the page for the first time and get his name or greet him
        if (!localStorage.getItem('counter')) {
            localStorage.setItem('counter', 0);
            $('#first-time-visit').css('display', 'block').show();
        } else {
            var user = localStorage.getItem('user');
            if (user === null) {
                user = 'unknow user';
            }

            $('#greeting-message').text('Hello ' + user + '!');
            $('#greeting-message').css('display', 'block').show();
        }

        //set the sessions storage counter 
        if (!sessionStorage.getItem('counter')) {
            sessionStorage.setItem('counter', 0);
        }

        // increment total vistits
        var totalCount = parseInt(localStorage.getItem('counter'));
        totalCount++;
        localStorage.setItem('counter', totalCount);
        $('#total-count').text(totalCount);

        // increment session vistits
        var sessionCount = parseInt(sessionStorage.getItem('counter'));
        sessionCount++;
        sessionStorage.setItem('counter', sessionCount);
        $('#session-count').text(sessionCount);

        function addItemError() {
            noty({
                text: 'Text can not be empty',
                type: 'error',
                layout: 'topCenter',
                timeout: 1000
            });
        }
    });
}());