var specialConsole = ( function () {

    function writeLine(){
        var writingLine = arguments[0];
        var writingLineUsingFormatting = [];
        for (var i = 1; i < arguments.length; i++) {
              writingLineUsingFormatting.push(arguments[i]);
        }

        if (arguments.length == 1) {
            console.log(writingLine);
        } else {
        	console.log(writingLine.split(' ')[0] + ": " + writingLineUsingFormatting.join(' '));
        }
    }

    return {
    	writeLine: writeLine,
    	writeError: writeLine,
    	writeWarning: writeLine,
    };
})();


specialConsole.writeLine("Message: Hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Message: {0} {1}", "hello", "world");
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0} {1}", "You are not allowed to do that!", "Dude");
