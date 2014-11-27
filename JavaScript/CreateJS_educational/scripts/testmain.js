/// <autosync enabled="true" />
/// <reference path="jquery-1.11.1.min.js" />
/// <reference path="createjs.js" />
/// <reference path="jquery_animate.js" />
var isClicked = false;

var core = (function () {

    function init() {
        disableRightClickMenu();

        var stage = new createjs.Stage("canvas");
        var circle = new createjs.Shape();
        circle.graphics.beginFill("red").drawCircle(0, 0, 20);
        circle.x = 100;
        circle.y = 100;
        stage.addChild(circle);

        createjs.Ticker.on("tick", move);
        createjs.Ticker.setFPS(40);

        function move() {
            var tween = createjs.Tween.get(circle, { loop: false })
                             .to({ x: 350, y: 400 }, 1500)
                             .call(handleComplete);

            function handleComplete() {
                console.log("Im here");
            }
            stage.update();
        }
        stage.update();

        var index = 0;

        function tick(event) {
            console.log("tick");

            if (isClicked) {

                isClicked = false;
                move();
            }


            function move() {
                var tween = createjs.Tween.get(circle, { loop: true })
                                 .to({ x: 350, y: 400, rotation: -360 }, 1500)
            }

            stage.update();
        }
    };

    var followMouseCursor = function (event) {
        event = event || window.event;
        var triangle = document.querySelector('#sniper');
        var xDist = event.layerX - triangle.offsetLeft;
        var yDist = event.layerY - triangle.offsetTop;
        var angle = Math.atan2(yDist, xDist) * (180 / Math.PI);

        triangle.style.transform = 'rotate(' + angle + 'deg)';
    };


    function animateSprite() {
        $("#sniper").animateSprite({
            fps: 12,
            animations: {
                walkRight: [0, 1, 2, 3, 4, 5, 6, 7],
            },
            loop: true,
            complete: function () {
                // use complete only when you set animations with 'loop: false'
                alert("animation End");
            }
        });
    }


    function getPositionAndMove(event) {
        if (event.which == 3) {

            targetPoint.x = event.clientX;
            targetPoint.y = event.clientY;
            var ang = find_angle(MIDDLE_POINT, characterPoint, targetPoint);
            rotateSniper(ang * 100, "left");

            //var canvas = document.getElementById("mainScene");

            //if (event.x != undefined && event.y != undefined) {
            //    x = event.x;
            //    y = event.y;
            //}
            //else {
            //    x = event.clientX + document.body.scrollLeft +
            //        document.documentElement.scrollLeft;
            //    y = event.clientY + document.body.scrollTop +
            //        document.documentElement.scrollTop;
            //}

            //x -= canvas.offsetLeft;
            //y -= canvas.offsetTop;
        }

    }
    function disableRightClickMenu() {
        document.oncontextmenu = RightMouseDown;
        function RightMouseDown() { return false; }
    }
    return {
        init: init,
    }
}());