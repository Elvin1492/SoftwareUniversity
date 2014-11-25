(function() {
    $(function() {
        var PARSE_APP_ID = "Jmj9zyCKBGaUu68XCLJmTVPfHP5EqkD8V1WllIve";
        var PARSE_REST_API_KEY = "7zoNr1hEM0MCoHSF3k0nTyB8zpe6i3UA12geb2Av";

        loadCountries();

        // add event on button for adding new countries
        $('#add-country-button').on('click', function() {
            var $countryName = $('#add-country').val();
            // check if name is not empty or whitespacess string
            if (/^\s*$/.test($countryName)) {
                addItemError();
                return;
            }

            addCountry($countryName);
            $('#add-country').val('');
        });

        // add event on button for adding new towns
        $('#add-town-button').on('click', function() {
            var $townName = $('#add-town').val();
            // check if name is not empty or whitespacess string
            if (/^\s*$/.test($townName)) {
                addItemError();
                return;
            }

            addTown($townName);
            $('#add-town').val('');
        });

        function loadCountries() {
            // clear existing items and load new list with added/edited/deleted countries
            $('#countries-list li').remove();
            $.ajax({
                method: "GET",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Country?order=name",
                success: countriesLoaded,
                error: ajaxError
            });
        }
        // draw countries on the page
        function countriesLoaded(data) {
            for (var c in data.results) {
                var country = data.results[c];
                var countryItem = $('<li>').attr('class', 'country-item');
                $(countryItem).data('country', country);
                // atach data about each country on the list item holding it
                var countryLink = $("<a href='#'>").text(country.name);
                $(countryLink).data('country', country);
                $(countryLink).on('click', loadTowns);
                // add a button for deleting a country and eventListener on it
                var deleteButton = $('<input/>').attr({
                    type: 'button',
                    value: 'Delete',
                    class: 'delete-country'
                });
                $(deleteButton).on('click', deleteCountry);
                // add a button for editing a country and eventListener on it
                var editButton = $('<input/>').attr({
                    type: 'button',
                    value: 'Edit',
                    class: 'edit-country'
                });
                $(editButton).on('click', editCountry);
                // append created link and buttons to the list item
                countryLink.appendTo(countryItem);
                editButton.appendTo(countryItem);
                deleteButton.appendTo(countryItem);
                // append list iteme to the coountry list
                countryItem.appendTo($("#countries-list"));
            }
        }

        function addCountry(countryName) {
            // format country name before making the AJAX request
            var countryNameFormated = formatString(countryName);
            $.ajax({
                method: "POST",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Country",
                data: JSON.stringify({
                    "name": countryNameFormated
                }),
                contentType: "application/json",
                // on success notify user  about changes and reload countries on the page 
                // so that the newly added countries could be displyed
                success: [addedSuccessfully, loadCountries],
                error: ajaxError
            });
        }

        function deleteCountry() {
            // take the country to be deleted from the list item data attribute holding the country
            // and add the same data to the pop-up dialog box
            var country = $(this).parent().data('country');
            $('#deleteCountry').data('country', country);
            $("#deleteCountry").dialog("open");
        }
        // a jQueryUI built-in functonality for confirming or canceling the deletion
        $("#deleteCountry").dialog({
            autoOpen: false,
            modal: true,
            buttons: {
                OK: function() {
                    // retrieving data about the country to be deleted from the dialog box data attribute
                    var country = $('#deleteCountry').data('country');
                    $.ajax({
                        method: "DELETE",
                        headers: {
                            "X-Parse-Application-Id": PARSE_APP_ID,
                            "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                        },
                        url: "https://api.parse.com/1/classes/Country/" + country.objectId,
                        // on success notify user  about changes and reload countries on the page 
                        // so that the newly added countries could be displyed
                        success: [deletedSuccessfully, loadCountries],
                        error: ajaxError
                    });
                    // chek if the deleted country is the one whose towns are currenty displayed 
                    // and hide the listed towns if it is
                    if ($('#towns h1').text() === country.name) {
                        $('#towns').hide();
                    }

                    $(this).dialog("close");
                },
                Cancel: function() {
                    $(this).dialog("close");
                }
            }
        });

        function editCountry() {
            // take the country to be edited from the list item data attribute holding the country
            // and add the same data to the pop-up dialog box
            var country = $(this).parent().data('country');
            // adding the country to be deleted name in the dialog box that's about to pop-up
            $('#newCountryName').val(country.name);
            $('#editCountry').data('country', country);
            $("#editCountry").dialog("open");
        }
        // a jQueryUI built-in functonality for confirming or canceling the editing
        $("#editCountry").dialog({
            autoOpen: false,
            modal: true,
            buttons: {
                OK: function() {
                    // retrieving data about the country to be deited from the dialog box data attribute
                    // get new country name from the input in the dialog box and format the new name
                    var country = $('#editCountry').data('country');
                    var newCountryName = $('#newCountryName').val();
                    var newNameFormaeted = formatString(newCountryName);
                    // validate if the new name is not empty or whitespaces
                    if (/^\s*$/.test(newNameFormaeted)) {
                        addItemError();
                        return;
                    }

                    $.ajax({
                        method: "PUT",
                        headers: {
                            "X-Parse-Application-Id": PARSE_APP_ID,
                            "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                        },
                        url: "https://api.parse.com/1/classes/Country/" + country.objectId,
                        data: JSON.stringify({
                            'name': newNameFormaeted
                        }),
                        contentType: "application/json",
                        // on success notify user  about changes and reload countries on the page 
                        // so that the newly added countries could be displyed
                        success: [updatedSuccessfully, loadCountries],
                        error: ajaxError
                    });
                    // chek if the edited country is the one whose towns are currenty displayed 
                    // and edit the country name in the currently displayed list                 
                    if ($('#towns h1').text() === country.name) {
                        $('#towns h1').text(newNameFormaeted);
                    }

                    $(this).dialog("close");
                },
                Cancel: function() {
                    $(this).dialog("close");
                }
            }
        });

        function loadTowns() {
            // clear existing items and load new list with added/edited/deleted towns
            $('#towns-list li').remove();
            // get the country whose towns should be displayed form the data attribute 
            // of the list item link clicked
            var country = $(this).parent().data('country');
            $('#towns').hide();
            // assign country name to the heading of the towns list to be displayed
            // and to the data attribute of the towns heading div for later retrieving it
            $('#towns h1').text(country.name);
            $('#towns h1').data('country', country);

            var countryID = country.objectId;
            $.ajax({
                method: "GET",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: 'https://api.parse.com/1/classes/' +
                    'Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' +
                    countryID + '"}}&keys=name&order=name',
                success: townsLoaded,
                error: ajaxError
            });
            $('#towns').show();
        }

        function updateTowns() {
            // clear existing items and load new list with added/edited/deleted towns
            $('#towns-list li').remove();
            // get the country whose towns should be displayed form the data attribute 
            // of the towns div heading 
            var country = $('#towns h1').data('country');
            $('#towns').hide();
            $('#towns h1').text(country.name);

            var countryID = country.objectId;
            $.ajax({
                method: "GET",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: 'https://api.parse.com/1/classes/' +
                    'Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' +
                    countryID + '"}}&keys=name&order=name',
                success: townsLoaded,
                error: ajaxError
            });
            $('#towns').show();
        }
        // draw towns on the page
        function townsLoaded(data) {
            for (var t in data.results) {
                var town = data.results[t];
                var townItem = $('<li>').attr('class', 'town-item');
                $(townItem).data('town', town);
                // ataching current town to the lnik's data attribute and 
                //adding a link for a google search to it
                var townLink = $("<a />").text(town.name);
                townLink.attr('href', 'https://www.google.bg/#q=' + town.name);
                // adding a button for deleting a town and an event listener
                var deleteButton = $('<input/>').attr({
                    type: 'button',
                    value: 'Delete',
                    class: 'delete-town'
                });
                $(deleteButton).on('click', deleteTown);
                // adding a button for editing a town and an event listener
                var editButton = $('<input/>').attr({
                    type: 'button',
                    value: 'Edit',
                    class: 'edit-town'
                });
                $(editButton).on('click', editTown);
                // appending town link and buttons to the town list item
                townLink.appendTo(townItem);
                editButton.appendTo(townItem);
                deleteButton.appendTo(townItem);
                // apend town list item to the town list
                townItem.appendTo($("#towns-list"));
            }
        }

        function addTown(townName) {
            // format town's name to be added
            var townNameFormated = formatString(townName);
            // get country to which a town will bee added from he towns heading div data attribute
            var country = $('#towns h1').data('country');

            $.ajax({
                method: "POST",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Town",
                data: JSON.stringify({
                    'name': townNameFormated,
                    'country': {
                        "__type": "Pointer",
                        "className": "Country",
                        "objectId": country.objectId
                    }
                }),
                contentType: "application/json",
                // on success notify user  about changes and reload townns on the page 
                // so that the newly added towns could be displyed
                success: [addedSuccessfully, updateTowns],
                error: ajaxError
            });
        }

        function deleteTown() {
            // get town to  be deleted from the town list item data attribute clicked
            var town = $(this).parent().data('town');
            // add data attribute with current town to the dialog pop-up box
            $('#deleteTown').data('town', town);
            $("#deleteTown").dialog("open");
        }
        // a jQueryUI built-in functonality for confirming or canceling the deleting
        $("#deleteTown").dialog({
            autoOpen: false,
            modal: true,
            buttons: {
                OK: function() {
                    // get town to be delted from the dialog box pop-up data attribute
                    var town = $('#deleteTown').data('town');
                    $.ajax({
                        method: "DELETE",
                        headers: {
                            "X-Parse-Application-Id": PARSE_APP_ID,
                            "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                        },
                        url: "https://api.parse.com/1/classes/Town/" + town.objectId,
                        // on success notify user  about changes and reload townns on the page 
                        // so that the newly added towns could be displyed
                        success: [deletedSuccessfully, updateTowns],
                        error: ajaxError
                    });

                    $(this).dialog("close");
                },
                Cancel: function() {
                    $(this).dialog("close");
                }
            }
        });

        function editTown() {
            // get town to  be edited from the town list item data attribute clicked
            // and add the same data to the pop-up dialog box
            var town = $(this).parent().data('town');
            // adding the country to be deleted name in the dialog box that's about to pop-up
            $('#newTownName').val(town.name);
            $('#editTown').data('town', town);
            $("#editTown").dialog("open");
        }

        $("#editTown").dialog({
            autoOpen: false,
            modal: true,
            buttons: {
                OK: function() {
                    // get town to be edited from the dialog pop-up box data attribute
                    var town = $('#editTown').data('town');
                    // get new town name from the dialog box input format it and check
                    // if it's empty string or whitespace
                    var newTownName = $('#newTownName').val();
                    var newNameFormaeted = formatString(newTownName);
                    if (/^\s*$/.test(newNameFormaeted)) {
                        addItemError();
                        return;
                    }

                    $.ajax({
                        method: "PUT",
                        headers: {
                            "X-Parse-Application-Id": PARSE_APP_ID,
                            "X-Parse-REST-API-Key": PARSE_REST_API_KEY
                        },
                        url: "https://api.parse.com/1/classes/Town/" + town.objectId,
                        data: JSON.stringify({
                            'name': newNameFormaeted
                        }),
                        contentType: "application/json",
                        // on success notify user  about changes and reload townns on the page 
                        // so that the newly added towns could be displyed
                        success: [updatedSuccessfully, updateTowns],
                        error: ajaxError
                    });

                    $(this).dialog("close");
                },
                Cancel: function() {
                    $(this).dialog("close");
                }
            }
        });
        // a custom functon for formating a string making its first char uppercase and trimming it
        function formatString(string) {
            var trimmed = string.trim();
            return trimmed.charAt(0).toUpperCase() + string.slice(1);
        }
        // noty function for succssfuly added item
        function addedSuccessfully() {
            noty({
                text: 'Item added successfully',
                type: 'success',
                layout: 'topCenter',
                timeout: 2000
            });
        }
        // noty function for succssfuly deleted item
        function deletedSuccessfully() {
            noty({
                text: 'Item deleted successfully',
                type: 'success',
                layout: 'topCenter',
                timeout: 2000
            });
        }
        // noty function for succssfuly edited item
        function updatedSuccessfully() {
            noty({
                text: 'Item updated successfully',
                type: 'success',
                layout: 'topCenter',
                timeout: 2000
            });
        }
        // noty function for and AJAX request error
        function ajaxError() {
            noty({
                text: 'An error occured.',
                type: 'error',
                layout: 'topCenter',
                timeout: 2000
            });
        }
        // noty function for an invalid item name error
        function addItemError() {
            noty({
                text: 'Text can not be empty',
                type: 'error',
                layout: 'topCenter',
                timeout: 1000
            });
        }
    });
}());