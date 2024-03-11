using StockManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Seed
    {
        public static void SeedDB(Context context)
        {
            context.Users.Add(new User("admin", "admin"));
            context.Users.Add(new User("test user", "123"));

            context.SaveChanges();
        }
    }
}
