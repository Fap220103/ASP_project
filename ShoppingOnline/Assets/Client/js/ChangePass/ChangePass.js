document.addEventListener('DOMContentLoaded', function () {
    const formInputs = document.querySelectorAll('.form-input-pass');

    formInputs.forEach(function (input) {
        const toggleIcon = input.nextElementSibling;

        input.addEventListener('focus', function () {
            toggleIcon.style.display = 'block';
        });

        input.addEventListener('blur', function () {
            if (input.value === '') {
                toggleIcon.style.display = 'none';
            }

        });

        // Check initial value
        if (input.value !== '') {
            toggleIcon.style.display = 'block';
        }
    });
});
