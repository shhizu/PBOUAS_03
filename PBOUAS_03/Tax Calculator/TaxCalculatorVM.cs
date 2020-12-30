using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOUAS_03
{
    class TaxCalculatorVM : ObservableObject
    {
        private double _income;
        public double Income
        {
            get
            {
                return _income;
            }
            set
            {
                _income = value;
                OnPropertyChanged(nameof(Income));
            }
        }

        private double _tax;
        public double Tax
        {
            get
            {
                return _tax;
            }
            set
            {
                _tax = value;
                OnPropertyChanged(nameof(Tax));
            }
        }
        public CommandHandler submitButton { get; set; }
        public ObservableCollection<TaxCalculator> Calculation { get; set; }

        public TaxCalculatorVM() // Constructor
        {
            Calculation = new ObservableCollection<TaxCalculator>();
            submitButton = new CommandHandler(submit);
        }

        private void submit()
        {
            double total = Income + (Income * (Tax / 100));
            Calculation.Add(new TaxCalculator("Income: Rp.", Income));
            Calculation.Add(new TaxCalculator("Tax: %", Tax));
            Calculation.Add(new TaxCalculator("Total: Rp.", total));
            Calculation = new ObservableCollection<TaxCalculator>();
        }
    }
}
