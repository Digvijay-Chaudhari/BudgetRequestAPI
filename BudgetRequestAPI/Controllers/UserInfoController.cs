using AutoMapper;
using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataService.DTO.Response;
using BudgetRequestAPI.ServiceModel.DTO.Request;
using BudgetRequestAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BudgetRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _IUserInfoService;

        private readonly IMapper _mapper;
        public UserInfoController(IUserInfoService userInfoService, IMapper mapper)
        {
            _IUserInfoService = userInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/UserInfo")]
        public ActionResult<List<UserInfoDTO>> GetAllUserInfo()
        {
            var Dto = _IUserInfoService.GetAllUserInfo();
            var mappingResponse = _mapper.Map<List<UserInfoDTO>>(Dto);
            return mappingResponse;
        }

        [HttpGet("{id}")]
        public UserInfo GetUserInfo(int id)
        {
            return _IUserInfoService.GetUserInfo(id);
        }

        [HttpPost]
        [Route("api/UserInfo")]
        public int AddUserInfo(UserInfo userInfo)
        {
            return  _IUserInfoService.AddUserInfo(userInfo);
        }

        [HttpPut]
        public int UpdateUserInfo(UserInfo userInfo)
        {
            return _IUserInfoService.UpdateUserInfo(userInfo);
        }

        [HttpGet]
        public UserInfo AuthenticateUser(LogInDTO userInfoDto)
        {
            return _IUserInfoService.AuthenticateUser(userInfoDto);
        }
    }
}
