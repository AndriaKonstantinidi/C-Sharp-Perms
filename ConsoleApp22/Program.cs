class Program
{
    static void Main()
    {
        var users = new List<Users>();

        var permissions = new List<permissions>();

        var usersToPermissions = new List<UsersToPermissions>();

        users.Add(new Users { Id = 1, Name = "jemali" });
        users.Add(new Users { Id = 2, Name = "tornike" });
        users.Add(new Users { Id = 3, Name = "datooo" });

        permissions.Add(new permissions { id = 1, name = "admin", level = 1});
        permissions.Add(new permissions { id = 1, name = "lector", level = 2});
        permissions.Add(new permissions { id = 1, name = "student", level = 3});

        usersToPermissions.Add(new UsersToPermissions { id = 1, userid = 1, PermissionsId = 1 });
        usersToPermissions.Add(new UsersToPermissions { id = 2, userid = 2, PermissionsId = 2 });
        usersToPermissions.Add(new UsersToPermissions { id = 3, userid = 3, PermissionsId = 2 });
        usersToPermissions.Add(new UsersToPermissions { id = 4, userid = 3, PermissionsId = 1 });
        usersToPermissions.Add(new UsersToPermissions { id = 5, userid = 2, PermissionsId = 3 });
        usersToPermissions.Add(new UsersToPermissions { id = 6, userid = 1, PermissionsId = 3 });

        var result = (from per in permissions
                      join usertoper in usersToPermissions on per.id equals usertoper.PermissionsId
                      join user in users on usertoper.userid equals user.Id
                      where per.level == 1
                      select per).ToList();
        result.ForEach(result => Console.WriteLine(result.name));
    }
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class permissions
    {
        public int id { get; set;}
        public string name { get; set; }
        public int level { get; set; }
    }
    public class UsersToPermissions
    {
        public int id { get; set;}
        public int userid { get; set; }
        public int PermissionsId { get; set; }
    }
}