function getSelectedShape() {
    var selectedShape = document.getElementById('shape-select').value;

    switch (selectedShape) {
        case 'Triangle':
            getBasicInput();
            break;
        case 'Rectangle':
            getBasicInput();
            break;
        case 'Circle':
            //  code block
            break;
        case 'Point':
            //  code block
            break;
        case 'Segment':
            // code block
            break;
        default:
            break;
    }
}

function getBasicInput() {
    //require('./lib/inheritance');
    var x = document.getElementById('x1').value;
    var y = document.getElementById('y1').value;
    var color = document.getElementById('color').value;

    var height = document.getElementById('height').value;
    var width = document.getElementById('width').value;

    var radius = document.getElementById('radius').value;

    var x2 = document.getElementById('x2').value;
    var y2 = document.getElementById('y2').value;

    var x3 = document.getElementById('x3').value;
    var y3 = document.getElementById('y3').value;
    // return {
    // 	x: x,
    // 	y: y,
    // 	color: color,
    // 	height: height,
    // 	width: width
    // };

    // var rectangle = new Shapes.Rectangle(x, y, color, width, height);
    // rectangle.draw();

    var point = new Shapes.Point(x, y, color);
    point.draw();

    // var circle = new Shapes.Circle(x, y, color, radius);
    // circle.draw();

    // var segment = new Shapes.Segment(x, y, color, x2, y2);
    // segment.draw();

    // var triangle = new Shapes.Triangle(x, y, color, x2, y2, x3, y3);
    // triangle.draw();
}