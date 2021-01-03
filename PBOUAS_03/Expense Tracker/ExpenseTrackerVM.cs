using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PBOUAS_03
{
    public class ExpenseTrackerVM : ObservableObject // Inhertance
    {

        public List<Expense> Expenses { get; set; }
        public ExpenseOverviewVM overviewVM { get; set; }


        // Command handler
        public CommandHandler addButton { get; private set; }
        public CommandHandler overviewButton { get; private set; }

        // Input Handler
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
            }
        }

        private float _price;
        public float Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private DateTime _date = DateTime.Now.Date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public ExpenseTrackerVM()
        {
            Expenses = new List<Expense>();
            overviewVM = new ExpenseOverviewVM();
            addButton = new CommandHandler(add);
            overviewButton = new CommandHandler(overviewVM.openWindow);
        }

        private void add()
        {
            try
            {
                if (string.IsNullOrEmpty(ItemName)) { throw new EmptyException(); }
                ExpenseTB tb = new ExpenseTB();
                tb.Item = ItemName;
                tb.Price = Price;
                tb.Date = Date;
                tb.Category = Category;
                overviewVM.OverviewGrid.Add(tb);
                ExpenseOverviewVM.ExpenseDB.ExpenseTBs.InsertOnSubmit(tb);
                ExpenseOverviewVM.ExpenseDB.SubmitChanges();
                MessageBoxResult message = MessageBox.Show("Your item has been added");
            }
            catch(EmptyException x) { MessageBox.Show(x.Message); }
        }

    }
}
