function findPalindromes(value) {
    var myArray = value.split(/[^a-zA-z]+/);
    var palindromes = [];
    for (var i = 0; i < myArray.length; i++) {
        var currentWord = myArray[i];
        var reversedWord = "";
        for (var j = currentWord.length - 1; j >= 0; j--) {
            reversedWord += currentWord[j];
        }
        if (reversedWord.toLowerCase() === currentWord.toLowerCase()) {
            palindromes.push(currentWord);
        }
    }
    var result = palindromes.join(', ');
    return result;
}

console.log(findPalindromes('There is a man,  his name was Bob'));