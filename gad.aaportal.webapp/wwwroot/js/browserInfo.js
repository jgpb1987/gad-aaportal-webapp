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

window.imprimirComprobante = function (elementId) {
    const contenido = document.getElementById(elementId);

    if (!contenido) {
        alert("No se encontró el comprobante para imprimir.");
        return;
    }

    const ventana = window.open("", "_blank", "width=900,height=700");

    ventana.document.write(`
        <html>
        <head>
            <title>Comprobante de declaración</title>
            <style>
                * {
                    box-sizing: border-box;
                }

                body {
                    font-family: Arial, sans-serif;
                    margin: 10mm;
                    color: #111827;
                    background: #ffffff;
                }

                .comprobante-simple-box {
                    width: 100%;
                    border: 1px solid #d1d5db;
                    border-radius: 8px;
                    overflow: hidden;
                }

                .comprobante-simple-title {
                    text-align: center;
                    padding: 8px 10px;
                    border-bottom: 1px solid #d1d5db;
                    background: #f9fafb;
                }

                .comprobante-simple-title strong {
                    display: block;
                    font-size: 15px;
                    font-weight: 800;
                }

                .comprobante-simple-title span {
                    display: block;
                    margin-top: 2px;
                    font-size: 11px;
                    color: #6b7280;
                }

                .comprobante-simple-section-title {
                    padding: 6px 8px;
                    background: #f3f4f6;
                    border-top: 1px solid #e5e7eb;
                    border-bottom: 1px solid #e5e7eb;
                    font-size: 10px;
                    font-weight: 800;
                    text-transform: uppercase;
                }

                .comprobante-simple-grid {
                    display: grid;
                    grid-template-columns: repeat(4, 1fr);
                    border-bottom: 1px solid #e5e7eb;
                }

                .comprobante-simple-grid div {
                    padding: 6px 8px;
                    border-right: 1px solid #e5e7eb;
                    border-bottom: 1px solid #e5e7eb;
                    min-height: 36px;
                }

                .comprobante-simple-grid div:nth-child(4n) {
                    border-right: none;
                }

                .comprobante-simple-grid span {
                    display: block;
                    font-size: 9px;
                    color: #6b7280;
                    font-weight: 700;
                }

                .comprobante-simple-grid strong {
                    display: block;
                    margin-top: 2px;
                    font-size: 11px;
                    font-weight: 800;
                }

                .comprobante-simple-two-columns {
                    display: grid;
                    grid-template-columns: 1fr 1fr;
                }

                .comprobante-simple-two-columns > div:first-child {
                    border-right: 1px solid #e5e7eb;
                }

                .comprobante-simple-table {
                    width: 100%;
                    border-collapse: collapse;
                    font-size: 10px;
                }

                .comprobante-simple-table td {
                    padding: 4px 7px;
                    border-bottom: 1px solid #e5e7eb;
                }

                .comprobante-simple-table td:last-child {
                    text-align: right;
                    font-weight: 800;
                }

                .comprobante-simple-subtotal td {
                    background: #f9fafb;
                    font-weight: 800;
                }

                .comprobante-simple-total {
                    display: flex;
                    justify-content: space-between;
                    align-items: center;
                    padding: 8px 10px;
                    background: #fff7ed;
                    color: #c2410c;
                    font-size: 14px;
                    font-weight: 800;
                    border-top: 1px solid #fed7aa;
                }

                .comprobante-simple-total strong {
                    font-size: 17px;
                }

                @page {
                    size: A4 portrait;
                    margin: 8mm;
                }

                @media print {
                    body {
                        margin: 0;
                    }
                }
            </style>
        </head>
        <body>
            ${contenido.outerHTML}
        </body>
        </html>
    `);

    ventana.document.close();

    ventana.onload = function () {
        ventana.focus();
        ventana.print();
        ventana.close();
    };
};