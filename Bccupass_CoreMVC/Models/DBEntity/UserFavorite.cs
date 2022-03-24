using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class UserFavorite
    {
        public int FavoritesId { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public DateTime BuildTime { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
    }
}
