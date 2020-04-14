using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoASPCore.Models;
using ToDoASPCore.Repository;
using ToDoASPCore.Utils;

namespace ToDoASPCore.Services
{
    public class ToDoRepository : IRepository<ToDo>
    {

		//public static IRepository<ToDo> Instance
		//{
		//	get { return instance ?? (instance = new ToDoRepository()); }
		//}
		private Consume consume;
		public ToDoRepository(Consume _consume)
		{
			consume = _consume;
		}

		public void Create(ToDo t)
		{
			consume.Post<ToDo>("ToDo", t);
		}

		public void Delete(int id)
		{
			consume.Delete("ToDo", id);
		}

		public List<ToDo> GetAll()
		{
			return consume.GetAll<ToDo>("ToDo");
		}

		public ToDo GetOne(int id)
		{
			return consume.GetOne<ToDo>("Todo", id);
		}

		public void Update(ToDo t)
		{
			consume.Put("ToDo", t);
		}
	}
}
