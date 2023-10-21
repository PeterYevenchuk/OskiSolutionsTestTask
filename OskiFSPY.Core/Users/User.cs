using System.ComponentModel.DataAnnotations.Schema;

namespace OskiFSPY.Core.Users;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public Role Role { get; set; }

    public string Salt { get; set; }
}
