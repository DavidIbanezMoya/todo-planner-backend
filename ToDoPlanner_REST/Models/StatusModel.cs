namespace ToDoPlanner_REST.Models
{
    public class StatusModel
    {
        //Atributes that a Status of the Task will have
        public int Id { set; get; }
        public string Name { set; get; }

        //Constructors
        public StatusModel()
        {

        }

        public StatusModel(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        } 
    }
}
