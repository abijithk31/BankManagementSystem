using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    internal class AccountMemoryRepo : IAccountRepo
    {
        public ObservableCollection<AccountModel> account = new ObservableCollection<AccountModel>()
        {
            new AccountModel
            {
                AccountNumber = 1,
                Name = "Test",
                Type = "Savings",
                Email = "test",
                Address = "",
                Balance = 0,
                PhoneNo = "1234",
                IsActive = true,
                InterestPercentage = 0,
            }

        };

        public void CalculateInterestAndUpdateBalance()
        {
            throw new NotImplementedException();
        }

        public void Create(AccountModel accountModel)
        {
            account.Add(accountModel);
        }

        public void Delete(int acNo, AccountModel account)
        {
            throw new NotImplementedException();
        }

        public void Deposit(int acNo, int Amount)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<AccountModel> ReadAllAccounts()
        {
            return account;
        }

        public void Update(AccountModel account)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(int acNo, int Amount)
        {
            throw new NotImplementedException();
        }
    }
}
