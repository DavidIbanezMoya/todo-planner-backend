using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ToDoPlanner_REST.Data;
using ToDoPlanner_REST.Models;

namespace ToDoPlanner_REST.Controllers
{
    //Control of the different methods
    [Route("/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApiContext _context;

        public TaskController(ApiContext context)
        {
            _context = context;
        }


        [HttpPost("addTask")]
        public JsonResult addTask(string title, string description, int statusId)
        {
            try
            {
                //We will check the ID from the last registered User and we will assing it ID+1
                var idAuto = 1;
                if (_context.TaskList.Count() > 0) idAuto = _context.TaskList.Max(uId => uId.Id) + 1;
                TaskModel newTask = new TaskModel(idAuto,title,description,statusId);
                _context.TaskList.Add(newTask);
                _context.SaveChanges();
                return new JsonResult(Ok(newTask));
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));

            }

        }

        [HttpPut("editTask")]
        public JsonResult editTask(int taskId, string title, string description, int statusId)
        {
            try
            {
                //Todo Adapt the edit task
                TaskModel taskEdited = _context.TaskList.Find(taskId);

                taskEdited.Title = title;
                taskEdited.Description = description;
                taskEdited.StatusId = statusId;
                _context.SaveChanges();

                return new JsonResult(taskEdited);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpDelete("deleteTask")]
        public JsonResult deleteTaskById(int taskId)
        {
            try
            {
                var task = _context.TaskList.Find(taskId);
                _context.TaskList.Remove(task);
                _context.SaveChanges();
                return new JsonResult(Ok(task));
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpGet("getTaskInfo")]
        public JsonResult getTaskById(int taskId)
        {
            var result = _context.TaskList.Find(taskId);
            return new JsonResult(result);
        }


        [HttpGet("getTasksByStatus")]
        public JsonResult getTasksByStatus(int statusId)
        {
            //We will filter the tasks by the desired status that we want
            var selectQuery = _context.TaskList.Where(tl => tl.StatusId == statusId);
            return new JsonResult(selectQuery);
        }

        [HttpGet("getAllTasks")]
        public JsonResult getAllTasks()
        {
            var result = _context.TaskList.ToList();
            return new JsonResult(result);
        }
    }
}