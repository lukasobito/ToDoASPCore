using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoASPCore.Models;
using ToDoASPCore.Services;

namespace ToDoASPCore.Controllers
{
    public class ToDoController : Controller
    {
        private ToDoRepository toDoRepository;
        public ToDoController(ToDoRepository _toDoRepository)
        {
            toDoRepository = _toDoRepository;
        }
        // GET: ToDo
        public ActionResult Index()
        {
            return View(toDoRepository.GetAll());
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View(toDoRepository.GetOne(id));
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            //ToDoRepository.Instance.Create();
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ToDo toDo = new ToDo
                {
                    Titre = collection["Titre"],
                    Description = collection["Description"]
                };
                toDoRepository.Create(toDo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(toDoRepository.GetOne(id));
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ToDo toDo = toDoRepository.GetOne(id);
                toDo.Titre = collection["Titre"];
                toDo.Description = collection["Description"];
                toDo.IsDone = bool.Parse(collection["IsDone"]);
                if (toDo.IsDone == true) toDo.DateValidation = DateTime.Now;
                toDoRepository.Update(toDo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(toDoRepository.GetOne(id));
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                toDoRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}