using System;
using System.Data;
using System.Globalization;

internal class Program
{
    // global variables for order history
    public static double total = 0;
    public static string orderHist = $"\n";
    private static void Main(string[] args)
    {
        userAuth();
    }


    // Validate username and password
    static void userAuth()
    {
        // Known usernames and passwords
        string uName = "Saajid";
        string uPass = "1234";


        string iPass, iName;
        int numAttempts = 3;


        do
        {
            Console.WriteLine("Enter username:");
            iName = Console.ReadLine();
            Console.WriteLine("Enter password");
            iPass = Console.ReadLine();

            numAttempts--;

            if (iPass == uPass && iName == uName)
            {
                Console.WriteLine("SUCCESS");
                dispMenu();
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Incorrect credentials.You have {numAttempts} attempts remaining");
            }

        }
        while (numAttempts > 0);

        if (numAttempts == 0) Console.WriteLine("Login failed. Session terminated");

    }


    // users can order coffee, view past order or exit the program
    static void dispMenu()
    {
        Console.WriteLine($"Choose an option \n\t1) Order coffee\n\t2) View previous orders\n\t3) Logout and exit");
        string uOption = Console.ReadLine();
        switch (uOption)
        {
            case "1":
                orderCoffee();
                break;
            case "2":
                dispHistory();
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("Session terminated");
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Please try again");
                dispMenu();
                break;
        }
    }


    // allows user to choose a coffee type and size
    static void orderCoffee()
    {
        double price = 0;
        bool vType = true;
        bool vSize = true;
        string typeCoffee;

        Console.WriteLine($"Choose an option\n\t1) Espresso - R35.00\n\t2) Latte - R25.00\n\t3) Cappuccino - R40.00");
        typeCoffee = Console.ReadLine();
        switch (typeCoffee)
        {
            case "1":
                typeCoffee = "Espresso";
                price += 35.00;
                vType = false;
                break;
            case "2":
                typeCoffee = "Latte";
                price += 25.00;
                vType = false;
                break;
            case "3":
                typeCoffee = "Cappuccino";
                price += 40.00;
                vType  = false;
                break;
            default:

                Console.Clear();
                Console.WriteLine("Invalid option! Try again");
                orderCoffee();
                break;
            
        }

        
        Console.WriteLine($"Choose an option\n\t1) Small\n\t2) Medium + R5.00\n\t3) Large + R10.00");
        string sizeCoffee = Console.ReadLine();
        switch (sizeCoffee)
        {
            case "1":
                sizeCoffee = "Small";
                break;
            case "2":
                sizeCoffee = "Medium";
                price += 5.00;
                break;
            case "3":
                sizeCoffee = "Large";
                price += 10.00;
                break;
            default:

                Console.Clear();
                Console.WriteLine("Invalid option! Try again");
                orderCoffee();
                break;
        }
        

        // adds user choices together into a single order
        string order = $"{typeCoffee} {sizeCoffee} R{price:N}";
        Console.WriteLine(order);

        orderHist += order + "\n";
        total += price;

        chooseAdd();

    }


    //allows user to make another order
    static void chooseAdd()
    {

        Console.WriteLine($"Enter A to make another order\tEnter any other key to continue");
        if (Console.ReadLine() == "a") orderCoffee();
        else
        {
            Console.Clear();
            Console.WriteLine($"Your total is: R{total:N}\n\tPlease pay at the register");
            Console.WriteLine("Press any key to return to display menu");
            Console.ReadKey();
            dispMenu();
        }
    }


    // displays all previous orders
    static void dispHistory()
    {
        Console.Clear();
        Console.WriteLine(orderHist);
        Console.WriteLine("Press any key to return to display menu");
        Console.ReadKey();
        Console.Clear();
        dispMenu();

    }



}