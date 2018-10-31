using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class Order {
        private String orderID = null;
        private String phoneNum = null;
        private String statusID = null;
        private double total = -1.0;
        private List<Pizza> pizzaList = new List<Pizza>();

        public Order(String phoneNum) {
            this.phoneNum = phoneNum;
        }
        public int MyProperty { get; set; }
        public string OrderID { get => orderID; set => orderID = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string StatusID { get => statusID; set => statusID = value; }
        public double Total { get => total; set => total = value; }
        public List<Pizza> PizzaList { get => pizzaList; set => pizzaList = value; }
    }
}
