function reverseString(value) {
    var result = "";
    for (var i = value.length - 1; i >= 0; i--) {
        result += value[i];
    }
    return result;
}

console.log(reverseString('sample'));
console.log(reverseString('softUni'));
console.log(reverseString('java script'));