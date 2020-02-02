var Lock = {
    init: function () {
        Lock.regEvents();
    },
    regEvents: function () {
        $('.Lock').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    id: $(this).data('iduser'),
                    tt: $(this).data('tt')
                },
                url: '/Admin/User/Lock',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/User/Index"
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });

        $('#MEMBER').off('click').on('click', function (e) {
            e.preventDefault();
            var tv = 'MEMBER';
            $.ajax({
                data: {
                    group: tv
                },
                url: '/Admin/User/ListMember',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/User/Index?group=" + tv + "";
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });

        $('#AD').off('click').on('click', function (e) {
            e.preventDefault();
            var qtv = 'QTV';
            $.ajax({
                data: {
                    group: qtv
                },
                url: '/Admin/User/ListQTV',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Admin/User/Index?group=" + qtv + "";
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
    }
}
Lock.init();