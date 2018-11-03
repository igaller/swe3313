using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{

    class CreditCard
    {
        private String creditCardID = null;
        private String creditCardName = null;
        private String creditCardNumber = null;
        private String creditCardExpiration = null;

        public CreditCard(String creditCardID)
        {
            this.creditCardID = creditCardID;
        }

        public string CreditCardID
        {
            get
            {
                return creditCardID;
            }

            set
            {
                creditCardID = value;
            }
        }

        public string CreditCardName
        {
            get
            {
                return creditCardName;
            }

            set
            {
                creditCardName = value;
            }
        }

        public string CreditCardNumber
        {
            get
            {
                return creditCardNumber;
            }

            set
            {
                creditCardNumber = value;
            }
        }

        public string CreditCardExpiration
        {
            get
            {
                return creditCardExpiration;
            }

            set
            {
                creditCardExpiration = value;
            }
        }

        public String toString()
        {
            String[] creditCardData = new string[4];
            creditCardData[0] = Utility.quote(creditCardNumber);
            creditCardData[1] = Utility.quote(CreditCardName);
            creditCardData[2] = Utility.quote(CreditCardNumber);
            creditCardData[1] = Utility.quote(CreditCardExpiration);


            String collectCreditCard = string.Join(",", creditCardData);
            return collectCreditCard;
        }
    }
}