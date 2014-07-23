function findLargestBySumOfDigits(nums) {
    var integers = [];
    var maxSum = 0;
    var maxInt = 0;
    if (nums.length === 0) {
        return undefined;
    }
    for (var i = 0; i < nums.length; i++) {
        if (typeof(nums[i]) === 'number' && nums[i] % 1 === 0) {
            integers.push(nums[i]);
        } else {
            return undefined;
        }
    }
    for (var j = 0; j < nums.length; j++) {
        var currentInt = Math.abs(nums[j]).toString();
        var sum = 0;
        for (var l = 0; l < currentInt.length; l++) {
            sum += Number(currentInt[l]);
        }
        if (sum > maxSum) {
            maxSum = sum;
            maxInt = nums[j];
        }
    }
    return maxInt;
}

console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));
console.log(findLargestBySumOfDigits([]));