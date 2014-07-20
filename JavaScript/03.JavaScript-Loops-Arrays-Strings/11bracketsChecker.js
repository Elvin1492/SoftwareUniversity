function checkBrackets(value) {
    var result = "";
    var openBracketsCount = 0;
    var closingBracketsCount = 0;
    for (var i = 0; i < value.length; i++) {
        if (value.charAt(i) === '(') {
            openBracketsCount++;
        } else if (value.charAt(i) === ')') {
            closingBracketsCount++;
        }
    }
    if (openBracketsCount === closingBracketsCount) {
        result = "correct";
    } else {
        result = "incorrect";
    }
    return result;
}

console.log(checkBrackets('( ( a + b ) / 5 – d )'));
console.log(checkBrackets(') ( a + b ) )'));
console.log(checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'));