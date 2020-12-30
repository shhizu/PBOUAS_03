using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PBOUAS_03
{
    public class Product
    {
        public string Item { get; set; }
        public double Price { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public Product Product { get; set; } // Aggregation 

        public Person(Product Product, string Name = " ")
        {
            this.Name = Name;
            this.Product = Product;
        }
    }

    public abstract class Win // Polymorphism 
    {
        public abstract void OpenWindow();
        public abstract void CloseWindow();
    }

    public class PopUp : Win
    {
        private static billPopUp _win { get; set; }
        public override void OpenWindow()
        {
            _win = new billPopUp();
            _win.ShowDialog();
        }

        public override void CloseWindow()
        {
            _win.Close();
        }

    }

    public class Calculate : Win
    {

        private static calculateWin _win { get; set; }
        public override void OpenWindow()
        {
            _win = new calculateWin();
            _win.ShowDialog();
        }

        public override void CloseWindow()
        {
            _win.Close();
        }

        public double getTotal(double Subtotal, double Discount, double Others)
        {
            double res = 0;
            res = (Subtotal + Others) - Discount;
            return res;
        }
    }


}

