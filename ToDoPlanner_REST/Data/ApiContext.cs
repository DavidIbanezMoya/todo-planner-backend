using Microsoft.EntityFrameworkCore;
using ToDoPlanner_REST.Models;

namespace ToDoPlanner_REST.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<TaskModel> TaskList { get; set; }
        public DbSet<StatusModel> StatusList { get; set; }
        public DbSet<BoardModel> BoardList { get; set; }
        public DbSet<UserModel> UserList { get; set; }
        
        
        //Constructor
        public ApiContext (DbContextOptions<ApiContext> options) :base (options)
        {
            //We create the in built deafult info
            if (StatusList.ToList().Count == 0 && TaskList.ToList().Count == 0)
            {
                StatusList.Add(new StatusModel(1, "New"));
                StatusList.Add(new StatusModel(2, "Active"));
                StatusList.Add(new StatusModel(3, "Done"));

                TaskList.Add(new TaskModel(1, "User", "Create the user class", 2));
                TaskList.Add(new TaskModel(2, "Frontend user", "Create the frontend with login", 1));
                TaskList.Add(new TaskModel(3, "Frontend todo page", "Create the frontend page for the todo stuff", 1));
                TaskList.Add(new TaskModel(4, "Desktop user", "Desktop application with the user configuration", 1));
                TaskList.Add(new TaskModel(5, "Desktop app", "The desktop application with the ToDo stuff", 1));
                TaskList.Add(new TaskModel(6, "REST", "Create the base REST app", 3));
                
                SaveChanges();
            }
        }
    }
}
