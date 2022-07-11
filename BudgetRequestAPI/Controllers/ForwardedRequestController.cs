using AutoMapper;
using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.ServiceModel.DTO.Request;
using BudgetRequestAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForwardedRequestController : Controller
    {
        private readonly IForwardedRequestService _forwardedRequestService;

        private readonly IMapper _mapper;

        public ForwardedRequestController(IForwardedRequestService forwardedRequestService, IMapper mapper)
        {
            _forwardedRequestService = forwardedRequestService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<int> AddForwardedRequest([FromBody] ForwardedRequestDTO requestDetail)
        {
            var response = _mapper.Map<ForwordedRequestDetail>(requestDetail);
            return await _forwardedRequestService.AddForwardedRequest(response);
        }

        [HttpGet("{managerId}/{Status}")]
        public List<ForwordedRequestDetail> GetForwadedRequests(int managerId, int Status)
        {
            return _forwardedRequestService.GetForwadedRequests(managerId, Status);
        }

        [HttpPut("{RequestId}/{Status}")]
        public async Task<int> RequestDecisonBySupManager(int RequestId, int Status)
        {
            return await _forwardedRequestService.RequestDecisonBySupManager(RequestId, Status);
        }

        [HttpPut("RejectionCommentByManager/{RequestId}/{Comment}")]
        public async Task<int> RejectionCommentByManager(int RequestId, string Comment)
        {
            return await _forwardedRequestService.RejectionCommentByManager(RequestId, Comment);
        }

        [HttpGet("{id}")]
        public ActionResult<ForwordedRequestDetail> GetForwardedRequest(int id)
        {
            return _forwardedRequestService.GetForwardedRequest(id);
        }
    }
}
