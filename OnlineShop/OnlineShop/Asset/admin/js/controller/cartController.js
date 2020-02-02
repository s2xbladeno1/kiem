var giohang = {
    init: function () {
        giohang.regEvents();
    },
    regEvents: function () {
        $('#btnMuaTiep').off('click').on('click', function () {
            window.location.href = "/trang-chu";
        });
        $('#btnThanhToan').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('#btnCapNhat').off('click').on('click', function () {
            var listProduct = $('.txtSoLuong');
            var cartList = [];
            $.each(listProduct, function(i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    MauSanPham: {
                        MaSP: $(item).data('idsp'),
                        MaMau: $(item).data('idmau'),
                        MaTT: $(item).data('idtt'),
                        MaDL: $(item).data('iddl')
                    }
                });
            });
            $.ajax({
                url: '/GioHang/CapNhat',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "gio-hang"
                    }
                },
                error: function () {
                    alert('cập nhật lỗi');
                }
            })
        });

        $('#btnXoaGioHang').off('click').on('click', function () {
            $.ajax({
                url: '/GioHang/XoaGioHang',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang"
                    }
                },
                error: function () {
                    alert('xóa lỗi');
                }
                
            })
        });

        $('.XoaSP').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    masp: $(this).data('idsp'),
                    mamau: $(this).data('idmau'),
                    matt: $(this).data('idtt'),
                    madl: $(this).data('iddl')
                },
                url: '/GioHang/XoaSP',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang"
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
    }
}
giohang.init();