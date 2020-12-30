using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _discount = value;
                OnPropertyChanged(nameof(Discount));
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
                _otherFees = value;
                OnPropertyChanged(nameof(OtherFees));
            }
        }

        public CalculateVM()
        {
            Calculate = new Calculate();
            okButton = new CommandHandler(Calculate.CloseWindow);

           
        }
    }
}
