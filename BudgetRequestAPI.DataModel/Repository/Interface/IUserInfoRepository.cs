using BudgetRequestAPI.DataModel.Entities;
using System.Collections.Generic;

namespace BudgetRequestAPI.DataModel.Repository.Interface
{
    public interface IUserInfoRepository
    {
        List<UserInfo> GetAllUserInfo();

        UserInfo GetUserInfo(int id);

        int AddUserInfo(UserInfo userInfo);

        int UpdateUserInfo(UserInfo userInfo);


    }
}
