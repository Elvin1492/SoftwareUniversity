function convertKWtoHP(kW) {
    var hP = kW * (1 / 0.746);
    return hP.toFixed(2);
}

console.log(convertKWtoHP(75));
console.log(convertKWtoHP(150));
console.log(convertKWtoHP(1000));