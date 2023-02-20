using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoWpfApp.Services
{
    public static class OpenIdContstants
    {
        public static string ClientId { get; } = "2b12ed75-9965-4330-8e49-5c754e5ab865";
        public static string[] ClientScopes { get; } = {
            "openid",
            "api",
            "offline_access"
        };

        public static string Authority { get; } = "https://localhost:5001";
    }
}
