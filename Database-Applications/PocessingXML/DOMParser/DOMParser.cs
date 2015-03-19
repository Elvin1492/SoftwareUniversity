namespace ProcessingXML
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.XPath;

    public class DOMParser
    {
        public static void ExtractAlbumNames(XmlDocument doc)
        {
            doc.Load("../../catalog.xml");
            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                foreach (XmlNode album in node.ChildNodes)
                {
                    Console.WriteLine("Album: {0};", album.Attributes["title"].Value);
                }
            }
        }

        public static ICollection<string> ExtactAllArtistAlphabetically(XmlDocument doc)
        {
            var artistList = new SortedSet<string>();
            doc.Load("../../catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            string currentArtist;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                currentArtist = node.Attributes["name"].Value;
                artistList.Add(currentArtist);
            }

            return artistList;
        }

        public static Dictionary<string, int> ExtractArtistsAndNumberOfAlbums(XmlDocument doc)
        {
            var artistWithAlbums = new Dictionary<string, int>();
            doc.Load("../../catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            string currentAtist;
            int currentArtistAlbumsCount;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                currentAtist = node.Attributes["name"].Value;
                currentArtistAlbumsCount = node.ChildNodes.Count;

                if (artistWithAlbums.ContainsKey(currentAtist))
                {
                    artistWithAlbums[currentAtist] += currentArtistAlbumsCount;
                }
                else
                {
                    artistWithAlbums.Add(currentAtist, currentArtistAlbumsCount);
                }
            }

            return artistWithAlbums;
        }

        public static Dictionary<string, int> ArtistWithAlbumsCountUsingXPath(XmlDocument doc)
        {
            var artistWithAlbums = new Dictionary<string, int>();
            doc.Load("../../catalog.xml");
            string xPathQuery = "/music/artist";
            string currentAtist;
            int currentArtistAlbumsCount;
            XmlNodeList artistsList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in artistsList)
            {
                currentAtist = node.Attributes["name"].Value;
                currentArtistAlbumsCount = node.ChildNodes.Count;

                if (artistWithAlbums.ContainsKey(currentAtist))
                {
                    artistWithAlbums[currentAtist] += currentArtistAlbumsCount;
                }
                else
                {
                    artistWithAlbums.Add(currentAtist, currentArtistAlbumsCount);
                }
            }

            return artistWithAlbums;
        }

        public static void DeleteAlbums(XmlDocument doc)
        {
            doc.Load("../../catalog.xml");
            string xPathQueryArtists = "/music/artist";
            XmlNodeList foundArtist = doc.SelectNodes(xPathQueryArtists);

            foreach (XmlNode artist in foundArtist)
            {
                foreach (XmlNode album in artist.ChildNodes)
                {
                    Decimal price = Decimal.Parse(album.Attributes["price"].Value);
                    if (price > 20)
                    {
                        artist.RemoveChild(album);
                    }
                }
            }
           
            doc.Save("../../cheap-albums-catalog.xml");
        }

        public static void FindOldAlbums(XmlDocument doc)
        {
            doc.Load("../../catalog.xml");
           // string xPathQuery = "/music/artist/album[date <= " + DateTime.Now.AddYears(-5) + "]";
            string xPathQuery = "/music/artist/album";
            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                DateTime albumDate = DateTime.Parse(album.Attributes["date"].Value);
                if (albumDate < DateTime.Now.AddYears(-5))
                {
                    Console.WriteLine("Album: {0}; Price: {1}",
                        album.Attributes["title"].Value,
                        album.Attributes["price"].Value);
                }
            }
        }

    }
}





