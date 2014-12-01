/// <autosync enabled="true" />
/// <reference path="jquery.js" />

$(function () {
    var PARSE_APP_ID = "X9eM3h4B8Bxe9wstaLIzcIKRJiEuq0YRmeiGZQha";
    var PARSE_REST_API_KEY = "QH51xD4RQ5rQoip4UjRH7xlhqr9KYIhSrCVIvuk1";
    var liTowns = [];

    var addNameTb = $('#add_country_name');
    var addPopulationTb = $('#add_country_population');
    var addBtn = $('#add_btn').on("click", addCountry);

    var editCurrentName = $('#edit_current_name');
    var editNewName = $('#edit_new_name');
    var editNameBtn = $('#edit_name_btn');
    var editCurrentPopulation = $('#edit_current_population');
    var editNewPopulation = $('#edit_population_btn');
    var editPopulationBtn = $('#edit_population_btn');
    $("#print_countries").on("click", loadCountries);
    //loadCountries();

    function addCountry() {
        jQuery.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
            },
            data: JSON.stringify({
                countryName: addNameTb.val(),
                population: parseInt(addPopulationTb.val())
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
            success: countriesLoaded,
            error: ajaxError
        });
    }

    function loadCountries(state) {
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

    function getCountry(data) {

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