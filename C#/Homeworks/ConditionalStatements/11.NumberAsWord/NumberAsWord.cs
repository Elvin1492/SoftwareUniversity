using System;

class NumberAsWord
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        string numberToPrint = null;
        string onesToPrint = null;
        string tensToPrint = null;
        string hundredsToPrint = null;

        
        // numbers from 0 to 20
        string zero = "zero";
        string one = "one";
        string two = "two";
        string three = "three";
        string four = "four";
        string five = "five";
        string six = "six";
        string seven = "seven";
        string eight = "eight";
        string nine = "nine";
        string ten = "ten";
        string eleven = "eleven";
        string twelve = "twelve";
        string thirteen = "thirteen";
        string fourteen = "fourteen";
        string fifteen = "fifteen";
        string sixteen = "sixteen";
        string seventeen = "seventeen";
        string eighteen = "eighteen";
        string nineteen = "nineteen";
        string twenty = "twenty";

        //numbers from thirty to hundred
        string thirty = "thirty";
        string fourty = "fourty";
        string fifty = "fifty";
        string sixty = "sixty";
        string seventy = "seventy";
        string eighty = "eighty";
        string ninety = "ninety";
        string hundred = "hundred";

       if(number >= 0 && number <= 20)
       {
           switch (number)
           {
               case 0: numberToPrint = zero; break;
               case 1: numberToPrint = one; break;
               case 2: numberToPrint = two; break;
               case 3: numberToPrint = three; break;
               case 4: numberToPrint = four; break;
               case 5: numberToPrint = five; break;
               case 6: numberToPrint = six; break;
               case 7: numberToPrint = seven; break;
               case 8: numberToPrint = eight; break;
               case 9: numberToPrint = nine; break;
               case 10: numberToPrint = ten; break;
               case 11: numberToPrint = eleven; break;
               case 12: numberToPrint = twelve; break;
               case 13: numberToPrint = thirteen; break;
               case 14: numberToPrint = fourteen; break;
               case 15: numberToPrint = fifteen; break;
               case 16: numberToPrint = sixteen; break;
               case 17: numberToPrint = seventeen; break;
               case 18: numberToPrint = eighteen; break;
               case 19: numberToPrint = nineteen; break;
               case 20: numberToPrint = twenty; break;
               default:
                   break;              
           }
           Console.WriteLine(numberToPrint);
       }
          
        else if( number > 20 && number <= 999)
       {
            //get the digits from the number
           int ones = number  % 10;
           int tens = (number / 10)  % 10;
           int hundreds = number / 100;
            //print the hundreds
           switch (hundreds)
           {
               case 0: hundredsToPrint = null; break;
               case 1: hundredsToPrint = "one hundred"; break;
               case 2: hundredsToPrint = "two hundred"; break;
               case 3: hundredsToPrint = "three hundred"; break;
               case 4: hundredsToPrint = "four hundred"; break;
               case 5: hundredsToPrint = "five hundred"; break;
               case 6: hundredsToPrint = "six hundred"; break;
               case 7: hundredsToPrint = "seven hundred"; break;
               case 8: hundredsToPrint = "eight hundred"; break;
               case 9: hundredsToPrint = "nine hundred"; break;
               default:
                   break;
           }

           Console.Write("{0} ", hundredsToPrint);
            //print "and"
           if (hundreds != 0 && ones != 0 && tens != 0)
           {
               Console.Write("and ");
           }
            //print the tens
           switch (tens)
           {
               case 2: tensToPrint = twenty; break;
               case 3: tensToPrint = thirty; break;
               case 4: tensToPrint = fourty; break;
               case 5: tensToPrint = fifty; break;
               case 6: tensToPrint = sixty; break;
               case 7: tensToPrint = seventy; break;
               case 8: tensToPrint = eighty; break;
               case 9: tensToPrint = ninety; break;
               case 10: tensToPrint = null; break;
               default:
                   break;
           }
           Console.Write("{0} ",tensToPrint);
            // case from 010 to 019
           if(tens == 1 )
           {
               switch (ones)
               {
                   case 0: numberToPrint = ten; break;
                   case 1: numberToPrint = eleven; break;
                   case 2: numberToPrint = twelve; break;
                   case 3: numberToPrint = thirteen; break;
                   case 4: numberToPrint = fourteen; break;
                   case 5: numberToPrint = fifteen; break;
                   case 6: numberToPrint = sixteen; break;
                   case 7: numberToPrint = seventeen; break;
                   case 8: numberToPrint = eighteen; break;
                   case 9: numberToPrint = nineteen; break;
                   default:
                       break;
               }
               Console.Write("{0} ",numberToPrint);
           }

            //print the ones
           switch (ones)
           {
               case 0: numberToPrint = null; break;
               case 1: numberToPrint = one; break;
               case 2: numberToPrint = two; break;
               case 3: numberToPrint = three; break;
               case 4: numberToPrint = four; break;
               case 5: numberToPrint = five; break;
               case 6: numberToPrint = six; break;
               case 7: numberToPrint = seven; break;
               case 8: numberToPrint = eight; break;
               case 9: numberToPrint = nine; break;
               default:
                   break;
           }
           Console.Write("{0} ", numberToPrint);
       }

       Console.WriteLine();

    }
}

