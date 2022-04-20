using CSharp.Video.Rental.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Video.Rental.Services.Interfaces
{
    public interface IMovieService
    {
        void ViewMovierList(User user);
    }
}
