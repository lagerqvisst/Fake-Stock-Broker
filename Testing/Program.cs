using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using BusinessLayer;
using StockManager.Client.Models;

namespace Testing;

class Program
{
    static void Main(string[] args)
    {
        Login login = new Login();

        User user = login.LoginUser("admin", "admin");
        Console.WriteLine(user.username);


    }
}
