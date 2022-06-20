using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BudgetRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailController : ControllerBase
    {
        private readonly IRequestDetailService _irequestDetailService;

        public RequestDetailController(IRequestDetailService requestDetailService)
        {
            _irequestDetailService = requestDetailService;
        }

        [HttpGet]
        [Route("api/Requests")]
        public ActionResult<IEnumerable<RequestDetail>> GetAllRequests()
        {
            return _irequestDetailService.GetAllRequestDetails();
        }

        [HttpGet]
        [Route("api/Requests/id")]
        public ActionResult<IEnumerable<RequestDetail>> GetRequestById(int id)
        {
            return _irequestDetailService.GetRequestById(id);
        }

        [HttpPost]
        [Route("api/Request")]
        public int AddRequest(RequestDetail requestDetail)
        {
            return _irequestDetailService.AddRequest(requestDetail);
        }

        [HttpGet]
        [Route("id")]
        public ActionResult<RequestDetail> GetRequest(int id)
        {
            return _irequestDetailService.GetRequest(id);
        }

        [HttpPut]
        public int UpdateRequest(RequestDetail requestDetail)
        {
            return _irequestDetailService.UpdateRequest(requestDetail);
        }

        [HttpDelete]
        public int DeleteRequest(int id)
        {
            return _irequestDetailService.DeleteRequest(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RequestDetail>> GetRequestDetailsByStatus(int userId, int Status)
        {
            return _irequestDetailService.GetRequestDetailsByStatus(userId, Status);
        }

        [HttpPut]
        [Route("RequestId")]
        public int RequestDecisonByManager(int RequestId, int StatusID,string comment)
        {
            return _irequestDetailService.RequestDecisonByManager(RequestId, StatusID, comment);
        }



    }
}
