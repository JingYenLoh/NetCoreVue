using Microsoft.AspNetCore.Identity;

namespace NetCoreVue.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}