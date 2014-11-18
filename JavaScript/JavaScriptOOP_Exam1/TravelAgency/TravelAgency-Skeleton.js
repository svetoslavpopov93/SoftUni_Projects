function processTravelAgencyCommands(commands) {
    'use strict';
    Function.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }

    var Validation = (function(){
        function CheckForEmptyString(str){
                if(str === ""){
                        throw new Error("Input string can not be empty.");
                    }
            };
            
            function CheckForNegativeNumber(num){
                if(parseFloat(num) < 0){
                    throw new Error("Number must be greater than zero!");
                    }
                };    
        return {
            CheckForEmptyString:CheckForEmptyString,
            CheckForNegativeNumber:CheckForNegativeNumber
            };
        }());
    
    var Models = (function() {

        var Destination = (function() {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }

            Destination.prototype.getLocation = function() {
                return this._location;
            }

            Destination.prototype.setLocation = function(location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            }

            Destination.prototype.getLandmark = function() {
                return this._landmark;
            }

            Destination.prototype.setLandmark = function(landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            }

            Destination.prototype.toString = function() {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            }

            return Destination;
        }());

        var Travel = (function () {
            function Travel(name, startDate, endDate, price) {
                if (this.constructor === Travel) {
                    throw new Error("Can't instantiate abstract class Travel.");
                }
                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);

            }
            
            Travel.prototype.setEndDate = function(endDate){
                if(endDate.constructor !== Date){
                        throw new Error("End date must be real Date object.");
                    }
                    this._endDate = endDate;};
            Travel.prototype.getEndDate = function(){
                return this._endDate;};
            Travel.prototype.setName = function(name){
                Validation.CheckForEmptyString(name);
                this._name = name;};
            Travel.prototype.getName = function(){return this._name;};
            Travel.prototype.setPrice = function(price){
                if(isNaN(price)){
                    throw new Error("Price can not be undefined!");
                    }
            Validation.CheckForNegativeNumber(price);
            var str = price.toFixed(2);
            this._price = str;};
            Travel.prototype.getPrice = function(){
                return this._price;};
            Travel.prototype.setStartDate = function(startDate){
                if(startDate.constructor !== Date){
                        throw new Error("Start date must be real Date object.");
                    }
                this._startDate = startDate;};
            Travel.prototype.getStartDate = function(){return this._startDate;};
            Travel.prototype.getCurrentStartDate = function(){
                var day = this.getStartDate().getDate();
                var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                var month = months[parseInt(this.getStartDate().getMonth())];
                var year = this.getStartDate().getFullYear();

                return day + "-" + month + "-" + year;
                };
                
            Travel.prototype.getCurrentEndDate = function(){
                var day = this.getEndDate().getDate();
                var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                var month = months[parseInt(this.getEndDate().getMonth())];
                var year = this.getEndDate().getFullYear();

                return day + "-" + month + "-" + year;
                };
            Travel.prototype.toString = function(){
            return " * " + this.constructor.name + ": name=" + this.getName() + ",start-date=" + this.getCurrentStartDate() + ",end-date=" + this.getCurrentEndDate() + ",price=" + this.getPrice();
                };
            return Travel;
        }());
        
        var Excursion = (function () {
            function Excursion(name, startDate, endDate,  price,  transport) {
                Travel.call(this, name, startDate, endDate,  price);
                this.setTransport(transport);
                this._transport = transport;
                this._destinations = [];
            };
            Excursion.extends(Travel);
            Excursion.prototype.addDestination = function (destination) { this._destinations.push(destination)};
            Excursion.prototype.getDestinations = function () { 
                var str = "";
                for(var i = 0; i < this._destinations.length; i++){
                        str += this._destinations[i].toString() + (i < (this._destinations.length - 1) ? ";" : "");
                    }

                return str;
                };
            Excursion.prototype.removeDestinations = function (destination) { 
                for(var i = 0; i < destinations.length; i++){
                        if(destinations[i] === destination){
                            destinations.splice(i, 1);
                            break;
                            }
                    }
                };
            Excursion.prototype.setTransport = function(tr){
                Validation.CheckForEmptyString(tr);
                this._transport = tr;};
            Excursion.prototype.getTransport = function(){return this._transport;};
                Excursion.prototype.toString = function(){
                    var tr = this._transport;
                    var dest = (this.getDestinations() !== "" ? this.getDestinations() : "-");
                    return Travel.prototype.toString.call(this) + ",transport=" + this.getTransport() + "\n ** Destinations: "
                + dest;
                    };

                return Excursion;
        }());

        var Vacation = (function(){
            //command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            //parseFloat(command["price"]), command["location"], command["accommodation"]
            function Vacation(name, startDate, endDate,price, location, accommodation){
                Travel.call(this, name, startDate, endDate, price);
                this.setAccommodation(accommodation);
                this.setLocation(location);
                }

            Vacation.extends(Travel);
            Vacation.prototype.setAccommodation = function(accommodation){
                if(accommodation !== undefined){
                        Validation.CheckForEmptyString(accommodation);
                    }
                this._accommodation = accommodation;};
            Vacation.prototype.getAccommodation = function(){return this._accommodation;};
            Vacation.prototype.setLocation = function(location){
                if(location === undefined){
                    throw new Error("Location can not be undefined!");
                    }
                Validation.CheckForEmptyString(location);
                this._location = location;};
            Vacation.prototype.getLocation = function(){return this._location;};
            Vacation.prototype.toString = function(){
                return Travel.prototype.toString.call(this) +
                ",location=" + this.getLocation() +
                (this.getAccommodation() ? ",accommodation=" + this.getAccommodation() : "");
            };

            return Vacation;
            }());

        var Cruise = (function(){
            function Cruise(name, startDate, endDate, price, transport, startDock){
                    Excursion.call(this, name, startDate, endDate,  price, "cruise liner");
                    this.setStartDock(startDock);
                };

            Cruise.extends(Excursion);
            Cruise.prototype.setStartDock = function(startDock){
                if(startDock !== undefined){
                Validation.CheckForEmptyString(startDock);
                }
                this._startDock = startDock;};
            Cruise.prototype.getStartDock = function(){return this._startDock;};
            Cruise.prototype.toString = function(){
                return Excursion.prototype.toString.call(this) + 
            (this.getStartDock() ? ",start-dock=" + this.getStartDock() : "");
                };

            return Cruise;
            }());

        return {
            Destination: Destination,
            Travel: Travel,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise
        }
    }());

    var TravellingManager = (function(){
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function() {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function(t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.getName() + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.getName() + ".";
            }

            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travelsQuery) {
                var queryString = "";

                if (travelsQuery.length > 0) {
                    queryString += travelsQuery.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand
            }
        }());

        var Command = (function() {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }

    var output = "";
    TravellingManager.init();

    commands.forEach(function(cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function() {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function(line) {
            arr.push(line);
        }).on('close', function() {
            console.log(processTravelAgencyCommands(arr));
        });
    }
})();