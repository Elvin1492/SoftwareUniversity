function calcSupply(age, maxAge, foodPerDay) {
    var foodSupply = Math.round((maxAge - age) * (365 * foodPerDay));
    return foodSupply + "kg of bananas would be enough until I am " + maxAge + " years old.";
}

console.log(calcSupply(38, 118, 0.5));
console.log(calcSupply(20, 87, 2));
console.log(calcSupply(16, 102, 1.1));