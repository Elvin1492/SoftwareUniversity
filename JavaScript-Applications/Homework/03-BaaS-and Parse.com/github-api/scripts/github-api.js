(function() {
    'use strict';
    $(function() {
        $.get('https://api.github.com/users/borislavml')
            .success(function(responce) {
                var $userInfo = proccessUserInfo(responce);
                $('#wrapper').html($userInfo);
            });
    });

    function proccessUserInfo(responce) {
        var $userInfo = $('<ul/>');
        for (var prop in responce) {
            var $currentProp = $('<li/>').html(prop + ': ' + responce[prop]);
            $userInfo.append($currentProp);
        }
        return $userInfo;
    }
}());