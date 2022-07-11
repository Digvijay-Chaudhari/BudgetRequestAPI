using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Repository.Interface;
using BudgetRequestAPI.ServiceModel.DTO.Request;
using BudgetRequestAPI.Services.Interface;
using System.Collections.Generic;

namespace BudgetRequestAPI.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _iUserInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _iUserInfoRepository = userInfoRepository;
        }
        public List<UserInfo> GetAllUserInfo()
        {
            return _iUserInfoRepository.GetAllUserInfo();
        }

        public UserInfo GetUserInfo(int id)
        {
            return _iUserInfoRepository.GetUserInfo(id);
        }

        public int AddUserInfo(UserInfo userInfo)
        {
            return _iUserInfoRepository.AddUserInfo(userInfo);
        }

        public int UpdateUserInfo(UserInfo userInfo)
        {
            return _iUserInfoRepository.UpdateUserInfo(userInfo);
        }

        public UserInfo AuthenticateUser(LogInDTO userInformation)
        {
            List<UserInfo> userInfo = GetAllUserInfo();

            UserInfo singleUser = userInfo.Find(x => x.UserName == userInformation.UserName && x.Password == userInformation.Password);

            if (singleUser != null)
            {
                var user = new UserInfo()
                {
                    UserName = singleUser.UserName,
                    UserId = singleUser.UserId,
                    ManagerId = singleUser.ManagerId,
                    IsManager = singleUser.IsManager
                };

                return user;
            }
            else
            {
                return singleUser;
            }


                
        }
    }
}
