using DoAnTotNghiep.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoAnTotNghiep.ViewModel
{
    class SalaryViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<SalaryDetail> _List;
        public ObservableCollection<SalaryDetail> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List


        //Visibility
        private string _IsSalary = "Visible";
        public string IsSalary { get => _IsSalary; set { _IsSalary = value; OnPropertyChanged(); } }
        private string _IsBaseSalary = "Collapsed";
        public string IsBaseSalary { get => _IsBaseSalary; set { _IsBaseSalary = value; OnPropertyChanged(); } }
        private string _IsLessonsCount = "Collapsed";
        public string IsLessonsCount { get => _IsLessonsCount; set { _IsLessonsCount = value; OnPropertyChanged(); } }
        private string _IsBonus = "Collapsed";
        public string IsBonus { get => _IsBonus; set { _IsBonus = value; OnPropertyChanged(); } }
        private string _IsDiscipline = "Collapsed";
        public string IsDiscipline { get => _IsDiscipline; set { _IsDiscipline = value; OnPropertyChanged(); } }
        //Visibility


        //ListTeacher
        private ObservableCollection<teacher> _ListTeacher;
        public ObservableCollection<teacher> ListTeacher { get => _ListTeacher; set { _ListTeacher = value; OnPropertyChanged(); } }

        private teacher _SelectedTeacher;
        public teacher SelectedTeacher { get => _SelectedTeacher; set { _SelectedTeacher = value; OnPropertyChanged(); } }
        //ListTeacher


        public SalaryViewModel()
        {
            List = new ObservableCollection<SalaryDetail>();
            var salaryList = DataProvider.Ins.DB.salaries;
            foreach (var item in salaryList)
            {
                DateTime startMonth = new DateTime(item.year, item.month, 1);
                DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
                var lessons = DataProvider.Ins.DB.lesson_count.Where(u => u.teacherId == item.id && startMonth <= u.createdAt && u.createdAt <= endMonth).FirstOrDefault();
                var bonusCount = DataProvider.Ins.DB.bonus.Where(u => u.teacherId == item.id && startMonth <= u.createdAt && u.createdAt <= endMonth);
                var disciplineCount = DataProvider.Ins.DB.disciplines.Where(u => u.teacherId == item.id && startMonth <= u.createdAt && u.createdAt <= endMonth);

                if (lessons != null)
                {
                    SalaryDetail salaryDetail = new SalaryDetail();
                    salaryDetail.Id = item.id;
                    salaryDetail.Name = item.teacher.name;
                    salaryDetail.CitizenIdentification = item.teacher.citizenIdentification;
                    salaryDetail.BaseSalary = item.base_salary.currentSalary;
                    salaryDetail.LessonCount = lessons.lessonsCount;
                    salaryDetail.BonusCount = bonusCount.Count();
                    salaryDetail.DisciplineCount = disciplineCount.Count();
                    salaryDetail.Month = item.month;
                    salaryDetail.Year = item.year;
                    salaryDetail.Total = item.total;
                    List.Add(salaryDetail);
                }
            }
        }

        public void LoadData()
        {

        }
    }
}
