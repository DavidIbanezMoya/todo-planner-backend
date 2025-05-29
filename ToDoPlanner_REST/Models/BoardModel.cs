namespace ToDoPlanner_REST.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Constructors
        public BoardModel()
        {

        }

        public BoardModel (int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
    }
}
