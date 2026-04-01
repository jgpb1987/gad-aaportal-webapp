window.layoutInterop = {
    isMobile: function (breakpoint) {
        return window.matchMedia(`(max-width: ${breakpoint}px)`).matches;
    },

    listenResize: function (dotnetRef, breakpoint) {
        const mq = window.matchMedia(`(max-width: ${breakpoint}px)`);
        const handler = () => dotnetRef.invokeMethodAsync("OnResizeChanged", mq.matches);

        handler();

        if (mq.addEventListener) mq.addEventListener("change", handler);
        else mq.addListener(handler);
    },

    lockBodyScroll: function () {
        document.body.style.overflow = "hidden";
    },

    unlockBodyScroll: function () {
        document.body.style.overflow = "";
    }
};
