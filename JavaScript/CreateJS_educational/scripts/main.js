/// <autosync enabled="true" />
/// <reference path="jquery-1.11.1.min.js" />
/// <reference path="createjs.js" />
/// <reference path="jquery_animate.js" />

var core = (function () {
    var inputX = 300;
    var inputY = 300;
    var isRightBtnClicked = false;

    document.oncontextmenu = RightMouseDown;
    

    var canvas = document.createElement('canvas');
    //$(canvas).on("contextmenu", getMouseCoordinates);
    //canvas.addEventListener("click", getMouseCoordinates);
    canvas.id = "mainScene";
    canvas.width = 800;
    canvas.height = 568;
    document.body.appendChild(canvas);
    var sniper;
    var x = 110;
    var y = 140;
    

    var stage = new createjs.Stage("mainScene");
    init();

    function init() {
        animateSniper();
    }

    function animateSniper() {

        stage = new createjs.Stage(document.getElementById("mainScene"));
        // Define a spritesheet. Note that this data was exported by Zoë.
        var ss = new createjs.SpriteSheet({
            "animations":
            {
                "run": [0, 7, "run"]},
            "images": ["assets/newSniper.png"],
            "frames":
                {
                    "height": 63,
                    "width":53,
                    "regX": 0,
                    "regY": 0,
                    "count": 8
                }
        });
        sniper = new createjs.Sprite(ss, "run");
        sniper.x = x;
        sniper.y = y;
        sniper.name = "sniper";
        stage.addChild(sniper);
        createjs.Ticker.setInterval(130);
        createjs.Ticker.addEventListener("tick", tick);
        //createjs.Ticker.on("tick", move);
    }

    var i = 0; var tween;

    var currentSniper;
        function move() {
            tween = createjs.Tween.get(sniper, { loop: false })
                             .to({ x: inputX, y: inputY }, 1000)
                             .call(handleComplete);

            function handleComplete() {
                isRightBtnClicked = false;
            }
            stage.update();
        }

        function tick() {
            if (isRightBtnClicked) {
                move();
            }
        stage.update();
        };

        function RightMouseDown(event) {
            inputX = event.offsetX;
            inputY = event.offsetY;
            isRightBtnClicked = true;

            event = event || window.event;

            var xDist = event.offsetX - sniper.x;
            var yDist = event.offsetY - sniper.y;
            var angle = Math.atan2(yDist, xDist) * (180 / Math.PI);
            sniper.rotation = angle;
            return false;
        }

    return {
        init: init
    }
}());