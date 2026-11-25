document.addEventListener("DOMContentLoaded", () => {
    const passwordInputs = document.querySelectorAll("[data-password-input]");
    const passwordConfirm = document.querySelector("[data-password-confirm]");
    const submitForms = document.querySelectorAll("[data-auth-form], #login-form");

    document.querySelectorAll("[data-password-toggle]").forEach((toggle) => {
        toggle.addEventListener("click", () => {
            const input = toggle.closest(".auth-input-wrap")?.querySelector("input");
            if (!input) {
                return;
            }

            const showing = input.type === "text";
            input.type = showing ? "password" : "text";
            toggle.textContent = showing ? "Afficher" : "Masquer";
            toggle.setAttribute("aria-label", showing ? "Afficher le mot de passe" : "Masquer le mot de passe");
        });
    });

    passwordInputs.forEach((password) => {
        const rules = {
            length: (value) => value.length >= Number(password.dataset.minLength || 0),
            digit: (value) => /\d/.test(value),
            lower: (value) => /[a-z]/.test(value),
            upper: (value) => /[A-Z]/.test(value),
            special: (value) => /[^a-zA-Z0-9]/.test(value)
        };

        Object.keys(rules).forEach((ruleName) => {
            const requirement = password.dataset[`require${ruleName.charAt(0).toUpperCase()}${ruleName.slice(1)}`];
            const ruleElement = document.querySelector(`[data-rule="${ruleName}"]`);
            if (ruleElement && ruleName !== "length") {
                ruleElement.hidden = requirement !== "true";
            }
        });

        const updateRules = () => {
            Object.entries(rules).forEach(([ruleName, rule]) => {
                const ruleElement = document.querySelector(`[data-rule="${ruleName}"]`);
                if (ruleElement) {
                    ruleElement.classList.toggle("is-valid", password.value.length > 0 && rule(password.value));
                }
            });

            updatePasswordMatch();
        };

        password.addEventListener("input", updateRules);
        updateRules();
    });

    function updatePasswordMatch() {
        if (!passwordConfirm || passwordInputs.length === 0) {
            return;
        }

        const password = passwordInputs[0];
        const matchMessage = document.querySelector("[data-password-match]");
        if (!matchMessage || passwordConfirm.value.length === 0) {
            if (matchMessage) {
                matchMessage.textContent = "";
                matchMessage.className = "password-match";
            }
            return;
        }

        const matches = password.value === passwordConfirm.value;
        matchMessage.textContent = matches ? "Les mots de passe correspondent." : "Les mots de passe ne correspondent pas.";
        matchMessage.className = `password-match ${matches ? "is-valid" : "is-invalid"}`;
    }

    passwordConfirm?.addEventListener("input", updatePasswordMatch);

    submitForms.forEach((form) => {
        form.addEventListener("submit", (event) => {
            if (!form.checkValidity()) {
                event.preventDefault();
                form.classList.add("was-validated");
                return;
            }

            const submitButton = form.querySelector("[data-auth-submit]");
            const submitLabel = form.querySelector("[data-submit-label]");
            const submitLoading = form.querySelector("[data-submit-loading]");
            if (submitButton && submitLabel && submitLoading) {
                submitButton.disabled = true;
                submitLabel.hidden = true;
                submitLoading.hidden = false;
            }
        });
    });
});
