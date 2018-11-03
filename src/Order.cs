using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class Order {
        private int orderID;
        private String phoneNum = null;
        private String statusID = null;
        private double total = -1.0;
        private List<Pizza> pizzaList = new List<Pizza>();
        private List<Drink> drinkList = new List<Drink>();
        private double price = -1.0;
        private DateTime date;

        public Order(String phoneNum) {
            this.phoneNum = phoneNum;
        }
        public int OrderID { get => orderID; set => orderID = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string StatusID { get => statusID; set => statusID = value; }
        public double Total { get => total; set => total = value; }
        public List<Pizza> PizzaList { get => pizzaList; set => pizzaList = value; }
        public double Price { get => price; set => price = value; }
        public List<Drink> DrinkList { get => drinkList; set => drinkList = value; }
        public DateTime Date { get => date; set => date = value; }

        public void updatePrice() {

        }
    }
}
