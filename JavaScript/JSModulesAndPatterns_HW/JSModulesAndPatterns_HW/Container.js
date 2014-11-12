var world = world || {};
document.getElementById("new_section_btn").onclick = function () { world.CreateSection() };

var wrapper = document.getElementById("wrapper");

(function (world) {
    var currentContainer = 0;

    function CreateSection(name) {
        var cont = document.createElement("div");
        var title = document.createElement("h2");
        title.className = "title";
        title.innerText = document.getElementById("new_section_tb").value;


        var innerCont = document.createElement("div");
        innerCont.appendChild(title);
        var ul = document.createElement("ul");
ul.style.clear = "both";
        ul.id = "ul" + currentContainer;
        innerCont.appendChild(ul);
        var innerTb = document.createElement("input");
        innerTb.type = "text";
        innerTb.id = "innerTb" + currentContainer;
        var innerBtn = document.createElement("input");
        innerBtn.type = "button";
        innerBtn.value = "+";
        innerBtn.id = "innerBtn" + currentContainer;
        innerBtn.onclick = function() {world.CreateItem(innerTb.id, ul)};
        innerCont.appendChild(innerTb);
        innerCont.appendChild(innerBtn);

        cont.appendChild(innerCont);
        var tb = document.createElement("input");
        tb.type = "text";
        var btn = document.createElement("button");
        cont.className = "container";
        cont.id = "container" + currentContainer;

        wrapper.appendChild(cont);
        currentContainer++;
    };

    world.CreateSection = CreateSection;
}(world));
