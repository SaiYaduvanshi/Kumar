(function ($) {
    $(document).ready(function () {
        $('#my-menu').menufication(options);
    })
})(jQuery);
$('#my-menu').menufication({
    hideDefaultMenu: true,
    triggerWidth: 450,
    onlyMobile: true
})