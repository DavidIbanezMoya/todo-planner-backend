using ToDoPlanner_REST.Models;

namespace ToDoPlanner_REST.DTO
{
    public class CreateBoardDTO
    {
        public string Name { get; set; }
        public List<int> TaskIds { get; set; }
        public List<int> UserIds { get; set; }
    }
}
