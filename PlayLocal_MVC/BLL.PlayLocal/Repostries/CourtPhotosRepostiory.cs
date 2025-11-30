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
    public class CourtPhotosRepostiory : ICourtPhotoRepository
    {
        private readonly PlayLocalDBcontext _context;

        public CourtPhotosRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }
        public int AddPhoto(CourtPhoto photo)
        {
            _context.CourtPhotos.Add(photo);

            return _context.SaveChanges();
        }

        public int DeletePhoto(string photoId)
        {
            CourtPhoto photoToDelete = _context.CourtPhotos.Find(photoId)!;

            if (photoToDelete != null)
            {
                _context.CourtPhotos.Remove(photoToDelete);
                return _context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<CourtPhoto> GetPhotosByCourtId(string courtId)
        {
            List<CourtPhoto> photos = _context.CourtPhotos.Where(p => p.CourtID == courtId).ToList();
            return photos;
        }
    }
}
