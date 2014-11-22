(function() {
    $(document).ready((function() {
        var SLIDE_WIDTH = 900,
            SPEED = 6000;

        var currentPosition = 0,
            slides = $('.slide'),
            numberOfSlides = slides.length,
            slideShowInterval;

        //Set the timer for the images to move at given interval with given speed
        slideShowInterval = setInterval(changePosition, SPEED);

        slides.wrapAll('<div id="slidesHolder"></div>');

        slides.css('float', 'left');

        $('#slidesHolder').css('width', SLIDE_WIDTH * numberOfSlides);

        //Add navigation buttons to the slide
        $('#slideshow')
            .prepend('<span class="nav" id="leftNav">Move Left</span>')
            .append('<span class="nav" id="rightNav">Move Right</span>');

         // call the function for maniging navigation
         manageNav(currentPosition);  

         //tell the buttons what to do when clicked
		$('.nav').bind('click', function() {			
			//determine new position
			currentPosition = ($(this).attr('id')=='rightNav') ? currentPosition +1 : currentPosition-1;
										
			//hide/show controls
			manageNav(currentPosition);
			clearInterval(slideShowInterval);
			slideShowInterval = setInterval(changePosition, SPEED);
			moveSlide();
		});

        function manageNav(position) {
            //hide left arrow if position is first slide
            if (position === 0) {
                $('#leftNav').hide();
            } else {
                $('#leftNav').show();
            }
            //hide right arrow is slide position is last slide
            if (position === numberOfSlides - 1) {
                $('#rightNav').hide();
            } else {
                $('#rightNav').show();
            }
        }

        //changing image positon
        function changePosition() {
            if (currentPosition == numberOfSlides - 1) {
                currentPosition = 0;
                manageNav(currentPosition);
            } else {
                currentPosition++;
                manageNav(currentPosition);
            }
            moveSlide();
        }

        //moving images
        function moveSlide() {
            var header;
            //changing header
            switch (currentPosition) {
                case 0:
                    header = 'SOUTH PARK';
                    break;
                case 1:
                    header = 'FUTURAMA';
                    break;
                case 2:
                    header = 'AMERICAN DAD';
                    break;
                case 3:
                    header = 'FAMILY GUY';
                    break;
                case 4:
                    header = 'CLEVELAND SHOW';
                    break;
            }
            $('#slidesHolder')
                .animate({
                    'marginLeft': SLIDE_WIDTH * (-currentPosition)
                });
            $('#heading').text(header);
        }
    }));
}());