using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQToObject.Models
{
    class BankAccount
    {
        private const String COUNTRY = "AT";
        private const int IBANLENGTH = 18;
        private static int BaNCounter = 0;
        // (KontoNr (IBAN-Nr.), Bankleitzahl (BIC/SWIFT-Code), Bankname, Betrag der sich am Konto befindet, KundenId)
        public String BankaccountNumber { get; private set; } // IBAN
        public String BankCode { get; set; } // 8 bis 11 Stellen in AT
        public String Bankname { get; set; }
        public decimal AmountOfMoney { get; set; }
        public String CustomerId { get; set; }

        public BankAccount() : this(null, null, 0.0m, null)
        {

        }

        public BankAccount(String bankCode, String bankname, decimal amountOfMoney, String customerId)
        {
            this.BankaccountNumber = COUNTRY + string.Concat(Enumerable.Repeat("0", IBANLENGTH - IMath.Log10(BaNCounter))) + BaNCounter;
            BaNCounter++;
            this.BankCode = bankCode;
            this.Bankname = bankname;
            this.AmountOfMoney = amountOfMoney;
            this.CustomerId = customerId;
        }
    }
}
