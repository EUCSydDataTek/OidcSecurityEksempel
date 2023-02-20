using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoWpfApp.Services
{
    public class LoginInfo
    {

        public string AccessToken { get; set; } = string.Empty;

        public string IdToken { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}
