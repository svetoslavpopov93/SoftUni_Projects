/// <autosync enabled="true" />
/// <reference path="jquery.js" />

(function () {
    var btn = $("#btn");
    var table = $("#cars");

    var json =
        [
            { "manufacturer": "BMW", "model": "E92 320i", "year": 2011, "price": 50000, "class": "Family" },
            { "manufacturer": "Porsche", "model": "Panamera", "year": 2012, "price": 100000, "class": "Sport" },
            { "manufacturer": "Peugeot", "model": "305", "year": 1978, "price": 1000, "class": "Family" }
        ];

    btn.on("click", function () {
        table.css("display", "inline-block");
        $.each(json, function (i, item) {
            var $tr = $("<tr>").append(
                $("<td>").text(item.manufacturer),
                $("<td>").text(item.model),
                $("<td>").text(item.year),
                $("<td>").text(item.price),
                $("<td>").text(item.class)
                );
            table.append($tr);
        });
    });
}());