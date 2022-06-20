using AutoMapper;
using BudgetRequestAPI.DataModel.DTO;
using BudgetRequestAPI.DataModel.Entities;

namespace BudgetRequestAPI.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserInfo, UserInfoDTO>().ReverseMap();
        }
    }
}
