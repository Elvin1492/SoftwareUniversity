namespace ProcessingXML
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class XMLWriter
    {
        public static void DirectoryContentAsXML(string path)
        {
            string rootPath = path;
            string fileName = "../../file-system.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {

                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("root-dir");
                writer.WriteAttributeString("path", path);

                if (Directory.Exists(path))
                {
                    ProcessDirectory(writer, path, rootPath);
                }
                else if (File.Exists(path))
                {
                    ProcessFile(writer, path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);              
                }

                writer.WriteEndDocument();
            }
        }

        private static void ProcessFile(XmlTextWriter writer, string path)
        {
            writer.WriteStartElement("file");
            writer.WriteAttributeString("name", Path.GetFileName(path));
            writer.WriteEndElement();
        }

        private static void ProcessDirectory(XmlTextWriter writer, string directory, string rootPath)
        {
            string[] files = Directory.GetFiles(directory);
            string[] subdirectories = Directory.GetDirectories(directory);

            if (directory != rootPath)
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", Path.GetFileName(directory));
            }

            foreach (string file in files)
            {
                ProcessFile(writer, file);
            }

            foreach (var directories in subdirectories)
            {
                ProcessDirectory(writer, directories, rootPath);
            }

            if (directory != rootPath)
            {
                writer.WriteEndElement();
            }
        }
    }
}
