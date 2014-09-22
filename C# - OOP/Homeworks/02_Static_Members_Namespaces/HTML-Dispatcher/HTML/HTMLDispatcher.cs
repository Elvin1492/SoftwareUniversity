
namespace HTML
{
    using System;

    public static class HTMLDispatcher
    {
      
        public static string CreateImage(string imagSource, string alt, string title)
        {
            ElementBuilder tag = new ElementBuilder("img");
            tag.AddAtribute("src", imagSource);
            tag.AddAtribute("alt", alt);
            tag.AddAtribute("title", title);
            return tag.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder tag = new ElementBuilder("a");
            tag.AddAtribute("href", url);
            tag.AddAtribute("text", text);
            tag.AddAtribute("title", title);
            return tag.ToString();
        }
        
        public static string  CreateInput(string type, string name, string value)
        {
            ElementBuilder tag = new ElementBuilder("input");
            tag.AddAtribute("type", type);
            tag.AddAtribute("name", name);
            tag.AddAtribute("value", value);
            return tag.ToString();
        }

    }
}
