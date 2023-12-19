using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.NET.Selfies.Domain
{
    public interface ISelfieRepository : IRepository
    {
        ICollection<Selfie> GetAll(int wookieId);
        Selfie AddOne(Selfie item);
        Picture AddOnePicture(string url);
        //Picture AddOnePicture(int selfieId, string url);
    }
}
