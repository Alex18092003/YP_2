﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YP_2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessNetworks> AccessNetworks { get; set; }
        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<BuildingType> BuildingType { get; set; }
        public virtual DbSet<ContractTypes> ContractTypes { get; set; }
        public virtual DbSet<DescriptionsProblems> DescriptionsProblems { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EquiomentType> EquiomentType { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Highways> Highways { get; set; }
        public virtual DbSet<InformationForEmployees> InformationForEmployees { get; set; }
        public virtual DbSet<Pols> Pols { get; set; }
        public virtual DbSet<ProblemTypes> ProblemTypes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesTypes> ServicesTypes { get; set; }
        public virtual DbSet<ServicesView> ServicesView { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Subscribers> Subscribers { get; set; }
        public virtual DbSet<SubscriberServices> SubscriberServices { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TableEquipment> TableEquipment { get; set; }
    }
}
