var theToggle = document.getElementById('toggle');

// based on Todd Motto functions
// https://toddmotto.com/labs/reusable-js/

// hasClass
function hasClass(elem, className) {
    return new RegExp(' ' + className + ' ').test(' ' + elem.className + ' ');
}
// addClass
function addClass(elem, className) {
    if (!hasClass(elem, className)) {
        elem.className += ' ' + className;
    }
}
// removeClass
function removeClass(elem, className) {
    var newClass = ' ' + elem.className.replace( /[\t\r\n]/g, ' ') + ' ';
    if (hasClass(elem, className)) {
        while (newClass.indexOf(' ' + className + ' ') >= 0 ) {
            newClass = newClass.replace(' ' + className + ' ', ' ');
        }
        elem.className = newClass.replace(/^\s+|\s+$/g, '');
    }
}
// toggleClass
function toggleClass(elem, className) {
    var newClass = ' ' + elem.className.replace( /[\t\r\n]/g, " " ) + ' ';
    if (hasClass(elem, className)) {
        while (newClass.indexOf(" " + className + " ") >= 0 ) {
            newClass = newClass.replace( " " + className + " " , " " );
        }
        elem.className = newClass.replace(/^\s+|\s+$/g, '');
    } else {
        elem.className += ' ' + className;
    }
}

theToggle.onclick = function() {
    toggleClass(this, 'on');
    return false;
};

$(document).ready(function () {
    /* Variables */
    var navigation = $('.navigation');
    var toggleBtn = $('.toggle-btn');
    var menuLevel2 = $('.menu-level-2');
    var menuLevel3 = $('.menu-level-3');
    var body = $('body');
    var temp = true;

    $(document).scroll(function () {
        $('.menu-level-1 > .menu-list-1 > .list-item').addClass("active");
        navigation.attr('style', '    box-shadow: 0 .250rem 1rem rgba(0, 0, 0, .095);');
    });

    $(document).scroll(function () {
        if (pageYOffset == 0) {
            $('.menu-level-1 > .menu-list-1 > .list-item').removeClass("active");
            navigation.attr('style', ' ');
        }
    });
    menuLevel2.addClass('none');
    menuLevel3.addClass('none');
    toggleBtn.click(function () {
        body.toggleClass('active');
        navigation.toggleClass('active');
      /*  $(this).toggleClass('active');*/
        menuLevel2.removeClass('block');
        menuLevel3.removeClass('block');
        $(' .menu-list-1 > .list-item > .item-icon').removeClass('active');
    });

    if ($(window).width() <= 768) {
        menuLevel2.addClass('none');
        menuLevel3.addClass('none');
        navigation.attr('style', ' ');

    }
    else {
        menuLevel2.addClass('flex');
        menuLevel3.addClass('flex');
    }

    $(window).resize(function () {
        if ($(window).width() <= 768) {
            navigation.attr('style', ' ');
            $(' .menu-list-1 > .list-item > .item-icon').removeClass('active');

            menuLevel2.removeClass('block');
            menuLevel3.removeClass('block');
            menuLevel2.addClass('none');
            menuLevel3.addClass('none');
            menuLevel2.removeClass('flex');
            menuLevel3.removeClass('flex');
            temp = true;
        }
        else {
            body.removeClass('active');
            menuLevel2.removeClass('block');
            menuLevel3.removeClass('block');
            menuLevel2.addClass('flex');
            menuLevel3.addClass('flex');
            $(' .menu-list-1 > .list-item > .item-icon').removeClass('active');
            $('.menu-list-2 > .list-item > img').removeClass('active');
            navigation.removeClass('active');
            toggleBtn.removeClass('active');

            temp = false;

        }

    });

    if (temp) {
        $('.menu-list-1 > .list-item').on('click', function () {
            $(' .item-icon', this).toggleClass('active');
            $(this).siblings('.menu-level-2').toggleClass('block');
            $('.menu-list-2').addClass('active');
            if (menuLevel3.hasClass('block')) {
                menuLevel3.removeClass('block');
               $('.menu-list-2 > .list-item > img').removeClass('active');
            }

        });
        $('.menu-list-2 > .list-item').on('click', function () {
            $('> img', this).toggleClass('active');
            $(this).siblings('.menu-level-3').toggleClass('block');
        });
    }


});

