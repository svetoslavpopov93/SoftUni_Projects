function TraverseDOM(selector) {
    var node = document.querySelector("body");

  TraverseElement(node, "");
}

function TraverseElement(element, currInterval) {
    var currentInterval = currInterval;
    var wholeElement = "";
    var name = (element.nodeName).toLowerCase();
    wholeElement += name + ": "

    var idName = element.id;
    if(idName != ""){
        wholeElement += "id=\"" + idName + "\"";
        }

    var className = element.className;
    if(className != ""){
        wholeElement += "class=\"" + className + "\"";
        }
    var nodes = element.childNodes;
    var onlyElements = [];

    for(var i = 0; i < nodes.length; i++){
        if(nodes[i].nodeName != "#text"){
                onlyElements.push(nodes[i]);
            }
        }
    console.log(currentInterval + wholeElement);

    if(onlyElements.length != 0){
        for(var i = 0; i < onlyElements.length; i++){
                TraverseElement(onlyElements[i], ("  " + currentInterval));
            }
        }
};

    // Because of a but in NodeJS console, this is implemented to make the console stop disapearing
//require('readline')
//    .createInterface(process.stdin, process.stdout)
//    .question("Press [Enter] to exit...", function () {
//        process.exit();
//    });

    TraverseDOM("body");