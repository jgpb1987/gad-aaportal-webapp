// wwwroot/js/browserInfo.js

window.browserInfo = {
    getBrowserInfo: function () {
        const userAgent = navigator.userAgent;
        let browserName, fullVersion;

        if (userAgent.indexOf("Firefox") > -1) {
            browserName = "Mozilla Firefox";
            fullVersion = userAgent.split("Firefox/")[1];
        } else if (userAgent.indexOf("Chrome") > -1) {
            browserName = "Google Chrome";
            fullVersion = userAgent.split("Chrome/")[1].split(" ")[0];
        } else if (userAgent.indexOf("Safari") > -1) {
            browserName = "Safari";
            fullVersion = userAgent.split("Version/")[1].split(" ")[0];
        } else if (userAgent.indexOf("MSIE") > -1 || !!document.documentMode === true) {
            browserName = "Internet Explorer";
            fullVersion = userAgent.split("MSIE ")[1];
        } else {
            browserName = "Unknown";
            fullVersion = "Unknown";
        }

        return {
            browser: `${browserName} ${fullVersion}`,
            userAgent: userAgent,
            language: navigator.language,
            operatingSystem: this.getOperatingSystem(),
            timeZone: Intl.DateTimeFormat().resolvedOptions().timeZone
        };
    },
    getOperatingSystem: function () {
        const platform = navigator.userAgent;
        if (platform.indexOf("Win") !== -1) return "Windows";
        if (platform.indexOf("Mac") !== -1) return "MacOS";
        if (platform.indexOf("Linux") !== -1) return "Linux";
        if (platform.indexOf("Android") !== -1) return "Android";
        if (platform.indexOf("like Mac") !== -1) return "iOS";
        return "Unknown OS";
    },
    getGeolocation: function () {
        return new Promise((resolve, reject) => {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    position => resolve(position.coords),
                    error => reject(error)
                );
            } else {
                reject("Geolocation not supported");
            }
        });
    }

};

window.browserInfo.getIp = async function () {
    const response = await fetch("https://api.ipify.org?format=json");
    const data = await response.json();
    return data.ip;
};