$(document).ready(function () {
    let contact = {
        init: function () {
            this.registerEvents();
        },
        registerEvents: function () {
            $('#contactForm').validate({
                rules: {
                    Name: {
                        required: true,
                        maxlength: 50
                    },
                    Phone: {
                        required: true,
                        number: true,
                        maxlength: 11,
                        minlength: 10
                    },
                    Address: {
                        required: true,
                        maxlength: 50
                    },
                    Email: {
                        required: true,
                        maxlength: 50,
                        email: true
                    },
                    Content: {
                        maxlength: 250
                    }
                },
                messages: {
                    Name: {
                        required: 'Họ tên không được để trống',
                        maxlength: 'Họ tên không được quá 50 kí tự'
                    },
                    Phone: {
                        required: 'Số điện thoại không được để trống',
                        number: 'Số điện thoại phải nhập số',
                        maxlength: 'Số điện thoại không được quá 11 số',
                        minlength: 'Số điện thoại phải ít nhất 10 số'
                    },
                    Address: {
                        required: 'Địa chỉ không được để trống',
                        maxlength: 'Địa chỉ không được quá 50 kí tự'
                    },
                    Email: {
                        required: 'Địa chỉ email không được để trống',
                        maxlength: 'Địa chỉ email không được quá 50 kí tự',
                        email: 'Địa chỉ email không hợp lệ'
                    },
                    Content: {
                        maxlength: 'Nội dung không được quá 250 kí tự'
                    }
                }
            });
            $('#btnSend').click(function () {
                if ($('#contactForm').valid()) {
                    let dataForm = $('#contactForm').serialize();
                    $.ajax({
                        type: 'POST',
                        url: '/Contact/Send',
                        data: dataForm,
                        dataType: 'json',
                        success: function (response) {
                            if (response.status === true) {
                                alert('Gửi thành công');
                                $('#contactForm').reset();
                            }
                        }
                    });
                }
            });
        }
    };
    contact.init();
});
