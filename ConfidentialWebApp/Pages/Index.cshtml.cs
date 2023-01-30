using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Text;

namespace ConfidentialWebApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            await LogIdentityInformation();
        }

        public async Task LogIdentityInformation()
        {
            // Hent gemt Identity token
            var token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            var claimsStringBuilder = new StringBuilder();

            foreach (var claim in User.Claims)
            {
                claimsStringBuilder.AppendLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }

            _logger.LogInformation($"""

                ------ OpenIDConnect ------
                Token: {token}
                Claims: 
                {claimsStringBuilder.ToString()}
                ---------------------------
            """);
        }
    }
}