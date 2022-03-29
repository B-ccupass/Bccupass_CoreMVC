using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bccupass_CoreMVC.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityNotification",
                columns: table => new
                {
                    ActivityNotificationId = table.Column<int>(type: "int", nullable: false, comment: "活動通知Id"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動Id"),
                    ActiveNotificationStatus = table.Column<int>(type: "int", nullable: false, comment: "活動通知狀態"),
                    LettersSubject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Email主題"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "目標Email"),
                    BuildTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "編輯時間"),
                    SendTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "發送時間"),
                    EmailContent = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Email內容")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityNotification", x => x.ActivityNotificationId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTheme",
                columns: table => new
                {
                    ActivityThemeId = table.Column<int>(type: "int", nullable: false, comment: "活動主題PK"),
                    ActivityThemeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "活動主題名稱(0:戶外,1:學習,2:親子,3.寵物,4.科技,5.商業,6.創業,7.投資,8.設計,9.藝文,10.手作,11.美食,12.攝影,13.遊戲,14.運動,15.健康,16.音樂,17.電影)"),
                    ActivityThemeImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "活動主題圖片")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTheme", x => x.ActivityThemeId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeImg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    OrganizerId = table.Column<int>(type: "int", nullable: false, comment: "主辦Id"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "UserId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "主辦名"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "主辦圖像"),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "主辦簡介"),
                    Telphone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "主辦連絡電話"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "主辦聯絡Email"),
                    OfficialWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主辦官網"),
                    FacebookWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主辦FaceBook"),
                    InstagramWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主辦Instagram"),
                    YoutubeWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主辦Youtube"),
                    MediumWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主辦Medium"),
                    OrganizerWebQuery = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主辦網站查詢")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.OrganizerId);
                });

            migrationBuilder.CreateTable(
                name: "SystemAnnouncement",
                columns: table => new
                {
                    SystemAnnouncementID = table.Column<int>(type: "int", nullable: false, comment: "系統公告PK"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "發佈時間"),
                    SystemAnnouncementTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "系統公告標題"),
                    SystemAnnouncementContent = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, comment: "系統公告內容")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAnnouncement", x => x.SystemAnnouncementID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "標籤名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                },
                comment: "活動標籤名稱");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "顯示名稱"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "大頭照"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "電子郵件"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "姓名"),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false, comment: "生日"),
                    Gender = table.Column<bool>(type: "bit", nullable: false, comment: "性別(true=男 False=女)"),
                    Relationship = table.Column<int>(type: "int", nullable: true, comment: "感情狀態(Enum 1:單身 2. 有穩定交往對象 3.已婚)"),
                    Phone = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false, comment: "電話"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "居住地"),
                    Password = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false, comment: "密碼"),
                    Job = table.Column<int>(type: "int", nullable: true, comment: "醫療產業"),
                    Verification = table.Column<bool>(type: "bit", nullable: false, comment: "帳號驗證")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動Id"),
                    ActivityPrimaryThemeId = table.Column<int>(type: "int", nullable: false),
                    ActivitySecondThemeId = table.Column<int>(type: "int", nullable: true),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false, comment: "主辦方Id"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "活動名稱"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "活動主圖"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "活動開始時間"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "活動結束時間"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "活動建立時間"),
                    ActivityRefWebUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "活動參考網址"),
                    RefWebDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "活動參考網址描述"),
                    ActivityIntro = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "活動簡介"),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "活動描述"),
                    ActivityNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "活動注意事項"),
                    ActivityState = table.Column<int>(type: "int", nullable: false, comment: "活動狀態\r\n0: 草稿\r\n1: 已上架\r\n2: 已下架\r\n3: 已結束\r\n4: 已刪除 IDelete\r\n"),
                    City = table.Column<int>(type: "int", nullable: true, comment: "Enum 線下活動: 活動地址(縣市)"),
                    District = table.Column<int>(type: "int", nullable: true, comment: "Enum 線下活動: 活動地址(行政區)"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "線下活動: 活動地址(詳細地址)"),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Enum 線下活動: 活動地址(地址描述:甚麼大樓、甚麼展館)"),
                    StreamingWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "姓名"),
                    FormEmail = table.Column<bool>(type: "bit", nullable: false, comment: "電子郵件"),
                    FormPhone = table.Column<bool>(type: "bit", nullable: false, comment: "電話"),
                    FormBirthday = table.Column<bool>(type: "bit", nullable: false, comment: "生日"),
                    FormAddress = table.Column<bool>(type: "bit", nullable: false, comment: "地址"),
                    FormGender = table.Column<bool>(type: "bit", nullable: false, comment: "0: Female, 1:Male"),
                    FormAge = table.Column<bool>(type: "bit", nullable: false, comment: "年齡"),
                    FormHobby = table.Column<bool>(type: "bit", nullable: false, comment: "興趣"),
                    FormMaritalStatus = table.Column<bool>(type: "bit", nullable: false, comment: "0: Single, 1: Engaged, 2: Married"),
                    FormIndustry = table.Column<bool>(type: "bit", nullable: false, comment: "enum產業"),
                    FormDepartment = table.Column<bool>(type: "bit", nullable: false, comment: "enum部門"),
                    FormMonthlyIncome = table.Column<bool>(type: "bit", nullable: false, comment: "月收入"),
                    FormIDNumber = table.Column<bool>(type: "bit", nullable: false, comment: "身分證字號"),
                    FormFax = table.Column<bool>(type: "bit", nullable: false, comment: "傳真"),
                    FormEducationLevel = table.Column<bool>(type: "bit", nullable: false, comment: "0: 國小, 1:國中, 2:高中高職, 3:大學專科 4, 研究所, 5: 博士"),
                    FormDiningNeeds = table.Column<bool>(type: "bit", nullable: false, comment: "0: 全素, 1: 蛋奶素, 2: 不吃豬, 3: 不吃牛"),
                    FormConpanyName = table.Column<bool>(type: "bit", nullable: false, comment: "公司名稱"),
                    FormJobTitle = table.Column<bool>(type: "bit", nullable: false, comment: "職稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityTheme",
                        column: x => x.ActivityPrimaryThemeId,
                        principalTable: "ActivityTheme",
                        principalColumn: "ActivityThemeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityTheme1",
                        column: x => x.ActivitySecondThemeId,
                        principalTable: "ActivityTheme",
                        principalColumn: "ActivityThemeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityType",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Organizer",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "OrganizerId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "活動上架後能改的\r\n活動代表圖\r\n嘉賓\r\n活動參考網址、活動參考網址描述\r\n活動描述\r\n\r\n活動上架後能改的 -> 但要發公告\r\n活動名稱\r\n開始、結束時間\r\n活動簡介\r\n活動注意事項\r\n\r\n活動開始後不能改的 -> 全部欄位、只能發公告");

            migrationBuilder.CreateTable(
                name: "ActivityNotificationUser",
                columns: table => new
                {
                    ActivityNotificationUserId = table.Column<int>(type: "int", nullable: false),
                    ActivityNotificationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityNotificationUser", x => x.ActivityNotificationUserId);
                    table.ForeignKey(
                        name: "FK_ActivityNotificationUser_ActivityNotification",
                        column: x => x.ActivityNotificationId,
                        principalTable: "ActivityNotification",
                        principalColumn: "ActivityNotificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityNotificationUser_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFollowOrganizer",
                columns: table => new
                {
                    UserFollowOrganizerId = table.Column<int>(type: "int", nullable: false, comment: "使用者追蹤主辦ID"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    OrganizerId = table.Column<int>(type: "int", nullable: false, comment: "主辦ID"),
                    BuildTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowOrganizer", x => x.UserFollowOrganizerId);
                    table.ForeignKey(
                        name: "FK_UserFollowOrganizer_Organizer",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "OrganizerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFollowOrganizer_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityAnnouncement",
                columns: table => new
                {
                    AnnouncementId = table.Column<int>(type: "int", nullable: false, comment: "活動公告PK"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動FK"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "公告順序"),
                    AnnouncementContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "活動公告內容"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "發布時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_活動公告", x => x.AnnouncementId);
                    table.ForeignKey(
                        name: "FK_EventAnnouncement_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityIntroImg",
                columns: table => new
                {
                    ActivityIntroImageId = table.Column<int>(type: "int", nullable: false, comment: "活動簡介圖片PK"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動FK"),
                    ActivityIntroImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "活動簡介圖片")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_活動簡介圖片", x => x.ActivityIntroImageId);
                    table.ForeignKey(
                        name: "FK_ActivityIntroImg_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTag",
                columns: table => new
                {
                    ActivityTagId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false, comment: "活動標籤ID"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動ID")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ActivityTag_Activity1",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityTag_Tag",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false, comment: "評論Id"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "UserId"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動Id"),
                    BuildTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "編輯時間"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "評論內容"),
                    StarRank = table.Column<int>(type: "int", nullable: false, comment: "星級評等")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Comment_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false, comment: "嘉賓ID"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "姓名"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "照片"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "職稱"),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "公司名稱"),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "敘述"),
                    SocialLink = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "相關連結"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動ID"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guest_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<int>(type: "int", nullable: false, comment: "訂單建立時間"),
                    OrderState = table.Column<int>(type: "int", nullable: false, comment: "訂單狀態 0: 未付款, 1: 已付款/已報名, 2: 已取消,3: 以退票")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "");

            migrationBuilder.CreateTable(
                name: "QA",
                columns: table => new
                {
                    QaId = table.Column<int>(type: "int", nullable: false, comment: "常見問題ID"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "問題"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "回答"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QA", x => x.QaId);
                    table.ForeignKey(
                        name: "FK_QA_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketDatail",
                columns: table => new
                {
                    TicketDatailId = table.Column<int>(type: "int", nullable: false, comment: "(PK)票卷設定Id"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "票卷名稱"),
                    TicketGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "數量(庫存)"),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false, comment: "價格"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "票卷說明"),
                    SellStartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "開始販賣時間"),
                    SellEndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "結束販賣時間"),
                    CheckStartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "開始驗票時間"),
                    CheckEndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "結束驗票時間"),
                    IsSell = table.Column<bool>(type: "bit", nullable: false, comment: "是否開賣"),
                    BuyLimitLeast = table.Column<int>(type: "int", nullable: false, comment: "最少購賣數量限制"),
                    BuyLimitMost = table.Column<int>(type: "int", nullable: false, comment: "最多購買數量限制")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDatail", x => x.TicketDatailId);
                    table.ForeignKey(
                        name: "FK_TicketDatail_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    FavoritesId = table.Column<int>(type: "int", nullable: false, comment: "使用者收藏Id"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "UserId"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "活動Id"),
                    BuildTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "編輯時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.FavoritesId);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFavorites_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketDetailOrderDetail",
                columns: table => new
                {
                    TicketDetailOrderDetailId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    TicketDetailId = table.Column<int>(type: "int", nullable: false),
                    CheckStatus = table.Column<bool>(type: "bit", nullable: false),
                    UniPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    BuyerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuyerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuyerPhone = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    BuyerBirthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    BuyerAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuyerGender = table.Column<int>(type: "int", nullable: true, comment: "0: Female, 1:Male"),
                    BuyerAge = table.Column<int>(type: "int", nullable: true),
                    BuyerHobby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuyerMaritalStatus = table.Column<int>(type: "int", nullable: true, comment: "0: Single, 1: Engaged, 2: Married"),
                    BuyerIndustry = table.Column<int>(type: "int", nullable: true, comment: "enum"),
                    BuyerDepartment = table.Column<int>(type: "int", nullable: true, comment: "enum"),
                    BuyerMonthlyIncome = table.Column<int>(type: "int", nullable: true),
                    BuyerIDNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    BuyerFax = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    BuyerEducationLevel = table.Column<int>(type: "int", nullable: true, comment: "0: 國小, 1:國中, 2:高中高職, 3:大學專科 4, 研究所, 5: 博士"),
                    BuyerDiningNeeds = table.Column<int>(type: "int", nullable: true, comment: "0: 全素, 1: 蛋奶素, 2: 不吃豬, 3: 不吃牛"),
                    BuyerConpanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuyerJobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetailOrderDetail", x => x.TicketDetailOrderDetailId);
                    table.ForeignKey(
                        name: "FK_TicketDetailOrderDetail_OrderDetail",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetail",
                        principalColumn: "OrderDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketDetailOrderDetail_TicketDatail",
                        column: x => x.TicketDetailId,
                        principalTable: "TicketDatail",
                        principalColumn: "TicketDatailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityPrimaryThemeId",
                table: "Activity",
                column: "ActivityPrimaryThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivitySecondThemeId",
                table: "Activity",
                column: "ActivitySecondThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityTypeId",
                table: "Activity",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_OrganizerId",
                table: "Activity",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAnnouncement_ActivityId",
                table: "ActivityAnnouncement",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityIntroImg_ActivityId",
                table: "ActivityIntroImg",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityNotificationUser_ActivityNotificationId",
                table: "ActivityNotificationUser",
                column: "ActivityNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityNotificationUser_UserId",
                table: "ActivityNotificationUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTag_ActivityId",
                table: "ActivityTag",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTag_TagId",
                table: "ActivityTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ActivityId",
                table: "Comment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_ActivityId",
                table: "Guest",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ActivityId",
                table: "OrderDetail",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_UserId",
                table: "OrderDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QA_ActivityId",
                table: "QA",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDatail_ActivityId",
                table: "TicketDatail",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetailOrderDetail_OrderDetailId",
                table: "TicketDetailOrderDetail",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetailOrderDetail_TicketDetailId",
                table: "TicketDetailOrderDetail",
                column: "TicketDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_ActivityId",
                table: "UserFavorites",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowOrganizer_OrganizerId",
                table: "UserFollowOrganizer",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowOrganizer_UserId",
                table: "UserFollowOrganizer",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityAnnouncement");

            migrationBuilder.DropTable(
                name: "ActivityIntroImg");

            migrationBuilder.DropTable(
                name: "ActivityNotificationUser");

            migrationBuilder.DropTable(
                name: "ActivityTag");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "QA");

            migrationBuilder.DropTable(
                name: "SystemAnnouncement");

            migrationBuilder.DropTable(
                name: "TicketDetailOrderDetail");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserFollowOrganizer");

            migrationBuilder.DropTable(
                name: "ActivityNotification");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "TicketDatail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "ActivityTheme");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Organizer");
        }
    }
}
