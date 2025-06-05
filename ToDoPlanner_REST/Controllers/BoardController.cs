using ToDoPlanner_REST.Data;
using ToDoPlanner_REST.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoPlanner_REST.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {

        private readonly ApiContext _context;

        public BoardController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("createBoard")]
        public JsonResult createBoard(string name)
        {
            try
            {
                //We will create an empty Board
                var idAuto = 1;
                if (_context.BoardList.Count() > 0) idAuto = _context.BoardList.Max(board => board.Id) + 1;

                
                BoardModel boardCreated = new BoardModel(idAuto,name);
                
                //When the Board is created we will save the changes to our Database
                _context.SaveChanges();

                return new JsonResult(boardCreated);
            } catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpPut("editBoard")]
        public JsonResult editBoard(int boardId,string name, List<int>taskId, List<int>userId)
        {
            try
            {
                //At the moment we will update every field
                BoardModel boardEdited = _context.BoardList.Find(boardId);
                boardEdited.Name = name;
                boardEdited.TaskId = taskId;
                boardEdited.UserId = userId;

                //Save the data into the DB
                _context.SaveChanges();

                return new JsonResult(boardEdited);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpDelete("deleteBoard")]
        public JsonResult deleteBoard(int boardId)
        {
            try
            {
                var boardToDelete = _context.BoardList.Find(boardId);
                _context.BoardList.Remove(boardToDelete);

                //Save
                _context.SaveChanges();
                return new JsonResult(Ok());
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpGet("getUsersByBoard")]
        public JsonResult getUsersByBoard(int boardId)
        {
            try
            {
                BoardModel board = _context.BoardList.Find(boardId);
                var listOfUsersIds = board.UserId;
                List<UserModel> result = new List<UserModel>();
                foreach (int userId in listOfUsersIds)
                {
                    result.Add(_context.UserList.Find(userId));
                }

                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpGet("getTasksByBoard")]
        public JsonResult getTasksByBoard(int boardId)
        {
            try
            {
                BoardModel board = _context.BoardList.Find(boardId);
                var listOfTasksIds = board.TaskId;
                List<TaskModel> result = new List<TaskModel>();
                foreach (int taskId in listOfTasksIds)
                {
                    result.Add(_context.TaskList.Find(taskId));
                }
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpGet("getAllBoards")]
        public JsonResult getAllBoards()
        {
            try
            {
                var result = _context.BoardList.ToList();
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }
    }
}
