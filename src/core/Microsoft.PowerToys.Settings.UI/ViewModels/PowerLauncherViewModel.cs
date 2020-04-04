using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

using Microsoft.PowerToys.Settings.UI.Helpers;
using Microsoft.PowerToys.Settings.UI.Lib;
using Microsoft.PowerToys.Settings.UI.Views;

namespace Microsoft.PowerToys.Settings.UI.ViewModels
{
    public class PowerLauncherViewModel : Observable
    {
        public PowerLauncherSettings settings;
        private const string POWERTOY_NAME = "PowerLauncher";

        public PowerLauncherViewModel()
        {
            if (SettingsUtils.SettingsExists(POWERTOY_NAME))
            {
                settings = SettingsUtils.GetSettings<PowerLauncherSettings>(POWERTOY_NAME);
            } else
            {
                settings = new PowerLauncherSettings();
            }
        }



        private void UpdateSettings([CallerMemberName] string propertyName = null)
        {
            // Notify UI of property change
            OnPropertyChanged(propertyName);


            // Save settings to file
            SettingsUtils.SaveSettings(JsonSerializer.Serialize(settings), POWERTOY_NAME);

            // Propagate changes to application through IPC
            var propertiesJson = JsonSerializer.Serialize(settings.properties);
            ShellPage.Default_SndMSG_Callback(
                string.Format("{{ \"{0}\": {1} }}", POWERTOY_NAME, JsonSerializer.Serialize(settings.properties)));
        }

        public bool EnablePowerLauncher
        {
            get { return settings.properties.enable_powerlauncher; }
            set 
            {
                settings.properties.enable_powerlauncher = value;
                UpdateSettings();
            }
        }

        public int SearchResultPreference
        {
            get { return settings.properties.search_result_preference;  }
            set 
            {
                settings.properties.search_result_preference = value;
                UpdateSettings();
            }
        }

        public int SearchTypePreference
        {
            get { return settings.properties.search_type_preference; }
            set
            {
                settings.properties.search_type_preference = value;
                UpdateSettings();
            }
        }

        public int MaximumNumberOfResults
        {
            get { return settings.properties.maximum_number_of_results; }
            set
            {
                settings.properties.maximum_number_of_results = value;
                UpdateSettings();
            }
        }

        public string OpenPowerLauncher
        {
            get { return settings.properties.open_powerlauncher; }
            set
            {
                settings.properties.open_powerlauncher = value;
                UpdateSettings();
            }
        }

        public string OpenFileLocation
        {
            get { return settings.properties.open_file_location; }
            set
            {
                settings.properties.open_file_location = value;
                UpdateSettings();
            }
        }

        public string CopyPathLocation
        {
            get { return settings.properties.copy_path_location; }
            set
            {
                settings.properties.copy_path_location = value;
                UpdateSettings();
            }
        }

        public string OpenConsole
        {
            get { return settings.properties.open_console; }
            set
            {
                settings.properties.open_console = value;
                UpdateSettings();
            }
        }

        public bool OverrideWinRKey
        {
            get { return settings.properties.override_win_r_key; }
            set
            {
                settings.properties.override_win_r_key = value;
                UpdateSettings();
            }
        }

        public bool OverrideWinSKey
        {
            get { return settings.properties.override_win_s_key; }
            set
            {
                settings.properties.override_win_s_key = value;
                UpdateSettings();
            }
        }
    }
}