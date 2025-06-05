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

        [HttpPost("createUser")]
        public JsonResult createUser(string _name, string _surname, string _email, string _password)
        {
            try
            {
                //We will check the ID from the last registered User and we will assing it ID+1
                var idAuto = 1;
                if (_context.UserList.Count() > 0) idAuto = _context.UserList.Max(uId => uId.Id)+1;

                UserModel newUser = new UserModel(idAuto,_name,_surname,_email,_password);
                _context.UserList.Add(newUser);
                _context.SaveChanges();
                return new JsonResult(Ok());
            }
            catch (Exception e) 
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpGet("getUser")]
        public JsonResult getUserByEmail(string email)
        {
            try
            {
                //Todo the user has to be a unique field
                var user = _context.UserList.Where(usEmail => usEmail.Email == email);
                return new JsonResult(user);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpGet("getAllUsers")]
        public JsonResult getAllUsers()
        {
            try
            {
                var result = _context.UserList.ToList();
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpPut("editUser")]
        public JsonResult editUser(int id, string name, string surname, string email, string password, List<int?>boardsId)
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
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpDelete("deleteUser")]
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
                return new JsonResult(BadRequest(e.Message));
            }
        }
    }
}
