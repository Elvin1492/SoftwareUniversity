function variablesTypes(name, age, isMale, params) {
    var favouriteFood = [];
    for (var i = 0; i < params.length; i++) {
        favouriteFood[i] = params[i];
    }
    return "My name: " + name + " //type is " + typeof(name) + "\n" +
        "My age: " + age + "  //type is " + typeof(age) + "\n" +
        "I am male: " + isMale + "  //type is " + typeof(isMale) + "\n" +
        "My favourite foods are: " + favouriteFood + "  //type is " + typeof(params) + "\n";
}
console.log(variablesTypes('Pesho', 22, true, ['fries', 'banana', 'cake']));
console.log(variablesTypes('Borislav', 28, true, ['bananas', 'rice', 'potatoes']));


console.log("You will work " + result[0] + " years on " + result[1] + ". You will live in " + result[2] +
    " drive " + result[4]);