function findMaxSequence(value) {
    var result = [];
    var currentLength = 1;
    var bestLength = 1;
    var bestEnd = 0;
    var bestStart = 0;
    if (value.length === 1) {
        result.push(value[0]);
    } else {
        for (var i = 1; i < value.length; i++) {
            if (value[i] > value[i - 1]) {
                currentLength++;
            } else {
                currentLength = 1;
            }
            if (currentLength > bestLength) {
                bestLength = currentLength;
                bestStart = i - bestLength + 1;
                bestEnd = i;
            }
        }
    }
    if (bestLength === 1) {
        result = "no";
    } else {
        for (var j = bestStart; j <= bestEnd; j++) {
            result.push(value[j]);
        }
    }
    return result;
}

console.log(findMaxSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]));
console.log(findMaxSequence([3, 2, 1]));