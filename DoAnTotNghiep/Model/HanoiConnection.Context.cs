﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HanoiConnectionEntities : DbContext
    {
        public HanoiConnectionEntities()
            : base("name=HanoiConnectionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<@class> classes { get; set; }
        public virtual DbSet<exercise> exercises { get; set; }
        public virtual DbSet<homework_student> homework_student { get; set; }
        public virtual DbSet<parent> parents { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<semester> semesters { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<students_classes> students_classes { get; set; }
        public virtual DbSet<teacher_class> teacher_class { get; set; }
        public virtual DbSet<teacher> teachers { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}