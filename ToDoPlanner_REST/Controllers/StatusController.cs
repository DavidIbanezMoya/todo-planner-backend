    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoPlanner_REST.Data;
using ToDoPlanner_REST.Models;

namespace ToDoPlanner_REST.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ApiContext _context;

        public StatusController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("addStatus")]
        public JsonResult addStatus(StatusModel status)
        {
            try
            {
                _context.StatusList.Add(status);
                _context.SaveChanges();
                return new JsonResult(Ok(status));
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(status));

            }

        }

        [HttpDelete("deleteStatus")]
        public JsonResult deleteStatusById(int statusId)
        {
            try
            {
                var status = _context.StatusList.Find(statusId);
                _context.StatusList.Remove(status);
                _context.SaveChanges();
                return new JsonResult(Ok(status));
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }
    }
}
