function findMinAndMax(arguments) {
    var result = "";
    arguments.sort(function(a, b) {
        return a - b;
    });
    var minNumber = arguments[0];
    var maxNumber = arguments[arguments.length - 1];
    result = "Min -> " + minNumber + "\n" + "Max -> " + maxNumber + "\n";
    return result;
}

console.log(findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]));
console.log(findMinAndMax([2, 2, 2, 2, 2]));
console.log(findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]));