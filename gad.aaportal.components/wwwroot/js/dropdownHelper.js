window.dropdownHelper = {
    handler: null,

    register: function (dotnetObj, element) {
        this.handler = (e) => {
            // CLIC FUERA
            if (!element.contains(e.target)) {
                dotnetObj.invokeMethodAsync('CloseFromJs');
            }
            // ESC
            if (e.key === "Escape") {
                dotnetObj.invokeMethodAsync('CloseFromJs');
            }
        };

        document.addEventListener("click", this.handler);
        document.addEventListener("keyup", this.handler);
    },

    unregister: function () {
        if (this.handler) {
            document.removeEventListener("click", this.handler);
            document.removeEventListener("keyup", this.handler);
            this.handler = null;
        }
    }
};
