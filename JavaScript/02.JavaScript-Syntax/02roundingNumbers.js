function roundNumber(number) {
    var round = Math.round(number);
    var floor = Math.floor(number);
    return (floor + "\n" + round);

}

console.log(roundNumber(22.7));
console.log(roundNumber(12.3));
console.log(roundNumber(58.7));