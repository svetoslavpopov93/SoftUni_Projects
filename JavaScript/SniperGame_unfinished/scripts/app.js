/// <autosync enabled="true" />
/// <reference path="jquery-1.11.1.min.js" />

(function () {
    var canvas = document.createElement("canvas");
    var ctx = canvas.getContext("2d");
    canvas.width = 512;
    canvas.height = 480;
    $(".wrapper").append(canvas);

    var lastTime;
    function main() {
        var now = Date.now();
        var dt = (now - lastTime) / 1000.0;

        update(dt);
        render();

        lastTime = now;
        requestAnimFrame(main);
    };

    resources.load ([
    'img/sniper.png'
    ]);
}());
