using ExrCrudUsingEFInWEBAPIInSwagger.Context;
using ExrCrudUsingEFInWEBAPIInSwagger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExrCrudUsingEFInWEBAPIInSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CrudContext _crudContext;

        public StudentsController(CrudContext crudContext)
        {
            _crudContext = crudContext;
        }

        //Token generation function 
        [HttpGet("gettoken")]
        public Object GetToken()
        {
            string key = "my_secret_key_160297";
            var issuer = "http://mysite.com";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "Vishal"));

            var token = new JwtSecurityToken(issuer,
                            issuer,
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };
        }


        [Authorize]
        [HttpPost("getname1")]
        public ActionResult<String> GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = User.Claims;
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }


        [Authorize]
        [HttpPost("getname2")]
        public Object GetName2()
        {
            var claims = User.Claims;
            var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
            return new
            {
                data = name
            };
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Students> Get()
        {
            return _crudContext.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Students Get(int id)
        {
            return _crudContext.Students.SingleOrDefault(x => x.StudentId == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public Students Post([FromBody] Students students)
        {
            _crudContext.Students.Add(students);
            _crudContext.SaveChanges();
            return students;
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public Students Put([FromBody] Students students)
        {
            _crudContext.Students.Update(students);
            _crudContext.SaveChanges();
            return students;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _crudContext.Students.FirstOrDefault(x => x.StudentId == id);
            if (item != null)
            {
                _crudContext.Students.Remove(item);
                _crudContext.SaveChanges();
            }

        }
    }
}
