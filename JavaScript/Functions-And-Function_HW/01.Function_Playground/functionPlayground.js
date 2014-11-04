function funcWithoutArguments() {
    for (var i = 0; i < arguments.length; i++) {
        console.log("Argument " + (i + 1) + arguments[i] + ", of type [" + typeof (arguments[i]) + "]");
    }

    console.log();
}

var func = function () {
    var obj = {};
    obj.name = "Pesho";
    return obj;
};


funcWithoutArguments.call(null, "asd", 123);

funcWithoutArguments.call(null, "asd", 123, func().name);

funcWithoutArguments.apply(null, ["asssd", 124]);

//I didnt find a way to stop my console from closing, so i find alter
//require('readline')
//    .createInterface(process.stdin, process.stdout)
//    .question("Press [Enter] to exit...", function () {
//        process.exit();
//    });