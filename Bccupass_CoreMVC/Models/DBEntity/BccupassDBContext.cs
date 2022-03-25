using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class BccupassDBContext : DbContext
    {
        public BccupassDBContext()
        {
        }

        public BccupassDBContext(DbContextOptions<BccupassDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityAnnouncement> ActivityAnnouncements { get; set; }
        public virtual DbSet<ActivityIntroImg> ActivityIntroImgs { get; set; }
        public virtual DbSet<ActivityNotification> ActivityNotifications { get; set; }
        public virtual DbSet<ActivityNotificationUser> ActivityNotificationUsers { get; set; }
        public virtual DbSet<ActivityTag> ActivityTags { get; set; }
        public virtual DbSet<ActivityTheme> ActivityThemes { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Organizer> Organizers { get; set; }
        public virtual DbSet<Qa> Qas { get; set; }
        public virtual DbSet<SystemAnnouncement> SystemAnnouncements { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TicketDatail> TicketDatails { get; set; }
        public virtual DbSet<TicketDetailOrderDetail> TicketDetailOrderDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFavorite> UserFavorites { get; set; }
        public virtual DbSet<UserFollowOrganizer> UserFollowOrganizers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=BccupassDB;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.HasComment("活動上架後能改的\r\n活動代表圖\r\n嘉賓\r\n活動參考網址、活動參考網址描述\r\n活動描述\r\n\r\n活動上架後能改的 -> 但要發公告\r\n活動名稱\r\n開始、結束時間\r\n活動簡介\r\n活動注意事項\r\n\r\n活動開始後不能改的 -> 全部欄位、只能發公告");

                entity.Property(e => e.ActivityId)
                    .ValueGeneratedNever()
                    .HasComment("活動Id");

                entity.Property(e => e.ActivityDescription)
                    .IsRequired()
                    .HasComment("活動描述");

                entity.Property(e => e.ActivityIntro)
                    .IsRequired()
                    .HasComment("活動簡介");

                entity.Property(e => e.ActivityNotes)
                    .HasMaxLength(500)
                    .HasComment("活動注意事項");

                entity.Property(e => e.ActivityRefWebUrl).HasComment("活動參考網址");

                entity.Property(e => e.ActivityState).HasComment("活動狀態\r\n0: 草稿\r\n1: 已上架\r\n2: 已下架\r\n3: 已結束\r\n4: 已刪除 IDelete\r\n");

                entity.Property(e => e.Address).HasComment("線下活動: 活動地址(詳細地址)");

                entity.Property(e => e.AddressDescription).HasComment("Enum 線下活動: 活動地址(地址描述:甚麼大樓、甚麼展館)");

                entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasComment("Enum 線下活動: 活動地址(縣市)");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("活動建立時間");

                entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasComment("Enum 線下活動: 活動地址(行政區)");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("活動結束時間");

                entity.Property(e => e.FormAddress).HasComment("地址");

                entity.Property(e => e.FormAge).HasComment("年齡");

                entity.Property(e => e.FormBirthday).HasComment("生日");

                entity.Property(e => e.FormConpanyName).HasComment("公司名稱");

                entity.Property(e => e.FormDepartment).HasComment("enum部門");

                entity.Property(e => e.FormDiningNeeds).HasComment("0: 全素, 1: 蛋奶素, 2: 不吃豬, 3: 不吃牛");

                entity.Property(e => e.FormEducationLevel).HasComment("0: 國小, 1:國中, 2:高中高職, 3:大學專科 4, 研究所, 5: 博士");

                entity.Property(e => e.FormEmail).HasComment("電子郵件");

                entity.Property(e => e.FormFax).HasComment("傳真");

                entity.Property(e => e.FormGender).HasComment("0: Female, 1:Male");

                entity.Property(e => e.FormHobby).HasComment("興趣");

                entity.Property(e => e.FormIdnumber)
                    .HasColumnName("FormIDNumber")
                    .HasComment("身分證字號");

                entity.Property(e => e.FormIndustry).HasComment("enum產業");

                entity.Property(e => e.FormJobTitle).HasComment("職稱");

                entity.Property(e => e.FormMaritalStatus).HasComment("0: Single, 1: Engaged, 2: Married");

                entity.Property(e => e.FormMonthlyIncome).HasComment("月收入");

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("姓名");

                entity.Property(e => e.FormPhone).HasComment("電話");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasComment("活動主圖");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("活動名稱");

                entity.Property(e => e.OrganizerId).HasComment("主辦方Id");

                entity.Property(e => e.RefWebDescription)
                    .HasMaxLength(50)
                    .HasComment("活動參考網址描述");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("活動開始時間");

                entity.HasOne(d => d.ActivityPrimaryTheme)
                    .WithMany(p => p.ActivityActivityPrimaryThemes)
                    .HasForeignKey(d => d.ActivityPrimaryThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ActivityTheme");

                entity.HasOne(d => d.ActivitySecondTheme)
                    .WithMany(p => p.ActivityActivitySecondThemes)
                    .HasForeignKey(d => d.ActivitySecondThemeId)
                    .HasConstraintName("FK_Activity_ActivityTheme1");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ActivityType");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.OrganizerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Organizer");
            });

            modelBuilder.Entity<ActivityAnnouncement>(entity =>
            {
                entity.HasKey(e => e.AnnouncementId)
                    .HasName("PK_活動公告");

                entity.ToTable("ActivityAnnouncement");

                entity.Property(e => e.AnnouncementId)
                    .ValueGeneratedNever()
                    .HasComment("活動公告PK");

                entity.Property(e => e.ActivityId).HasComment("活動FK");

                entity.Property(e => e.AnnouncementContent)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("活動公告內容");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("發布時間");

                entity.Property(e => e.Sort).HasComment("公告順序");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityAnnouncements)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAnnouncement_Activity");
            });

            modelBuilder.Entity<ActivityIntroImg>(entity =>
            {
                entity.HasKey(e => e.ActivityIntroImageId)
                    .HasName("PK_活動簡介圖片");

                entity.ToTable("ActivityIntroImg");

                entity.Property(e => e.ActivityIntroImageId)
                    .ValueGeneratedNever()
                    .HasComment("活動簡介圖片PK");

                entity.Property(e => e.ActivityId).HasComment("活動FK");

                entity.Property(e => e.ActivityIntroImage)
                    .IsRequired()
                    .HasComment("活動簡介圖片");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityIntroImgs)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityIntroImg_Activity");
            });

            modelBuilder.Entity<ActivityNotification>(entity =>
            {
                entity.ToTable("ActivityNotification");

                entity.Property(e => e.ActivityNotificationId)
                    .ValueGeneratedNever()
                    .HasComment("活動通知Id");

                entity.Property(e => e.ActiveNotificationStatus).HasComment("活動通知狀態");

                entity.Property(e => e.ActivityId).HasComment("活動Id");

                entity.Property(e => e.BuildTime)
                    .HasColumnType("datetime")
                    .HasComment("編輯時間");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasComment("目標Email");

                entity.Property(e => e.EmailContent)
                    .IsRequired()
                    .HasComment("Email內容");

                entity.Property(e => e.LettersSubject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Email主題");

                entity.Property(e => e.SendTime)
                    .HasColumnType("datetime")
                    .HasComment("發送時間");
            });

            modelBuilder.Entity<ActivityNotificationUser>(entity =>
            {
                entity.ToTable("ActivityNotificationUser");

                entity.Property(e => e.ActivityNotificationUserId).ValueGeneratedNever();

                entity.HasOne(d => d.ActivityNotification)
                    .WithMany(p => p.ActivityNotificationUsers)
                    .HasForeignKey(d => d.ActivityNotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityNotificationUser_ActivityNotification");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityNotificationUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityNotificationUser_User");
            });

            modelBuilder.Entity<ActivityTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ActivityTag");

                entity.HasComment("");

                entity.Property(e => e.ActivityId).HasComment("活動ID");

                entity.Property(e => e.TagId).HasComment("活動標籤ID");

                entity.HasOne(d => d.Activity)
                    .WithMany()
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityTag_Activity1");

                entity.HasOne(d => d.Tag)
                    .WithMany()
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityTag_Tag");
            });

            modelBuilder.Entity<ActivityTheme>(entity =>
            {
                entity.ToTable("ActivityTheme");

                entity.Property(e => e.ActivityThemeId)
                    .ValueGeneratedNever()
                    .HasComment("活動主題PK");

                entity.Property(e => e.ActivityThemeImage)
                    .IsRequired()
                    .HasComment("活動主題圖片");

                entity.Property(e => e.ActivityThemeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("活動主題名稱(0:戶外,1:學習,2:親子,3.寵物,4.科技,5.商業,6.創業,7.投資,8.設計,9.藝文,10.手作,11.美食,12.攝影,13.遊戲,14.運動,15.健康,16.音樂,17.電影)");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.ToTable("ActivityType");

                entity.Property(e => e.ActivityTypeId).ValueGeneratedNever();

                entity.Property(e => e.TypeImg).IsRequired();

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Comment");

                entity.Property(e => e.ActivityId).HasComment("活動Id");

                entity.Property(e => e.BuildTime)
                    .HasColumnType("datetime")
                    .HasComment("編輯時間");

                entity.Property(e => e.Comment1)
                    .HasColumnName("Comment")
                    .HasComment("評論內容");

                entity.Property(e => e.CommentId).HasComment("評論Id");

                entity.Property(e => e.StarRank).HasComment("星級評等");

                entity.Property(e => e.UserId).HasComment("UserId");

                entity.HasOne(d => d.Activity)
                    .WithMany()
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Activity");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("Guest");

                entity.Property(e => e.GuestId)
                    .ValueGeneratedNever()
                    .HasComment("嘉賓ID");

                entity.Property(e => e.ActivityId).HasComment("活動ID");

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .HasComment("公司名稱");

                entity.Property(e => e.Describe)
                    .IsRequired()
                    .HasComment("敘述");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("姓名");

                entity.Property(e => e.Photo).HasComment("照片");

                entity.Property(e => e.SocialLink).HasComment("相關連結");

                entity.Property(e => e.Sort).HasComment("排序");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .HasComment("職稱");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_Activity");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.HasComment("");

                entity.Property(e => e.OrderDetailId).ValueGeneratedNever();

                entity.Property(e => e.OrderState).HasComment("訂單狀態 0: 未付款, 1: 已付款/已報名, 2: 已取消,3: 以退票");

                entity.Property(e => e.OrderTime).HasComment("訂單建立時間");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Activity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_User");
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.ToTable("Organizer");

                entity.Property(e => e.OrganizerId)
                    .ValueGeneratedNever()
                    .HasComment("主辦Id");

                entity.Property(e => e.Banner).IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("主辦簡介");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasComment("主辦聯絡Email");

                entity.Property(e => e.FacebookWebsite).HasComment("主辦FaceBook");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasComment("主辦圖像");

                entity.Property(e => e.InstagramWebsite).HasComment("主辦Instagram");

                entity.Property(e => e.MediumWebsite).HasComment("主辦Medium");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("主辦名");

                entity.Property(e => e.OfficialWebsite).HasComment("主辦官網");

                entity.Property(e => e.OrganizerWebQuery).HasComment("主辦網站查詢");

                entity.Property(e => e.Telphone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("主辦連絡電話");

                entity.Property(e => e.UserId).HasComment("UserId");

                entity.Property(e => e.YoutubeWebsite).HasComment("主辦Youtube");
            });

            modelBuilder.Entity<Qa>(entity =>
            {
                entity.ToTable("QA");

                entity.Property(e => e.QaId)
                    .ValueGeneratedNever()
                    .HasComment("常見問題ID");

                entity.Property(e => e.ActivityId).HasComment("活動ID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasComment("回答");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasComment("問題");

                entity.Property(e => e.Sort).HasComment("排序");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Qas)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QA_Activity");
            });

            modelBuilder.Entity<SystemAnnouncement>(entity =>
            {
                entity.ToTable("SystemAnnouncement");

                entity.Property(e => e.SystemAnnouncementId)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemAnnouncementID")
                    .HasComment("系統公告PK");

                entity.Property(e => e.ReleaseTime)
                    .HasColumnType("datetime")
                    .HasComment("發佈時間");

                entity.Property(e => e.SystemAnnouncementContent)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasComment("系統公告內容");

                entity.Property(e => e.SystemAnnouncementTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("系統公告標題");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.HasComment("活動標籤名稱");

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("標籤名稱");
            });

            modelBuilder.Entity<TicketDatail>(entity =>
            {
                entity.ToTable("TicketDatail");

                entity.Property(e => e.TicketDatailId)
                    .ValueGeneratedNever()
                    .HasComment("(PK)票卷設定Id");

                entity.Property(e => e.BuyLimitLeast).HasComment("最少購賣數量限制");

                entity.Property(e => e.BuyLimitMost).HasComment("最多購買數量限制");

                entity.Property(e => e.CheckEndTime)
                    .HasColumnType("datetime")
                    .HasComment("結束驗票時間");

                entity.Property(e => e.CheckStartTime)
                    .HasColumnType("datetime")
                    .HasComment("開始驗票時間");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("票卷說明");

                entity.Property(e => e.IsSell).HasComment("是否開賣");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("價格");

                entity.Property(e => e.Quantity).HasComment("數量(庫存)");

                entity.Property(e => e.SellEndTime)
                    .HasColumnType("datetime")
                    .HasComment("結束販賣時間");

                entity.Property(e => e.SellStartTime)
                    .HasColumnType("datetime")
                    .HasComment("開始販賣時間");

                entity.Property(e => e.TicketGroup).HasMaxLength(50);

                entity.Property(e => e.TicketName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("票卷名稱");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TicketDatails)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketDatail_Activity");
            });

            modelBuilder.Entity<TicketDetailOrderDetail>(entity =>
            {
                entity.ToTable("TicketDetailOrderDetail");

                entity.Property(e => e.TicketDetailOrderDetailId).ValueGeneratedNever();

                entity.Property(e => e.BuyerAddress).HasMaxLength(50);

                entity.Property(e => e.BuyerBirthday).HasColumnType("datetime");

                entity.Property(e => e.BuyerConpanyName).HasMaxLength(50);

                entity.Property(e => e.BuyerDepartment).HasComment("enum");

                entity.Property(e => e.BuyerDiningNeeds).HasComment("0: 全素, 1: 蛋奶素, 2: 不吃豬, 3: 不吃牛");

                entity.Property(e => e.BuyerEducationLevel).HasComment("0: 國小, 1:國中, 2:高中高職, 3:大學專科 4, 研究所, 5: 博士");

                entity.Property(e => e.BuyerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BuyerFax)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.BuyerGender).HasComment("0: Female, 1:Male");

                entity.Property(e => e.BuyerHobby).HasMaxLength(50);

                entity.Property(e => e.BuyerIdnumber)
                    .HasMaxLength(10)
                    .HasColumnName("BuyerIDNumber")
                    .IsFixedLength(true);

                entity.Property(e => e.BuyerIndustry).HasComment("enum");

                entity.Property(e => e.BuyerJobTitle).HasMaxLength(50);

                entity.Property(e => e.BuyerMaritalStatus).HasComment("0: Single, 1: Engaged, 2: Married");

                entity.Property(e => e.BuyerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BuyerPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UniPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.TicketDetailOrderDetails)
                    .HasForeignKey(d => d.OrderDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketDetailOrderDetail_OrderDetail");

                entity.HasOne(d => d.TicketDetail)
                    .WithMany(p => p.TicketDetailOrderDetails)
                    .HasForeignKey(d => d.TicketDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketDetailOrderDetail_TicketDatail");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasComment("使用者ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasComment("居住地");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .HasComment("顯示名稱");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasComment("電子郵件");

                entity.Property(e => e.Gender).HasComment("性別(true=男 False=女)");

                entity.Property(e => e.Job).HasComment("醫療產業");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("姓名");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true)
                    .HasComment("密碼");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .HasComment("電話");

                entity.Property(e => e.Photo).HasComment("大頭照");

                entity.Property(e => e.Relationship).HasComment("感情狀態(Enum 1:單身 2. 有穩定交往對象 3.已婚)");

                entity.Property(e => e.Verification).HasComment("帳號驗證");
            });

            modelBuilder.Entity<UserFavorite>(entity =>
            {
                entity.HasKey(e => e.FavoritesId);

                entity.Property(e => e.FavoritesId)
                    .ValueGeneratedNever()
                    .HasComment("使用者收藏Id");

                entity.Property(e => e.ActivityId).HasComment("活動Id");

                entity.Property(e => e.BuildTime)
                    .HasColumnType("datetime")
                    .HasComment("編輯時間");

                entity.Property(e => e.UserId).HasComment("UserId");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFavorites_Activity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFavorites_User");
            });

            modelBuilder.Entity<UserFollowOrganizer>(entity =>
            {
                entity.ToTable("UserFollowOrganizer");

                entity.Property(e => e.UserFollowOrganizerId)
                    .ValueGeneratedNever()
                    .HasComment("使用者追蹤主辦ID");

                entity.Property(e => e.BuildTime).HasColumnType("datetime");

                entity.Property(e => e.OrganizerId).HasComment("主辦ID");

                entity.Property(e => e.UserId).HasComment("使用者ID");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.UserFollowOrganizers)
                    .HasForeignKey(d => d.OrganizerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFollowOrganizer_Organizer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFollowOrganizers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFollowOrganizer_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
