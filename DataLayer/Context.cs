
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StockManagement;Integrated Security=True;");


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define your model here if needed
            base.OnModelCreating(modelBuilder);
        }

        public void Reset()
        {
            #region Remove Tables
            using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?'", conn))
            {
                conn.Open();
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        // throw;
                    }
                }
                conn.Close();
            }
            #endregion
        }

        public Context()
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }


    }
}
