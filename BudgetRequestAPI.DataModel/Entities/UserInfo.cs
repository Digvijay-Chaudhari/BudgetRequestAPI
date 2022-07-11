using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetRequestAPI.DataModel.Entities
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            ForwordedRequestDetails = new HashSet<ForwordedRequestDetail>();
            RequestDetails = new HashSet<RequestDetail>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Designation { get; set; }
        public int? ManagerId { get; set; }
        public bool? IsManager { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ForwordedRequestDetail> ForwordedRequestDetails { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
