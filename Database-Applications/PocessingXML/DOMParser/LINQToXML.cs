namespace ProcessingXML
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class LINQToXML
    {
        public static void FindOldAlbums(XDocument xmlDoc)
        {
            var dateToCompare = DateTime.Now.AddYears(-5);

            var albums =
                from album in xmlDoc.Descendants("album")
                where DateTime.Parse(album.Attribute("date").Value) <= dateToCompare
                select new
                {
                    Name = album.Attribute("title").Value,
                    Price = album.Attribute("price").Value
                };

            foreach (var album in albums)
            {
                Console.WriteLine("Album: {0}; Price: {1}", album.Name, album.Price);
            }
        }

        public static void DirectoryContentAsXML(string path)
        {
            string rootPath = path;       
            var xmlFile = new XElement("root-dir", new XAttribute("path", path));

            if (Directory.Exists(path))
            {
               ProcessDirectory(xmlFile, path, rootPath);
            }
            else if (File.Exists(path))
            {
                ProcessFile(xmlFile, path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }

            xmlFile.Save("../../file-system2.xml");    
        }

        private static void ProcessFile(XElement xmlFile, string path)
        {
            xmlFile.Element("root-dir").Add(new XElement("file", new XAttribute("name", Path.GetFileName(path))));
            xmlFile.Save("../../file-system2.xml");   
        }

        private static void ProcessDirectory(XElement xmlFile, string directory, string rootPath)
        {
            string[] files = Directory.GetFiles(directory);
            string[] subdirectories = Directory.GetDirectories(directory);

            if (directory != rootPath)
            {
                xmlFile.Element("root-dir")
                    .Add(new XElement("dir", new XAttribute("name", Path.GetFileName(directory))));

               // xmlFile.(new XElement("dir", new XAttribute("name", Path.GetFileName(directory))));
                xmlFile.Save("../../file-system2.xml");
            }

            foreach (string file in files)
            {
               ProcessFile(xmlFile, file);
            }

            foreach (var directories in subdirectories)
            {
               ProcessDirectory(xmlFile, directories, rootPath);
            }

            if (directory != rootPath)
            {
            xmlFile.Save("../../file-system2.xml");
            }
        }
    }
}
