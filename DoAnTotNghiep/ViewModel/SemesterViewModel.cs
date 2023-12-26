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
    class SemesterViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<semester> _List;
        public ObservableCollection<semester> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List


        //Selected Item
        private semester _SelectedItem;
        public semester SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Block = SelectedItem.block;
                    StartSemester = SelectedItem.startSemester;
                    EndSemester = SelectedItem.endSemester;
                    SelectedStatus = StatusList.FirstOrDefault(s => s.StatusID == SelectedItem.status);
                }
            }
        }
        //Selected Item


        //Block
        private string _Block;
        public string Block { get => _Block; set { _Block = value; OnPropertyChanged(); } }
        //Block

        //StartSemester
        private DateTime _StartSemester = DateTime.Now;
        public DateTime StartSemester { get => _StartSemester; set { _StartSemester = value; OnPropertyChanged(); } }
        //StartSemester


        //EndSemester
        private DateTime _EndSemester = DateTime.Now;
        public DateTime EndSemester { get => _EndSemester; set { _EndSemester = value; OnPropertyChanged(); } }
        //EndSemester


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


        //Add Command
        public ICommand AddCommand { get; set; }
        //Add Command


        //Edit Command
        public ICommand EditCommand { get; set; }
        //Edit Command

        //Delete Command
        public ICommand DeleteCommand { get; set; }
        //Delete Command


        public SemesterViewModel()
        {
            StatusList = new ObservableCollection<Status>
            {
                new Status { StatusID = 1, StatusName = "Hoạt động" },
                new Status { StatusID = 2, StatusName = "Ngừng hoạt động" }
            };

            List = new ObservableCollection<semester>(DataProvider.Ins.DB.semesters);

            AddCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(Block) || SelectedStatus == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.semesters.Where(x => x.block == Block && x.startSemester == StartSemester && x.endSemester == EndSemester);
                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var semesterProp = new semester()
                    {
                        block = Block,
                        createdAt = DateTime.Now,
                        createdBy = CurrentUser.UserID,
                        updatedAt = DateTime.Now,
                        updatedBy = CurrentUser.UserID,
                        startSemester = StartSemester,
                        endSemester = EndSemester,
                        status = SelectedStatus.StatusID
                    };
                    DataProvider.Ins.DB.semesters.Add(semesterProp);
                    DataProvider.Ins.DB.SaveChanges();

                    List.Add(semesterProp);

                    MessageBox.Show("Thêm thành công!");

                    Block = "";
                    StartSemester = DateTime.Now;
                    EndSemester = DateTime.Now;
                    SelectedStatus = null;
                });

            EditCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(Block) || SelectedStatus == null || SelectedItem == null)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var semesterProp = DataProvider.Ins.DB.semesters.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                    semesterProp.block = Block;
                    semesterProp.updatedAt = DateTime.Now;
                    semesterProp.updatedBy = CurrentUser.UserID;
                    semesterProp.startSemester = StartSemester;
                    semesterProp.endSemester = EndSemester;
                    semesterProp.status = SelectedStatus.StatusID;
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Sửa thành công!");

                    Block = "";
                    StartSemester = DateTime.Now;
                    EndSemester = DateTime.Now;
                    SelectedStatus = null;
                });
            DeleteCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItem == null)
                    {
                        return true;
                    }
                    var displayList = DataProvider.Ins.DB.semesters.Where(x => x.id == SelectedItem.id && x.status == 0);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    if (SelectedItem != null && !string.IsNullOrEmpty(Block) && SelectedStatus != null)
                    {
                        var semesterProp = DataProvider.Ins.DB.semesters.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                        semesterProp.status = 0;
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                    }

                    Block = "";
                    StartSemester = DateTime.Now;
                    EndSemester = DateTime.Now;
                    SelectedStatus = null;
                });
        }
    }
}
