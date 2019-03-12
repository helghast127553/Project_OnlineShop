$(document).ready(function () {
    let user = {
        init: function () {
            this.registerEvents();
        },
        registerEvents: function () {
            $('.btn-active').click(function (e) {
                e.preventDefault();
                let btn = $('.btn-active');
                let ID = btn.data('id');
                $.ajax({
                    type: 'POST',
                    url: '/Admin/User/ChangeStatus',
                    data: { "ID": ID },
                    dataType: 'json',
                    success: function (response) {
                        console.log(response);
                        if (response.status == true) {
                            btn.text('Kích hoạt tài khoản');
                        }
                        else {
                            btn.text('Khóa tài khoản');
                        }
                    }
                });
            });
        }
    };

    user.init();
});
