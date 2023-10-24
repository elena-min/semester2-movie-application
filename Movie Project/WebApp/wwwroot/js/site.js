// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('.star').click(function () {
        $('.star').removeClass('active');
        $(this).addClass('active');
        var ratingValue = $(this).data('value');
        $('#rating-value').val(ratingValue);
    });
});
