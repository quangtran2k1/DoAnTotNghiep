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

    public partial class user : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.parents = new HashSet<parent>();
            this.students = new HashSet<student>();
            this.teachers = new HashSet<teacher>();
        }

        public int id { get; set; }
        private string _username;
        private string _email;
        private byte _status;
        private int _roleId;
        public string username { get => _username; set { _username = value; OnPropertyChanged(); } }
        public string password { get; set; }
        public string email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public byte status { get => _status; set { _status = value; OnPropertyChanged(); } }
        public System.DateTime createdAt { get; set; }
        public Nullable<System.DateTime> updatedAt { get; set; }
        public int roleId { get => _roleId; set { _roleId = value; OnPropertyChanged(); } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<parent> parents { get; set; }
        public virtual role role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student> students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacher> teachers { get; set; }
    }
}
