function LoadImportProductGrid() {

    var product = []
    $.ajax({
        url: 'GetProductList',
        dataType: 'json',
        async: false,
        type: 'post',
        success: function (string) {
            for (var i = 0; i < string.length ; i++) {
                product.push({ id: string[i].MaSP, text: string[i].TenSP });
            }
        }
    });
    $('#grid').w2grid({
        name: 'ImportProductGrid',
        recid: 'MaNhap',
        show: {
            toolbar: true,
            footer: true,
            toolbarAdd : true,
            toolbarDelete: true,
            toolbarSave: true

        },
        searches: [
            { field: 'MaNhap', caption: 'Import Code', type: 'int' },
            { field: 'TenSP', caption: 'Product Name', type: 'text' },
            { field: 'SoLuong', caption: 'Number', type: 'text' },
            { field: 'DonGia', caption: 'Price', type: 'text' },
            { field: 'NgayNhap', caption: 'Import Date', type: 'date' },
            { field: 'TongTien', caption: 'ToTal money', type: 'text' }
        ],
        columns: [

            { field: 'MaNhap', caption: 'Import Code', size: '20%', sortable: true, attr: 'align=center' },
            { field: 'TenSP', caption: 'Product Name', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'list', items: product, showAll: true } },
            { field: 'SoLuong', caption: 'Number', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'DonGia', caption: 'Price', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'NgayNhap', caption: 'Import Date', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'date' } },
            { field: 'TongTien', caption: 'ToTal money', size: '20%', sortable: true, attr: 'align=center' },
            { field: 'GhiChu', caption: 'Note', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } }
        ],
        onDelete: function (event) {
            console.log('delete has default behavior');
            Delete();
        },
        onSave: function (event) {
            Update();
        }
    });
}
function Update() {
    //alert(JSON.stringify(w2ui['Customergrid'].getChanges()));
    $.ajax({
        url: 'UpdateImportProductList',
        data: { kh: w2ui['ImportProductGrid'].getChanges() },
        dataType: 'text',
        type: 'post',
        success: function (string) {
            if (string == '1') {
                alert("cập nhật thành công");
            }
            else {
                alert("lỗi");
            }
        },
        error: function (loi) {
            alert("Lỗi");
        }
    });
}

function Delete() {

    $.ajax({
        url: 'DeleteImportProduct',
        data: { MaKH: w2ui['ImportProductGrid'].getSelection() },
        dataType: 'text',
        type: 'post',
        success: function (string) {
            if (string == '1') {
                alert("xóa thành công");
            }
            else {
                alert("lỗi");
            }
        }
    });
}

