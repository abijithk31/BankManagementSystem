using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    public static class FormConfig
    {
        public static AccountViewModel accountViewModel = null;
        public static CreateAccountWindow createAccountWindow = null;
        public static EditAccountWindow editAccountWindow = null;
        public static DepositViewModel depositViewModel = null;
        public static DepositWindow depositWindow = null;
        public static WithdrawViewModel withdrawViewModel = null;
        public static WithdrawWindow withdrawWindow = null;

        static FormConfig()
        {
            accountViewModel = new AccountViewModel();
            createAccountWindow = new CreateAccountWindow();
            editAccountWindow = new EditAccountWindow();
            depositViewModel = new DepositViewModel();
            withdrawViewModel = new WithdrawViewModel();
            withdrawWindow = new WithdrawWindow();
            depositWindow = new DepositWindow();
        }
    }
}
