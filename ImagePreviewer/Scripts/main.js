$(function () {
    $.ajaxSetup({ cache: false });
    $(".compItem").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
})

$(document).ready(function () {
    $("a.fancyimage").fancybox();
});

$(function () {

    $('div#loading').hide();

    var page = 0;
    var _inCallback = false;
    function loadItems() {
        if (page > -1 && !_inCallback) {
            _inCallback = true;
            page++;
            $('div#loading').show();

            $.ajax({
                type: 'GET',
                url: '/Home/Index/' + page,
                success: function (data, textstatus) {
                    if (data != '') {
                        $("#scrolList").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                    $("div#loading").hide();
                }
            });
        }
    }
    // обработка события скроллинга
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {

            loadItems();
        }
    });
})















