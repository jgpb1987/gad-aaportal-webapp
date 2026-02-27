using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gad.admin.app.Settings
{
    public static class AppSettingsLoader
    {
        public static AppSettingsRoot Load()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            if (!File.Exists(path))
                throw new FileNotFoundException($"No se encontró appsettings.json en: {path}");

            var json = File.ReadAllText(path);

            var settings = JsonSerializer.Deserialize<AppSettingsRoot>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return settings ?? new AppSettingsRoot();
        }
    }
}
