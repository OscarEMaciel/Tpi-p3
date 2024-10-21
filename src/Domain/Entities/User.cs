using System;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

    }
}
