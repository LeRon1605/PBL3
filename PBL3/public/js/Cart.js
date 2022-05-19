﻿let showToast = (status, message) => {
    const toastBody = document.getElementById('toast_body');
    if (status) {
        if (toastBody.classList.contains('bg-danger')) toastBody.classList.remove('bg-danger');
        if (!toastBody.classList.contains('bg-success')) toastBody.classList.add('bg-success');
    } else {
        if (!toastBody.classList.contains('bg-danger')) toastBody.classList.add('bg-danger');
        if (toastBody.classList.contains('bg-success')) toastBody.classList.remove('bg-success');
    }
    toastBody.innerText = message;
    $("#notification_toast").toast('show');
};
let deleteHandler = (e) => {
    let id = e.dataset.id
    let data = {
        id,
    };
    $.ajax({
        type: "POST",
        url: `/Cart/Delete`,
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            if (res.status) {
                e.parentElement.parentElement.remove();
            }
            showToast(res.status, res.message);
        }
    })
}
let UpdateCartProduct = (e, quantity) => {
    let ProductID = e.dataset.productid
    let data = {
        productID: ProductID,
        quantity
    }
    let inputQty = e.parentElement.parentElement.children[1];
    if (parseInt(inputQty.value) + quantity > 0) {
        $.ajax({
            type: "POST",
            url: `/Cart/Add`,
            data: JSON.stringify(data),
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                if (res.status) {
                    let oldQuantity = parseInt(inputQty.value);
                    inputQty.value = parseInt(inputQty.value) + quantity;
                    let money = e.parentElement.parentElement.parentElement.nextElementSibling;
                    money.innerText = (Number(money.innerText.trim().replace(/[^0-9-]+/g, "")) / oldQuantity * parseInt(inputQty.value)).toLocaleString() + ' đ';
                }
                else {
                    showToast(res.status, "Không đủ số lượng sản phẩm trong kho");
                }
            }
        })
    }
}