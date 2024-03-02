function increaseValue(quantityInputID) {
    var value = parseInt(document.getElementById(quantityInputID).value, 10);
    value = isNaN(value) ? 0 : value;
    value++;
    document.getElementById(quantityInputID).value = value;
}

function decreaseValue(quantityInputID) {
    var value = parseInt(document.getElementById(quantityInputID).value, 10);
    value = isNaN(value) ? 0 : value;
    if (value > 1) {
        value--;
        document.getElementById(quantityInputID).value = value;
    }
}