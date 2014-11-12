document.getElementById("btn").addEventListener("click", DrawFigure);
var canvas = document.getElementById("shapes_container");
var ctx = canvas.getContext("2d");

Object.prototype.extends = function (parent) {
    if (!Object.create) {
        Object.prototype.create = function (proto) {
            function F() { };
            F.prototype = proto;
            return new F;
        };
    };

    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
}

var Shape = (function () {
    function Shape(x, y, color) {
        if (isNaN(x)) {
            throw "X must be a number";
        }
        if (isNaN(y)) {
            throw "Y must be a number";
        }
        this._x = x;
        this._y = y;
        this._color = color;
    }

    Shape.prototype = {
        draw: function draw() {
            return "X: " + this._x + ", Y: " + this._y + ", Color: " + this._color;
        }
    };

    return Shape;
}());

var Point = (function () {
    function Point(x, y) {
        if (isNaN(x)) {
            throw "X must be a number.";
        }
        if (isNaN(y)) {
            throw "Y must be a number.";
        }
        this._x = x;
        this._y = y;

    };

    Point.prototype.GetX = function X() { return this._x };
    Point.prototype.GetY = function Y() { return this._y };

    return Point;
}());

var Circle = (function () {
    function Circle(x, y, color, radius) {
        Shape.call(this, x, y, color);
        this._radius = radius;
    }

    Circle.extends(Shape);

    Circle.prototype.draw = function () {
        ctx.beginPath();
        ctx.arc(this._x, this._y, this._radius, 0, 2 * Math.PI);
        ctx.fillStyle = this._color;
        ctx.fill();
        ctx.stroke();

        return Shape.prototype.draw.call(this) + ", Radius: " + this._radius;
    };

    return Circle;
}());

var Rectangle = (function () {
    function Rectangle(x, y, color, width, height) {
        Shape.call(this, x, y, color);
        this._width = width;
        this._heigth = height;
    };

    Rectangle.extends(Shape);

    Rectangle.prototype.draw = function () {
        ctx.beginPath();
        ctx.beginPath();
        ctx.rect(this._x, this._y, this._width, this._heigth);
        ctx.fillStyle = this._color;
        ctx.fill();
        ctx.stroke();

        return Shape.prototype.draw.call(this) + ", Width: " + this._width + ", Height: " + this._heigth;
    };

    return Rectangle;
}());

var Triangle = (function () {
    function Triangle(x, y, color, a, b) {
        Shape.call(this, x, y, color);
        this._a = a;
        this._b = b;
    };

    Triangle.extends(Shape);

    Triangle.prototype.draw = function () {
        ctx.beginPath();
        ctx.moveTo(this._x, this._y);
        ctx.lineTo(this._a.GetX(), this._a.GetY());
        ctx.lineTo(this._b.GetX(), this._b.GetY());        ctx.fillStyle = this._color;

        ctx.fill();
        return Shape.prototype.draw.call(this)
    + ", Side A: [" + this._a.GetX() + ", " + this._a.GetY()
    + "], Side B: [" + this._b.GetX() + ", " + this._b.GetY()
    + "], Side C: [" + this._c.GetX() + ", " + this._c.GetY();
    };

    return Triangle;
}());

var Segment = (function () {
    function Segment(x, y, color, a) {
        Shape.call(this, x, y, color);
        this._a = a;
    };

    Segment.extends(Shape);

    Segment.prototype.draw = function () {
        ctx.beginPath();
        ctx.moveTo(this._x, this._y);
        ctx.lineTo(this._a.GetX(), this._a.GetY());
        ctx.lineWidth = 7;
        ctx.stroke();
        return Shape.prototype.draw.call(this) + ", A: [" + this._a.GetX() + ", " + this._a.GetY() + "], B: [" + this._b.GetX() + ", " + this._b.GetY() + "]"
    };

    return Segment;
}());



function DrawFigure() {
    var x = document.getElementById("x_box").value;
    var y = document.getElementById("y_box").value;
    var clr = document.getElementById("color_picker").value;
    var radius = document.getElementById("radius_box").value;
    var shape = document.getElementById("shape_box").value;
    var aX = document.getElementById("x_box2").value;
    var aY = document.getElementById("y_box2").value;
    var a = new Point(aX, aY);
    var bX = document.getElementById("x_box3").value;
    var bY = document.getElementById("y_box3").value;
    var b = new Point(bX, bY);

    if (shape === "circle") {
        var cir = new Circle(x, y, clr, radius);
        cir.draw();
    }
    if (shape === "rectangle") {
        var rec = new Rectangle(x, y, clr, aX, aY);
        rec.draw();
    }
    if (shape === "triangle") {
        var tr = new Triangle(x, y, clr, a, b);
        tr.draw();
    }
    if (shape === "segment") {
        var sg = new Segment(x, y, clr, a);
        sg.draw();
    }
}


    // To launch in nodeJS, decomment bottom lines, so the console can stop at end
    //require('readline')
    //    .createInterface(process.stdin, process.stdout)
    //    .question("Press [Enter] to exit...", function () {
    //        process.exit();
    //    });