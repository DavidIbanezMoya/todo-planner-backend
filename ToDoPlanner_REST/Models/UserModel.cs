namespace ToDoPlanner_REST.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        //The password of the User is not being encrypted at the moment
        public string Password_Hash { get; set; }
        public string Password_Salt { get; set; }
        //A user access will be granted to a Board, so multiple users could look at the same Board, and a user can have access to multiple boards
        public List<int?> BoardsId { get; set; }


        //Constructors
        public UserModel()
        {

        }

        public UserModel(int _id, string _name, string _surname, string _email, string _password_Hash, string password_Salt)
        {
            Id = _id;
            Name = _name;
            Surname = _surname;
            Email = _email;
            Password_Hash = _password_Hash;
            Password_Salt = password_Salt;
            BoardsId = new List<int?>();
            Password_Salt = password_Salt;
        }

    }
}
