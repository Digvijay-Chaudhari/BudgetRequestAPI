
using BudgetRequestAPI.DataModel.Entities;
using System.Collections.Generic;


namespace BudgetRequestAPI.DataModel.Repository.Interface
{
    public interface IRequestDetailRepository 
    {
        List<RequestDetail>GetAllRequestDetails();

        List<RequestDetail> GetRequestByUserId(int id);

        RequestDetail GetRequestByRequestId(int id);

        int AddRequest(RequestDetail requestDetail);

        int UpdateRequest(RequestDetail requestDetail);

        int DeleteRequest(int id);

        int RequestDecisonByManager(int RequestId, int StatusID ,string comment);
    }
}
