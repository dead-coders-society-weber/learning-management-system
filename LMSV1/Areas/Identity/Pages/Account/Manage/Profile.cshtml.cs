// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LMSV1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMSV1.Areas.Identity.Pages.Account.Manage
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IWebHostEnvironment _webHostEnvironment;

        public ProfileModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [DataType(DataType.EmailAddress)]
            public string Email { get; set;}

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Birthdate")]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }

            [Display(Name = "Address 1")]
            public string Address1 { get; set; }

            [Display(Name = "Address 2")]
            public string Address2 { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }

            [Display(Name = "State")]
            public string State { get; set; }

            [Display(Name = "Zip Code")]
            [DataType(DataType.PostalCode)]
            public string Zip { get; set; }

            [Display(Name = "Link 1")]
            [DataType(DataType.Url)]
            public string? Link1 { get; set; }

            [Display(Name = "Link 2")]
            [DataType(DataType.Url)]
            public string? Link2 { get; set; }

            [Display(Name = "Link 3")]
            [DataType(DataType.Url)]
            public string? Link3 { get; set; }

            [DataType(DataType.ImageUrl)]
            public string? ProfileImage { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            Input = new InputModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                Address1 = user.Address1,
                Address2 = user.Address2,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                Link1 = user.Link1,
                Link2 = user.Link2,
                Link3 = user.Link3,
                ProfileImage = user.ProfileImage,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile profileImage)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.Birthdate = Input.Birthdate;
            user.Address1 = Input.Address1;
            user.Address2 = Input.Address2;
            user.City = Input.City;
            user.State = Input.State;
            user.Zip = Input.Zip;
            user.Link1 = Input.Link1;
            user.Link2 = Input.Link2;
            user.Link3 = Input.Link3;

            // Handle profile image upload
            var profileImageFile = profileImage;
            if (profileImageFile != null && profileImageFile.Length > 0)
            {
                var profileImageFileName = $"{user.Id}_profile_image{Path.GetExtension(profileImageFile.FileName)}";
                var profileImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", profileImageFileName);

                using (var stream = new FileStream(profileImagePath, FileMode.Create))
                {
                    await profileImageFile.CopyToAsync(stream);
                }

                // Update the ProfileImage property
                user.ProfileImage = $"/Uploads/{profileImageFileName}";
            }

            // update user management
            await _signInManager.RefreshSignInAsync(user);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
