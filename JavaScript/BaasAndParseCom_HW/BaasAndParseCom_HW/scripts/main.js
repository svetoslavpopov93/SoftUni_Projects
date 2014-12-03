/// <autosync enabled="true" />
/// <reference path="jquery.js" />

(function () {
    var PARSE_APP_ID = "X9eM3h4B8Bxe9wstaLIzcIKRJiEuq0YRmeiGZQha";
    var PARSE_REST_API_KEY = "QH51xD4RQ5rQoip4UjRH7xlhqr9KYIhSrCVIvuk1";

    var tb_name = $('#tb_name');
    var tb_population = $('#tb_population');
    var btn_add = $('#btn_add');
    btn_add.on("click", addCountry);
    var btn_showCountries = $('#btn_showCountries');
    btn_showCountries.on("click", loadCountries);

    function loadCountries() {
        $("#countries").html("");
        jQuery.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country",
            success: countriesLoaded,
            error: message.error
        });
    }

    function countriesLoaded(data) {
        for (var c in data.results) {
            var country = data.results[c];
            var countryItem = $('<li>');
            var countryLink = $('<p>');
            countryLink.data('country', country);
            //countryLink.click();     //TODO
            countryItem.append(countryLink);
            countryLink.text(country.countryName + ", population: " + country.population);
            addControls(countryItem, country);
            countryItem.appendTo($("#countries"));
        }

        message.successfullLoad();
    }

    function addControls(countryItem, country) {
        var tb_name = $('<input type="text" class="inner_tb"/>');
        var tb_population = $('<input type="text" class="inner_tb"/>');
        var btn_edit = $('<a href="#" >Edit</a>');
        btn_edit.on("click", editCountry);
        var btn_showTowns = $('<a href="#" class="btn_showTowns">Show Towns</a>');
        btn_showTowns.on("click", showTowns);

        var tb_newTownName = $('<input type="text" />');
        var tb_newTownPopulation = $('<input type="text" />');
        var btn_addTown = $('<a href="#" >Add</a>');
        btn_addTown.on("click", function () {
            addTownToCountry(country, tb_newTownName, tb_newTownPopulation);
        });
        var btn_removeCountry = $('<a href="#" class="btn_remove">Remove Country</a>');
        btn_removeCountry.on("click", removeCountry);

        countryItem.append($('<span>Name: </span>'));
        countryItem.append(tb_name);
        countryItem.append($('<span>Population: </span>'));
        countryItem.append(tb_population);
        countryItem.append(btn_edit);
        countryItem.append(btn_showTowns);
        countryItem.append($('<span>Towns- Name: </span>'));
        countryItem.append(tb_newTownName);
        countryItem.append($('<span>Population: </span>'));
        countryItem.append(tb_newTownPopulation);
        countryItem.append(btn_addTown);
        countryItem.append(btn_removeCountry);

        var townsContainer = $('<div class="townsContainer">');
        var townsList = $('<ul class="townsList">');

        function showTowns() {
            var id = country.objectId;

            jQuery.ajax({
                method: "GET",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + country.objectId + '"}}',
                success: townsLoaded,
                error: message.error
            });

            townsContainer.append(townsList);
            countryItem.append(townsContainer);
        }

        function townsLoaded(data) {
            for (var t in data.results) {
                var town = data.results[t];
                var townItem = $('<li>');
                var townP = $('<p>').text(town.townName + " " + town.population);
                townItem.append(townP);
                addTownControls(town, townItem);
                townsList.append(townItem);
            }

            if (data.results.length == 0) {
                message.townsNotFound();
            }

        }

        function addTownControls(town, townItem) {
            var tb_townName = $('<input type="text" />');
            var tb_townPopulation = $('<input type="text" />');
            var btn_editTown = $('<a href="#" >Edit</a>');
            btn_editTown.on('click', function () { editTown(town, tb_townName, tb_townPopulation) });
            var btn_removeTown = $('<a href="#" >Remove</a>');
            btn_removeTown.on("click", function () { removeTown(town); });
            townItem.append(tb_townName);
            townItem.append(tb_townPopulation);
            townItem.append(btn_editTown);
            townItem.append(btn_removeTown);
        }

        function addTownToCountry(country, name, population) {
            validation.checkForEmptyString(name.val());
            validation.checkForEmptyString(name.val());

            jQuery.ajax({
                method: "POST",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                },
                data: JSON.stringify({
                    townName: name.val(),
                    population: parseInt(population.val()),
                    country:
                   {
                       "__type": "Pointer",
                       "className": "Country",
                       "objectId": country.objectId
                   }
                }),
                url: "https://api.parse.com/1/classes/Town",
                success: function () {
                    loadCountries();
                    message.successfullCreation();
                },
                error: message.error
            });
        }

        function editTown(town, name, population) {
            validation.checkForEmptyString(name.val());
            validation.checkForEmptyString(population.val());

            $.ajax({
                method: "PUT",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                data: JSON.stringify(
                    {
                        "townName": name.val(),
                        "population": parseInt(population.val())
                    }
                ),
                contentType: "application/json",
                url: "https://api.parse.com/1/classes/Town/" + town.objectId,
                success: function () {
                    message.successfullEditing();
                    loadCountries();
                },
                error: message.error
            });
        }

        function removeTown(town) {
            $.ajax({
                method: "DELETE",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Town/" + town.objectId,
                success: function () {
                    message.townRemoved();
                    loadCountries();
                },
                error: message.error
            });
        }

        function addTown(country, name, population) {
            jQuery.ajax({
                method: "POST",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                },
                data: JSON.stringify({
                    countryName: tb_name.val(),
                    population: parseInt(tb_population.val())
                }),
                url: "https://api.parse.com/1/classes/Country",
                success: function () {
                    loadCountries();
                    message.successfullCreation();
                },
                error: message.error
            });
        }

        function editCountry() {
            validation.checkForEmptyString(tb_name.val());
            validation.checkForEmptyString(tb_population.val());

            $.ajax({
                method: "PUT",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                data: JSON.stringify(
                    {
                        "countryName": tb_name.val(),
                        "population": parseInt(tb_population.val())
                    }
                ),
                contentType: "application/json",
                url: "https://api.parse.com/1/classes/Country/" + country.objectId,
                success: function () {
                    message.successfullEditing();
                    loadCountries();
                },
                error: message.error
            });
        }

        function removeCountry() {
            $.ajax({
                method: "DELETE",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Country/" + country.objectId,
                success: loadCountries,
                error: message.error
            });
        }
    }

    function addCountry() {
        validation.checkForEmptyString(tb_name.val());
        validation.checkForEmptyString(tb_population.val());

        jQuery.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
            },
            data: JSON.stringify({
                countryName: tb_name.val(),
                population: parseInt(tb_population.val())
            }),
            url: "https://api.parse.com/1/classes/Country",
            success: function () {
                loadCountries();
                message.successfullCreation();
            },
            error: message.error
        });
    }

    var validation = (function () {
        function checkForEmptyString(str) {
            if (str == "" || str == undefined) {
                message.emptyStringNotAwoled();
                throw new Error("Input string must be valid string!");
            }
        }

        return {
            checkForEmptyString: checkForEmptyString
        }
    }());

    var message = (function () {
        function error() {
            noty({
                text: 'Cannot load AJAX data.',
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            }
        );
        }

        function emptyStringNotAlowed() {
            noty({
                text: 'Empty fields are not alowed!',
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            }
        );
        }

        function townsNotFound() {
            noty({
                text: 'There are no towns in this country.',
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            }
        );
        }

        function townRemoved() {
            noty({
                text: 'Town deleted successfully!',
                layout: 'topCenter',
                timeout: 5000
            });
        }

        function successfullLoad() {
            noty({
                text: 'Countries are loaded.',
                layout: 'topCenter',
                timeout: 5000
            }
        );
        }

        function successfullCreation() {
            noty({
                text: 'Country created successfully!.',
                layout: 'topCenter',
                timeout: 5000
            }
        );
        }

        function successfullEditing() {
            noty({
                text: 'Country edited successfully!.',
                layout: 'topCenter',
                timeout: 5000
            }
        );
        }

        return {
            error: error,
            successfullLoad: successfullLoad,
            successfullCreation: successfullCreation,
            successfullEditing: successfullEditing,
            townsNotFound: townsNotFound,
            emptyStringNotAwoled: emptyStringNotAlowed,
            townRemoved: townRemoved
        }
    }());
}());
