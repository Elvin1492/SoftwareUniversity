define(['todo-list/validation', 'todo-list/section'], function(Validation, Section) {
    'use strict';

    var Container,
        containerInstance;

    Container = (function() {
        var _sections;

        function Container(title) {
            this.setTitle(title);
            this._sections = [];
        }

        Container.prototype.setTitle = function(title) {
            Validation.validateString(title, 'title');
            this._title = title;
        };

        Container.prototype.getTitle = function() {
            return this._title;
        };

        Container.prototype.addSection = function(section) {
            Validation.validateNonEmptyObject(section, Section, 'Section');
            this._sections.push(section);
        };

        Container.prototype.createElement = function() {
            var header = document.createElement('h1');
            header.innerHTML = this.getTitle();
            document.getElementById('wrapper').appendChild(header);

            var container = document.createElement('div');
            container.setAttribute('id', 'container');

            return container;
        };

        Container.prototype.createAddSectionField = function() {
            var addSectionField = document.createElement('div');
            addSectionField.setAttribute('class', 'add-new-sectionField');

            var input = document.createElement('input');
            input.setAttribute('id', 'addSection-input');
            input.setAttribute('placeholder', 'Title');

            var button = document.createElement('button');
            button.setAttribute('id', 'addSection-button');
            button.innerHTML = 'New Section';

            var errorMesage = document.createElement('div');
            errorMesage.setAttribute('id', 'section-error-mesage');
            errorMesage.setAttribute('class', 'error-mesage');
            var errorMesageText = document.createElement('span');
            errorMesageText.innerHTML = 'Please enter a title for the new section!'; 
            errorMesage.appendChild(errorMesageText);

            addSectionField.appendChild(input);
            addSectionField.appendChild(button);
            addSectionField.appendChild(errorMesage);

            return addSectionField;
        };

        Container.prototype.addToDOM = function() {
            var container = this.createElement();
            var addSectionField = this.createAddSectionField();

            document.getElementById('wrapper').appendChild(container);
            document.getElementById('wrapper').appendChild(addSectionField);
        };

        return Container;
    }());

    // TODO implement singelton pattern for instancing container only once;
    return Container;
});