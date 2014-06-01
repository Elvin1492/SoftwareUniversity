using System;

class Program
{
    static void Main()
    {
        string card = null;
        for (int i = 1; i < 13; i++)
        {
            switch (i)
            {
                case 1: card = "2"; break;
                case 2: card = "3"; break;
                case 3: card = "4"; break;
                case 4: card = "5"; break;
                case 5: card = "6"; break;
                case 6: card = "7"; break;
                case 7: card = "8"; break;
                case 8: card = "9"; break;
                case 9: card = "10"; break;
                case 10: card = "Q"; break;
                case 11: card = "K"; break;
                case 12: card = "A"; break;
                default:
                    break;
            }
            Console.WriteLine("{0}{1} {0}{2} {0}{3}  {0}{4}", card, (char)3, (char)4, (char)5, (char)6);           
        }     
              
     }
}

