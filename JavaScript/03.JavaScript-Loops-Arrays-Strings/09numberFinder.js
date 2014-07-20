function findMostFreqNum(value) {
    var result = "";
    value.sort(function(a, b) {
        return a - b;
    });
    var currentLength = 1;
    var bestLength = 1;
    var elementPosition = 0;
    if (value.length === 1) {
        result = value[0] + " (1 time)";
    } else {
        for (var i = 1; i < value.length; i++) {
            if (value[i] === value[i - 1]) {
                currentLength++;
            } else {
                currentLength = 1;
            }
            if (currentLength > bestLength) {
                bestLength = currentLength;
                elementPosition = i;
            }
        }
        result = value[elementPosition] + " (" + bestLength + " times)";
    }
    return result;
}

console.log(findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]));
console.log(findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]));
console.log(findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]));