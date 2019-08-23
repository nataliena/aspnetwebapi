using System.Collections.Generic;
using Task = WebApplication1.Models.Task;


using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static IList<Task>_tasks = new List<Task>
        {
            new Task
            {
              Id=1,
              Title="Task 1",
              Description="Description of Task 1"
              },
            new Task
            {
              Id=2,
              Title="Task 2",
              Description="Description of Task 2"
              },
            new Task
            {
              Id=3,
              Title="Task 3",
              Description="Description of Task 3"
              },
            new Task
            {
              Id=4,
              Title="Task 4",
              Description="Description of Task 4"
              }

        };


        private readonly TaskRepository repo;

        public TasksController (TaskRepository _repo)
        {
            repo = _repo;

        }

        // GET api/tasks
      
        [HttpGet]
        //public ActionResult<string> Get()
        public ActionResult<IList<Task>> Get()
        {
            //return StatusCode(StatusCodes.Status404NotFound, "Hello World");
            //return NotFound("Hello World");
            //return Ok("Hello World");

            return Ok(_tasks);

        }
        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            Task task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound($"Task with id : {id} not found");
                
            }
            return Ok(task);

        }
        // api/tasks
        [HttpPost]
        public ActionResult<string> Post([FromBody]Task obj)
        {
            Task newTask = new Task
            {
                Id = _tasks.Count() + 1,
                Title = obj.Title,
                Description = obj.Description

            };
            _tasks.Add(newTask);
            return Ok("Get a post request");
        }

        [HttpPut("{id}")]
        public ActionResult<Task> Put([FromBody]Task obj, int id)
        {
            Task task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound($"Task with id : {id} not found");

            }

            task.Title = obj.Title;
            task.Description = obj.Description;


            return Ok("Get a put request");
        }





        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id,[FromQuery]string user)
        //{
        //    return $"endpoint {id}, from query {user}";
        //}
    }
}