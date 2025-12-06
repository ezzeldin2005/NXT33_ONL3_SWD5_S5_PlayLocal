
using DAL.PlayLocal.Models;

namespace PL.Playlocal.ViewModels
{
    public class OwnerViewModel
    {
        public string OwnerID { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
    }

    public static class OwnerExtensions
    {
        public static OwnerViewModel ToViewModel(this Owner owner)
        {
            return new OwnerViewModel
            {
                OwnerID = owner.OwnerID,
                FullName = owner.FullName,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber,
                Password = owner.Password 
            };
        }
    }
}