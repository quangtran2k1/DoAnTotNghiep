using DoAnTotNghiep.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoAnTotNghiep.ViewModel
{
    class SalaryViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<teacher> _TeacherSearchResult;
        public ObservableCollection<teacher> TeacherSearchResult { get => _TeacherSearchResult; set { _TeacherSearchResult = value; OnPropertyChanged(); } }
        private ObservableCollection<SalaryDetail> _List;
        public ObservableCollection<SalaryDetail> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<base_salary> _ListBS;
        public ObservableCollection<base_salary> ListBS { get => _ListBS; set { _ListBS = value; OnPropertyChanged(); } }
        private ObservableCollection<lesson_count> _ListLC;
        public ObservableCollection<lesson_count> ListLC { get => _ListLC; set { _ListLC = value; OnPropertyChanged(); } }
        private ObservableCollection<bonu> _ListBonus;
        public ObservableCollection<bonu> ListBonus { get => _ListBonus; set { _ListBonus = value; OnPropertyChanged(); } }
        private ObservableCollection<discipline> _ListDiscipline;
        public ObservableCollection<discipline> ListDiscipline { get => _ListDiscipline; set { _ListDiscipline = value; OnPropertyChanged(); } }
        //List


        //SelectedTeacher
        private teacher _SelectedTeacher;
        public teacher SelectedTeacher { get => _SelectedTeacher; set { _SelectedTeacher = value; OnPropertyChanged(); } }
        private teacher _SelectedTeacherBonus;
        public teacher SelectedTeacherBonus { get => _SelectedTeacherBonus; set { _SelectedTeacherBonus = value; OnPropertyChanged(); } }
        private teacher _SelectedTeacherLC;
        public teacher SelectedTeacherLC { get => _SelectedTeacherLC; set { _SelectedTeacherLC = value; OnPropertyChanged(); } }
        private teacher _SelectedTeacherDiscipline;
        public teacher SelectedTeacherDiscipline { get => _SelectedTeacherDiscipline; set { _SelectedTeacherDiscipline = value; OnPropertyChanged(); } }
        //SelectedTeacher


        //SelectedItem
        private SalaryDetail _SelectedItem;
        public SalaryDetail SelectedItem 
        { 
            get => _SelectedItem; 
            set 
            { 
                _SelectedItem = value; 
                OnPropertyChanged(); 
                if (SelectedItem != null)
                {
                    teacher teacherSelect = DataProvider.Ins.DB.teachers.Where(x => x.citizenIdentification == SelectedItem.CitizenIdentification).FirstOrDefault();
                    SelectedTeacher = teacherSelect;
                    base_salary BSSelect = DataProvider.Ins.DB.base_salary.Where(x => x.currentSalary == SelectedItem.BaseSalary).FirstOrDefault();
                    SelectedBaseSalary = BSSelect;
                    SelectedMonth = ListMonth.Where(x => x.id == SelectedItem.Month).FirstOrDefault();
                    YearAdd = SelectedItem.Year;
                }
            } 
        }
        private base_salary _SelectedItemBS;
        public base_salary SelectedItemBS 
        { 
            get => _SelectedItemBS; 
            set 
            { 
                _SelectedItemBS = value; 
                OnPropertyChanged(); 
                if (SelectedItemBS != null)
                {
                    CurrentSalary = SelectedItemBS.currentSalary;
                }
            } 
        }
        private bonu _SelectedItemBonus;
        public bonu SelectedItemBonus 
        { 
            get => _SelectedItemBonus; 
            set 
            { 
                _SelectedItemBonus = value; 
                OnPropertyChanged(); 
                if (SelectedItemBonus != null)
                {
                    teacher teacherSelect = DataProvider.Ins.DB.teachers.Where(x => x.id == SelectedItemBonus.teacherId).FirstOrDefault();
                    SelectedTeacherBonus = teacherSelect;
                    ReasonBonus = SelectedItemBonus.reason;
                    Bonus = SelectedItemBonus.bonus;
                }
            } 
        }
        private lesson_count _SelectedItemLC;
        public lesson_count SelectedItemLC 
        { 
            get => _SelectedItemLC; 
            set 
            { 
                _SelectedItemLC = value; 
                OnPropertyChanged(); 
                if (SelectedItemLC != null)
                {
                    teacher teacherSelect = DataProvider.Ins.DB.teachers.Where(x => x.id == SelectedItemLC.teacherId).FirstOrDefault();
                    SelectedTeacherLC = teacherSelect;
                    LessonCount = SelectedItemLC.lessonsCount;
                }
            } 
        }
        private discipline _SelectedItemDC;
        public discipline SelectedItemDC 
        { 
            get => _SelectedItemDC; 
            set 
            { 
                _SelectedItemDC = value; 
                OnPropertyChanged(); 
                if (SelectedItemDC != null)
                {
                    teacher teacherSelect = DataProvider.Ins.DB.teachers.Where(x => x.id == SelectedItemDC.teacherId).FirstOrDefault();
                    SelectedTeacherDiscipline = teacherSelect;
                    ReasonDiscipline = SelectedItemDC.reason;
                    Discipline = SelectedItemDC.fine;
                }
            } 
        }
        //SelectedItem


        //SeletedBaseSalary
        private base_salary _SelectedBaseSalary;
        public base_salary SelectedBaseSalary { get => _SelectedBaseSalary; set { _SelectedBaseSalary = value; OnPropertyChanged(); } }
        //SeletedBaseSalary


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
        private int _YearAdd = DateTime.Now.Year;
        public int YearAdd { get => _YearAdd; set { _YearAdd = value; OnPropertyChanged(); } }
        private int _YearLC = DateTime.Now.Year;
        public int YearLC { get => _YearLC; set { _YearLC = value; OnPropertyChanged(); } }
        private int _YearBonus = DateTime.Now.Year;
        public int YearBonus { get => _YearBonus; set { _YearBonus = value; OnPropertyChanged(); } }
        private int _YearDiscipline = DateTime.Now.Year;
        public int YearDiscipline { get => _YearDiscipline; set { _YearDiscipline = value; OnPropertyChanged(); } }
        //Year


        //CurrentSalary
        private int _CurrentSalary;
        public int CurrentSalary { get => _CurrentSalary; set { _CurrentSalary = value; OnPropertyChanged(); } }
        //CurrentSalary


        //LessonCount
        private int _LessonCount;
        public int LessonCount { get => _LessonCount; set { _LessonCount = value; OnPropertyChanged(); } }
        //LessonCount


        //Bonus
        private int _Bonus;
        public int Bonus { get => _Bonus; set { _Bonus = value; OnPropertyChanged(); } }
        private string _ReasonBonus;
        public string ReasonBonus { get => _ReasonBonus; set { _ReasonBonus = value; OnPropertyChanged(); } }
        //Bonus


        //Discipline
        private int _Discipline;
        public int Discipline { get => _Discipline; set { _Discipline = value; OnPropertyChanged(); } }
        private string _ReasonDiscipline;
        public string ReasonDiscipline { get => _ReasonDiscipline; set { _ReasonDiscipline = value; OnPropertyChanged(); } }
        //Discipline


        public ICommand IsSalaryCommand { get; set; }
        public ICommand IsBaseSalaryCommand { get; set; }
        public ICommand IsLessonCountCommand { get; set; }
        public ICommand IsBonusCommand { get; set; }
        public ICommand IsDisciplineCommand { get; set; }


        //Add Command
        public ICommand AddSalaryCommand { get; set; }
        public ICommand AddBSCommand { get; set; }
        public ICommand AddLCCommand { get; set; }
        public ICommand AddBonusCommand { get; set; }
        public ICommand AddDisciplineCommand { get; set; }
        //Add Command


        //Edit Command
        public ICommand EditSalaryCommand { get; set; }
        public ICommand EditBSCommand { get; set; }
        public ICommand EditLCCommand { get; set; }
        public ICommand EditBonusCommand { get; set; }
        public ICommand EditDisciplineCommand { get; set; }
        //Edit Command


        //Clear Command
        public ICommand ClearSalaryCommand { get; set; }
        public ICommand ClearBSCommand { get; set; }
        public ICommand ClearLCCommand { get; set; }
        public ICommand ClearBonusCommand { get; set; }
        public ICommand ClearDisciplineCommand { get; set; }
        //Clear Command


        //Filter Command
        public ICommand FilterSalaryCommand { get; set; }
        public ICommand FilterLCCommand { get; set; }
        public ICommand FilterBonusCommand { get; set; }
        public ICommand FilterDisciplineCommand { get; set; }
        //Filter Command


        public SalaryViewModel()
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
            LoadListTeacher();
            LoadData();
            ListBS = new ObservableCollection<base_salary>(DataProvider.Ins.DB.base_salary);
            LoadDataLC();
            LoadDataBonus();
            LoadDataDiscipline();

            IsSalaryCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            { 
                IsSalary = "Visible";
                IsBaseSalary = "Collapsed";
                IsLessonsCount = "Collapsed";
                IsBonus = "Collapsed";
                IsDiscipline = "Collapsed";
            });

            IsBaseSalaryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Collapsed";
                IsBaseSalary = "Visible";
                IsLessonsCount = "Collapsed";
                IsBonus = "Collapsed";
                IsDiscipline = "Collapsed";
            });

            IsLessonCountCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Collapsed";
                IsBaseSalary = "Collapsed";
                IsLessonsCount = "Visible";
                IsBonus = "Collapsed";
                IsDiscipline = "Collapsed";
            });

            IsBonusCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Collapsed";
                IsBaseSalary = "Collapsed";
                IsLessonsCount = "Collapsed";
                IsBonus = "Visible";
                IsDiscipline = "Collapsed";
            });

            IsDisciplineCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSalary = "Collapsed";
                IsBaseSalary = "Collapsed";
                IsLessonsCount = "Collapsed";
                IsBonus = "Collapsed";
                IsDiscipline = "Visible";
            });

            //Add Command
            AddSalaryCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacher == null)
                       return false;
                   if (SelectedMonthAdd.id == 0)
                       return false;
                   if (LessonCount < 0)
                       return false;
                   var check = DataProvider.Ins.DB.salaries.Where(x => x.teacherId == SelectedTeacher.id && x.month == SelectedMonthAdd.id && x.year == YearAdd);
                   if (check.Count() != 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   DateTime startMonth = new DateTime(YearAdd, SelectedMonthAdd.id, 1);
                   DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
                   var lessons = DataProvider.Ins.DB.lesson_count.Where(u => u.teacherId == SelectedTeacher.id && startMonth <= u.createdAt && u.createdAt <= endMonth).FirstOrDefault();
                   if (lessons != null)
                   {
                       var bonusCount = DataProvider.Ins.DB.bonus.Where(u => u.teacherId == SelectedTeacher.id && startMonth <= u.createdAt && u.createdAt <= endMonth);
                       var disciplineCount = DataProvider.Ins.DB.disciplines.Where(u => u.teacherId == SelectedTeacher.id && startMonth <= u.createdAt && u.createdAt <= endMonth);
                       int bonus = 0;
                       int fine = 0;
                       foreach (var item in bonusCount)
                       {
                           bonus = bonus + item.bonus;
                       }
                       foreach (var item in disciplineCount)
                       {
                           fine = bonus + item.fine;
                       }
                       int baseSalary = DataProvider.Ins.DB.base_salary.Where(x => x.id == SelectedBaseSalary.id).FirstOrDefault().currentSalary;
                       var salaryProp = new salary()
                       {
                           createdAt = DateTime.Now,
                           createdBy = CurrentUser.UserID,
                           updatedAt = DateTime.Now,
                           updatedBy = CurrentUser.UserID,
                           month = SelectedMonthAdd.id,
                           year = YearAdd,
                           baseSalaryId = SelectedBaseSalary.id,
                           teacherId = SelectedTeacher.id,
                           total = baseSalary * lessons.lessonsCount + bonus - fine
                       };
                       DataProvider.Ins.DB.salaries.Add(salaryProp);
                       DataProvider.Ins.DB.SaveChanges();

                       LoadSalary(SelectedTeacher.name, SelectedTeacher.citizenIdentification, SelectedBaseSalary.currentSalary, lessons.lessonsCount, bonusCount.Count(), disciplineCount.Count(), SelectedMonthAdd.id, YearAdd, salaryProp.total);

                       MessageBox.Show("Thêm thành công!");

                       SelectedMonthAdd = ListMonth.Where(x => x.id == DateTime.Now.Month).FirstOrDefault();
                       SelectedTeacher = null;
                       SelectedBaseSalary = null;
                       YearAdd = DateTime.Now.Year;
                   }
                   else
                   {
                       MessageBox.Show("Chưa thêm số tiết dạy của giáo viên này!");
                   }
                   
               });
            AddBSCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (CurrentSalary < 0)
                       return false;
                   var check = DataProvider.Ins.DB.base_salary.Where(x => x.currentSalary == CurrentSalary);
                   if (check.Count() != 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var baseSalaryProp = new base_salary()
                   {
                       createdAt = DateTime.Now,
                       createdBy = CurrentUser.UserID,
                       updatedAt = DateTime.Now,
                       updatedBy = CurrentUser.UserID,
                       currentSalary = CurrentSalary
                   };
                   DataProvider.Ins.DB.base_salary.Add(baseSalaryProp);
                   DataProvider.Ins.DB.SaveChanges();

                   ListBS.Add(baseSalaryProp);

                   MessageBox.Show("Thêm thành công!");

                   CurrentSalary = 0;
               });
            AddLCCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacherLC == null)
                       return false;
                   if (SelectedMonthLC.id == 0)
                       return false;
                   DateTime startMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                   DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
                   var check = DataProvider.Ins.DB.lesson_count.Where(x => x.teacherId == SelectedTeacherLC.id && startMonth <= x.createdAt && x.createdAt <= endMonth);
                   if (check.Count() != 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var lessonsProp = new lesson_count()
                   {
                       createdAt = DateTime.Now,
                       createdBy = CurrentUser.UserID,
                       updatedAt = DateTime.Now,
                       updatedBy = CurrentUser.UserID,
                       teacherId = SelectedTeacherLC.id,
                       lessonsCount = LessonCount
                   };
                   DataProvider.Ins.DB.lesson_count.Add(lessonsProp);
                   DataProvider.Ins.DB.SaveChanges();

                   ListLC.Add(lessonsProp);

                   MessageBox.Show("Thêm thành công!");

                   SelectedTeacherLC = null;
                   LessonCount = 0;
               });
            AddBonusCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacherBonus == null)
                       return false;
                   if (SelectedMonthBonus.id == 0)
                       return false;
                   if (ReasonBonus == null)
                       return false;
                   if (Bonus < 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var bonusProp = new bonu()
                   {
                       createdAt = DateTime.Now,
                       createdBy = CurrentUser.UserID,
                       updatedAt = DateTime.Now,
                       updatedBy = CurrentUser.UserID,
                       teacherId = SelectedTeacherBonus.id,
                       reason = ReasonBonus,
                       bonus = Bonus
                   };
                   DataProvider.Ins.DB.bonus.Add(bonusProp);
                   DataProvider.Ins.DB.SaveChanges();

                   ListBonus.Add(bonusProp);

                   MessageBox.Show("Thêm thành công!");

                   SelectedTeacherBonus = null;
                   ReasonBonus = "";
                   Bonus = 0;
               });
            AddDisciplineCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacherDiscipline == null)
                       return false;
                   if (SelectedMonthDiscipline.id == 0)
                       return false;
                   if (ReasonDiscipline == null)
                       return false;
                   if (Discipline < 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var disciplineProp = new discipline()
                   {
                       createdAt = DateTime.Now,
                       createdBy = CurrentUser.UserID,
                       updatedAt = DateTime.Now,
                       updatedBy = CurrentUser.UserID,
                       teacherId = SelectedTeacherDiscipline.id,
                       reason = ReasonDiscipline,
                       fine = Discipline
                   };
                   DataProvider.Ins.DB.disciplines.Add(disciplineProp);
                   DataProvider.Ins.DB.SaveChanges();

                   ListDiscipline.Add(disciplineProp);

                   MessageBox.Show("Thêm thành công!");

                   SelectedTeacherDiscipline = null;
                   ReasonDiscipline = "";
                   Discipline = 0;
               });
            //Add Command

            //Edit Command
            EditSalaryCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacher == null)
                       return false;
                   if (SelectedMonthAdd.id == 0)
                       return false;
                   if (LessonCount < 0)
                       return false;
                   var check = DataProvider.Ins.DB.salaries.Where(x => x.teacherId == SelectedTeacher.id && x.month == SelectedMonthAdd.id && x.year == YearAdd);
                   if (check.Count() > 1)
                       return false;

                   return true;
               },
               (p) =>
               {
                   DateTime startMonth = new DateTime(YearAdd, SelectedMonthAdd.id, 1);
                   DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
                   var lessons = DataProvider.Ins.DB.lesson_count.Where(u => u.teacherId == SelectedTeacher.id && startMonth <= u.createdAt && u.createdAt <= endMonth).FirstOrDefault();
                   if (lessons != null)
                   {
                       var bonusCount = DataProvider.Ins.DB.bonus.Where(u => u.teacherId == SelectedTeacher.id && startMonth <= u.createdAt && u.createdAt <= endMonth);
                       var disciplineCount = DataProvider.Ins.DB.disciplines.Where(u => u.teacherId == SelectedTeacher.id && startMonth <= u.createdAt && u.createdAt <= endMonth);
                       int bonus = 0;
                       int fine = 0;
                       foreach (var item in bonusCount)
                       {
                           bonus = bonus + item.bonus;
                       }
                       foreach (var item in disciplineCount)
                       {
                           fine = bonus + item.fine;
                       }
                       int baseSalary = DataProvider.Ins.DB.base_salary.Where(x => x.id == SelectedBaseSalary.id).FirstOrDefault().currentSalary;
                       var salaryProp = DataProvider.Ins.DB.salaries.Where(x => x.teacher.name == SelectedItem.Name && x.teacher.citizenIdentification == SelectedItem.CitizenIdentification && x.month == SelectedItem.Month && x.year == SelectedItem.Year).SingleOrDefault();
                       salaryProp.month = SelectedMonthAdd.id;
                       salaryProp.updatedAt = DateTime.Now;
                       salaryProp.updatedBy = CurrentUser.UserID;
                       salaryProp.teacherId = SelectedTeacher.id;
                       salaryProp.year = YearAdd;
                       salaryProp.baseSalaryId = SelectedBaseSalary.id;
                       salaryProp.total = baseSalary * lessons.lessonsCount + bonus - fine;
                       DataProvider.Ins.DB.SaveChanges();

                       LoadSalary(SelectedTeacher.name, SelectedTeacher.citizenIdentification, SelectedBaseSalary.currentSalary, lessons.lessonsCount, bonusCount.Count(), disciplineCount.Count(), SelectedMonthAdd.id, YearAdd, salaryProp.total);

                       MessageBox.Show("Sửa thành công!");

                       SelectedMonthAdd = ListMonth.Where(x => x.id == DateTime.Now.Month).FirstOrDefault();
                       SelectedTeacher = null;
                       SelectedBaseSalary = null;
                       YearAdd = DateTime.Now.Year;
                   }
                   else
                   {
                       MessageBox.Show("Chưa thêm số tiết dạy của giáo viên này!");
                   }

               });
            EditBSCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (CurrentSalary < 0)
                       return false;
                   var check = DataProvider.Ins.DB.base_salary.Where(x => x.currentSalary == CurrentSalary);
                   if (check.Count() != 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var baseSalaryProp = DataProvider.Ins.DB.base_salary.Where(x => x.id == SelectedItemBS.id).SingleOrDefault();
                   baseSalaryProp.currentSalary = CurrentSalary;
                   baseSalaryProp.updatedAt = DateTime.Now;
                   baseSalaryProp.updatedBy = CurrentUser.UserID;
                   DataProvider.Ins.DB.SaveChanges();

                   MessageBox.Show("Sửa thành công!");

                   CurrentSalary = 0;
               });
            EditLCCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacherLC == null)
                       return false;
                   if (SelectedMonthLC.id == 0)
                       return false;
                   DateTime startMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                   DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
                   var check = DataProvider.Ins.DB.lesson_count.Where(x => x.teacherId == SelectedTeacherLC.id && startMonth <= x.createdAt && x.createdAt <= endMonth);
                   if (check.Count() != 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var lessonsProp = DataProvider.Ins.DB.lesson_count.Where(x => x.id == SelectedItemLC.id).SingleOrDefault();
                   lessonsProp.lessonsCount = LessonCount;
                   lessonsProp.updatedAt = DateTime.Now;
                   lessonsProp.updatedBy = CurrentUser.UserID;
                   lessonsProp.teacherId = SelectedTeacherLC.id;
                   DataProvider.Ins.DB.SaveChanges();

                   MessageBox.Show("Sửa thành công!");

                   SelectedTeacherLC = null;
                   LessonCount = 0;
               });
            EditBonusCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacherBonus == null)
                       return false;
                   if (SelectedMonthBonus.id == 0)
                       return false;
                   if (ReasonBonus == null)
                       return false;
                   if (Bonus < 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var bonusProp = DataProvider.Ins.DB.bonus.Where(x => x.id == SelectedItemBonus.id).SingleOrDefault();
                   bonusProp.bonus = Bonus;
                   bonusProp.updatedAt = DateTime.Now;
                   bonusProp.updatedBy = CurrentUser.UserID;
                   bonusProp.teacherId = SelectedTeacherBonus.id;
                   bonusProp.reason = ReasonBonus;
                   DataProvider.Ins.DB.SaveChanges();

                   MessageBox.Show("Sửa thành công!");

                   SelectedTeacherBonus = null;
                   ReasonBonus = "";
                   Bonus = 0;
               });
            EditDisciplineCommand = new RelayCommand<object>(
               (p) =>
               {
                   if (SelectedTeacherDiscipline == null)
                       return false;
                   if (SelectedMonthDiscipline.id == 0)
                       return false;
                   if (ReasonDiscipline == null)
                       return false;
                   if (Discipline < 0)
                       return false;

                   return true;
               },
               (p) =>
               {
                   var disciplineProp = DataProvider.Ins.DB.disciplines.Where(x => x.id == SelectedItemDC.id).SingleOrDefault();
                   disciplineProp.fine = Discipline;
                   disciplineProp.updatedAt = DateTime.Now;
                   disciplineProp.updatedBy = CurrentUser.UserID;
                   disciplineProp.teacherId = SelectedTeacherDiscipline.id;
                   disciplineProp.reason = ReasonDiscipline;
                   DataProvider.Ins.DB.SaveChanges();

                   MessageBox.Show("Sửa thành công!");

                   SelectedTeacherDiscipline = null;
                   ReasonDiscipline = "";
                   Discipline = 0;
               });
            //Edit Command


            //Filter Command
            FilterSalaryCommand = new RelayCommand<object>( (p) => { return true; }, (p) => { LoadData(); });
            FilterLCCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadDataLC(); });
            FilterBonusCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadDataBonus(); });
            FilterDisciplineCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadDataDiscipline(); });
            //Filter Command
        }

        public void LoadListTeacher()
        {
            TeacherSearchResult = new ObservableCollection<teacher>(DataProvider.Ins.DB.teachers);
        }
        private void LoadData()
        {
            List = new ObservableCollection<SalaryDetail>();
            var salaryList = DataProvider.Ins.DB.salaries.Where(x=>x.month != SelectedMonth.id && x.year != Year);

            if (Year == 0 && SelectedMonth.id == 0)
            {
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.month != SelectedMonth.id && x.year != Year);
            }
            else if (Year == 0)
            {
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.month == SelectedMonth.id);
            }
            else if (SelectedMonth.id == 0)
            {
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.year == Year);
            }
            else
            {
                DateTime startTime = new DateTime(Year, SelectedMonth.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                salaryList = DataProvider.Ins.DB.salaries.Where(x => x.createdAt >= startTime && x.createdAt <= endTime);
            }
            foreach (var item in salaryList)
            {
                DateTime startTime = new DateTime(item.year, item.month, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                var lessons = DataProvider.Ins.DB.lesson_count.Where(u => u.teacherId == item.teacherId && startTime <= u.createdAt && u.createdAt <= endTime).FirstOrDefault();
                var bonusCount = DataProvider.Ins.DB.bonus.Where(u => u.teacherId == item.id && startTime <= u.createdAt && u.createdAt <= endTime);
                var disciplineCount = DataProvider.Ins.DB.disciplines.Where(u => u.teacherId == item.id && startTime <= u.createdAt && u.createdAt <= endTime);

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
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count);
            }
            else if(YearLC == 0)
            {
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count.Where(x=>x.createdAt.Month == SelectedMonthLC.id));
            }
            else if (SelectedMonthLC.id == 0)
            {
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count.Where(x => x.createdAt.Year == YearLC));
            }
            else
            {
                DateTime startTime = new DateTime(YearLC, SelectedMonthLC.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                ListLC = new ObservableCollection<lesson_count>(DataProvider.Ins.DB.lesson_count.Where(x => x.createdAt >= startTime && x.createdAt <= endTime));
            }
        }

        private void LoadDataBonus()
        {
            if (YearBonus == 0 && SelectedMonthBonus.id == 0)
            {
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus);
            }
            else if (YearBonus == 0)
            {
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus.Where(x => x.createdAt.Month == SelectedMonthBonus.id));
            }
            else if (SelectedMonthBonus.id == 0)
            {
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus.Where(x => x.createdAt.Year == YearBonus));
            }
            else
            {
                DateTime startTime = new DateTime(YearBonus, SelectedMonthBonus.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                ListBonus = new ObservableCollection<bonu>(DataProvider.Ins.DB.bonus.Where(x => x.createdAt >= startTime && x.createdAt <= endTime));
            }
        }

        private void LoadDataDiscipline()
        {
            if (YearDiscipline == 0 && SelectedMonthDiscipline.id == 0)
            {
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines);
            }
            else if (YearDiscipline == 0)
            {
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines.Where(x => x.createdAt.Month == SelectedMonthDiscipline.id));
            }
            else if (SelectedMonthDiscipline.id == 0)
            {
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines.Where(x => x.createdAt.Year == YearDiscipline));
            }
            else
            {
                DateTime startTime = new DateTime(YearDiscipline, SelectedMonthDiscipline.id, 1);
                DateTime endTime = startTime.AddMonths(1).AddDays(-1);
                ListDiscipline = new ObservableCollection<discipline>(DataProvider.Ins.DB.disciplines.Where(x => x.createdAt >= startTime && x.createdAt <= endTime));
            }
        }

        private void LoadSalary( string name, string cccd, int bs, int lc, int bc, int dc, int month, int year, int total)
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
