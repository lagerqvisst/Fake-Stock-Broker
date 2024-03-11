using DataLayer;
using StockManager.Client.Models;

namespace BusinessLayer
{
    public class Login
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public User LoginUser(string username, string password)
        {
            User user = unitOfWork.UserRepository.FirstOrDefault(u => u.username == username && u.password == password);
            return user;
        }
    }
}
