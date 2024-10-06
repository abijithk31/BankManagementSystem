using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    public interface IAccountRepo
    {
        void Create(AccountModel account);
        void Update(AccountModel account);
        void Delete(int acNo ,AccountModel account );
        void Deposit(int acNo, int Amount);
        void Withdraw(int acNo, int Amount);
        void CalculateInterestAndUpdateBalance();
        ObservableCollection<AccountModel> ReadAllAccounts();

    }
}
