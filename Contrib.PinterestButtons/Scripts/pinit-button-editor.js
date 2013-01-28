(function ($) {
    $(function () {

        var checkbox = $("#AnyImage");
        var anyImageDependantField = $(".editor-pintitbutton-anyimage");

        var clickFunction = function () {
            if (checkbox.is(":checked")) {
                anyImageDependantField.show();
            } else {
                anyImageDependantField.hide();
            }
        };

        checkbox.on("click", clickFunction);

        clickFunction();
    });
})(jQuery);