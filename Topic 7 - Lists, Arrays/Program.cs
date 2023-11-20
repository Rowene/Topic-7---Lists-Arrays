using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;

namespace Topic_7___Lists__Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool program = true;
            List<string> menuOption = new List<string>();
            menuOption.Add("You are given 25 random numbers ranged from 10 to 20.");
            menuOption.Add("Select what you want to do to these numbers.");
            menuOption.Add("");
            menuOption.Add("You are given 5 vegetables.");
            menuOption.Add("Adjust and edit the list to you're likings.");
            string mainMenu = "";
            while (program == true)
            {
                while ((mainMenu != "1") & (mainMenu != "2"))
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - " + menuOption[0]);
                    Console.WriteLine(menuOption[1]);
                    Console.WriteLine();
                    Console.WriteLine("2 - " + menuOption[3]);
                    Console.WriteLine(menuOption[4]);
                    Console.WriteLine();
                    Console.Write("Which program do you want to run: ");
                    mainMenu = Console.ReadLine();
                    if ((mainMenu != "1") || (mainMenu != "2")) { Console.Clear();Console.WriteLine("Error."); }
                }
                Console.Clear();
                Random generator = new Random();
                List<int> listInt = new List<int>();

                string menu1 = "";
                bool newList1 = true;
                int intListRemove = 0;
                int numIntList = 24;
                int intListAdd = 0;

                while ((mainMenu == "1") & (menu1 != "0")) 
                {
                    Console.WriteLine();
                    for (int i = 0; i <= numIntList;)
                    {
                        if (newList1 == true)
                        {
                            listInt.Add(generator.Next(10, 21));
                        }
                        Console.Write(listInt[i]);
                        if (i < numIntList)
                        {
                            Console.Write(", ");
                        }
                        i++;
                    }
                    Console.WriteLine(".");
                    bool added = false;
                    bool inputCount = false;
                    bool removed = false;
                    int count10 = 0;
                    int countX = 0;
                    int countXIn = 0;
                    newList1 = false;

                    Console.WriteLine();
                    Console.WriteLine("1 - Sort the List");
                    Console.WriteLine();
                    Console.WriteLine("2 - Make a new List of Random Numbers");
                    Console.WriteLine();
                    Console.WriteLine("3 - Remove a Number");
                    Console.WriteLine();
                    Console.WriteLine("4 - Add a Value to List");
                    Console.WriteLine();
                    Console.WriteLine("5 - Count Occurences of 10");
                    Console.WriteLine();
                    Console.WriteLine("6 - Print the Largest Value");
                    Console.WriteLine();
                    Console.WriteLine("7 - Print the smallest Value");
                    Console.WriteLine();
                    Console.WriteLine("8 - Average and Sum of Generated Numbers.");
                    Console.WriteLine();
                    Console.WriteLine("9 - Determine the Number(s) that Occur Most.");
                    Console.WriteLine();
                    Console.WriteLine("10 - Count Occurences of a Specified Value");
                    Console.WriteLine();
                    Console.WriteLine("0 - Quit");
                    Console.WriteLine();
                    Console.Write("Pick One of the Options Above: ");
                    menu1 = Console.ReadLine();
                    if (menu1 == "1")
                    {
                        listInt.Sort();
                    }
                    else if (menu1 == "2")
                    {
                        listInt.Clear();
                        newList1 = true;
                    }
                    else if (menu1 == "3")
                    {
                        while (removed == false)
                        {
                            Console.WriteLine();
                            Console.Write("Number to Remove: ");
                            intListRemove = Convert.ToInt32(Console.ReadLine());
                            if (listInt.Contains(intListRemove))
                            {
                                for (int i = 0; i <= numIntList; i++)
                                {
                                    if (listInt.Contains(intListRemove)) { listInt.Remove(intListRemove); numIntList -= 1; }
                                }
                                removed = true;
                            }
                            else { Console.WriteLine("Invalid"); }
                        }
                    }
                    else if (menu1 == "4")
                    {
                        while (added == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine("(10 - 20)");
                            Console.Write("Number to Add: ");
                            intListAdd = Convert.ToInt32(Console.ReadLine());
                            if ((intListAdd >= 10) || (intListAdd <= 20))
                            {
                                listInt.Add(intListAdd);
                                added = true;
                                numIntList++;
                            }
                            else { Console.WriteLine("Invalid, numbers must be between 10 and 20."); }
                        }
                    }
                    else if (menu1 == "5")
                    {
                        for (int i = 0; i < numIntList; i++)
                        {
                            if (listInt[i] == 10) { count10++; }
                        }
                        Console.WriteLine("There are " + count10 + " Number 10s. Click 'Enter' to Continue.");
                        Console.ReadLine();
                    }
                    else if (menu1 == "6")
                    {
                        Console.WriteLine("Largest Value is " +listInt.Max()+ ". Click 'Enter' to Continue.");
                        Console.ReadLine();
                    }
                    else if (menu1 == "7")
                    {
                        Console.WriteLine("Smallest Value is " + listInt.Min() + ". Click 'Enter' to Continue.");
                        Console.ReadLine();
                    }
                    else if (menu1 == "8")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Average Value is " + listInt.Average());
                        Console.WriteLine("The Sum of the Values is " + listInt.Sum() + ".");
                        Console.WriteLine("Click 'Enter' to Continue.");
                        Console.ReadLine();
                    }
                    else if (menu1 == "9") 
                    {
                        Console.WriteLine();
                        var groupedNumbers = listInt.GroupBy(n => n);
                        var maxFrequency = groupedNumbers.Max(g => g.Count());
                        var modes = groupedNumbers.Where(g => g.Count() == maxFrequency).Select(g => g.Key);
                        Console.Write("The Most Common Number(s) are: ");
                        foreach (var mode in modes)
                        {
                            Console.Write(mode + ", ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Click 'Enter' to Continue.");
                        Console.ReadLine ();
                    }
                    else if (menu1 == "10") 
                    {
                        while (inputCount == false)
                        {
                            Console.WriteLine();
                            Console.Write("Which Number do you want to Count: ");
                            countXIn = Convert.ToInt32(Console.ReadLine());
                            if ((countXIn >= 10) & (countXIn <= 20))
                            {
                                for (int i = 0; i < numIntList; i++)
                                {
                                    if (listInt[i] == countXIn) { countX++; }
                                }
                                Console.WriteLine();
                                Console.WriteLine("There are " + countX + " of " + countXIn + "(s) in the List.");
                                inputCount = true;
                                Console.WriteLine("Click 'Enter' to Continue.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Error. Number not Within 10 and 20.");
                            }
                        }
                    }
                    else if (menu1 == "0") { mainMenu = "0"; }
                    else { Console.WriteLine("Invalid Input, click 'Enter' to Continue."); Console.ReadLine(); }
                    Console.Clear();
                }

                List<string> listVeg = new List<string>();
                string menu2 = "";

                listVeg.Add("CARROT");
                listVeg.Add("BEET");
                listVeg.Add("CELERY");
                listVeg.Add("RADISH");
                listVeg.Add("CABBAGE");

                while ((mainMenu == "2") & (menu2 != "0"))
                {
                    bool foodRemoved;
                    string tempString ;
                    for (int i = 0; i <= listVeg.Count() - 1; i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine(i+1 + " - " +(listVeg[i]).ToUpper());
                    }
                    Console.WriteLine();
                    Console.WriteLine("Sort, Add, Remove, Search, Clear or Quit.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("What would you like to do: ");
                    menu2 = Console.ReadLine().ToUpper();
                    
                    if (menu2 == "SORT") { listVeg.Sort(); }
                    else if (menu2 == "ADD")
                    {
                        Console.WriteLine();
                        Console.Write("Which Food are you Adding: ");
                        tempString = Console.ReadLine().ToUpper();
                        listVeg.Add(tempString);
                    }
                    while (menu2 == "REMOVE")
                    {
                        Console.WriteLine() ;
                        Console.Write("Which Food are you Removing: ");
                        tempString = Console.ReadLine().ToUpper();
                        if (listVeg.Contains(tempString)) { menu2 = ""; }
                        else { Console.WriteLine("Invalid."); }
                        listVeg.Remove(tempString);
                    }
                    while (menu2 == "SEARCH")
                    {
                        Console.WriteLine();
                        Console.Write("Search Bar: ");
                        tempString = Console.ReadLine().ToUpper();
                        if (listVeg.Contains(tempString))
                        {
                            for (int i = 0;i <= listVeg.Count() - 1;i++)
                            {
                                if (listVeg[i] == tempString) { Console.WriteLine(); Console.WriteLine(i+1 + " - " + tempString); }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Click 'Enter' to Continue.");
                            Console.ReadLine();
                            menu2 = "";
                        }
                        else { Console.WriteLine("List Doesn't Contain " + tempString) ;}
                    }
                    if (menu2 == "CLEAR") { listVeg.Clear(); }
                    else if (menu2 == "QUIT") { mainMenu = "0"; }
                    Console.Clear();

                }
            }
        }
    }
}