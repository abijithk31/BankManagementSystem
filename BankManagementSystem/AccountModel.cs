using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    public class AccountModel
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public Decimal Balance { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public int InterestPercentage { get; set; }
        public int TransactionCount { get; set; }
        public DateTime LastTransactionDate { get; set; }
    }
}
