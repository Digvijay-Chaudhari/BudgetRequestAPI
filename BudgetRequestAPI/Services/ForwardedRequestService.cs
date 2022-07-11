using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Repository.Interface;
using BudgetRequestAPI.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetRequestAPI.Services
{
    public class ForwardedRequestService : IForwardedRequestService
    {
        private readonly IForwardedRequestRepository _forwardedRequestRepository;

        public ForwardedRequestService(IForwardedRequestRepository forwardedRequestRepository)
        {
            _forwardedRequestRepository = forwardedRequestRepository;
        }

        public async Task<int> AddForwardedRequest(ForwordedRequestDetail requestDetail)
        {
            return await _forwardedRequestRepository.AddForwordedRequest(requestDetail);
        }

        public  List<ForwordedRequestDetail> GetForwadedRequests(int managerId, int statusID)
        {
            return _forwardedRequestRepository.GetForwadedRequests(managerId,statusID);
        }

        public async Task<int> RequestDecisonBySupManager(int requestId, int status)
        {
            return await _forwardedRequestRepository.RequestDecisonBySupManager(requestId, status);
        }

        public async Task<int> RejectionCommentByManager(int requestId, string comment)
        {
            return await _forwardedRequestRepository.RejectionCommentByManager(requestId, comment);
        }

        public ForwordedRequestDetail GetForwardedRequest(int id)
        {
            return  _forwardedRequestRepository.GetForwardedRequest(id);
        }


    }
}
