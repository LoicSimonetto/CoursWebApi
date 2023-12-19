using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//#pragma warning disable CS8618
namespace SelfieAWookies.NET.Selfies.Domain
{
    public class Selfie
    {
        #region Constructors
        //public Selfie()
        //{
        //    Wookie = new Wookie();
        //}
        #endregion
        #region Propriétés
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }

        public int? WookieId { get; set; }
        public Wookie? Wookie { get; set; }
        public int? PictureId { get; set; }
        public Picture? Picture { get; set; }
        #endregion
    }
}
