using _40k2ed.Data;
using _40k2ed.Models.EntityModels;
using _40k2ed.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace _40k2ed.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserController(ApplicationDbContext db, IPasswordHasher<User> passwordHasher)
        {
            _db = db;
            _passwordHasher = passwordHasher;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            // Find user by email
            var user = await _db.User
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            // Verify password hash (you should implement a method to verify the password)
            if (VerifyPassword(password, user.PasswordHash))
            {
                // Log in user (you could use session or authentication cookie)
                await SignInUser(user, rememberMe);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            // Add your password hashing logic here (e.g., bcrypt, PBKDF2, etc.)
            return enteredPassword == storedPasswordHash;  // This is just a placeholder
        }
        private async Task SignInUser(User user, bool rememberMe)
        {
            // Sign in logic (can use ASP.NET Core Identity or a custom method)
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = rememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, properties);
        }
        public IActionResult Register()
        {
            return View();
        }
        // Register POST action to handle form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists in the database
                var existingUser = await _db.User
                    .FirstOrDefaultAsync(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "This email is already in use.");
                    return View(model);
                }

                // Create a new user and hash their password
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    RegisteredDate = DateTime.UtcNow,
                    Confirmed = false, // Set the default to false until confirmed via email
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

                // Save user to the database
                _db.User.Add(user);
                await _db.SaveChangesAsync();

                // Here you can send a confirmation email (not shown in this example)
                // SendConfirmationEmail(user); 

                // Redirect to a confirmation page or login
                return RedirectToAction("Login");
            }

            // Return back to the view if validation fails
            return View(model);
        }
    }
}
