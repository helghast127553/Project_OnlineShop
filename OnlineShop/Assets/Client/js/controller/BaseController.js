$(document).ready(function () {
    let common = {
        init: function () {
            this.registerEvent();
        },
        registerEvent: function () {
            $("#keyword").autocomplete({
                minLength: 0,
                source: function (request, response) {
                    $.ajax({
                        type: 'GET',
                        url: "/Product/ListName",
                        dataType: "json",
                        data: {
                            "keyword": request.term
                        },
                        success: function (res) {
                            response(res.data);
                        }
                    });
                },
                focus: function (event, ui) {
                    $("#keyword").val(ui.item.label);
                    return false;
                },
                select: function (event, ui) {
                    $("#keyword").val(ui.item.label);
                    return false;
                }
            })
                .autocomplete("instance")._renderItem = function (ul, item) {
                    return $("<li>")
                        .append("<a>" + item.label + "</a>")
                        .appendTo(ul);
                };
        }
    };

    common.init();
});
