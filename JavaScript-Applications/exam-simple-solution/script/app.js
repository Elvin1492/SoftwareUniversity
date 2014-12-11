(function() {
    $(function() {
        // check if user is currently logged in
        var currentUser = userSession.getCurrentUser();
        if (currentUser) {
            showBookmarksView();
        } else {
            showHomePage();
        }

        // retur user to loginpage on click login button on register page
        $('#back-to-login').click(function() {
            $('#login-div').show();
            $('#register-div').hide();
        });

        // add eventhanler on logout button
        $('#logout-button').click(function() {
            userSession.logout();
            showHomePage();
        });

        //nabigat user to registration page on clicking register button
        $('#register-button').click(function() {
            $('#register-div').show();
            $('#login-div').hide();
        });

        //add event handler on sbmit registration button clicked
        $('#submit-registration').click(function() {
            var username = $('#register-username').val();
            var password = $('#register-password').val();

            //chekc if inputs are empty string or whitespace and warn user
            if (/^\s*$/.test(username) || /^\s*$/.test(password)) {
                messageHandler.fillAllDataError();
                return;
            }

            var data = {
                "username": username,
                "password": password,
            };

            ajaxRequester.post(' https://api.parse.com/1/users', data, registerSuccess, ajaxError);

            $('#register-username').val('');
            $('#register-password').val('');
        });

        //add event handler on login button
        $('#login-button').click(function() {
            var username = $('#login-username').val();
            var password = $('#login-password').val();

            //chekc if inputs are empty string or whitespace and warn user
            if (/^\s*$/.test(username) || /^\s*$/.test(password)) {
                messageHandler.fillAllDataError();
                return;
            }

            ajaxRequester.get('https://api.parse.com/1/login?username=' + username + '&password=' + password,
                loginSuccess, ajaxError);

            $('#login-username').val('');
            $('#login-password').val('');
        });

        // load user page with his bookmarks
        function showBookmarksView() {
            var currentUser = userSession.getCurrentUser();
            if (currentUser) {
                var username = currentUser.username;
                var sessionToken = currentUser.sessionToken;

                $('#bookmarks-view').show();
                $('#bookmarks-holder').empty();
                $('#new-bookmark-div').show();
                $('#greet-user').text('Bookkmarks - ' + username);
                $('#logout-button').show();
                $('.login-register').hide();

                ajaxRequester.getSession(sessionToken, 'https://api.parse.com/1/classes/Bookmark',
                    loadBookmarks, ajaxError);

                $('#bookmarks-holder').show();
            } else {
                showHomePage();
            }
        }

        // laod bookmarks from database
        function loadBookmarks(data) {
            for (var b in data.results) {
                var bookmark = data.results[b];
                var bookmarkTitle = bookmark.title;
                var bookmarkUrl = bookmark.url;
                var bookmarkId = bookmark.objectId;

                var $bookmark = createBookmark(bookmarkTitle, bookmarkUrl, bookmarkId);

                $('#bookmarks-holder').append($bookmark);
            }
        }

        // function for creating a bookmark
        function createBookmark(title, url, id) {
            var $bookmarkDiv = $('<div />').attr('boomkark-id', id).attr('class', "bookmark-div");
            var bookmarkTitle = $('<h4 />').text(title);
            var bookmarkUrl = $('<a />').text(url).attr({
                href: url,
                target: '_blank'
            });
            var deleteButton = $('<input type="button" value="X">').attr('class', 'delete-bookmark-button');

            //add eventhandler on delete
            deleteButton.click(function() {
                var sessionToken = currentUser.sessionToken;
                noty({
                    text: "Delete this bookmark?",
                    type: 'confirm',
                    layout: 'topCenter',
                    buttons: [{
                        text: "Yes",
                        onClick: function($noty) {
                            ajaxRequester.deleteSession(sessionToken, 'https://api.parse.com/1/classes/Bookmark/' + id,
                                deleteBookmarkSuccess(id), ajaxError);
                            $noty.close();
                        }
                    }, {
                        text: "Cancel",
                        onClick: function($noty) {
                            $noty.close();
                        }
                    }]
                });
            });

            $bookmarkDiv.append(bookmarkTitle);
            $bookmarkDiv.append(bookmarkUrl);
            $bookmarkDiv.append(deleteButton);

            return $bookmarkDiv;
        }

        // laod home page with login/register
        function showHomePage() {
            $('#greet-user').text('Bookmarks');
            $('#logout-button').hide();
            $('#login-div').show();
            $('#register-div').hide();
            $('#bookmarks-view').hide();
        }

        // add eventhandler on submit button for adding new bookmark
        $('#submit-bookmark').click(function() {
            var bookmarkTitle = $('#bookmark-title').val();
            var bookmarkUrl = $('#bookmark-url').val();

            var sessionToken = currentUser.sessionToken;
            var userObjectID = currentUser.objectId;

            //chekc if input is empty string or whitespace and warn user
            if (/^\s*$/.test(bookmarkTitle) || /^\s*$/.test(bookmarkUrl)) {
                messageHandler.fillAllDataError();
                return;
            }

            var bookmark = {
                "title": bookmarkTitle,
                "url": bookmarkUrl,
                "ACL": {}
            };

            bookmark.ACL[userObjectID] = {
                "write": true,
                "read": true
            };

            ajaxRequester.postSession(sessionToken, 'https://api.parse.com/1/classes/Bookmark',
                bookmark, bookmarkAddSuccess, ajaxError);

            $('#bookmark-title').val('');
            $('#bookmark-url').val('');
        });

        function registerSuccess(data) {
            $('#login-div').show();
            $('#register-div').hide();
            messageHandler.registerSuccess();
        }

        function loginSuccess(data) {
            //get the session token
            userSession.login(data);
            showBookmarksView();
        }

        function deleteBookmarkSuccess(id) {
            $("div").find("[boomkark-id='" + id + "']").remove();
            messageHandler.deleteSuccess();
        }

        function bookmarkAddSuccess(data) {
            messageHandler.addSuccess();

            var sessionToken = currentUser.sessionToken;
            var objectId = data.objectId;
            ajaxRequester.getSession(sessionToken, 'https://api.parse.com/1/classes/Bookmark/' + objectId,
                getNewBookmarkSucces, ajaxError);
        } 

        function getNewBookmarkSucces(data){
           var $newBoookMark = createBookmark(data.title, data.url, data.objectId);
            $('#bookmarks-holder').prepend($newBoookMark);

        }

        function ajaxError(error) {
            messageHandler.ajaxError(error);
        }

    });
})();