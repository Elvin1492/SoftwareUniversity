function clone(obj) {
    var objCopy = JSON.parse(JSON.stringify(obj));
    return objCopy;
}

function compareObjects(obj, objCopy) {
    if (obj == objCopy) {
        return 'a == b --> true';
    } else {
        return 'a == b --> false';
    }
}

var a = {
    name: 'Pesho',
    age: 21
};
var b = clone(a); // a deep copy 
console.log(compareObjects(a, b));

var x = {
    name: 'Pesho',
    age: 21
};
var y = x; // not a deep copy
console.log(compareObjects(x, y));