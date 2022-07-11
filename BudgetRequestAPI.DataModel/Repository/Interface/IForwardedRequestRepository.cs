using BudgetRequestAPI.DataModel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetRequestAPI.DataModel.Repository.Interface
{
    public interface IForwardedRequestRepository
    {
        Task<int> AddForwordedRequest(ForwordedRequestDetail requestDetail);

        List<ForwordedRequestDetail> GetForwadedRequests(int managerId, int statusId);

        Task<int> RequestDecisonBySupManager(int requestId, int status);

        Task<int> RejectionCommentByManager(int requestId, string comment);

        ForwordedRequestDetail GetForwardedRequest(int id);
    }
}
