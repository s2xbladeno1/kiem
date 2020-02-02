var loc = {
    init: function () {
        loc.regEvents();
    },
    regEvents: function () {
        $('.Loc').off('click').on('click', function (e) {
            e.preventDefault();
            var iddmsp = $(this).data('iddmsp');
            $.ajax({
                data: {
                    iddmsp: $(this).data('iddmsp'),
                    giaMin: $(this).data('giaMin'),
                    giaMax: $(this).data('giaMax')
                },
                url: '/SanPham/LocSanPham',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/danh-muc-san-pham?iddmsp=" + iddmsp + " "
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
    }
}
loc.init();