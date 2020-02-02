var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                debugger;

                $.ajax({
                    url: "/SanPham/ListName",
                    dataType: "json",
                    data: {
                        term: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                debugger;
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                //mo file view
                debugger;
                $("#txtKeyword").val(ui.item.label);
              

                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<div>" + item.label + "</div>")
                    .appendTo(ul);
            };
    }
}
common.init();