function LoadCustomerGrid() {
    $('#grid').w2grid({
        name: 'Customergrid',
        recid: 'MaKH',
        show: {
            toolbar: true,
            footer: true,
            toolbarDelete: true,
            toolbarSave: true

        },
        searches: [
            { field: 'MaKH', caption: 'Customer Code', type: 'int' },
            { field: 'TenKH', caption: 'Full Name', type: 'text' },
            { field: 'SDT', caption: 'Phone Number', type: 'text' },
            { field: 'DiaChi', caption: 'Address', type: 'text' },
            { field: 'Email', caption: 'Email', type: 'text' }
        ],
        columns: [

            { field: 'MaKH', caption: 'Customer Code', size: '20%', sortable: true, attr: 'align=center' },
            { field: 'TenKH', caption: 'Full Name', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'SDT', caption: 'Phone Number', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'DiaChi', caption: 'Address', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } },
            { field: 'Email', caption: 'Email', size: '20%', sortable: true, attr: 'align=center', editable: { type: 'text' } }
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
function Update()
{
    //alert(JSON.stringify(w2ui['Customergrid'].getChanges()));
    $.ajax({
        url: 'UpdateCustomer',
        data : {kh : w2ui['Customergrid'].getChanges()},
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

function Delete()
{
   
    $.ajax({
        url: 'DeleteCustomer',
        data: { MaKH: w2ui['Customergrid'].getSelection() },
        dataType: 'text',
        type: 'post',
        success: function (string) {
            if(string == '1')
            {
                alert("xóa thành công");
            }
            else {
                alert("lỗi");
            }
        }
    });
}

