function LoadProductGrid() {

    var Type = []
    $.ajax({
        url: 'GetTypeOfProductList',
        dataType: 'json',
        async: false,
        type: 'post',
        success: function (string) {
            for (var i = 0; i < string.length ; i++) {
                Type.push({ id: string[i].MaLoai, text: string[i].TenLoai });
            }
        }
    });
    var brand = []
    $.ajax({
        url: 'GetBrandList',
        dataType: 'json',
        async: false,
        type: 'post',
        success: function (string) {
            for (var i = 0; i < string.length ; i++) {
                brand.push({ id: string[i].MaLoai, text: string[i].TenLoai });
            }
        }
    });
    $('#Productgrid').w2grid({
        name: 'ProductGrid',
        recid: 'MaNhap',
        show: {
            toolbar: true,
            footer: true,
            toolbarAdd : true,
            toolbarDelete: true,
            toolbarSave: true

        },
        searches: [
            { field: 'MaSP', caption: 'Import Code', type: 'int' },
            { field: 'TenSP', caption: 'Product Name', type: 'text' },
            { field: 'MaLoai', caption: 'Number', type: 'text' },
            { field: 'SoLuongTrongKho', caption: 'Price', type: 'text' },
            { field: 'DonGia', caption: 'Import Date', type: 'date' },
            { field: 'MaNSX', caption: 'ToTal money', type: 'text' },
            { field: 'TinhTrang', caption: 'ToTal money', type: 'text' }
        ],
        columns: [

            { field: 'MaSP', caption: 'Product Code', size: '20%', sortable: true, attr: 'align=center' },
            { field: 'TenSP', caption: 'Product Name', size: '20%', sortable: true, attr: 'align=center' },
            { field: 'MaLoai', caption: 'Type', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'list', items: Type, showAll: true } },
            { field: 'SoLuongTrongKho', caption: 'Number', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'DonGia', caption: 'Price', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'date' } },
            { field: 'MaNSX', caption: 'Brand', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'list', items: brand, showAll: true } },
            { field: 'TinhTrang', caption: 'Status', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'NoiDung', caption: 'Content', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'Hinh', caption: 'Image', size: '20%', sortable: true, attr: 'align=center' }
            
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

