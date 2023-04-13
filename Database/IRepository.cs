using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IRepository
    {
        public void AddUser(User User);
        public User? getUserByLogin(String Login);
        public Boolean Login(User User);
    }
}
