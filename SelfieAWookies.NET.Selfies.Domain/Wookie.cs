using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

//#pragma warning disable CS8618

namespace SelfieAWookies.NET.Selfies.Domain
{
    public class Wookie
    {
        #region Constructors
        public Wookie()
        {
            Selfies = new List<Selfie>();
        }
        #endregion
        #region properties
        public int Id { get; set; }
        public string Surname { get; set; }
        public List<Selfie> Selfies { get; set; }
        #endregion
    }
}
