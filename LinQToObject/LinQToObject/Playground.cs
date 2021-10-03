using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinQToObject.Models;

namespace LinQToObject
{
    class Playground
    {
        public static void Main(String[] args)
        {
            int customerNumber = 10;
            int bankaccountNumber = 10;
            List<Customer> customers = new List<Customer>();
            List<BankAccount> bankAccounts = new List<BankAccount>();

            for (int i = 0; i < customerNumber; i++)
            {
                customers.Add(new Customer());
            }

            for (int i = 0; i < bankaccountNumber; i++)
            {
                bankAccounts.Add(new BankAccount());
            }
            if (customerNumber == bankaccountNumber)
            {
                ConnectOneByOne(bankAccounts, customers);
            }
            else
            {
                throw new Exception("Only works with same ammount. Has to be programmed.");
            }

            var joinCustomersBankAccount = from c in customers
                                           join ba in bankAccounts
                                           on c.CustomerId equals ba.CustomerId
                                           select new
                                           {
                                               Customer = c,
                                               BankAccount = ba
                                           };
            foreach (var item in joinCustomersBankAccount)
            {
                Console.WriteLine(item.BankAccount.BankaccountNumber + "\t" + item.BankAccount.AmountOfMoney + "\t" + item.Customer.FirstName);
                Console.WriteLine("\t" + item.Customer.CustomerId + "\t" + item.BankAccount.CustomerId);
            }
        }
        private static List<BankAccount> ConnectOneByOne(List<BankAccount> bankAccounts, List<Customer> customers)
        {
            for(int i = 0; i < bankAccounts.Count; i++)
            {
                bankAccounts[i].CustomerId = customers[i].CustomerId;
            }
            return bankAccounts;
        }
    }
}
