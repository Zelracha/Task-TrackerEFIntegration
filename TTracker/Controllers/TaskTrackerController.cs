using Microsoft.AspNetCore.Mvc;
using TTracker.Data;
using Task = TTracker.Models.Task;
namespace TTracker.Controllers
{
    public class TaskTrackerController : Controller
    {
       private readonly ApplicationDbContext _context;

        public TaskTrackerController(ApplicationDbContext pDbContext)
        {
            _context = pDbContext;
        }
        public IActionResult Index()
        {
            List<Task> _myTasks = new List<Task>();
            _myTasks = _context.Tasks.ToList();
            return View(_myTasks);
        }

        [HttpGet]
        public IActionResult ManageTask(int id)
        {
            var _newTask = new Task();
            if (id > 0)
            {
                _newTask = _context.Tasks.Find(id);
            }
            return View(_newTask);
        }

        [HttpGet]
        public IActionResult UpdateStatus(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.TaskStatus = !task.TaskStatus; 
                _context.Tasks.Update(task);
                _context.SaveChanges(); 
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Save(Task pTask)
        {
            if (pTask.Id == 0)
            {
                pTask.TaskStatus = true; 
                _context.Tasks.Add(pTask);
                _context.SaveChanges(); 
                pTask.Id = _context.Tasks.Max(t => t.Id); 
            }
            else
            {
                _context.Tasks.Update(pTask);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Task pTask)
        {
            var _tasktoremove = _context.Tasks.Find(pTask.Id);
            if (_tasktoremove != null)
            {
                _context.Tasks.Remove(_tasktoremove);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
