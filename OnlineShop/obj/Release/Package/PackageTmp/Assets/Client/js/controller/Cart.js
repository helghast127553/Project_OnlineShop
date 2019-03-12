$(document).ready(function () {
    let updateProductPrice = (productID, quantity) => {
        $.ajax({
            type: 'POST',
            url: '/Cart/UpdateProduct',
            data: { "productID": productID, "quantity": quantity },
            dataType: 'json',
            success: function (response) {
                $('td[data-id=' + productID + ']').html(response.Total + " Đ");
            }
        });
    };

    $('.quantity-right-plus').click(function (e) {
        debugger;
        e.preventDefault();
        let productID = $(this).attr('data-id');
        let quantity = parseInt($('input[data-id=' + productID + ']').val());   
        quantity++;
        $('input[data-id=' + productID + ']').val(quantity);
        updateProductPrice(productID, quantity);
    });

    $('.quantity-left-minus').click(function (e) {
        debugger;
        e.preventDefault();
        let productID = $(this).attr('data-id');
        let quantity = parseInt($('input[data-id=' + productID + ']').val());
        quantity == 1 ? 1 : quantity--;
        $('input[data-id=' + productID + ']').val(quantity);
        updateProductPrice(productID, quantity);
    });
});