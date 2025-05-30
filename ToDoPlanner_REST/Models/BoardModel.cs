using Microsoft.AspNetCore.Mvc;

namespace ToDoPlanner_REST.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [FromRoute]
        public List<int> TaskId { get; set; }
        public List<int> UserId { get; set; }

        //Constructors
        public BoardModel()
        {
            TaskId = new List<int>();
            UserId = new List<int>();
        }

        public BoardModel (int _id, string _name)
        {
            Id = _id;
            Name = _name;
            TaskId = new List<int>();
            UserId = new List<int>();
        }
    }
}
