using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AuthContext _context;

        IndexModel(AuthContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public void Redirect(string url)
        {
            RedirectPermanent(url);
        }

        // GET /SqlInjection/Authenticate
        public IActionResult Authenticate(string user)
        {
            var query = "SELECT * FROM Users WHERE Username = '" + user + "'"; // Unsafe
            var userExists = _context.Users.FromSql(query).Any(); // Noncompliant

            // An attacker can bypass authentication by setting user to this special value
            user = "' or 1=1 or ''='";

            return Content(userExists ? "success" : "fail");
        }
    }
}
