define(['todo-list/validation'], function(Validation) {
    'use strict';

    var Item,
        itemID;

    Item = (function() {

        itemID = 0;
        function Item(content) {
            itemID++;
            this.setContent(content);
            this._status = false;
            this._id = itemID;
        }

        Item.prototype.setContent = function(content) {
            Validation.validateString(content, 'content');
            this._content = content;
        };

        Item.prototype.getContent = function() {
            return this._content;
        };

        Item.prototype.getID = function(){
            return this._id;
        };

        Item.prototype.createElement = function() {
            var item = document.createElement('div');
            item.setAttribute('id', 'item' + this.getID());
            item.setAttribute('class', 'section-item');
            item.innerHTML = this.getContent;

            return item;
        };


        Item.prototype.addToDOM = function() {
            var item = this.createElement();
 
            document.getElementById('container').appendChild(section);
            document.getElementById('container').appendChild(addItemField);
        };

        return Item;
    }());

    return Item;
});