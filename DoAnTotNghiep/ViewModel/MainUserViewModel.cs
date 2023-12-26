using DoAnTotNghiep.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DoAnTotNghiep.ViewModel
{
    class MainUserViewModel : BaseViewModel
    {
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


        public ICommand EditInfo { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand UploadAvatarCommand { get; set; }


        public MainUserViewModel()
        {
            SexList = new ObservableCollection<Sex>
            {
                new Sex { sexID = 1, sexName = "Nam" },
                new Sex { sexID = 2, sexName = "Nữ" },
                new Sex { sexID = 3, sexName = "Khác" }
            };


            var studentProp = DataProvider.Ins.DB.students.Where(x => x.id == CurrentUser.UserID).SingleOrDefault();

            if (CurrentUser.UserRole == 2)
            {
                UserAvatar = studentProp.avatar;
                Name = studentProp.name;
                Address = studentProp.address;
                DateOfBirth = studentProp.dateOfBirth;
                Sex = SexList.Where(x => x.sexID == studentProp.sex).FirstOrDefault().sexName;
            }
            else if (CurrentUser.UserRole == 4)
            {
                UserAvatar = DataProvider.Ins.DB.teachers.Where(x => x.id == CurrentUser.UserID).FirstOrDefault().avatar;
            }
            else
            {
                UserAvatar = "/Images/User/default-avatar-image.png";
            }

            //Upload Img
            UploadAvatarCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UploadAvatar(); });
            //Upload Img


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

            if (string.IsNullOrEmpty(AddressEdit)) AddressEdit = studentProp.address;
            if (string.IsNullOrEmpty(UserAvatarEdit)) UserAvatarEdit = studentProp.avatar;
            if (SelectedSex == null) SelectedSex = SexList.FirstOrDefault(s => s.sexID == studentProp.sex);

            SaveCommand = new RelayCommand<object>((p) => { return true;  }, 
                (p) => {
                    studentProp.address = AddressEdit;
                    studentProp.dateOfBirth = DateOfBirthEdit;
                    studentProp.sex = SelectedSex.sexID;
                    studentProp.avatar = UserAvatarEdit;
                    studentProp.updatedAt = DateTime.Now;
                    studentProp.updatedBy = CurrentUser.UserID;
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Lưu thành công!");

                    AddressEdit = "";
                    DateOfBirthEdit = DateTime.Now;
                    SelectedSex = null;
                    UserAvatarEdit = "";
            });

        }
        private void UploadAvatar()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                // Lấy đường dẫn của tệp tin ảnh
                string imagePath = openFileDialog.FileName;

                // Tạo một URI từ đường dẫn
                Uri imageUri = new Uri(imagePath);

                // Lấy tên tệp tin để sử dụng khi sao chép vào thư mục
                string fileName = Path.GetFileName(imagePath);

                // Đường dẫn đến thư mục Images/User trong dự án
                string destinationFolder = "Images/User";

                // Tạo đường dẫn đến thư mục đích
                string destinationPath = Path.Combine(destinationFolder, fileName);

                try
                {
                    // Sao chép tệp tin ảnh vào thư mục đích
                    File.Copy(imagePath, destinationPath, true);

                    // Gán URI của ảnh cho UserAvatarEdit
                    UserAvatarEdit = new BitmapImage(imageUri).ToString();
                }
                catch (Exception ex)
                {
                    // Xử lý nếu có lỗi khi sao chép
                    MessageBox.Show($"Error uploading avatar: {ex.Message}");
                }
            }
        }


    }
}
