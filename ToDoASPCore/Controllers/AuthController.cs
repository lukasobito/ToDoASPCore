using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoASPCore.Services;
using ToDoASPCore.Utils;
using ToDoASPCore.ViewModel;
using Tools.Cryptography;

namespace ToDoASPCore.Controllers
{
    public class AuthController : Controller
    {
        private AuthRepository authRepository;
        public AuthController(AuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(SignInUser signInUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RSAEncryption encryption = new RSAEncryption();
                    signInUser.Pwd = System.Text.Encoding.UTF8.GetString(encryption.Encrypt(signInUser.Pwd));
                    authRepository.Register(signInUser);
                    return RedirectToAction("Login");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }

            return View(signInUser);
        }
    }
}