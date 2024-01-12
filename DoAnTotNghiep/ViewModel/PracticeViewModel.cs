using DoAnTotNghiep.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep.ViewModel
{
    class PracticeViewModel : BaseViewModel
    {
        //List
        private ObservableCollection<exercise> _List;
        public ObservableCollection<exercise> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        //List
        public PracticeViewModel()
        {
            List = new ObservableCollection<exercise>(DataProvider.Ins.DB.exercises);
        }
    }
}
