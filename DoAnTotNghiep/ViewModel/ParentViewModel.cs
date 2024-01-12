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
    class ParentViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<parent> _List;
        public ObservableCollection<parent> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List


        //Selected Item
        private parent _SelectedItem;
        public parent SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DadName = SelectedItem.dadName;
                    MomName = SelectedItem.momName;
                    user selectedUser = DataProvider.Ins.DB.users.Where(x => x.id == SelectedItem.usersId).FirstOrDefault();
                    student selectedStudent = DataProvider.Ins.DB.students.Where(x => x.id == SelectedItem.studentId).FirstOrDefault();
                    SelectedUserAccount = selectedUser;
                    SelectedStudent = selectedStudent;
                }
            }
        }
        //Selected Item


        //Name
        private string _DadName;
        public string DadName { get => _DadName; set { _DadName = value; OnPropertyChanged(); } }
        private string _MomName;
        public string MomName { get => _MomName; set { _MomName = value; OnPropertyChanged(); } }
        //Name


        //ListUser
        private ObservableCollection<user> _ListUserAccount;
        public ObservableCollection<user> ListUserAccount { get => _ListUserAccount; set { _ListUserAccount = value; OnPropertyChanged(); } }

        private user _SelectedUserAccount;
        public user SelectedUserAccount { get => _SelectedUserAccount; set { _SelectedUserAccount = value; OnPropertyChanged(); } }
        //ListUser

        //ListStudent
        private ObservableCollection<student> _ListStudent;
        public ObservableCollection<student> ListStudent { get => _ListStudent; set { _ListStudent = value; OnPropertyChanged(); } }

        private student _SelectedStudent;
        public student SelectedStudent { get => _SelectedStudent; set { _SelectedStudent = value; OnPropertyChanged(); } }
        //ListStudent


        //Add Command
        public ICommand AddCommand { get; set; }
        //Add Command


        //Edit Command
        public ICommand EditCommand { get; set; }
        //Edit Command


        public ParentViewModel()
        {
            List = new ObservableCollection<parent>(DataProvider.Ins.DB.parents);
            LoadData();

            AddCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(DadName) && string.IsNullOrEmpty(MomName) || SelectedUserAccount == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.parents.Where(x => x.usersId == SelectedUserAccount.id);
                    if (displayList.Count() != 0)
                        return false;
                    return true;
                },
                (p) =>
                {
                    if (string.IsNullOrEmpty(DadName)) DadName = "<Trống>";  
                    if (string.IsNullOrEmpty(MomName)) MomName = "<Trống>";
                    var parentProp = new parent()
                    {
                        dadName = DadName,
                        momName = MomName,
                        dadPhone = "<Trống>",
                        momPhone = "<Trống>",
                        createdAt = DateTime.Now,
                        createdBy = CurrentUser.UserID,
                        updatedAt = DateTime.Now,
                        updatedBy = CurrentUser.UserID,
                        studentId = SelectedStudent.id,
                        usersId = SelectedUserAccount.id,
                    };
                    DataProvider.Ins.DB.parents.Add(parentProp);
                    DataProvider.Ins.DB.SaveChanges();

                    List.Add(parentProp);

                    MessageBox.Show("Thêm thành công!");

                    MomName = "";
                    DadName = "";
                    SelectedUserAccount = null;
                    SelectedStudent = null;
                });

            EditCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(DadName) && string.IsNullOrEmpty(MomName) || SelectedUserAccount == null || SelectedStudent == null || SelectedItem == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.parents.Where(x => x.id != SelectedItem.id && x.usersId == SelectedUserAccount.id);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    if (string.IsNullOrEmpty(DadName)) DadName = "<Trống>";
                    if (string.IsNullOrEmpty(MomName)) MomName = "<Trống>";
                    var parentProp = DataProvider.Ins.DB.parents.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                    parentProp.momName = MomName;
                    parentProp.dadName = DadName;
                    parentProp.updatedAt = DateTime.Now;
                    parentProp.updatedBy = CurrentUser.UserID;
                    parentProp.usersId = SelectedUserAccount.id;
                    parentProp.studentId = SelectedStudent.id;
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Sửa thành công!");

                    MomName = "";
                    DadName = "";
                    SelectedUserAccount = null;
                    SelectedStudent = null;
                });
        }

        public void LoadData()
        {
            ListUserAccount = new ObservableCollection<user>(DataProvider.Ins.DB.users.Where(x => x.role.id == 3));
            ListStudent = new ObservableCollection<student>(DataProvider.Ins.DB.students);
        }
    }
}
