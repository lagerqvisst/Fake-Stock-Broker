using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using BusinessLayer;

namespace Testing;

class Program
{
    static void Main(string[] args)
    {
        Context context = new Context();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        Context.Seed();


    }
}
