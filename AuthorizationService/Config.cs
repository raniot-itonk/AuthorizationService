using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;

namespace AuthorizationService
{
    public class Config
    {
        // clients that are allowed to access resources from the Auth server 
        public static IEnumerable<Client> GetClients()
        {
            // client credentials, list of clients
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client.user",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = new List<string>
                    {
                        GrantType.ResourceOwnerPassword,
                    },
                    AllowedScopes = new List<string>
                    {
                        "client.UserActions",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "client.Business",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = new List<string>
                    {
                        GrantType.ResourceOwnerPassword,
                    },
                    AllowedScopes = new List<string>
                    {
                        "client.BusinessActions",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        // API that are allowed to access the Auth server
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Client", "Client")
                {
                    Scopes = new List<Scope>
                    {
                        new Scope("client.UserActions", "User authorization"),
                        new Scope("client.BusinessActions", "Business authorization")
                    },
                },

            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}