namespace ToDoPlanner_REST.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password_Hash { get; set; }
        public string Password_Salt { get; set; }
        //A user access will be granted to a Board, so multiple users could look at the same Board, and a user can have access to multiple boards
        public List<int?> BoardsId { get; set; }


        //Constructors
        public UserModel()
        {

        }

        public UserModel(int _id, string _first_Name, string _last_Name, string _email, string _password_Hash, string password_Salt)
        {
            Id = _id;
            FirstName = _first_Name;
            LastName = _last_Name;
            Email = _email;
            Password_Hash = _password_Hash;
            Password_Salt = password_Salt;
            BoardsId = new List<int?>();
        }

    }
}
