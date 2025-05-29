namespace ToDoPlanner_REST.Models
{
    public class TaskModel
    {
        //Attributes that the Tasks will have
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }

        public TaskModel()
        {

        }

        public TaskModel (int _id, string _title, string _description, int _statusId)
        {
            Id = _id;
            Title = _title;
            Description = _description;
            StatusId = _statusId;
        }

    }
}
