using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Interfaces
{
    public interface IPlayerRepository
    {
        int AddPlayer(Player player);
        int UpdatePlayer(Player player);
        int DeletePlayer(Player player);

        Player GetPlayerById(string playerId);
        Player GetPlayerByEmail(string email);

        IEnumerable<Player> GetAllPlayers();
    }

}
