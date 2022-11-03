using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TrainBackendApi.Models;
using TrainBackendApi.Repository;

namespace TrainBackendApi.Services
{
    public class JwtTokenService
    {
        private IConfiguration _config;
        private readonly TrainDbConntext dbConntext;

        public JwtTokenService(IConfiguration config, TrainDbConntext dbConntext)
        {
            _config = config;
            this.dbConntext = dbConntext;
        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddSeconds(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefresToken()
        {

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                var refreshtoken= Convert.ToBase64String(randomNumber);
                dbConntext.RefreshTokens.Add(new RefreshToken { Token = refreshtoken });
                dbConntext.SaveChanges();
                return refreshtoken;
            }
        }
        public Dictionary<string,string> GenerateNewToken(string refreshtoken,string oldtoken)
        {
            var pricipals = GetPrincipalFromExpiredToken(oldtoken);
            var validaterefrestoken = dbConntext.RefreshTokens.FirstOrDefault(x => x.Token == refreshtoken) != null;
            Dictionary<string, string> Tokens = new Dictionary<string, string>();
            if (validaterefrestoken)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = pricipals.Claims;
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                 claims,
                  expires: DateTime.Now.AddSeconds(15),
                  signingCredentials: credentials);
                 var newtoken =new JwtSecurityTokenHandler().WriteToken(token);
                Tokens.Add("token",newtoken);
                Tokens.Add("refreshtoken", GenerateRefresToken());
                var oldrefrestoken = dbConntext.RefreshTokens.FirstOrDefault(x => x.Token == refreshtoken);
                dbConntext.RefreshTokens.Remove(oldrefrestoken);
                dbConntext.SaveChanges();
                return Tokens;
            }
            throw new SecurityTokenException("Invalid token");

        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var Key = Encoding.UTF8.GetBytes(_config["JWT:Key"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
    }
}
