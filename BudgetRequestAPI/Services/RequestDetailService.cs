using AutoMapper;
using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Repository.Interface;
using BudgetRequestAPI.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetRequestAPI.Services
{
    public class RequestDetailService : IRequestDetailService
    {
        private readonly IRequestDetailRepository _requestDetailRepository;
        private readonly IMapper _mapper;

        public RequestDetailService(IRequestDetailRepository requestDetailRepository, IMapper mapper)
        {
            _requestDetailRepository = requestDetailRepository;

        }

        public async Task<List<RequestDetail>> GetAllRequestDetails()
        {
            return await _requestDetailRepository.GetAllRequestDetails();
        }

        public List<RequestDetail> GetRequestByUserId(int id)
        {
            return _requestDetailRepository.GetRequestByUserId(id);
        }

        public List<RequestDetail> GetRequestByMangerId(int id)
        {
            return _requestDetailRepository.GetRequestByMangerId(id);
        }

        public async Task<List<RequestDetail>> GetHistoryOfRequestByUserId(int id)
        {
            return await _requestDetailRepository.GetHistoryOfRequestByUserId(id);
        }


        public async Task<int> AddRequest(RequestDetail requestDetail)
        {
            return await _requestDetailRepository.AddRequest(requestDetail);
        }

        public async Task<int> UpdateRequest(RequestDetail requestDetail)
        {
            return await _requestDetailRepository.UpdateRequest(requestDetail);
        }

        public RequestDetail GetRequest(int id)
        {
            return _requestDetailRepository.GetRequest(id);
        }

        public async Task<int> DeleteRequest(int id)
        {
            return await _requestDetailRepository.DeleteRequest(id);
        }

        public List<RequestDetail> GetRequestDetailsByStatus(int userId, int status)
        {
            var requestDetail = GetRequestByUserId(userId);
            List<RequestDetail> SelectdRequest;
            if (requestDetail != null)
            {
                SelectdRequest = requestDetail.FindAll(x => x.UserId == userId && x.RequestStatus == status);
                return SelectdRequest;
            }
            else
            {
                return null;
            }
        }

        public List<RequestDetail> GetRequestByStatusAndManagerID(int managerId, int status)
        {
            var requestDetail = GetRequestByMangerId(managerId);
            List<RequestDetail> SelectdRequest;
            if (requestDetail != null)
            {
                if (status == 0 || status == 3)
                {
                    SelectdRequest = requestDetail.FindAll(x => x.RequestStatus == status);
                    return SelectdRequest;
                }
                else if (status != 0)
                {
                    SelectdRequest = requestDetail.FindAll(x => x.RequestStatus != 0);
                    return SelectdRequest;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<int> RequestDecisonByManager(int requestId, int? requestStatus)
        {
            return await _requestDetailRepository.RequestDecisonByManager(requestId, requestStatus);
        }

        public async Task<int> RejectionCommentByManager(int id, string comment)
        {
            return await _requestDetailRepository.RejectionCommentByManager(id, comment);
        }

    }
}
