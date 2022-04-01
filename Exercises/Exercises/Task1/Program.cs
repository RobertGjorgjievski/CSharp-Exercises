using System;
using System.Collections.Generic;
using Task1.Logic.Models;
using Task1.Logic.Services;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            //## 1. Create a console application that detect provided names in a provided text 🔹
            //     *The application should ask for names to be entered until the user enteres x
            //     * After that the application should ask for a text
            //     *When that is done the application should show how many times that name was included in the text ignoring upper / lower case

            SearchService service = new SearchService();

            List<string> names = EnterNameFromScreen();
            Console.WriteLine("Please enter text for checking:");
            string text = Console.ReadLine();

            service.CountApperancesInText(text, names);

            Console.WriteLine("=============================================");

            Dictionary<string, int> result = service.CountApperancesInText1(text, names);

            foreach (KeyValuePair<string, int> pair in result)
            {
                Console.WriteLine($"Name: {pair.Key} is contained {pair.Value} times");
            }

            Console.WriteLine("=============================================");

            List<SearchResult> result2 = service.CountApperancesInText2(text, names);

            foreach (SearchResult searchResult in result2)
            {
                Console.WriteLine($"Name: {searchResult.Name} is contained {searchResult.Appearance} times");
            }

            Console.ReadLine();
        }

        static List<string> EnterNameFromScreen()
        {
            List<string> names = new List<string>();
            Console.WriteLine("Please enter names that you want to be searched");

            while (true)
            {
                string input = Console.ReadLine();
                if(input == "X" || input == "x")
                {
                    break;
                }
                names.Add(input);

            }
            return names;
        }
    }
}
