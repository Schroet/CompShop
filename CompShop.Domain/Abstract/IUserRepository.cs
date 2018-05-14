using CompShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Domain.Abstract
{
   public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        void SaveUser(User user);

    }
}
