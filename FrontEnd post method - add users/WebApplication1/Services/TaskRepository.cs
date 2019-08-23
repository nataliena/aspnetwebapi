using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class TaskRepository
    {
        private readonly ToDoDbContext db;
        public TaskRepository (ToDoDbContext context)
        {
            db = context;
        }
        public List<Task> GetAll()
        {
            return db.Tasks.ToList();
        }
    }
}
