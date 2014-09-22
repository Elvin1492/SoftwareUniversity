using System;
using HTML;

class HTMLtester
{
    static void Main()
    {
        //test the ElementBuilder, add some attributes and content to the tag and print it twice on the console
        ElementBuilder div = new ElementBuilder("div");
        div.AddAtribute("id", "page");
        div.AddAtribute("class", "big");
        div.AddConent("<p>Hello</p>");
        Console.WriteLine(div);

        //test the HTMLDispatcher create an img, a and input tag with attributes
        string imageTag = HTMLDispatcher.CreateImage("../imgs/img.jpeg", "image", "some image title");
        string linkkTag = HTMLDispatcher.CreateURL("https://softuni.bg/", "SoftUNi", "Software University");
        string inputTag = HTMLDispatcher.CreateInput("text", "userName", "user");
        Console.WriteLine(imageTag);
        Console.WriteLine(linkkTag);
        Console.WriteLine(inputTag);
        
    }
} 