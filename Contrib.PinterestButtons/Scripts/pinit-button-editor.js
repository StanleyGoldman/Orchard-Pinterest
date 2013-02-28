(function ($) {
    $(function () {

        var checkbox = $("#AnyImage");
        var anyImageDependantField = $(".editor-pintitbutton-anyimage");

        var clickFunction = function () {
            if (checkbox.is(":checked")) {
                anyImageDependantField.hide();
            } else {
                anyImageDependantField.show();
            }
        };

        checkbox.on("click", clickFunction);

        clickFunction();
    });
})(jQuery);