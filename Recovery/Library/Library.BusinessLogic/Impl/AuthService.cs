using Library.DataAccess;
using Library.Datamodel;
using Library.Datamodel.TokenAuth;
using Library.EF;
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

namespace Library.BusinessLogic.Impl {
    public class AuthService : IAuthService {

        private readonly IRepository<User> userRepository;
        private readonly IRepository<Role> roleRepository;
        private readonly TokenSettings tokenSettings;
        public AuthService(IRepository<User> userRepository,IRepository<Role> roleRepository, IOptions<TokenSettings> tokenSettings) {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.tokenSettings = tokenSettings.Value;
        }

        public async Task<string> Register(User entity) {
            var user = await userRepository.GetFirstAsync(u => u.Email.Equals(entity.Email));

            if(user != null) {
                throw new Exception("User already exists");
            }
            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            entity.Roles = (await roleRepository.GetAsync(r => r.Name.Equals("User"))).ToList();

            return (await userRepository.AddAsync(entity)).Email;
        }
        public async Task<string> Login(string email, string password) {

            var user = await userRepository.GetFirstAsync(user => user.Email.Equals(email), user => user.Roles);
            if (user is not null && BCrypt.Net.BCrypt.Verify(password, user.Password)) {
                var securtityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key));

                var credentials = new SigningCredentials(securtityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();

                claims.Add(new Claim("FirstName", user.FirstName));
                claims.Add(new Claim("LastName", user.LastName));
                claims.Add(new Claim("Email", user.Email));
                if (user.Roles?.Count > 0) {
                    foreach (var role in user.Roles) {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }
                }

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: tokenSettings.Issuer,
                    audience: tokenSettings.Audience,
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
