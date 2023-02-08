using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace jsk.Isp;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope()
                {
                    DisplayName = "Todo api",
                    Name = "api",
                    Description = "Access todo Api",
                    Emphasize= true,
                }
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client()
                {
                    ClientName= "Confidential Client",
                    ClientId= "confidentialclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris =
                    {
                        "https://localhost:7276/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7276/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequireConsent = true,
                },
                new Client()
                {
                    ClientName= "M2m Client",
                    ClientId= "m2mclient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api"
                    },
                    ClientSecrets =
                    {
                        new Secret("m2mSecret".Sha256())
                    },
                    AllowOfflineAccess = true,
                },
                new Client()
                {
                    ClientName= "Device Client",
                    ClientId= "deviceclient",
                    AllowedGrantTypes = GrantTypes.DeviceFlow,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    },
                    ClientSecrets =
                    {
                         new Secret("DeviceSecret".Sha256())
                    },
                },
                new Client()
                {
                    ClientName= "Swagger Client",
                    ClientId= "SwagClient",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api"
                    },
                    RedirectUris =
                    {
                        "https://localhost:7216/swagger/oauth2-redirect.html"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:7216"
                    },
                    ClientSecrets =
                    {
                         new Secret("TooSwagSecret".Sha256())
                    },
                    RequireConsent= true,
                    AllowOfflineAccess = true,
                },
        };
}