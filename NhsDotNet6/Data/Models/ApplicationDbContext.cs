using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NhsDotNet6.Data.Models
{

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Affliction> Afflictions { get; set; } = null!;
        public virtual DbSet<Afflictioncatrgory> Afflictioncatrgories { get; set; } = null!;
        public virtual DbSet<Afflictiontype> Afflictiontypes { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Appointmentstaff> Appointmentstaffs { get; set; } = null!;
        //public virtual DbSet<Appointmenttime> Appointmenttimes { get; set; } = null!;
        public virtual DbSet<County> Counties { get; set; } = null!;
        public virtual DbSet<Homeaddress> Homeaddresses { get; set; } = null!;
        public virtual DbSet<Homeaddresspatient> Homeaddresspatients { get; set; } = null!;
        public virtual DbSet<Homeaddressstaff> Homeaddressstaffs { get; set; } = null!;
        public virtual DbSet<Hospital> Hospitals { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Patientlogin> Patientlogins { get; set; } = null!;
        public virtual DbSet<Phonenumberstaff> Phonenumberstaffs { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<Stafflogin> Stafflogins { get; set; } = null!;
        public virtual DbSet<Towncity> Towncities { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;database=mydb;user=root;password=root", ServerVersion.Parse("8.0.34-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Affliction>(entity =>
            {
                entity.HasKey(e => new { e.AfflictionId, e.AfflictionTypeAfflictionTypeId, e.AfflictionCatrgoryAfflictionCatrgoryId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("affliction");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.AfflictionCatrgoryAfflictionCatrgoryId, "fk_AfflictionCategoryType_AfflictionCatrgory1_idx");

                entity.HasIndex(e => e.AfflictionTypeAfflictionTypeId, "fk_AfflictionCategoryType_AfflictionType1_idx");

                entity.HasIndex(e => e.PatientPatientId, "fk_Affliction_Patient1_idx");

                entity.Property(e => e.AfflictionId).HasColumnName("AfflictionID");

                entity.Property(e => e.AfflictionTypeAfflictionTypeId).HasColumnName("AfflictionType_AfflictionTypeID");

                entity.Property(e => e.AfflictionCatrgoryAfflictionCatrgoryId).HasColumnName("AfflictionCatrgory_AfflictionCatrgoryID");

                entity.Property(e => e.PatientPatientId).HasColumnName("Patient_PatientID");

                entity.HasOne(d => d.AfflictionCatrgoryAfflictionCatrgory)
                    .WithMany(p => p.Afflictions)
                    .HasForeignKey(d => d.AfflictionCatrgoryAfflictionCatrgoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AfflictionCategoryType_AfflictionCatrgory1");

                entity.HasOne(d => d.AfflictionTypeAfflictionType)
                    .WithMany(p => p.Afflictions)
                    .HasForeignKey(d => d.AfflictionTypeAfflictionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AfflictionCategoryType_AfflictionType1");

                entity.HasOne(d => d.PatientPatient)
                    .WithMany(p => p.Afflictions)
                    .HasForeignKey(d => d.PatientPatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Affliction_Patient1");
            });

            modelBuilder.Entity<Afflictioncatrgory>(entity =>
            {
                entity.ToTable("afflictioncatrgory");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AfflictionCatrgoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("AfflictionCatrgoryID");

                entity.Property(e => e.AfflictionCatrgoryName).HasMaxLength(45);
            });

            modelBuilder.Entity<Afflictiontype>(entity =>
            {
                entity.ToTable("afflictiontype");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AfflictionTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("AfflictionTypeID");

                entity.Property(e => e.AfflictionTypeName).HasMaxLength(45);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => new { e.HospitalHospitalId, e.HospitalTowncityTownCityId, e.HospitalTowncityCountyCountyId, e.PatientPatientId, e.AppointmentstaffAppointmentStaffId, e.AppointmentstaffStaffStaffId, e.AppointmentId, e.AppointmenttimeAppointmentTimeId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0, 0, 0 });

                entity.ToTable("appointment");

                entity.HasIndex(e => new { e.AppointmentstaffAppointmentStaffId, e.AppointmentstaffStaffStaffId }, "fk_appointment_appointmentstaff1_idx");

                entity.HasIndex(e => e.AppointmenttimeAppointmentTimeId, "fk_appointment_appointmenttime1_idx");

                entity.HasIndex(e => e.PatientPatientId, "fk_appointment_patient1_idx");

                entity.Property(e => e.HospitalHospitalId).HasColumnName("hospital_HospitalID");

                entity.Property(e => e.HospitalTowncityTownCityId).HasColumnName("hospital_towncity_TownCityID");

                entity.Property(e => e.HospitalTowncityCountyCountyId).HasColumnName("hospital_towncity_County_CountyID");

                entity.Property(e => e.PatientPatientId).HasColumnName("patient_PatientID");

                entity.Property(e => e.AppointmentstaffAppointmentStaffId).HasColumnName("appointmentstaff_AppointmentStaffID");

                entity.Property(e => e.AppointmentstaffStaffStaffId).HasColumnName("appointmentstaff_Staff_StaffID");

                entity.Property(e => e.AppointmentId)
                    .HasMaxLength(45)
                    .HasColumnName("AppointmentID");

                entity.Property(e => e.AppointmenttimeAppointmentTimeId).HasColumnName("appointmenttime_AppointmentTimeID");

               /* entity.HasOne(d => d.AppointmenttimeAppointmentTime)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppointmenttimeAppointmentTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_appointment_appointmenttime1");
               */
                entity.HasOne(d => d.PatientPatient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientPatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_appointment_patient1");

                entity.HasOne(d => d.Appointmentstaff)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => new { d.AppointmentstaffAppointmentStaffId, d.AppointmentstaffStaffStaffId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_appointment_appointmentstaff1");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => new { d.HospitalHospitalId, d.HospitalTowncityTownCityId, d.HospitalTowncityCountyCountyId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_appointment_hospital1");
            });

            modelBuilder.Entity<Appointmentstaff>(entity =>
            {
                entity.HasKey(e => new { e.AppointmentStaffId, e.StaffStaffId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("appointmentstaff");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.StaffStaffId, "fk_AppointmentStaff_Staff1_idx");

                entity.Property(e => e.AppointmentStaffId).HasColumnName("AppointmentStaffID");

                entity.Property(e => e.StaffStaffId).HasColumnName("Staff_StaffID");

                entity.HasOne(d => d.StaffStaff)
                    .WithMany(p => p.Appointmentstaffs)
                    .HasForeignKey(d => d.StaffStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AppointmentStaff_Staff1");
            });

           /* modelBuilder.Entity<Appointmenttime>(entity =>
            {
                entity.ToTable("appointmenttime");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AppointmentTimeId)
                    .ValueGeneratedNever()
                    .HasColumnName("AppointmentTimeID");
            });*/

            modelBuilder.Entity<County>(entity =>
            {
                entity.ToTable("county");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CountyId)
                    .ValueGeneratedNever()
                    .HasColumnName("CountyID");

                entity.Property(e => e.CountyName).HasMaxLength(45);
            });

            modelBuilder.Entity<Homeaddress>(entity =>
            {
                entity.ToTable("homeaddress");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.HomeAddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("HomeAddressID");

                entity.Property(e => e.County).HasMaxLength(45);

                entity.Property(e => e.HomeName).HasMaxLength(45);

                entity.Property(e => e.HouseNumber).HasMaxLength(45);

                entity.Property(e => e.Postcode).HasMaxLength(45);

                entity.Property(e => e.RoadName).HasMaxLength(45);

                entity.Property(e => e.TownCity).HasMaxLength(45);
            });

            modelBuilder.Entity<Homeaddresspatient>(entity =>
            {
                entity.ToTable("homeaddresspatient");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.HomeAddressId, "fk_HomeAddressPatient_HomeAddress1_idx");

                entity.HasIndex(e => e.PatientId, "fk_HomeAddressPatient_Patient1_idx");

                entity.Property(e => e.HomeAddressPatientId).HasColumnName("HomeAddressPatientID");

                entity.Property(e => e.HomeAddressId).HasColumnName("HomeAddressID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.HomeAddress)
                    .WithMany(p => p.Homeaddresspatients)
                    .HasForeignKey(d => d.HomeAddressId)
                    .HasConstraintName("fk_HomeAddressPatient_HomeAddress1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Homeaddresspatients)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("fk_HomeAddressPatient_Patient1");
            });

            modelBuilder.Entity<Homeaddressstaff>(entity =>
            {
                entity.HasKey(e => e.HomeAddressId)
                    .HasName("PRIMARY");

                entity.ToTable("homeaddressstaff");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.HomeAddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("HomeAddressID");

                entity.Property(e => e.County).HasMaxLength(45);

                entity.Property(e => e.HomeName).HasMaxLength(45);

                entity.Property(e => e.HouseNumber).HasMaxLength(45);

                entity.Property(e => e.Postcode).HasMaxLength(45);

                entity.Property(e => e.RoadName).HasMaxLength(45);

                entity.Property(e => e.TownCity).HasMaxLength(45);
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => new { e.HospitalId, e.TowncityTownCityId, e.TowncityCountyCountyId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("hospital");

                entity.HasIndex(e => new { e.TowncityTownCityId, e.TowncityCountyCountyId }, "fk_hospital_towncity1_idx");

                entity.Property(e => e.HospitalId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HospitalID");

                entity.Property(e => e.TowncityTownCityId).HasColumnName("towncity_TownCityID");

                entity.Property(e => e.TowncityCountyCountyId).HasColumnName("towncity_County_CountyID");

                entity.Property(e => e.HospitalName).HasMaxLength(45);

                entity.Property(e => e.Postcode).HasMaxLength(45);

                entity.HasOne(d => d.Towncity)
                    .WithMany(p => p.Hospitals)
                    .HasForeignKey(d => new { d.TowncityTownCityId, d.TowncityCountyCountyId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hospital_towncity1");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("PatientID");

                entity.Property(e => e.PatientFirstName).HasMaxLength(100);

                entity.Property(e => e.PatientLastName).HasMaxLength(100);

                entity.Property(e => e.PatientSex).HasMaxLength(100);
            });

            modelBuilder.Entity<Patientlogin>(entity =>
            {
                entity.ToTable("patientlogin");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.PatientId, "fk_PatientLogin_Patient1_idx");

                entity.Property(e => e.PatientLoginId)
                    .HasMaxLength(45)
                    .HasColumnName("PatientLoginID");

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Username).HasMaxLength(45);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Patientlogins)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientLogin_Patient1");
            });

            modelBuilder.Entity<Phonenumberstaff>(entity =>
            {
                entity.HasKey(e => e.PhoneNumberId)
                    .HasName("PRIMARY");

                entity.ToTable("phonenumberstaff");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.StaffStaffId, "fk_PhoneNumber_Staff1_idx");

                entity.Property(e => e.PhoneNumberId).HasColumnName("PhoneNumberID");

                entity.Property(e => e.StaffStaffId).HasColumnName("Staff_StaffID");

                entity.HasOne(d => d.StaffStaff)
                    .WithMany(p => p.Phonenumberstaffs)
                    .HasForeignKey(d => d.StaffStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PhoneNumber_Staff1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(45);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.StaffStaffId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("specialization");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.StaffStaffId, "fk_Specialization_Staff1_idx");

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.StaffStaffId).HasColumnName("Staff_StaffID");

                entity.Property(e => e.SpecName).HasMaxLength(45);

                entity.HasOne(d => d.StaffStaff)
                    .WithMany(p => p.Specializations)
                    .HasForeignKey(d => d.StaffStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Specialization_Staff1");
            });

            modelBuilder.Entity<Stafflogin>(entity =>
            {
                entity.ToTable("stafflogin");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.StaffStaffId, "fk_StaffLogin_Staff1_idx");

                entity.Property(e => e.StaffLoginId)
                    .HasMaxLength(45)
                    .HasColumnName("StaffLoginID");

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.StaffStaffId).HasColumnName("Staff_StaffID");

                entity.Property(e => e.Username).HasMaxLength(45);

                entity.HasOne(d => d.StaffStaff)
                    .WithMany(p => p.Stafflogins)
                    .HasForeignKey(d => d.StaffStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_StaffLogin_Staff1");
            });

            modelBuilder.Entity<Towncity>(entity =>
            {
                entity.HasKey(e => new { e.TownCityId, e.CountyCountyId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("towncity");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.CountyCountyId, "fk_TownCity_County1_idx");

                entity.Property(e => e.TownCityId).HasColumnName("TownCityID");

                entity.Property(e => e.CountyCountyId).HasColumnName("County_CountyID");

                entity.Property(e => e.TownCityName).HasMaxLength(45);

                entity.HasOne(d => d.CountyCounty)
                    .WithMany(p => p.Towncities)
                    .HasForeignKey(d => d.CountyCountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TownCity_County1");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.RoleRoleId, "RoleID_idx");

                entity.Property(e => e.StaffId)
                    .ValueGeneratedNever()
                    .HasColumnName("StaffID");

                entity.Property(e => e.NameF).HasMaxLength(45);

                entity.Property(e => e.NameL).HasMaxLength(45);

                entity.Property(e => e.RoleRoleId).HasColumnName("Role_RoleID");

                entity.HasOne(d => d.RoleRole)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.RoleRoleId)
                    .HasConstraintName("RoleID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
