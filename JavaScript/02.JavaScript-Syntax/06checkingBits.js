function bitChecker(number) {
    var bitIs1 = false;
    var mask = number >> 3;
    var bit3 = mask & 1;
    if (bit3 === 1) {
        bitIs1 = true;
    }
    return bitIs1;
}

console.log(bitChecker(333));
console.log(bitChecker(425));
console.log(bitChecker(2567564754));