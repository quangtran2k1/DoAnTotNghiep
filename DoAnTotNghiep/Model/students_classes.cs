//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnTotNghiep.Model
{
    using DoAnTotNghiep.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class students_classes : BaseViewModel
    {
        public int id { get; set; }
        public System.DateTime createdAt { get; set; }
        private Nullable<System.DateTime> _updateAt;
        public Nullable<System.DateTime> updateAt { get => _updateAt; set { _updateAt = value; OnPropertyChanged(); } }
        public int createdBy { get; set; }
        private Nullable<int> _updatedBy;
        public Nullable<int> updatedBy { get => _updatedBy; set { _updatedBy = value; OnPropertyChanged(); } }
        private string _note;
        public string note { get => _note; set { _note = value; OnPropertyChanged(); } }
        private byte _status;
        public byte status { get => _status; set { _status = value; OnPropertyChanged(); } }
        private int _studentId;
        public int studentId { get => _studentId; set { _studentId = value; OnPropertyChanged(); } }
        public int classId { get; set; }
    
        public virtual @class @class { get; set; }
        public virtual student student { get; set; }
    }
}
