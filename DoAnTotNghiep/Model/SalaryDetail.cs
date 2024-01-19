using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Model
{
    public class SalaryDetail
    {
        public string Name { get; set; }
        public string CitizenIdentification { get; set; }
        public int BaseSalary { get; set; }
        public int LessonCount { get; set; }
        public int BonusCount { get; set; }
        public int DisciplineCount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Total { get; set; }
    }
}
