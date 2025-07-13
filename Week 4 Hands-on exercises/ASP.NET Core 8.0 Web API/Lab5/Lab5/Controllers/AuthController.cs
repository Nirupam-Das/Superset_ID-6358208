using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]                              // token not required to get a new one
    public class AuthController : ControllerBase
    {
        // GET: api/Auth?userId=1
        [HttpGet]
        public IActionResult GetToken([FromQuery] int userId = 1)
        {
            // Normally you would validate the user here (DB lookup, etc.)
            var token = GenerateJsonWebToken(userId, "Admin");
            return Ok(new { token });
        }

        // --------------------------------------------------------------------
        // PRIVATE: Generates a JWT valid for 2 minutes
        // --------------------------------------------------------------------
        private string GenerateJsonWebToken(int userId, string userRole)
        {
            // 🔑 32‑byte secret ‑‑ MUST match Program.cs
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysuperdupersecuresecretkeythatworks123!"));
            var credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            // Custom claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,  userRole),
                new Claim("UserId",         userId.ToString())
            };

            // Build the token (expires after 2 minutes)
            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: credentials);

            // Serialize to compact JWT
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
