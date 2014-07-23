function reverseWordsInString(str) {
    var words = str.split(' ');
    var reversed = [];
    for (var word in words) {
        var current = words[word].split('').reverse().join('');
        reversed.push(current);
    }
    return reversed.join(' ');
}

console.log(reverseWordsInString('Hello, how are you.'));
console.log(reverseWordsInString('Life is pretty good, isn’t it?'));