function treeHouseCompare(a, b) {
    var houseArea = (4 * a * a) / 3;
    var treeArea = (b * b * (3 + 4 * Math.PI)) / 9;
    if (houseArea > treeArea) {
        return "house/" + houseArea.toFixed(2);
    } else {
        return "tree/" + treeArea.toFixed(2);
    }
}

console.log(treeHouseCompare(3, 2));
console.log(treeHouseCompare(3, 3));
console.log(treeHouseCompare(4, 5));