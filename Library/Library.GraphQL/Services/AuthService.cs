using Library.EF;
using Library.GraphQL.TokenAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQL.Contract {
    public class AuthService : IAuthService {
        private readonly LibraryContext _context;
        private readonly TokenSettings _tokenSettings;
        public AuthService(IDbContextFactory<LibraryContext> libraryContextFactory, IOptions<TokenSettings> tokenSettings) {
            _context = libraryContextFactory.CreateDbContext();
            _tokenSettings = tokenSettings.Value;
        }

        public string Login(string email, string password) {
            var user = _context.Users.Single(u => u.Email == email);
            if (user is not null && BCrypt.Net.BCrypt.Verify(password, user.Password)) {
                var securtityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Key));

                var credentials = new SigningCredentials(securtityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();

                claims.Add(new Claim("FirstName", user.FirstName));
                claims.Add(new Claim("LastName", user.LastName));
                claims.Add(new Claim("Email", user.Email));
                if (user.Roles?.Count > 0) {
                    foreach (var role in user.Roles) {
                        claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                    }
                }

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _tokenSettings.Issuer,
                    audience: _tokenSettings.Audience,
                    //expires: DateTime.Now.AddMinutes(30),
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials,
                    claims: claims
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }

            return "";
        }
    }
}
