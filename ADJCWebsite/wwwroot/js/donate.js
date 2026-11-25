document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector(".donate-form");
    if (!form) return;

    const amountButtons = form.querySelectorAll(".donate-amount");
    const customAmount = form.querySelector("#customAmount");
    const selectedAmount = form.querySelector("#selectedAmount");

    const updateAmount = (value) => {
        const amount = Number.parseFloat(value);
        selectedAmount.textContent = Number.isFinite(amount) && amount > 0
            ? `${amount.toFixed(2).replace(".", ",")} €`
            : "—";
    };

    amountButtons.forEach((button) => {
        button.addEventListener("click", () => {
            amountButtons.forEach((item) => item.classList.remove("selected"));
            button.classList.add("selected");
            customAmount.value = button.dataset.amount;
            updateAmount(button.dataset.amount);
        });
    });

    customAmount.addEventListener("input", () => {
        amountButtons.forEach((item) => item.classList.remove("selected"));
        updateAmount(customAmount.value);
    });
});
