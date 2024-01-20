using DoAnTotNghiep.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoAnTotNghiep.ViewModel
{
    public class SalaryUserViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<SalaryDetail> _List;
        public ObservableCollection<SalaryDetail> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<lesson_count> _ListLC;
        public ObservableCollection<lesson_count> ListLC { get => _ListLC; set { _ListLC = value; OnPropertyChanged(); } }
        private ObservableCollection<bonu> _ListBonus;
        public ObservableCollection<bonu> ListBonus { get => _ListBonus; set { _ListBonus = value; OnPropertyChanged(); } }
        private ObservableCollection<discipline> _ListDiscipline;
        public ObservableCollection<discipline> ListDiscipline { get => _ListDiscipline; set { _ListDiscipline = value; OnPropertyChanged(); } }
        //List


        //Visibility
        private string _IsSalary = "Visible";
        public string IsSalary { get => _IsSalary; set { _IsSalary = value; OnPropertyChanged(); } }
        private string _IsLessonsCount = "Collapsed";
        public string IsLessonsCount { get => _IsLessonsCount; set { _IsLessonsCount = value; OnPropertyChanged(); } }
        private string _IsBonus = "Collapsed";
        public string IsBonus { get => _IsBonus; set { _IsBonus = value; OnPropertyChanged(); } }
        private string _IsDiscipline = "Collapsed";
        public string IsDiscipline { get => _IsDiscipline; set { _IsDiscipline = value; OnPropertyChanged(); } }
        //Visibility


        //Month
        private ObservableCollection<Month> _ListMonth;
        public ObservableCollection<Month> ListMonth { get => _ListMonth; set { _ListMonth = value; OnPropertyChanged(); } }

        private Month _SelectedMonth;
        public Month SelectedMonth { get => _SelectedMonth; set { _SelectedMonth = value; OnPropertyChanged(); } }

        private Month _SelectedMonthAdd;
        public Month SelectedMonthAdd { get => _SelectedMonthAdd; set { _SelectedMonthAdd = value; OnPropertyChanged(); } }
        private Month _SelectedMonthLC;
        public Month SelectedMonthLC { get => _SelectedMonthLC; set { _SelectedMonthLC = value; OnPropertyChanged(); } }
        private Month _SelectedMonthBonus;
        public Month SelectedMonthBonus { get => _SelectedMonthBonus; set { _SelectedMonthBonus = value; OnPropertyChanged(); } }
        private Month _SelectedMonthDiscipline;
        public Month SelectedMonthDiscipline { get => _SelectedMonthDiscipline; set { _SelectedMonthDiscipline = value; OnPropertyChanged(); } }
        //Month


        //Year
        private int _Year = DateTime.Now.Year;
        public int Year { get => _Year; set { _Year = value; OnPropertyChanged(); } }
        private int _YearLC = DateTime.Now.Year;
        public int YearLC { get => _YearLC; set { _YearLC = value; OnPropertyChanged(); } }
        private int _YearBonus = DateTime.Now.Year;
        public int YearBonus { get => _YearBonus; set { _YearBonus = value; OnPropertyChanged(); } }
        private int _YearDiscipline = DateTime.Now.Year;
        public int YearDiscipline { get => _YearDiscipline; set { _YearDiscipline = value; OnPropertyChanged(); } }
        //Year


        public ICommand IsSalaryCommand { get; set; }
        public ICommand IsLessonCountCommand { get; set; }
        public ICommand IsBonusCommand { get; set; }
        public ICommand IsDisciplineCommand { get; set; }


        //Filter Command
        public ICommand FilterSalaryCommand { get; set; }
        public ICommand FilterLCCommand { get; set; }
        public ICommand FilterBonusCommand { get; set; }
        public ICommand FilterDisciplineCommand { get; set; }
        //Filter Command


        public SalaryUserViewModel()
        {
            ListMonth = new ObservableCollection<Month>
            {
                new Month { id = 0, month = "Chọn tháng" },
                new Month { id = 1, month = "Tháng một" },
                new Month { id = 2, month = "Tháng hai" },
                new Month { id = 3, month = "Tháng ba" },
                new Month { id = 4, month = "Tháng bốn" },
                new Month { id = 5, month = "Tháng năm" },
                new Month { id = 6, month = "Tháng sáu" },
                new Month { id = 7, month = "Tháng bảy" },
                new Month { id = 8, month = "Tháng tám" },
                new Month { id = 9, month = "Tháng chín" },
                new Month { id = 10, month = "Tháng mười" },
                new Month { id = 11, month = "Tháng mười một" },
                new Month { id = 12, month = "Tháng mười hai" },
            };
            if (SelectedMonth == null) SelectedMonth = ListMonth.Where(x => x.id == DateTime.Now.Month).FirstOrDefault();
            if (SelectedMonthAdd == null) SelectedMonthAdd = ListMonth.Where(x => x.id == DateTime.Now.Month).FirstOrDefault();
            if (SelectedMonthLC == null) SelectedMonthLC = ListMonth.Where(x => x.id == DateTime.Now.Month).FirstOrDefault();
            if (SelectedMonthBonus == null) SelectedMonthBonus = ListMonth.Where(x => x.id == DateTime.Now.Month).FirstOrDefault();
            if (SelectedMonthDiscipline == null) SelectedMonthDiscipline = ListMonth.Where(x => x.id == DateTime.Now.Month).FirstOrDefault();
            LoadData();
            LoadDataLC();
            LoadDataBonus();
            LoadDataDiscipline();

            IsSalaryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Visible";
                IsLessonsCount = "Collapsed";
                IsBonus = "Collapsed";
                IsDiscipline = "Collapsed";
            });

            IsLessonCountCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Collapsed";
                IsLessonsCount = "Visible";
                IsBonus = "Collapsed";
                IsDiscipline = "Collapsed";
            });

            IsBonusCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Collapsed";
                IsLessonsCount = "Collapsed";
                IsBonus = "Visible";
                IsDiscipline = "Collapsed";
            });

            IsDisciplineCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Collapsed";
                IsLessonsCount = "Collapsed";
                IsBonus = "Collapsed";
                IsDiscipline = "Visible";
            });


            //Filter Command
            FilterSalaryCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadData(); });
            FilterLCCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadDataLC(); });
            FilterBonusCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadDataBonus(); });
            FilterDisciplineCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadDataDiscipline(); });
            //Filter Command
        }

        private void LoadData()
        {
            List = new ObservableCollection<SalaryDetail>();
            var salaryList = DataProvider.Ins.DB.salaries.Where(x => x.month != SelectedMonth.id && x.year != Year && x.teacher.userId == CurrentUser.UserID);

            if (Year == 0 && SelectedMonth.id == 0)
            {
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.month != SelectedMonth.id && x.year != Year && x.teacher.userId == CurrentUser.UserID);
            }
            else if (Year == 0)
            {
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.month == SelectedMonth.id && x.teacher.userId == CurrentUser.UserID);
            }
            else if (SelectedMonth.id == 0)
            {
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.year == Year && x.teacher.userId == CurrentUser.UserID);
            }
            else
            {
                DateTime startTime = new DateTime(Year, SelectedMonth.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.createdAt >= startTime && x.createdAt <= endTime && x.teacher.userId == CurrentUser.UserID);
            }
            foreach (var item in salaryList)
            {
                DateTime startTime = new DateTime(item.year, item.month, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                var lessons = DataProvider.Ins.DB.lesson_count.Where(u => u.teacherId == item.teacherId && startTime <= u.createdAt && u.createdAt <= endTime && u.teacher.userId == CurrentUser.UserID).FirstOrDefault();
                var bonusCount = DataProvider.Ins.DB.bonus.Where(u => u.teacherId == item.id && startTime <= u.createdAt && u.createdAt <= endTime && u.teacher.userId == CurrentUser.UserID);
                var disciplineCount = DataProvider.Ins.DB.disciplines.Where(u => u.teacherId == item.id && startTime <= u.createdAt && u.createdAt <= endTime && u.teacher.userId == CurrentUser.UserID);

                if (lessons != null)
                {
                    LoadSalary(item.teacher.name, item.teacher.citizenIdentification, item.base_salary.currentSalary, lessons.lessonsCount, bonusCount.Count(), disciplineCount.Count(), item.month, item.year, item.total);
                }
            }
        }
        private void LoadDataLC()
        {
            if (YearLC == 0 && SelectedMonthLC.id == 0)
            {
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count.Where(x=> x.teacher.userId == CurrentUser.UserID));
            }
            else if (YearLC == 0)
            {
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count.Where(x => x.createdAt.Month == SelectedMonthLC.id && x.teacher.userId == CurrentUser.UserID));
            }
            else if (SelectedMonthLC.id == 0)
            {
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count.Where(x => x.createdAt.Year == YearLC && x.teacher.userId == CurrentUser.UserID));
            }
            else
            {
                DateTime startTime = new DateTime(YearLC, SelectedMonthLC.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count.Where(x => x.createdAt >= startTime && x.createdAt <= endTime && x.teacher.userId == CurrentUser.UserID));
            }
        }

        private void LoadDataBonus()
        {
            if (YearBonus == 0 && SelectedMonthBonus.id == 0)
            {
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus.Where(x=>x.teacher.userId == CurrentUser.UserID));
            }
            else if (YearBonus == 0)
            {
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus.Where(x => x.createdAt.Month == SelectedMonthBonus.id && x.teacher.userId == CurrentUser.UserID));
            }
            else if (SelectedMonthBonus.id == 0)
            {
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus.Where(x => x.createdAt.Year == YearBonus && x.teacher.userId == CurrentUser.UserID));
            }
            else
            {
                DateTime startTime = new DateTime(YearBonus, SelectedMonthBonus.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus.Where(x => x.createdAt >= startTime && x.createdAt <= endTime && x.teacher.userId == CurrentUser.UserID));
            }
        }

        private void LoadDataDiscipline()
        {
            if (YearDiscipline == 0 && SelectedMonthDiscipline.id == 0)
            {
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines.Where(x=>x.teacher.userId == CurrentUser.UserID));
            }
            else if (YearDiscipline == 0)
            {
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines.Where(x => x.createdAt.Month == SelectedMonthDiscipline.id && x.teacher.userId == CurrentUser.UserID));
            }
            else if (SelectedMonthDiscipline.id == 0)
            {
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines.Where(x => x.createdAt.Year == YearDiscipline && x.teacher.userId == CurrentUser.UserID));
            }
            else
            {
                DateTime startTime = new DateTime(YearDiscipline, SelectedMonthDiscipline.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines.Where(x => x.createdAt >= startTime && x.createdAt <= endTime && x.teacher.userId == CurrentUser.UserID));
            }
        }

        private void LoadSalary(string name, string cccd, int bs, int lc, int bc, int dc, int month, int year, int total)
        {
            SalaryDetail salaryDetail = new SalaryDetail();
            salaryDetail.Name = name;
            salaryDetail.CitizenIdentification = cccd;
            salaryDetail.BaseSalary = bs;
            salaryDetail.LessonCount = lc;
            salaryDetail.BonusCount = bc;
            salaryDetail.DisciplineCount = dc;
            salaryDetail.Month = month;
            salaryDetail.Year = year;
            salaryDetail.Total = total;
            List.Add(salaryDetail);
        }
    }
}
