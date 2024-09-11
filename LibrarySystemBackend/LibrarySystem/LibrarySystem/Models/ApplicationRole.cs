using LibrarySystem.Common;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.Models
{
    public class ApplicationRole : IdentityRole
    {
      public virtual ICollection<IdentityUserRole<string>> Users { get; set;}
      public virtual ICollection<IdentityUserClaim<string>> Claims { get; set;}


    }
}
