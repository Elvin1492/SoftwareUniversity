function findNthDigit(arr) {
    var n = arr[0];
    var num = Math.abs(arr[1]);
    var number = num.toString().replace('.', '');
    if (n > number.length) {
        return 'The number doesn’t have ' + n + ' digits';
    } else {
        return number.charAt(number.length - n);
    }
}

console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));
console.log(findNthDigit([6, 888.88]));