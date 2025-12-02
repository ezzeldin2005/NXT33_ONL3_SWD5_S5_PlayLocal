using DAL.PlayLocal.Models;
using PL.Playlocal.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PL.Playlocal.ViewModels
{
    public enum AccountType
    {
        Player = 1,
        [Display(Name = "Venue Owner")]
        Owner = 2
    }
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select an account type")]
        public AccountType AccountType { get; set; }
    }
}

public static class MappingExtensions
{
    public static Player ToPlayer(this SignUpViewModel vm)
    {
        return new Player
        {
            PlayerID = Guid.NewGuid().ToString(),
            FullName = vm.FullName,
            Email = vm.Email,
            passwordHash = vm.Password,
            PhoneNumber = vm.PhoneNumber,
            Address = string.Empty,
        };
    }

    public static Owner ToOwner(this SignUpViewModel vm)
    {
        return new Owner
        {
            OwnerID = Guid.NewGuid().ToString(),
            FullName = vm.FullName,
            Email = vm.Email,
            Password = vm.Password,
            PhoneNumber = vm.PhoneNumber
        };
    }
}
