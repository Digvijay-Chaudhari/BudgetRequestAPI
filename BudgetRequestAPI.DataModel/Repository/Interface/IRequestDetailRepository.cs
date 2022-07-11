using BudgetRequestAPI.DataModel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetRequestAPI.DataModel.Repository.Interface
{
    public interface IRequestDetailRepository
    {
        Task<List<RequestDetail>> GetAllRequestDetails();

        List<RequestDetail> GetRequestByUserId(int id);

        List<RequestDetail> GetRequestByMangerId(int id);

        Task<List<RequestDetail>> GetHistoryOfRequestByUserId(int id);

        RequestDetail GetRequest(int id);

        Task<int> AddRequest(RequestDetail requestDetail);

        Task<int> UpdateRequest(RequestDetail requestDetail);

        Task<int> DeleteRequest(int id);

        Task<int> RequestDecisonByManager(int requestId, int? statusId);

        Task<int> RejectionCommentByManager(int id, string comment);
    }
}
