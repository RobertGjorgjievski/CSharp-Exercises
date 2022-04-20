using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Video.Rental.Data.Models
{
    public class RentalInfo
    {
        public Movie Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DataReturnet { get; set; }

        public RentalInfo()
        {

        }
        public RentalInfo(Movie movie)
        {
            Movie = movie;
            DateRented = DateTime.Now;
            DataReturnet = null;
        }
    }
}
