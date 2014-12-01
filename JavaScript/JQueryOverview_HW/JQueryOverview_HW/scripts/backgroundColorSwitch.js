/// <autosync enabled="true" />
/// <reference path="jquery.js" />

(function () {
    var tb = $("#tb");
    var color = $("#color");
    var button = $("#btn");

    button.on("click", paint);

    function paint() {
        $(("." + tb.val())).css("background-color", color.val());
    }
}());