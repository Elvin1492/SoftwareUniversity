(function() {
    $(function() {
        // chek if the user has already ansswered any questons and check the answers for him
        // if (localStorage.length !== 0) {
        //     for (var i = 0; i < localStorage.length; i++) {
        //         alert('success');
        //         console.log(localStorage.key(i));
        //     }
        // }

        // collect checked answers in local storage to relod them if the uer escapes by misktake
        // $('input[name="optradio"]').click(function() {
        //     if ($(this).is(':checked')) {
        //         var answer = $(this).closest('.radio').data('data-id');
        //         var question = $(this).closest('.well').data('data-id');
        //         loacalStorage.setItem(question, answer);
        //         console.log(answer.text);
        //     }

        // });

        $('#submit-button').on('click', function() {
            if ($(':checked').length != 4) {
                submitError();
                return;
            }

            window.localStorage.clear();
            var totalScore = 0;
            $(':checked').each(function() {
                // calculate the total score 
                var score = parseInt($(this).closest('.radio').data('points'));
                var answer = $(this).closest('.radio').data('data-id');
                // save the answer and its score in the local storage for showing the users mistkaes
                localStorage.setItem(answer, score);
                totalScore += score;
                $(this).prop('checked', false);
                console.log(answer);
            });

            drawResult(totalScore);
            $('#result-div').show();
            // window.localStorage.clear();
        });

        // draw the result and show the user his mistkaes
        function drawResult(totalScore) {
            if (localStorage.length !== 0) {
                for (var key in localStorage) {
                  console.log(localStorage[key]);
                }
            }

            $('#result').text('You scored:' + totalScore);
             window.localStorage.clear();
        }

        // noty function for an invalid answer submit
        function submitError() {
            noty({
                text: 'Please fill out all questions before submitting!',
                type: 'error',
                layout: 'topCenter',
                timeout: 2000
            });
        }
    });
}());