function findMaxSequence(value) {
    var result = [];
    var currentLength = 1;
    var bestLength = 1;
    var currentStart = 0;
    var bestStart = 0;
    if (value.length === 1) {
        result.push(value[0]);
    } else {
        for (var i = 1; i < value.length; i++) {
            if (value[i] === value[i - 1] && typeof(value[i] === typeof(value[i - 1]))) {
                currentLength++;
                currentStart = i - 1;
            } else {
                currentLength = 1;
                currentStart = 0;
            }
            if (currentLength >= bestLength) {
                bestLength = currentLength;
                bestStart = currentStart;
            }
        }
        for (var j = bestStart - 1; j < bestStart + bestLength - 1; j++) {
            result.push(value[bestStart]);
        }
    }
    return result;
}

console.log(findMaxSequence(['happy']));
console.log(findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]));
console.log(findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']));
console.log(findMaxSequence([1, 1, 2, 2, 2, 3, 3, 3]));