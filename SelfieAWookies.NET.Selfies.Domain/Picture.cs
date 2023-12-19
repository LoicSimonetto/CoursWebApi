using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.NET.Selfies.Domain
{
    public class Picture
    {
        public Picture()
        {
            Selfies = new List<Selfie>();
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public List<Selfie> Selfies { get; set; }
    }
}
