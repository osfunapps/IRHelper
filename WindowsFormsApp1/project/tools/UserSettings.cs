using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Properties;

namespace Remotes_App_Translation_Project.tools
{
    public class UserSettings
    {
        private static UserSettings instance;

        public UserSettings(){}

        public static UserSettings getIntance()
        {
            if (instance != null) return instance;
            return new UserSettings();
        }

        public void SaveSettings(string eventGhostPath, bool textToSpeech)
        {
            Settings.Default.Upgrade();
            Settings.Default.eventGhostPath = eventGhostPath;
            Settings.Default.textToSpeech = textToSpeech;
            Settings.Default.Save();
        }

        public bool GetTxtToSpeech()
        {
            return Settings.Default.textToSpeech;
        }

        public string GetEventGhostPath()
        {
            return Settings.Default.eventGhostPath;
        }

        
    }
}
