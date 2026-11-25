document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector(".serve-form");
    const department = form?.querySelector("[name='Department']");

    document.querySelectorAll(".serve-select").forEach((link) => {
        link.addEventListener("click", () => {
            if (department) {
                department.value = link.dataset.department || "";
                department.dispatchEvent(new Event("change", { bubbles: true }));
            }
        });
    });

    if (!form) {
        return;
    }

    form.addEventListener("submit", (event) => {
        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
            form.classList.add("was-validated");
            return;
        }

        const button = form.querySelector(".serve-submit");
        const label = form.querySelector(".submit-label");
        const loading = form.querySelector(".submit-loading");
        if (button && label && loading) {
            button.disabled = true;
            label.hidden = true;
            loading.hidden = false;
        }
    });
});
