using IdentityModel.OidcClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Controls;

namespace TodoWpfApp.Services
{
    public static class LoginService
    {

        public static async Task LoginAsync()
        {
            var browser = new SystemBrowser();
            string redirectUri = string.Format($"http://127.0.0.1:{browser.Port}");

            OidcClientOptions options = new()
            {
                Authority = OpenIdContstants.Authority,
                ClientId= OpenIdContstants.ClientId,
                
            };

            var client = new OidcClient(options);

           
            
           
        }

    }
}
