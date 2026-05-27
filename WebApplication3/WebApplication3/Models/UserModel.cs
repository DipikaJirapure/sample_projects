using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } = "";

        [Required]
        public string PasswordHash { get; set; } = "";

        [MaxLength(50)]
        public string Role { get; set; } = "User";
    }
}
