var BigNumber = require('./bignumber.min.js');

function sumTwoHugeNumbers(value) {
    var bigInteger1 = BigNumber(value[0]);
    var bigInteger2 = BigNumber(value[1]);
    var sum = bigInteger1.plus(bigInteger2).toString(10);
    return sum;
}

console.log(sumTwoHugeNumbers(['155', '65']));
console.log(sumTwoHugeNumbers(['123456789', '123456789']));
console.log(sumTwoHugeNumbers(['887987345974539', '4582796427862587']));
console.log(sumTwoHugeNumbers(['347135713985789531798031509832579382573195807',
    '817651358763158761358796358971685973163314321'
]));