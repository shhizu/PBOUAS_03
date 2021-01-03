using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOUAS_03
{
    class HomePageVM : ObservableObject
    {
        public static double Income { get; set; }
        public double NetIncome { get; set; }
        private string _personName;
        public string PersonName
        {
            get { return _personName; }
            set { _personName = value;  OnPropertyChanged(nameof(PersonName)); }
        }


        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }


        private string _bankNumber;
        public string BankNumber
        {
            get { return _bankNumber; }
            set { _bankNumber = value; OnPropertyChanged(nameof(BankNumber));}
        }

        public HomePageVM()
        {
            NetIncome = Income - ExpenseOverviewVM.TotalExpense;
        }
    }
}
