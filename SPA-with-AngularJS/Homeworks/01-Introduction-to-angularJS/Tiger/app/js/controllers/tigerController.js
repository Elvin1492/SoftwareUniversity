app.controller('tigerController', function($scope) {

    var tiger = {
        'Name': 'Pesho',
        'Born': 'Asia',
        'BirthDate': 2006,
        'Live': 'Sofia Zoo',

    };

    tiger.image = 'http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg';
    $scope.tiger = tiger;

    $scope.wrapper = 'wrapper';
    $scope.tigerInfo = 'tigerInfo';
    $scope.image = 'image';
});