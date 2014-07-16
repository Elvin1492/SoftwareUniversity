 var result = [];

 function soothSayer(arguments) {
     for (var i = 0; i < 4; i++) {
         var randomNumber = Math.floor(Math.random() * 5);
         var randomItem = arguments[i][randomNumber];
         result.push(randomItem);
     }
     return result;
 }

 soothSayer([
     [3, 5, 2, 7, 9],
     ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'],
     ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'],
     ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']
 ]);

 console.log("You will work " + result[0] + " years on " + result[1] + ". You will live in " + result[2] +
     " and drive " + result[3] + ".");