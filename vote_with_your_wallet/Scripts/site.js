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

  // Collapse Navbar
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


  $('#submit-login').on('click', function () {
      console.log('submit login')
      $('#login-toggle').text('Logout')
      $('#sign-up').addClass('d-none')
  });

  $('#login-toggle').on('click', function () {

      if ($('#login-toggle').text() === 'Login') {
          $('#login-modal').modal('show');
      } else {
          $('#login-toggle').text('Login')
          $('#sign-up').removeClass('d-none')
      }
      
  });

})(jQuery); // End of use strict