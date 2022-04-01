using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Logic.Service
{
    public class FreeDayService
    {
        public List<int> NonWorkingDaysNonLeapYear { get; set; }


        public FreeDayService()
        {
            NonWorkingDaysNonLeapYear = new List<int>()
            {
                new DateTime(2022,01,01).DayOfYear,
                new DateTime(2022,01,07).DayOfYear,
                new DateTime(2022, 04,20).DayOfYear,
                new DateTime(2022, 05, 01).DayOfYear,
                new DateTime(2022, 05, 25).DayOfYear,
                new DateTime(2022, 08, 03).DayOfYear,
                new DateTime(2022, 09, 08).DayOfYear,
                new DateTime(2022, 10, 12).DayOfYear,
                new DateTime(2022, 10, 23).DayOfYear,
                new DateTime(2022, 12, 08).DayOfYear
            };
        }

        public bool CheckIfDateIsNonWorkingDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            else if (date.Month == 1 && (date.Day == 1 || date.Day == 7))
            {
                return true;
            }
            else if (date.Month == 4 && date.Day == 20)
            {
                return true;
            }
            else if (date.Month == 5 && (date.Day == 1 || date.Day == 25))
            {
                return true;
            }
            else if (date.Month == 8 && date.Day == 3)
            {
                return true;
            }
            else if (date.Month == 9 && date.Day == 8)
            {
                return true;
            }
            else if (date.Month == 10 || (date.Day == 12 && date.Day == 23))
            {
                return true;
            }
            else if (date.Month == 12 && date.Day == 8)
            {
                return true;
            }
            else 
                return false;
            
        }

        public bool CheckIfDateIsNonWorkingDay1(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) ||
                (date.Month == 1 && (date.Day == 1 || date.Day == 7)) ||
                (date.Month == 4 && date.Day == 20) ||
                (date.Month == 5 && (date.Day == 1 || date.Day == 25)) ||
                (date.Month == 8 && date.Day == 3) ||
                (date.Month == 9 && date.Day == 8) ||
                (date.Month == 10 && (date.Day == 12 || date.Day == 23)) ||
                (date.Month == 12 && date.Day == 8);
        }
        public bool CheckIfDateIsNonWorkingDay2(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            if (!DateTime.IsLeapYear(date.Year))
            {
                return NonWorkingDaysNonLeapYear.Contains(date.DayOfYear);
            }

            if (date.DayOfYear > (DateTime.DaysInMonth(date.Year, 1) + DateTime.DaysInMonth(date.Year, 2)))
            {
                return NonWorkingDaysNonLeapYear.Contains(date.DayOfYear - 1);
            }

            return NonWorkingDaysNonLeapYear.Contains(date.DayOfYear);
        }
    }
}
