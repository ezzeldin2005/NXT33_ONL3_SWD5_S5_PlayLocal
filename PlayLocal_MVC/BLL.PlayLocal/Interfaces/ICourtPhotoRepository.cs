using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Interfaces
{
    public interface ICourtPhotoRepository
    {
        int AddPhoto(CourtPhoto photo);
        int DeletePhoto(string photoId);
        IEnumerable<CourtPhoto> GetPhotosByCourtId(string courtId);
    }

}
