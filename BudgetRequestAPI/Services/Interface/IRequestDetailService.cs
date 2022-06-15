using BudgetRequestAPI.DataModel.Entities;
using System.Collections.Generic;

namespace BudgetRequestAPI.Services.Interface
{
    public interface IRequestDetailService
    {
        List<RequestDetail> GetAllRequestDetails();

        List<RequestDetail>  GetRequestById(int id);

        RequestDetail GetRequest(int id);

        int AddRequest(RequestDetail requestDetail);

        int UpdateRequest(RequestDetail requestDetail);

        int DeleteRequest(int id);

        List<RequestDetail> GetRequestDetailsByStatus(int UserId,int StatusID);

    }
}
