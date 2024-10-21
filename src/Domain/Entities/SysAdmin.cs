
namespace Domain.Entities
{
    public class SysAdmin : User
    {
        public SysAdmin() { }
        public SysAdmin(string name, string lastname, string email, string username, string password)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Username = username;
            Password = password;
        }

    }
}