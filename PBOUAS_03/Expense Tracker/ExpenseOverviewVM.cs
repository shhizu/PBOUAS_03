using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOUAS_03
{
    public class ExpenseOverviewVM : ObservableObject
    {
        public CommandHandler okButton { get; private set; }
        public CommandHandler deleteButton { get; private set; }
        public ObservableCollection<Expense> OverviewGrid { get; set; }

        // Input handlers
        private double _total;
        public double Total
        {
            get { return _total; }
            set { _total = value;  OnPropertyChanged(nameof(Total)); }
        }

        private Expense _selectedItem;
        public Expense SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem));}
        }

        

        private static OverviewWin _win;

        public ExpenseOverviewVM()
        {
            OverviewGrid = new ObservableCollection<Expense>();
            OverviewGrid.CollectionChanged += OnCollectionChanged;
            okButton = new CommandHandler(close);
            deleteButton = new CommandHandler(deleteRow);

        }

        public void openWindow()
        {
            _win = new OverviewWin();
            _win.ShowDialog();
        }

        private void close()
        {
            _win.Close();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Total = OverviewGrid.Sum(item => item.Price);
        }

        private void deleteRow()
        {
            OverviewGrid.Remove(SelectedItem);
        }
    }
}
