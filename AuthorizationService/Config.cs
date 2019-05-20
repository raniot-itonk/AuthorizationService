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
                        "BankingService.UserActions",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "client.broker&taxer",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = new List<string>
                    {
                        GrantType.ClientCredentials,
                    },
                    AllowedScopes = new List<string>
                    {
                        "BankingService.broker&taxer",
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
                new ApiResource("BankingService", "Banking")
                {
                    Scopes = new List<Scope>
                    {
                        new Scope("BankingService.UserActions", "User authorization for banking service"),
                        new Scope("BankingService.broker&taxer", "Broker & Taxer authorization for banking service")
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