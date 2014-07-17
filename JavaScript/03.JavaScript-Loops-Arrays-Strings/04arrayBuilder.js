function createArray(arguments) {
    var result = "";
    var myArray = new Array(20);
    for (var i = 0; i < 20; i++) {
        myArray[i] = arguments[i] * 5;
    }
    result = myArray.join(', ');
    return result;
}

console.log(createArray([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]));