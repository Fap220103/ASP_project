
document.addEventListener("DOMContentLoaded", function () {

    var groupDiv = document.querySelector('.signin-form');
    var formTitle = document.querySelector('.form-title');
    var formAlert = document.querySelector('.form-alert');


    if (formAlert.innerText.trim() !== "") {
        formTitle.style.visibility = 'hidden';
  
    } else {
        formTitle.style.display = 'block';
        formAlert.style.display = 'none';
    }
});
