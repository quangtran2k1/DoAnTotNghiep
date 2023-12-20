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
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<UserCount> _UserCountList;
        public ObservableCollection<UserCount> UserCountList { get => _UserCountList; set { _UserCountList = value; OnPropertyChanged(); } }
        public bool Isloaded = false;
        private int _studentCount;
        public int studentCount { get => _studentCount; set { _studentCount = value; OnPropertyChanged(); } }
        private int _teacherCount;
        public int teacherCount { get => _teacherCount; set { _teacherCount = value; OnPropertyChanged(); } }
        private int _classCount;
        public int classCount { get => _classCount; set { _classCount = value; OnPropertyChanged(); } }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ClassesWindowCommand { get; set; }
        public ICommand UsersWindowCommand { get; set; }
        public ICommand TeacherEditWindowCommand { get; set; }
        public ICommand EditPassWindow { get; set; }
        public ICommand MainUserWindow { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                if (p == null) return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null) return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsAdminLogin)
                {
                    p.Show();
                    loadUserCountData();
                }
                else if (loginVM.IsStudentLogin) 
                {
                    MainUserWindow mainUserWindow = new MainUserWindow();
                    mainUserWindow.Show();
                    p.Close();
                }
                else p.Close();
            });

            ClassesWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                ClassesWindow classesWindow = new ClassesWindow();
                classesWindow.ShowDialog();
            });

            UsersWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                UsersWindow usersWindow = new UsersWindow();
                usersWindow.ShowDialog();
            });

            TeacherEditWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                TeacherEditWindow teacherEdit = new TeacherEditWindow();
                teacherEdit.ShowDialog();
            });

            EditPassWindow = new RelayCommand<object>((p) => { return true; }, (p) => {
                EditPassWindow editPassWindow = new EditPassWindow();
                editPassWindow.ShowDialog();
            });

            MainUserWindow = new RelayCommand<object>((p) => { return true; }, (p) => {
                MainUserWindow mainUserWindow = new MainUserWindow();
                mainUserWindow.ShowDialog();
            });

            studentCount = DataProvider.Ins.DB.users.Where(u => u.roles.FirstOrDefault().role1 == "Student" && u.status == 1).Count();
            teacherCount = DataProvider.Ins.DB.users.Where(u => u.roles.FirstOrDefault().role1 == "Teacher" && u.status == 1).Count();
            classCount = DataProvider.Ins.DB.classes.Where(c => c.status == 1).Count();

        }

        void loadUserCountData()
        {
            UserCountList = new ObservableCollection<UserCount>();

            var rolesList = DataProvider.Ins.DB.roles;
            int i = 1;
            foreach (var item in rolesList)
            {
                var countActiavted = DataProvider.Ins.DB.users.Where(u => u.roles.FirstOrDefault().id == item.id && u.status == 1).Count();
                var countNotActiavted = DataProvider.Ins.DB.users.Where(u => u.roles.FirstOrDefault().id == item.id && u.status == 2).Count();

                UserCount userCount = new UserCount();
                userCount.STT = i;
                userCount.role = item;
                userCount.Count = countActiavted + countNotActiavted;
                userCount.Activated = countActiavted;
                userCount.NotActivated = countNotActiavted;
                UserCountList.Add(userCount);

                i++;
            }

        }

    }
}
