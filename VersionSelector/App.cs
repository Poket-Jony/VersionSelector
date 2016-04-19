using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace VersionSelector
{
    public class App
    {
        private string filePath = null;
        public string FilePath
        {
            get
            {
                return filePath;
            }
            private set
            {
                filePath = value;
                FileName = Path.GetFileName(value);
                FileExtension = Path.GetExtension(value);
            }
        }
        public string FileName { get; private set; }
        public string FileExtension { get; private set; }
        public List<string> FileOpenArguments { get; private set; }
        public Icon FileIcon { get; private set; }

        public App(string path, List<string> args)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            FilePath = path;
            FileOpenArguments = args;
            FileIcon = Icon.ExtractAssociatedIcon(path);
        }

        public string GetFileOpenArguments()
        {
            if (FileOpenArguments.Count == 0)
                return null;
            string argString = string.Empty;
            foreach(string arg in FileOpenArguments)
            {
                argString += arg + " ";
            }
            argString.Remove(argString.Length - 1);
            return argString;
        }
    }
}
