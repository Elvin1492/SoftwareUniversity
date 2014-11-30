(function() {
    $(function() {
        $('#delete-book-dialog').hide();
        $('#delete-item-success').hide();

        $('#add-item-error').hide();
        $('#add-item-success').hide();
        $('#new-book-dialog').hide();

        $('#edit-book-dialog').hide();
        $('#edit-item-error').hide();
        $('#edit-item-success').hide();

        // display dialog for adding new book on clciking "add boook" button
        $('#add-book-button').click(function() {
            $('#add-item-success').hide();
            $('#delete-item-success').hide();
            $('#edit-item-success').hide();

            $('#new-book-dialog').css({
                position: 'fixed',
                top: '20%',
                left: '30%'
            }).show();
        });

        // process data on submiting new book
        $('#submit-new-book').click(function() {
            var $newBookTitle = $('#inputTitle').val();
            var $newBookAuthor = $('#inputAuthor').val();
            var $newBookISDN = $('#inputISDN').val();

            // check if input is not empty or whitespacess string
            if (/^\s*$/.test($newBookTitle) || /^\s*$/.test($newBookAuthor) || /^\s*$/.test($newBookISDN)) {
                $('#add-item-error').css({
                    positon: 'fixed',
                    top: '0%',
                    lett: '40%'
                }).show();

                return;
            }

            var data = {
                'title': $newBookTitle,
                'author': $newBookAuthor,
                'isbn': $newBookISDN,
            };

            ajaxRequester.post("https://api.parse.com/1/classes/Book", data,
                itemAddedSuccess($newBookTitle), ajaxError);

            $('#inputTitle').val('');
            $('#inputAuthor').val('');
            $('#inputISDN').val('');
        });

        // process data on deleting a book 
        $('#delete-book').click(function() {
            var bookID = $(this).parents('.col-md-3').data('book-id');
            $('#delete-book-dialog').hide();

            ajaxRequester.delete("https://api.parse.com/1/classes/Book/" + bookID,
                itemDeletedSuccessfuly, ajaxError);

            $('#' + bookID).empty();
        });

        // process data on editing  book
        $('#edit-new-book').click(function() {
            var bookID = $(this).parents('.col-md-4').data('book-id');

            var $editBookTitle = $('#editTitle').val();
            var $editBookAuthor = $('#editAuthor').val();
            var $editBookISDN = $('#editISDN').val();

            // check if input is not empty or whitespacess string
            if (/^\s*$/.test($editBookTitle) || /^\s*$/.test($editBookAuthor) || /^\s*$/.test($editBookISDN)) {
                $('#edit-item-error').css({
                    positon: 'fixed',
                    top: '0%',
                    lett: '40%'
                }).show();

                return;
            }

            var data = {
                'title': $editBookTitle,
                'author': $editBookAuthor,
                'isbn': $editBookISDN,
            };

            ajaxRequester.put("https://api.parse.com/1/classes/Book/" + bookID, data,
                itemEditedSuccess, ajaxError);

            // add functionality for editing books on newly added book
                var $editBookLink = $('<a/>').text($editBookTitle);
                $editBookLink.attr('href', '#');
                $editBookLink.data('book-id', bookID);
                $editBookLink.data('book-title', $editBookTitle);
                $editBookLink.data('book-author', $editBookAuthor);
                $editBookLink.data('book-isdn', $editBookISDN);
                $editBookLink.click(function() {                   
                    var bookID = $(this).data('book-id');
                    var bookTitle = $(this).data('book-title');
                    var bookAuthor = $(this).data('book-author');
                    var bookISDN = $(this).data('book-isdn');

                    $('#edit-book-dialog').css({
                        position: 'fixed',
                        top: '20%',
                        left: '35%'
                    }).show();

                    $('#editTitle').val(bookTitle);
                    $('#editAuthor').val(bookAuthor);
                    $('#editISDN').val(bookISDN);
                    
                    $('#edit-item-success').hide();
                    $('#delete-item-success').hide();
                    $('#add-item-success').hide();
                    $('#edit-book-dialog').data('book-id', bookID);
                });

            $('#' + bookID + ' td:nth-child(1)').html($editBookLink);
            $('#' + bookID + ' td:nth-child(2)').text($editBookAuthor);
            $('#' + bookID + ' td:nth-child(3)').text($editBookISDN);

            $('#editTitle').val('');
            $('#editAuthor').val('');
            $('#editISDN').val('');
        });

        function addNewBook(data) {
            // display success message
            $('#add-item-success').css({
                positon: 'fixed',
                top: '0%',
                lett: '40%'
            }).show();

            var book = data.results[0];
            var bookItem = $('<tr />');
            bookItem.attr('id', book.objectId);

            // add functionality for editing books
            var $editBookLink = $('<a/>').text(book.title);
            $editBookLink.attr('href', '#');
            $editBookLink.data('book-id', book.objectId);
            $editBookLink.data('book-title', book.title);
            $editBookLink.data('book-author', book.author);
            $editBookLink.data('book-isdn', book.isbn);
            $editBookLink.click(function() {
                var bookID = $(this).data('book-id');
                var bookTitle = $(this).data('book-title');
                var bookAuthor = $(this).data('book-author');
                var bookISDN = $(this).data('book-isdn');

                $('#edit-book-dialog').css({
                    position: 'fixed',
                    top: '20%',
                    left: '35%'
                }).show();

                $('#editTitle').val(bookTitle);
                $('#editAuthor').val(bookAuthor);
                $('#editISDN').val(bookISDN);

                $('#edit-item-success').hide();
                $('#delete-item-success').hide();
                $('#add-item-success').hide();
                $('#edit-book-dialog').data('book-id', bookID);
            });

            var bookTitle = $('<td />').append($editBookLink);
            var bookAuthor = $('<td />').text(book.author);
            var bookISBN = $('<td />').text(book.isbn);

            // add functionality for deleting books
            var $deleteBook = $('<td/>').html('<a href="#" class="btn btn-danger">Delete</a>');
            $deleteBook.attr('class', 'delete-book-button');
            $deleteBook.data('book-id', book.objectId);
            $deleteBook.click(function() {
                var bookID = $(this).data('book-id');
                $('#delete-book-dialog').css({
                    position: 'fixed',
                    top: '20%',
                    left: '35%'
                }).show();

                $('#edit-item-success').hide();
                $('#delete-item-success').hide();
                $('#add-item-success').hide();
                $('#delete-book-dialog').data('book-id', bookID);
            });

            bookItem.append(bookTitle);
            bookItem.append(bookAuthor);
            bookItem.append(bookISBN);
            bookItem.append($deleteBook);

            $("#books-list").append(bookItem);
        }

        function itemAddedSuccess(newBookTitle) {
            $('#add-item-error').hide();
            $('#new-book-dialog').hide();

            ajaxRequester.get('https://api.parse.com/1/classes/Book?where={"title":"' + newBookTitle + '"}', addNewBook, ajaxError);
        }

        function itemEditedSuccess() {
            $('#edit-book-dialog').hide();
            $('#add-item-success').hide();
            $('#delete-item-success').hide();
            $('#edit-item-success').show();
        }

        function itemDeletedSuccessfuly() {
            $('#add-item-success').hide();
            $('#edit-item-success').hide();
            $('#delete-item-success').show();
        }

        // hide dialog on cancel button click (for adding new book)
        $('#close-dialog').click(function() {
            $('#new-book-dialog').hide();
            $('#add-item-error').hide();
        });

        // hide dialog on cancel button click (for editing a book)
        $('#close-edit-dialog').click(function() {
            $('#edit-book-dialog').hide();
            $('#edit-item-error').hide();
        });

        // hide dialog on cancel button click (for deleting a book)
        $('#cancel-delete').click(function() {
            $('#delete-book-dialog').hide();
            $('#add-item-error').hide();
        });

        // hide alert windows
        $('.close-window').click(function() {
            $('#add-item-error').css('display', 'none');
            $('#add-item-success').css('display', 'none');
            $('#delete-item-success').css('display', 'none');
            $('#edit-item-success').css('display', 'none');
        });

        function ajaxError() {
            alert('Something went wrong!');
        }
    });
}());