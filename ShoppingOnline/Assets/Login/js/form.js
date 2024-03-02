document.addEventListener('DOMContentLoaded', function () {
    const formInputs = document.querySelectorAll('.form-input');

    formInputs.forEach(function (input) {
        input.addEventListener('focus', function () {
            input.nextElementSibling.classList.add('active');
        });

        input.addEventListener('blur', function () {
            if (input.value === '') {
                input.nextElementSibling.classList.remove('active');
            }
        });

        // Check initial value
        if (input.value !== '') {
            input.nextElementSibling.classList.add('active');
        }
    });
});



