using DoAnTotNghiep.Library;
using DoAnTotNghiep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnTotNghiep.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsAdminLogin { get; set; }
        public bool IsStudentLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            IsAdminLogin = false;
            IsStudentLogin = false;
            UserName = "";
            Password = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

        }

        void Login(Window p)
        {
            if (p == null) return;

            string passEnCode = XString.MD5Hash(XString.Base64Encode(Password));
            var user = DataProvider.Ins.DB.users.Where(u => u.username == UserName && u.password == passEnCode).FirstOrDefault();
            if (user != null)
            {
                CurrentUser.UserID = user.id;

                if (user.roles.First().role1 == "Admin")
                {
                    IsAdminLogin = true;
                    p.Close();
                }
                else
                {
                    IsStudentLogin = true;
                    p.Close();
                }
            }
            else
            {
                IsAdminLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu. Vui lòng nhập lại!");
            }
        }
    }

    public static class CurrentUser
    {
        public static int UserID { get; set; }
    }
}
