using Microsoft.AspNetCore.Mvc;

namespace ToDoPlanner_REST.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> TaskIds { get; set; }
        public List<int> UserIds { get; set; }

        //Constructors
        public BoardModel()
        {
        }

        public BoardModel (int _id, string _name)
        {
            Id = _id;
            Name = _name;
            TaskIds = new List<int>();
            UserIds = new List<int>();
        }

        public BoardModel(int _id, string _name, List<int> userIds, List<int> taskIds)
        {
            this.Id = _id;
            this.Name = _name;
            this.TaskIds = taskIds;
            this.UserIds = userIds;
        }
    }
}
