using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTwebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTwebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token([FromBody]LoginModel user)
        {
            //var header = Request.Headers["Authorization"];
            //if (header.ToString().StartsWith("Basic"))
            //{
            //var credVal = header.ToString().Substring("basic ".Length).Trim();
            //var usernameandpassword = Encoding.UTF8.GetString(Convert.FromBase64String(credVal));
            //var usrpass = usernameandpassword.Split(":");

            //if (usrpass[0] == "Admin" && usrpass[1] == "pass")
            if (user.UserName == "Admin" && user.Password == "pass")
            {
                var claimsdata = new[] { new Claim(ClaimTypes.Name, user.UserName )};
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeyformyapp"));
                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                    issuer: "mysite.com",
                    audience: "mysite.com",
                    expires: DateTime.Now.AddMinutes(30),
                    claims: claimsdata,
                    signingCredentials: signInCred);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                User userResult = new User();
                userResult.firstName = user.UserName;
                userResult.lastName = user.UserName;
                userResult.id = 1;
                userResult.username = user.UserName;
                userResult.password = user.Password;
                userResult.token = tokenString;
                //return Ok(tokenString);
                return Ok(userResult);
            }
            else
                return BadRequest("Invalid UserName And Password");
            //}
            //else
            //    return BadRequest("Bad Request");

        }
    }
}