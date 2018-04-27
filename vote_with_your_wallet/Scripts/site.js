(function($) {
  "use strict"; // Start of use strict

    // Smooth scrolling using jQuery easing
    $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function() {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: (target.offset().top - 57)
                }, 1000, "easeInOutExpo");
                return false;
            }
        }
    });

    // Closes responsive menu when a scroll trigger link is clicked
    $('.js-scroll-trigger').click(function() {
        $('.navbar-collapse').collapse('hide');
    });

    // Activate scrollspy to add active class to navbar items on scroll
    $('body').scrollspy({
        target: '#mainNav',
        offset: 57
    });

    // Collapse Navbar for different styled navbar when scrolling down
    var navbarCollapse = function() {
        if ($("#mainNav").offset().top > 100) {
            $("#mainNav").addClass("navbar-shrink");
        } else {
            $("#mainNav").removeClass("navbar-shrink"); 
        }
    };

    // Initial call of navbarCollapse
    navbarCollapse();

    // Call navbarCollapse when page is scrolled
    $(window).scroll(navbarCollapse);

    // Reset show modal on login button click
    $('#login-button').on('click', function () {
        $('#login-modal').modal('show');
    });
    
    // Update supporter when cause is supported 
    $('.support-button').on('click', function () {
        var targetBaseId = $(this).attr('for')

        // Update supporter count
        var targetCountIt = targetBaseId + '-cnt';
        var currentCount = $('#' + targetCountIt).text();
        var newCount = parseInt(currentCount) + 1;
        $('#' + targetCountIt).text(newCount)

        // Add name to the beginning of supporters (static atm)
        $('#' + targetBaseId + '-names > tbody > tr:first').before('<tr><td scope= "row" >Peter Barclay</td></tr>');
    });

    // Logout on button click logout
    $("#logout-button").on('click', function () {
        var request = $.ajax({
            type: 'POST',
            url: '/Account/LogOff',
            
        })

        request.done(function (message) {
            location.reload(true)
        })

        request.fail(function () {
            console.log('logout fail')
        })
    })

    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = $('.needs-validation'); 
        
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {

            // Input validation while typing
            form.addEventListener('input', function (event) {
                if (event.target.checkValidity() === false) {
                    event.target.classList.add('is-invalid');
                } else {
                    event.target.classList.remove('is-invalid');
                    event.target.classList.add('is-valid');
                }

            }, false);

            // Input validation and close blocking on submit
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });

       

    }, false);

})(jQuery); // End of use strict
