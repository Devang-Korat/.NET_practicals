using System;

namespace practical_3
{
    class Expense
    {
        public string Categories;
        public double Budget;
        public double Spent;

        public Expense(string categories, double budget)
        {
            Categories = categories;
            Budget = budget;
            Spent = 0;
        }

        public void AddExpense(double amount)
        {
            if (Spent + amount > Budget)
            {
                Console.WriteLine("Your budget has reached the limit for " + Categories + ".");
            }
            else
            {
                Spent += amount;
                Console.WriteLine("Expense added successfully.");
            }
        }

        public void Display()
        {
            Console.WriteLine(Categories +
                              "\tBudget: " + Budget +
                              "\tSpent: " + Spent +
                              "\tRemaining: " + (Budget - Spent));
        }
    }

    class SecondExpense : Expense
    {
        public SecondExpense(string categories, double budget) : base(categories, budget)
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== EXPENSE TRACKER =====");

            Console.Write("Enter Total Pocket Money: ");
            double pocketMoney = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nAllocate Budget");

            Console.Write("Food: ");
            double foodBudget = Convert.ToDouble(Console.ReadLine());

            Console.Write("Travel: ");
            double travelBudget = Convert.ToDouble(Console.ReadLine());

            Console.Write("Shopping: ");
            double shoppingBudget = Convert.ToDouble(Console.ReadLine());

            Console.Write("Entertainment: ");
            double entertainmentBudget = Convert.ToDouble(Console.ReadLine());

            Console.Write("Medical: ");
            double medicalBudget = Convert.ToDouble(Console.ReadLine());

            double totalBudget = foodBudget + travelBudget + shoppingBudget + entertainmentBudget + medicalBudget;

            if (totalBudget > pocketMoney)
            {
                Console.WriteLine("\nBudget exceeds Pocket Money!");
                return;
            }

            Expense food = new Expense("Food", foodBudget);
            Expense travel = new Expense("Travel", travelBudget);
            Expense shopping = new Expense("Shopping", shoppingBudget);
            Expense entertainment = new Expense("Entertainment", entertainmentBudget);
            SecondExpense medical = new SecondExpense("Medical", medicalBudget);

            while (true)
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Add Food Expense");
                Console.WriteLine("2. Add Travel Expense");
                Console.WriteLine("3. Add Shopping Expense");
                Console.WriteLine("4. Add Entertainment Expense");
                Console.WriteLine("5. Add Medical Expense");
                Console.WriteLine("6. View Report");
                Console.WriteLine("7. Exit");
                Console.Write("Enter Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                double amount;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Food Expense: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        food.AddExpense(amount);
                        break;

                    case 2:
                        Console.Write("Enter Travel Expense: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        travel.AddExpense(amount);
                        break;

                    case 3:
                        Console.Write("Enter Shopping Expense: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        shopping.AddExpense(amount);
                        break;

                    case 4:
                        Console.Write("Enter Entertainment Expense: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        entertainment.AddExpense(amount);
                        break;

                    case 5:
                        Console.Write("Enter Medical Expense: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        medical.AddExpense(amount);
                        break;

                    case 6:
                        Console.WriteLine("\n===== EXPENSE REPORT =====");
                        food.Display();
                        travel.Display();
                        shopping.Display();
                        entertainment.Display();
                        medical.Display();

                        double totalSpent = food.Spent +
                                            travel.Spent +
                                            shopping.Spent +
                                            entertainment.Spent +
                                            medical.Spent;

                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("Pocket Money : " + pocketMoney);
                        Console.WriteLine("Total Spent  : " + totalSpent);
                        Console.WriteLine("Remaining    : " + (pocketMoney - totalSpent));
                        break;

                    case 7:
                        Console.WriteLine("Thank You!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
    }
}
