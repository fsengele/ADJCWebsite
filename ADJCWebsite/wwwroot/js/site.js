// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector(".contact-form");

    if (!form) {
        return;
    }

    form.addEventListener("submit", (event) => {
        if (!form.checkValidity()) {
            event.preventDefault();
            form.classList.add("was-validated");
            return;
        }

        const submitButton = form.querySelector(".contact-submit");
        const submitLabel = form.querySelector(".submit-label");
        const submitLoading = form.querySelector(".submit-loading");

        if (submitButton && submitLabel && submitLoading) {
            submitButton.disabled = true;
            submitLabel.hidden = true;
            submitLoading.hidden = false;
        }
    });
});
