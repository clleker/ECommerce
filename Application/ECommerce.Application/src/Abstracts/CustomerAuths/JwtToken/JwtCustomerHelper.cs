using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Common.Extensions;
using Core.Utilities.Security.Encyption;
using ECommerce.Core.Domain.AppUser;
using ECommerce.Core.Utilities.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace ECommerce.Application.Abstracts.CustomerAuth.JwtToken
{
    public class JwtCustomerHelper : ITokenCustomerHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtCustomerHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("CustomerTokenOptions").Get<TokenOptions>();
            
        }
        public AccessToken CreateToken(Domain.Entities.Customer customer)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, customer, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Domain.Entities.Customer user, 
            SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                claims: SetClaims(user),
                signingCredentials:signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Domain.Entities.Customer customer)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(customer.Id.ToString());
            claims.AddEmail(customer.Email);
            claims.AddName($"{customer.FirstName} {customer.LastName}");
            
            return claims;
        }
    }
}
