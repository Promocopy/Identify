using Identify.Data;
using Identify.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;
        public PersonController(PersonContext context) 
        { 
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _context.iDs.FirstOrDefault(c => c.Id==id);
                if (user==null)
                {
                    return NotFound("No user found");
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
        }

        [HttpPost()]
        public IActionResult post(PersonRequest id)
        {
            Person user = new Person();
            user.Name = id.Name;
            try
            {
                _context.iDs.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, Person idf) 
        {
           if (id!=idf.Id)
            {
                return BadRequest("Not found");
            }
            var user = _context.iDs.Find(id);
            if (user==null)
            {
                return NotFound("User not found");
            }
            user.Name = idf.Name;
            try
            {
                _context.iDs.Update(user);
                _context.SaveChanges();
            }
            catch (Exception )
            {
                return StatusCode(500, "An error has occurred");
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                var user = _context.iDs.FirstOrDefault(c => c.Id==id);
                if (user==null)
                {
                    return NotFound("No user found");
                }
                _context.iDs.Remove(user);
                _context.SaveChanges();
                return Ok(user);
            }

            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
            
        }
    }
}
