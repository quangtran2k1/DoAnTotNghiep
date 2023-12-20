using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Model
{
    public class UserCount
    {
        public role role { get; set; } 
        public int STT { get; set; }
        public int Count { get; set; }
        public int Activated { get; set; }
        public int NotActivated { get; set; }
    }
}
