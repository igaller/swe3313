using System;

namespace Pizza
{
    class Drink
    {
        private String drinkName = null;
        private double drinkPrice = null;

        public string DrinkName
        {
            get
            {
                return drinkName;
            }

            set
            {
                drinkName = value;
            }
        }

        public double DrinkPrice
        {
            get
            {
                return drinkPrice;
            }

            set
            {
                drinkPrice = value;
            }
        }

        public String toString()
        {
            String[] drinkData = new string[4];
            drinkData[0] = Utility.quote(creditCardNumber);
            drinkData[1] = Utility.quote(CreditCardName);
            drinkData[2] = Utility.quote(CreditCardNumber);
            drinkData[1] = Utility.quote(CreditCardExpiration);

            String collectDrink = string.Join(",", drinkData);
            return collectDrink;
        }
    }
}
