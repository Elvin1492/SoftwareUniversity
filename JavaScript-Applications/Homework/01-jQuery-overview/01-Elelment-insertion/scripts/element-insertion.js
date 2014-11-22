(function() {
    $(document).ready(function() {
        $('#add-after-button').on('click', function() {
            var text = $('#item-text').val();
            var className = $('#class-name').val();
            var positon = 'after';
            var toElement = '#dynamic-list';
            addElement(text, positon, toElement, className);
        });

        $('#add-before-button').on('click', function() {
            var text = $('#item-text').val();
            var className = $('#class-name').val();
            var positon = 'before';
            var toElement = '#dynamic-list';
            addElement(text, positon, toElement, className);
        });

    });

    function addElement(text, position, toElement, className) {
        var newItem;

        if (/^\s*$/.test(text)) {
            addItemError();
            $('#class-name').val('');
            return;
        }

        switch (position) {
            case 'after':
                newItem = $('<li/>').text(text).appendTo(toElement);
                addItemSuccess();
                break;
            case 'before':
                newItem = $('<li/>').text(text).prependTo(toElement);
                addItemSuccess();
                break;
            default:
                break;
        }

        if (!/^\s*$/.test(className)) {
            newItem.attr('class', className);
        }
        $('#item-text').val('');
        $('#class-name').val('');
    }

    function addItemSuccess() {
        noty({
            text: 'Item addde',
            type: 'success',
            layout: 'topCenter',
            timeout: 1000
        });

    }

    function addItemError() {
        noty({
            text: 'Text can not be empty',
            type: 'error',
            layout: 'topCenter',
            timeout: 1000
        });
    }
}());