(function() {
    //check if running on Node.js
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('../node_modules/underscore/underscore.js');
    }

    var students = [{
        "gender": "Male",
        "firstName": "Joe",
        "lastName": "Riley",
        "age": 22,
        "country": "Russia"
    }, {
        "gender": "Female",
        "firstName": "Lois",
        "lastName": "Morgan",
        "age": 41,
        "country": "Bulgaria"
    }, {
        "gender": "Male",
        "firstName": "Roy",
        "lastName": "Wood",
        "age": 33,
        "country": "Russia"
    }, {
        "gender": "Female",
        "firstName": "Diana",
        "lastName": "Freeman",
        "age": 40,
        "country": "Argentina"
    }, {
        "gender": "Female",
        "firstName": "Bonnie",
        "lastName": "Hunter",
        "age": 23,
        "country": "Bulgaria"
    }, {
        "gender": "Male",
        "firstName": "Joe",
        "lastName": "Young",
        "age": 16,
        "country": "Bulgaria"
    }, {
        "gender": "Female",
        "firstName": "Kathryn",
        "lastName": "Murray",
        "age": 22,
        "country": "Indonesia"
    }, {
        "gender": "Male",
        "firstName": "Dennis",
        "lastName": "Woods",
        "age": 37,
        "country": "Bulgaria"
    }, {
        "gender": "Male",
        "firstName": "Billy",
        "lastName": "Patterson",
        "age": 24,
        "country": "Bulgaria"
    }, {
        "gender": "Male",
        "firstName": "Willie",
        "lastName": "Gray",
        "age": 42,
        "country": "China"
    }, {
        "gender": "Male",
        "firstName": "Justin",
        "lastName": "Lawson",
        "age": 38,
        "country": "Bulgaria"
    }, {
        "gender": "Male",
        "firstName": "Ryan",
        "lastName": "Foster",
        "age": 24,
        "country": "Indonesia"
    }, {
        "gender": "Male",
        "firstName": "Eugene",
        "lastName": "Morris",
        "age": 37,
        "country": "Bulgaria"
    }, {
        "gender": "Male",
        "firstName": "Eugene",
        "lastName": "Rivera",
        "age": 45,
        "country": "Philippines"
    }, {
        "gender": "Female",
        "firstName": "Kathleen",
        "lastName": "Hunter",
        "age": 28,
        "country": "Bulgaria"
    }];

    console.log('----Students with age bewtween 18 and 24----');
    var studentsByAge = _.chain(students)
        .filter(function(st) {
            return st.age >= 18 && st.age <= 24;
        })
        .each(function(st) {
            console.log(st.firstName + ' ' + st.lastName + ': ' + st.age);
        });
    console.log('-----------------------------------------------------');


    console.log('----Students whose first name is alphabetically before their last name---');
    var studentsByName = _.chain(students)
        .filter(function(st) {
            return st.firstName.localeCompare(st.lastName) < 0;
        })
        .each(function(st) {
            console.log(st.firstName + ' ' + st.lastName);
        });
    console.log('-----------------------------------------------------');


    console.log('----Students from Bulgaria ---');
    var studentsFromBulgaria = _.chain(students)
        .where({
            country: 'Bulgaria'
        })
        .each(function(st) {
            console.log(st.firstName + ' ' + st.lastName + ': ' + st.country);
        });
    console.log('-----------------------------------------------------');


    console.log('----Last five students---');
    var studentsLastFive = _.chain(students)
        .last(5)
        .each(function(st) {
            console.log(st.firstName + ' ' + st.lastName);
        });
    console.log('-----------------------------------------------------');


    console.log('----First three students who are not from Bulgaria and are male---');
    var studentsNotFromBlgariaMale = _.chain(students)
        .filter(function(st) {
            return st.country !== 'Bulgaria' && st.gender === 'Male';
        })
        .first(3)
        .each(function(st) {
            console.log(st.firstName + ' ' + st.lastName + ': ' + st.country + ' ' + st.gender);
        });
    console.log('-----------------------------------------------------');
}());