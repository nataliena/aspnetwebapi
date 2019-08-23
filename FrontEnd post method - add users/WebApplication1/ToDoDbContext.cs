using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Task> Tasks { get; set; }
    }
}
