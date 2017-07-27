function LoadImportProductData() {
    //ajax
    $.ajax({
        url: 'GetImportProductList',
        dataType: 'json',
        type: 'post',
        success: function (string) {
            w2ui['ImportProductGrid'].add(string);
            
        },
        error: function (string) {
            alert("Lỗi");
        }
    });
}