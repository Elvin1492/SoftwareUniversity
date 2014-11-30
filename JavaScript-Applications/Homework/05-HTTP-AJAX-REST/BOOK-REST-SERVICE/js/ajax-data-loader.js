(function() {
    $(function() {
        loadBooks();

        function loadBooks() {
            ajaxRequester.get("https://api.parse.com/1/classes/Book", drawBooks, ajaxError);
        }

        // draw books on the page
        function drawBooks(data) {
            for (var b in data.results) {
                var book = data.results[b];
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
                var $deleteBook = $('<td/>').html('<button type="button" class="btn btn-danger">Delete</button>');
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
        }

        // noty function for an AJAX request error
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