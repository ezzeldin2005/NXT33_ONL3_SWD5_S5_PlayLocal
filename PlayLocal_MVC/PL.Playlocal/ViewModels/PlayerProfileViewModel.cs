// PL.Playlocal.ViewModels/PlayerProfileViewModel.cs
using DAL.PlayLocal.Models;

namespace PL.Playlocal.ViewModels
{
    public class PlayerProfileViewModel
    {
        public string PlayerID { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public static class PlayerExtensions
    {
        public static PlayerProfileViewModel ToProfileViewModel(this Player player)
        {
            return new PlayerProfileViewModel
            {
                PlayerID = player.PlayerID,
                FullName = player.FullName,
                Email = player.Email,
                PhoneNumber = player.PhoneNumber,
            };
        }
    }
}