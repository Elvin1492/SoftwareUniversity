define(['todo-list/validation', 'todo-list/item'], function(Validation, Item) {
    'use strict';

    var Section;
    var sectionID;

    Section = (function() {
        var _items;
        sectionID = 0;

        function Section(title) {
        	sectionID++;
            this.setTitle(title);
            this._items = [];
            this._id = sectionID;
        }

        Section.prototype.setTitle = function(title) {
            Validation.validateString(title, 'title');
            this._title = title;
        };

        Section.prototype.getTitle = function() {
            return this._title;
        };

        Section.prototype.getID = function(){
        	return this._id;
        };

        Section.prototype.addItem = function() {
             var itemToaAdd = Item.createElement();
             var sectionToAdd = document.getElementById('section' + this.getID());
             sectionToAdd.appendChild(itemToaAd);
        };

        Section.prototype.createElement = function() {
            var section = document.createElement('div');
            section.setAttribute('id', 'section' + this.getID());
            section.setAttribute('class', 'section');
 
            var sectionTitle = document.createElement('h1');
            sectionTitle.setAttribute('class', 'section-title');
            sectionTitle.innerHTML = this.getTitle();

            section.appendChild(sectionTitle);

            return section;
        };

        Section.prototype.createAddItemField = function() {
            var addItemField = document.createElement('div');
            addItemField.setAttribute('class', 'add-new-itemField');

            var input = document.createElement('input');
            input.setAttribute('id', 'additem-input' + this.getID());
            input.setAttribute('placeholder', 'Add item...');

            var button = document.createElement('button');
            button.setAttribute('id', 'addItem-button' + this.getID());
            button.setAttribute('class', 'addItem-buttons');
            button.innerHTML = '+';

            var errorMessage = document.createElement('div');
            errorMessage.setAttribute('id', 'item-error-mesage');
            errorMessage.setAttribute('class', 'error-mesage');
            var errorMessageText = document.createElement('span');
            errorMessageText.innerHTML = 'Please enter a title for the new item!';
            errorMessage.appendChild(errorMessageText);

            addItemField.appendChild(input);
            addItemField.appendChild(button);
            addItemField.appendChild(errorMessage);

            return addItemField;
        };

        Section.prototype.addToDOM = function() {
            var section = this.createElement();
            var addItemField = this.createAddItemField();

            document.getElementById('container').appendChild(section);
            document.getElementById('container').appendChild(addItemField);

        };

        return Section;
    }());

    return Section;
});