define(['todo-list/container', 'todo-list/section', 'todo-list/item'],
    function(Container, Section, Item) {
        'use strict';

        return {
            getContainer: function(title) {
                return new Container(title);
            },
            getSection: function(title) {
                return new Section(title);
            },
            getItem: function(content) {
                return new Item(content);
            }
        };
    }
);