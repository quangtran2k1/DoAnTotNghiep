using DoAnTotNghiep.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DoAnTotNghiep.ViewModel
{
    class ClassViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<@class> _List;
        public ObservableCollection<@class> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List


        //TeacherList
        private ObservableCollection<teacher_class> _TeacherList;
        public ObservableCollection<teacher_class> TeacherList { get => _TeacherList; set { _TeacherList = value; OnPropertyChanged(); } }
        //TeacherList

        //StudentList
        private ObservableCollection<students_classes> _StudentList;
        public ObservableCollection<students_classes> StudentList { get => _StudentList; set { _StudentList = value; OnPropertyChanged(); } }
        //StudentList

        //TeacherSearchResult
        private ObservableCollection<teacher> _TeacherSearchResult;
        public ObservableCollection<teacher> TeacherSearchResult { get => _TeacherSearchResult; set { _TeacherSearchResult = value; OnPropertyChanged(); } }
        private teacher _SelectedTeacher;
        public teacher SelectedTeacher { get => _SelectedTeacher; set { _SelectedTeacher = value; OnPropertyChanged(); } }
        //TeacherSearchResult

        //StudentSearchResult
        private ObservableCollection<student> _StudentSearchResult;
        public ObservableCollection<student> StudentSearchResult { get => _StudentSearchResult; set { _StudentSearchResult = value; OnPropertyChanged(); } }
        private student _SelectedStudent;
        public student SelectedStudent { get => _SelectedStudent; set { _SelectedStudent = value; OnPropertyChanged(); } }
        //StudentSearchResult

        //Teacher Note
        private string _NoteTeacher;
        public string NoteTeacher { get => _NoteTeacher; set { _NoteTeacher = value; OnPropertyChanged(); } }
        //Teacher Note

        //Student Note
        private string _NoteStudent;
        public string NoteStudent { get => _NoteStudent; set { _NoteStudent = value; OnPropertyChanged(); } }
        //Student Note


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
                    LoadData();
                }
            }
        }
        //Selected Item


        //Selected Item Teacher Class
        private teacher_class _SelectedItemTC;
        public teacher_class SelectedItemTC
        {
            get => _SelectedItemTC;
            set
            {
                _SelectedItemTC = value;
                OnPropertyChanged();
                if (SelectedItemTC != null)
                {
                    teacher selectedTeacher = DataProvider.Ins.DB.teachers.FirstOrDefault(t => t.id == SelectedItemTC.teacherId);
                    SelectedTeacher = selectedTeacher;
                    NoteTeacher = SelectedItemTC.note;
                }
            }
        }
        //Selected Item Teacher Class


        //Selected Item Student Class
        private students_classes _SelectedItemSC;
        public students_classes SelectedItemSC
        {
            get => _SelectedItemSC;
            set
            {
                _SelectedItemSC = value;
                OnPropertyChanged();
                if (SelectedItemSC != null)
                {
                    student selectedStudent = DataProvider.Ins.DB.students.FirstOrDefault(t => t.id == SelectedItemSC.studentId);
                    SelectedStudent = selectedStudent;
                    NoteStudent = SelectedItemSC.note;
                }
            }
        }
        //Selected Item Student Class


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

        //Delete Command
        public ICommand DeleteCommand { get; set; }
        //Delete Command

        //Detail Command
        public ICommand DetailCommand { get; set; }
        //Detail Command

        //Add Teacher Command
        public ICommand AddTeacherCommand { get; set; }
        //Add Teacher Command

        //Delete Teacher Command
        public ICommand DeleteTeacherCommand { get; set; }
        //Delete Teacher Command

        //Add Student Command
        public ICommand AddStudentCommand { get; set; }
        //Add Student Command

        //Delete Student Command
        public ICommand DeleteStudentCommand { get; set; }
        //Delete Student Command


        public ClassViewModel()
        {
            NoteTeacher = "";
            NoteStudent = "";
            StatusList = new ObservableCollection<Status>
            {
                new Status { StatusID = 1, StatusName = "Hoạt động" },
                new Status { StatusID = 2, StatusName = "Ngừng hoạt động" }
            };

            List = new ObservableCollection<@class>(DataProvider.Ins.DB.classes);

            LoadData();

            AddCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(ClassName) || SelectedStatus == null || SelectedSemester == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.classes.Where(x => x.class1 == ClassName && x.semesterId == SelectedSemester.id);
                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
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

                    MessageBox.Show("Thêm thành công!");

                    ClassName = "";
                    StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
                    SelectedSemester = null;
                    SelectedStatus = null;
                });

            EditCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (string.IsNullOrEmpty(ClassName) || SelectedStatus == null || SelectedSemester == null || SelectedItem == null)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var classProp = DataProvider.Ins.DB.classes.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                    classProp.class1 = ClassName;
                    classProp.updatedAt = DateTime.Now;
                    classProp.updatedBy = CurrentUser.UserID;
                    classProp.startTime = new TimeSpan(StartTime.Hour, StartTime.Minute, StartTime.Second);
                    classProp.endTime = new TimeSpan(EndTime.Hour, EndTime.Minute, EndTime.Second);
                    classProp.semesterId = SelectedSemester.id;
                    classProp.status = SelectedStatus.StatusID;
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Sửa thành công!");

                    ClassName = "";
                    StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
                    SelectedSemester = null;
                    SelectedStatus = null;
                });
            DeleteCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItem == null)
                    {
                        return true;
                    }
                    var displayList = DataProvider.Ins.DB.classes.Where(x => x.id == SelectedItem.id && x.status == 0);
                    if (displayList.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    if (SelectedItem != null && !string.IsNullOrEmpty(ClassName) && SelectedStatus != null && SelectedSemester != null)
                    {
                        var classProp = DataProvider.Ins.DB.classes.Where(x => x.id == SelectedItem.id).SingleOrDefault();
                        classProp.status = 0;
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                    }

                    ClassName = "";
                    StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
                    SelectedSemester = null;
                    SelectedStatus = null;
                });
            DetailCommand = new RelayCommand<object>(
                (p) => {
                    if (SelectedSemester == null)
                        return false;
                    var check = DataProvider.Ins.DB.classes.Where(x => x.id == SelectedItem.id && x.status == 0);
                    if (check.Count() != 0)
                        return false;
                    return true; 
                }, 
                (p) => {
                    DetailWindow detailWindow = new DetailWindow();
                    detailWindow.ShowDialog();
                });


            AddTeacherCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedTeacher == null)
                        return false;

                    var check = DataProvider.Ins.DB.teacher_class.Where(x => x.teacherId == SelectedTeacher.id && x.classesId == SelectedItem.id);
                    if (check.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var teacherProp = new teacher_class()
                    {
                        createdAt = DateTime.Now,
                        createdBy = CurrentUser.UserID,
                        updateAt = DateTime.Now,
                        updatedBy = CurrentUser.UserID,
                        note = NoteTeacher,
                        teacherId = SelectedTeacher.id,
                        classesId = SelectedItem.id,
                        status = 1
                    };
                    DataProvider.Ins.DB.teacher_class.Add(teacherProp);
                    DataProvider.Ins.DB.SaveChanges();

                    TeacherList.Add(teacherProp);

                    MessageBox.Show("Thêm thành công!");

                    SelectedTeacher = null;
                    NoteTeacher = null;
                    TeacherSearchResult = new ObservableCollection<teacher>(DataProvider.Ins.DB.teachers);
                });

            DeleteTeacherCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItemTC == null)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var teacherProp = DataProvider.Ins.DB.teacher_class.Where(x => x.id == SelectedItemTC.id).SingleOrDefault();
                    if (teacherProp != null) DataProvider.Ins.DB.teacher_class.Remove(teacherProp);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    TeacherList.Remove(teacherProp);

                    SelectedTeacher = null;
                    NoteTeacher = null;
                    TeacherSearchResult = new ObservableCollection<teacher>(DataProvider.Ins.DB.teachers);
                });


            AddStudentCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedStudent == null)
                        return false;

                    var check = DataProvider.Ins.DB.students_classes.Where(x => x.studentId == SelectedStudent.id && x.classId == SelectedItem.id);
                    if (check.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var studentProp = new students_classes()
                    {
                        createdAt = DateTime.Now,
                        createdBy = CurrentUser.UserID,
                        updateAt = DateTime.Now,
                        updatedBy = CurrentUser.UserID,
                        note = NoteStudent,
                        studentId = SelectedStudent.id,
                        classId = SelectedItem.id,
                        status = 1
                    };
                    DataProvider.Ins.DB.students_classes.Add(studentProp);
                    DataProvider.Ins.DB.SaveChanges();

                    StudentList.Add(studentProp);

                    MessageBox.Show("Thêm thành công!");

                    SelectedStudent = null;
                    NoteStudent = null;
                    StudentSearchResult = new ObservableCollection<student>(DataProvider.Ins.DB.students);
                });

            DeleteStudentCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItemSC == null)
                        return false;

                    return true;
                },
                (p) =>
                {
                    var studentProp = DataProvider.Ins.DB.students_classes.Where(x => x.id == SelectedItemSC.id).SingleOrDefault();
                    if (studentProp != null) DataProvider.Ins.DB.students_classes.Remove(studentProp);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    StudentList.Remove(studentProp);


                    SelectedStudent = null;
                    NoteStudent = null;
                    StudentSearchResult = new ObservableCollection<student>(DataProvider.Ins.DB.students);
                });
        }

        public void LoadData()
        {
            if (SelectedItem != null)
            {
                TeacherList = new ObservableCollection<teacher_class>(DataProvider.Ins.DB.teacher_class.Where(x => x.classesId == SelectedItem.id));
                StudentList = new ObservableCollection<students_classes>(DataProvider.Ins.DB.students_classes.Where(x => x.classId == SelectedItem.id));
            }

            TeacherSearchResult = new ObservableCollection<teacher>(DataProvider.Ins.DB.teachers);
            StudentSearchResult = new ObservableCollection<student>(DataProvider.Ins.DB.students);

            ListSemester = new ObservableCollection<semester>(DataProvider.Ins.DB.semesters);
        }

    }
}
