using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetTask.Models;

namespace DotnetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _context;
        public TaskController(TaskContext context)
        {
            _context = context;
            if (_context.TaskItems.Count() == 0)
            {
                // Crea un nuevo item si la coleccion esta vacia,
                // lo que significa que no puedes borrar todos los Items.
                _context.TaskItems.Add(new TaskItem { Id = 1, Title = "Funciona! :v", Description = "Priorida", Priority = true });
                _context.TaskItems.Add(new TaskItem { Id = 2, Title = "Si que funciona Kbron! xD", Description = "Priorizar", Priority = true });
                _context.SaveChanges();
            }
        }
        // Aquí, despues del constructor de la clase, irán los Métodos HTTP GET,POST, DELETE, PUT
        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            return await _context.TaskItems.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return taskItem;
        }

    }
}