/// <autosync enabled="true" />
/// <reference path="jquery.js" />
(function () {
    var btn = $("#btn").on("click", insertDiv);
    var text;
    var placement;
    var newDiv;

    function insertDiv() {
        text = $("#tb").val();
        placement = $("#placement").val();

        if (placement == "after") {
            newDiv = document.createElement("div");
            newDiv.innerText = text;
            $("article").append(newDiv);
        }
        else {
            newDiv = document.createElement("div");
            newDiv.innerText = text;
            $("article").before(newDiv);
        }
    }
}());