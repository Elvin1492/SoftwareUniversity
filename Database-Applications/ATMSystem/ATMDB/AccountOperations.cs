namespace ATMDB
{
    using System;
    using System.Data;
    using System.Linq;

    public class AccountOperations
    {
        public static void Withdraw(string cardNumber, string pin, decimal sumAmmount)
        {
            var context = new ATMDBEntities();

            using (var dbContextTransaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    Console.WriteLine("Withdrawing ...");

                    var requestedAccount = context.CardAccounts
                        .Where(a => a.CardNumber == cardNumber && a.CardPIN == pin)
                        .First();

                    if (sumAmmount > requestedAccount.CardCash)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    requestedAccount.CardCash -= sumAmmount;
                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    Console.WriteLine("Transaction completed.Withdrawn sum: {0}\nBalance after withdraw: {1:0.00}",
                        sumAmmount,
                        requestedAccount.CardCash);

                    LogTransactionHistory(cardNumber, pin, sumAmmount);
                }
                catch (Exception ex)
                {
                    var exceptionType = ex.GetType().ToString();
                    switch (exceptionType)
                    {
                        case "System.InvalidOperationException":
                            Console.WriteLine("Wrong card or pin number.");
                            break;
                        case "System.ArgumentOutOfRangeException":
                            Console.WriteLine("Insufficient funds");
                            break;
                        default:
                            break;
                    }

                    dbContextTransaction.Rollback();
                }
            }
        }

        private static void LogTransactionHistory(string cardNumber, string pin, decimal ammount)
        {
            var context = new ATMDBEntities();
            var newLog = new TransactionHistory
            {
                CardNumber = cardNumber,
                TransactionDate = DateTime.Now,
                Amount = ammount,
            };

            context.TransactionHistories.Add(newLog);
            context.SaveChanges();
        }
    }
}
