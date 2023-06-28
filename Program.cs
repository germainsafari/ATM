using System;
using System.Collections.Generic;

class CardHolder
{
    public string CardNumber { get; set; }
    public int PIN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Balance { get; set; }

    public CardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        CardNumber = cardNumber;
        PIN = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<CardHolder> cardHolders = new List<CardHolder>();

        CardHolder holder1 = new CardHolder("4321 8765 1234 5678", 1234, "John", "Doe", 1250.75);
        cardHolders.Add(holder1);

        CardHolder holder2 = new CardHolder("9876 5432 1098 7654", 4321, "Jane", "Smith", 5678.90);
        cardHolders.Add(holder2);

        CardHolder holder3 = new CardHolder("2468 1357 8024 6913", 5678, "Alex", "Johnson", 3425.50);
        cardHolders.Add(holder3);

        CardHolder holder4 = new CardHolder("7890 2468 3579 8024", 9876, "Emily", "Davis", 2100.25);
        cardHolders.Add(holder4);

        CardHolder holder5 = new CardHolder("1357 8024 4691 3579", 3456, "Michael", "Brown", 10000.00);
        cardHolders.Add(holder5);

        Console.WriteLine("Welcome to GlobalATM!");
        Console.WriteLine("Please insert your debit card:");
        string debitCardNum = Console.ReadLine();

        CardHolder currentUser = cardHolders.Find(holder => holder.CardNumber == debitCardNum);

        if (currentUser != null)
        {
            Console.WriteLine("Welcome, " + currentUser.FirstName + " " + currentUser.LastName);
            Console.WriteLine("Please enter your PIN:");

            int enteredPIN;
            if (int.TryParse(Console.ReadLine(), out enteredPIN))
            {
                if (enteredPIN == currentUser.PIN)
                {
                    while (true)
                    {
                        Console.WriteLine("\nPlease choose one of the following options:");
                        Console.WriteLine("1. Deposit");
                        Console.WriteLine("2. Withdraw");
                        Console.WriteLine("3. Balance");
                        Console.WriteLine("4. Exit");

                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                Console.WriteLine("Enter the amount you want to deposit:");
                                double depositAmount;
                                if (double.TryParse(Console.ReadLine(), out depositAmount))
                                {
                                    currentUser.Balance += depositAmount;
                                    Console.WriteLine("Deposit successful.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please try again.");
                                }
                                break;

                            case "2":
                                Console.WriteLine("Enter the amount you want to withdraw:");
                                double withdrawAmount;
                                if (double.TryParse(Console.ReadLine(), out withdrawAmount))
                                {
                                    if (withdrawAmount <= currentUser.Balance)
                                    {
                                        currentUser.Balance -= withdrawAmount;
                                        Console.WriteLine("Withdrawal successful.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient funds.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please try again.");
                                }
                                break;

                            case "3":
                                Console.WriteLine("Current balance: $" + currentUser.Balance);
                                break;

                            case "4":
                                Console.WriteLine("Thank you for using GlobalATM. Goodbye!");
                                return;

                            default:
                                Console.WriteLine("Invalid option. Please try again.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect PIN. Access denied.");
                }
            }
            else
            {
                Console.WriteLine("Invalid PIN. Access denied.");
            }
        }
        else
        {
            Console.WriteLine("Invalid card number. Access denied.");
        }
    }
}
