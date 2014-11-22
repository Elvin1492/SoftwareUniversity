(function() {
    var jsonString = [{
        "manufacturer": "BMW",
        "model": "E92 320i",
        "year": 2011,
        "price": 50000,
        "class": "Family"
    }, {
        "manufacturer": "Porsche",
        "model": "Panamera",
        "year": 2012,
        "price": 100000,
        "class": "Sport"
    }, {
        "manufacturer": "Peugeot",
        "model": "305",
        "year": 1978,
        "price": 1000,
        "class": "Family"
    }];

    $(document).ready(function() {
        $("#generate-content").one('click', function() {
            $(jsonString).each(function(index, car) {
                $('#add-rows').append(
                    $('<tr />')
                    .append($('<td />').text(car.manufacturer))
                    .append($('<td />').text(car.model))
                    .append($('<td />').text(car.year))
                    .append($('<td />').text(car.price))
                    .append($('<td />').text(car.class))
                );
            });
        });
    });
}());