var donHang = {
    init: function () {
        donHang.regEvents();
    },
    regEvents: function () {
        $('#btnCapNhat').off('click').on('click', function (e) {
            e.preventDefault();
            var tinhtrang = $('select[data-tt=tinhtrang]').val();
            $.ajax({
                data: {
                    madh: $(this).data('iddh'),
                    tt: tinhtrang
                },
                url: '/DonHang/CapNhat',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/DonHang/ListDonHang"
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });

        $('#choDuyet').off('click').on('click', function (e) {
            e.preventDefault();
            var tinhtrang = 'Chờ duyệt';
            $.ajax({
                data: {
                    tt: tinhtrang
                },
                url: '/DonHang/JsonListDHTheoTrangThai',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/DonHang/ListDonHang?tt=" + tinhtrang + "";
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });

        $('#daDuyet').off('click').on('click', function (e) {
            e.preventDefault();
            var tinhtrang = 'Đã duyệt';
            $.ajax({
                data: {
                    tt: tinhtrang
                },
                url: '/DonHang/JsonListDHTheoTrangThai',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/DonHang/ListDonHang?tt=" + tinhtrang + "";
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });

        $('#dangGiao').off('click').on('click', function (e) {
            e.preventDefault();
            var tinhtrang = 'Đang giao';
            $.ajax({
                data: {
                    tt: tinhtrang
                },
                url: '/DonHang/JsonListDHTheoTrangThai',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/DonHang/ListDonHang?tt=" + tinhtrang + "";
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
        $('#daNhanHang').off('click').on('click', function (e) {
            e.preventDefault();
            var tinhtrang = 'Đã nhận hàng';
            $.ajax({
                data: {
                    tt: tinhtrang
                },
                url: '/DonHang/JsonListDHTheoTrangThai',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/DonHang/ListDonHang?tt=" + tinhtrang + "";
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
        $('#Huy').off('click').on('click', function (e) {
            e.preventDefault();
            var tinhtrang = 'Hủy';
            $.ajax({
                data: {
                    tt: tinhtrang
                },
                url: '/DonHang/JsonListDHTheoTrangThai',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/DonHang/ListDonHang?tt=" + tinhtrang + "";
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
    }
}
donHang.init();