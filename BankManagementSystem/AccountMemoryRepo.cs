using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankManagementSystem
{
    public class AccountMemoryRepo : IAccountRepo
    {
        private static AccountMemoryRepo _instance;
        private ObservableCollection<AccountModel> accounts;
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

        public static AccountMemoryRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountMemoryRepo();
                }
                return _instance;
            }
        }


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
            var account = accounts.FirstOrDefault(a => a.AccountNumber == acNo);
            if (account != null)
            {
                account.Balance = account.Balance + Amount;
                account.LastTransactionDate = DateTime.Now;
                account.TransactionCount = account.TransactionCount + 1;

                MessageBox.Show(messageBoxText: $"Deposited Successfully to account {acNo}",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show(messageBoxText: $"Account Not Found , Please input valid account number",
                    caption: "Warning",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Warning);
                return;
            }
        }
        public ObservableCollection<AccountModel> ReadAllAccounts()
        {
            return account;
        }

        public AccountModel Update(AccountModel account)
        {
            return account;
        }

        public void Withdraw(int acNo, int Amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == acNo);
            if (account != null)
            {
                if (account.Balance < Amount)
                {
                    MessageBox.Show(messageBoxText: $"Insufficient balance",
                   caption: "Warning",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Warning);
                    return;
                }
                account.Balance = account.Balance - Amount;
                account.LastTransactionDate = DateTime.Now;
                account.TransactionCount = account.TransactionCount + 1;

                MessageBox.Show(messageBoxText: $"Withdrawed Successfully from account {acNo}",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show(messageBoxText: $"Account Not Found , Please input valid account number",
                    caption: "Warning",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Warning);
                return;
            }
        }
    }
}
