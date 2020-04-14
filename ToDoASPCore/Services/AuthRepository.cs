using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoASPCore.Utils;
using ToDoASPCore.ViewModel;

namespace ToDoASPCore.Services
{
    public class AuthRepository
    {
        private ConsumeAuth consumeAuth;
        public AuthRepository(ConsumeAuth consumeAuth)
        {
            this.consumeAuth = consumeAuth;
        }

        public void Register(SignInUser signInUser)
        {
            consumeAuth.Register<SignInUser>("auth", signInUser);
        }
    }
}
