using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StarsectorTranslator
{
    public class Settings
    {
        private static Settings _instance;
        public static Settings Instance
        {
            get { return _instance ?? (_instance = ReadSettings()); }
        }

        // Method for reading settings from a file using Newtonsoft.Json
        private static Settings ReadSettings()
        {
            var text = File.ReadAllText("settings.json", Encoding.UTF8);
            var settings = JsonConvert.DeserializeObject<Settings>(text);

            return settings;
        }

        public List<string> TranslationFields { get; set; }
    }
}
