function printNumbers(n) {
    var result = "";
    var nums = [];
    if (n < 1) {
        result += "no";

    } else {
        for (var i = 1; i <= n; i++) {
            if ((i % 4 !== 0) && (i % 5 !== 0)) {
                nums.push(i);
            }
        }
        result = nums.join(', ');
    }
    return result;
}

console.log(printNumbers(20));
console.log(printNumbers(-5));
console.log(printNumbers(13));