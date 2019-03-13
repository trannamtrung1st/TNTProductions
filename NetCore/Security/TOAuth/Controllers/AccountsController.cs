using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TOAuth.Areas.Identity.Data;

namespace TOAuth.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        //private SignInManager<OAuthUser> _signInManager;
        private UserManager<OAuthUser> _userManager;
        private IdentityOptions _identityOptions;

        public AccountsController(
            //SignInManager<OAuthUser> signInManager,
            UserManager<OAuthUser> userManager,
            Startup startup)
        {
            //_signInManager = signInManager;
            _userManager = userManager;
            _identityOptions = startup.IdentityOptions;
        }

        //public class LoginModel
        //{
        //    [JsonProperty("email")]
        //    [Required]
        //    [EmailAddress]
        //    public string Email { get; set; }

        //    [JsonProperty("password")]
        //    [Required]
        //    [DataType(DataType.Password)]
        //    public string Password { get; set; }

        //    [JsonProperty("isPersistent")]
        //    public bool IsPersistent { get; set; }
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromForm] LoginModel model)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(
        //        model.Email, model.Password, model.IsPersistent, lockoutOnFailure: true);
        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }
        //    if (result.RequiresTwoFactor)
        //    {
        //        return Unauthorized("Two factor login is required");
        //    }
        //    if (result.IsLockedOut)
        //    {
        //        return Unauthorized("User is locked out");
        //    }
        //    if (result.IsNotAllowed)
        //    {
        //        if (_identityOptions.SignIn.RequireConfirmedEmail
        //        || _identityOptions.SignIn.RequireConfirmedPhoneNumber)
        //        {
        //            return Unauthorized("Account confirmation is required");
        //        }
        //        return Unauthorized();
        //    }
        //    return Unauthorized("Invalid username or password");
        //}

        public class RegisterModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Fullname")]
            public string Name { get; set; }

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
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            var user = new OAuthUser()
            {
                Email = model.Email,
                Name = model.Name,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (_identityOptions.User.RequireUniqueEmail)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //send confirm email
                }
                return Ok();
            }
            foreach (var err in result.Errors)
                ModelState.AddModelError(err.Code, err.Description);
            return BadRequest(ModelState);
        }
    }
}