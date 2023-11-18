using System;

public class cardHolder
{
    string cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    //constructor
    public cardHolder(string cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getCardNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
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

    public void setCardNum(string newCardNum)
    {
        cardNum = newCardNum;
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

    public static void Main()
    {
        void PrintOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void Deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void Withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            double withdrawal = double.Parse(Console.ReadLine());
            //check if user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insuficient Balance:(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank Youu:)");
            }
        }

        void Balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("2345671890123456", 1234, "Qaby", "Qurbanov", 258.17));
        cardHolders.Add(new cardHolder("8129012123459873", 5432, "Saby", "Surbanov", 764.00));
        cardHolders.Add(new cardHolder("3456781290124535", 7668, "Daby", "Durbanov", 342.97));
        cardHolders.Add(new cardHolder("0123456123456789", 8765, "Kaby", "Yurbanov", 279.66));
        cardHolders.Add(new cardHolder("1234567890123456", 2455, "Maby", "Nurbanov", 145.34));

        //Prompt user
        Console.WriteLine("welcome to SimpleATM");
        Console.WriteLine("Please enter your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized! Please try again."); }
            }
            catch { Console.WriteLine("Card not recognized! Please try again."); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against our db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin! Please try again."); }
            }
            catch { Console.WriteLine("Incorrect Pin! Please try again."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { Deposit(currentUser); }
            else if (option == 2) { Withdraw(currentUser); }
            else if (option == 3) { Balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("THANKSSSS");

    }
}