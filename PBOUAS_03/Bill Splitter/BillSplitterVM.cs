using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.Specialized;

namespace PBOUAS_03
{
    public class BillSplitterVM : ObservableObject
    {
        // Command Handlers
        public CommandHandler popCommand { get; private set; }
        public CommandHandler calculateCommand { get; private set; }

   

        //// Input pop up view model
        public PopUpVM popvm { get; set; }

        // Calculate pop up view model
        public CalculateVM calvm { get; set; }

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

        public static ObservableCollection<Person> GridCollection { get; set; } // Data grid in bill splitter window
       
        public BillSplitterVM()
        {

            popvm = new PopUpVM();
            GridCollection = new ObservableCollection<Person>();
            GridCollection.CollectionChanged += OnCollectionChanged;
            popCommand = new CommandHandler(popvm.PopUp.OpenWindow);
            calvm = new CalculateVM(Subtotal);
            calculateCommand = new CommandHandler(calvm.Calculate.OpenWindow);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Subtotal = GridCollection.Sum(person => person.Product.Price);
        }
    }
}
