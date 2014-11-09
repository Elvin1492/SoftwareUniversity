function processRestaurantManagerCommands(commands) {
    'use strict';

    // ------------------------------------------------------------
    // Property for simple inheritance 
    // ------------------------------------------------------------
    Object.prototype.extends = function(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    // ------------------------------------------------------------
    // Enumeration for recepie's unit type
    // ------------------------------------------------------------
    var Units = {
        MILLIETERS: 'ml',
        GRAMS: 'g',
        NONE: 'none',
    };

    // ------------------------------------------------------------
    // Custom function for cheking if a recipe type exists in an array
    // ------------------------------------------------------------
    function inArray(needle, haystack) {
        var length = haystack.length;
        for (var i = 0; i < length; i++) {
            if (haystack[i].constructor.name == needle) {
                return true;
            }
        }

        return false;
    }

    // ------------------------------------------------------------
    // VALIDATION
    // ------------------ NON-EMPTY STRING ------------------------
    Object.prototype.validateNonEmptyString = function(value, variableName) {
        if (typeof(value) != 'string' || !value) {
            throw new Error('The ' + variableName + ' is required.');
        }
    };

    // ------------------ POSITIVE NUMBER ------------------------
    Object.prototype.validateNumber = function(value, variableName) {
        var MIN_VALUE = 0;
        var MAX_VALUE = Number.MAX_VALUE;

        if (typeof(value) != 'number') {
            throw new Error(variableName + ' should be a number.');
        }

        if (value <= MIN_VALUE || value > MAX_VALUE) {
            throw new Error('The ' + variableName + 'must be positive.');
        }
    };

    // ------------------ POSITIVE NUMBER IN RANGE ------------------------
    Object.prototype.validateNumberRange = function(value, variableName, minValue, maxValue) {
        if (typeof(value) != 'number') {
            throw new Error(variableName + ' should be a number.');
        }

        if (value < minValue || value > maxValue) {
            throw new Error(variableName + ' should be number in the range [' +
                minValue + '...' + maxValue + '].');
        }
    };

    // ------------------ POSITIVE INTEGER NUMBER ------------------------
    Object.prototype.validateIntegerNumber = function(value, variableName) {
        var MIN_VALUE = 0;
        var MAX_VALUE = Number.MAX_VALUE;

        if (typeof(value) != 'number') {
            throw new Error(variableName + ' should be a number.');
        }

        if (value !== parseInt(value, 10)) {
            throw new Error(variableName + ' should be integer.');
        }

        if (value < MIN_VALUE || value > MAX_VALUE) {
            throw new Error('The ' + variableName + 'must be positive.');
        }
    };

    // ------------------ POSITIVE INTEGER NUMBER IN RANGE ------------------------
    Object.prototype.validateIntegerNumberRange = function(value, variableName, minValue, maxValue) {
        if (typeof(value) != 'number') {
            throw new Error(variableName + ' should be a number.');
        }

        if (value !== parseInt(value, 10)) {
            throw new Error(variableName + ' should be integer. ');
        }

        if (value < minValue || value > maxValue) {
            throw new Error(variableName + ' should be number in the range [' +
                minValue + '...' + maxValue + '].');
        }
    };

    // ------------------ BOOLEAN VARIABLE ------------------------
    Object.prototype.validateBoolean = function(value, variableName) {
        if (typeof(value) != 'boolean') {
            throw new Error(variableName + " should be a boolean value.");
        }
    };

    // ------------------ NON EMPTY OBJCT------------------------
    Object.prototype.validateNonEmptyObject = function(value, className, variableName) {
        if (!(value instanceof className)) {
            throw new Error(variableName + " should be non-empty " +
                className.prototype.constructor.name + ".");
        }
    };

    var RestaurantEngine = (function() {
        var _restaurants, _recipes;

        function initialize() {
            _restaurants = [];
            _recipes = [];
        }

        var Restaurant = (function() {
            var _recipesList;

            function Restaurant(name, location) {
                this.setName(name);
                this.setLocation(location);
                this._recipesList = [];
            }

            Restaurant.prototype.setName = function(name) {
                this.validateNonEmptyString(name, 'name');
                this._name = name;
            };

            Restaurant.prototype.getName = function() {
                return this._name;
            };

            Restaurant.prototype.setLocation = function(location) {
                this.validateNonEmptyString(location, 'location');
                this._location = location;
            };

            Restaurant.prototype.getLocation = function() {
                return this._location;
            };


            Restaurant.prototype.addRecipe = function(recipe) {
                this.validateNonEmptyObject(recipe, Recipe, 'Recipe');
                this._recipesList.push(recipe);

            };

            Restaurant.prototype.removeRecipe = function(recipe) {
                this.validateNonEmptyObject(recipe, Recipe, 'Recipe');
                var index = this._recipesList.indexOf(recipe);
                if (index > -1) {
                    this._recipesList.splice(index, 1);
                }
            };

            Restaurant.prototype.toString = function() {
                return '***** ' + this.getName() + ' - ' + this.getLocation() + ' *****\n';
            };

            Restaurant.prototype.printRestaurantMenu = function() {

                var sortedMenu = this._recipesList.sort(function(a, b) {
                    if (a.constructor.name === b.constructor.name) {
                        return a.getName().localeCompare(b.getName());
                    }
                });

                var menu = Restaurant.prototype.toString.call(this);

                if (sortedMenu.length === 0) {
                    menu += 'No recipes... yet\n';
                }

                if (inArray('Drink', sortedMenu)) {
                    menu += '~~~~~ DRINKS ~~~~~\n';
                    for (var drink in sortedMenu) {
                        if (sortedMenu[drink] instanceof Drink) {
                            menu += sortedMenu[drink].toString() + '\n';
                        }
                    }
                }

                if (inArray('Salad', sortedMenu)) {
                    menu += '~~~~~ SALADS ~~~~~\n';
                    for (var salad in sortedMenu) {
                        if (sortedMenu[salad] instanceof Salad) {
                            menu += sortedMenu[salad].toString() + '\n';
                        }
                    }
                }

                if (inArray('MainCourse', sortedMenu)) {
                    menu += '~~~~~ MAIN COURSES ~~~~~\n';
                    for (var main in sortedMenu) {
                        if (sortedMenu[main] instanceof MainCourse) {
                            menu += sortedMenu[main].toString() + '\n';
                        }
                    }
                }

                if (inArray('Dessert', sortedMenu)) {
                    menu += '~~~~~ DESSERTS ~~~~~\n';
                    for (var dessert in sortedMenu) {
                        if (sortedMenu[dessert] instanceof Dessert) {
                            menu += sortedMenu[dessert].toString() + '\n';
                        }
                    }
                }

                return menu;
            };

            return Restaurant;
        }());

        var Recipe = (function() {
            function Recipe(name, price, calories, quantity, timeToPrepare) {
                if (this.constructor === Recipe) {
                    throw new Error("Can't instantiate abstract class Recipe.");
                }
                this.setName(name);
                this.setPrice(price);
                this.setCalories(calories);
                this.setQuantity(quantity);
                this.setTimeToPrepare(timeToPrepare);
            }

            Recipe.prototype._unit = Units.NONE;

            Recipe.prototype.getUnit = function() {
                return this._unit;
            };

            Recipe.prototype.setName = function(name) {
                this.validateNonEmptyString(name, 'name');
                this._name = name;
            };

            Recipe.prototype.getName = function() {
                return this._name;
            };

            Recipe.prototype.setPrice = function(price) {
                this.validateNumber(price, 'price');
                this._price = price;
            };

            Recipe.prototype.getPrice = function() {
                return this._price.toFixed(2);
            };

            Recipe.prototype.setCalories = function(calories) {
                this.validateIntegerNumber(calories, 'calories');
                this._calories = calories;
            };

            Recipe.prototype.getCalories = function() {
                return this._calories;
            };

            Recipe.prototype.setQuantity = function(quantity) {
                this.validateIntegerNumber(quantity, 'quantity');
                this._quantity = quantity;
            };

            Recipe.prototype.getQuantity = function() {
                return this._quantity;
            };

            Recipe.prototype.setTimeToPrepare = function(timeToPrepare) {
                //this.validateNumber(timeToPrepare, 'timeToPrepare');
                this._timeToPrepare = timeToPrepare;
            };

            Recipe.prototype.getTimeToPrepare = function() {
                return this._timeToPrepare;
            };


            Recipe.prototype.toString = function() {
                var recipe = '==  ' + this.getName() + ' == $' + this.getPrice() +
                    '\nPer serving: ' + this.getQuantity() + ' ' + this.getUnit() + ', ' +
                    this.getCalories() + ' kcal\n' + 'Ready in ' + this.getTimeToPrepare() + ' minutes';
                return recipe;
            };

            return Recipe;

        }());

        var Drink = (function() {
            function Drink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
                Recipe.call(this, name, price, calories, quantity, timeToPrepare);
                this.setIsCarbonated(isCarbonated);
            }

            Drink.extends(Recipe);

            Drink.prototype._unit = Units.MILLIETERS;

            Drink.prototype.setCalories = function(calories) {
                this.validateIntegerNumberRange(calories, 'calories', 0, 100);
                this._calories = calories;
            };

            Drink.prototype.setTimeToPrepare = function(timeToPrepare) {
                //this.validateIntegerNumberRange(timeToPrepare, 'timeToPrepare', 0, 20);
                this._timeToPrepare = timeToPrepare;
            };

            Drink.prototype.setIsCarbonated = function(isCarbonated) {
                this.validateBoolean(isCarbonated, 'carbonated');
                this._isCarbonated = isCarbonated;
            };

            Drink.prototype.getIsCarbonated = function() {
                return this._isCarbonated;
            };

            Drink.prototype.toString = function() {
                var drink = Recipe.prototype.toString.call(this);
                var carbonated = this.getIsCarbonated() ? 'yes' : 'no';
                drink += '\nCarbonated: ' + carbonated;
                return drink;
            };

            return Drink;
        }());

        var Meal = (function() {
            function Meal(name, price, calories, quantity, timeToPrepare, isVegan) {
                if (this.constructor === Meal) {
                    throw new Error("Can't instantiate abstract class Meal.");
                }
                Recipe.call(this, name, price, calories, quantity, timeToPrepare);
                this.setIsVegan(isVegan);
            }

            Meal.extends(Recipe);

            Meal.prototype._unit = Units.GRAMS;

            Meal.prototype.setIsVegan = function(isVegan) {
               // this.validateBoolean(isVegan, 'vegan');
                this._isVegan = isVegan;
            };

            Meal.prototype.getIsVegan = function() {
                return this._isVegan;
            };

            Meal.prototype.toggleVegan = function() {
                this._isVegan = !this._isVegan;
            };

            Meal.prototype.toString = function() {
                var isVegan = this.getIsVegan() ? '[VEGAN] ' : '';
                var meal = isVegan + Recipe.prototype.toString.call(this);
                return meal;
            };

            return Meal;

        }());

        var Dessert = (function() {
            function Dessert(name, price, calories, quantity, timeToPrepare, isVegan) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                this._withSugar = true;
            }

            Dessert.extends(Meal);

            Dessert.prototype.getIsWithSugar = function() {
                return this._withSugar;
            };

            Dessert.prototype.toggleSugar = function() {
                this._withSugar = !this._withSugar;
            };

            Dessert.prototype.toString = function() {
                var isWithSugar = !this.getIsWithSugar() ? '[NO SUGAR] ' : '';
                var dessert = isWithSugar + Meal.prototype.toString.call(this);
                return dessert;
            };

            return Dessert;

        }());

        var MainCourse = (function() {
            function MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                this.setType(type);
            }

            MainCourse.extends(Meal);

            MainCourse.prototype.setType = function(type) {
                this.validateNonEmptyString(type, 'type');
                this._type = type;
            };

            MainCourse.prototype.getType = function() {
                return this._type;
            };

            MainCourse.prototype.toString = function() {
                var mainCourse = '' + Meal.prototype.toString.call(this);
                mainCourse += '\nType: ' + this.getType();
                return mainCourse;
            };

            return MainCourse;
        }());

        var Salad = (function() {
            function Salad(name, price, calories, quantity, timeToPrepare, containsPasta) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare);
                this.setContainsPasta(containsPasta);
                this._isVegan = true;
            }


            Salad.extends(Meal);

            Salad.prototype.setContainsPasta = function(containsPasta) {
                this.validateBoolean(containsPasta, 'pasta');
                this._containsPasta = containsPasta;
            };

            Salad.prototype.getContainsPastta = function() {
                return this._containsPasta;
            };

            Salad.prototype.toString = function() {
                var salad = '' + Meal.prototype.toString.call(this);
                var containsPasta = this.getContainsPastta() ? 'yes' : 'no';
                salad += '\nContains pasta: ' + containsPasta;
                return salad;
            };

            return Salad;
        }());

        var Command = (function() {

            function Command(commandLine) {
                this._params = new Array();
                this.translateCommand(commandLine);
            }

            Command.prototype.translateCommand = function(commandLine) {
                var self, paramsBeginning, name, parametersKeysAndValues;
                self = this;
                paramsBeginning = commandLine.indexOf("(");

                this._name = commandLine.substring(0, paramsBeginning);
                name = commandLine.substring(0, paramsBeginning);
                parametersKeysAndValues = commandLine
                    .substring(paramsBeginning + 1, commandLine.length - 1)
                    .split(";")
                    .filter(function(e) {
                        return true;
                    });

                parametersKeysAndValues.forEach(function(p) {
                    var split = p
                        .split("=")
                        .filter(function(e) {
                            return true;
                        });
                    self._params[split[0]] = split[1];
                });
            }

            return Command;
        }());

        function createRestaurant(name, location) {
            _restaurants[name] = new Restaurant(name, location);
            return "Restaurant " + name + " created\n";
        }

        function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
            _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
            return "Recipe " + name + " created\n";
        }

        function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
            _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
            return "Recipe " + name + " created\n";
        }

        function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
            _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
            return "Recipe " + name + " created\n";
        }

        function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
            _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
            return "Recipe " + name + " created\n";
        }

        function toggleSugar(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            recipe = _recipes[name];

            if (recipe instanceof Dessert) {
                recipe.toggleSugar();
                return "Command ToggleSugar executed successfully. New value: " + recipe._withSugar.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleSugar is not applicable to recipe " + name + "\n";
            }
        }

        function toggleVegan(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }

            recipe = _recipes[name];
            if (recipe instanceof Meal) {
                recipe.toggleVegan();
                return "Command ToggleVegan executed successfully. New value: " +
                    recipe._isVegan.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleVegan is not applicable to recipe " + name + "\n";
            }
        }

        function printRestaurantMenu(name) {
            var restaurant;

            if (!_restaurants.hasOwnProperty(name)) {
                throw new Error("The restaurant " + name + " does not exist");
            }

            restaurant = _restaurants[name];
            return restaurant.printRestaurantMenu();
        }

        function addRecipeToRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.addRecipe(recipe);
            return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
        }

        function removeRecipeFromRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.removeRecipe(recipe);
            return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
        }

        function executeCommand(commandLine) {
            var cmd, params, result;
            cmd = new Command(commandLine);
            params = cmd._params;

            switch (cmd._name) {
                case 'CreateRestaurant':
                    result = createRestaurant(params["name"], params["location"]);
                    break;
                case 'CreateDrink':
                    result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["carbonated"]));
                    break;
                case 'CreateSalad':
                    result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["pasta"]));
                    break;
                case "CreateMainCourse":
                    result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]), params["type"]);
                    break;
                case "CreateDessert":
                    result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]));
                    break;
                case "ToggleSugar":
                    result = toggleSugar(params["name"]);
                    break;
                case "ToggleVegan":
                    result = toggleVegan(params["name"]);
                    break;
                case "AddRecipeToRestaurant":
                    result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "RemoveRecipeFromRestaurant":
                    result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "PrintRestaurantMenu":
                    result = printRestaurantMenu(params["name"]);
                    break;
                default:
                    throw new Error('Invalid command name: ' + cmdName);
            }

            return result;
        }

        function parseBoolean(value) {
            switch (value) {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    RestaurantEngine.initialize();
    commands.forEach(function(cmd) {
        if (cmd != "") {
            try {
                var cmdResult = RestaurantEngine.executeCommand(cmd);
                results += cmdResult;
            } catch (err) {
                results += err.message + "\n";
            }
        }
    });

    return results.trim();
}