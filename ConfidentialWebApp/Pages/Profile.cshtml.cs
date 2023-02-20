using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ConfidentialWebApp.Pages
{
    public class ProfileModel : PageModel
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public void OnGet()
        {
            Name = User.Identity.Name;
            Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Image = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
        }
    }
}
