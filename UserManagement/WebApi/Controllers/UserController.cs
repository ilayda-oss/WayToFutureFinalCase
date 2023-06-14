using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi;
using System;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id); 
            if (user == null)
            {
                return NotFound("Belirtilen kullanıcı bulunamadı.");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!Enum.IsDefined(typeof(UserRole),(user.Role)))
            {
                return BadRequest();
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound("Böyle bir id bulunamadı.");
            }
            existingUser.Name = user.Name; //İsmi güncelledik
            existingUser.Email = user.Email; //Maili güncelledik
            existingUser.Role = user.Role; // Rolü güncelledik
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id); // Silinmek istenen id bulunuyor
            if (user == null)
            {
                return NotFound("Böyle bir id bulunamadı.");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok("Kullanıcı başarıyla silindi.");
        }

        [HttpGet("list")]
        public IActionResult GetUsersByName([FromQuery] string name)
        {
            var users = _context.Users.Where(u => u.Name.Contains(name)).ToList(); // Girilen isim içeride bulunuyor mu diye kontrol ediyor.
             if (users.Count == 0)
            {
                 return NotFound("Belirtilen kullanıcı bulunamadı.");
            }
            return Ok(users);
        }

        [HttpGet("list/sort")]
        public IActionResult GetUsersSortedByRole()
        {
            var users = _context.Users.OrderBy(u => u.Role).ToList(); // Role göre sıralıyor
            return Ok(new {Message = "Kullanıcılar rollere göre başarıyla sıralandı", Users = users});
        }
    }

  
}
