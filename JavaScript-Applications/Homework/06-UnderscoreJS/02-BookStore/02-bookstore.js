(function() {
    //check if running on Node.js
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('../node_modules/underscore/underscore.js');
    }

    var books = [{
        "book": "The Grapes of Wrath",
        "author": "John Steinbeck",
        "price": "34,24",
        "language": "French"
    }, {
        "book": "The Great Gatsby",
        "author": "F. Scott Fitzgerald",
        "price": "39,26",
        "language": "English"
    }, {
        "book": "Nineteen Eighty-Four",
        "author": "George Orwell",
        "price": "15,39",
        "language": "English"
    }, {
        "book": "Ulysses",
        "author": "James Joyce",
        "price": "23,26",
        "language": "German"
    }, {
        "book": "Lolita",
        "author": "Vladimir Nabokov",
        "price": "14,19",
        "language": "German"
    }, {
        "book": "Catch-22",
        "author": "Joseph Heller",
        "price": "47,89",
        "language": "German"
    }, {
        "book": "The Catcher in the Rye",
        "author": "J. D. Salinger",
        "price": "25,16",
        "language": "English"
    }, {
        "book": "Beloved",
        "author": "Toni Morrison",
        "price": "48,61",
        "language": "French"
    }, {
        "book": "Of Mice and Men",
        "author": "John Steinbeck",
        "price": "29,81",
        "language": "Bulgarian"
    }, {
        "book": "Animal Farm",
        "author": "George Orwell",
        "price": "38,42",
        "language": "English"
    }, {
        "book": "Finnegans Wake",
        "author": "James Joyce",
        "price": "29,59",
        "language": "English"
    }, {
        "book": "The Grapes of Wrath",
        "author": "John Steinbeck",
        "price": "42,94",
        "language": "English"
    }];

    // •	Group all books by language and sort them by author 
    // (if two books have the same author, sort by price)

    var groupedByLanguageSortByAuthor = _.chain(books)
        .sortBy(function(b) {
            return b.author + '_' + b.price;
        })
        .groupBy('language')
        .value();

    console.log(groupedByLanguageSortByAuthor);
    console.log('----------------------------------');

    var booksInGermanAndEnglishWithPriceBelow30GroupedByAuthor = _.chain(books)
        .filter(function(b) {
            return (b.language === 'English' || b.language === 'German') && parseFloat(b.price) < 30;
        })
        .groupBy('author')
        .value();

    console.log(booksInGermanAndEnglishWithPriceBelow30GroupedByAuthor);
    console.log('----------------------------------');

    var authorsBookPrice = {};

    _.each(books, function(b) {
        var price = parseFloat(b.price.replace(/,/g, '.'));
        var author = b.author;
        if (!authorsBookPrice[author]) {
            authorsBookPrice[b.author] = {
                'booksCount': 0,
                'totalPrice': 0
            };
        }

        authorsBookPrice[b.author]['totalPrice'] += price;
        authorsBookPrice[b.author]['booksCount'] += 1;
    });

    for (var author in authorsBookPrice) {
     var averagePrice = authorsBookPrice[author]['totalPrice']/authorsBookPrice[author]['booksCount'];
      console.log ( author +  ', Average books price: ' +  averagePrice.toFixed(2));
    }

}());