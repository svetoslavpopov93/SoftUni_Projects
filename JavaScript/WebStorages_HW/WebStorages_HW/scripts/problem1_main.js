/// <autosync enabled="true" />
/// <reference path="jquery.js" />

(function () {
    $("#btn_clear").on("click", clearStorage);
    var sessionVisits = $('<span id="sessionVisits">');
    var totalVisits = $('<span id="totalVisits">');
    $("#container").append(sessionVisits).append(totalVisits);
    checkUser();

    function checkUser() {
        var isFirstTime = false;

        if (localStorage.getItem("name") == undefined) {
            isFirstTime = true;
        }

        if (sessionStorage["counter"] == undefined) {
            sessionStorage.setItem("counter", "1");
        }

        if (isFirstTime) {
            var lbl = $('<label for="tb">Name: </label>');
            var tb = $('<input type="text" id="tb" >');
            var btn = $('<a href="#">Set Name</a>');
            btn.on("click", function () {
                localStorage.setItem("name", tb.val());
                localStorage.setItem("counter", "1");
                sessionStorage.setItem("counter", "1");
                lbl.remove();
                tb.remove();
                btn.remove();
                $('#container').addClass("moveRight");
                checkUser();
            });

            $("#container").append(lbl).append(tb).append(btn);
        }
        else {
            $('#btn_clear').show();
            sessionVisits.show();
            totalVisits.show();
            var greetingsBox = $('<div id="greetings_box">').text("Greetings, " + localStorage["name"] + "!").width(0).height(0).animate(
                {
                    left: '520px',
                    height: '150px',
                    width: '250px'
                });
            $('body').append(greetingsBox);
            var localCounter = parseInt(localStorage.getItem("counter"));
            localCounter++;
            localStorage.setItem("counter", localCounter);
            totalVisits.text("Total visits: " + localCounter);

            var sessionCounter = parseInt(sessionStorage.getItem("counter"));
            sessionCounter++;
            sessionStorage.setItem("counter", sessionCounter);
            sessionVisits.text("Session visits: " + sessionCounter + ", ");
        }

    }

    function clearStorage() {
        $('#btn_clear').hide();;
        sessionVisits.hide();
        totalVisits.hide();
        localStorage.clear();
        $('#greetings_box').hide();
        $('#container').removeClass("moveRight");
        checkUser();
    }
}());