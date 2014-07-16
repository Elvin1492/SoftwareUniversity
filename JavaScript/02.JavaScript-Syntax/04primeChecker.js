function isPrime(number) {
    var prime = true;
    var maxDivider = Math.floor(Math.sqrt(number));
    if (number == 1) {
        prime = false;
    } else if (number == 2) {
        prime = true;
    }

    for (var i = 2; i <= maxDivider; i++) {
        if (number % i === 0) {
            prime = false;
        }
    }
    return prime;
}

console.log(isPrime(7));
console.log(isPrime(254));
console.log(isPrime(587));