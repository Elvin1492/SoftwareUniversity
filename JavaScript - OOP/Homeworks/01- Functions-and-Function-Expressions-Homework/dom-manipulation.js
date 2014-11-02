var domModule = (function() {

    function appendChild(childToAdd, parentSelector) {
        var parentElementList = document.querySelectorAll(parentSelector);
        for (var i = 0; length = parentElementList.length, i < length; i++) {
            var textnode = document.createTextNode("New list item added");
            childToAdd.appendChild(textnode);
            parentElementList[i].appendChild(childToAdd);
        }
    }

    function removeChild(childToRemove, parentSelector) {
        var parentElementList = document.querySelectorAll(parentSelector);
        for (var i = 0; length = parentElementList.length, i < length; i++) {
            var toRemove = parentElementList[i].querySelector(childToRemove);
            parentElementList[i].removeChild(toRemove);
        }
    }

    function addHandler(selector, eventType, eventHandler) {
        var  nodeList = document.querySelectorAll(selector);
        for (var i = 0; length = nodeList.length, i < length; i++) {
             nodeList[i].addEventListener(eventType, eventHandler);
        }
    }

    function retrieveElements(selector) {
        var nodeList = document.querySelectorAll(selector);
        var nodeListToString = "";
        for (var i = 0; length = nodeList.length, i < length; i++) {
            nodeListToString += nodeList[i].nodeName.toLowerCase() + "\n";
        }

        var paragraph = document.createElement("p");
        var nodeText = document.createTextNode(nodeListToString);
        paragraph.appendChild(nodeText);
        document.body.appendChild(paragraph);
        console.log(nodeList);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
})();

var liElement = document.createElement("li");

// Appends a list item to ul.birds-list
domModule.appendChild(liElement,".birds-list"); 

// Removes the first li child from the bird list
domModule.removeChild("li:first-child", "ul.birds-list");

// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function(){ alert("I'm a bird!");});

// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");

