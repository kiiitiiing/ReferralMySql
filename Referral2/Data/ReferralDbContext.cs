using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Referral2.Models;

namespace Referral2.Data
{
    public partial class ReferralDbContext : DbContext
    {
        public ReferralDbContext()
        {
        }

        public ReferralDbContext(DbContextOptions<ReferralDbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Baby> Baby { get; set; }
        public virtual DbSet<Barangay> Barangay { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryLogs> InventoryLogs { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<ModeTransportation> ModeTransportation { get; set; }
        public virtual DbSet<Muncity> Muncity { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientForm> PatientForm { get; set; }
        public virtual DbSet<PregnantForm> PregnantForm { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Seen> Seen { get; set; }
        public virtual DbSet<Tracking> Tracking { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-6I12DHEP\\SQLEXPRESS;Initial Catalog=Referral;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasIndex(e => e.ActionMd)
                    .HasName("IX_IIActivity_ActionMd");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_IIActivity_DepartmentId");

                entity.HasIndex(e => e.PatientId)
                    .HasName("IX_IIActivity_PatientId");

                entity.HasIndex(e => e.ReferredFrom)
                    .HasName("IX_IIActivity_ReferredFrom");

                entity.HasIndex(e => e.ReferredTo)
                    .HasName("IX_IIActivity_ReferredTo");

                entity.HasIndex(e => e.ReferringMd)
                    .HasName("IX_IIActivity_ReferringMd");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.ActionMdNavigation)
                    .WithMany(p => p.ActivityActionMdNavigation)
                    .HasForeignKey(d => d.ActionMd)
                    .HasConstraintName("FK_Activity_User_To");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Activity_Department");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Patient");

                entity.HasOne(d => d.ReferredFromNavigation)
                    .WithMany(p => p.ActivityReferredFromNavigation)
                    .HasForeignKey(d => d.ReferredFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Facility_From");

                entity.HasOne(d => d.ReferredToNavigation)
                    .WithMany(p => p.ActivityReferredToNavigation)
                    .HasForeignKey(d => d.ReferredTo)
                    .HasConstraintName("FK_Activity_Facilit_To");

                entity.HasOne(d => d.ReferringMdNavigation)
                    .WithMany(p => p.ActivityReferringMdNavigation)
                    .HasForeignKey(d => d.ReferringMd)
                    .HasConstraintName("FK_Activity_User_From");
            });

            modelBuilder.Entity<Baby>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("AK_IIBaby_Id")
                    .IsUnique();

                entity.HasOne(d => d.BabyNavigation)
                    .WithMany(p => p.BabyBabyNavigation)
                    .HasForeignKey(d => d.BabyId)
                    .HasConstraintName("FK_Patient_BabyId");

                entity.HasOne(d => d.Mother)
                    .WithMany(p => p.BabyMother)
                    .HasForeignKey(d => d.MotherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_MotherId");
            });

            modelBuilder.Entity<Barangay>(entity =>
            {
                entity.HasIndex(e => e.MuncityId)
                    .HasName("IX_IIBarangay_MuncityId");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Muncity)
                    .WithMany(p => p.Barangay)
                    .HasForeignKey(d => d.MuncityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Barangay_Muncity");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Barangay)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_Barangay_Province");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.HasIndex(e => e.BarangayId)
                    .HasName("IX_IIFacility_BarangayId");

                entity.HasIndex(e => e.MuncityId)
                    .HasName("IX_IIFacility_MuncityId");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("IX_IIFacility_ProvinceId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Abbr).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ChiefHospital).IsUnicode(false);

                entity.Property(e => e.ContactNo).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FacilityCode).IsUnicode(false);

                entity.Property(e => e.Level).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.HasOne(d => d.Barangay)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.BarangayId)
                    .HasConstraintName("FK_Facility_Barangay");

                entity.HasOne(d => d.Muncity)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.MuncityId)
                    .HasConstraintName("FK_Facility_Muncity");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facility_Province");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Code).IsUnicode(false);

                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.FeedbackReciever)
                    .HasForeignKey(d => d.RecieverId)
                    .HasConstraintName("FK_Feedback_MDReciever");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.FeedbackSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_MDSender");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.EncodedByNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.EncodedBy)
                    .HasConstraintName("FK_Inventory_User");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Facility");
            });

            modelBuilder.Entity<InventoryLogs>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.EncodedByNavigation)
                    .WithMany(p => p.InventoryLogs)
                    .HasForeignKey(d => d.EncodedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Logs_User");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.InventoryLogs)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Logs_Facility");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryLogs)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Logs_Inventory");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasIndex(e => e.TrackingId)
                    .HasName("IX_IIIssue_TrackingId");

                entity.Property(e => e.Issue1).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.Tracking)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.TrackingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issue_Tracking");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_IILogin_UserId");

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_User_Id");
            });

            modelBuilder.Entity<ModeTransportation>(entity =>
            {
                entity.Property(e => e.Transportation).IsUnicode(false);
            });

            modelBuilder.Entity<Muncity>(entity =>
            {
                entity.HasIndex(e => e.ProvinceId)
                    .HasName("IX_IIMuncity_ProvinceId");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Muncity)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Muncity_Province");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.BarangayId)
                    .HasName("IX_IIPatients_BarangayId");

                entity.HasIndex(e => e.MuncityId)
                    .HasName("IX_IIPatients_MuncityId");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("IX_IIPatients_ProvinceId");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.CivilStatus).IsUnicode(false);

                entity.Property(e => e.Fname).IsUnicode(false);

                entity.Property(e => e.Lname).IsUnicode(false);

                entity.Property(e => e.Mname).IsUnicode(false);

                entity.Property(e => e.PhicId).IsUnicode(false);

                entity.Property(e => e.PhicStatus).IsUnicode(false);

                entity.Property(e => e.Sex).IsUnicode(false);

                entity.Property(e => e.UniqueId).IsUnicode(false);

                entity.HasOne(d => d.Barangay)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.BarangayId)
                    .HasConstraintName("FK_Patients_Barangay");

                entity.HasOne(d => d.Muncity)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.MuncityId)
                    .HasConstraintName("FK_Patients_Muncity");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_Patients_Province");
            });

            modelBuilder.Entity<PatientForm>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_IIPatientForm_DepartmentId");

                entity.HasIndex(e => e.PatientId)
                    .HasName("IX_IIPatientForm_PatientId");

                entity.HasIndex(e => e.ReferredMd)
                    .HasName("IX_IIPatientForm_ReferredMd");

                entity.HasIndex(e => e.ReferredTo)
                    .HasName("IX_IIPatientForm_ReferredTo");

                entity.HasIndex(e => e.ReferringFacility)
                    .HasName("IX_IIPatientForm_ReferringFacilityId");

                entity.HasIndex(e => e.ReferringMd)
                    .HasName("IX_IIPatientForm_ReferringMd");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Diagnosis).IsUnicode(false);

                entity.Property(e => e.Reason).IsUnicode(false);

                entity.Property(e => e.UniqueId).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PatientForm)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_PatientForm_Department");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientForm)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientForm_Patient_Id");

                entity.HasOne(d => d.ReferredMdNavigation)
                    .WithMany(p => p.PatientFormReferredMdNavigation)
                    .HasForeignKey(d => d.ReferredMd)
                    .HasConstraintName("FK_PatientForm_User_ReferredMd");

                entity.HasOne(d => d.ReferredToNavigation)
                    .WithMany(p => p.PatientFormReferredToNavigation)
                    .HasForeignKey(d => d.ReferredTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientForm_Facility_To");

                entity.HasOne(d => d.ReferringFacilityNavigation)
                    .WithMany(p => p.PatientFormReferringFacilityNavigation)
                    .HasForeignKey(d => d.ReferringFacility)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientForm_Facility_From");

                entity.HasOne(d => d.ReferringMdNavigation)
                    .WithMany(p => p.PatientFormReferringMdNavigation)
                    .HasForeignKey(d => d.ReferringMd)
                    .HasConstraintName("FK_PatientForm_User_ReferringMd");
            });

            modelBuilder.Entity<PregnantForm>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_IIPregnantForm_DepartmentId");

                entity.HasIndex(e => e.PatientWomanId)
                    .HasName("IX_IIPregnantForm_PatientWomanId");

                entity.HasIndex(e => e.ReferredBy)
                    .HasName("IX_IIPregnantForm_ReferredBy");

                entity.HasIndex(e => e.ReferredTo)
                    .HasName("IX_IIPregnantForm_ReferredTo");

                entity.HasIndex(e => e.ReferringFacility)
                    .HasName("IX_IIPregnantForm_ReferringFacility");

                entity.Property(e => e.BabyBeforeTreatment).IsUnicode(false);

                entity.Property(e => e.BabyDuringTransport).IsUnicode(false);

                entity.Property(e => e.BabyInformationGiven).IsUnicode(false);

                entity.Property(e => e.BabyReason).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.HealthWorker).IsUnicode(false);

                entity.Property(e => e.RecordNo).IsUnicode(false);

                entity.Property(e => e.UniqueId).IsUnicode(false);

                entity.Property(e => e.WomanDuringTransport).IsUnicode(false);

                entity.Property(e => e.WomanReason).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PregnantForm)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_PregnantForm_Department");

                entity.HasOne(d => d.PatientBaby)
                    .WithMany(p => p.PregnantFormPatientBaby)
                    .HasForeignKey(d => d.PatientBabyId)
                    .HasConstraintName("FK_PregnantForm_BabyId");

                entity.HasOne(d => d.PatientWoman)
                    .WithMany(p => p.PregnantFormPatientWoman)
                    .HasForeignKey(d => d.PatientWomanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PregnantForm_MotherId");

                entity.HasOne(d => d.ReferredByNavigation)
                    .WithMany(p => p.PregnantForm)
                    .HasForeignKey(d => d.ReferredBy)
                    .HasConstraintName("FK_PregnantForm_User_From");

                entity.HasOne(d => d.ReferredToNavigation)
                    .WithMany(p => p.PregnantFormReferredToNavigation)
                    .HasForeignKey(d => d.ReferredTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PregnantForm_Facility_To");

                entity.HasOne(d => d.ReferringFacilityNavigation)
                    .WithMany(p => p.PregnantFormReferringFacilityNavigation)
                    .HasForeignKey(d => d.ReferringFacility)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PregnantForm_Facility_From");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Seen>(entity =>
            {
                entity.HasIndex(e => e.FacilityId)
                    .HasName("IX_IISeen_FacilityId");

                entity.HasIndex(e => e.TrackingId)
                    .HasName("IX_IISeen_TrackingId");

                entity.HasIndex(e => e.UserMd)
                    .HasName("IX_IISeen_UserMd");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Seen)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seen_Facility");

                entity.HasOne(d => d.Tracking)
                    .WithMany(p => p.Seen)
                    .HasForeignKey(d => d.TrackingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seen_Tracking");

                entity.HasOne(d => d.UserMdNavigation)
                    .WithMany(p => p.Seen)
                    .HasForeignKey(d => d.UserMd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seen_User_Id");
            });

            modelBuilder.Entity<Tracking>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_IITracking_DepartmentId");

                entity.HasIndex(e => e.PatientId)
                    .HasName("IX_IITracking_PatientId");

                entity.HasIndex(e => e.ReferredFrom)
                    .HasName("IX_IITracking_ReferredFrom");

                entity.HasIndex(e => e.ReferredTo)
                    .HasName("IX_IITracking_ReferredTo");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.ModeTransportation).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.Walkin).IsUnicode(false);

                entity.HasOne(d => d.ActionMdNavigation)
                    .WithMany(p => p.TrackingActionMdNavigation)
                    .HasForeignKey(d => d.ActionMd)
                    .HasConstraintName("FK_Tracking_User_ActionMd");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Tracking)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Tracking_Department");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Tracking)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tracking_Patients");

                entity.HasOne(d => d.ReferredFromNavigation)
                    .WithMany(p => p.TrackingReferredFromNavigation)
                    .HasForeignKey(d => d.ReferredFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tracking_Facility_From");

                entity.HasOne(d => d.ReferredToNavigation)
                    .WithMany(p => p.TrackingReferredToNavigation)
                    .HasForeignKey(d => d.ReferredTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tracking_Facility_To");

                entity.HasOne(d => d.ReferringMdNavigation)
                    .WithMany(p => p.TrackingReferringMdNavigation)
                    .HasForeignKey(d => d.ReferringMd)
                    .HasConstraintName("FK_Tracking_User_ReferringMd");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_IIUser_DepartmentId");

                entity.HasIndex(e => e.FacilityId)
                    .HasName("IX_IIUser_FacilityId");

                entity.HasIndex(e => e.MuncityId)
                    .HasName("IX_IIUser_MuncityId");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("IX_IIUser_ProvinceId");

                entity.Property(e => e.AccreditationNo).IsUnicode(false);

                entity.Property(e => e.AccreditationValidity).IsUnicode(false);

                entity.Property(e => e.ContactNo).IsUnicode(false);

                entity.Property(e => e.Designation).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Fname).IsUnicode(false);

                entity.Property(e => e.Level).IsUnicode(false);

                entity.Property(e => e.LicenseNo).IsUnicode(false);

                entity.Property(e => e.Lname).IsUnicode(false);

                entity.Property(e => e.LoginStatus).IsUnicode(false);

                entity.Property(e => e.Mname).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.Prefix).IsUnicode(false);

                entity.Property(e => e.RememberToken).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_User_Department");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Facility");

                entity.HasOne(d => d.Muncity)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.MuncityId)
                    .HasConstraintName("FK_User_Muncity");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Province");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
