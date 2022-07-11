using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetRequestAPI.DataModel.Repository
{
    public class ForwardedRequestRepository : IForwardedRequestRepository
    {
        private readonly Budget_RequestContext _context;

        public ForwardedRequestRepository(Budget_RequestContext context)
        {
            _context = context;
        }

        public async Task<int> AddForwordedRequest(ForwordedRequestDetail requestDetail)
        {
            _context.ForwordedRequestDetails.Add(requestDetail);
            await _context.SaveChangesAsync();
            return 1;
        }

        public List<ForwordedRequestDetail> GetForwadedRequests(int managerId, int statusId)
        {
            if (statusId == 3)
            {
                var Request = _context.ForwordedRequestDetails.Where(x => x.SuperManagerId == managerId && x.RequestStatus == statusId).OrderByDescending(x => x.ForwordedRequestId).ToList();
                if (Request != null)
                {
                    return Request;
                }
                return null;
            }
            else
            {
                var Request = _context.ForwordedRequestDetails.Where(x => x.SuperManagerId == managerId && x.RequestStatus != 3).OrderByDescending(x => x.ForwordedRequestId).ToList();
                if (Request != null)
                {
                    return Request;
                }
                return null;
            }

        }

        public async Task<int> RequestDecisonBySupManager(int requestId, int status)
        {
            var requestDetail = new ForwordedRequestDetail { ForwordedRequestId = requestId, RequestStatus = status };
            _context.ForwordedRequestDetails.Attach(requestDetail).Property(x => x.RequestStatus).IsModified = true;
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> RejectionCommentByManager(int requestId, string comment)
        {
            var requestDetail = new ForwordedRequestDetail { ForwordedRequestId = requestId, Comments = comment };
            _context.ForwordedRequestDetails.Attach(requestDetail).Property(x => x.Comments).IsModified = true;
            await _context.SaveChangesAsync();
            return 1;
        }

        public ForwordedRequestDetail GetForwardedRequest(int id)
        {
            return _context.ForwordedRequestDetails.FirstOrDefault(x => x.ForwordedRequestId == id && x.IsDeleted == false);

        }
    }
}
