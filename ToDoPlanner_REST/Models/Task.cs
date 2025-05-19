namespace ToDoPlanner_REST.Models
{
    public class Task
    {
        //Attributes that the Tasks will have
        private int Id { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Status { get; set; }
    }
}
