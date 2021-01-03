using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Linq;

namespace PBOUAS_03
{
    public class ExpenseOverviewVM : ObservableObject
    {

        // Database and Datagrid
        public static ExpenseLINQDataContext ExpenseDB { get; set; }
        public ObservableCollection<ExpenseTB> OverviewGrid { get; set; }
        public static double TotalExpense { get; set; }
        private static OverviewWin _win;


        // Command Handlers
        public CommandHandler okButton { get; private set; }
        public CommandHandler deleteButton { get; private set; }
        public CommandHandler saveButton { get; private set; }

        // Input Handlers

        private double _total;
        public double Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }

        private ExpenseTB _selectedItem;
        public ExpenseTB SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); }
        }



        public ExpenseOverviewVM()
        {
            ExpenseDB = new ExpenseLINQDataContext(Properties.Settings.Default.ExpenseTrackerDBConnectionString);
            OverviewGrid = new ObservableCollection<ExpenseTB>();
            loadData();
            OverviewGrid.CollectionChanged += OnCollectionChanged;
            okButton = new CommandHandler(close);
            deleteButton = new CommandHandler(deleteRow);
            saveButton = new CommandHandler(saveToDatabase);

        }

        // Methods
        private void loadData()
        {
            foreach (var item in ExpenseDB.ExpenseTBs)
            {
                OverviewGrid.Add(item);
            }
        }

        public void openWindow()
        {
            _win = new OverviewWin();
            _win.ShowDialog();
        }

        private void deleteRow()
        {
            OverviewGrid.Remove(SelectedItem);
            ExpenseDB.ExpenseTBs.DeleteOnSubmit(SelectedItem);
        }

        private void close()
        {
            _win.Close();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Total = ExpenseDB.ExpenseTBs.Sum(item => item.Price);
        }


        private void saveToDatabase()
        {
            ExpenseDB.SubmitChanges();
        }
    }
}
