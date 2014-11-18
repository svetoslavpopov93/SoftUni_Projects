var test = (function(){
    

Function.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }

var Person = (function () {
    function Person(name, age){
            this.setName(name);
            this.setAge(age);
        }

    Person.prototype.setName = function(name){this._name = name;};
    Person.prototype.getName = function(){return this._name;};
    Person.prototype.setAge = function(age){this._age = age;};
    Person.prototype.getAge = function(){return this._age;};

    return Person;
}());

var Student = (function(){
    function Student(name, age, num){
        Person.call(this, name, age);
        this.setNum(num);
        };

    Student.extends(Person);
    Student.prototype.setNum = function(num){this._num = num;};
    Student.prototype.getNum = function(){return this._num;};
    Student.prototype.toString = function(){return this.constructor.name;};

    return Student;
    }());

        var pesho = new Person("Pesho", 5);
        var goshy = new Student("Goshy", 5, 3);
        
        console.log(pesho.getName() + " " + pesho.getAge());
        console.log(goshy.toString());




        
        
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
        var destinations = [];
        var d= new Destination("Giurgevo", "smochevo");
        var d1 = new Destination("Smochevo", "giurgevo");

        function removeDest(destination) { 
                for(var i = 0; i < destinations.length; i++){
                        if(destinations[i] === destination){
                            destinations.splice(i, 1);
                            break;
                            }
                    }
                };

        destinations.push(d);
        destinations.push(d1);

        removeDest(d);

        console.log("'a");




    }());