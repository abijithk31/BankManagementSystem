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

        static FormConfig()
        {
            accountViewModel = new AccountViewModel();
            createAccountWindow = new CreateAccountWindow();
        }
    }
}
