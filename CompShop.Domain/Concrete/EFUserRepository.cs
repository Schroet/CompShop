using CompShop.Domain.Abstract;
using CompShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Domain.Concrete
{
   public class EFUserRepository : IUserRepository
    {

        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public void SaveUser(User user)
        {
            if (user.UserId != "")
            {
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.UserId);
                if (dbEntry != null)
                {
                    dbEntry.UserId = user.UserId;
                    dbEntry.Password = user.Password;
                    dbEntry.Country = user.Country;

                }
            }
            context.SaveChanges();
        }

    }
}
