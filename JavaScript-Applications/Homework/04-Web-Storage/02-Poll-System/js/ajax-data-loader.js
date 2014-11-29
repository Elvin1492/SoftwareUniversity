(function() {
    $(function() {
        var PARSE_APP_ID = "152qZeN8oC9bpWBPTbxD3mIGVcIxwvKhkQQpQwNU ";
        var PARSE_REST_API_KEY = "dMb7pG4rzsuA6yvH3c8iIGhwgKfSdfP7nqXmxJQV";

        loadQuestions();
        loadAnswers();

        function loadQuestions() {
            $.ajax({
                method: "GET",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Question",
                success: drawQuestions,
                error: ajaxError
            });
        }
        // draw qustions on the page
        function drawQuestions(data) {
            for (var q in data.results) {
                var question = data.results[q];
                var questionItem = $('<div>').addClass("well question-items col-md-3");
                questionItem.data('data-id', question.objectId);

                var answersForm = $("<form />").attr({
                    role: 'form',
                    id: question.objectId
                });

                var questioText = $('<h4>').text(question.name);
                
                questionItem.append(questioText);
                questionItem.append(answersForm);

                $("#questions").append(questionItem);
            }
        }

        function loadAnswers() {
            $.ajax({
                method: "GET",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Answer",
                success: [drawAnswers],
                error: ajaxError
            });
        }

        // draw qustions on the page
        function drawAnswers(data) {
            for (var a in data.results) {
                var answer = data.results[a];
                var answerItem = $('<div />');
                answerItem.data('data-id', answer.objectId);
                answerItem.data('points', answer.points);
                answerItem.attr('class', 'radio');
                answerItem.html('<label><input type="radio" name="optradio">' + answer.name + '</label>');


                var questionID = answer.question['objectId'];
                var answersForm = $("#" + questionID);
                answersForm.append(answerItem);
            }
        }
        // noty function for and AJAX request error
        function ajaxError() {
            noty({
                text: 'An error occured.',
                type: 'error',
                layout: 'topCenter',
                timeout: 2000
            });
        }
    });
}());