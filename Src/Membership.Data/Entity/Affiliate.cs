using System;

namespace Membership.Data
{
    [Serializable]
    public class Affiliate : BaseEntity
    {
        public string Email { get; set; }
        
        //invited user
        public User User { get; set; }
        public int? UserId { get; set; }
        
        public string RefererSource { get; set; }

        public DateTime ActivatedOn { get; set; }
    }
}