using ToDoPlanner_REST.Models;
using ToDoPlanner_REST.Data;
using Microsoft.AspNetCore.Mvc;

namespace ToDoPlanner_REST.Controllers
{

    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiContext _context;

        public UserController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("/createUser")]
        public JsonResult createUser(string _id, string _name, string _surname, string _email, string _password)
        {
            try
            {
                //Todo ID has to be dynamically asigned
                UserModel newUser = new UserModel(1,"David","Ibanez","davidibanez@gmail.com","123a");
                _context.SaveChanges();
                return new JsonResult(Ok());
            }
            catch (Exception e) 
            {
                return new JsonResult(BadRequest());
            }
        }

        [HttpGet("/getUser")]
        public JsonResult getUserByEmail(string email)
        {
            try
            {
                var user = _context.UserList.Find(email);
                return new JsonResult(user);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest());
            }
        }

        [HttpPut("/editUser")]
        public JsonResult editUser(int id, string name, string surname, string email, string password, List<int>boardsId)
        {
            try
            {
                //The check logic has to be in the Front End
                UserModel userEdited = _context.UserList.Find(id);

                userEdited.Name = name;
                userEdited.Surname = surname;
                userEdited.Email = email;
                userEdited.Password = password;
                userEdited.BoardsId = boardsId;

                _context.SaveChanges();
                return new JsonResult(Ok("The user has been updated"));
            } 
            catch (Exception e)
            {
                return new JsonResult(BadRequest());
            }
        }

        [HttpDelete("/deleteUser")]
        public JsonResult deleteUser (int userId)
        {
            try
            {
                var user = _context.UserList.Find(userId);
                _context.UserList.Remove(user);
                _context.SaveChanges();
                return new JsonResult(Ok());
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest());
            }
        }
    }
}
