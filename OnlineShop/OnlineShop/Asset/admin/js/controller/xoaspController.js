var xoasp = {
    init: function () {
        xoasp.regEvents();
    },
    regEvents: function () {
        //Xóa CTSP
        $('.Xoa').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    masp: $(this).data('idsp'),
                    mamau: $(this).data('idmau'),
                    matt: $(this).data('idtt'),
                    madl: $(this).data('iddl')
                },
                url: '/Admin/SanPham/XoaSP',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert('Xóa thành công');
                        window.location.href = "/Admin/SanPham/ListSanPham"
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
        
        //Xóa SP
        $('.DelSP').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    masp: $(this).data('idsp')
                },
                url: '/Admin/SanPham/DelSP',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert('Xóa thành công');
                        window.location.href = "/Admin/SanPham/Index"
                    }
                    else {
                        alert('Không thể xóa vì tồn tại 1 chi tiết sản phẩm liên kết với sản phẩm này');
                    }
                }
            })
        });

        //Xoá DMSP
        $('.del').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    iddmsp: $(this).data('iddmsp')
                },
                url: '/Admin/SanPham/XoaDMSP',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert('Xóa thành công');
                        window.location.href = "/Admin/SanPham/DanhMucSanPham";
                    }
                    else {
                        alert('Không thể xóa vì danh mục này có chứa sản phẩm');
                    }
                }
            })
        });

        //Xóa SP trong nhập hàng
        $('.XoaItem').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    manh: $(this).data('idnh'),
                    masp: $(this).data('idsp'),
                    mamau: $(this).data('idmau'),
                    matt: $(this).data('idtt'),
                    madl: $(this).data('iddl')
                },
                url: '/Admin/NhapHang/XoaItem',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert('Xóa thành công');
                        window.location.href = "/Admin/NhapHang/ChiTietNhapHang?manh=" + manh + ""
                    }
                    else {
                        alert('lỗi');
                    }
                }
            })
        });
    }
}
xoasp.init();