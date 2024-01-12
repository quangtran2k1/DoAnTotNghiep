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
    class StudentViewModel :BaseViewModel
    {
        //List
        private ObservableCollection<student> _List;
        public ObservableCollection<student> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List


        //Selected Item
        private student _SelectedItem;
        public student SelectedItem
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


        //ListUser
        private ObservableCollection<user> _ListUserAccount;
        public ObservableCollection<user> ListUserAccount { get => _ListUserAccount; set { _ListUserAccount = value; OnPropertyChanged(); } }

        private user _SelectedUserAccount;
        public user SelectedUserAccount { get => _SelectedUserAccount; set { _SelectedUserAccount = value; OnPropertyChanged(); } }
        //ListUser


        //Add Command
        public ICommand AddCommand { get; set; }
        //Add Command


        //Edit Command
        public ICommand EditCommand { get; set; }
        //Edit Command


        public StudentViewModel()
        {
            List = new ObservableCollection<student>(DataProvider.Ins.DB.students);
            LoadData();

            AddCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(Name) || SelectedUserAccount == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.students.Where(x => x.userId == SelectedUserAccount.id);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var studentProp = new student()
                    {
                        name = Name,
                        createdAt = DateTime.Now,
                        createdBy = CurrentUser.UserID,
                        updatedAt = DateTime.Now,
                        updatedBy = CurrentUser.UserID,
                        dateOfBirth = DateTime.Now,
                        sex = 0,
                        userId = SelectedUserAccount.id,
                        address = "<Trống>",
                        avatar = "/Images/User/default-avatar-image.png",
                        status = 1
                    };
                    DataProvider.Ins.DB.students.Add(studentProp);
                    DataProvider.Ins.DB.SaveChanges();

                    List.Add(studentProp);

                    MessageBox.Show("Thêm thành công!");

                    Name = "";
                    SelectedUserAccount = null;
                });

            EditCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(Name) || SelectedUserAccount == null || SelectedItem == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.students.Where(x => x.id != SelectedItem.id && x.userId == SelectedUserAccount.id);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var studentProp = DataProvider.Ins.DB.students.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                    studentProp.name = Name;
                    studentProp.updatedAt = DateTime.Now;
                    studentProp.updatedBy = CurrentUser.UserID;
                    studentProp.userId = SelectedUserAccount.id;
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Sửa thành công!");

                    Name = "";
                    SelectedUserAccount = null;
                });
        }

        public void LoadData()
        {
            ListUserAccount = new ObservableCollection<user>(DataProvider.Ins.DB.users.Where(x => x.role.id == 2));
        }
    }
}
