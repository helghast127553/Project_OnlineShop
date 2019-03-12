let cart = {
    init: function () { },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = '/';
        });
    }
};

cart.regEvents();
