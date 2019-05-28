using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Voting.Data;
using Voting.Models;

namespace Voting.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<applicationUser> _signInManager;
        private readonly UserManager<applicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<applicationUser> userManager,
            SignInManager<applicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "First Name")]
            [DataType(DataType.Text)]
            [StringLength(50,ErrorMessage ="The {0} must be atleast {2} and at max {1} characters long.")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Mother Name")]
            [DataType(DataType.Text)]
            [StringLength(100, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string MotherName { get; set; }

            [Required]
            [Display(Name = "Birth Date")]
            [DataType(DataType.Text)]
            public string BirthDate { get; set; }

            [Required]
            [Display(Name = "City")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string City { get; set; }

            [Required]
            [Display(Name = "Subcity")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string Subcity { get; set; }

            [Required]
            [Display(Name = "Woreda")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string Woreda { get; set; }

            [Required]
            [Display(Name = "House Number")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string HouseNumber { get; set; }

            [Required]
            [Display(Name = "Identification Number")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string IdNumber { get; set; }

            [Required]
            [Display(Name = "File Id")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
            public string FileNumber { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                // var user = new applicationUser { UserName = Input.Email, Email = Input.Email };
                var user = new applicationUser
                {
                      
                      UserName=Input.Email,
                      Email=Input.Email,
                      FirstName=Input.FirstName,
                      LastName= Input.LastName,
                      MotherName=Input.MotherName,
                      BirthDate = Input.BirthDate,
                      Woreda = Input.Woreda,
                      HouseNumber = Input.HouseNumber,
                      Subcity = Input.Subcity,
                      City = Input.City,
                      IdNumber = Input.IdNumber,
                      FileNumber = Input.FileNumber
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    _logger.LogInformation("User created a new account with password.");
                    var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                    await _userManager.AddToRoleAsync(user, "Voter");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
