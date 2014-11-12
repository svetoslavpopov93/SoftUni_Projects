var world = world || {};

(function (world) {
    function CreateItem(tb, uList) {
        var currLi = document.createElement("li");
        var liCheckbox = document.createElement("input");
        liCheckbox.type = "checkbox";
        var liText = document.createElement("p");
        liCheckbox.onchange = function () {
            if (liText.style.backgroundColor !== "green") {
                liText.style.backgroundColor = "green";
            }
            else {
                liText.style.backgroundColor = "white";
            }
        };
        currLi.appendChild(liCheckbox);
        var text = document.getElementById(tb).value;
        liText.innerText = text;
        currLi.appendChild(liText);

        var list = uList;

        list.appendChild(currLi);
    }
    world.CreateItem = CreateItem;
}(world));