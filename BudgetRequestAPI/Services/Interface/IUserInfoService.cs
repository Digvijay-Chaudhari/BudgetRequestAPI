using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.ServiceModel.DTO.Request;
using System.Collections.Generic;

namespace BudgetRequestAPI.Services.Interface
{
    public interface IUserInfoService
    {
        List<UserInfo> GetAllUserInfo();

        UserInfo GetUserInfo(int id);

        int AddUserInfo(UserInfo userInfo);

        int UpdateUserInfo(UserInfo userInfo);

       // UserInfo AuthenticateUser(string Uname,string Pasword);

        UserInfo AuthenticateUser(LogInDTO userInfo);
    }
}
