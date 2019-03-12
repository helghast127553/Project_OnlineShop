$(document).ready(function () {
    let user = {
        init: function () {
            this.loadProvince();
            this.registerEvents();
        },
        registerEvents: function () {
            $('#ddlProvince').change(function () {
                debugger;
                let id = $(this).val();
                if (id !== '') {
                    user.loadDistrict(parseInt(id));
                }
                else {
                    $('#ddlDistrict').html('');
                }
            });
        },
        loadProvince: function () {
            $.ajax({
                type: 'POST',
                url: '/User/LoadProvince',
                dataType: 'json',
                success: function (response) {
                    if (response.status === true) {
                        let html = '<option value="">---Chọn tỉnh thành---</option>';
                        let data = response.data;
                        $.each(data, function (index, item) {
                            html += '<option value="' + item.ID + '">"' + item.Name + '"</option>';
                        });
                        $('#ddlProvince').html(html);
                    }
                }
            });
        },

        loadDistrict: function (id) {
            $.ajax({
                type: 'POST',
                url: '/User/LoadDistrict',
                data: { "provinceID": id },
                dataType: 'json',
                success: function (response) {
                    if (response.status === true) {
                        let html = '<option value="">---Chọn quận huyện---</option>';
                        let data = response.data;
                        $.each(data, function (index, item) {
                            html += '<option value="' + item.ID + '">"' + item.Name + '"</option>';
                        });
                        $('#ddlDistrict').html(html);
                    }
                }
            });
        }
    };

    user.init();
});