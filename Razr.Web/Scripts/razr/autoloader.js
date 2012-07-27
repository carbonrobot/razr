// Razr autoloader
var Razr = (function ($, window, document, undefined) {

    // on ready, execute
    $(function () {
        Razr.init();
    });

    var setupHighlighting = function () {
        // add pretty print required classes to code elements
        $('pre').addClass('prettyprint');

        // enable pretty print
        prettyPrint();
    };

    return {
        init: function () {
            setupHighlighting();
        }
    };

})(jQuery, window, document);