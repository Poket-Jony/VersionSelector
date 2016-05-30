using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace VersionSelector
{
    [Serializable()]
    public class DefaultApp
    {
        public List<string> OpenExtensions { get; private set; } = new List<string>();
        public string FilePath { get; private set; }

        public DefaultApp(string path, string extension)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            FilePath = path;
            OpenExtensions.Add(extension);
        }

        public void StartProgram(App app)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = FilePath;
            startInfo.Arguments = "\"" + app.FilePath + "\"" + app.GetFileOpenArguments();
            Process.Start(startInfo);
        }

        public Icon GetFileIcon()
        {
            return Icon.ExtractAssociatedIcon(FilePath);
        }

        public string GetApplicationName()
        {
            string progName = FileVersionInfo.GetVersionInfo(FilePath).ProductName;
            string fileName = Path.GetFileNameWithoutExtension(FilePath);
            return string.IsNullOrEmpty(progName) || progName.Length > 32  ? fileName: progName;
        }
    }
}
