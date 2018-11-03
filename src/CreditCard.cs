using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class CreditCard {
        int creditCardID = 0;
        String name = null;
        int number = 0;
        DateTime expirationDate;
        String dateString = null;

        public string Name { get => name; set => name = value; }
        public int Number { get => number; set => number = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public int CreditCardID { get => creditCardID; set => creditCardID = value; }
        public string DateString { get => dateString; set => dateString = value; }

        public Object toString() {
            Object[] attributes = new Object[3];
            attributes[0] = Utility.quote(Name);
            attributes[1] = Number;
            attributes[2] = DateTime.Parse(DateString).ToString("yyyy-MM-dd");
            Object str = String.Join(",", attributes);
            return str;
        }
    }
}
