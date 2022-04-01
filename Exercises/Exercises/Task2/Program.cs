using System;
using Task2.Logic.Service;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //## 2. Create a console application that checks if a day is a working day 🔹
            //            *The app should request for a user to enter a date as an input or multiple inputs
            //           * The app should then open and see if the day is a working day
            //           * It should show the user a message whether the date they entered is working or not
            //             *Weekends are not working
            //            * 1 January, 7 January, 20 April, 1 May, 25 May, 3 August, 8 September, 12 October, 23 October and 8 December are not working days as well
            //          * It should ask the user if they want to check another date
            //            * Yes -the app runs again
            //           * No -the app closes

            FreeDayService freeDay = new FreeDayService();

            for (int i = 1990; i < 2023; i++)
            {
                int month = (i % 12) + 1;
                int day = (int)(DateTime.Now.Ticks%(DateTime.DaysInMonth(i,month))) + 1;
                DateTime date = new DateTime(i, month, day);

                bool result = freeDay.CheckIfDateIsNonWorkingDay(date);
                string working = result ? "non working" : "working";
                Console.WriteLine($"Date: {date.ToShortDateString()} is {working} day");

            }
            Console.WriteLine("------------------ Second Way ----------------------------");

            for (int i = 1990; i < 2021; i++)
            {
                int month = (i % 12) + 1;
                int day = (int)(DateTime.Now.Ticks % (DateTime.DaysInMonth(i, month))) + 1;
                DateTime date = new DateTime(i, month, day);

                bool result = freeDay.CheckIfDateIsNonWorkingDay1(date);
                string working = result ? "non working" : "working";
                Console.WriteLine($"Date: {date.ToShortDateString()} is {working} day");
            }

            Console.WriteLine("---------------------- THIRD WAY --------------------------");

            for (int i = 1990; i < 2021; i++)
            {
                int month = (i % 12) + 1;
                int day = (int)(DateTime.Now.Ticks % (DateTime.DaysInMonth(i, month))) + 1;
                DateTime date = new DateTime(i, month, day);

                bool result = freeDay.CheckIfDateIsNonWorkingDay2(date);
                string working = result ? "non working" : "working";
                Console.WriteLine($"Date: {date.ToShortDateString()} is {working} day");
            }

            Console.ReadLine();
        }
    }
}
