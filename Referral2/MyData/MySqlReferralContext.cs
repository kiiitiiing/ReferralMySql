using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Referral2.MyModels;

namespace Referral2.MyData
{
    public partial class MySqlReferralContext : DbContext
    {
        public MySqlReferralContext()
        {
        }

        public MySqlReferralContext(DbContextOptions<MySqlReferralContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Baby> Baby { get; set; }
        public virtual DbSet<Barangay> Barangay { get; set; }
        public virtual DbSet<Bed> Bed { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Devicetoken> Devicetoken { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Icd10> Icd10 { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryLogs> InventoryLogs { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<ModeTransportation> ModeTransportation { get; set; }
        public virtual DbSet<Muncity> Muncity { get; set; }
        public virtual DbSet<OpcenClient> OpcenClient { get; set; }
        public virtual DbSet<PatientForm> PatientForm { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<PregnantForm> PregnantForm { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<ReferenceNumber> ReferenceNumber { get; set; }
        public virtual DbSet<RepeatCall> RepeatCall { get; set; }
        public virtual DbSet<Seen> Seen { get; set; }
        public virtual DbSet<Tracking> Tracking { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=admin;database=doh_referral");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("activity");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ActionMd)
                    .HasColumnName("action_md")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DateReferred).HasColumnName("date_referred");

                entity.Property(e => e.DateSeen).HasColumnName("date_seen");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferredFrom)
                    .HasColumnName("referred_from")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferredTo)
                    .HasColumnName("referred_to")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferringMd)
                    .HasColumnName("referring_md")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Baby>(entity =>
            {
                entity.ToTable("baby");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BabyId)
                    .HasColumnName("baby_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.GestationalAge)
                    .HasColumnName("gestational_age")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MotherId)
                    .HasColumnName("mother_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Barangay>(entity =>
            {
                entity.ToTable("barangay");

                entity.HasIndex(e => new { e.ProvinceId, e.MuncityId, e.OldTarget })
                    .HasName("province_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MuncityId)
                    .HasColumnName("muncity_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OldTarget)
                    .HasColumnName("old_target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Target)
                    .HasColumnName("target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Bed>(entity =>
            {
                entity.ToTable("bed");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ActualNo)
                    .HasColumnName("actual_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowableNo)
                    .HasColumnName("allowable_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("encoded_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FacilityId)
                    .HasColumnName("facility_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Temporary)
                    .IsRequired()
                    .HasColumnName("temporary")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Devicetoken>(entity =>
            {
                entity.ToTable("devicetoken");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FacilityId)
                    .HasColumnName("facility_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("facility");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Abbr)
                    .IsRequired()
                    .HasColumnName("abbr")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Brgy)
                    .HasColumnName("brgy")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChiefHospital)
                    .HasColumnName("chief_hospital")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityCode)
                    .HasColumnName("facility_code")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HospitalType)
                    .HasColumnName("hospital_type")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Muncity)
                    .HasColumnName("muncity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.Receiver)
                    .HasColumnName("receiver")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Icd10>(entity =>
            {
                entity.ToTable("icd10");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("encoded_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FacilityId)
                    .HasColumnName("facility_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Occupied)
                    .HasColumnName("occupied")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<InventoryLogs>(entity =>
            {
                entity.ToTable("inventory_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("encoded_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FacilityId)
                    .HasColumnName("facility_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Occupied)
                    .HasColumnName("occupied")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("issue");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Issue1)
                    .IsRequired()
                    .HasColumnName("issue")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingId)
                    .HasColumnName("tracking_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Login1).HasColumnName("login");

                entity.Property(e => e.Logout).HasColumnName("logout");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModeTransportation>(entity =>
            {
                entity.ToTable("mode_transportation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Transportation)
                    .IsRequired()
                    .HasColumnName("transportation")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Muncity>(entity =>
            {
                entity.ToTable("muncity");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<OpcenClient>(entity =>
            {
                entity.ToTable("opcen_client");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BarangayId)
                    .HasColumnName("barangay_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CallClassification)
                    .HasColumnName("call_classification")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactNumber)
                    .HasColumnName("contact_number")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("encoded_by")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MunicipalityId)
                    .HasColumnName("municipality_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonActionTaken)
                    .HasColumnName("reason_action_taken")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonCalling)
                    .HasColumnName("reason_calling")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonChiefComplains)
                    .HasColumnName("reason_chief_complains")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonNotes)
                    .HasColumnName("reason_notes")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonPatientData)
                    .HasColumnName("reason_patient_data")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Relationship)
                    .HasColumnName("relationship")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sitio)
                    .HasColumnName("sitio")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TimeDuration)
                    .HasColumnName("time_duration")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeEnded)
                    .HasColumnName("time_ended")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeStarted)
                    .HasColumnName("time_started")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TransactionComplete)
                    .HasColumnName("transaction_complete")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TransactionIncomplete)
                    .HasColumnName("transaction_incomplete")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<PatientForm>(entity =>
            {
                entity.ToTable("patient_form");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("patient_form_unique_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CaseSummary)
                    .IsRequired()
                    .HasColumnName("case_summary");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CovidNumber)
                    .HasColumnName("covid_number")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Diagnosis)
                    .IsRequired()
                    .HasColumnName("diagnosis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisClinicalStatus)
                    .HasColumnName("dis_clinical_status")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DisSurCategory)
                    .HasColumnName("dis_sur_category")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecoSummary)
                    .IsRequired()
                    .HasColumnName("reco_summary");

                entity.Property(e => e.ReferClinicalStatus)
                    .HasColumnName("refer_clinical_status")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReferSurCategory)
                    .HasColumnName("refer_sur_category")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReferredMd)
                    .HasColumnName("referred_md")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferredTo)
                    .HasColumnName("referred_to")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferringFacility)
                    .HasColumnName("referring_facility")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferringMd)
                    .HasColumnName("referring_md")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeReferred).HasColumnName("time_referred");

                entity.Property(e => e.TimeTransferred).HasColumnName("time_transferred");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasColumnName("unique_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.ToTable("patients");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("patients_unique_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Brgy)
                    .HasColumnName("brgy")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CivilStatus)
                    .IsRequired()
                    .HasColumnName("civil_status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("mname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Muncity)
                    .HasColumnName("muncity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PhicId)
                    .IsRequired()
                    .HasColumnName("phic_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhicStatus)
                    .IsRequired()
                    .HasColumnName("phic_status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("sex")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TsekapPatient)
                    .HasColumnName("tsekap_patient")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasColumnName("unique_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<PregnantForm>(entity =>
            {
                entity.ToTable("pregnant_form");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("pregnant_form_unique_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ArrivalDate).HasColumnName("arrival_date");

                entity.Property(e => e.BabyBeforeGivenTime).HasColumnName("baby_before_given_time");

                entity.Property(e => e.BabyBeforeTreatment)
                    .IsRequired()
                    .HasColumnName("baby_before_treatment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BabyDuringTransport)
                    .IsRequired()
                    .HasColumnName("baby_during_transport")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BabyInformationGiven)
                    .IsRequired()
                    .HasColumnName("baby_information_given");

                entity.Property(e => e.BabyLastFeed).HasColumnName("baby_last_feed");

                entity.Property(e => e.BabyMajorFindings)
                    .IsRequired()
                    .HasColumnName("baby_major_findings");

                entity.Property(e => e.BabyReason)
                    .IsRequired()
                    .HasColumnName("baby_reason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BabyTransportGivenTime).HasColumnName("baby_transport_given_time");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HealthWorker)
                    .IsRequired()
                    .HasColumnName("health_worker")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PatientBabyId)
                    .HasColumnName("patient_baby_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PatientWomanId)
                    .HasColumnName("patient_woman_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RecordNo)
                    .IsRequired()
                    .HasColumnName("record_no")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReferredBy)
                    .HasColumnName("referred_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferredDate).HasColumnName("referred_date");

                entity.Property(e => e.ReferredTo)
                    .HasColumnName("referred_to")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferringFacility)
                    .HasColumnName("referring_facility")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasColumnName("unique_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WomanBeforeGivenTime).HasColumnName("woman_before_given_time");

                entity.Property(e => e.WomanBeforeTreatment)
                    .IsRequired()
                    .HasColumnName("woman_before_treatment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WomanDuringTransport)
                    .IsRequired()
                    .HasColumnName("woman_during_transport")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WomanInformationGiven)
                    .IsRequired()
                    .HasColumnName("woman_information_given");

                entity.Property(e => e.WomanMajorFindings)
                    .IsRequired()
                    .HasColumnName("woman_major_findings");

                entity.Property(e => e.WomanReason)
                    .IsRequired()
                    .HasColumnName("woman_reason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WomanTransportGivenTime).HasColumnName("woman_transport_given_time");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<ReferenceNumber>(entity =>
            {
                entity.HasKey(e => e.ReferenceNumber1)
                    .HasName("PRIMARY");

                entity.ToTable("reference_number");

                entity.Property(e => e.ReferenceNumber1)
                    .HasColumnName("reference_number")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("encoded_by")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<RepeatCall>(entity =>
            {
                entity.ToTable("repeat_call");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BarangayId)
                    .HasColumnName("barangay_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CallClassification)
                    .HasColumnName("call_classification")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactNumber)
                    .HasColumnName("contact_number")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("encoded_by")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MunicipalityId)
                    .HasColumnName("municipality_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonActionTaken)
                    .HasColumnName("reason_action_taken")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonCalling)
                    .HasColumnName("reason_calling")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonChiefComplains)
                    .HasColumnName("reason_chief_complains")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonNotes)
                    .HasColumnName("reason_notes")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReasonPatientData)
                    .HasColumnName("reason_patient_data")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Relationship)
                    .HasColumnName("relationship")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sitio)
                    .HasColumnName("sitio")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TimeDuration)
                    .HasColumnName("time_duration")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeEnded)
                    .HasColumnName("time_ended")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeStarted)
                    .HasColumnName("time_started")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TransactionComplete)
                    .HasColumnName("transaction_complete")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TransactionIncomplete)
                    .HasColumnName("transaction_incomplete")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Seen>(entity =>
            {
                entity.ToTable("seen");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FacilityId)
                    .HasColumnName("facility_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrackingId)
                    .HasColumnName("tracking_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserMd)
                    .HasColumnName("user_md")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tracking>(entity =>
            {
                entity.ToTable("tracking");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ActionMd)
                    .HasColumnName("action_md")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DateAccepted).HasColumnName("date_accepted");

                entity.Property(e => e.DateArrived).HasColumnName("date_arrived");

                entity.Property(e => e.DateReferred).HasColumnName("date_referred");

                entity.Property(e => e.DateSeen).HasColumnName("date_seen");

                entity.Property(e => e.DateTransferred).HasColumnName("date_transferred");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModeTransportation)
                    .IsRequired()
                    .HasColumnName("mode_transportation")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferredFrom)
                    .HasColumnName("referred_from")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferredTo)
                    .HasColumnName("referred_to")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferringMd)
                    .HasColumnName("referring_md")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Walkin)
                    .IsRequired()
                    .HasColumnName("walkin")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AccreditationNo)
                    .IsRequired()
                    .HasColumnName("accreditation_no")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AccreditationValidity)
                    .IsRequired()
                    .HasColumnName("accreditation_validity")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasColumnName("designation")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityId)
                    .HasColumnName("facility_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnName("level")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseNo)
                    .IsRequired()
                    .HasColumnName("license_no")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LoginStatus)
                    .IsRequired()
                    .HasColumnName("login_status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("mname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Muncity)
                    .HasColumnName("muncity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnName("picture")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasColumnName("prefix")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
