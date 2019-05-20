using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public bool IsStockProvider { get; set; }
    }
}
