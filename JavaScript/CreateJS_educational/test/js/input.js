
(function() {
    var pressedKeys = {};

    function setKey(event, status) {
            
        
        //var code = event.keyCode;
        //if (event.which == 1) {
        //    console.log("asd");
        //    code = -1;
        //}
        //var key;

        //switch (code) {
        //    case -1:
        //        key = "LEFT"; break;
        //case 32:
        //    key = 'SPACE'; break;
        //case 37:
        //    key = 'LEFT'; break;
        //case 38:
        //    key = 'UP'; break;
        //case 39:
        //    key = 'RIGHT'; break;
        //case 40:
        //    key = 'DOWN'; break;
        //default:
        //    // Convert ASCII codes to letters
        //    key = String.fromCharCode(code);
        //}

        var code = event.which;
        switch (code) {
            case 3:
                key = "RIGHT";
                console.log("right");
                break;
            case 1:
                key = "LEFT";
                console.log("left");
                break;
            default:
                key = "ANOTHER";
                console.log("another");
                break;
        }

        pressedKeys[key] = status;
    }

    document.addEventListener('keydown', function(e) {
        setKey(e, true);
    });

    document.addEventListener('keyup', function(e) {
        setKey(e, false);
    });

    window.addEventListener('blur', function() {
        pressedKeys = {};
    });

    window.input = {
        isDown: function(key) {
            return pressedKeys[key.toUpperCase()];
        }
    };
})();