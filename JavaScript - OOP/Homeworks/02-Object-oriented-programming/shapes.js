// Inheritance implementation
(function() {
    Object.prototype.extends = function(parent) {
        if (!Object.create) {
            Object.prototype.create = function(proto) {
                function F() {}
                F.prototype = proto;
                return new F();
            };
        }
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };
}());


// module Shapes holding the Shpes modules
var Shapes = (function() {
    //require('./lib/inheritance');
    // base module Shape
    var Shape = (function() {
        function Shape(x, y, color) {
            this._x = x;
            this._y = y;
            // if (!validatePosition.call(this)) {
            //     throw new Error('Invalid x/y coordinates');
            //     window.alert("Invalid x/y coordinates");
            // }
            this._color = color;
        }

        Shape.prototype.toString = function() {
            return this.constructor.name + " - " + "X: " + this._x + ", Y: " + this._y + ", Color: " + this._color;
        };

        Shape.prototype.draw = function() {
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            return ctx;
        };

        var BORDERS = {
        LEFT: 0,
        RIGHT: 1000,
        TOP: 0,
        BOTTOM: 1000
    };

    function validatePosition() {
        if (this._x < BORDERS.LEFT || BORDERS.RIGHT < this._x ||
            this._y < BORDERS.TOP || BORDERS.BOTTOM < this._y) {
            return false;
        }
        return true;
    }

        return Shape;
    })();

    // module Point ineherits Shape
    var Point = (function() {
        function Point(x, y, color) {
            Shape.call(this, x, y, color);
        }

        Point.extends(Shape);

        Point.prototype.draw = function() {
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            ctx.fillStyle = this._color;
            ctx.fillRect(this._x, this._y, 2, 2);
        };

        return Point;
    })();
    // module Segment ineherits Shape
    var Segment = (function() {
        function Segment(x, y, color, x2, y2) {
            Shape.call(this, x, y, color);
            this._x2 = x2;
            this._y2 = y2;
        }

        Segment.extends(Shape);

        Segment.prototype.toString = function() {
            return Shape.prototype.toString.call(this) + ", X2: " + this._x2 + ", Y2: " + this._y2;
        };

        Segment.prototype.draw = function() {
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            ctx.fillStyle = this._color;
            ctx.moveTo(this._x, this._y);
            ctx.lineTo(this._x2, this._y2);
            ctx.lineWidth = 3;
            ctx.fill();
        };

        return Segment;
    })();
    // module Circle ineherits Shape
    var Circle = (function() {
        function Circle(x, y, color, radius) {
            Shape.call(this, x, y, color);
            this._radius = radius;
        }

        Circle.extends(Shape);

        Circle.prototype.toString = function() {
            return Shape.prototype.toString.call(this) + ", Radius: " + this._radius;
        };

        Circle.prototype.draw = function() {
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            ctx.fillStyle = this._color;
            ctx.arc(this._x, this._y, this._radius, 0 * Math.PI, 2 * Math.PI);
            ctx.fill();
        };

        return Circle;
    })();
    // module Rectngle ineherits Shape
    var Rectangle = (function() {
        function Rectangle(x, y, color, width, height) {
            Shape.call(this, x, y, color);
            this._width = width;
            this._height = height;
        }

        Rectangle.extends(Shape);

        Rectangle.prototype.toString = function() {
            return Shape.prototype.toString.call(this) + ", Width: " + this._width + ", Height: " + this._height;
        };

        Rectangle.prototype.draw = function() {
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            this.canvas().ctx.fillStyle = this._color;
            this.canvas().ctx.fillRect(this._x, this._y, this._width, this._height);
        };

        return Rectangle;
    })();
    // class Triangle ineheris Shape
    var Triangle = (function() {
        function Triangle(x, y, color, x2, y2, x3, y3) {
            Segment.call(this, x, y, color, x2, y2);
            this._x3 = x3;
            this._y3 = y3;
        }

        Triangle.extends(Shape);

        Triangle.prototype.toString = function() {
            return Segment.prototype.toString.call(this) + ", X3: " + this._x3 + ", Y3: " + this._y3;
        };

        Triangle.prototype.draw = function() {
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            ctx.fillStyle = this._color;
            ctx.beginPath();
            ctx.moveTo(this._x, this._y);
            ctx.lineTo(this._x2, this._y2);
            ctx.lineTo(this._x3, this._y3);
            ctx.lineTo(this._x, this._y);
            ctx.fill();
        };

        return Triangle;
    })();

    return {
        Point: Point,
        Segment: Segment,
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle
    };

})();

var point = new Shapes.Point(5, 5, "red");
console.log(point.toString());

var segment = new Shapes.Segment(1, 1, "black", -4, 5);
console.log(segment.toString());

var circle = new Shapes.Circle(3, 3, "yellow", 6);
console.log(circle.toString());

var rectangle = new Shapes.Rectangle(5, 5, "red", 10, 18);
console.log(rectangle.toString());

var triangle = new Shapes.Triangle(4, 4, "black", 3, 7, 8, 9);
console.log(triangle.toString());