#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reports.API.Models;
using Task = Reports.API.Models.Task;

namespace Reports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> GetTask(string id)
        {
            Task? task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();
            return task;
        }

        // GET: api/Task/CreatedAt?fromTime&toTime
        [HttpGet("CreatedAt")]
        public async Task<ActionResult<List<Task>>> GetTaskCreatedAt(DateTime fromTime,
            DateTime? toTime)
        {
            List<Task> tasks = await _context.Tasks
                .OrderBy(t => t.CreatedAt)
                .Where(t => t.CreatedAt >= fromTime && t.CreatedAt <= (toTime ?? DateTime.Now))
                .ToListAsync();
            return tasks;
        }

        // GET: api/Task/LastUpdateAt?fromTime&toTime
        [HttpGet("LastUpdateAt")]
        public async Task<ActionResult<List<Task>>> GetTaskLastUpdateAt(DateTime fromTime,
            DateTime? toTime)
        {
            List<Task> tasks = await _context.Tasks
                .OrderBy(t => t.LastUpdateAt)
                .Where(t => t.LastUpdateAt >= fromTime && t.LastUpdateAt <= (toTime ?? DateTime.Now))
                .ToListAsync();
            return tasks;
        }

        // GET: api/Task/?EmployerId
        [HttpGet("EmployerId")]
        public async Task<ActionResult<List<Task>>> GetTaskByEmployerId(string employerId)
        {
            List<Task> tasks = await _context.Tasks
                .OrderBy(t => t.LastUpdateAt)
                .Where(t => t.Employer.Id == employerId)
                .ToListAsync();
            return tasks;
        }

        // GET: api/Task/?EditorId
        [HttpGet("EditorId")]
        public async Task<ActionResult<List<Task>>> GetTaskByEditorId(string editorId)
        {
            List<Task> tasks = await
                _context.Tasks.Where(t => t.Employer.Id == editorId)
                    .Concat(
                        _context.Comments.Where(c => c.Employer.Id == editorId).Select(c => c.Task))
                    .GroupBy(t => t.Id, (k, g) => g.OrderBy(task => task.Id).First())
                    .ToListAsync();
            return tasks;
        }


        // PUT: api/Task/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(string id, Task taskToUpdate)
        {
            if (id != taskToUpdate.Id) return BadRequest();

            _context.Entry(taskToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Task
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Task>> PostTask(Task task)
        {
            _context.Tasks.Add(task);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaskExists(task.Id))
                    return Conflict();
                throw;
            }

            return CreatedAtAction(nameof(GetTask), new {id = task.Id}, task);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(string id)
        {
            Task? task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(string id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}