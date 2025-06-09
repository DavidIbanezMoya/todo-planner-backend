using ToDoPlanner_REST.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoPlanner_REST.DTO
{
    public class EditBoardDTO
    {
        public string Name { get; set; }
        public List<int> TaskIds { get; set; }
        public List<int> UserIds { get; set; }
    }
}
