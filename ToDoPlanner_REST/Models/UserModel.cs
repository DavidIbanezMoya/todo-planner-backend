namespace ToDoPlanner_REST.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        //The password of the User is not being encrypted at the moment
        public string Password { get; set; }
        //A user access will be granted to a Board, so multiple users could look at the same Board, and a user can have access to multiple boards
        public List<int> BoardsId { get; set; }


        //Constructors
        public UserModel()
        {

        }

        public UserModel(int _id, string _name, string _surname, string _email, string _password)
        {
            Id = _id;
            Name = _name;
            Surname = _surname;
            Email = _email;
            Password = _password;

        }

    }
}
