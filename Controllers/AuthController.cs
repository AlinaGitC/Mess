using AppServerTest.Data;
using AppServerTest.Models;
using AppServerTest.Models.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppServerTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly MessengerDbContext _context;

        public AuthController(MessengerDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            // Проверка существования пользователя
            if (await _context.Users.AnyAsync(u => u.Login == registrationDto.Login))
                return BadRequest("User already exists");

            // Создание нового пользователя
            var user = new Userr
            {
                Login = registrationDto.Login,
                Password = registrationDto.Password, // В реальном приложении нужно хэшировать пароль!
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                BirthDate = registrationDto.BirthDate.Date
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { userId = user.ID });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == loginDto.Login && u.Password == loginDto.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { userId = user.ID });
        }
    }
}
