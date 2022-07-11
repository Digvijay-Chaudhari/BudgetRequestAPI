using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRequestAPI.ServiceModel.DTO.Request
{
    public class ForwardedRequestDTO
    {
        public int? RequestId { get; set; }
        public int? UserId { get; set; }
        public int? SuperManagerId { get; set; }
        public int? ManagerId { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public int? EstAmount { get; set; }
        public int? AdvAmount { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? RequestStatus { get; set; }
        public string Comments { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
