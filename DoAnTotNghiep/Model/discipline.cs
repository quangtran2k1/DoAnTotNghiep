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
    using System;
    using System.Collections.Generic;
    
    public partial class discipline
    {
        public int id { get; set; }
        public System.DateTime createdAt { get; set; }
        public Nullable<System.DateTime> updatedAt { get; set; }
        public int createdBy { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public string reason { get; set; }
        public int fine { get; set; }
        public int teacherId { get; set; }
    
        public virtual teacher teacher { get; set; }
    }
}
