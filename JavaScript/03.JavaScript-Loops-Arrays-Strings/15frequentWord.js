function findMostFreqWord(value) {
    var sorted = value.toLowerCase().split(/[^a-zA-z]+/);
    sorted.sort();
    var wordFreq = {};
    var counter = 1;
    var max = 0;
    for (var i = 1; i < sorted.length; i++) {
        if (sorted[i] === sorted[i - 1]) {
            counter++;
            wordFreq[sorted[i]] = counter;
            if (counter >= max) {
                max = counter;
            }
        } else {
            counter = 1;
        }
    }
    var result = "";
    for (var word in wordFreq) {
        if (wordFreq[word] === max) {
            result += word + " -> " + wordFreq[word] + " times" + "\n";
        }
    }
    return result;
}

console.log(findMostFreqWord('in the middle of the night'));
console.log(findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.'));
console.log(findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.'));