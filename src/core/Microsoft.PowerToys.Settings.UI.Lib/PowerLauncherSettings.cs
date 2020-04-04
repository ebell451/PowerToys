using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.PowerToys.Settings.UI.Lib
{
    public class PowerLauncherSettings : BasePTModuleSettings
    {
        public PowerLauncherProperties properties { get; set; }
        
        public PowerLauncherSettings()
        {
            this.properties = new PowerLauncherProperties();
            this.version = "1";
            this.name = "_unset_";
        }
    }

    public class PowerLauncherProperties
    {
        public bool enable_powerlauncher { get; set; }
        public int search_result_preference { get; set; }
        public int search_type_preference { get; set; }
        public int maximum_number_of_results { get; set; }
        public string open_powerlauncher { get; set; }
        public string open_file_location { get; set; }
        public string copy_path_location { get; set; }
        public string open_console { get; set; }
        public bool override_win_r_key { get; set; }
        public bool override_win_s_key { get; set; }
    }
}
