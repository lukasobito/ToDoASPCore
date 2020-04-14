using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoASPCore.Models;
using ToDoASPCore.Repository;
using ToDoASPCore.Utils;

namespace ToDoASPCore.Services
{
    public class UserRepository : IRepository<User>
    {
        private Consume consume;
        public UserRepository(Consume _consume)
        {
            consume = _consume;
        }
        public void Create(User t)
        {
            consume.Post<User>("User", t);
        }

        public void Delete(int id)
        {
            consume.Delete("User", id);
        }

        public List<User> GetAll()
        {
            return consume.GetAll<User>("User");
        }

        public User GetOne(int id)
        {
            return consume.GetOne<User>("User",id);
        }

        public void Update(User t)
        {
            consume.Put("User", t);
        }
    }
}
