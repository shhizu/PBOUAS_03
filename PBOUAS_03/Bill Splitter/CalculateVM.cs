using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PBOUAS_03
{
    public class CalculateVM : ObservableObject
    {
        public CommandHandler okButton { get; private set; }
        public ObservableCollection<Split> ResultCollection { get; set; }
        public Calculate Calculate { get; set; }

        public List<Split> Split { get; set; }

        public double Total
        {
            get
            {
                return (_subtotal + _otherFees) - _discount;
            }
            set
            {
                OnPropertyChanged(nameof(Total));
            }
        }
        private double _discount;
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                try
                {
                    _discount = value;
                    if (_discount < 0 || _discount > 100) { _discount = 0; throw new InvalidLogicException(); }
                    OnPropertyChanged(nameof(Discount));
                }
                catch (InvalidLogicException x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }


        private double _subtotal;
        public double Subtotal
        {
            get
            {
                return _subtotal;
            }
            set
            {
                _subtotal = value;
                OnPropertyChanged(nameof(Subtotal));
            }
        }

        private double _otherFees;
        public double OtherFees
        {
            get
            {
                return _otherFees;
            }
            set
            {
                try
                {
                    _otherFees = value;
                    if (_otherFees < 0) { _otherFees = 0; throw new InvalidLogicException(); }
                    OnPropertyChanged(nameof(OtherFees));
                }
                catch (InvalidLogicException x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        public CalculateVM()
        {

            Calculate = new Calculate();
            okButton = new CommandHandler(Calculate.CloseWindow);
        }
    }
}
