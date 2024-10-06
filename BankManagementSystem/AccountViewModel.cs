using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankManagementSystem
{
    public delegate void DWindowClose();
    public class AccountViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(PropertyChanged, new PropertyChangedEventArgs(propertyName));
        }

        public DWindowClose NewWindowClose;
        public DWindowClose EditWindowClose;

        private AccountModel _newAccount;

        public AccountModel NewAccount
        {
            get { return _newAccount; }
            set { _newAccount = value; OnPropertyChanged(nameof(NewAccount)); }
        }

        private AccountModel _selectedAccount;

        public AccountModel SelectedAccount
        {
            get { return _selectedAccount; }
            set { _selectedAccount = value; OnPropertyChanged(nameof(SelectedAccount)); }
        }

        private IAccountRepo _repo = new AccountMemoryRepo();
        // object creation in view model with reference I account repo and memory repo.

        void CreateAccount()
        {
            AccountModel accounts = new AccountModel
            {
                AccountNumber = NewAccount.AccountNumber,
                Name = NewAccount.Name,
                Balance = NewAccount.Balance,
                Type = NewAccount.Type,
                Email = NewAccount.Email,
                PhoneNo = NewAccount.PhoneNo,
                Address  = NewAccount.Address,
                IsActive = NewAccount.IsActive,
                InterestPercentage = NewAccount.InterestPercentage,
                TransactionCount = NewAccount.TransactionCount,
                LastTransactionDate = NewAccount.LastTransactionDate,
            };

            var result = MessageBox.Show(messageBoxText: "Are you sure to create?",
                   caption: "Confirm",
                   button: MessageBoxButton.YesNo,
                   icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            _repo.Create(accounts);// adding this object to the observablecollection
            this.NewAccount = new AccountModel { AccountNumber = 0, Name = "", Balance = 0, Type = "", Email = "", PhoneNo = "", Address = "", IsActive = false, InterestPercentage = 0, TransactionCount = 0, LastTransactionDate = DateTime.Now };


            result = MessageBox.Show(messageBoxText: "Created Successfully",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);



            if (NewWindowClose!=null)
            {
                NewWindowClose();
            }
        }
        public ICommand  CreateCommand { get; }
        public AccountViewModel()
        {
            CreateCommand = new RelayCommand(CreateAccount);// object of relay command to get all the things in relay command
            EditCommand = new RelayCommand(EditAccount);
            this.NewAccount = new AccountModel
            {
                AccountNumber = 0,
                Name = "",
                Balance = 0,
                Type = "",
                Email = "",
                PhoneNo = "",
                InterestPercentage = 0,
                IsActive = false,
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
                Address=""
            };
        }

        public ICommand EditCommand { get; }

        void EditAccount() 
        {
            _repo.Update(SelectedAccount);
            if (EditWindowClose!=null)
            {
                EditWindowClose();
            }

        }

        
        public ObservableCollection<AccountModel> Accounts 
        {
            get
            {
                return _repo.ReadAllAccounts();
            }
        }


        



    }
}
