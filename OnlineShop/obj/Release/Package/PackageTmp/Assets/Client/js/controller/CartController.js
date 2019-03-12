$(document).ready(function () {
    let cart = {
        init: function () { },
        regEvents: function () {
            $('#btnContinue').off('click').on('click', function () {
                window.location.href = '/';
            });

            $('#btnPayment').off('click').on('click', function () {
                window.location.href = '/thanh-toan'
            });
        }
    };

    cart.regEvents();
});

