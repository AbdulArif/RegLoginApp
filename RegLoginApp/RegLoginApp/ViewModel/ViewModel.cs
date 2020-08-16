using RegLoginApp.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RegLoginApp.ViewModel
{
    public class ViewModel
    {
        public ObservableCollection<OrderInfo> OrdersInfo { get; set; }

        public ViewModel()
        {
            this.OrdersInfo = new ObservableCollection<OrderInfo>();
            GenerateOrders();
        }
        private void GenerateOrders()
        {
            OrdersInfo.Add(new OrderInfo(1001,"ALFKI","Maria","Kolkata","India"));
            OrdersInfo.Add(new OrderInfo(1002, "ARIF1", "Arif", "Durgapur", "India"));
            OrdersInfo.Add(new OrderInfo(1003, "SAFIK1", "Safik", "SILIGURI", "India"));
            OrdersInfo.Add(new OrderInfo(1004, "JOHN1", "JOhn", "Kolkata", "India"));

        }
    }
}
