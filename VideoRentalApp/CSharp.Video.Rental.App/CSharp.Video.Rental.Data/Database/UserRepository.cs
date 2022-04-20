using CSharp.Video.Rental.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Video.Rental.Data.Database
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository()
        {
            Seed();
        }

        private void Seed()
        {
            if (!_db.Read().Any())
            {
                _db.Seed(new List<User>
                {
                    new User() { Id = 1, CardNumber = 123, FullName = "Smiley Face"}
                });
            }
        }

        public User GetUserByIdCard(int idCard)
        {
            return _db.Read().FirstOrDefault(u => u.CardNumber == idCard);
        }
        public List<int> GetAllCardNumbers()
        {
            return _db.Read().Select(u => u.CardNumber).ToList();   
        }

    }
}
