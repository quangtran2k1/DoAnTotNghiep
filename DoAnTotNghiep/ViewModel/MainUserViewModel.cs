using DoAnTotNghiep.Library;
using DoAnTotNghiep.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DoAnTotNghiep.ViewModel
{
    class MainUserViewModel : BaseViewModel
    {
        //ClassList
        private ObservableCollection<@class> _ClassList;
        public ObservableCollection<@class> ClassList { get => _ClassList; set { _ClassList = value; OnPropertyChanged(); } }
        //ClassList


        //ListStudent
        private ObservableCollection<student> _ListStudent;
        public ObservableCollection<student> ListStudent { get => _ListStudent; set { _ListStudent = value; OnPropertyChanged(); } }

        private student _SelectedStudent;
        public student SelectedStudent 
        { 
            get => _SelectedStudent; 
            set 
            { 
                _SelectedStudent = value; 
                OnPropertyChanged();
                if (SelectedStudent != null)
                {
                    LoadData();
                }
            } 
        }
        //ListStudent


        //ImgPath
        private string _selectedImagePath;
        public string SelectedImagePath  { get => _selectedImagePath; set { _selectedImagePath = value; OnPropertyChanged(); } }
        //ImgPath


        //User Avatar
        private string _UserAvatar;
        public string UserAvatar { get => _UserAvatar; set { _UserAvatar = value; OnPropertyChanged(); } }
        private string _UserAvatarEdit;
        public string UserAvatarEdit { get => _UserAvatarEdit; set { _UserAvatarEdit = value; OnPropertyChanged(); } }
        //User Avatar


        //Name
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        //Name


        //CitizenIdentification
        private string _CitizenIdentificationEdit;
        public string CitizenIdentificationEdit 
        { 
            get => _CitizenIdentificationEdit; 
            set 
            {
                if (Regex.IsMatch(value, "^[0-9]*$"))
                {
                    _CitizenIdentificationEdit = value;
                    OnPropertyChanged();
                }
            } 
        }
        private string _CitizenIdentification;
        public string CitizenIdentification { get => _CitizenIdentification; set { _CitizenIdentification = value; OnPropertyChanged(); } }
        //CitizenIdentification


        //Phone
        private string _PhoneEdit;
        public string PhoneEdit 
        {
            get => _PhoneEdit; 
            set
            {
                if (Regex.IsMatch(value, "^[0-9]*$"))
                {
                    _PhoneEdit = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        //Phone


        //Nation
        private string _NationEdit;
        public string NationEdit { get => _NationEdit; set { _NationEdit = value; OnPropertyChanged(); } }
        private string _Nation;
        public string Nation { get => _Nation; set { _Nation = value; OnPropertyChanged(); } }
        //Nation


        //Emty
        private string _IsList;
        public string IsList { get => _IsList; set { _IsList = value; OnPropertyChanged(); } }
        private string _IsEmpty;
        public string IsEmpty { get => _IsEmpty; set { _IsEmpty = value; OnPropertyChanged(); } }
        //Emty


        //Address
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _AddressEdit;
        public string AddressEdit { get => _AddressEdit; set { _AddressEdit = value; OnPropertyChanged(); } }
        //Address


        //DateOfBirth
        private DateTime _DateOfBirth;
        public DateTime DateOfBirth { get => _DateOfBirth; set { _DateOfBirth = value; OnPropertyChanged(); } }

        private DateTime _DateOfBirthEdit = DateTime.Now;
        public DateTime DateOfBirthEdit { get => _DateOfBirthEdit; set { _DateOfBirthEdit = value; OnPropertyChanged(); } }
        //DateOfBirth


        //Sex
        private string _Sex;
        public string Sex { get => _Sex; set { _Sex = value; OnPropertyChanged(); } }
        private ObservableCollection<Sex> _SexList;
        public ObservableCollection<Sex> SexList { get => _SexList; set { _SexList = value; OnPropertyChanged(); } }

        private Sex _SelectedSex;
        public Sex SelectedSex { get => _SelectedSex; set { _SelectedSex = value; OnPropertyChanged(); } }
        //Sex


        //Password
        private string _OldPassword;
        public string OldPassword { get => _OldPassword; set { _OldPassword = value; OnPropertyChanged(); } }
        public ICommand OldPasswordChangedCommand { get; set; }
        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }
        public ICommand NewPasswordChangedCommand { get; set; }
        private string _ReNewPassword;
        public string ReNewPassword { get => _ReNewPassword; set { _ReNewPassword = value; OnPropertyChanged(); } }
        public ICommand ReNewPasswordChangedCommand { get; set; }
        //Password


        //Is Teacher
        private string _IsTeacher = "Collapsed";
        public string IsTeacher { get => _IsTeacher; set { _IsTeacher = value; OnPropertyChanged(); } }
        //Is Teacher


        public ICommand EditInfo { get; set; }
        public ICommand Salary { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand UploadAvatarCommand { get; set; }
        public ICommand EditPassWindow { get; set; }
        public ICommand SavePassCommand { get; set; }


        public MainUserViewModel()
        {
            string defaultPath = "/Images/User/default-avatar-image.png";
            SexList = new ObservableCollection<Sex>
            {
                new Sex { sexID = 1, sexName = "Nam" },
                new Sex { sexID = 2, sexName = "Nữ" },
                new Sex { sexID = 0, sexName = "Khác" }
            };


            string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            appDirectory = appDirectory.Replace("\\bin\\Debug", "");

            var studentProp = DataProvider.Ins.DB.students.Where(x => x.userId == CurrentUser.UserID).SingleOrDefault();
            var teacherProp = DataProvider.Ins.DB.teachers.Where(x => x.userId == CurrentUser.UserID).SingleOrDefault();

            if (CurrentUser.UserRole == 2)
            {
                LoadAvatar(appDirectory + studentProp.avatar);
                Name = studentProp.name;
                Address = studentProp.address;
                DateOfBirth = studentProp.dateOfBirth;
                Sex = SexList.Where(x => x.sexID == studentProp.sex).FirstOrDefault().sexName;
                LoadData();
            }
            else if (CurrentUser.UserRole == 4)
            {
                IsTeacher = "Visible";
                LoadAvatar(appDirectory + teacherProp.avatar);
                Name = teacherProp.name;
                DateOfBirth = teacherProp.dateOfBirth;
                Sex = SexList.Where(x => x.sexID == teacherProp.sex).FirstOrDefault().sexName;
                CitizenIdentification = teacherProp.citizenIdentification;
                Phone = teacherProp.phone;
                Nation = teacherProp.name;
                LoadData();
            }
            else if (CurrentUser.UserRole == 3)
            {
                var parentInfo = DataProvider.Ins.DB.parents.Where(x => x.usersId == CurrentUser.UserID).FirstOrDefault();
                if (parentInfo != null)
                {
                    ListStudent = new ObservableCollection<student>(DataProvider.Ins.DB.students.Where(x => x.parents.FirstOrDefault().id == parentInfo.id));
                }
                LoadAvatar(defaultPath);
            }
            else
            {
                LoadAvatar(defaultPath);
            }

            if (ClassList == null || ClassList.Count() == 0)
            {
                IsEmpty = "Visible";
                IsList = "Collapsed";
            }
            else
            {
                IsEmpty = "Collapsed";
                IsList = "Visible";
            }

            OldPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { OldPassword = p.Password; });
            NewPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { NewPassword = p.Password; });
            ReNewPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { ReNewPassword = p.Password; });

            var checkUserProp = DataProvider.Ins.DB.users.Where(x => x.id == CurrentUser.UserID).FirstOrDefault();


            UploadAvatarCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UploadAvatar(checkUserProp.username); });


            EditInfo = new RelayCommand<object>((p) => { return true; }, (p) => {
                if(CurrentUser.UserRole == 2)
                {
                    StudentEditWindow studentEditWindow = new StudentEditWindow();
                    studentEditWindow.Show();
                }else if(CurrentUser.UserRole == 4)
                {
                    TeacherEditWindow teacherEditWindow = new TeacherEditWindow();
                    teacherEditWindow.Show();
                }
            });

            EditPassWindow = new RelayCommand<object>((p) => { return true; }, (p) => {
                EditPassWindow editPassWindow = new EditPassWindow();
                editPassWindow.ShowDialog();
            });

            Salary = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });

            SavePassCommand = new RelayCommand<object>((p) => { return true; },
                (p) => {
                    if (string.IsNullOrEmpty(OldPassword)) MessageBox.Show("Vui lòng nhập mật khẩu cũ!");
                    if (string.IsNullOrEmpty(NewPassword)) MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                    if (NewPassword != ReNewPassword) MessageBox.Show("Mật khẩu mới không khớp. Vui lòng nhập lại!");
                    else
                    {
                        var userProp = DataProvider.Ins.DB.users.Where(x => x.id == CurrentUser.UserID).SingleOrDefault();
                        userProp.password = XString.MD5Hash(XString.Base64Encode(NewPassword));
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Lưu thành công!");
                    }
                });

            SaveCommand = new RelayCommand<object>((p) => { return true;  }, 
                (p) => {
                    if (CurrentUser.UserRole == 2)
                    {
                        if (SelectedSex == null) SelectedSex = SexList.FirstOrDefault(s => s.sexID == studentProp.sex);
                        if (string.IsNullOrEmpty(AddressEdit)) AddressEdit = studentProp.address;
                        if (string.IsNullOrEmpty(UserAvatarEdit)) UserAvatarEdit = studentProp.avatar;
                        studentProp.address = AddressEdit;
                        studentProp.dateOfBirth = DateOfBirthEdit;
                        studentProp.sex = SelectedSex.sexID;
                        studentProp.avatar = UserAvatarEdit;
                        studentProp.updatedAt = DateTime.Now;
                        studentProp.updatedBy = CurrentUser.UserID;
                        DataProvider.Ins.DB.SaveChanges();

                        MessageBox.Show("Lưu thành công!");

                        LoadAvatar(appDirectory +  studentProp.avatar);
                        AddressEdit = "";
                        DateOfBirthEdit = DateTime.Now;
                        SelectedSex = null;
                        UserAvatarEdit = "";
                    }else if (CurrentUser.UserRole == 4)
                    {
                        if (SelectedSex == null) SelectedSex = SexList.FirstOrDefault(s => s.sexID == teacherProp.sex);
                        if (string.IsNullOrEmpty(CitizenIdentificationEdit)) CitizenIdentificationEdit = teacherProp.citizenIdentification;
                        if (string.IsNullOrEmpty(PhoneEdit)) PhoneEdit = teacherProp.phone;
                        if (string.IsNullOrEmpty(NationEdit)) NationEdit = teacherProp.nation;
                        if (string.IsNullOrEmpty(UserAvatarEdit)) UserAvatarEdit = teacherProp.avatar;
                        teacherProp.citizenIdentification = CitizenIdentificationEdit;
                        teacherProp.phone = PhoneEdit;
                        teacherProp.nation = NationEdit;
                        teacherProp.dateOfBirth = DateOfBirthEdit;
                        teacherProp.sex = SelectedSex.sexID;
                        teacherProp.avatar = UserAvatarEdit;
                        teacherProp.updatedAt = DateTime.Now;
                        teacherProp.updatedBy = CurrentUser.UserID;
                        DataProvider.Ins.DB.SaveChanges();

                        MessageBox.Show("Lưu thành công!");

                        LoadAvatar(appDirectory + teacherProp.avatar);
                        CitizenIdentificationEdit = "";
                        NationEdit = "";
                        PhoneEdit = "";
                        DateOfBirthEdit = DateTime.Now;
                        SelectedSex = null;
                        UserAvatarEdit = "";
                    }
            });

        }
        private void UploadAvatar(string slug)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName.Length != 0)
                {
                    string imgName = slug + Path.GetExtension(openFileDialog.FileName);

                    // Lấy đường dẫn thư mục gốc của ứng dụng (thư mục chứa file exe)
                    string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    appDirectory = appDirectory.Replace("\\bin\\Debug", "");

                    // Tạo đường dẫn đến thư mục Images/User nằm ngoài thư mục bin/Debug
                    string destinationFolder = Path.Combine(appDirectory, "Images\\User");

                    // Tạo đường dẫn đầy đủ đến thư mục đích nằm ngoài thư mục bin/Debug
                    string destinationPath = Path.Combine(destinationFolder, imgName);

                    try
                    {
                        // Kiểm tra xem thư mục đích có tồn tại chưa, nếu chưa thì tạo mới
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }

                        File.Copy(openFileDialog.FileName, destinationPath, true);

                        UserAvatarEdit = destinationPath.Replace(appDirectory, "");
                    }
                    catch (Exception ex)
                    {
                        // Xử lý nếu có lỗi khi sao chép hoặc lưu vào CSDL
                        MessageBox.Show($"Error uploading avatar: {ex.Message}");
                    }




                }
            }

        }

        public void LoadData()
        {
            if (CurrentUser.UserRole == 4)
            {
                ClassList = new ObservableCollection<@class>(DataProvider.Ins.DB.classes.Where(x => x.teacher_class.FirstOrDefault().teacher.userId == CurrentUser.UserID));
            }
            else if (CurrentUser.UserRole == 2)
            {
                ClassList = new ObservableCollection<@class>(DataProvider.Ins.DB.classes.Where(x => x.students_classes.FirstOrDefault().student.userId == CurrentUser.UserID));
            }
            else
            {
                if (SelectedStudent != null)
                    ClassList = new ObservableCollection<@class>(DataProvider.Ins.DB.classes.Where(x => x.students_classes.FirstOrDefault().studentId == SelectedStudent.id));
            }
            if (ClassList == null || ClassList.Count() == 0)
            {
                IsEmpty = "Visible";
                IsList = "Collapsed";
            }
            else
            {
                IsEmpty = "Collapsed";
                IsList = "Visible";
            }
        }

        private void LoadAvatar(string path)
        {
            UserAvatar = path;
        }

    }
}
