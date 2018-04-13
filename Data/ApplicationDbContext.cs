using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreVue.Models;

namespace NetCoreVue.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<AccountRate> AccountRates { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<SessionSynopsis> SessionSynopses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<TimeSheetDetail> TimeSheetDetails { get; set; }
        public DbSet<InstructorAccount> InstructorAccounts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            #region Course

            builder.Entity<Course>()
                .HasKey(input => input.CourseId)
                .HasName("PrimaryKey_CourseId");

            builder.Entity<Course>()
                .Property(input => input.CourseId)
                .HasColumnName("CourseId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Course>()
                .Property(input => input.CourseName)
                .HasColumnName("CourseName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Entity<Course>()
                .Property(input => input.CourseAbbreviation)
                .HasColumnName("CourseAbbreviation")
                .HasColumnType("VARCHAR(10)")
                .IsRequired();

            builder.Entity<Course>()
                .Property(input => input.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            builder.Entity<Course>()
                .Property(input => input.UpdatedAt)
                .HasDefaultValueSql("GetDate()");

            builder.Entity<Course>()
                .Property(input => input.DeletedAt)
                .IsRequired(false);

            builder.Entity<Course>()
                .HasIndex(input => input.CourseAbbreviation).IsUnique()
                .HasName("Course_CourseAbbreviation_UniqueConstraint");
            builder.Entity<Course>()
                .HasOne(input => input.CreatedBy)
                .WithMany()
                .HasForeignKey(input => input.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.Entity<Course>()
                .HasOne(input => input.DeletedBy)
                .WithMany()
                .HasForeignKey(input => input.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Course>()
                .HasOne(input => input.UpdatedBy)
                .WithMany()
                .HasForeignKey(input => input.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            #endregion

            #region SessionSynopSis

            builder.Entity<SessionSynopsis>()
                .HasKey(input => input.SessionSynopsisId)
                .HasName("PrimaryKey_SessionSynopsisId");
            builder.Entity<SessionSynopsis>()
                .Property(input => input.SessionSynopsisId)
                .HasColumnName("SessionSynopsisId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<SessionSynopsis>()
                .Property(input => input.SessionSynopsisName)
                .HasColumnName("SessionSynopsisName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Entity<SessionSynopsis>()
                .Property(input => input.IsVisible)
                .HasColumnName("IsVisible")
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Entity<SessionSynopsis>()
                .HasIndex(input => input.SessionSynopsisName).IsUnique()
                .HasName("SessionSynopsis_SessionSynopsisName_UniqueConstraint");

            #endregion

            #region CustomerAccount

            builder.Entity<CustomerAccount>()
                .HasKey(input => input.CustomerAccountId)
                .HasName("PrimaryKey_CustomerAccountId");
            builder.Entity<CustomerAccount>()
                .Property(input => input.CustomerAccountId)
                .HasColumnName("CustomerAccountId")
                .HasColumnType("INT")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<CustomerAccount>()
                .Property(input => input.AccountName)
                .HasColumnName("AccountName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Entity<CustomerAccount>()
                .Property(input => input.IsVisible)
                .HasColumnName("IsVisible")
                .HasColumnType("BIT")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Entity<CustomerAccount>()
                .Property(input => input.Comments)
                .HasColumnName("Comments")
                .HasColumnType("NVARCHAR(4000)")
                .IsRequired(false);

            builder.Entity<CustomerAccount>()
                .Property(input => input.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            builder.Entity<CustomerAccount>()
                .Property(input => input.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            builder.Entity<CustomerAccount>()
                .HasIndex(input => input.AccountName).IsUnique()
                .HasName("CustomerAccount_AccountName_UniqueConstraint");

            #endregion

            #region AccountRate

            builder.Entity<AccountRate>()
                .HasKey(input => input.AccountRateId)
                .HasName("PrimaryKey_AccountRateId");

            builder.Entity<AccountRate>()
                .Property(input => input.AccountRateId)
                .HasColumnName("AccountRateId")
                .HasColumnType("INT")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<AccountRate>()
                .Property(input => input.EffectiveStartDate)
                .HasColumnName("EffectiveStartDate")
                .IsRequired();

            builder.Entity<AccountRate>()
                .Property(input => input.EffectiveEndDate)
                .HasColumnName("EffectiveEndDate")
                .IsRequired(false);

            builder.Entity<AccountRate>()
                .Property(input => input.RatePerHour)
                .HasColumnName("RatePerHour")
                .HasColumnType("DECIMAL(6,2)")
                .IsRequired();

            #endregion

            #region UserInfo

            builder.Entity<UserInfo>()
                .HasKey(input => input.UserInfoId)
                .HasName("PrimaryKey_UserInfoId");

            builder.Entity<UserInfo>()
                .Property(input => input.UserInfoId)
                .HasColumnName("UserInfoId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<UserInfo>()
                .Property(input => input.LoginUserName)
                .HasColumnName("LoginUserName")
                .HasColumnType("VARCHAR(10)")
                .IsRequired();

            builder.Entity<UserInfo>()
                .Property(input => input.FullName)
                .HasColumnName("FullName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Entity<UserInfo>()
                .Property(input => input.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Entity<UserInfo>()
                .Property(input => input.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Entity<UserInfo>()
                .HasIndex(input => input.LoginUserName).IsUnique()
                .HasName("UserInfo_LoginUserName_UniqueConstraint");

            #endregion

            #region InstructorAccount

            builder.Entity<InstructorAccount>()
                .HasKey(input => input.InstructorAccountId)
                .HasName("PrimaryKey_InstructorAccounttId");

            builder.Entity<InstructorAccount>()
                .Property(input => input.InstructorAccountId)
                .HasColumnName("InstructorAccountId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<InstructorAccount>()
                .Property(input => input.EffectiveStartDate)
                .HasColumnName("EffectiveStartDate")
                .IsRequired();

            builder.Entity<InstructorAccount>()
                .Property(input => input.EffectiveEndDate)
                .HasColumnName("EffectiveEndDate")
                .IsRequired(false);

            builder.Entity<InstructorAccount>()
                .Property(input => input.InstructorId)
                .HasColumnName("InstructorId")
                .HasColumnType("int")
                .IsRequired();

            builder.Entity<InstructorAccount>()
                .Property(input => input.CustomerAccountId)
                .HasColumnName("CustomerAccountId")
                .HasColumnType("int")
                .IsRequired();

            builder.Entity<InstructorAccount>()
                .Property(input => input.WageRate)
                .HasColumnName("WageRate")
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Entity<InstructorAccount>()
                .Property(input => input.IsCurrent)
                .HasColumnName("IsCurrent")
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Entity<InstructorAccount>()
                .Property(input => input.Comments)
                .HasColumnName("Comments")
                .HasColumnType("NVARCHAR(4000)")
                .IsRequired(false);

            #endregion

            #region AccountDetail

            builder.Entity<AccountDetail>()
                .HasKey(input => input.AccountDetailId)
                .HasName("PrimaryKey_AccountDetailId");

            builder.Entity<AccountDetail>()
                .Property(input => input.AccountDetailId)
                .HasColumnName("AccountDetailId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<AccountDetail>()
                .Property(input => input.EffectiveStartDate)
                .HasColumnName("EffectiveStartDate")
                .IsRequired();

            builder.Entity<AccountDetail>()
                .Property(input => input.EffectiveEndDate)
                .HasColumnName("EffectiveEndDate")
                .IsRequired(false);

            builder.Entity<AccountDetail>()
                .Property(input => input.StartTimeInMinutes)
                .HasColumnName("StartTimeInMinutes")
                .HasColumnType("int")
                .IsRequired();

            builder.Entity<AccountDetail>()
                .Property(input => input.EndTimeInMinutes)
                .HasColumnName("EndTimeInMinutes")
                .HasColumnType("int")
                .IsRequired();

            builder.Entity<AccountDetail>()
                .Property(input => input.IsVisible)
                .HasColumnName("IsVisible")
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .IsRequired();

            #endregion

            #region TimeSheet

            builder.Entity<TimeSheet>()
                .HasKey(input => input.TimeSheetId)
                .HasName("PrimaryKey_TimeSheetId");

            builder.Entity<TimeSheet>()
                .Property(input => input.TimeSheetId)
                .HasColumnName("TimeSheetId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<TimeSheet>()
                .Property(input => input.MonthAndYear)
                .HasColumnName("MonthAndYear")
                .IsRequired();

            builder.Entity<TimeSheet>()
                .Property(input => input.VerifiedAndSubmittedAt)
                .HasColumnName("VerifiedAndSubmittedAt")
                .IsRequired(false);

            builder.Entity<TimeSheet>()
                .Property(input => input.UpdatedById)
                .HasColumnName("UpdatedById")
                .HasColumnType("int")
                .IsRequired();

            builder.Entity<TimeSheet>()
                .Property(input => input.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("GetDate()");

            builder.Entity<TimeSheet>()
                .Property(input => input.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("GetDate()");

            builder.Entity<TimeSheet>()
                .Property(input => input.RatePerHour)
                .HasColumnName("RatePerHour")
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            #endregion

            #region TimeSheetDetail

            builder.Entity<TimeSheetDetail>()
                .HasKey(input => input.TimeSheetDetailId)
                .HasName("PrimaryKey_TimeSheetDetailId");

            builder.Entity<TimeSheetDetail>()
                .Property(input => input.TimeSheetDetailId)
                .HasColumnName("TimeSheetDetailId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<TimeSheetDetail>()
                .Property(input => input.SessionSynopsisNames)
                .HasColumnName("SessionSynopsisNames")
                .HasColumnType("VARCHAR(300)")
                .IsRequired();

            builder.Entity<TimeSheetDetail>()
                .Property(input => input.OfficialTimeInMinutes)
                .HasColumnName("OfficialTimeInMinutes")
                .IsRequired();

            builder.Entity<TimeSheetDetail>()
                .Property(input => input.OfficialTimeOutMinutes)
                .HasColumnName("OfficialTimeOutMinutes")
                .IsRequired();

            builder.Entity<TimeSheetDetail>()
                .Property(input => input.IsReplacementInstructor)
                .HasColumnName("IsReplacementInstructor")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Entity<TimeSheetDetail>()
                .Property(input => input.WageRatePerHour)
                .HasColumnName("WageRatePerHour")
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            #endregion

            #region TimeSheetDetailSignature

            builder.Entity<TimeSheetDetailSignature>()
                .HasKey(input => input.TimeSheetDetailSignatureId)
                .HasName("PrimaryKey_TimeSheetSignatureId");

            builder.Entity<TimeSheetDetailSignature>()
                .Property(input => input.TimeSheetDetailSignatureId)
                .HasColumnName("TimeSheetDetailSignatureId")
                .HasColumnType("INT")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<TimeSheetDetailSignature>()
                .Property(input => input.Signature)
                .HasColumnType("VARBINARY(MAX)")
                .IsRequired(false);

            #endregion

            //
            // Relationship database modeling
            //

//            builder.Entity<ApplicationUser>()
//                .HasMany(e => e.Roles)
//                .WithOne()
//                .HasForeignKey(e => e.UserId)
//                .IsRequired()
//                .OnDelete(DeleteBehavior.Cascade);

            //many-to-one relationship between AccountDetail and CustomerAccount
            //
            builder.Entity<AccountDetail>()
                .HasOne(input => input.CustomerAccount)
                .WithMany(input => input.AccountDetails)
                .HasForeignKey(input => input.CustomerAccountId);

            //
            // Note: InstructorAccount is a join table
            //

            builder.Entity<InstructorAccount>()
                .HasOne(input => input.CustomerAccount)
                .WithMany(input => input.InstructorAccounts)
                .HasForeignKey(input => input.CustomerAccountId);

            builder.Entity<InstructorAccount>()
                .HasOne(input => input.Instructor)
                .WithMany(input => input.InstructorAccounts)
                .HasForeignKey(input => input.InstructorId);

            builder.Entity<TimeSheetDetail>()
                .HasOne(input => input.AccountDetail)
                .WithMany(input => input.TimeSheetDetails)
                .HasForeignKey(input => input.AccountDetailId);

            builder.Entity<TimeSheetDetail>()
                .HasOne(input => input.TimeSheet)
                .WithMany(input => input.TimeSheetDetails)
                .HasForeignKey(input => input.TimeSheetId);

            builder.Entity<TimeSheet>()
                .HasOne(input => input.CreatedBy)
                .WithMany()
                .HasForeignKey(input => input.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<TimeSheet>()
                .HasOne(input => input.ApprovedBy)
                .WithMany()
                .HasForeignKey(input => input.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<TimeSheet>()
                .HasOne(input => input.UpdatedBy)
                .WithMany()
                .HasForeignKey(input => input.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<CustomerAccount>()
                .HasOne(input => input.CreatedBy)
                .WithMany()
                .HasForeignKey(input => input.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<CustomerAccount>()
                .HasOne(input => input.UpdatedBy)
                .WithMany()
                .HasForeignKey(input => input.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<SessionSynopsis>()
                .HasOne(input => input.CreatedBy)
                .WithMany()
                .HasForeignKey(input => input.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<SessionSynopsis>()
                .HasOne(input => input.UpdatedBy)
                .WithMany()
                .HasForeignKey(input => input.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //
            // Define one-to-one relationship between TimeSheetDetail and TimeSheetDetailSignaure
            //
            //Reference: http://stackoverflow.com/questions/35506158/one-to-one-relationships-in-entity-framework-7-code-first
            builder.Entity<TimeSheetDetail>()
                .HasOne(input => input.TimeSheetDetailSignature)
                .WithOne(input => input.TimeSheetDetail)
                .HasForeignKey<TimeSheetDetailSignature>(input => input.TimeSheetIDetailId);

            builder.Entity<TimeSheet>()
                .HasOne(input => input.Instructor)
                .WithMany(input => input.TimeSheets)
                .HasForeignKey(input => input.InstructorId);

            builder.Entity<AccountRate>()
                .HasOne(input => input.CustomerAccount)
                .WithMany(input => input.AccountRates)
                .HasForeignKey(input => input.CustomerAccountId);
        }
    }
}
