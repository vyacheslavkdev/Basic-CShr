using System;

namespace Ex3.Sources.Config
{
    [Serializable]
    public class ConfigModel
    {
        private string _author;
        private string _version;
        private string _defaultDir;
        private string _defaultFileName;

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public string Version
        {
            get => _version;
            set => _version = value;
        }

        public string DefaultDir
        {
            get => _defaultDir;
            set => _defaultDir = value;
        }

        public string DefaultFileName
        {
            get => _defaultFileName;
            set => _defaultFileName = value;
        }
    }
}