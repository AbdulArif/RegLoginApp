using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RegLoginApp.Tables
{
    public class OrderInfo : INotifyPropertyChanged
    {
        private int orderID;
        private string customerID;
        private string customerName;
        private string shipCity;
        private string shipCountry;

        public int OrderID
        {
            get { return orderID; }
            set { this.orderID = value;
            RaisePropertyChanged("OrderID");
            }
        }
        public string CustomerID
        {
            get { return customerID; }
            set
            {
                this.customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                this.customerName = value;
                RaisePropertyChanged("CustomerName");
            }
        }
        public string ShipCity
        {
            get { return shipCity; }
            set
            {
                this.shipCity = value;
                RaisePropertyChanged("ShipCity");
            }
        }
        public string ShipCountry
        {
            get { return shipCountry; }
            set
            {
                this.shipCountry = value;
                RaisePropertyChanged("ShipCountry");
            }
        }

        public OrderInfo(int orderID, string customerID, string customerName, string city, string country)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.CustomerName = customerName;
            this.ShipCity = city;
            this.ShipCountry = country;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
