namespace ProcessingXML
{
    using System;
    using System.Xml;
    using System.Xml.Linq;

    public class ProgramEntryPoint
    {
        public static void Main()
        {
            XmlDocument doc  = new XmlDocument();

            // Problem 2.DOM Parser: Extract Album Names
            DOMParser.ExtractAlbumNames(doc);
            Console.WriteLine();

            // Problem 3.DOM Parser: Extract All Artists Alphabetically
            var artsistsAlphabetically = DOMParser.ExtactAllArtistAlphabetically(doc);
            foreach (var artist in artsistsAlphabetically)
            {
                Console.WriteLine(artist);
            }

            Console.WriteLine();

            // Problem 4.DOM Parser: Extract Artists and Number of Albums
            var artistsWithAlbums = DOMParser.ExtractArtistsAndNumberOfAlbums(doc);
            foreach (var item in artistsWithAlbums)
            {
                Console.WriteLine("{0} - {1} alubms", item.Key, item.Value);
            }

            Console.WriteLine();

            // Problem 5.XPath: Extract Artists and Number of Albums
            var artistWithAlbumsUsingXPath = DOMParser.ArtistWithAlbumsCountUsingXPath(doc);
            foreach (var item in artistWithAlbumsUsingXPath)
            {
                Console.WriteLine("{0} - {1} alubms", item.Key, item.Value);
            }

            Console.WriteLine();

            //  Problem 6.DOM Parser: Delete Albums
            DOMParser.DeleteAlbums(doc);
            Console.WriteLine();

            // Problem 7.DOM Parser and XPath: Old Albums
            DOMParser.FindOldAlbums(doc);
            Console.WriteLine();

            // Problem 8.LINQ to XML: Old Albums
            XDocument xmlDoc = XDocument.Load("../../catalog.xml");
            LINQToXML.FindOldAlbums(xmlDoc);
            Console.WriteLine();

            // Problem 9.* XmlWriter: Directory Contents as XML
            string directory = @"E:\Git";
            XMLWriter.DirectoryContentAsXML(directory);

            // Problem 10.XElement: Directory Contents as XML
            string directory2 = @"E:\HTML-CSS projects\bootstrap tutorial\dtown";
          // LINQToXML.DirectoryContentAsXML(directory2);

        }
    }
}
