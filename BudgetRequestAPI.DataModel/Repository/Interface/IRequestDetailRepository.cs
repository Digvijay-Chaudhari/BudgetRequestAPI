
using BudgetRequestAPI.DataModel.Entities;
using System.Collections.Generic;


namespace BudgetRequestAPI.DataModel.Repository.Interface
{
    public interface IRequestDetailRepository 
    {
        List<RequestDetail>GetAllRequestDetails();

        List<RequestDetail> GetRequestById(int id);

        RequestDetail GetRequest(int id);

        int AddRequest(RequestDetail requestDetail);

        int UpdateRequest(RequestDetail requestDetail);

        int DeleteRequest(int id);
    }
}
