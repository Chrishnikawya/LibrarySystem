using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.Common
{
    public class User : IdentityUser
    {
       public bool UserType { get; set; }
    }
}