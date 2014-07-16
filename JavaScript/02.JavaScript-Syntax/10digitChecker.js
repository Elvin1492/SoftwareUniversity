/* using strings*/
function checkDigit(number) {
    var digitIs3 = false;
    var numberAsString = number.toString();
    var position = numberAsString.length - 3;
    if (numberAsString[position] === "3") {
        digitIs3 = true;
    }
    return digitIs3;
}

console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));

/* using arithmetics*/

function checkDigitBeta(num) {
    var digitIs3beta = false;
    var thirdDigit = Math.floor(num / 100) % 10;
    if (thirdDigit === 3) {
        digitIs3beta = true;
    }
    return digitIs3beta;
}

console.log(checkDigitBeta(1235));
console.log(checkDigitBeta(25368));
console.log(checkDigitBeta(123456));