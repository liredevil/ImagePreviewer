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

$('#addTag').click(function () {
    var name = $('#tag').val();
    $('#tag').empty();
    //addTag(name);
});


function AddTag(name) {
    $.ajax({
        type: 'POST',
        url: '/Image/AddTag/' + name,
        success: function (data) {
            var $select = $('#results');
            $select.empty();
            $('#results').html(data);
        }
    });
}

$(function () {
    $('#dropArea').filedrop({
        url: '@Url.Action("UploadFile")',
        allowedfiletypes: ['image/jpeg', 'image/png', 'image/gif'],
        allowedfileextensions: ['.jpg', '.jpeg', '.png', '.gif'],
        paramname: 'files',
        maxfiles: 1,
        maxfilesize: 5, // in MB
        dragOver: function () {
            $('#dropArea').addClass('active-drop');
        },
        dragLeave: function () {
            $('#dropArea').removeClass('active-drop');
        },
        drop: function () {
            $('#dropArea').removeClass('active-drop');
        },
        afterAll: function (e) {
            $('#dropArea').html('file(s) uploaded successfully');
        },
        uploadFinished: function (i, file, response, time) {
            $('#uploadList').append('<li class="list-group-item">' + file.name + '</li>')
        }
    })
})











