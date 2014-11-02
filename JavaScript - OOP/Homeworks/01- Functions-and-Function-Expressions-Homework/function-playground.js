function playFunction() {
    console.log("Number of arguments passed to " + playFunction.name + "(): " + arguments.length);
    for (var argument in arguments) {
        console.log("Argument " + (parseInt(argument) + 1) + ": " + arguments[argument] + 
        	"; Type: " + typeof(arguments[argument]));
    }
    console.log("Printing the this object: " + this.thisExample);
}

playFunction();
console.log();

playFunction.call({thisExample : "function scope"}, true, function() { return 1; }, []);
console.log();

thisExample = "global scope";
playFunction.apply(null, [2, "some string"]);
console.log();
