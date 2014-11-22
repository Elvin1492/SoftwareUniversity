(function() {
    var existingClasses = [];

    $(document).ready(function() {
        $('input[type=button]').on('click', function() {
            var classToColor = $('#classpicked').val();
            var color = $('#colorpicked').val();

            changeColor(classToColor, color);
        });
    });

    function changeColor(classToColor, color) {
        $('ul#dynamic-list li').each(function() {
            var className = $(this).attr('class');
            existingClasses.push(className);
        });

        if (/^\s*$/.test(classToColor)) {
            colorItemError();
            return;
        }

        if ($.inArray(classToColor, existingClasses) === -1) {
            classNotFound();
            $('input[type=text]').val('');
            return;
        }
       
        $('.' + classToColor).css('background', color);
        $('input[type=text]').val('');
        colorChangeSuccess();
    }

     function classNotFound() {
        noty({
            text: 'Class not found',
            type: 'error',
            layout: 'topCenter',
            timeout: 1000
        });

    }

    function colorItemError() {
        noty({
            text: 'Choose class to color',
            type: 'warning',
            layout: 'topCenter',
            timeout: 1000
        });
    }

     function colorChangeSuccess() {
        noty({
            text: 'Color changed',
            type: 'success',
            layout: 'topCenter',
            timeout: 1000
        });

    }
}());