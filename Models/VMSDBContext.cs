using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VMS_API.Models
{
    public partial class VMSDBContext : DbContext
    {
        public VMSDBContext()
        {
        }

        public VMSDBContext(DbContextOptions<VMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiMonitorTb> ApiMonitorTbs { get; set; } = null!;
        public virtual DbSet<BranchTb> BranchTbs { get; set; } = null!;
        public virtual DbSet<CompanyTb> CompanyTbs { get; set; } = null!;
        public virtual DbSet<CourierTb> CourierTbs { get; set; } = null!;
        public virtual DbSet<DbsettingTb> DbsettingTbs { get; set; } = null!;
        public virtual DbSet<DepartmentTb> DepartmentTbs { get; set; } = null!;
        public virtual DbSet<DesignationTb> DesignationTbs { get; set; } = null!;
        public virtual DbSet<DeviceLogsTb> DeviceLogsTbs { get; set; } = null!;
        public virtual DbSet<DevicesTb> DevicesTbs { get; set; } = null!;
        public virtual DbSet<EmployeePunchTb> EmployeePunchTbs { get; set; } = null!;
        public virtual DbSet<EmployeeScheduledVisitTb> EmployeeScheduledVisitTbs { get; set; } = null!;
        public virtual DbSet<MailSettingTb> MailSettingTbs { get; set; } = null!;
        public virtual DbSet<UserTb> UserTbs { get; set; } = null!;
        public virtual DbSet<VisitorEntryTb> VisitorEntryTbs { get; set; } = null!;
        public virtual DbSet<VisitorStatusTb> VisitorStatusTbs { get; set; } = null!;
        public virtual DbSet<VisitorTb> VisitorTbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ASHOK;initial catalog=VMSDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiMonitorTb>(entity =>
            {
                entity.ToTable("ApiMonitorTB");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.Command).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.DeviceSrno)
                    .HasMaxLength(50)
                    .HasColumnName("DeviceSRNO");

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.Page).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");
            });

            modelBuilder.Entity<BranchTb>(entity =>
            {
                entity.ToTable("BranchTB");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ContactPerson).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);
            });

            modelBuilder.Entity<CompanyTb>(entity =>
            {
                entity.ToTable("CompanyTB");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ContactPerson).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(10);
            });

            modelBuilder.Entity<CourierTb>(entity =>
            {
                entity.ToTable("CourierTB");

                entity.Property(e => e.CourierCompany).HasMaxLength(50);

                entity.Property(e => e.CourierNo).HasMaxLength(50);

                entity.Property(e => e.CourierPersonName).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EmployeeName).HasMaxLength(100);

                entity.Property(e => e.Time).HasMaxLength(20);
            });

            modelBuilder.Entity<DbsettingTb>(entity =>
            {
                entity.ToTable("DBSettingTB");

                entity.Property(e => e.DataSource).HasMaxLength(50);

                entity.Property(e => e.Dbname)
                    .HasMaxLength(50)
                    .HasColumnName("DBName");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<DepartmentTb>(entity =>
            {
                entity.ToTable("DepartmentTB");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DesignationTb>(entity =>
            {
                entity.ToTable("DesignationTB");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceLogsTb>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("DeviceLogsTB");

                entity.Property(e => e.AccessCardNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Adate)
                    .HasColumnType("date")
                    .HasColumnName("ADate");

                entity.Property(e => e.Atime).HasColumnName("ATime");

                entity.Property(e => e.AttendDate).HasColumnType("datetime");

                entity.Property(e => e.DownloadDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.PunchStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DevicesTb>(entity =>
            {
                entity.HasKey(e => e.DeviceId);

                entity.ToTable("DevicesTB");

                entity.Property(e => e.DeviceAccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceDirection)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceIpaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DeviceIPAddress");

                entity.Property(e => e.DeviceLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceSerialNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadDate).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Port)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeePunchTb>(entity =>
            {
                entity.ToTable("EmployeePunchTB");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(50)
                    .HasColumnName("cardNo");

                entity.Property(e => e.CardReaderNo)
                    .HasMaxLength(50)
                    .HasColumnName("cardReaderNo");

                entity.Property(e => e.CurrentVerifyMode)
                    .HasMaxLength(50)
                    .HasColumnName("currentVerifyMode");

                entity.Property(e => e.DeviceAccountId).HasMaxLength(50);

                entity.Property(e => e.DeviceIndex)
                    .HasMaxLength(100)
                    .HasColumnName("deviceIndex");

                entity.Property(e => e.DoorNo)
                    .HasMaxLength(50)
                    .HasColumnName("doorNo");

                entity.Property(e => e.EmployeeNoString)
                    .HasMaxLength(50)
                    .HasColumnName("employeeNoString");

                entity.Property(e => e.Major)
                    .HasMaxLength(50)
                    .HasColumnName("major");

                entity.Property(e => e.Mask)
                    .HasMaxLength(50)
                    .HasColumnName("mask");

                entity.Property(e => e.Minor)
                    .HasMaxLength(50)
                    .HasColumnName("minor");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(50)
                    .HasColumnName("serialNo");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .HasColumnName("userType");
            });

            modelBuilder.Entity<EmployeeScheduledVisitTb>(entity =>
            {
                entity.ToTable("EmployeeScheduledVisitTB");
            });

            modelBuilder.Entity<MailSettingTb>(entity =>
            {
                entity.ToTable("MailSettingTB");

                entity.Property(e => e.Host).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Port).HasColumnName("port");

                entity.Property(e => e.Smtpfrom)
                    .HasMaxLength(50)
                    .HasColumnName("smtpfrom");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTB");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CardNo).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(20);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IdProof).HasMaxLength(20);

                entity.Property(e => e.IdProofNumber).HasMaxLength(20);

                entity.Property(e => e.LastLoginDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserType).HasMaxLength(20);
            });

            modelBuilder.Entity<VisitorEntryTb>(entity =>
            {
                entity.ToTable("VisitorEntryTB");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.CardNo).HasMaxLength(50);

                entity.Property(e => e.CertificateImagePath).HasMaxLength(500);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Contact).HasMaxLength(20);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.IdProof).HasMaxLength(20);

                entity.Property(e => e.IdProofNumber).HasMaxLength(20);

                entity.Property(e => e.InTime).HasMaxLength(20);

                entity.Property(e => e.Material).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OutTime).HasMaxLength(20);

                entity.Property(e => e.Photo).HasMaxLength(100);

                entity.Property(e => e.Priority).HasMaxLength(10);

                entity.Property(e => e.PucendDate)
                    .HasColumnType("date")
                    .HasColumnName("PUCEndDate");

                entity.Property(e => e.Purpose).HasMaxLength(200);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.VehicleNo).HasMaxLength(50);

                entity.Property(e => e.VehiclePucno)
                    .HasMaxLength(50)
                    .HasColumnName("VehiclePUCNo");

                entity.Property(e => e.VehicleType).HasMaxLength(50);

                entity.Property(e => e.VisitorId).HasMaxLength(20);

                entity.Property(e => e.VisitorType).HasMaxLength(50);
            });

            modelBuilder.Entity<VisitorStatusTb>(entity =>
            {
                entity.ToTable("VisitorStatusTB");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<VisitorTb>(entity =>
            {
                entity.ToTable("VisitorTB");

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Contact).HasMaxLength(10);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Photo).HasMaxLength(100);

                entity.Property(e => e.VisitorId).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
