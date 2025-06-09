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
        public JsonResult addStatus(string statusName)
        {
            try
            {
                //We will check the ID from the last registered User and we will assing it ID+1
                var idAuto = 1;
                if (_context.StatusList.Count() > 0) idAuto = _context.StatusList.Max(uId => uId.Id) + 1;
                StatusModel newStatus = new StatusModel(idAuto,statusName);
                _context.StatusList.Add(newStatus);
                _context.SaveChanges();
                return new JsonResult(Ok(newStatus));
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));

            }

        }

        [HttpPut("editStatus")]
        public JsonResult editStatus(int statusId, string name)
        {
            try
            {
                StatusModel statusEdited = _context.StatusList.Find(statusId);

                statusEdited.Name = name;
                _context.SaveChanges();

                return new JsonResult(statusEdited);
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
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

        [HttpGet("getAllStatus")]
        public JsonResult getAllStatus()
        {
            try
            {
                var result = _context.StatusList.ToList();
                return new JsonResult(Ok(result));
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }
    }
}
