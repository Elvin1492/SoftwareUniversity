function sortArray(value) {
    for (var i = 0; i < value.length - 1; i++) {
        for (var j = i + 1; j < value.length; j++) {
            if (value[i] > value[j]) {
                var num = value[i];
                value[i] = value[j];
                value[j] = num;
            }
        }
    }
    var result = value.join(', ');
    return result;
}

console.log(sortArray([5, 4, 3, 2, 1]));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]));