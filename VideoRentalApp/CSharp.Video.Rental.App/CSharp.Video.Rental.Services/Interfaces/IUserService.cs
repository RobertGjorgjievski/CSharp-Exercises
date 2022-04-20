using CSharp.Video.Rental.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Video.Rental.Services.Interfaces
{
    public interface IUserService
    {
        User LogIn();
        User SingUp();
        void ViewRentalMovies(User user);
    }
}
