using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class DataManipulation {
        private static SqlConnection connection = null;

        public static SqlConnection Connection { get => connection; set => connection = value; }

        public static void InsertCustomer(Customer c, InsertType e) {
            StringBuilder sb = new StringBuilder("INSERT INTO Customer ");
            if (e == InsertType.FULL) {
                String columns = "( PhoneNumber, FirstName, LastName, Password, Street, City, State, ZIP)";
                sb.Append(columns);
                String values = "VALUES (" + c.toString() + ")";
                sb.Append(values);
                Console.WriteLine(sb);
                String sql = sb.ToString();
                SqlCommand command = new SqlCommand(sql, Connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
            }
            else if (e == InsertType.BASIC) {
                String columns = "(PhoneNumber, FirstName, LastName, Password)";
                sb.Append(columns);
                String[] substr = (c.toString()).Split(',');
                List<String> temp = substr.ToList();
                int i = 4;
                int j = substr.Length ;
                temp.RemoveRange(i, ( j  - i) );
                substr = temp.ToArray();
                String str = String.Join(",", substr);
                Console.WriteLine(str);
                String values = "VALUES (" + str + ")";
                sb.Append(values);
                String sql = sb.ToString();
                SqlCommand command = new SqlCommand(sql, Connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }

        public static void InsertTopping(Customer c) {
            Topping top = c.Order.PizzaList[0].Topping1;
            StringBuilder sb = new StringBuilder("INSERT INTO Topping ");
            String columns = "( Name, Price )";
            String values = "VALUES (" + top.toString() +")";
            sb.Append(columns);
            sb.Append(values);
            String sql = sb.ToString();
            Console.WriteLine(sql);
            SqlCommand command = new SqlCommand(sql, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
        }
        public static void InsertSize(String sizeName, double sizePrice) {
            
            StringBuilder sb = new StringBuilder("INSERT INTO Size ");
            String name = sizeName;
            Object price = sizePrice;
            String str = "\'" + name + "\', " + price;
            String columns = "( Name, Price )";
            String values = "VALUES (" + str  + ")";
            sb.Append(columns);
            sb.Append(values);
            String sql = sb.ToString();
            Console.WriteLine(sql);
            SqlCommand command = new SqlCommand(sql, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
        }
        public static void InsertPizza(Pizza p) {
            String columns = "(Size, Topping1, Topping2, Topping3, Topping4)";
            String values = ("VALUES (@size, @topping1, @topping2, @topping3, @topping4)");
            StringBuilder sb = new StringBuilder("INSERT INTO Pizza ");
            sb.Append(columns);
            sb.Append(values);
            String sql = sb.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(sql, Connection);
            command.CommandText = sql;
            command.Parameters.Add("@size", SqlDbType.VarChar).Value = p.Size;
            command.Parameters.Add("@topping1", SqlDbType.VarChar).Value = p.Topping1.Name;
            command.Parameters.Add("@topping2", SqlDbType.VarChar).Value = p.Topping2.Name;
            command.Parameters.Add("@topping3", SqlDbType.VarChar).Value = p.Topping3.Name;
            command.Parameters.Add("@topping4", SqlDbType.VarChar).Value = p.Topping4.Name;
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
        }
        public static void InsertPizza(Customer c) {
            Int32 newPizzaID;
            StringBuilder col = new StringBuilder("( Size, ");
            String columns = "(Size, Topping1, Topping2, Topping3, Topping4)";
            String output = "OUTPUT INSERTED.PizzaID ";
            SqlDataAdapter adapter = new SqlDataAdapter();
            foreach(Pizza pizza in c.Order.PizzaList) {
                StringBuilder sb = new StringBuilder("INSERT INTO Pizza ");
                String[] attributes = new string[5];
                attributes[0] = Utility.quote(pizza.Size);
                attributes[1] = Utility.quote(pizza.Topping1.Name);
                attributes[2] = Utility.quote(pizza.Topping2.Name);
                attributes[3] = Utility.quote(pizza.Topping3.Name);
                attributes[4] = Utility.quote(pizza.Topping3.Name);
                String str = String.Join(",", attributes);
                String values = "VALUES (" + str + ")";
                sb.Append(columns);
                sb.Append(output);
                sb.Append(values);
                String sql = sb.ToString();
                Console.WriteLine(sql);
                SqlCommand command = new SqlCommand(sql, Connection);
                newPizzaID = Convert.ToInt32(command.ExecuteScalar());
                pizza.PizzaID = newPizzaID;
                Console.WriteLine(newPizzaID);
                InsertPizzaIdentity(c);
                //adapter.InsertCommand = command;
                //adapter.InsertCommand.ExecuteNonQuery();
            }
        }
        public static void InserCard(Customer c) {
            int cardIndex = c.Cards.Count - 1;
            StringBuilder sb = new StringBuilder("INSERT INTO CreditCard ");
            String columns = "(Name, Number, Expiration)";
            String output = "OUTPUT INSERTED.CreditCardID ";
            String values = "VALUES ( @name, @number, @date )";
            sb.Append(columns);
            sb.Append(output);
            sb.Append(values);
            String sql = sb.ToString();
            Console.WriteLine(sql);
            SqlCommand command = new SqlCommand(sql, Connection);
            command.CommandText = sql;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = c.Cards[cardIndex].Name;
            command.Parameters.Add("@number", SqlDbType.VarChar).Value = c.Cards[cardIndex].Number;
            command.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Parse(c.Cards[cardIndex].DateString).ToString();
            c.Cards[cardIndex].CreditCardID = Convert.ToInt32(command.ExecuteScalar());
            InsertCreditCardIdentity(c);
        }
        public static void InsertDrink(String name, Double price) {
            StringBuilder sb = new StringBuilder("INSERT INTO Drink ");
            String columns = "(Name, Price)";
            String values = "VALUES( @name, @price)";
            sb.Append(columns);
            sb.Append(values);
            String sql = sb.ToString();
            SqlCommand command = new SqlCommand(sql, Connection);
            command.CommandText = sql;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
        }
        public static void InsertOrder(Customer c) {
            StringBuilder sb = new StringBuilder("INSERT INTO [Order]");
            String columns = "(CustomerID, CreditCardID, DrinkID, Price)";
            String values = "VALUES ( @customer, @card, @drink, @price) ";
            String output = "OUTPUT INSERTED.OrderID ";
            sb.Append(columns);
            sb.Append(output); 
            sb.Append(values);
            String sql = sb.ToString();
            SqlCommand command = new SqlCommand(sql, Connection);
            command.CommandText = sql;
            command.Parameters.Add("@customer", SqlDbType.VarChar).Value = c.PhoneNumber;
            command.Parameters.Add("@card", SqlDbType.Int).Value = c.Cards[0].CreditCardID;
            command.Parameters.Add("@drink", SqlDbType.VarChar).Value = c.Order.DrinkList[0].Name;
            command.Parameters.Add("@price", SqlDbType.Decimal).Value = c.Order.Price;
            Console.WriteLine(command.CommandText);
            c.Order.OrderID = Convert.ToInt32(command.ExecuteScalar());
        }
        private static void InsertPizzaIdentity(Customer c) {
            String columns = ("(OrderID, PizzaID) ");
            String values = ("VALUES ( @order, @pizza)");
            foreach(Pizza pizza in c.Order.PizzaList) {
                StringBuilder sb = new StringBuilder("INSERT INTO PizzaOrder ");
                int pizzaID = pizza.PizzaID;
                int orderID = c.Order.OrderID;
                sb.Append(columns);
                sb.Append(values);
                String sql = sb.ToString();
                SqlCommand command = new SqlCommand(sql, Connection);
                command.Parameters.Add("@order", SqlDbType.Int).Value = orderID;
                command.Parameters.Add("@pizza", SqlDbType.Int).Value = pizzaID;
                SqlDataAdapter adapter = new SqlDataAdapter();
                Console.WriteLine(command.CommandText);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }
        private static void InsertCreditCardIdentity(Customer c) {
            String columns = ("(CustomerID, CreditCardID)");
            String values = ("VALUES (@customer, @card)");
            CreditCard creditCard = c.Cards[c.Cards.Count - 1];
            StringBuilder sb = new StringBuilder("INSERT INTO CustomerCreditCard ");
            int cardID = creditCard.CreditCardID;
            String customerID = c.PhoneNumber;
            sb.Append(columns);
            sb.Append(values);
            String sql = sb.ToString();
            SqlCommand command = new SqlCommand(sql, Connection);
            command.Parameters.Add("@customer", SqlDbType.VarChar).Value = customerID;
            command.Parameters.Add("@card", SqlDbType.VarChar).Value = cardID;
            Console.WriteLine(command.CommandText);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
        }
    }
}
