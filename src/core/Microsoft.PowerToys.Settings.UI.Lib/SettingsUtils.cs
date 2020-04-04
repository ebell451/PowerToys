using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Microsoft.PowerToys.Settings.UI.Lib
{
    public static class SettingsUtils
    {
        /// <summary>
        /// Get path to the json settings file.
        /// </summary>
        /// <returns>string path.</returns>
        public static string GetSettingsPath(string powertoy)
        {
            string dir;
            if (string.IsNullOrWhiteSpace(powertoy))
            {
                dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Microsoft\\PowerToys\\");
            }
            else
            {
                dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Microsoft\\PowerToys\\{powertoy}\\");
            }

            // create dirctory if one does not exist.
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return Path.Combine(dir, "settings.json");
        }

        /// <summary>
        /// Get a Deserialized object of the json settings string.
        /// </summary>
        /// <returns>Deserialized json settings object.</returns>
        public static T GetSettings<T>(string powertoy)
        {
            var jsonSettingsString = File.ReadAllText(SettingsUtils.GetSettingsPath(powertoy));
            return JsonSerializer.Deserialize<T>(jsonSettingsString);
        }

        /// <summary>
        /// Save settings to a json file.
        /// </summary>
        /// <param name="moduleJsonSettings">json string settings object.</param>
        /// <param name="powertoyModuleName">the name of the powertoy</param>
        public static void SaveSettings(string moduleJsonSettings, string powertoyModuleName)
        {
            File.WriteAllText(SettingsUtils.GetSettingsPath(powertoyModuleName), moduleJsonSettings);
        }
    }
}
