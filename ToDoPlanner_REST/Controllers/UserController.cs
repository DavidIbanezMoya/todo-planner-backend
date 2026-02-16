using ToDoPlanner_REST.Models;
using ToDoPlanner_REST.Data;
using Microsoft.AspNetCore.Mvc;
using ToDoPlanner_REST.DB_Queries;

namespace ToDoPlanner_REST.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiContext _context;
        //private DatabaseConnection dbConnection;
        private UserQueries userQuery = new UserQueries();
        public UserController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("createUser")]
        public JsonResult createUser(string _name, string _surname, string _email, string _password_Hash, string _password_Salt)
        {
            try
            {

                //The user doesn't have to know about the password hash and salt...
                var result = userQuery.insertUserQuery(_name,_surname,_email,_password_Hash,_password_Salt);

                return new JsonResult(Ok());
            }
            catch (Exception e) 
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        [HttpPut("editUser")]
        public JsonResult editUser(int id, string firstname, string lastname, string email, List<int?> boardsId)
        {
            try
            {
                //The check logic has to be in the Front End
                UserModel userEdited = _context.UserList.Find(id);

                userEdited.FirstName = firstname;
                userEdited.LastName = lastname;
                userEdited.Email = email;
                //The user can't edit the password, just create a new one, with a new hash...
                //userEdited.Password = password;
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
        public JsonResult deleteUser(int userId)
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

        [HttpGet("getUser")]
        public JsonResult getUserByEmail(string email)
        {
            try
            {
                //var user = _context.UserList.Where(usEmail => usEmail.Email == email);
                var result = userQuery.selectUsersByEmailQuery(email);
                return new JsonResult(result);
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
                var result = userQuery.selectAllUsersQuery();
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }


    }
}
