(function() {
    'use strict';
    require(['factory'], function(Factory) {

        function addSection() {
            var sectionName = document.getElementById('addSection-input').value;

            try {
                var section = Factory.getSection(sectionName);
                section.addToDOM();
                document.getElementById('addSection-input').value = '';
                var addSectionButton = document.getElementById('addItem-button' + section.getID());
                addSectionButton.addEventListener('click', additem);
            } catch (ex) {

            }
        }

        function addItem(){
        	var content = document.getElementById('addItem-input' + section.getID());
        	var item  = Factory.getItem(content);
        	section.addItem();
        }

        function hideSectioErrormessage(){
        	var errorMesage = document.getElementById('section-error-mesage');
                errorMesage.style.display = "none";
        }

        var container = Factory.getContainer('TODO List');
        container.addToDOM();

        document.getElementById('addSection-button').addEventListener('click', addSection);
        document.getElementById('addSection-input').addEventListener('click', hideSectioErrormessage);
        
    });
}());