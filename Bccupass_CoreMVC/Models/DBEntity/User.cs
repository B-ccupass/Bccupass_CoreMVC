using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class User
    {
        public User()
        {
            ActivityNotificationUsers = new HashSet<ActivityNotificationUser>();
            OrderDetails = new HashSet<OrderDetail>();
            UserFavorites = new HashSet<UserFavorite>();
            UserFollowOrganizers = new HashSet<UserFollowOrganizer>();
        }

        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public int? Relationship { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int? Job { get; set; }
        public bool Verification { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<ActivityNotificationUser> ActivityNotificationUsers { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
        public virtual ICollection<UserFollowOrganizer> UserFollowOrganizers { get; set; }
    }
}
