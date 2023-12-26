using DoAnTotNghiep.Library;
using DoAnTotNghiep.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnTotNghiep.ViewModel
{
    class UserAccountViewModel : BaseViewModel
    {

        //List
        private ObservableCollection<user> _List;
        public ObservableCollection<user> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List


        //Selected Item
        private user _SelectedItem;
        public user SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    UserName = SelectedItem.username;
                    Email = SelectedItem.email;
                    role selectedRole = DataProvider.Ins.DB.roles.FirstOrDefault(s => s.id == SelectedItem.roleId);
                    SelectedRole = selectedRole;
                    SelectedStatus = StatusList.FirstOrDefault(s => s.StatusID == SelectedItem.status);
                }
            }
        }
        //Selected Item


        //UserName
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        //UserName


        //Email
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        //Email


        //Password
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand PasswordChangedCommand { get; set; }
        //Password


        //Status
        private ObservableCollection<Status> _StatusList;
        public ObservableCollection<Status> StatusList { get => _StatusList; set { _StatusList = value; OnPropertyChanged(); } }

        private Status _SelectedStatus;
        public Status SelectedStatus
        {
            get => _SelectedStatus;
            set
            {
                _SelectedStatus = value;
                OnPropertyChanged();
                if (SelectedStatus != null)
                {
                    if (SelectedItem != null)
                    {
                        SelectedItem.status = SelectedStatus.StatusID;
                    }
                }
            }
        }

        private ICommand _statusSelectionChangedCommand;
        public ICommand StatusSelectionChangedCommand
        {
            get
            {
                return _statusSelectionChangedCommand ?? (_statusSelectionChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    string statusName = SelectedStatus?.StatusName ?? "Unknown";
                    Status = $"{statusName} ({SelectedStatus?.StatusID ?? 0})";
                }));
            }
        }

        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        //Status


        //Role
        private ObservableCollection<role> _ListRole;
        public ObservableCollection<role> ListRole { get => _ListRole; set { _ListRole = value; OnPropertyChanged(); } }

        private role _SelectedRole;
        public role SelectedRole { get => _SelectedRole; set { _SelectedRole = value; OnPropertyChanged(); } }
        //Role


        //Add Command
        public ICommand AddCommand { get; set; }
        //Add Command


        //Edit Command
        public ICommand EditCommand { get; set; }
        //Edit Command


        //Delete Command
        public ICommand DeleteCommand { get; set; }
        //Delete Command

        public UserAccountViewModel()
        {
            StatusList = new ObservableCollection<Status>
            {
                new Status { StatusID = 1, StatusName = "Hoạt động" },
                new Status { StatusID = 2, StatusName = "Ngừng hoạt động" }
            };

            List = new ObservableCollection<user>(DataProvider.Ins.DB.users);
            ListRole = new ObservableCollection<role>(DataProvider.Ins.DB.roles);

            Password = "";

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

            AddCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(UserName) || SelectedStatus == null || SelectedRole == null || Password == null || Email == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.users.Where(x => x.username == UserName);
                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var userProp = new user()
                    {
                        username = UserName,
                        createdAt = DateTime.Now,
                        updatedAt = DateTime.Now,
                        email = Email,
                        password = XString.MD5Hash(XString.Base64Encode(Password)),
                        roleId = SelectedRole.id,
                        status = SelectedStatus.StatusID
                    };
                    DataProvider.Ins.DB.users.Add(userProp);
                    DataProvider.Ins.DB.SaveChanges();

                    List.Add(userProp);

                    MessageBox.Show("Thêm thành công!");

                    UserName = "";
                    Email = "";
                    PasswordChangedCommand = new RelayCommand<PasswordBox>((pw) => { return true; }, (pw) => { pw.Clear(); });
                    SelectedRole = null;
                    SelectedStatus = null;
                });

            EditCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(UserName) || SelectedStatus == null || SelectedRole == null || SelectedItem == null || Email == null)
                        return false;

                    if (SelectedItem.id == CurrentUser.UserID)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var userProp = DataProvider.Ins.DB.users.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                    userProp.username = UserName;
                    userProp.updatedAt = DateTime.Now;
                    userProp.email = Email;
                    if(Password != "" && Password != null)
                    {
                        userProp.password = XString.MD5Hash(XString.Base64Encode(Password));
                    }
                    userProp.roleId = SelectedRole.id;
                    userProp.status = SelectedStatus.StatusID;
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Sửa thành công!");

                    UserName = "";
                    Email = "";
                    PasswordChangedCommand = new RelayCommand<PasswordBox>((pw) => { return true; }, (pw) => { pw.Clear(); });
                    SelectedRole = null;
                    SelectedStatus = null;
                });
            DeleteCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItem == null)
                    {
                        return true;
                    }
                    var displayList = DataProvider.Ins.DB.users.Where(x => x.id == SelectedItem.id && x.status == 0);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    if (SelectedItem.id != CurrentUser.UserID)
                    {
                        if (SelectedItem != null && !string.IsNullOrEmpty(UserName) && SelectedStatus != null && SelectedRole != null && Email != null)
                        {
                            var userProp = DataProvider.Ins.DB.users.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                            userProp.status = 0;
                            DataProvider.Ins.DB.SaveChanges();
                            MessageBox.Show("Xóa thành công!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!");
                    }

                    UserName = "";
                    Email = "";
                    PasswordChangedCommand = new RelayCommand<PasswordBox>((pw) => { return true; }, (pw) => { pw.Clear(); });
                    SelectedRole = null;
                    SelectedStatus = null;
                });
        }
    }
}
