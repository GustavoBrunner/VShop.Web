using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityService.Configuration;

public class IdentityConfiguration
{
    public const string ADMIN = "Admin";
    public const string CLIENT = "Client";

    public static IEnumerable<IdentityResource> IdentityResources
    {
        get =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
    }
    public static IEnumerable<ApiScope> ApiScopes 
    {
        get => new List<ApiScope>()
        {
            new("vshop", "VShop server"),
            new(name: "read", "Read data"),
            new(name: "write", "Write data"),
            new(name: "delete", "Delete data")
        };
    }
    public static IEnumerable<Client> Clients 
    {
        get => new List<Client>()
        {
            new()
            {
                ClientId = "client",
                ClientSecrets = { new Secret("Abracadabra#Simsalabim".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "delete" }
            },
            new()
            {
                ClientId = "vshop",
                ClientSecrets = { new Secret("Abracadabra#Simsalabim".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:7237/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:7237/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    "vshop"
                }
            }
        };
    }
}
