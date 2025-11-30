using BLL.PlayLocal.Interfaces;
using DAL.PlayLocal.Contexts;
using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Repostries
{
    public class PlayerRepostiory : IPlayerRepository
    {
        private readonly PlayLocalDBcontext _context;

        public PlayerRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }
        public int AddPlayer(Player player)
        {
            _context.Players.Add(player);
            return _context.SaveChanges();
        }

        public int DeletePlayer(Player player)
        {
            Player? playerToDelete = _context.Players.Find(player.PlayerID);
            if (playerToDelete == null)
            {
                return 0; // Player not found
            }
            else
            {
                _context.Players.Remove(playerToDelete);
                return _context.SaveChanges();
            }
        }

        public IEnumerable<Player> GetAllPlayers() //readonly
        {
           List<Player> players = _context.Players.ToList();
            return players;
        }

        public Player GetPlayerByEmail(string email)
        {
            Player? player = _context.Players.FirstOrDefault(p => p.Email == email);
            return player;
        }

        public Player GetPlayerById(string playerId)
        {
            Player? player = _context.Players.Find(playerId);
            return player;
        }

        public int UpdatePlayer(Player player)
        {
           _context.Players.Update(player);
            return _context.SaveChanges();
        }
    }
}
