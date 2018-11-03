using System;
using System.Collections.Generic;

namespace Pizza {
    class Customer {
        private String phoneNumber = null;
        private String firstName = null;
        private String lastName = null;
        private String password = null;
        private String street = null;
        private String city = null;
        private String state = null;
        private String zip = null;
        private Order order = null;
        private List<CreditCard> cards = new List<CreditCard>();

        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        internal Order Order { get => order; set => order = value; }
        internal List<CreditCard> Cards { get => cards; set => cards = value; }

        public Customer() {

        }

        public void setOrder() { Order = new Order(this.PhoneNumber); }
        public Order getOrder() { return Order; }

        public String toString() {
            String[] attributes = new string[8];
            attributes[0] = Utility.quote(PhoneNumber);
            attributes[1] = Utility.quote(FirstName);
            attributes[2] = Utility.quote(LastName);
            attributes[3] = Utility.quote(Password);
            attributes[4] = Utility.quote(Street);
            attributes[5] = Utility.quote(City);
            attributes[6] = Utility.quote(State);
            attributes[7] = Utility.quote(Zip);
            String str = string.Join(",", attributes);
            return str;
        }
        
    }
}
