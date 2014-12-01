/// <autosync enabled="true" />
/// <reference path="jquery.js" />
(function () {
    var images = [];
    var img;
    var currentIndex = 0;
    var previousIndex = 0;
    var middleIndex;

    var leftBtn = $("#left").on("click", moveLeft);
    var rightBtn = $("#right").on("click", moveRight);

    for (var i = 0; i < 4; i++) {
        img = $("<img src=\"assets\\image" + i + ".png\" >").addClass("image" + i);
        images.push(img);
        $("body").append(img);;
    }

    setInterval(function () { moveRight(); }, 5000);

    middleIndex = Math.floor(images.length / 2);
    images[middleIndex].addClass("big_image");
    currentIndex = middleIndex;
    previousIndex = currentIndex;

    function moveRight() {
        currentIndex++;
        if (currentIndex >= images.length) {
            currentIndex = 0;
        }

        $(".image" + currentIndex).addClass("big_image");
        $(".image" + previousIndex).removeClass("big_image");

        previousIndex++;
        if (previousIndex >= images.length) {
            previousIndex = 0;
        }

    }

    function moveLeft() {
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = images.length - 1;
        }

        $(".image" + previousIndex).removeClass("big_image");
        $(".image" + currentIndex).addClass("big_image");

        previousIndex--;
        if (previousIndex < 0) {
            previousIndex = images.length - 1;
        }
    }

    
}());