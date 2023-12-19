using SelfieAWookies.NET.Selfies.Domain;
using SelfieAWookies.NET.Selfies.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfiesAWookies.Core.Framework;
using System.Reflection.Metadata.Ecma335;

namespace SelfieAWookies.NET.Selfies.Infrastructures.Repositories
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        #region Fields
        private readonly SelfiesContext _context;
        #endregion

        #region Properties
        public IUnitOfWork UnitOfWork => this._context;
        #endregion

        #region Constructors    
        public DefaultSelfieRepository(SelfiesContext context)
        {
            _context = context;
        }

        
        #endregion
        #region Pubic methods
        public ICollection<Selfie> GetAll(int wookieId)
        {
            //var toto = _context.Selfies.ToList();
            var query =  _context.Selfies.Include(x => x.Wookie).AsQueryable();

            if (wookieId > 0)
            {
                query = query.Where(item => item.WookieId == wookieId);
            }

            return query.ToList();
        }

        public Selfie AddOne(Selfie item)
        {
            return this._context.Selfies.Add(item).Entity;
        }

        public Picture AddOnePicture(string url)
        {
            return this._context.Pictures.Add(new Picture()
            {
                Url = url
            }).Entity;
        }
        #endregion
    }
}
