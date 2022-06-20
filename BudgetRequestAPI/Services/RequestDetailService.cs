using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Repository.Interface;
using BudgetRequestAPI.Services.Interface;
using System.Collections.Generic;

namespace BudgetRequestAPI.Services
{
    public class RequestDetailService : IRequestDetailService
    {
        private readonly IRequestDetailRepository _requestDetailRepository;

        public RequestDetailService(IRequestDetailRepository requestDetailRepository)
        {
            _requestDetailRepository = requestDetailRepository;
        }

        public List<RequestDetail> GetAllRequestDetails()
        {
            return _requestDetailRepository.GetAllRequestDetails();
        }

        public List<RequestDetail> GetRequestById(int id)
        {
            return _requestDetailRepository.GetRequestByUserId(id);
        }

        public int AddRequest(RequestDetail requestDetail)
        {
            return _requestDetailRepository.AddRequest(requestDetail);
        }

        public int UpdateRequest(RequestDetail requestDetail)
        {
            return _requestDetailRepository.UpdateRequest(requestDetail);
        }

        public RequestDetail GetRequest(int id)
        {
            return _requestDetailRepository.GetRequestByRequestId(id);
        }

        public int DeleteRequest(int id)
        {
            return _requestDetailRepository.DeleteRequest(id);
        }

        public List<RequestDetail> GetRequestDetailsByStatus(int UserId,int Status)
        {
            List<RequestDetail> requestDetail = GetRequestById(UserId);
            List<RequestDetail> SelectdRequest;
            if (requestDetail != null)
            {
                SelectdRequest = requestDetail.FindAll(x =>x.UserId == UserId && x.RequestStatus == Status);
                return SelectdRequest;
            }
            else
            {
                return null;
            }
        }

        public int RequestDecisonByManager(int RequestId, int StatusID, string comment)
        {
            return _requestDetailRepository.RequestDecisonByManager(RequestId, StatusID, comment);
        }


    }
}
