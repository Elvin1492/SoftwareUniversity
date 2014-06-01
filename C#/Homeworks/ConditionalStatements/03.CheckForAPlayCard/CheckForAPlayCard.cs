using System;

class CheckForAPlayCard
{
    static void Main()
    {
        string playingCard = Console.ReadLine();

        if(playingCard == "2" || playingCard == "3" || playingCard == "4" || playingCard == "5" || playingCard == "6"
            || playingCard == "7" || playingCard == "8" || playingCard == "9" || playingCard == "10" || playingCard == "J"
            || playingCard == "Q" || playingCard == "K" || playingCard == "A")
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

