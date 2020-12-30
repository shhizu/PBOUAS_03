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
        public ObservableCollection<Person> ResultCollection { get; set; }
        public Calculate Calculate { get; set; }
        public double Total { get; set; }
        private double _discount;
        public double Discount
        {
            get
            {
                if (_discount != 0)
                {
                    return _discount;
                }
                return 0;
            }
            set
            {
                _discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }
        public double OtherFees { get; set; }


        public CalculateVM(double Subtotal)
        {
            Calculate = new Calculate();
            Total = Calculate.getTotal(Subtotal, Discount, OtherFees);
            okButton = new CommandHandler(Calculate.CloseWindow);
        }


    }
}
