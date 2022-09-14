using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstname()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. deposit");
            Console.WriteLine("2. WithDraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to dewposit ?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for you $$. Your new balance is: " +currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal= double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insuficient balance :(");
            }
            else
            {
                double newBalance = (currentUser.getBalance() - withdrawal);
                Console.WriteLine("You´re good tyo go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance:" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5304675123455620", 1234, "John", "Griffith",150.31));
        cardHolders.Add(new cardHolder("1543201687941031", 4321, "Ahsley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("1034519645412561", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("1611515401548974", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("4415821265526856", 4826, "Dawn", "Smith", 54.27));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break;  }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("incorrect Pin. Please try again"); }
            }

            catch { Console.WriteLine("incorrect Pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstname() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }

            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }

}