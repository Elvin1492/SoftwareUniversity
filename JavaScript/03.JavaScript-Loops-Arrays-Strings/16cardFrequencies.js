function findCardFrequency(value) {
    var cards = value.split(/[♥♣♦♠ ]+/);
    var length = cards.length - 1;
    cards.sort();
    var cardsFreq = {};
    var count = 1;
    for (var i = 1; i < cards.length; i++) {
        if (cards[i] === cards[i - 1]) {
            count++;
            cardsFreq[cards[i]] = count;
        } else {
            cardsFreq[cards[i]] = 1;
            count = 1;
        }

    }
    var result = "";
    for (var card in cardsFreq) {
        result += card + " ->  " + ((cardsFreq[card] * 100) / length).toFixed(2) + "%" + "\n";
    }
    return result;
}

console.log(findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦'));
console.log(findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠'));
console.log(findCardFrequency('10♣ 10♥'));