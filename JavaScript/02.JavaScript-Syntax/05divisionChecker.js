/* using strings*/
function divisionBy3(number) {
    var numberAsString = number.toString();
    var sum = 0;
    for (var i = 0; i < numberAsString.length; i++) {
        var digit = Number(numberAsString[i]);
        sum += digit;
    }
    if (sum % 3 === 0) {
        return "the number is divided by 3 without remainder";
    } else {
        return "the number is not divided by 3 without remainder";
    }
}

console.log(divisionBy3(12));
console.log(divisionBy3(13));
console.log(divisionBy3(591));

