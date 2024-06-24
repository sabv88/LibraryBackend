using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;
using IdentityServer4.Test;
using System.Security.Claims;

namespace LibraryIdentity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("LibraryWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", new[] { "role" })

            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("LibraryWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "LibraryWebAPI" }
                },
                new ApiResource("roles", "My Roles", new[] { "role" }),

            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "library-web-app",
                    ClientName = "Library Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://localhost:44410/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:44410"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:44410/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "LibraryWebAPI",
                        "roles"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
        public static IEnumerable<TestUser> Users =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("name", "Alice Smith"),
                    new Claim("email", "alice@example.com"),
                    new Claim("role", "admin")
                }
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "bob",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("name", "Bob Johnson"),
                    new Claim("email", "bob@example.com"),
                    new Claim("role", "user")
                }
            }
        };
    }
}
    

