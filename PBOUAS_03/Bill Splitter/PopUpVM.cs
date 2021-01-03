using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PBOUAS_03
{
    public class PopUpVM : ObservableObject
    {
        // Button handlers properties
        public CommandHandler cancelButton { get; private set; }
        public CommandHandler updateButton { get; private set; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ObservableCollection<Product> PopUpGrid { get; set; } // Thus, data still resides
        public PopUp PopUp { get; set; }
        public Person Person { get; set; }
        public PopUpVM()
        {

            PopUpGrid = new ObservableCollection<Product>();
            PopUp = new PopUp();
            cancelButton = new CommandHandler(PopUp.CloseWindow);
            updateButton = new CommandHandler(update);
        }


        public void update()
        {
            try
            {
                if (string.IsNullOrEmpty(Name)){throw new EmptyException();}

                foreach (Product item in PopUpGrid)
                {
                    Person = new Person(item, Name);
                    BillSplitterVM.GridCollection.Add(Person);
                }
                PopUpGrid = new ObservableCollection<Product>(); // Creating a new pop up grid because billsplitterVM doesnt re run PopUpVM constructor
                PopUp.CloseWindow();

            }
            catch (EmptyException x)
            {
                MessageBoxResult message = MessageBox.Show(x.Message);
            }
          

        }
    }
}
