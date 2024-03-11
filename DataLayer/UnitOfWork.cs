using StockManager.Client.Models;
using System.Numerics;

namespace DataLayer
{
    public class UnitOfWork
    {
        public Context context { get; set; }


        public Repository<User> UserRepository
        {
            get; private set;
        }

        public Repository<Stock> StockRepository
        {
            get; private set;
        }


        public UnitOfWork()
        {
            context = new Context(); // Initialisera patientMgmtContext
            UserRepository = new Repository<User>();
            StockRepository = new Repository<Stock>();



            //Initialize the tables if this is the first UnitOfWork.


            if (UserRepository.IsEmpty())
            {
                Fill();
            }


        }

        public void Save()
        {
            context.SaveChanges();
        }

        private void Fill()
        {
            var usersinDb = context.Users.ToList();
            foreach (var user in usersinDb)
            {
                UserRepository.Add(user);
            }
        }
    }
}
