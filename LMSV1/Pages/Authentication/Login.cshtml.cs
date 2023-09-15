using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1UserContext _context;

        public LoginModel(LMSV1.Data.LMSV1UserContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;
        [Required]
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public IActionResult OnGet()
        {
            User? User = null;
            if (_context.User != null)
            //{
            //    User = await _context.User.ToListAsync();
            //}
           
            if (!string.IsNullOrEmpty(Email))
            {
                User = _context.User.FirstOrDefault(x => x.Email == Email);
                //Checks the database for the userName in a loop row by row.



            }
            if (User != null)
            {

                if (User.Password == Password)
                {
                   return RedirectToPage("./Welcome", User); //Maybe can pass a username in here.
                }

            }
            
            return Page();
        }
    }
}
