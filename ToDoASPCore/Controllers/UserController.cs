using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoASPCore.Services;
using ToDoASPCore.ViewModel;

namespace ToDoASPCore.Controllers
{
    public class UserController : Controller
    {
        private UserRepository userRepository;
        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Inscription(SignInUser u)
        {
            if (ModelState.IsValid)
            {
                if(userRepository.GetAll().Select(x => x.Email).FirstOrDefault() == u.Email)
                {
                    //userRepository.Create(u.)
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Adresse Email déjà utilisé";
                    return View(u);
                }
            }
            else
            {
                return View(u);
            }
        }
    }
}