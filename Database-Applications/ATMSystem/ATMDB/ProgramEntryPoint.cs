using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDB
{
    public class ProgramEntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("Please wait ...");
            CreateDatabase();

           AccountOperations.Withdraw("1234567890", "1234", 700);

          //  AccountOperations.Withdraw("12345678908", "1234", 700); // Wrong pin number error
          //  AccountOperations.Withdraw("1234567890", "1234", 7000); // Invalid sum error
        }

        private static void CreateDatabase()
        {
            using (var context = new ATMDBEntities())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
