var repcmt = {
    init: function () {
        repcmt.regEvents();
    },
    regEvents: function () {
        $('.Rep').off('click').on('click', function (e) {
            e.preventDefault();
            var mabl = $(this).data('idbl');
            var masp = $(this).data('idsp');
            var mamau = $(this).data('idmau');
            var matt = $(this).data('idtt');
            var madl = $(this).data('iddl');
            var iddmsp = $(this).data('iddmsp');
            $.ajax({
                data: {
                    mabl: $(this).data('idbl'),
                    iddmsp: $(this).data('iddmsp'),
                    masp: $(this).data('idsp'),
                    mamau: $(this).data('idmau'),
                    matt: $(this).data('idtt'),
                    madl: $(this).data('iddl')
                },
                url: '/SanPham/GetNameToReply',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "chi-tiet-san-pham?iddmsp=" + iddmsp + "&masp=" + masp + "&mamau=" + mamau + "&matt=" + matt + "&madl=" + madl + "&mabl=" + mabl + "";
                    }
                }
            })
        });
    }
}
repcmt.init();