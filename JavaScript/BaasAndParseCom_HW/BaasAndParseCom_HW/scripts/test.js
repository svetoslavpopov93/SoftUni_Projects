/// <autosync enabled="true" />
/// <reference path="jquery.js" />

$(function () {
    var PARSE_APP_ID = "X9eM3h4B8Bxe9wstaLIzcIKRJiEuq0YRmeiGZQha";
    var PARSE_REST_API_KEY = "QH51xD4RQ5rQoip4UjRH7xlhqr9KYIhSrCVIvuk1";
    var liTowns = [];

    var tb_addName = $('#add_country_name');
    var tb_addPopulation = $('#add_country_population');
    var btn_addCountry = $('#add_btn').on("click", addCountry);

    var tb_editName_countryName_old = $('#edit_current_name');
    var tb_editName_countryName_new = $('#edit_new_name');
    var btn_editName = $('#edit_name_btn');
    var tb_editPopulation_countryName = $('#edit_current_population');
    var tb_editPopulation_newPopulation = $('#edit_new_population');
    var btn_editPopulation = $('#edit_population_btn');
    $("#print_countries").on("click", loadCountries);
    btn_editName.on("click", ChangeCountryName);
    btn_editPopulation.on("click", changeCountryPopulation);

    var validation = (function () {
        function CheckForEmptyString(name) {
            if (name == "") {
                throw new Error("Input string must not be empty!");
            }
        }

        return {
            checkForEmptyString:CheckForEmptyString
        }
    }());

    function addCountry() {
        validation.checkForEmptyString(tb_addName.val());
        validation.checkForEmptyString(tb_addPopulation.val());
        jQuery.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
            },
            data: JSON.stringify({
                countryName: tb_addName.val(),
                population: parseInt(tb_addPopulation.val())
            }),
            url: "https://api.parse.com/1/classes/Country",
            success: countriesLoaded,
            error: ajaxError
        });
    }
    
    function ChangeCountryName() {
        jQuery.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country",
            success: changeName,
            error: ajaxError
        });
    }

    function changeName(data) {
        var wantedCountry;
        validation.checkForEmptyString(tb_editName_countryName_old.val());
        validation.checkForEmptyString(tb_editName_countryName_new.val());
        for (var c in data.results) {
            var country = data.results[c];

            if (country.countryName == tb_editName_countryName_old.val()) {
                wantedCountry = country;
                break;
            }
        }

        $.ajax({
            method: "PUT",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            data: JSON.stringify(
                { "countryName": tb_editName_countryName_new.val() }
            ),
            contentType: "application/json",
            url: "https://api.parse.com/1/classes/Country/" + wantedCountry.objectId,
            success: ajaxLoadedSuccessfully,
            error: ajaxError
        });
    }

    function changeCountryPopulation() {
        jQuery.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country",
            success: changePopulation,
            error: ajaxError
        });
    }

    function changePopulation(data) {
        var wantedCountry;
        validation.checkForEmptyString(tb_editPopulation_countryName.val());
        validation.checkForEmptyString(tb_editPopulation_newPopulation.val());

        for (var c in data.results) {
            var country = data.results[c];

            if (country.countryName == tb_editPopulation_countryName.val()) {
                wantedCountry = country;
                break;
            }
        }

        $.ajax({
            method: "PUT",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            data: JSON.stringify(
                { "population": parseInt(tb_editPopulation_newPopulation.val()) }
            ),
            contentType: "application/json",
            url: "https://api.parse.com/1/classes/Country/" + wantedCountry.objectId,
            success: ajaxLoadedSuccessfully,
            error: ajaxError
        });
    }


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
            error: ajaxError
        });
    }

    function countriesLoaded(data) {
        for (var c in data.results) {
            var country = data.results[c];
            var countryItem = $('<li>');
            var countryLink = $("<ul>").text(country.countryName + " " + country.population);
            $(countryLink).data('country', country);
            countryLink.appendTo(countryItem);
            countryItem.appendTo($("#countries"));
        }

        ajaxLoadedSuccessfully();
    }

    function ajaxError() {
        noty({
            text: 'Cannot load AJAX data.',
            type: 'error',
            layout: 'topCenter',
            timeout: 5000
        }
        );
    }

    function ajaxLoadedSuccessfully() {
        noty({
            text: 'Countries are loaded.',
            layout: 'topCenter',
            timeout: 5000
        }
        );
    }
}());