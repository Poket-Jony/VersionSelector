using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VersionSelector
{
    public class Settings
    {
        private List<DefaultApp> defaultApps = new List<DefaultApp>();

        public Settings()
        {
            if(!string.IsNullOrEmpty(Properties.Settings.Default.DefaultApps))
                defaultApps = StringSerializer<List<DefaultApp>>.Deserialize(Properties.Settings.Default.DefaultApps);
        }

        public List<DefaultApp> GetDefaultAppsByExtension(string extension)
        {
            return defaultApps.FindAll(s => s.OpenExtensions.Contains(extension));
        }

        public void AddDefaultApp(DefaultApp app)
        {
            if (defaultApps.Exists(s => s.FilePath == app.FilePath))
            {
                DefaultApp defApp = defaultApps.Find(s => s.FilePath == app.FilePath);
                if (!defApp.OpenExtensions.Contains(app.OpenExtensions.First()))
                    defApp.OpenExtensions.Add(app.OpenExtensions.First());
            }
            else
                defaultApps.Add(app);
        }

        public void DelDefaultApp(DefaultApp app, string extension)
        {
            if (defaultApps.Exists(s => s.FilePath == app.FilePath))
            {
                DefaultApp defApp = defaultApps.Find(s => s.FilePath == app.FilePath);
                if (defApp.OpenExtensions.Contains(extension))
                    defApp.OpenExtensions.Remove(extension);
                if (defApp.OpenExtensions.Count == 0)
                    defaultApps.Remove(defApp);
            }
        }

        public void ClearDefaultApps()
        {
            defaultApps.Clear();
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.DefaultApps = StringSerializer<List<DefaultApp>>.Serialize(defaultApps);
            Properties.Settings.Default.Save();
        }
    }
}
