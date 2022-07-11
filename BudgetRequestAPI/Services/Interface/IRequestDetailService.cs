using BudgetRequestAPI.DataModel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetRequestAPI.Services.Interface
{
    public interface IRequestDetailService
    {
        Task<List<RequestDetail>> GetAllRequestDetails();

        List<RequestDetail> GetRequestByUserId(int id);

        List<RequestDetail> GetRequestByMangerId(int id);

        Task<List<RequestDetail>> GetHistoryOfRequestByUserId(int id);

        RequestDetail GetRequest(int id);

        Task<int> AddRequest(RequestDetail requestDetail);

        Task<int> UpdateRequest(RequestDetail requestDetail);

        Task<int> DeleteRequest(int id);

        List<RequestDetail> GetRequestDetailsByStatus(int userId,int statusId);

        List<RequestDetail> GetRequestByStatusAndManagerID(int managerId, int statusId);

        Task<int> RequestDecisonByManager(int requestId, int? requestStatus);

        Task<int> RejectionCommentByManager(int id, string Comment);
    }
}
