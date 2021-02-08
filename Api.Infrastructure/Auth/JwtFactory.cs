using Microsoft.Extensions.Options;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Auth
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        public async Task<Token> GenerateEncodedToken(GenerateJwtTokenRequest request)
        {
            var identity = GenerateClaimsIdentity(request);

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, request.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                 identity.FindFirst("rol"),
                 identity.FindFirst("id"),
                 identity.FindFirst("comId")
             };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                _jwtOptions.NotBefore,
                _jwtOptions.Expiration,
                _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new Token()
            {
                Id = identity.Claims.Single(c => c.Type == "id").Value,
                AuthToken = encodedJwt,
                ExpiresIn = (int)_jwtOptions.ValidFor.TotalSeconds
            };
        }

        private static ClaimsIdentity GenerateClaimsIdentity(GenerateJwtTokenRequest request)
        {
            request.CompanyId ??= string.Empty;
            request.LocationId ??= string.Empty;

            return new ClaimsIdentity(new GenericIdentity(request.UserName, "Token"), new[]
            {
                new Claim("id", request.Id),
                new Claim("rol", request.Role.ToLower()),
                new Claim("comId", request.CompanyId),
                new Claim("locId", request.LocationId)
            });
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}
