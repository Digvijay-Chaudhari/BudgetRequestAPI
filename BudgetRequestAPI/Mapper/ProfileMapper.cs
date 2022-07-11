using AutoMapper;

using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataService.DTO.Response;
using BudgetRequestAPI.ServiceModel.DTO.Request;
using BudgetRequestAPI.ServiceModel.DTO.Response;

namespace BudgetRequestAPI.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserInfo, UserInfoDTO>().ReverseMap();

            CreateMap<UserInfo, LogInDTO>().ReverseMap();

            CreateMap<RequestDetail, RequestDetailDTO>().ReverseMap();

            CreateMap<RequestDetail, RequestDTO>().ReverseMap();

            CreateMap<ForwordedRequestDetail, ForwardedRequestDTO>().ReverseMap();
        }
    }
}
