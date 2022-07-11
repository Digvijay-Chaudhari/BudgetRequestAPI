using AutoMapper;
using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.ServiceModel.DTO.Request;
using BudgetRequestAPI.ServiceModel.DTO.Response;
using BudgetRequestAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailController : ControllerBase
    {
        private readonly IRequestDetailService _irequestDetailService;
        private readonly IMapper _mapper;

        public RequestDetailController(IRequestDetailService requestDetailService,IMapper mapper)
        {
            _irequestDetailService = requestDetailService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("api/Requests")]
        public async Task<ActionResult<IEnumerable<RequestDetailDTO>>> GetAllRequests()
        {
            var requestDetails = await _irequestDetailService.GetAllRequestDetails();
            var requests = _mapper.Map<IEnumerable<RequestDetailDTO>>(requestDetails);
            return Ok(requests);
        }


        //[Authorize]
        //[Route("api/Requests/id")]
        [HttpGet("GetRequestByUserId/{id}")]
        public ActionResult<IEnumerable<RequestDetail>> GetRequestByUserId(int id)
        {
            return _irequestDetailService.GetRequestByUserId(id);
        }



        //[HttpGet]
        [HttpGet("GetRequestByMangerId/{id}")]
        public ActionResult<IEnumerable<RequestDetail>> GetRequestByMangerId(int id)
        {
            return _irequestDetailService.GetRequestByMangerId(id);
        }


        [HttpGet("GetHistoryOfRequestByUserId/{id}")]
        //[Authorize()]
        public async Task<ActionResult<IEnumerable<RequestDetailDTO>>> GetHistoryOfRequestByUserId(int id)
        {
            var requestDetails =  await _irequestDetailService.GetHistoryOfRequestByUserId(id);
            var requests = _mapper.Map<IEnumerable<RequestDetailDTO>>(requestDetails);
            return Ok(requests);
        }


        [HttpPost]
        [Authorize()]
        //[Route("api/Request")]
        public async Task<int> AddRequest([FromBody] RequestDetailDTO requestDetail)
        {
            var response = _mapper.Map<RequestDetail>(requestDetail);
            return await _irequestDetailService.AddRequest(response);
        }


        [HttpGet("{id}")]
        public ActionResult<RequestDetail> GetRequest(int id)
        {
            return  _irequestDetailService.GetRequest(id);
        }


        [HttpPut]
        public async Task<int> UpdateRequest([FromBody] RequestDTO requestDetail)
        {
            var response = _mapper.Map<RequestDetail>(requestDetail);
            return await _irequestDetailService.UpdateRequest(response);
        }


        [HttpDelete("DeleteRequest/{id}")]
        public async Task<int> DeleteRequest(int id)
        {
            return await _irequestDetailService.DeleteRequest(id);
        }


        [HttpGet("{userId}/{Status}")]
        //[Authorize()]

        public ActionResult<IEnumerable<RequestDetail>> GetRequestDetailsByStatus(int userId, int status)
        {
            return  _irequestDetailService.GetRequestDetailsByStatus(userId, status);
        }

        [HttpGet("GetRequestByStatusAndManagerID/{managerId}/{status}")]
        public ActionResult<IEnumerable<RequestDetail>> GetRequestByStatusAndManagerID(int managerId, int status)
        {
            return _irequestDetailService.GetRequestByStatusAndManagerID(managerId, status);
        }


        [HttpPut("{RequestId}/{Status}")]
        public async Task<int> RequestDecisonByManager(int RequestId, int Status)
        {
            return await _irequestDetailService.RequestDecisonByManager(RequestId, Status);
        }

        [HttpPut("RejectionCommentByManager/{RequestId}/{Comment}")]
        public async Task<int> RejectionCommentByManager(int RequestId, string Comment)
        {
            return await _irequestDetailService.RejectionCommentByManager(RequestId, Comment);
        }


    }
}
