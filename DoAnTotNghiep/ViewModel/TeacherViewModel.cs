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
    class TeacherViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<teacher> _List;
        public ObservableCollection<teacher> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List


        //Selected Item
        private teacher _SelectedItem;
        public teacher SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Name = SelectedItem.name;
                    user selectedUser = DataProvider.Ins.DB.users.Where(x => x.id == SelectedItem.userId).FirstOrDefault();
                    SelectedUserAccount = selectedUser;
                }
            }
        }
        //Selected Item


        //Name
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        //Name


        //Student
        private ObservableCollection<user> _ListUserAccount;
        public ObservableCollection<user> ListUserAccount { get => _ListUserAccount; set { _ListUserAccount = value; OnPropertyChanged(); } }

        private user _SelectedUserAccount;
        public user SelectedUserAccount { get => _SelectedUserAccount; set { _SelectedUserAccount = value; OnPropertyChanged(); } }
        //Student


        //Add Command
        public ICommand AddCommand { get; set; }
        //Add Command


        //Edit Command
        public ICommand EditCommand { get; set; }
        //Edit Command
        public TeacherViewModel()
        {
            List = new ObservableCollection<teacher>(DataProvider.Ins.DB.teachers);

            ListUserAccount = new ObservableCollection<user>(DataProvider.Ins.DB.users.Where(x => x.role.id == 4));

            AddCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(Name) || SelectedUserAccount == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.teachers.Where(x => x.userId == SelectedUserAccount.id);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var teacherProp = new teacher()
                    {
                        name = Name,
                        createdAt = DateTime.Now,
                        createdBy = CurrentUser.UserID,
                        updatedAt = DateTime.Now,
                        updatedBy = CurrentUser.UserID,
                        dateOfBirth = DateTime.Now,
                        sex = 0,
                        phone = "<Trống>",
                        citizenIdentification = "<Trống>",
                        userId = SelectedUserAccount.id,
                        nation = "<Trống>",
                        avatar = "/Images/User/default-avatar-image.png",
                        status = 1
                    };
                    DataProvider.Ins.DB.teachers.Add(teacherProp);
                    DataProvider.Ins.DB.SaveChanges();

                    List.Add(teacherProp);

                    MessageBox.Show("Thêm thành công!");

                    Name = "";
                    SelectedUserAccount = null;
                });

            EditCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(Name) || SelectedUserAccount == null || SelectedItem == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.teachers.Where(x => x.id == SelectedItem.id && x.userId == SelectedUserAccount.id);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var teacherProp = DataProvider.Ins.DB.teachers.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                    teacherProp.name = Name;
                    teacherProp.updatedAt = DateTime.Now;
                    teacherProp.updatedBy = CurrentUser.UserID;
                    teacherProp.userId = SelectedUserAccount.id;
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Sửa thành công!");

                    Name = "";
                    SelectedUserAccount = null;
                });
        }
    }
}
