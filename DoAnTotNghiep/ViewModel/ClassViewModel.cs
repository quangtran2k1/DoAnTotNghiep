using DoAnTotNghiep.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DoAnTotNghiep.ViewModel
{
    class ClassViewModel : BaseViewModel
    {
        //List Class
        private ObservableCollection<@class> _List;
        public ObservableCollection<@class> List{ get => _List; set { _List = value; OnPropertyChanged(); } }
        //List Class


        //Selected Item
        private @class _SelectedItem;
        public @class SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    ClassName = SelectedItem.class1;
                    StartTime = new DateTime(1, 1, 1, SelectedItem.startTime.Hours, SelectedItem.startTime.Minutes, 0);
                    EndTime = new DateTime(1, 1, 1, SelectedItem.endTime.Hours, SelectedItem.endTime.Minutes, 0);
                    semester selectedSemester = DataProvider.Ins.DB.semesters.FirstOrDefault(s => s.id == SelectedItem.semesterId);
                    SelectedSemester = selectedSemester;
                    SelectedStatus = StatusList.FirstOrDefault(s => s.StatusID == SelectedItem.status);
                }
            }
        }
        //Selected Item


        //ClassName
        private string _ClassName;
        public string ClassName { get => _ClassName; set { _ClassName = value; OnPropertyChanged(); } }
        //ClassName


        //Start Time
        private int _StartHour;
        private int _StartMinute;
        public int StartHour { get => _StartHour; set { _StartHour = value; OnPropertyChanged(); } }
        public int StartMinute { get => _StartMinute; set { _StartMinute = value; OnPropertyChanged(); } }
        private DateTime _StartTime;
        public DateTime StartTime
        {
            get => _StartTime;
            set
            {
                _StartTime = value;
                StartHour = value.Hour;
                StartMinute = value.Minute;
                OnPropertyChanged();
            }
        }
        //Start Time


        //EndTime
        private int _EndHour;
        private int _EndMinute;
        public int EndHour { get => _EndHour; set { _EndHour = value; OnPropertyChanged(); } }
        public int EndMinute { get => _EndMinute; set { _EndMinute = value; OnPropertyChanged(); } }
        private DateTime _EndTime;
        public DateTime EndTime
        {
            get => _EndTime;
            set
            {
                _EndTime = value;
                EndHour = value.Hour;
                EndMinute = value.Minute;
                OnPropertyChanged();
            }
        }
        //EndTime


        //Semester
        private ObservableCollection<semester> _ListSemester;
        public ObservableCollection<semester> ListSemester { get => _ListSemester; set { _ListSemester = value; OnPropertyChanged(); } }

        private semester _SelectedSemester;
        public semester SelectedSemester { get => _SelectedSemester; set { _SelectedSemester = value; OnPropertyChanged(); } }
        //Semester


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


        public ClassViewModel()
        {
            StatusList = new ObservableCollection<Status>
            {
                new Status { StatusID = 1, StatusName = "Hoạt động" },
                new Status { StatusID = 2, StatusName = "Ngừng hoạt động" }
            };

            List = new ObservableCollection<@class>(DataProvider.Ins.DB.classes);
            ListSemester = new ObservableCollection<semester>(DataProvider.Ins.DB.semesters);

            AddCommand = new RelayCommand<object>(
                (p) => {
                    if (string.IsNullOrEmpty(ClassName) || SelectedStatus == null || SelectedSemester == null) 
                        return false;

                    var displayList = DataProvider.Ins.DB.classes.Where(x => x.class1 == ClassName && x.semesterId == SelectedSemester.id);
                    if (displayList == null || displayList.Count() != 0) 
                        return false;

                    return true;
                }, 
                (p) => {
                    var classProp = new @class()
                    {
                        class1 = ClassName,
                        createdAt = DateTime.Now,
                        createdBy = CurrentUser.UserID,
                        updatedAt = DateTime.Now,
                        updatedBy = CurrentUser.UserID,
                        startTime = new TimeSpan(StartTime.Hour, StartTime.Minute, StartTime.Second),
                        endTime = new TimeSpan(EndTime.Hour, EndTime.Minute, EndTime.Second),
                        semesterId = SelectedSemester.id,
                        status = SelectedStatus.StatusID
                    };
                DataProvider.Ins.DB.classes.Add(classProp);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(classProp);
            });

            EditCommand = new RelayCommand<object>(
                (p) => {
                    if (string.IsNullOrEmpty(ClassName) || SelectedStatus == null || SelectedSemester == null || SelectedItem == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.classes.Where(x => x.class1 == ClassName && x.semesterId == SelectedSemester.id);
                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) => {
                    var classProp = DataProvider.Ins.DB.classes.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                    classProp.class1 = ClassName;
                    classProp.updatedAt = DateTime.Now;
                    classProp.updatedBy = CurrentUser.UserID;
                    classProp.startTime = new TimeSpan(StartTime.Hour, StartTime.Minute, StartTime.Second);
                    classProp.endTime = new TimeSpan(EndTime.Hour, EndTime.Minute, EndTime.Second);
                    classProp.semesterId = SelectedSemester.id;
                    classProp.status = SelectedStatus.StatusID;
                    DataProvider.Ins.DB.SaveChanges();

                    SelectedItem.class1 = ClassName;
                    SelectedItem.updatedAt = DateTime.Now;
                    SelectedItem.updatedBy = CurrentUser.UserID;
                    SelectedItem.startTime = new TimeSpan(StartTime.Hour, StartTime.Minute, StartTime.Second);
                    SelectedItem.endTime = new TimeSpan(EndTime.Hour, EndTime.Minute, EndTime.Second);
                    SelectedItem.semesterId = SelectedSemester.id;
                    SelectedItem.status = SelectedStatus.StatusID;
                });
        }
    }
}
